<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Header11.ascx.cs" Inherits="eschool.usercontrol.Header11" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<HTML>
	<HEAD>
		<TITLE>Template 1.Page 2 modified2</TITLE>
		<LINK href="/eschool/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY bgColor="#ffffff" leftMargin="0" topMargin="0" rightMargin="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<TABLE cellSpacing="0" cellPadding="0" width="770" align="center" border="0">
			<TR>
				<TD width="770" background="/eschool/images/header1.jpg" colSpan="3" height="109"></TD>
			</TR>
			<tr>
				<td width="770" background="/eschool/images/eSchoolMenu_08111.JPG" colSpan="3" height="23">
					<SCRIPT src="/eschool/shareables/jsfiles/stm31.js" type="text/javascript"></SCRIPT>
					<SCRIPT src="/eschool/shareables/jsfiles/menu.htm" type="text/javascript"></SCRIPT>
				</td>
			</tr>
			<tr vAlign="baseline">
				<td align="left"><asp:label id="Label1" runat="server" Font-Bold="True" ForeColor="Maroon">Current Date : </asp:label><asp:label id="lblDate" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:label>&nbsp;<asp:label id="Labusertype" runat="server" Font-Bold="True" ForeColor="Maroon">User Type :</asp:label>
					<asp:label id="Labusertype1" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:label>&nbsp;<asp:label id="Labelloginby" runat="server" Font-Bold="True" ForeColor="Maroon">Login By :</asp:label>
					<asp:label id="Labelloginby3" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:label></td>
				<td align="right" colSpan="2"><asp:HyperLink ID="hl11" Runat="server" NavigateUrl="../Login.aspx">logout</asp:HyperLink>&nbsp;
					<a href="/eschool/Login.aspx">Vikash</a>
				</td>
			</tr>
		</TABLE>
	</BODY>
</HTML>
