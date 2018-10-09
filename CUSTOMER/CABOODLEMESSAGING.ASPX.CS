using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

///引入新的命名空间
using ASPNETAJAXWeb.AjaxInstantMessaging;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;

public partial class CaboodleMessaging : System.Web.UI.Page
{
	int userID = -1;
	int caboodleID = -1;
	protected void Page_Load(object sender,EventArgs e)
	{   ///判断用户是否登录
		if(Session["UserID"] == null)
		{
			Response.Redirect("~/Login.aspx");
			return;
		}
		///获取用户的ID值
		userID = Int32.Parse(Session["UserID"].ToString());
		if(Request.Params["CaboodleID"] != null)
		{
			caboodleID = Int32.Parse(Request.Params["CaboodleID"].ToString());
		}
		if(!Page.IsPostBack && userID > 0 && caboodleID > 0)
		{	///保存进入聊天室的时间
			ViewState["StartDate"] = DateTime.Now.ToString();
			///设置用户登录当前团队InitCaboodleUser();
			///显示消息和用户
			BindPageData(userID,caboodleID);
			ShowUserData();
		}
		btnCommit.Enabled = (userID > 0 && caboodleID > 0) ? true : false;
	}

	private void InitCaboodleUser()
	{  ///设置用户进入的团队for(int i = 0; i < ASP.global_asax.Users.Count; i++)
		{
			if(ASP.global_asax.Users[i].UserID.ToString() == Session["UserID"].ToString())
			{
				ASP.global_asax.Users[i].CaboodleID = caboodleID;
				break;
			}
		}
	}
	private void ShowUserData()
	{   ///获取群聊天室的用户
		List<UserInfo> users = new List<UserInfo>();
		foreach(UserInfo ui in ASP.global_asax.Users)
		{
			if(ui.CaboodleID == caboodleID)
			{
				users.Add(ui);
			}
		}
		///显示群聊天室的用户
		lbUser.DataSource = users;
		lbUser.DataValueField = "UserID";
		lbUser.DataTextField = "Username";
		lbUser.DataBind();
	}

	private void BindPageData(int userID,int caboodleID)
	{   ///获取用户信息
		ASPNETAJAXWeb.AjaxInstantMessaging.User user = new ASPNETAJAXWeb.AjaxInstantMessaging.User();
		SqlDataReader dr = user.GetSingleUser(userID);
		if(dr == null) return;
		string username = string.Empty;
		if(dr.Read())
		{   ///获取用户名称
			username = dr["Username"].ToString();
		}
		dr.Close();
		///获取群信息
		Caboodle caboodle = new Caboodle();
		SqlDataReader drc = caboodle.GetSingleCaboodle(caboodleID);
		if(drc == null) return;
		if(drc.Read())
		{   ///读取并显示群的信息
			lbInfoMessage.Text = "用户 " + username + " 正在 " + drc["Name"].ToString() + " 群中聊天...";
		}
		drc.Close();
	}

	private void ShowMessageData(int caboodleID)
	{   ///获取所有消息
		MessageForCaboodle message = new MessageForCaboodle();
		DataSet ds = message.GetMessageByCaboodle(caboodleID);
		if(ds == null || ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0) return;
		///过滤进入该聊天室之前的消息，保留进入该聊天室之后的消息
		DataView dv = ds.Tables[0].DefaultView;
		dv.RowFilter = string.Format("CreateDate >= '{0}'",DateTime.Parse(ViewState["StartDate"].ToString()));
		///构建聊天的消息
		StringBuilder sbMessage = new StringBuilder();
		foreach(DataRowView row in dv)
		{   ///设置一条消息
			string singleMessage = row["SenderName"].ToString() + " 在[" + row["CreateDate"].ToString() + "]发表：\n";
			singleMessage += "　　" + row["Body"].ToString() + "\n";
			sbMessage.Append(singleMessage);
		}
		///显示聊天消息
		tbChatMessage.Text = sbMessage.ToString();
	}

	protected void btnCommit_Click(object sender,EventArgs e)
	{   ///发送消息
		MessageForCaboodle message = new MessageForCaboodle();
		if(message.AddMessage(tbMessage.Text,userID,caboodleID) > 0)
		{   ///重新显示消息
			ShowMessageData(caboodleID);
		}
	}
	protected void tUser_Tick(object sender,EventArgs e)
	{   ///显示最新消息和在线用户
		ShowMessageData(caboodleID);
		ShowUserData();
	}
}
