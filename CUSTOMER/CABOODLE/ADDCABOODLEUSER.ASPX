<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCaboodleUser.aspx.cs" Inherits="Caboodle_AddCaboodleUser" StylesheetTheme="ASPNETAjaxWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>添加群团队</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="up" runat="server">
		<ContentTemplate>			
			<table class="Table" border="0" cellpadding="2" bgcolor="Black" cellspacing="1">
				<tr bgcolor="white">
					<td colspan="2"><hr /><a name="message"></a></td>
				</tr>
				<tr bgcolor="white">
					<td>团队名称：</td>
					<td width="90%"><asp:Label ID="lbGroupName" runat="server" Font-Bold="true" ForeColor="red"></asp:Label>
					</td>
				</tr>
				<tr bgcolor="white">
					<td>搜索结果：&nbsp;</td>
					<td width="90%">
						<asp:GridView ID="gvUser" runat="server" EmptyDataText="很遗憾，您的好友不存在。" Width="100%" DataKeyNames="ID" AutoGenerateColumns="False" SkinID="gvSkin" OnRowCommand="gvUser_RowCommand" AllowPaging="True" OnPageIndexChanging="gvUser_PageIndexChanging">
							<EmptyDataTemplate>
								很遗憾，您的客户不存在。
							</EmptyDataTemplate>
							<Columns>						
								<asp:TemplateField HeaderText="好友名称">
									<ItemTemplate>
										<a href='ShowFellowInfo.aspx?UserID=<%# Eval("ID") %>' target="_blank"><%# Eval("Username") %>(<%# Eval("UserIdentity")%>)</a>
									</ItemTemplate>
									<HeaderStyle HorizontalAlign="Left" />
									<ItemStyle HorizontalAlign="Left" Width="30%" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="在线/离线">
									<ItemTemplate>
										<%# Eval("Email") %>
									</ItemTemplate>
									<HeaderStyle HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Center" Width="20%" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="个性签名">
									<ItemTemplate>
										<%# Eval("Signing")%>
									</ItemTemplate>
									<HeaderStyle HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Center" Width="40%" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="加为团队">
									<ItemTemplate>
										<asp:Button ID="btnAdd" runat="server" Text="加入该团队" CommandName="add" CommandArgument='<%# Eval("ID") %>' />
									</ItemTemplate>
									<HeaderStyle HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Center" Width="10%" />
								</asp:TemplateField>
							</Columns>
							<PagerSettings Mode="NumericFirstLast" NextPageImageUrl="~/App_Themes/ASPNETAjaxWeb/Images/bnext.gif"
								Position="TopAndBottom" />
						</asp:GridView>
					</td>
				</tr>
			</table> 
		</ContentTemplate>
	</asp:UpdatePanel>
    </form>
</body>
</html>
