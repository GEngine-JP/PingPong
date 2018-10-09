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
using ASPNETAJAXWeb.ValidateCode.Page;

public partial class Hailfellow_SearchFellow : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

	private void ShowSearchResult()
	{   ///获取数据
		ASPNETAJAXWeb.AjaxInstantMessaging.User user = new ASPNETAJAXWeb.AjaxInstantMessaging.User();
		DataSet ds = user.GetUsers();
		if(ds == null || ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0) return;
		if(string.IsNullOrEmpty(tbKey.Text) == true) return;
		///搜索给定条件的用户
		DataView dv = ds.Tables[0].DefaultView;
		switch(ddlMethod.SelectedValue)
		{
			case "0":
				{   ///按用户名称搜索
					dv.RowFilter = "Username LIKE '*" + tbKey.Text + "*'";
					break;
				}
			case "1":
				{   ///按用户别名搜索
					dv.RowFilter = "Aliasname LIKE '*" + tbKey.Text + "*'";
					break;
				}
			case "2":
				{   ///按用户号码搜索
					dv.RowFilter = "UserIdentity LIKE '*" + tbKey.Text + "*'";
					break;
				}
			default: break;
		}
		dv.Sort = "UserIdentity";

		///显示数据
		gvUser.DataSource = dv;
		gvUser.DataBind();
	}

	protected void btnCommit_Click(object sender,EventArgs e)
	{	///初始化搜索结果数据
		gvUser.DataSource = null;
		gvUser.DataBind();
		lbMessage.Visible = false;
		if(Session[ValidateCode.VALIDATECODEKEY] != null)
		{   ///验证验证码是否相等
			if(tbCode.Text != Session[ValidateCode.VALIDATECODEKEY].ToString())
			{
				lbMessage.Text = "验证码输入错误，请重新输入";
				lbMessage.Visible = true;
				return;
			}
		} 
		///搜索用户
		ShowSearchResult();
	}
	protected void gvUser_RowCommand(object sender,GridViewCommandEventArgs e)
	{
		if(e.CommandName.ToLower() == "add")
		{   ///重定向到添加好友页面
			Response.Redirect("~/Hailfellow/AddFellow.aspx?FellowID=" + e.CommandArgument.ToString());
			return;
		}
	}
	protected void gvUser_PageIndexChanging(object sender,GridViewPageEventArgs e)
	{   ///重新显示数据
		gvUser.PageIndex = e.NewPageIndex;
		ShowSearchResult();
	}
}
