using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace ASPNETAJAXWeb.AjaxInstantMessaging
{
	public class File
	{
		public File()
		{
			///
		}

		public DataSet GetFileByUser(int userID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "SELECT [File].*,S.Username AS SenderName,R.Username AS ReceiverName"
				+ " FROM [File]"
				+ " INNER JOIN [User] AS S ON S.ID=[File].Sender"
				+ " INNER JOIN [User] AS R ON R.ID=[File].Receiver"
				+ " WHERE [File].Receiver=@UserID ORDER BY CreateDate DESC";
			///创建SqlDataAdapter
			SqlDataAdapter da = new SqlDataAdapter(cmdText,con);
			///创建参数并赋值
			da.SelectCommand.Parameters.Add("@UserID",SqlDbType.Int,4);
			da.SelectCommand.Parameters[0].Value = userID;
			///定义DataSet
			DataSet ds = new DataSet();
			try
			{   ///打开连接
				con.Open();
				///填充数据
				da.Fill(ds,"DataTable");
			}
			catch(Exception ex)
			{   ///抛出异常
				throw new Exception(ex.Message,ex);
			}
			finally
			{   ///关闭连接
				con.Close();
			}

			return ds;
		}

		public int AddFile(string name,int sender,int receiver,string url,string type,int size)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "INSERT INTO [File](Name,Sender,Receiver,Url,Type,Size,CreateDate)VALUES(@Name,@Sender,@Receiver,@Url,@Type,@Size,GETDATE())";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@Name",SqlDbType.VarChar,200);
			cmd.Parameters.Add("@Sender",SqlDbType.Int,4);
			cmd.Parameters.Add("@Receiver",SqlDbType.Int,4);
			cmd.Parameters.Add("@Url",SqlDbType.VarChar,255);
			cmd.Parameters.Add("@Type",SqlDbType.VarChar,50);
			cmd.Parameters.Add("@Size",SqlDbType.Int,4);
			cmd.Parameters[0].Value = name;
			cmd.Parameters[1].Value = sender;
			cmd.Parameters[2].Value = receiver;
			cmd.Parameters[3].Value = url;
			cmd.Parameters[4].Value = type;
			cmd.Parameters[5].Value = size;

			int result = -1;
			try
			{   ///打开连接
				con.Open();
				///操作数据
				result = cmd.ExecuteNonQuery();
			}
			catch(Exception ex)
			{   ///抛出异常
				throw new Exception(ex.Message,ex);
			}
			finally
			{   ///关闭连接
				con.Close();
			}

			return result;
		}

		public int DeleteFile(int fileID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "DELETE [File] WHERE ID=@ID";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@ID",SqlDbType.Int,4);
			cmd.Parameters[0].Value = fileID;

			int result = -1;
			try
			{   ///打开连接
				con.Open();
				///操作数据
				result = cmd.ExecuteNonQuery();
			}
			catch(Exception ex)
			{   ///抛出异常
				throw new Exception(ex.Message,ex);
			}
			finally
			{   ///关闭连接
				con.Close();
			}

			return result;
		}
	}
}
