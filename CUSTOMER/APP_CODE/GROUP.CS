using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace ASPNETAJAXWeb.AjaxInstantMessaging
{
	public class Group
	{
		public Group()
		{

		}

		public DataSet GetGroupByUser(int userID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "SELECT G.*,[User].Username,(SELECT COUNT(*) FROM GroupUser WHERE GroupID=G.ID AND GroupID > 3) AS GroupUserCount FROM [Group] AS G INNER JOIN	[User] ON G.UserID=[User].ID WHERE G.UserID=@UserID OR UserID=0";
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

		public SqlDataReader GetSingleGroup(int groupID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "SELECT * FROM [Group] WHERE ID=@ID";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@ID",SqlDbType.Int,4);
			cmd.Parameters[0].Value = groupID;
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

		public int AddGroup(string name,int userID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "INSERT INTO [Group](Name,UserID)VALUES(@Name,@UserID)";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@Name",SqlDbType.VarChar,50);
			cmd.Parameters.Add("@UserID",SqlDbType.Int,4);
			cmd.Parameters[0].Value = name;
			cmd.Parameters[1].Value = userID;

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

		public int UpdateGroup(int groupID,string name)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "UPDATE [Group] SET Name=@Name WHERE ID=@ID";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@ID",SqlDbType.Int,4);
			cmd.Parameters.Add("@Name",SqlDbType.VarChar,50);
			cmd.Parameters[0].Value = groupID;
			cmd.Parameters[1].Value = name;

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

		public int DeleteGroup(int groupID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "DELETE [Group] WHERE ID = @ID";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@ID",SqlDbType.Int,4);
			cmd.Parameters[0].Value = groupID;

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

	public class GroupUser
	{
		public GroupUser()
		{

		}

		public DataSet GetUserbyGroup(int groupID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "SELECT [User].*,[GroupUser].GroupID FROM [GroupUser] INNER JOIN [User] ON [User].ID=[GroupUser].UserID WHERE GroupID=@GroupID";
			///创建SqlDataAdapter
			SqlDataAdapter da = new SqlDataAdapter(cmdText,con);
			///创建参数并赋值
			da.SelectCommand.Parameters.Add("@GroupID",SqlDbType.Int,4);
			da.SelectCommand.Parameters[0].Value = groupID;
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

		public int AddGroupUser(int groupID,int userID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建被执行的存储过程
			string cmdText = "Pr_AddGroupUser";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///设置执行的方式为存储过程
			cmd.CommandType = CommandType.StoredProcedure;
			///创建参数并赋值
			cmd.Parameters.Add("@GroupID",SqlDbType.Int,4);
			cmd.Parameters.Add("@UserID",SqlDbType.Int,4);
			cmd.Parameters[0].Value = groupID;
			cmd.Parameters[1].Value = userID;

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

		public int UpdateGroupUser(int oldGroupID,int newGroupID,int userID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建被执行的存储过程
			string cmdText = "Pr_UpdateGroupUser";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///设置执行的方式为存储过程
			cmd.CommandType = CommandType.StoredProcedure;
			///创建参数并赋值
			cmd.Parameters.Add("@OldGroupID",SqlDbType.Int,4);
			cmd.Parameters.Add("@NewGroupID",SqlDbType.Int,4);
			cmd.Parameters.Add("@UserID",SqlDbType.Int,4);
			cmd.Parameters[0].Value = oldGroupID;
			cmd.Parameters[1].Value = newGroupID;
			cmd.Parameters[2].Value = userID;

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

		public int DeleteGroupUser(int groupID,int userID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "DELETE [GroupUser] WHERE GroupID=@GroupID AND UserID=@UserID";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@GroupID",SqlDbType.Int,4);
			cmd.Parameters.Add("@UserID",SqlDbType.Int,4);
			cmd.Parameters[0].Value = groupID;
			cmd.Parameters[1].Value = userID;

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
