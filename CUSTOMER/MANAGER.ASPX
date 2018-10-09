<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manager.aspx.cs" Inherits="Manager" StylesheetTheme="ASPNETAjaxWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>用户信息管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <table class="Table" border="0" cellpadding="2" bgcolor="Black" cellspacing="1">
		<tr bgcolor="white" align="center">
			<td><a href='UserInfo/MyFile.aspx' target="Message">我的文件</a></td>
		</tr>
		<tr bgcolor="white" align="center">
			<td><a href='UserInfo/MyLeaveword.aspx' target="Message">我的留言</a></td>
		</tr>
		<tr bgcolor="white" align="center">
			<td><a href='UserInfo/MyMessage.aspx' target="Message">我的谈话记录</a></td>
		</tr>
    </table>
    </form>
</body>
</html>
