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

public partial class Caboodle_AddCaboodleUser : System.Web.UI.Page
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
		if(!Page.IsPostBack && userID > 0)
		{
			BindPageData(userID);
		}
	}

	private void BindPageData(int userID)
	{   ///获取群信息
		Caboodle caboodle = new Caboodle();
		DataSet ds = caboodle.GetSelfCaboodleByUser(userID);
		if(ds == null || ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0) return;
		///显示群的名称
		lbGroupName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
		///保存群的ID值
		ViewState["CaboodleIDKey"] = ds.Tables[0].Rows[0]["ID"].ToString();
		///获取数据
		ASPNETAJAXWeb.AjaxInstantMessaging.User user = new ASPNETAJAXWeb.AjaxInstantMessaging.User();
		///绑定并显示数据
		gvUser.DataSource = user.GetFellowNotInCaboodleByUser(userID);
		gvUser.DataBind();
	}

	protected void gvUser_RowCommand(object sender,GridViewCommandEventArgs e)
	{
		if(e.CommandName.ToLower() == "add")
		{
			if(ViewState["CaboodleIDKey"] != null)
			{
				CaboodleUser caboodleUser = new CaboodleUser();
				///获取群的ID值
				int caboodleID = Int32.Parse(ViewState["CaboodleIDKey"].ToString());
				///添加好友到团队caboodleUser.AddCaboodleUser(caboodleID,Int32.Parse(e.CommandArgument.ToString()),4);
				///显示操作结果
				AjaxInstantMessagingSystem.ShowAjaxDialog((Button)e.CommandSource,"恭喜您，添加好友到群成功。");
				///重新显示数据
				BindPageData(userID);
			}
			return;
		}
	}
	protected void gvUser_PageIndexChanging(object sender,GridViewPageEventArgs e)
	{   ///重新显示数据
		gvUser.PageIndex = e.NewPageIndex;
		BindPageData(userID);
	}
}
