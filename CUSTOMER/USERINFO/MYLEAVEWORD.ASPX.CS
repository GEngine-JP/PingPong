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

public partial class UserInfo_MyLeaveword : System.Web.UI.Page
{
	int userID = -1;
	protected void Page_Load(object sender,EventArgs e)
	{   ///判断用户是否登录
		if(Session["UserID"] == null)
		{
			Response.Redirect("~/Default.aspx");
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
		Leaveword leaveword = new Leaveword();
		DataSet ds = leaveword.GetLeavewordByUser(userID);
		///显示数据
		gvLeaveword.DataSource = ds;
		gvLeaveword.DataBind();
	}

	protected void gvLeaveword_RowCommand(object sender,GridViewCommandEventArgs e)
	{
		if(e.CommandName.ToLower() == "del")
		{   ///删除选择的留言
			Leaveword leaveword = new Leaveword();
			if(leaveword.DeleteLeaveword(Int32.Parse(e.CommandArgument.ToString())) > 0)
			{
				BindPageData(userID);
			}
			return;
		}
	}
	protected void gvLeaveword_RowDataBound(object sender,GridViewRowEventArgs e)
	{   ///添加删除确认的对话框
		ImageButton imgDelete = (ImageButton)e.Row.FindControl("imgDelete");
		if(imgDelete != null)
		{
			imgDelete.Attributes.Add("onclick","return confirm(\"您确认要删除当前行的留言吗？\");");
		}
	}
}
