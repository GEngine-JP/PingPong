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

public partial class Caboodle_CaboodleUserManage : System.Web.UI.Page
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
	{   ///读取群的数据
		Caboodle caboodle = new Caboodle();
		DataSet ds = caboodle.GetSelfCaboodleByUser(userID);
		if(ds == null || ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0) return;
		///获取群的ID值
		int caboodleID = Int32.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
		///保存群的ID值
		ViewState["CaboodleID"] = caboodleID.ToString();
		///读取群的用户数据
		CaboodleUser caboodleUser = new CaboodleUser();
		DataSet dsUser = caboodleUser.GetUserbyCaboodle(caboodleID);
		if(ds == null || ds.Tables.Count <= 0) return;
		///显示群的用户数据
		gvUser.DataSource = dsUser;
		gvUser.DataBind();
	}	
	protected void gvUser_RowCommand(object sender,GridViewCommandEventArgs e)
	{
		if(e.CommandName.ToLower() == "del")
		{   ///删除群中的用户
			CaboodleUser caboodleUser = new CaboodleUser();
			if(ViewState["CaboodleID"] != null)
			{   ///获取群的ID值
				int caboodleID = Int32.Parse(ViewState["CaboodleID"].ToString());
				if(caboodleUser.DeleteCaboodleUser(caboodleID,Int32.Parse(e.CommandArgument.ToString())) > 0)
				{   ///重新显示群中的用户
					BindPageData(userID);
				}
			}
			return;
		}
	}
	protected void gvUser_RowDataBound(object sender,GridViewRowEventArgs e)
	{   ///添加删除确认的对话框
		ImageButton imgDelete = (ImageButton)e.Row.FindControl("imgDelete");
		if(imgDelete != null)
		{
			imgDelete.Attributes.Add("onclick","return confirm(\"您确认要删除当前行的用户吗？\");");
		}
	}
	protected void btnAdd_Click(object sender,EventArgs e)
	{
		Response.Redirect("~/Caboodle/AddCaboodleUser.aspx");
	}	
}
