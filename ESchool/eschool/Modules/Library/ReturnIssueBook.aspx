<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="ReturnIssueBook.aspx.cs" AutoEventWireup="false" Inherits="eschool.Library.FORMS.ReturnIssueBook" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Return Issue Book</title> 
		<!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="ReturnIssueBook" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td></td>
					<td align="center"><asp:label id="Label2" runat="server"></asp:label></td>
					<td align="center"></td>
				</tr>
				<tr>
					<td></td>
					<td vAlign="top" align="center"><b>RETURN ISSUE BOOK</b>
						<TABLE borderColorLight="#663300" border="5">
							<TR>
								<TD>&nbsp;Candidate ID</TD>
								<TD><asp:dropdownlist id="ddbook" runat="server" AutoPostBack="True" CssClass="ComboBox" Width="125px">
										<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
									</asp:dropdownlist><asp:comparevalidator id="cvCandidateId" runat="server" ValueToCompare="---Select---" ErrorMessage="Yoy must select the candidate Id"
										ControlToValidate="ddbook" Operator="NotEqual">*</asp:comparevalidator></TD>
							</TR>
							<TR>
								<TD>&nbsp;Book ID</TD>
								<TD><asp:textbox id="TxtBookID" runat="server" CssClass="TextBoxForms" Enabled="False" Width="125px"></asp:textbox><asp:dropdownlist id="DropBookID" AutoPostBack="True" Width="50" Runat="server" Visible="false"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD>&nbsp;Book Name</TD>
								<TD><asp:textbox id="lblBookName" CssClass="TextBoxForms" Enabled="False" Width="125px" Runat="server"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>&nbsp;Date OF Issue</TD>
								<TD><asp:textbox id="TxtDateofissue" CssClass="TextBoxForms" Enabled="False" Width="125px" Runat="server"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>&nbsp;Return Date</TD>
								<TD><asp:textbox id="TxtReturnDate" CssClass="TextBoxForms" Enabled="False" Width="125px" Runat="server"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3">&nbsp;
									<asp:button id="btnSave" runat="server" CssClass="formbuttonstyle" Text="Return"></asp:button>&nbsp;
									<asp:button id="BtnReset" CssClass="formbuttonstyle" Runat="server" Text="Reset" CausesValidation="False"></asp:button><asp:validationsummary id="vsReturnbook" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
