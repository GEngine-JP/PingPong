using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace ASPNETAJAXWeb.AjaxInstantMessaging
{
	public class MessageForSingle
	{
		public MessageForSingle()
		{
			
		}

		public DataSet GetMessageByUser(int userID,int fellowID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "SELECT [MessageForSingle].*,S.Username AS SenderName,R.Username AS ReceiverName"
				+ " FROM [MessageForSingle]"
				+ " INNER JOIN [User] AS S ON S.ID=MessageForSingle.Sender"
				+ " INNER JOIN [User] AS R ON R.ID=MessageForSingle.Receiver"
				+ " WHERE (MessageForSingle.Sender=@UserID AND MessageForSingle.Receiver=@FellowID) OR (MessageForSingle.Sender=@FellowID AND MessageForSingle.Receiver=@UserID) ORDER BY CreateDate DESC";
			///创建SqlDataAdapter
			SqlDataAdapter da = new SqlDataAdapter(cmdText,con);
			///创建参数并赋值
			da.SelectCommand.Parameters.Add("@UserID",SqlDbType.Int,4);
			da.SelectCommand.Parameters.Add("@FellowID",SqlDbType.Int,4);
			da.SelectCommand.Parameters[0].Value = userID;
			da.SelectCommand.Parameters[1].Value = fellowID;
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

		public int AddMessage(string body,int sender,int receiver)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "INSERT INTO MessageForSingle(Body,Sender,Receiver,CreateDate)VALUES(@Body,@Sender,@Receiver,GETDATE())";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@Sender",SqlDbType.Int,4);
			cmd.Parameters.Add("@Receiver",SqlDbType.Int,4);
			cmd.Parameters.Add("@Body",SqlDbType.VarChar,1000);
			cmd.Parameters[0].Value = sender;
			cmd.Parameters[1].Value = receiver;
			cmd.Parameters[2].Value = body;

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

		public int DeleteMessage(int messageID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "DELETE [MessageForSingle] WHERE ID=@ID";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@ID",SqlDbType.Int,4);
			cmd.Parameters[0].Value = messageID;

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

	public class MessageForCaboodle
	{
		public MessageForCaboodle()
		{

		}

		public DataSet GetMessageByCaboodle(int caboodleID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "SELECT [MessageForCaboodle].*,S.Username AS SenderName,C.Name AS CaboodleName"
				+ " FROM [MessageForCaboodle]"
				+ " INNER JOIN [User] AS S ON S.ID=MessageForCaboodle.Sender"
				+ " INNER JOIN [Caboodle] AS C ON C.ID=MessageForCaboodle.CaboodleID"
				+ " WHERE MessageForCaboodle.CaboodleID=@CaboodleID ORDER BY CreateDate DESC";
			///创建SqlDataAdapter
			SqlDataAdapter da = new SqlDataAdapter(cmdText,con);
			///创建参数并赋值
			da.SelectCommand.Parameters.Add("@CaboodleID",SqlDbType.Int,4);
			da.SelectCommand.Parameters[0].Value = caboodleID;
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

		public int AddMessage(string body,int sender,int caboodleID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "INSERT INTO MessageForCaboodle(Body,Sender,CaboodleID,CreateDate)VALUES(@Body,@Sender,@CaboodleID,GETDATE())";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@Sender",SqlDbType.Int,4);
			cmd.Parameters.Add("@CaboodleID",SqlDbType.Int,4);
			cmd.Parameters.Add("@Body",SqlDbType.VarChar,1000);
			cmd.Parameters[0].Value = sender;
			cmd.Parameters[1].Value = caboodleID;
			cmd.Parameters[2].Value = body;

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

		public int DeleteMessage(int messageID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "DELETE [MessageForCaboodle] WHERE ID=@ID";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@ID",SqlDbType.Int,4);
			cmd.Parameters[0].Value = messageID;

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
