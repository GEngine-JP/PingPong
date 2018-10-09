using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace ASPNETAJAXWeb.AjaxInstantMessaging
{
	/// <summary>
	/// 保存用户登录信息的类
	/// </summary>
	public class UserInfo
	{
		private int userID;
		private int caboodleID = -1;
		private string username;

		/// <summary>
		/// 群的ID值
		/// </summary>
		public int CaboodleID
		{
			get
			{
				return caboodleID;
			}
			set
			{
				caboodleID = value;
			}
		}

		/// <summary>
		/// 用户ID值
		/// </summary>
		public int UserID
		{
			get
			{
				return userID;
			}
			set
			{
				userID = value;
			}
		}

		/// <summary>
		/// 用户名称
		/// </summary>
		public string Username
		{
			get
			{
				return username;
			}
			set
			{
				username = value;
			}
		}
	}

	public class User
	{
		public User()
		{
			
		}

		public DataSet GetUsers()
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "SELECT * FROM [User]";
			///创建SqlDataAdapter
			SqlDataAdapter da = new SqlDataAdapter(cmdText,con);
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

		public SqlDataReader GetUserLogin(string username,string password)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "SELECT ID FROM [User] WHERE Username=@Username AND Password=@Password";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@Username",SqlDbType.VarChar,50);
			cmd.Parameters.Add("@Password",SqlDbType.VarChar,255);
			cmd.Parameters[0].Value = username;
			cmd.Parameters[1].Value = password;
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

		public DataSet GetFellowByUser(int userID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建被执行的存储过程
			string cmdText = "Pr_GetFellowByUser";
			///创建SqlDataAdapter
			SqlDataAdapter da = new SqlDataAdapter(cmdText,con);
			///设置执行的方式为存储过程
			da.SelectCommand.CommandType = CommandType.StoredProcedure;
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

		public DataSet GetFellowNotInCaboodleByUser(int userID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建被执行的存储过程
			string cmdText = "Pr_GetFellowNotInCaboodleByUser";
			///创建SqlDataAdapter
			SqlDataAdapter da = new SqlDataAdapter(cmdText,con);
			///设置执行的方式为存储过程
			da.SelectCommand.CommandType = CommandType.StoredProcedure;
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

		public SqlDataReader GetSingleUser(int userID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "SELECT * FROM [User] WHERE ID=@ID";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@ID",SqlDbType.Int,4);
			cmd.Parameters[0].Value = userID;
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

		public int AddUser(string username,string aliasname,string password,string email,
			string pictureUrl,string signing)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "INSERT INTO [User](Username,Aliasname,Password,CreateDate,Email,PictureUrl,Signing)VALUES(@Username,@Aliasname,@Password,GETDATE(),@Email,@PictureUrl,@Signing)";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@Username",SqlDbType.VarChar,50);
			cmd.Parameters.Add("@Aliasname",SqlDbType.VarChar,50);
			cmd.Parameters.Add("@Password",SqlDbType.VarChar,255);
			cmd.Parameters.Add("@Email",SqlDbType.VarChar,255);
			cmd.Parameters.Add("@PictureUrl",SqlDbType.VarChar,255);
			cmd.Parameters.Add("@Signing",SqlDbType.VarChar,1000);
			cmd.Parameters[0].Value = username;
			cmd.Parameters[1].Value = aliasname;
			cmd.Parameters[2].Value = password;
			cmd.Parameters[3].Value = email;
			cmd.Parameters[4].Value = pictureUrl;
			cmd.Parameters[5].Value = signing;

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

		public int AddUserLogin(int userID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "INSERT INTO [UserLogin](UserID,LoginDate,LogoffDate)VALUES(@UserID,GETDATE(),GETDATE()) RETURN @@Identity";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@UserID",SqlDbType.Int,4);
			cmd.Parameters.Add("RETURNVALUE",SqlDbType.Int,4);
			cmd.Parameters[0].Value = userID;
			cmd.Parameters[1].Direction = ParameterDirection.ReturnValue;

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
			///返回登录的ID值
			return (int)cmd.Parameters[1].Value;
		}

		public int UpdateUser(int userID,string aliasname,string email,string signing)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "UPDATE [User] SET Aliasname=@Aliasname,Email=@Email,Signing=@Signing WHERE ID=@ID";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@ID",SqlDbType.Int,4);
			cmd.Parameters.Add("@Aliasname",SqlDbType.VarChar,50);
			cmd.Parameters.Add("@Email",SqlDbType.VarChar,255);
			cmd.Parameters.Add("@Signing",SqlDbType.VarChar,1000);
			cmd.Parameters[0].Value = userID;
			cmd.Parameters[1].Value = aliasname;
			cmd.Parameters[2].Value = email;
			cmd.Parameters[3].Value = signing;

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

		public int UpdateUserPassword(int userID,string password)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "UPDATE [User] SET Password=@Password WHERE ID=@ID";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@ID",SqlDbType.Int,4);
			cmd.Parameters.Add("@Password",SqlDbType.VarChar,255);
			cmd.Parameters[0].Value = userID;
			cmd.Parameters[1].Value = password;

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

		public int UpdateUserPicture(int userID,string pictureUrl)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "UPDATE [User] SET PictureUrl=@PictureUrl WHERE ID=@ID";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@ID",SqlDbType.Int,4);
			cmd.Parameters.Add("@PictureUrl",SqlDbType.VarChar,255);
			cmd.Parameters[0].Value = userID;
			cmd.Parameters[1].Value = pictureUrl;

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

		public int UpdateUserLogoff(int loginID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "UPDATE [UserLogin] SET LogoffDate=GETDATE() WHERE ID=@ID";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@ID",SqlDbType.Int,4);
			cmd.Parameters[0].Value = loginID;

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

		public int DeleteUser(int userID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "DELETE [User] WHERE ID = @ID";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@ID",SqlDbType.Int,4);
			cmd.Parameters[0].Value = userID;

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

	public class Role
	{
		public Role()
		{

		}

		public DataSet GetRoles()
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "SELECT * FROM [Role]";
			///创建SqlDataAdapter
			SqlDataAdapter da = new SqlDataAdapter(cmdText,con);
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

		public SqlDataReader GetSingleRole(int roleID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "SELECT * FROM [Role] WHERE ID=@ID";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@ID",SqlDbType.Int,4);
			cmd.Parameters[0].Value = roleID;
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

		public int AddRole(string name,string remark)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "INSERT INTO [Role](Name,Remark)VALUES(@Name,@Remark)";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@Name",SqlDbType.VarChar,50);
			cmd.Parameters.Add("@Remark",SqlDbType.VarChar,1000);
			cmd.Parameters[0].Value = name;
			cmd.Parameters[1].Value = remark;

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

		public int UpdateRole(int roleID,string name,string remark)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "UPDATE [Role] SET Name=@Name,Remark=@Remark WHERE ID=@ID";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@ID",SqlDbType.Int,4);
			cmd.Parameters.Add("@Name",SqlDbType.VarChar,50);
			cmd.Parameters.Add("@Remark",SqlDbType.VarChar,1000);
			cmd.Parameters[0].Value = roleID;
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
		
		public int DeleteRole(int roleID)
		{	///获取连接字符串
			string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
			///创建连接
			SqlConnection con = new SqlConnection(connectionString);
			///创建SQL语句
			string cmdText = "DELETE [Role] WHERE ID = @ID";
			///创建SqlCommand
			SqlCommand cmd = new SqlCommand(cmdText,con);
			///创建参数并赋值
			cmd.Parameters.Add("@ID",SqlDbType.Int,4);
			cmd.Parameters[0].Value = roleID;

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
