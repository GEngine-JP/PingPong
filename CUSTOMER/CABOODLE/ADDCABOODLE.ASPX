<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCaboodle.aspx.cs" Inherits="Caboodle_AddCaboodle" StylesheetTheme="ASPNETAjaxWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>添加新团队</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
    <table class="Table" border="0" cellpadding="2" bgcolor="Black" cellspacing="1">
		<tr bgcolor="white">
			<td colspan="2"><hr /></td>
		</tr>
		<tr bgcolor="white">
			<td>团队名称：</td>
			<td width="90%"><asp:TextBox ID="tbName" runat="server" SkinID="tbSkin" Width="60%" MaxLength="20"></asp:TextBox>
				<asp:RequiredFieldValidator ID="rfNameBlank" runat="server" ControlToValidate="tbName" Display="none" ErrorMessage="群名称不能为空！"></asp:RequiredFieldValidator>
				<asp:RequiredFieldValidator ID="rfNameValue" runat="server" ControlToValidate="tbName" Display="none" InitialValue="请输入群名称" ErrorMessage="名称不能为空！"></asp:RequiredFieldValidator>
				<asp:RegularExpressionValidator ID="revName" runat="server" ControlToValidate="tbName" Display="none" ErrorMessage="群名称的长度最大为20，请重新输入。" ValidationExpression=".{1,20}"></asp:RegularExpressionValidator>
				<ajaxToolkit:TextBoxWatermarkExtender ID="wmeName" runat="server" TargetControlID="tbName" WatermarkText="请输入群名称" WatermarkCssClass="Watermark"></ajaxToolkit:TextBoxWatermarkExtender>
				<ajaxToolkit:ValidatorCalloutExtender ID="vceNameBlank" runat="server" TargetControlID="rfNameBlank" HighlightCssClass="Validator"></ajaxToolkit:ValidatorCalloutExtender>
				<ajaxToolkit:ValidatorCalloutExtender ID="vceNameValue" runat="server" TargetControlID="rfNameValue" HighlightCssClass="Validator"></ajaxToolkit:ValidatorCalloutExtender>
				<ajaxToolkit:ValidatorCalloutExtender ID="vceNameRegex" runat="server" TargetControlID="revName" HighlightCssClass="Validator"></ajaxToolkit:ValidatorCalloutExtender>
			</td>
		</tr>
		<tr bgcolor="white">
			<td valign="top">团队简介：</td>
			<td width="90%">
				<asp:TextBox ID="tbRemark" runat="server" MaxLength="1000" TextMode="MultiLine" Width="98%" Height="100px" SkinID="tbSkin"></asp:TextBox>
				<asp:RequiredFieldValidator ID="rfRemarkBlank" runat="server" ControlToValidate="tbRemark" ErrorMessage="群简介不能为空" Display="none"></asp:RequiredFieldValidator>
				<asp:RequiredFieldValidator ID="rfRemarkValue" runat="server" ControlToValidate="tbRemark" InitialValue="请在这里输入群简介" ErrorMessage="群简介不能为空" Display="none"></asp:RequiredFieldValidator>
				<asp:RegularExpressionValidator ID="revRemark" runat="server" ControlToValidate="tbRemark" ErrorMessage="群简介的最大长度为1000。" Display="none" ValidationExpression=".{1,1000}"></asp:RegularExpressionValidator>
				<ajaxToolkit:TextBoxWatermarkExtender ID="wmeRemark" runat="server" TargetControlID="tbRemark" WatermarkText="请在这里输入群简介" WatermarkCssClass="Watermark"></ajaxToolkit:TextBoxWatermarkExtender>
				<ajaxToolkit:ValidatorCalloutExtender ID="vceRemarkBlank" runat="server" TargetControlID="rfRemarkBlank" HighlightCssClass="Validator"></ajaxToolkit:ValidatorCalloutExtender>
				<ajaxToolkit:ValidatorCalloutExtender ID="vceRemarkValue" runat="server" TargetControlID="rfRemarkValue" HighlightCssClass="Validator"></ajaxToolkit:ValidatorCalloutExtender>
				<ajaxToolkit:ValidatorCalloutExtender ID="vceRevRemark" runat="server" TargetControlID="revRemark" HighlightCssClass="Validator"></ajaxToolkit:ValidatorCalloutExtender>
			</td>
		</tr>			
		<tr bgcolor="white">
			<td>&nbsp;</td>
			<td width="90%">
				<asp:UpdatePanel ID="upbutton" runat="server">
					<ContentTemplate>
						<asp:Button ID="btnCommit" runat="server" Text="提交" SkinID="btnSkin" Width="100px" OnClick="btnCommit_Click" />
					</ContentTemplate>					
				</asp:UpdatePanel>
			</td>			
		</tr>
    </table>   
    </form>
</body>
</html>
