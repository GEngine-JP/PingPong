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

public partial class SelectCaboodle : System.Web.UI.Page
{
	int userID = -1;
	protected void Page_Load(object sender,EventArgs e)
	{   ///判断用户是否登录
		if(Session["UserID"] == null)
		{
			Response.Redirect("~/Login.aspx");
			return;
		}
		///获取用户的ID值
		userID = Int32.Parse(Session["UserID"].ToString());		
		if(!Page.IsPostBack && userID > 0)
		{
			BindPageData(userID);
		}
	}

	private void BindPageData(int userID)
	{   ///获取好友信息
		ASPNETAJAXWeb.AjaxInstantMessaging.User user = new ASPNETAJAXWeb.AjaxInstantMessaging.User();
		SqlDataReader dr = user.GetSingleUser(userID);
		if(dr == null) return;
		if(dr.Read())
		{   ///显示好友名称
			lbUsername.Text = dr["Username"].ToString();
		}
		dr.Close();

		///读取数据
		Caboodle caboodle = new Caboodle();
		DataSet ds = caboodle.GetCaboodleByUser(userID);
		///显示数据
		ddlCaboodle.DataSource = ds;
		ddlCaboodle.DataTextField = "Name";
		ddlCaboodle.DataValueField = "ID";
		ddlCaboodle.DataBind();
	}

	protected void btnCommit_Click(object sender,EventArgs e)
	{   ///进入选择的团队if(ddlCaboodle.SelectedIndex > -1)
		{
			Response.Redirect("~/CaboodleMessaging.aspx?CaboodleID=" + ddlCaboodle.SelectedValue);
		}
	}
}
