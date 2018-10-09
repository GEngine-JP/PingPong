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

public partial class Hailfellow_ShowFellowInfo : System.Web.UI.Page
{
	int userID = -1;
	protected void Page_Load(object sender,EventArgs e)
	{  	///获取用户的ID值
		if(Request.Params["UserID"] != null)
		{
			userID = Int32.Parse(Request.Params["UserID"].ToString());
		}
		if(!Page.IsPostBack && userID > 0)
		{   ///显示用户的信息
			BindPageData(userID);
		}
	}

	private void BindPageData(int userID)
	{   ///获取用户信息
		ASPNETAJAXWeb.AjaxInstantMessaging.User user = new ASPNETAJAXWeb.AjaxInstantMessaging.User();
		SqlDataReader dr = user.GetSingleUser(userID);
		if(dr == null) return;
		if(dr.Read())
		{   ///显示用户信息
			lbUsername.Text = dr["Username"].ToString();
			lbAliasname.Text = dr["Aliasname"].ToString();
			lbUserIdentity.Text = dr["UserIdentity"].ToString();
			lbEmail.Text = dr["Email"].ToString();
		}
		dr.Close();
	}
	protected void btnCommit_Click(object sender,EventArgs e)
	{
		Response.Write("<script>window.close();</script>");
	}
}
