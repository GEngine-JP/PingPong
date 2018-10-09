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

public partial class Caboodle_AddCaboodle : System.Web.UI.Page
{
	int userID = -1;
	protected void Page_Load(object sender,EventArgs e)
	{   ///判断用户是否登录
		if(Session["UserID"] == null)
		{
			Response.Redirect("~/Login.aspx");
			return;
		}
		///获取用户信息
		userID = Int32.Parse(Session["UserID"].ToString());
	}
	protected void btnCommit_Click(object sender,EventArgs e)
	{   Caboodle caboodle = new Caboodle();
		if(caboodle.AddCaboodle(tbName.Text,userID,tbRemark.Text) > 0)
		{
			Response.Redirect("~/Caboodle/CaboodleManage.aspx");
		}
	}
}
