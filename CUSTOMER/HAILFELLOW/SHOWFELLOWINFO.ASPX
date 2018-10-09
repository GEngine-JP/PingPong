<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowFellowInfo.aspx.cs" Inherits="Hailfellow_ShowFellowInfo" StylesheetTheme="ASPNETAjaxWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>查看用户信息</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
    <table class="Table" border="0" cellpadding="2" bgcolor="Black" cellspacing="1">
		<tr bgcolor="white">
			<td colspan="2"><hr /></td>
		</tr>
		<tr bgcolor="white">
			<td>用户名称：</td>
			<td width="90%"><asp:Label ID="lbUsername" runat="server" Font-Bold="true" ForeColor="red"></asp:Label>
			</td>
		</tr>
		<tr bgcolor="white">
			<td>用户别名：</td>
			<td width="90%"><asp:Label ID="lbAliasname" runat="server" Font-Bold="true" ForeColor="red"></asp:Label>
			</td>
		</tr>
		<tr bgcolor="white">
			<td>惟一标识：</td>
			<td width="90%"><asp:Label ID="lbUserIdentity" runat="server" Font-Bold="true" ForeColor="red"></asp:Label>
			</td>
		</tr>
		<tr bgcolor="white">
			<td>电子邮件：</td>
			<td width="90%"><asp:Label ID="lbEmail" runat="server" Font-Bold="true" ForeColor="red"></asp:Label>
			</td>
		</tr>		
		<tr bgcolor="white">
			<td>&nbsp;</td>
			<td width="90%">
				<asp:Button ID="btnCommit" runat="server" Text="关闭" SkinID="btnSkin" Width="100px" OnClick="btnCommit_Click" />&nbsp;
			</td>			
		</tr>
    </table>   
    </form>
</body>
</html>

