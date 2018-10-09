<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyMessage.aspx.cs" Inherits="UserInfo_MyMessage" StylesheetTheme="ASPNETAjaxWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>我的聊天记录</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server" ></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="up">
		<ContentTemplate>						
			<table class="Table" border="0" cellpadding="5" cellspacing="0">
				<tr bgcolor="white">
					<td>选择客户</td>
					<td width="90%"><asp:DropDownList ID="ddlUser" runat="server" SkinID="ddlSkin" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlUser_SelectedIndexChanged"></asp:DropDownList>
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:GridView ID="gvMessage" runat="server" Width="100%" AutoGenerateColumns="False" SkinID="gvSkin" AllowPaging="True" OnPageIndexChanging="gvMessage_PageIndexChanging">
							<EmptyDataTemplate>聊天记录为空！</EmptyDataTemplate>
							<Columns>
								<asp:TemplateField>
									<ItemTemplate>
										<table class="Table" cellpadding="3" cellspacing="0">
											<tr>
												<td><a href='../Hailfellow/ShowFellowInfo.aspx?UserID=<%# Eval("Sender") %>' target="_blank"><%# Eval("SenderName") %></a> 于[<%# Eval("CreateDate") %>]发送给 <a href='../Hailfellow/ShowFellowInfo.aspx?UserID=<%# Eval("Receiver") %>' target="_blank"><%# Eval("ReceiverName") %></a></td>												
											</tr>
											<tr>
												<td colspan="2"><hr size="1" /></td>
											</tr>
											<tr>
												<td colspan="2">　<%# Eval("Body") %></td>
											</tr>
										</table>
									</ItemTemplate>
								</asp:TemplateField>								
							</Columns>
							<PagerSettings Mode="NextPreviousFirstLast" />
						</asp:GridView>								
					</td>
				</tr>
				<tr bgcolor="white">
					<td>&nbsp;</td>
					<td width="90%">
						<asp:Button ID="btnToExcell" runat="server" Text="导出到Excell文件" SkinID="btnSkin" OnClick="btnToExcell_Click" />&nbsp;&nbsp;<asp:Button ID="btnToTxt" runat="server" Text="导出到文本文件" SkinID="btnSkin" OnClick="btnToTxt_Click" />
					</td>			
				</tr>
			</table>
		</ContentTemplate>
	</asp:UpdatePanel>	
    </form>
</body>
</html>

