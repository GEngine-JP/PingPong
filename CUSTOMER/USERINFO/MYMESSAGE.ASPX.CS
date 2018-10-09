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

public partial class UserInfo_MyMessage : System.Web.UI.Page
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
		{   ///显示好友信息
			BindFellowData(userID);
			if(ddlUser.SelectedIndex > -1)
			{   
				BindPageData(userID,Int32.Parse(ddlUser.SelectedValue));
			}
		}
	}

	private void BindFellowData(int userID)
	{	///获取好友信息
		ASPNETAJAXWeb.AjaxInstantMessaging.User user = new ASPNETAJAXWeb.AjaxInstantMessaging.User();
		DataSet ds = user.GetFellowByUser(userID);
		///显示好友列表
		ddlUser.DataSource = ds;
		ddlUser.DataTextField = "Username";
		ddlUser.DataValueField = "ID";
		ddlUser.DataBind();
		///设置第一项为选择项，如果存在
		if(ddlUser.Items.Count > 0) ddlUser.SelectedIndex = 0;
	}

	private void BindPageData(int userID,int fellowID)
	{///读取数据
		MessageForSingle message = new MessageForSingle();
		DataSet ds = message.GetMessageByUser(userID,fellowID);
		///显示数据
		gvMessage.DataSource = ds;
		gvMessage.DataBind();
	}

	protected void ddlUser_SelectedIndexChanged(object sender,EventArgs e)
	{   ///显示数据
		BindPageData(userID,Int32.Parse(ddlUser.SelectedValue));
	}
	protected void gvMessage_PageIndexChanging(object sender,GridViewPageEventArgs e)
	{   ///设置新的页面并显示数据
		gvMessage.PageIndex = e.NewPageIndex;
		BindPageData(userID,Int32.Parse(ddlUser.SelectedValue));
	}
	protected void btnToExcell_Click(object sender,EventArgs e)
	{   ///重定向到导出Excell文件页面
		if(ddlUser.SelectedIndex <= -1) return;
		Response.Redirect("~/UserInfo/OutputToExcel.aspx?UserID=" + userID.ToString()
			+ "&FellowID=" + ddlUser.SelectedValue);
	}
	protected void btnToTxt_Click(object sender,EventArgs e)
	{   ///重定向到导出文本文件页面
		if(ddlUser.SelectedIndex <= -1) return;
		Response.Redirect("~/UserInfo/OutputToTxt.aspx?UserID=" + userID.ToString()
			+ "&FellowID=" + ddlUser.SelectedValue);
	}
}
