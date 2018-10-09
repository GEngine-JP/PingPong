<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Messaging.aspx.cs" Inherits="Messaging" StylesheetTheme="ASPNETAjaxWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>聊天页面</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server" />    
	<asp:UpdatePanel ID="up" UpdateMode="Conditional" runat="server">
		<ContentTemplate>
			<table border="0" cellpadding="2" cellspacing="0" class="Table">
				<tr>
					<td>
						<asp:Label ID="lbUsername" runat="server" ForeColor="Red"></asp:Label>			
					</td>
				</tr>
				<tr>					
					<td valign="top">
						<asp:TextBox ID="tbChatMessage" runat="server" Width="98%" TextMode="MultiLine" Rows="20"></asp:TextBox>
					</td>
				<tr>
					<td>
						<asp:Panel ID="pInfo" runat="server" Width="98%">消息输入框：</asp:Panel>				
					</td>
				</tr>
				<tr>
					<td>
						<asp:TextBox ID="tbMessage" runat="server" TextMode="MultiLine" Width="98%" Rows="5"></asp:TextBox>				
					</td>
				</tr>
				<tr>
					<td>
						<asp:Button ID="btnCommit" runat="server" Text="发送" SkinID="btnSkin" Width="200px" OnClick="btnCommit_Click" />				
					</td>							
				</tr>
			</table>
			<asp:Timer ID="tUser" runat="server" Interval="12000" OnTick="tUser_Tick"></asp:Timer>
		</ContentTemplate>
	</asp:UpdatePanel>
    </form>
</body>
</html>
