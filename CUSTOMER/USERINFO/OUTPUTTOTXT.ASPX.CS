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

public partial class UserInfo_OutputToTxt : System.Web.UI.Page
{
	int userID = -1;
	int fellowID = -1;
	protected void Page_Load(object sender,EventArgs e)
	{   ///判断用户是否登录
		if(Session["UserID"] == null)
		{
			Response.Redirect("~/Default.aspx");
			return;
		}
		///获取用户的ID值
		userID = Int32.Parse(Session["UserID"].ToString());
		if(Request.Params["FellowID"] != null)
		{   ///获取好友的ID
			fellowID = Int32.Parse(Request.Params["FellowID"].ToString());
		}
		///导出数据为Excell文件
		MessageForSingle message = new MessageForSingle();
		OutputData.SaveAsTxt(Page,message.GetMessageByUser(userID,fellowID));
	}	
}
