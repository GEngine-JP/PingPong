<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Leaveword.aspx.cs" Inherits="LeavewordPage" StylesheetTheme="ASPNETAjaxWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>发送留言</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
    <table class="Table" border="0" cellpadding="2" bgcolor="Black" cellspacing="1">
		<tr bgcolor="white">
			<td colspan="2"><hr /><a name="message"></a></td>
		</tr>
		<tr bgcolor="white">
			<td>发送到：</td>
			<td width="90%"><asp:Label ID="lbUsername" runat="server" Font-Bold="true" ForeColor="red"></asp:Label>客户。
			</td>
		</tr>
		<tr bgcolor="white">
			<td valign="top">留言内容：</td>
			<td width="90%">
				<asp:TextBox ID="tbMessage" runat="server" MaxLength="1000" TextMode="MultiLine" Width="98%" Height="100px" SkinID="tbSkin"></asp:TextBox>
				<asp:RequiredFieldValidator ID="rfMessageBlank" runat="server" ControlToValidate="tbMessage" ErrorMessage="留言不能为空" Display="none"></asp:RequiredFieldValidator>
				<asp:RequiredFieldValidator ID="rfMessageValue" runat="server" ControlToValidate="tbMessage" InitialValue="请在这里输入留言" ErrorMessage="留言不能为空" Display="none"></asp:RequiredFieldValidator>
				<asp:RegularExpressionValidator ID="revMessage" runat="server" ControlToValidate="tbMessage" ErrorMessage="留言的最大长度为1000。" Display="none" ValidationExpression=".{1,1000}"></asp:RegularExpressionValidator>
				<ajaxToolkit:TextBoxWatermarkExtender ID="wmeMessage" runat="server" TargetControlID="tbMessage" WatermarkText="请在这里输入留言" WatermarkCssClass="Watermark"></ajaxToolkit:TextBoxWatermarkExtender>
				<ajaxToolkit:ValidatorCalloutExtender ID="vceMessageBlank" runat="server" TargetControlID="rfMessageBlank" HighlightCssClass="Validator"></ajaxToolkit:ValidatorCalloutExtender>
				<ajaxToolkit:ValidatorCalloutExtender ID="vceMessageValue" runat="server" TargetControlID="rfMessageValue" HighlightCssClass="Validator"></ajaxToolkit:ValidatorCalloutExtender>
				<ajaxToolkit:ValidatorCalloutExtender ID="vceRevMessage" runat="server" TargetControlID="revMessage" HighlightCssClass="Validator"></ajaxToolkit:ValidatorCalloutExtender>
			</td>
		</tr>
		<tr bgcolor="white">
			<td>&nbsp;</td>
			<td width="90%">
				<asp:Button ID="btnCommit" runat="server" Text="发送" SkinID="btnSkin" Width="100px" OnClick="btnCommit_Click" />&nbsp;
			</td>			
		</tr>
    </table>   
    </form>
</body>
</html>
