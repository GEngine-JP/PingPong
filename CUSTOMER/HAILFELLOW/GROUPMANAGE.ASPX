<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GroupManage.aspx.cs" Inherits="Hailfellow_GroupManage" StylesheetTheme="ASPNETAjaxWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>组管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server" ></asp:ScriptManager>
    <table class="Table" border="0" cellpadding="5" cellspacing="0">
		<tr>
			<td colspan="2">
				<asp:UpdatePanel runat="server" ID="up">
					<ContentTemplate>
						<asp:GridView ID="gvGroup" runat="server" Width="100%" AutoGenerateColumns="False" SkinID="gvSkin" OnRowCommand="gvGroup_RowCommand" OnRowDataBound="gvGroup_RowDataBound">
							<Columns>
								<asp:TemplateField HeaderText="组名称">
									<ItemTemplate>
										<%# Eval("Name")+ ((int)Eval("ID") > 3 ? ("(" + Eval("GroupUserCount").ToString() + ")") : string.Empty) %>
									</ItemTemplate>
									<ItemStyle HorizontalAlign="Left" Width="70%" />
									<HeaderStyle HorizontalAlign="Left" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="所属用户">
									<ItemTemplate>
										<%# (int)Eval("UserID") > 0 ? Eval("Username") : "系统" %>										
									</ItemTemplate>
									<ItemStyle HorizontalAlign="Center" Width="18%" />
									<HeaderStyle HorizontalAlign="Center" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="操作">
									<ItemTemplate>
										<asp:ImageButton ID="imgUpdate" runat="server" Visible='<%# (int)Eval("ID") > 3 ? true : false %>' CommandArgument='<%# Eval("ID") %>' ImageUrl="~/App_Themes/ASPNETAjaxWeb/Images/edit.PNG" CommandName="update" />&nbsp;
										<asp:ImageButton ID="imgDelete" runat="server" Visible='<%# ((int)Eval("ID") > 3 && (int)Eval("GroupUserCount") <= 0) ? true : false %>' CommandArgument='<%# Eval("ID") %>' ImageUrl="~/App_Themes/ASPNETAjaxWeb/Images/delete.PNG" CommandName="del" />								
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
				<asp:Button ID="btnAdd" runat="server" Text="添加新组" OnClick="btnAdd_Click" SkinID="btnSkin" />
			</td>
		</tr>
	</table>
    </form>
</body>
</html>