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

public partial class Caboodle_CaboodleManage : System.Web.UI.Page
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
		Caboodle caboodle = new Caboodle();
		DataSet ds = caboodle.GetSelfCaboodleByUser(userID);
		if(ds == null || ds.Tables.Count <= 0) return;
		///显示数据
		gvCaboodle.DataSource = ds;
		gvCaboodle.DataBind();

		if(ds.Tables[0].Rows.Count <= 0) btnAdd.Enabled = true;
		else btnAdd.Enabled = false;
	}

	protected void btnAdd_Click(object sender,EventArgs e)
	{
		Response.Redirect("~/Caboodle/AddCaboodle.aspx");
	}
	protected void gvCaboodle_RowCommand(object sender,GridViewCommandEventArgs e)
	{
		if(e.CommandName.ToLower() == "update")
		{   ///重定向到修改组页面
			Response.Redirect("~/Caboodle/UpdateCaboodle.aspx?CaboodleID=" + e.CommandArgument.ToString());
			return;
		}
		if(e.CommandName.ToLower() == "del")
		{   ///删除选择的组
			Caboodle caboodle = new Caboodle();
			if(caboodle.DeleteCaboodle(Int32.Parse(e.CommandArgument.ToString())) > 0)
			{
				BindPageData(userID);
			}
			return;
		}
	}
	protected void gvCaboodle_RowDataBound(object sender,GridViewRowEventArgs e)
	{   ///添加删除确认的对话框
		ImageButton imgDelete = (ImageButton)e.Row.FindControl("imgDelete");
		if(imgDelete != null)
		{
			imgDelete.Attributes.Add("onclick","return confirm(\"您确认要删除当前行的组吗？\");");
		}
	}
}
