<%@ Page language="c#" Codebehind="AccessDeny.aspx.cs" AutoEventWireup="false" Inherits="eschool.AccessDeny" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="/eschool/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="/eschool/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>eschool: Access Deny</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href=/eschool/shareables/Style/Styles.css>
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:Header id="Header1" runat="server" DESIGNTIMEDRAGDROP="11"></uc1:Header>
			<table width="778" height="250" align=center>
				<tr><td height=100>&nbsp;</td></tr>
				<tr>
					<td align=center>
						<FONT color="red" size="5"> Access Denied </FONT>
					</td>
				</tr>
			</table>
			<uc1:Footer id="Footer1" runat="server"></uc1:Footer>
		</form>
	</body>
</HTML>
