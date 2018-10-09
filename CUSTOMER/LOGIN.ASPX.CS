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
using ASPNETAJAXWeb.ValidateCode.Page;
using System.Data.SqlClient;

public partial class UserLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void btnLogin_Click(object sender,EventArgs e)
	{
		if(Session[ValidateCode.VALIDATECODEKEY] != null)
		{   ///验证验证码是否相等
			if(tbCode.Text != Session[ValidateCode.VALIDATECODEKEY].ToString())
			{
				lbMessage.Text = "验证码输入错误，请重新输入";
				return;
			}
			///判断用户的密码和名称是否正确
			ASPNETAJAXWeb.AjaxInstantMessaging.User user = new ASPNETAJAXWeb.AjaxInstantMessaging.User();
			SqlDataReader dr = user.GetUserLogin(tbUsername.Text,tbPassword.Text);
			if(dr == null)return;
			
			bool isLogin = false;
			if(dr.Read())
			{   //读取用户的登录信息，并保存
				UserInfo ui = new UserInfo();
				ui.UserID = Int32.Parse(dr["ID"].ToString());
				ui.Username = tbUsername.Text;
				///保存到Session中
				Session["UserID"] = ui.UserID;
				Session["Username"] = ui.Username;
				///保存到全局信息中
				ASP.global_asax.Users.Add(ui);
				isLogin = true;
			}
			dr.Close();
			///如果用户登录成功
			if(isLogin == true)
			{
				Response.Redirect("~/Default.aspx");
				return;
			}
		}
	}
	protected void btnReturn_Click(object sender,EventArgs e)
	{   ///清空各种输入框中的信息
		tbUsername.Text = tbPassword.Text = tbCode.Text = string.Empty;
	}
}
