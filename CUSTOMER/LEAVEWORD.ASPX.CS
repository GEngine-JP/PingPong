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

public partial class LeavewordPage : System.Web.UI.Page
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
		{
			BindPageData(userID,fellowID);
		}
	}

	private void BindPageData(int userID,int fellowID)
	{   ///获取好友信息
		ASPNETAJAXWeb.AjaxInstantMessaging.User user = new ASPNETAJAXWeb.AjaxInstantMessaging.User();
		SqlDataReader dr = user.GetSingleUser(fellowID);
		if(dr == null) return;
		if(dr.Read())
		{   ///显示好友名称
			lbUsername.Text = dr["Username"].ToString();
		}
		dr.Close();
	}
	protected void btnCommit_Click(object sender,EventArgs e)
	{   ///发送留言
		Leaveword leaveword = new Leaveword();
		if(leaveword.AddLeaveword(tbMessage.Text,userID,fellowID) > 0)
		{
			AjaxInstantMessagingSystem.ShowAjaxDialog((Button)sender,"恭喜您，发送留言给团队" + lbUsername.Text + "成功。");
		}
	}
}
