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

public partial class Hailfellow_Fellow : System.Web.UI.Page
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
		if(!Page.IsPostBack)
		{
			BindPageData(userID);
		}
	}

	private void BindPageData(int userID)
	{   ///读取数据
		Group group = new Group();
		DataSet ds = group.GetGroupByUser(userID);
		///显示数据
		gvGroup.DataSource = ds;
		gvGroup.DataBind();
	}

	private void BindUserData(DataList dl,int groupID)
	{   ///获取组中的用户
		GroupUser gu = new GroupUser();
		DataSet ds = gu.GetUserbyGroup(groupID);
		///显示组中的用户
		dl.DataSource = ds;
		dl.DataBind();
	}	

	protected void gvGroup_RowDataBound(object sender,GridViewRowEventArgs e)
	{   ///显示每一个组的用户
		DataList dlUser = (DataList)e.Row.FindControl("dlUser");
		if(dlUser != null)
		{   ///绑定数据
			BindUserData(dlUser,Int32.Parse(gvGroup.DataKeys[e.Row.RowIndex].Value.ToString()));
		}
	}
}
