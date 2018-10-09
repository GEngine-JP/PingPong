<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchFellow.aspx.cs" Inherits="Hailfellow_SearchFellow" StylesheetTheme="ASPNETAjaxWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>搜索团队</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
    <table class="Table" border="0" cellpadding="2" bgcolor="Black" cellspacing="1">
		<tr bgcolor="white">
			<td colspan="2"><hr /><a name="message"></a></td>
		</tr>
		<tr bgcolor="white">
			<td>关键字：</td>
			<td width="90%"><asp:TextBox ID="tbKey" runat="server" SkinID="tbSkin" Width="60%" MaxLength="100"></asp:TextBox>
				<asp:RequiredFieldValidator ID="rfKeyBlank" runat="server" ControlToValidate="tbKey" Display="none" ErrorMessage="关键字不能为空！"></asp:RequiredFieldValidator>
				<asp:RequiredFieldValidator ID="rfKeyValue" runat="server" ControlToValidate="tbKey" Display="none" InitialValue="请输入关键字" ErrorMessage="关键字不能为空！"></asp:RequiredFieldValidator>
				<asp:RegularExpressionValidator ID="revKey" runat="server" ControlToValidate="tbKey" Display="none" ErrorMessage="关键字的长度最大为50，请重新输入。" ValidationExpression=".{1,50}"></asp:RegularExpressionValidator>
				<ajaxToolkit:TextBoxWatermarkExtender ID="wmeKey" runat="server" TargetControlID="tbKey" WatermarkText="请输入关键字" WatermarkCssClass="Watermark"></ajaxToolkit:TextBoxWatermarkExtender>
				<ajaxToolkit:ValidatorCalloutExtender ID="vceKeyBlank" runat="server" TargetControlID="rfKeyBlank" HighlightCssClass="Validator"></ajaxToolkit:ValidatorCalloutExtender>
				<ajaxToolkit:ValidatorCalloutExtender ID="vceKeyValue" runat="server" TargetControlID="rfKeyValue" HighlightCssClass="Validator"></ajaxToolkit:ValidatorCalloutExtender>
				<ajaxToolkit:ValidatorCalloutExtender ID="vceKeyRegex" runat="server" TargetControlID="revKey" HighlightCssClass="Validator"></ajaxToolkit:ValidatorCalloutExtender>
			</td>
		</tr>
		<tr bgcolor="white">
			<td>搜索方式</td>
			<td width="90%">
				<asp:DropDownList ID="ddlMethod" runat="server" SkinID="ddlSkin" Width="200px">
					<asp:ListItem Text="按用户名称" Value="0" Selected="true"></asp:ListItem>
					<asp:ListItem Text="按用户别名" Value="1"></asp:ListItem>
					<asp:ListItem Text="按用户号码" Value="2"></asp:ListItem>
				</asp:DropDownList>
			</td>
		</tr>
		<tr bgcolor="white">						
			<td>验 证 码：</td>
			<td>
				<asp:TextBox ID="tbCode" runat="server" SkinID="tbSkin" Width="80px"></asp:TextBox>
				<asp:Image ID="imgCode" runat="server" ImageUrl = "~/ValidateCode.aspx" />													
			</td>
		</tr>
	</table>
	<asp:UpdatePanel ID="up" runat="server">
		<ContentTemplate>
			<table class="Table" border="0" cellpadding="2" bgcolor="Black" cellspacing="1">
				<tr bgcolor="white">
					<td>&nbsp;</td>
					<td width="90%">				
						<asp:Button ID="btnCommit" runat="server" Text="提交" SkinID="btnSkin" Width="100px" OnClick="btnCommit_Click" />&nbsp;<asp:Label ID="lbMessage" runat="server" CssClass="Text" ForeColor="Red"></asp:Label>
					</td>
				</tr>
				<tr bgcolor="white">
					<td>&nbsp;</td>
					<td width="90%">
					<asp:UpdateProgress ID="upProgress" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="up">
							<ProgressTemplate>
								<font color="red">正在搜索客户，请等待……</font> 
							</ProgressTemplate>
						</asp:UpdateProgress>
					</td>			
				</tr>
				<tr bgcolor="white">
					<td>搜索结果：&nbsp;</td>
					<td width="90%">
						<asp:GridView ID="gvUser" runat="server" EmptyDataText="很遗憾，您搜索的好友不存在。" Width="100%" DataKeyNames="ID" AutoGenerateColumns="False" SkinID="gvSkin" OnRowCommand="gvUser_RowCommand" AllowPaging="True" OnPageIndexChanging="gvUser_PageIndexChanging">
							<EmptyDataTemplate>
								很遗憾，您搜索的客户不存在。
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
								<asp:TemplateField HeaderText="加为客户">
									<ItemTemplate>
										<asp:Button ID="btnAdd" runat="server" Text="加为客户" CommandName="add" CommandArgument='<%# Eval("ID") %>' />
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

