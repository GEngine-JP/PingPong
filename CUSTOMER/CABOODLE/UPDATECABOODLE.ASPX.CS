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

public partial class Caboodle_UpdateCaboodle : System.Web.UI.Page
{
	int caboodleID = -1;
    protected void Page_Load(object sender, EventArgs e)
    {   ///获取群的ID值
		if(Request.Params["CaboodleID"] != null)
		{
			caboodleID = Int32.Parse(Request.Params["CaboodleID"].ToString());
		}
		if(!Page.IsPostBack && caboodleID > 0)
		{   ///显示群信息
			BindPageData(caboodleID);
		}
    }

	private void BindPageData(int caboodleID)
	{   ///读取数据
		Caboodle caboodle = new Caboodle();
		SqlDataReader dr = caboodle.GetSingleCaboodle(caboodleID);
		if(dr == null) return;
		///显示数据
		if(dr.Read())
		{
			tbName.Text = dr["Name"].ToString();
			tbRemark.Text = dr["Remark"].ToString();
		}
		dr.Close();
	}

	protected void btnCommit_Click(object sender,EventArgs e)
	{   ///修改团队Caboodle caboodle = new Caboodle();
		if(caboodle.UpdateCaboodle(caboodleID,tbName.Text,tbRemark.Text) > 0)
		{
			Response.Redirect("~/Caboodle/CaboodleManage.aspx");
		}
	}
}
