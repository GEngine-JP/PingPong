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

public partial class UserInfo_ShowLeavewordInfo : System.Web.UI.Page
{
	int leavewordID = -1;
	protected void Page_Load(object sender,EventArgs e)
	{  	///获取留言的ID值
		if(Request.Params["LeavewordID"] != null)
		{
			leavewordID = Int32.Parse(Request.Params["LeavewordID"].ToString());
		}
		if(!Page.IsPostBack && leavewordID > 0)
		{   ///修改留言状态，并显示留言
			UpdataLeavewordStatus(leavewordID);
			BindPageData(leavewordID);
		}
	}

	private void UpdataLeavewordStatus(int leavewordID)
	{   ///把留言状态修改为已读
		Leaveword leaveword = new Leaveword();
		leaveword.UpdateLeavewordStatus(leavewordID);
	}

	private void BindPageData(int leavewordID)
	{   ///获取留言信息
		Leaveword leaveword = new Leaveword();
		SqlDataReader dr = leaveword.GetSingleLeaveword(leavewordID);
		if(dr == null) return;
		if(dr.Read())
		{   ///显示留言信息
			lbUsername.Text = dr["SenderName"].ToString();
			tbMessage.Text = dr["Body"].ToString();
			lbCreateDate.Text = dr["CreateDate"].ToString();
		}
		dr.Close();
	}
	protected void btnCommit_Click(object sender,EventArgs e)
	{
		Response.Write("<script>window.close();</script>");
	}
}
