using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace ASPNETAJAXWeb.AjaxInstantMessaging
{
	public class AjaxInstantMessagingSystem
	{
		public static string[] ALLOWPHOTOFILELIST = new string[]{
			".bmp",
			".gif",
			".jpg",
			".mht",
			".png"
		};

		public AjaxInstantMessagingSystem()
		{
			
		}

		/// <summary>
		/// 在ASP.NET环境中弹出一个对话框
		/// </summary>
		/// <param name="response"></param>
		/// <param name="message"></param>
		public static void ShowDialog(HttpResponse response,string message)
		{
			response.Write("<script>alert(\"" + message + "\");</script>");
		}

		/// <summary>
		/// 在ajax环境中弹出一个对话框
		/// </summary>
		/// <param name="button"></param>
		/// <param name="message"></param>
		public static void ShowAjaxDialog(Button button,string message)
		{
			ScriptManager.RegisterClientScriptBlock(button,typeof(Button),button.ClientID,"alert(\"" + message + "\");",true);
		}

		/// <summary>
		///  根据Value属性把列表控件的选择项设置为指定项
		/// </summary>
		/// <param name="list"></param>
		/// <param name="value"></param>
		public static void ListSelectedItemByValue(ListControl list,string value)
		{
			if(list == null) return;
			///选择项为空
			if(list.Items.Count <= 0)
			{
				list.SelectedIndex = -1;
				return;
			}
			///逐项进行比较，设置选择项
			for(int i = 0; i < list.Items.Count; i++)
			{
				if(list.Items[i].Value == value)
				{
					list.SelectedIndex = i;
					return;
				}
			}
			///没有符合条件的选择项
			list.SelectedIndex = -1;
		}

		/// <summary>
		/// 根据Text属性把列表控件的选择项设置为指定项
		/// </summary>
		/// <param name="list"></param>
		/// <param name="text"></param>
		public static void ListSelectedItemByText(ListControl list,string text)
		{
			if(list == null) return;
			///选择项为空
			if(list.Items.Count <= 0)
			{
				list.SelectedIndex = -1;
				return;
			}
			///逐项进行比较，设置选择项
			for(int i = 0; i < list.Items.Count; i++)
			{
				if(list.Items[i].Text == text)
				{
					list.SelectedIndex = i;
					return;
				}
			}
			///没有符合条件的选择项
			list.SelectedIndex = -1;
		}

		/// <summary>
		/// 判断是否已经存在选择项
		/// </summary>
		/// <param name="item"></param>
		/// <param name="listbox"></param>
		/// <returns></returns>
		public static bool IsExistItem(ListItem item,ListBox listbox)
		{   ///如果列表为空，则不存在相同的选择项
			if(listbox.Items.Count <= 0) return false;
			///逐个比较是否存在相同的选择项
			foreach(ListItem i in listbox.Items)
			{
				if(item.Text == i.Text)
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// 根据时间创建字符串
		/// </summary>
		/// <returns></returns>
		public static string CreateDateTimeString()
		{
			DateTime now = DateTime.Now;
			string dtString = now.Year.ToString()
				+ now.Month.ToString().PadLeft(2,'0')
				+ now.Day.ToString().PadLeft(2,'0')
				+ now.Hour.ToString().PadLeft(2,'0')
				+ now.Minute.ToString().PadLeft(2,'0')
				+ now.Second.ToString().PadLeft(2,'0')
				+ now.Millisecond.ToString().PadLeft(3,'0');
			return (dtString);
		}

	}
}
