<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>在线即时通讯工具</title>
</head>
<frameset id="Default" rows="64,*" frameborder="0" border="0" framespacing="0">
	<frame id="Header" name="Header" src="Header.aspx" scrolling="auto" noresize></frame>	
	<frameset id="Main" cols="164,*" rows="*" border="0" framespacing="0">
		<frame name="User" src="Hailfellow/Fellow.aspx" scrolling="auto" frameborder="0" noresize></frame>
		<frame name="Desktop" scrolling="auto" src="Desktop.aspx" frameborder="0" noresize></frame>
	</frameset>	
</frameset>
</html>
