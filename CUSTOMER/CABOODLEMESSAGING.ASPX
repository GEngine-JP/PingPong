<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CaboodleMessaging.aspx.cs" Inherits="CaboodleMessaging" StylesheetTheme="ASPNETAjaxWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>群聊页面</title>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="btnCommit" defaultfocus="tbMessage">
    <asp:ScriptManager ID="sm" runat="server" />    
	<asp:UpdatePanel ID="upUser" UpdateMode="Conditional" runat="server">
		<ContentTemplate>
			<table border="0" cellpadding="2" cellspacing="0" class="Table">
				<tr>
					<td colspan="2">
						<asp:Label ID="lbInfoMessage" runat="server" ForeColor="Red"></asp:Label>				
					</td>
				</tr>
				<tr>
					<td valign="top" width="20%">				
						<asp:ListBox ID="lbUser" runat="server" Width="100%" Rows="28"></asp:ListBox>						
					</td>
					<td width="80%" valign="top">
						<asp:TextBox ID="tbChatMessage" runat="server" Width="98%" TextMode="MultiLine" Rows="20"></asp:TextBox>
						<table border="0" cellpadding="2" cellspacing="0" class="Table">
							<tr>
								<td>
									<asp:Panel ID="pInfo" runat="server" Width="98%"></asp:Panel>				
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
					</td>
				</tr>
			</table>
			<asp:Timer ID="tUser" runat="server" Interval="12000" OnTick="tUser_Tick"></asp:Timer>
		</ContentTemplate>
	</asp:UpdatePanel>
    </form>
</body>
</html>
