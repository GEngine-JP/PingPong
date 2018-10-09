<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FellowManage.aspx.cs" Inherits="Hailfellow_FellowManage" StylesheetTheme="ASPNETAjaxWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>管理我的团队</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server" ></asp:ScriptManager>
    <table class="Table" border="0" cellpadding="5" cellspacing="0">
		<tr>
			<td colspan="2">
				<asp:UpdatePanel runat="server" ID="up">
					<ContentTemplate>
						<asp:GridView ID="gvGroup" runat="server" Width="100%" AutoGenerateColumns="False" SkinID="gvSkin" OnRowDataBound="gvGroup_RowDataBound" DataKeyNames="ID">
							<Columns>
								<asp:TemplateField HeaderText="即时通讯团队">
									<ItemTemplate>
										<asp:Panel ID="pName" Height="25" BackColor="#add8e6" runat="server" HorizontalAlign="left" CssClass="ExpandCollapsePanelCss" Font-Bold="True" ForeColor="Gray" Font-Names="Tahoma"><%# Eval("Name") %></asp:Panel>
										<asp:GridView ID="gvUser" BorderWidth="0" runat="server" ShowHeader="false" Width="100%" AutoGenerateColumns="False" SkinID="gvSkin" OnRowDataBound="gvUser_RowDataBound" OnRowCommand="gvUser_RowCommand" DataKeyNames="ID">
											<Columns>
												<asp:TemplateField>
													<ItemTemplate>
														<a href='ShowFellowInfo.aspx?UserID=<%# Eval("ID") %>' target="_blank"><%# Eval("Username") %></a>
													</ItemTemplate>
													<ItemStyle HorizontalAlign="left" Width="90%" />
													<HeaderStyle HorizontalAlign="left" />
												</asp:TemplateField>
												<asp:TemplateField HeaderText="操作">
												<ItemTemplate>
													<asp:ImageButton ID="imgDelete" runat="server" CommandArgument='<%# Eval("ID") %>' ImageUrl="~/App_Themes/ASPNETAjaxWeb/Images/delete.PNG" CommandName="del" />								
												</ItemTemplate>
												<ItemStyle HorizontalAlign="Center" Width="10%" />
												<HeaderStyle HorizontalAlign="Center" />
											</asp:TemplateField>
											</Columns>
										</asp:GridView>
									</ItemTemplate>
									<ItemStyle HorizontalAlign="Left"/>
									<HeaderStyle HorizontalAlign="Left" />
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
