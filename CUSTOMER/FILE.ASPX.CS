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
using System.IO;

public partial class FilePage : System.Web.UI.Page
{
	int userID = -1;
	int fellowID = -1;
	protected void Page_Load(object sender,EventArgs e)
	{   ///判断用户是否登录
		if(Session["UserID"] == null)
		{
			Response.Redirect("~/Login.aspx");
			return;
		}
		///获取用户的ID值
		userID = Int32.Parse(Session["UserID"].ToString());
		if(Request.Params["UserID"] != null)
		{
			fellowID = Int32.Parse(Request.Params["UserID"].ToString());
		}
		if(!Page.IsPostBack && userID > 0 && fellowID > 0)
		{
			BindPageData(userID,fellowID);
		}
	}

	private void BindPageData(int userID,int fellowID)
	{   ///获取好友信息
		ASPNETAJAXWeb.AjaxInstantMessaging.User user = new ASPNETAJAXWeb.AjaxInstantMessaging.User();
		SqlDataReader dr = user.GetSingleUser(fellowID);
		if(dr == null) return;
		if(dr.Read())
		{   ///显示好友名称
			lbUsername.Text = dr["Username"].ToString();
		}
		dr.Close();
	}
	protected void btnCommit_Click(object sender,EventArgs e)
	{   ///判断上载文件的内容是否为空
		if(fuFile.HasFile == false || fuFile.PostedFile.ContentLength <= 0)
		{
			lbMessage.Text = "上载文件的内容为空，请重新选择文件！";
			return;
		}
		///获取上载文件的属性，如类型、大小、名称等
		string type = fuFile.PostedFile.ContentType;
		int size = fuFile.PostedFile.ContentLength;
		string oldFileName = Path.GetFileNameWithoutExtension(fuFile.PostedFile.FileName);
		///创建基于时间的文件名称
		string fileName = AjaxInstantMessagingSystem.CreateDateTimeString();
		string extension = Path.GetExtension(fuFile.PostedFile.FileName);
		///构建保存文件位置的路径
		string url = "Files/" + fileName + extension;
		///映射为物理路径
		string fullPath = Server.MapPath(url);
		///判断文件是否存在
		if(System.IO.File.Exists(fullPath) == true)
		{
			lbMessage.Text = "上载文件的已经存在，请重新选择文件！";
			return;
		}

		try
		{   ///上载文件
			fuFile.SaveAs(fullPath);
			ASPNETAJAXWeb.AjaxInstantMessaging.File file = new ASPNETAJAXWeb.AjaxInstantMessaging.File();
			///添加到数据库中
			if(file.AddFile(oldFileName,userID,fellowID,url,type,size) > 0)
			{
				lbMessage.Text = "恭喜您，发送文件（" + oldFileName + "）给团队" + lbUsername.Text + "成功。";
			}
		}
		catch(Exception ex)
		{   ///显示错误信息
			lbMessage.Text = "上载文件错误，错误原因为：" + ex.Message;
			return;
		}
	}
}
