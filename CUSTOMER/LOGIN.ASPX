<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" StylesheetTheme="ASPNETAjaxWeb" Inherits="UserLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>用户登录</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server" />
    <table class="Table" cellpadding="2" cellspacing="0" border="1" bordercolor="#daeeee">
		<tr>
			<td width="150" height="30" align="right">用户名称:</td>
			<td valign="middle">
				<asp:TextBox ID="tbUsername" CssClass="TextBox" runat="server" SkinID="tbSkin" MaxLength="50" Width="200px"></asp:TextBox>
				<asp:RequiredFieldValidator ID="rfNameBlank" runat="server" ControlToValidate="tbUsername" ErrorMessage="用户名称不能为空！" Display="none"></asp:RequiredFieldValidator>
				<asp:RequiredFieldValidator ID="rfNameValue" runat="server" ControlToValidate="tbUsername" InitialValue="请输入用户名称" ErrorMessage="用户名称不能为空！" Display="none"></asp:RequiredFieldValidator>
				<ajaxToolkit:TextBoxWatermarkExtender ID="wmeName" runat="server" TargetControlID="tbUsername" WatermarkText="请输入用户名称" WatermarkCssClass="Watermark"></ajaxToolkit:TextBoxWatermarkExtender>
				<ajaxToolkit:ValidatorCalloutExtender ID="vceNameBlank" runat="server" TargetControlID="rfNameBlank" HighlightCssClass="Validator"></ajaxToolkit:ValidatorCalloutExtender>
				<ajaxToolkit:ValidatorCalloutExtender ID="vceNameValue" runat="server" TargetControlID="rfNameValue" HighlightCssClass="Validator"></ajaxToolkit:ValidatorCalloutExtender>
			</td>
		</tr>
		<tr>
			<td width="150" height="30" valign="middle" align="right">用户密码:</td>
			<td valign="middle">
				<asp:TextBox ID="tbPassword" CssClass="TextBox" runat="server" SkinID="tbSkin" MaxLength="255" Width="200px" TextMode="Password"></asp:TextBox>
				<asp:RequiredFieldValidator ID="rfPwdBlank" runat="server" ControlToValidate="tbPassword" ErrorMessage="用户密码不能为空！" Display="none"></asp:RequiredFieldValidator>
				<asp:RequiredFieldValidator ID="rfPwdValue" runat="server" ControlToValidate="tbPassword" InitialValue="请输入用户密码" ErrorMessage="用户密码不能为空！" Display="none"></asp:RequiredFieldValidator>
				<ajaxToolkit:ValidatorCalloutExtender ID="vcePwdBlank" runat="server" TargetControlID="rfPwdBlank" HighlightCssClass="Validator"></ajaxToolkit:ValidatorCalloutExtender>
				<ajaxToolkit:ValidatorCalloutExtender ID="vcePwdValue" runat="server" TargetControlID="rfPwdValue" HighlightCssClass="Validator"></ajaxToolkit:ValidatorCalloutExtender>
			</td>
		</tr>	
		<tr>
			<td align="right">验 证 码:</td>
			<td width="90%">
				<asp:TextBox ID="tbCode" runat="server" SkinID="tbSkin" Width="80px"></asp:TextBox>
				<asp:Image ID="imgCode" runat="server" ImageUrl = "~/ValidateCode.aspx" />
				<asp:Label ID="lbMessage" runat="server" ForeColor="red" CssClass="Text"></asp:Label>							
			</td>
		</tr>	
		<tr>
			<td width="150" height="30" valign="middle" align="right">
				<asp:Label ID="Label1" runat="server" Width="150px"></asp:Label></td>
			<td valign="middle" width="100%">
				<asp:Button ID="btnLogin" runat="server" Text="用户登录" CssClass="Button" OnClick="btnLogin_Click" />&nbsp;&nbsp;&nbsp;
				<asp:Button ID="btnReturn" runat="server" CssClass="Button" Text="重置" CausesValidation="False" Width="80px" OnClick="btnReturn_Click" /></td>
		</tr>		
    </table>    
    </form>
</body>
</html>
