using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace ASPNETAJAXWeb.AjaxInstantMessaging
{
	public class Caboodle
	{
		public Caboodle()
		{

		}

		public DataSet GetSelfCaboodleByUser(int userID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "SELECT Caboodle.*,[User].Username,(SELECT COUNT(*) FROM CaboodleUser WHERE CaboodleID=Caboodle.ID) AS CaboodleUserCount FROM Caboodle INNER JOIN[User] ON Caboodle.UserID=[User].ID WHERE Caboodle.UserID=@UserID";
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

		public DataSet GetCaboodleByUser(int userID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "SELECT DISTINCT Caboodle.* FROM Caboodle INNER JOIN CaboodleUser ON Caboodle.ID=CaboodleUser.CaboodleID WHERE CaboodleUser.UserID=@UserID";
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

		public SqlDataReader GetSingleCaboodle(int caboodleID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "SELECT * FROM [Caboodle] WHERE ID=@ID";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@ID",SqlDbType.Int,4);
			cmd.Parameters[0].Value = caboodleID;
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

		public int AddCaboodle(string name,int userID,string remark)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "INSERT INTO [Caboodle](Name,UserID,Remark)VALUES(@Name,@UserID,@Remark)";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@Name",SqlDbType.VarChar,50);
			cmd.Parameters.Add("@UserID",SqlDbType.Int,4);			
			cmd.Parameters.Add("@Remark",SqlDbType.VarChar,1000);
			cmd.Parameters[0].Value = name;
			cmd.Parameters[1].Value = userID;
			cmd.Parameters[2].Value = remark;

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

		public int UpdateCaboodle(int caboodleID,string name,string remark)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "UPDATE [Caboodle] SET Name=@Name,Remark=@Remark WHERE ID=@ID";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@ID",SqlDbType.Int,4);
			cmd.Parameters.Add("@Name",SqlDbType.VarChar,50);
			cmd.Parameters.Add("@Remark",SqlDbType.VarChar,1000);
			cmd.Parameters[0].Value = caboodleID;
			cmd.Parameters[1].Value = name;
			cmd.Parameters[2].Value = remark;

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

		public int DeleteCaboodle(int caboodleID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "DELETE [Caboodle] WHERE ID = @ID";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@ID",SqlDbType.Int,4);
			cmd.Parameters[0].Value = caboodleID;

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

	public class CaboodleUser
	{
		public CaboodleUser()
		{

		}

		public DataSet GetUserbyCaboodle(int caboodleID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "SELECT [User].*,[CaboodleUser].CaboodleID FROM [CaboodleUser] INNER JOIN [User] ON [User].ID=[CaboodleUser].UserID WHERE CaboodleID=@CaboodleID";
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

		public int AddCaboodleUser(int caboodleID,int userID,int roleID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建被执行的存储过程
			string cmdText = "Pr_AddCaboodleUser";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///设置执行的方式为存储过程
			cmd.CommandType = CommandType.StoredProcedure;
			///创建参数并赋值
			cmd.Parameters.Add("@CaboodleID",SqlDbType.Int,4);
			cmd.Parameters.Add("@UserID",SqlDbType.Int,4);
			cmd.Parameters.Add("@RoleID",SqlDbType.Int,4);
			cmd.Parameters[0].Value = caboodleID;
			cmd.Parameters[1].Value = userID;
			cmd.Parameters[2].Value = roleID;

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

		public int DeleteCaboodleUser(int caboodleID,int userID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "DELETE [CaboodleUser] WHERE CaboodleID=@CaboodleID AND UserID=@UserID";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@CaboodleID",SqlDbType.Int,4);
			cmd.Parameters.Add("@UserID",SqlDbType.Int,4);
			cmd.Parameters[0].Value = caboodleID;
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

