<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CaboodleUserManage.aspx.cs" Inherits="Caboodle_CaboodleUserManage" StylesheetTheme="ASPNETAjaxWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>群用户管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server" ></asp:ScriptManager>
    <table class="Table" border="0" cellpadding="5" cellspacing="0">
		<tr>
			<td colspan="2">
				<asp:UpdatePanel runat="server" ID="up">
					<ContentTemplate>
						<asp:GridView ID="gvUser" runat="server" Width="100%" AutoGenerateColumns="False" SkinID="gvSkin" OnRowCommand="gvUser_RowCommand" OnRowDataBound="gvUser_RowDataBound">
							<Columns>
								<asp:TemplateField HeaderText="用户名称">
									<ItemTemplate>
										<a href='../Hailfellow/ShowFellowInfo.aspx?UserID=<%# Eval("ID") %>'><%# Eval("Username") %></a>
									</ItemTemplate>
									<ItemStyle HorizontalAlign="Left" Width="20%" />
									<HeaderStyle HorizontalAlign="Left" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="用户别名">
									<ItemTemplate>
										<%# Eval("Aliasname") %>										
									</ItemTemplate>
									<ItemStyle HorizontalAlign="Center" Width="20%" />
									<HeaderStyle HorizontalAlign="Center" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="唯一标识">
									<ItemTemplate>
										<%# Eval("UserIdentity") %>										
									</ItemTemplate>
									<ItemStyle HorizontalAlign="Center" Width="20%" />
									<HeaderStyle HorizontalAlign="Center" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="电子邮件">
									<ItemTemplate>
										<%# Eval("Email") %>										
									</ItemTemplate>
									<ItemStyle HorizontalAlign="Center" Width="28%" />
									<HeaderStyle HorizontalAlign="Center" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="操作">
									<ItemTemplate>
										<asp:ImageButton ID="imgDelete" runat="server" CommandArgument='<%# Eval("ID") %>' ImageUrl="~/App_Themes/ASPNETAjaxWeb/Images/delete.PNG" CommandName="del" />								
									</ItemTemplate>
									<ItemStyle HorizontalAlign="Center" Width="12%" />
									<HeaderStyle HorizontalAlign="Center" />
								</asp:TemplateField>
							</Columns>
						</asp:GridView>
					</ContentTemplate>
				</asp:UpdatePanel>				
			</td>
		</tr>
		<tr>
			<td>
				<br />
				<asp:Button ID="btnAdd" runat="server" Text="添加群的新用户" OnClick="btnAdd_Click" SkinID="btnSkin" />
			</td>
		</tr>
	</table>
    </form>
</body>
</html>
