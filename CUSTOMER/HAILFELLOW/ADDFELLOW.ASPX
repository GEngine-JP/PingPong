<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddFellow.aspx.cs" Inherits="Hailfellow_AddFellow" StylesheetTheme="ASPNETAjaxWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>添加团队</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
    <table class="Table" border="0" cellpadding="2" bgcolor="Black" cellspacing="1">
		<tr bgcolor="white">
			<td colspan="2"><hr /><a name="message"></a></td>
		</tr>
		<tr bgcolor="white">
			<td>客户名称：</td>
			<td width="90%"><asp:Label ID="lbUsername" runat="server" Font-Bold="true" ForeColor="red"></asp:Label>
			</td>
		</tr>
		<tr bgcolor="white">
			<td>选择组</td>
			<td width="90%"><asp:DropDownList ID="ddlGroup" runat="server" SkinID="ddlSkin" Width="200px"></asp:DropDownList>
			</td>
		</tr>	
		<tr bgcolor="white">
			<td>&nbsp;</td>
			<td width="90%">
				<asp:UpdatePanel ID="upbutton" runat="server">
					<ContentTemplate>
						<asp:Button ID="btnCommit" runat="server" Text="提交" SkinID="btnSkin" Width="100px" OnClick="btnCommit_Click" />
					</ContentTemplate>					
				</asp:UpdatePanel>
			</td>			
		</tr>
    </table>   
    </form>
</body>
</html>
