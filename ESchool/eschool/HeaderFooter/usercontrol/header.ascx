<%@ Control Language="c#" AutoEventWireup="false" Codebehind="header.ascx.cs" Inherits="eschool.usercontrol.header" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

<HTML>
  <HEAD>
		<TITLE>Template 1.Page 2 modified2</TITLE>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href=/eschool/HeaderFooter/shareables/Style/Styles.css type="text/css" rel="stylesheet">
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<!--		<STYLE type="text/css">BODY { SCROLLBAR-FACE-COLOR: #075D01; SCROLLBAR-HIGHLIGHT-COLOR: white; SCROLLBAR-SHADOW-COLOR: #E6EF01; SCROLLBAR-ARROW-COLOR: #E6EF01; SCROLLBAR-BASE-COLOR: #E6EF01; scrollbar-dark-shadow-color: white; scrollbar-3d-light-color: black }
		</STYLE>	--><LINK href="Styles.css" type="text/css" rel="stylesheet">
  </HEAD>
	<BODY bgColor="#ffffff" leftMargin="0" topMargin="0" rightMargin="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<!-- ImageReady Slices (Template 1.Page 2 modified2.psd) -->
		<TABLE cellSpacing="0" cellPadding="0" width="770" border="0" align="center">
			<TR>
				<TD width="770" background=/eschool/HeaderFooter/images/header1.jpg colSpan="3" height="109"></TD>
			</TR>
			<tr>
				<!--td colspan="3">
					<SCRIPT type="text/javascript" src="/eschool/shareables/jsfiles/coolmenus3.js"></SCRIPT>
					<SCRIPT type="text/javascript" src="/eschool/shareables/jsfiles/menubar.js"></SCRIPT>
					<SCRIPT type="text/javascript" src="/eschool/shareables/jsfiles/stMainLinks.js"></SCRIPT>
				</td-->
				<td colspan="3" background="/eschool/HeaderFooter/images/eSchoolMenu_08111.jpg" WIDTH="770" HEIGHT="23">
					<SCRIPT type="text/javascript" src=/eschool/HeaderFooter/shareables/jsfiles/stm31.js></SCRIPT>
					<SCRIPT type="text/javascript" src=/eschool/HeaderFooter/shareables/jsfiles/menu.htm></SCRIPT>
				</td>
			</tr>
			<tr height="25">
				<td align="left" valign="baseline">
					<asp:Label id="Label1" runat="server" Font-Bold="True" ForeColor="Maroon">Current Date : </asp:Label>
					<asp:Label id="lblDate" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label>
					&nbsp;<asp:Label id="Labusertype" runat="server" Font-Bold="True" ForeColor="Maroon">User Type :</asp:Label>
					<asp:Label id="Labusertype1" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label>
					&nbsp;<asp:Label id="Labelloginby" runat="server" Font-Bold="True" ForeColor="Maroon">Login By :</asp:Label>
					<asp:Label id="Labelloginby3" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
				<td align="right" colspan="2" valign="middle">
                <asp:HyperLink ID="HLinkHome" runat="server" NavigateUrl="~/LoginHome/Menu.aspx" ForeColor="Maroon"><STRONG>Home</STRONG></asp:HyperLink></td>
				<!--td align="right"></td-->
			</tr>
		</TABLE>
		<!-- End ImageReady Slices -->
	</BODY>
</HTML>
