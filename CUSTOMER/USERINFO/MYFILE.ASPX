<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyFile.aspx.cs" Inherits="UserInfo_MyFile" StylesheetTheme="ASPNETAjaxWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>我的文件管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server" ></asp:ScriptManager>
    <table class="Table" border="0" cellpadding="5" cellspacing="0">
		<tr>
			<td colspan="2">
				<asp:UpdatePanel runat="server" ID="up">
					<ContentTemplate>
						<asp:GridView ID="gvFile" runat="server" Width="100%" AutoGenerateColumns="False" SkinID="gvSkin" OnRowCommand="gvFile_RowCommand" OnRowDataBound="gvFile_RowDataBound">
							<EmptyDataTemplate>我的文件为空！</EmptyDataTemplate>
							<Columns>
								<asp:TemplateField HeaderText="文件名称">
									<ItemTemplate>
										<a href='<%# "../" + Eval("Url") %>' target="_blank"><%# Eval("Name") %></a>
									</ItemTemplate>
									<ItemStyle HorizontalAlign="Left" Width="36%" />
									<HeaderStyle HorizontalAlign="Left" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="发送者">
									<ItemTemplate>
										<%# Eval("SenderName")%>										
									</ItemTemplate>
									<ItemStyle HorizontalAlign="Center" Width="12%" />
									<HeaderStyle HorizontalAlign="Center" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="发送时间">
									<ItemTemplate>
										<%# Eval("CreateDate") %>										
									</ItemTemplate>
									<ItemStyle HorizontalAlign="Center" Width="18%" />
									<HeaderStyle HorizontalAlign="Center" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="文件类型">
									<ItemTemplate>
										<%# Eval("Type") %>										
									</ItemTemplate>
									<ItemStyle HorizontalAlign="Center" Width="16%" />
									<HeaderStyle HorizontalAlign="Center" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="文件大小">
									<ItemTemplate>
										<%# Eval("Size") %>										
									</ItemTemplate>
									<ItemStyle HorizontalAlign="Center" Width="12%" />
									<HeaderStyle HorizontalAlign="Center" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="操作">
									<ItemTemplate>
										<asp:ImageButton ID="imgDelete" runat="server" CommandArgument='<%# Eval("ID") %>' ImageUrl="~/App_Themes/ASPNETAjaxWeb/Images/delete.PNG" CommandName="del" />								
									</ItemTemplate>
									<ItemStyle HorizontalAlign="Center" Width="6%" />
									<HeaderStyle HorizontalAlign="Center" />
								</asp:TemplateField>
							</Columns>
						</asp:GridView>
					</ContentTemplate>
				</asp:UpdatePanel>				
			</td>
		</tr>
	</table>
    </form>
</body>
</html>
