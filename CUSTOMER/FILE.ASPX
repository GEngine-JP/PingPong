<%@ Page Language="C#" AutoEventWireup="true" CodeFile="File.aspx.cs" Inherits="FilePage" StylesheetTheme="ASPNETAjaxWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>发送文件</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
    <table class="Table" border="0" cellpadding="2" bgcolor="Black" cellspacing="1">
		<tr bgcolor="white">
			<td colspan="2"><hr /><a name="message"></a></td>
		</tr>
		<tr bgcolor="white">
			<td>发送到：</td>
			<td width="90%"><asp:Label ID="lbUsername" runat="server" Font-Bold="true" ForeColor="red"></asp:Label>客户。
			</td>
		</tr>
		<tr bgcolor="white">
			<td>选择文件：</td>
			<td width="90%">
				<asp:FileUpload ID="fuFile" runat="server" CssClass="Button" Width="400px" />
				<asp:Label ID="lbMessage" runat="server" CssClass="Text" ForeColor="Red"></asp:Label>
			</td>
		</tr>		
		<tr bgcolor="white">
			<td>&nbsp;</td>
			<td width="90%">
				<asp:Button ID="btnCommit" runat="server" Text="发送" SkinID="btnSkin" Width="100px" OnClick="btnCommit_Click" />&nbsp;
			</td>			
		</tr>
    </table>   
    </form>
</body>
</html>
