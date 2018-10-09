<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Desktop.aspx.cs" Inherits="Desktop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>聊天桌面</title>
</head>
<frameset id="Desktop" name="Desktop" rows="24,*" frameborder="0" border="0" framespacing="0">
	<frame id="Toolbar" name="Toolbar" src='Toolbar.aspx?UserID=<% =UserID %>&GroupID=<% =GroupID %>' scrolling="no" noresize></frame>		
	<frame name="Message" src='Messaging.aspx?UserID=<% =UserID %>' scrolling="auto" frameborder="0"></frame>
</frameset>
</html>
