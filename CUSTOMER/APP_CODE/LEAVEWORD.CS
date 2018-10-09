using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace ASPNETAJAXWeb.AjaxInstantMessaging
{
	public class Leaveword
	{
		public Leaveword()
		{

		}
		public DataSet GetLeavewordByUser(int userID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "SELECT [Leaveword].*,S.Username AS SenderName,R.Username AS ReceiverName"
				+ " FROM [Leaveword]"
				+ " INNER JOIN [User] AS S ON S.ID=[Leaveword].Sender"
				+ " INNER JOIN [User] AS R ON R.ID=[Leaveword].Receiver"
				+ " WHERE [Leaveword].Receiver=@UserID ORDER BY CreateDate DESC";
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

		public SqlDataReader GetSingleLeaveword(int leavewordID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "SELECT Leaveword.*,[User].Username AS SenderName FROM Leaveword INNER JOIN [User] ON Leaveword.Sender=[User].ID WHERE Leaveword.ID=@ID";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@ID",SqlDbType.Int,4);
			cmd.Parameters[0].Value = leavewordID;
			///定义SqlDataReader
			SqlDataReader dr;
			try
			{   ///打开连接
				con.Open();
				///读取数据
				dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			}
			catch(Exception ex)
			{   ///抛出异常
				throw new Exception(ex.Message,ex);
			}

			return dr;
		}

		public int AddLeaveword(string body,int sender,int receiver)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "INSERT INTO [Leaveword](Body,Sender,Receiver,CreateDate,Status)VALUES(@Body,@Sender,@Receiver,GETDATE(),0)";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@Body",SqlDbType.VarChar,1000);
			cmd.Parameters.Add("@Sender",SqlDbType.Int,4);
			cmd.Parameters.Add("@Receiver",SqlDbType.Int,4);
			cmd.Parameters[0].Value = body;
			cmd.Parameters[1].Value = sender;
			cmd.Parameters[2].Value = receiver;

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

		public int UpdateLeavewordStatus(int leavewordID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "UPDATE Leaveword SET Status=1 WHERE ID=@ID";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@ID",SqlDbType.Int,4);
			cmd.Parameters[0].Value = leavewordID;

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

		public int DeleteLeaveword(int leavewordID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "DELETE [Leaveword] WHERE ID=@ID";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@ID",SqlDbType.Int,4);
			cmd.Parameters[0].Value = leavewordID;

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
