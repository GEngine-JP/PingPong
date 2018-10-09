<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CaboodleManage.aspx.cs" Inherits="Caboodle_CaboodleManage" StylesheetTheme="ASPNETAjaxWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>群管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server" ></asp:ScriptManager>
    <table class="Table" border="0" cellpadding="5" cellspacing="0">
		<tr>
			<td colspan="2">
				<asp:UpdatePanel runat="server" ID="up">
					<ContentTemplate>
						<asp:GridView ID="gvCaboodle" runat="server" Width="100%" AutoGenerateColumns="False" SkinID="gvSkin" OnRowCommand="gvCaboodle_RowCommand" OnRowDataBound="gvCaboodle_RowDataBound">
							<Columns>
								<asp:TemplateField HeaderText="群名称">
									<ItemTemplate>
										<a href='CaboodleUserManage.aspx?CaboodleID=<%# Eval("ID") %>'><%# Eval("Name")+ "(" + Eval("CaboodleUserCount").ToString() + ")" %></a>
									</ItemTemplate>
									<ItemStyle HorizontalAlign="Left" Width="20%" />
									<HeaderStyle HorizontalAlign="Left" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="所属用户">
									<ItemTemplate>
										<%# Eval("Username") %>										
									</ItemTemplate>
									<ItemStyle HorizontalAlign="Center" Width="18%" />
									<HeaderStyle HorizontalAlign="Center" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="群简介">
									<ItemTemplate>
										<%# Eval("Remark") %>										
									</ItemTemplate>
									<ItemStyle HorizontalAlign="Center" Width="50%" />
									<HeaderStyle HorizontalAlign="Center" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="操作">
									<ItemTemplate>
										<asp:ImageButton ID="imgUpdate" runat="server" CommandArgument='<%# Eval("ID") %>' ImageUrl="~/App_Themes/ASPNETAjaxWeb/Images/edit.PNG" CommandName="update" />&nbsp;
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
				<asp:Button ID="btnAdd" runat="server" Text="添加新团队" OnClick="btnAdd_Click" SkinID="btnSkin" />
			</td>
		</tr>
	</table>
    </form>
</body>
</html>
