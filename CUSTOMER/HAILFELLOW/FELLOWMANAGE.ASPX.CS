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

public partial class Hailfellow_FellowManage : System.Web.UI.Page
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

	private void BindUserData(GridView gv,int groupID)
	{   ///获取组的用户
		GroupUser gu = new GroupUser();
		DataSet ds = gu.GetUserbyGroup(groupID);
		///显示组用户信息
		gv.DataSource = ds;
		gv.DataBind();
	}

	protected void gvGroup_RowDataBound(object sender,GridViewRowEventArgs e)
	{   ///显示组的用户
		GridView gvUser = (GridView)e.Row.FindControl("gvUser");
		if(gvUser != null)
		{
			BindUserData(gvUser,Int32.Parse(gvGroup.DataKeys[e.Row.RowIndex].Value.ToString()));
			gvUser.EmptyDataText = gvGroup.DataKeys[e.Row.RowIndex].Value.ToString();
		}
	}
	protected void gvUser_RowCommand(object sender,GridViewCommandEventArgs e)
	{
		if(e.CommandName.ToLower() == "del")
		{   ///删除组中的团队GroupUser groupUser = new GroupUser();
			int groupID = Int32.Parse(((GridView)sender).EmptyDataText);
			if(groupUser.DeleteGroupUser(groupID,Int32.Parse(e.CommandArgument.ToString())) > 0)
			{
				BindUserData((GridView)sender,groupID);
			}
			return;
		}
	}
	protected void gvUser_RowDataBound(object sender,GridViewRowEventArgs e)
	{	///添加删除确认的对话框
		ImageButton imgDelete = (ImageButton)e.Row.FindControl("imgDelete");
		if(imgDelete != null)
		{
			imgDelete.Attributes.Add("onclick","return confirm(\"您确认要删除当前行的用户吗？\");");
		}
	}
}
