<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyLeaveword.aspx.cs" Inherits="UserInfo_MyLeaveword" StylesheetTheme="ASPNETAjaxWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>我的留言管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server" ></asp:ScriptManager>
    <table class="Table" border="0" cellpadding="5" cellspacing="0">
		<tr>
			<td colspan="2">
				<asp:UpdatePanel runat="server" ID="up">
					<ContentTemplate>
						<asp:GridView ID="gvLeaveword" runat="server" Width="100%" AutoGenerateColumns="False" SkinID="gvSkin" OnRowCommand="gvLeaveword_RowCommand" OnRowDataBound="gvLeaveword_RowDataBound">
							<EmptyDataTemplate>我的留言为空！</EmptyDataTemplate>
							<Columns>
								<asp:TemplateField HeaderText="留言内容">
									<ItemTemplate>
										<a href='ShowLeavewordInfo.aspx?LeavewordID=<%# Eval("ID") %>' target="_blank"><%# Eval("Body").ToString().Length > 80 ? (Eval("Body").ToString().Substring(0,80) + "...") : Eval("Body").ToString()%></a>
									</ItemTemplate>
									<ItemStyle HorizontalAlign="Left" Width="52%" />
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
								<asp:TemplateField HeaderText="留言状态">
									<ItemTemplate>
										<%# Eval("Status").ToString() == "0" ? "未读" : "已读"%>										
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