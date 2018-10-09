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

public partial class Hailfellow_UpdateGroup : System.Web.UI.Page
{
	int groupID = -1;
    protected void Page_Load(object sender, EventArgs e)
    {   ///获取数据的ID值
		if(Request.Params["GroupID"] != null)
		{
			groupID = Int32.Parse(Request.Params["GroupID"].ToString());
		}
		if(!Page.IsPostBack && groupID > 0)
		{
			BindPageData(groupID);
		}
    }

	private void BindPageData(int groupID)
	{   ///读取数据
		Group group = new Group();
		SqlDataReader dr = group.GetSingleGroup(groupID);
		if(dr == null) return;
		///显示数据
		if(dr.Read())
		{
			tbName.Text = dr["Name"].ToString();
		}
		dr.Close();
	}

	protected void btnCommit_Click(object sender,EventArgs e)
	{   ///修改组
		Group group = new Group();
		if(group.UpdateGroup(groupID,tbName.Text) > 0)
		{
			Response.Redirect("~/Hailfellow/GroupManage.aspx");
		}
	}
}
