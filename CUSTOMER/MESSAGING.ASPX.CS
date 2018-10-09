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

public partial class Messaging : System.Web.UI.Page
{
	int userID = -1;
	int fellowID = -1;
	protected void Page_Load(object sender,EventArgs e)
	{   ///判断用户是否登录
		if(Session["UserID"] == null)
		{
			Response.Redirect("~/Login.aspx");
			return;
		}
		///获取用户的ID值
		userID = Int32.Parse(Session["UserID"].ToString());
		if(Request.Params["UserID"] != null)
		{
			fellowID = Int32.Parse(Request.Params["UserID"].ToString());
		}
		if(!Page.IsPostBack && userID > 0 && fellowID > 0)
		{	///保存进入聊天室的时间
			ViewState["StartDate"] = DateTime.Now.ToString();
			BindPageData(userID,fellowID);
		}
		btnCommit.Enabled = (userID > 0 && fellowID > 0) ? true : false;
	}

	private void BindPageData(int userID,int fellowID)
	{   ///获取好友信息
		ASPNETAJAXWeb.AjaxInstantMessaging.User user = new ASPNETAJAXWeb.AjaxInstantMessaging.User();
		SqlDataReader dr = user.GetSingleUser(fellowID);
		if(dr == null) return;
		if(dr.Read())
		{   ///显示好友名称
			lbUsername.Text = "正在与团队：" + dr["Username"].ToString() + " 聊天...";
		}
		dr.Close();
	}

	private void ShowMessageData()
	{   ///获取所有消息
		MessageForSingle message = new MessageForSingle();
		DataSet ds = message.GetMessageByUser(userID,fellowID);
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
		MessageForSingle message = new MessageForSingle();
		if(message.AddMessage(tbMessage.Text,userID,fellowID) > 0)
		{   ///重新显示消息
			ShowMessageData();
		}
	}
	protected void tUser_Tick(object sender,EventArgs e)
	{   ///显示最新消息
		ShowMessageData();
	}
}
