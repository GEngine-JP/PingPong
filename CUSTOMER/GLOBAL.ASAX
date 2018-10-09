<%@ Application Language="C#" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="ASPNETAJAXWeb.AjaxInstantMessaging" %>

<script runat="server">

	/// <summary>
	/// 保存登录用户的列表
	/// </summary>
	public static List<UserInfo> Users = new List<UserInfo>();
	
    void Application_Start(object sender, EventArgs e)
	{   ///登录用户列表初始化
		Users.Clear();
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  在应用程序关闭时运行的代码

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // 在出现未处理的错误时运行的代码

    }

    void Session_Start(object sender, EventArgs e) 
    {	

    }

    void Session_End(object sender, EventArgs e) 
    {
		if(Session["UserID"] != null)
		{   ///用户离开时，清空用户登录的信息
			string userID = Session["UserID"].ToString();
			foreach(UserInfo ui in Users)
			{   ///根据用户ID找到离开的用户
				if(ui.UserID.ToString() == userID)
				{
					Users.Remove(ui);
					break;
				}
			}
		}
    }
       
</script>
