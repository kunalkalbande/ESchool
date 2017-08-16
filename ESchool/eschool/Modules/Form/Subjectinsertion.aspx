<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="Subjectinsertion.aspx.cs" AutoEventWireup="false" Inherits="eschool.Form.Subjectinsertion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Subject Insertion</title><!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<script language="javascript" id="validation1" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
	</HEAD>
	<body>
		<form id="Subjectinsertion" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td></td>
					<td valign="top" align="center">
						<asp:Label id="Label1" runat="server">
							<b>SUBJECT INSERTION</b></asp:Label>
						<TABLE id="Table1" cellspacing="0" cellPadding="1" border="5" borderColorLight="#663300">
							<TR>
								<TD>Subject Name</TD>
								<TD>
									<asp:dropdownlist id="DropDownList1" runat="server" AutoPostBack="True">
										<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD>Add New Subject&nbsp;&nbsp;</TD>
								<TD>
									<asp:TextBox id="txtsubject" onkeypress="return GetOnlyChars(this, event);" BorderStyle="Groove"
										MaxLength="20" runat="server"></asp:TextBox>
								</TD>
							</TR>
							<TR>
								<TD align="center" colSpan="2">
									<asp:Button id="btnSave" runat="server" Text="Add" CssClass="formbuttonstyle"></asp:Button>
									<asp:button id="btnEdit" runat="server" Text="Edit" CssClass="formbuttonstyle"></asp:button>
									<asp:button id="btnSEdit" runat="server" Text=" Edit Save" CssClass="formbuttonstyle"></asp:button>
									<asp:button id="btnDelete" runat="server" Text="Delete" CssClass="formbuttonstyle"></asp:button>
								</TD>
							</TR>
							<tr>
							</tr>
						</TABLE>
					</td>
				</tr>
			</table>
			<uc1:Footer id="Footer1" runat="server"></uc1:Footer>
		</form>
	</body>
</HTML>
