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

public partial class LogOff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {   ///清空用户信息
		Session["UserID"] = null;
		Session["Username"] = null;
		///停止当前会话
		Session.Clear();
		Session.Abandon();
		///重定向到用户登录页面
		Response.Redirect("~/Login.aspx");
    }
}
