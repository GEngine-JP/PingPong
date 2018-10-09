using System;
using System.Text;
using System.IO;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;

namespace ASPNETAJAXWeb.AjaxInstantMessaging
{
	public class OutputData
	{
		public OutputData() { }

		public static void SaveAsExcel(Page page,DataSet ds)
		{
			if(page == null || ds == null || ds.Tables.Count <= 0) return;

			StringWriter sw = new StringWriter();

			///输出表格的标题
			StringBuilder column = new StringBuilder();
			foreach(DataColumn c in ds.Tables[0].Columns)
			{
				column.Append(c.ColumnName.ToLower());
				if(c.Ordinal < ds.Tables[0].Columns.Count - 1)
				{
					column.Append(",");
				}
			}
			sw.WriteLine(column.ToString());

			///输出每一行数据
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				column = new StringBuilder();
				foreach(DataColumn c in ds.Tables[0].Columns)
				{
					column.Append(r[c.ColumnName].ToString());
					if(c.Ordinal < ds.Tables[0].Columns.Count - 1)
					{
						column.Append(",");
					}
				}
				sw.WriteLine(column.ToString());
			}
			///设置输出格式
			page.Response.AddHeader("Content-Disposition","attachment;filename=data.csv");
			///保存数据的格式为Excel
			page.Response.ContentType = "application/ms-excel";
			///设置数据编码
			page.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
			///输出数据
			page.Response.Write(sw);
			///关闭流，并停止网页
			sw.Close();
			page.Response.End();
		}

		public static void SaveAsTxt(Page page,DataSet ds)
		{
			if(page == null || ds == null || ds.Tables.Count <= 0) return;

			StringWriter sw = new StringWriter();

			///输出表格的标题
			StringBuilder column = new StringBuilder();
			foreach(DataColumn c in ds.Tables[0].Columns)
			{
				column.Append(c.ColumnName.ToLower());
				if(c.Ordinal < ds.Tables[0].Columns.Count - 1)
				{
					column.Append("\t");
				}
			}
			column.Append("\n");
			sw.WriteLine(column);

			///输出每一行数据
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				column = new StringBuilder();
				foreach(DataColumn c in ds.Tables[0].Columns)
				{
					column.Append(r[c.ColumnName].ToString());
					if(c.Ordinal < ds.Tables[0].Columns.Count - 1)
					{
						column.Append("\t");
					}
				}
				sw.WriteLine(column.ToString());
			}
			///设置输出格式
			page.Response.AddHeader("Content-Disposition","attachment;filename=data.txt");
			///保存数据的格式为Excel
			page.Response.ContentType = "text/plain";
			///设置数据编码
			page.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
			///输出数据
			page.Response.Write(sw);
			///关闭流，并停止网页
			sw.Close();
			page.Response.End();
		}
	}
}
