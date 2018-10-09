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

public partial class Desktop : System.Web.UI.Page
{
	protected int UserID = -1;
	protected int GroupID = -1;

	protected void Page_Load(object sender,EventArgs e)
	{
		if(Request.Params["UserID"] != null)
		{   ///获取用户的ID
			UserID = Int32.Parse(Request.Params["UserID"].ToString());
		}
		if(Request.Params["GroupID"] != null)
		{   ///获取组的ID
			GroupID = Int32.Parse(Request.Params["GroupID"].ToString());
		}
	}
}
