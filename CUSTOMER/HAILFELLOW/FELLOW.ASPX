<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Fellow.aspx.cs" Inherits="Hailfellow_Fellow" StylesheetTheme="ASPNETAjaxWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>查看我的客户</title>
</head>
<body style="margin:0" bgcolor="#184073" class="Body">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server" ></asp:ScriptManager>
    <table class="Table" border="0" cellpadding="5" cellspacing="0">
		<tr>
			<td colspan="2">
				<asp:UpdatePanel runat="server" ID="up">
					<ContentTemplate>
						<asp:GridView ID="gvGroup" runat="server" Width="100%" AutoGenerateColumns="False" SkinID="gvSkin" OnRowDataBound="gvGroup_RowDataBound" DataKeyNames="ID">
							<Columns>
								<asp:TemplateField HeaderText="系统客户组">
									<ItemTemplate>
										<asp:Panel ID="pName" Height="25" runat="server" HorizontalAlign="left" CssClass="ExpandCollapsePanelCss" Font-Bold="True" ForeColor="Gray" Font-Names="Tahoma" BackImageUrl="~/App_Themes/ASPNETAjaxWeb/Images/manageshow.gif"><%# Eval("Name") %></asp:Panel>
										<asp:Panel ID="pContent" runat="server">
											<asp:DataList ID="dlUser" runat="server" DataKeyField="ID" RepeatColumns="1" RepeatDirection="Vertical">
												<ItemTemplate>
													<a href='../Desktop.aspx?UserID=<%# Eval("ID") %>&GroupID=<%# Eval("GroupID") %>' target="Desktop"><%# Eval("Username") %></a>
												</ItemTemplate>
												<ItemStyle Height="20" Width="100%" Font-Underline="true"/>
											</asp:DataList>
										</asp:Panel>										
										<ajaxToolkit:CollapsiblePanelExtender ID="cpeRss" runat="server" Collapsed="true" ExpandControlID="pName" CollapseControlID="pName" AutoCollapse="false" AutoExpand="false" ExpandDirection="Vertical" ExpandedSize="350" ScrollContents="true" TargetControlID="pContent" TextLabelID="lbGroupName"></ajaxToolkit:CollapsiblePanelExtender>
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
