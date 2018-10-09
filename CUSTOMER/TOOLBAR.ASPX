<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Toolbar.aspx.cs" Inherits="Toolbar" StylesheetTheme="ASPNETAjaxWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>工具栏</title>
</head>
<body style="margin:0;" bgcolor="#184073" class="Body">
    <form id="form1" runat="server">
     <table class="Table" border="0" cellpadding="2" bgcolor="Black" cellspacing="1">
		<tr bgcolor="white" align="center">
			<td>当前客户：<asp:Label ID="lbUsername" runat="server" Font-Bold="true" ForeColor="red"></asp:Label></td>
			<td><a href='Messaging.aspx?UserID=<%= UserID %>' target="Message">发布交流</a></td>
			<td><a href='SelectCaboodle.aspx' target="Message">团队交互</a></td>
			<td><a href='Leaveword.aspx?UserID=<%= UserID %>' target="Message">客户留言</a></td>
			<td><a href='File.aspx?UserID=<%= UserID %>' target="Message">发送文件</a></td>
			<td><a href='Hailfellow/ShowFellowInfo.aspx?UserID=<%=UserID %>' target="Message">查看信息</a></td>
			<td><a href='Hailfellow/MoveFellow.aspx?UserID=<%= UserID %>&GroupID=<% =GroupID %>' target="Message">移动到...</a></td>
			<td><a href='Caboodle/AddCaboodleUser.aspx?UserID=<%= UserID %>' target="Message">加入团队</a></td>
			<td><a href='Hailfellow/AddFellow.aspx?UserID=<%= UserID %>' target="Message">添加客户</a></td>
			<td><a href='Hailfellow/SearchFellow.aspx?UserID=<%= UserID %>' target="Message">客户检索</a></td>
			<td><a href='Caboodle/AddCaboodle.aspx?UserID=<%= UserID %>' target="Message">创建团队</a></td>
			<td><a href="Manager.aspx" target="Message">系统管理</a></td>
			<td><a href="LogOff.aspx" target="_top">退出登录</a></td>
		</tr>		
    </table>
    </form>
</body>
</html>
