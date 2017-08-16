<%@ Page language="c#" Codebehind="Student_MarksEntry.aspx.cs" AutoEventWireup="false" Inherits="eschool.Forms.Student_MarksEntry" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
<HTML>
	<HEAD>
		<title>Student_MarksEntry</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<script language="javascript" id="Validations" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY>
		<FORM id="Student_MarksEntry" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table id="Table1" height="232" width="778" align="center">
				<tr>
					<td></td>
				</tr>
				<tr>
					<td></td>
					<td vAlign="top" align="center">
						<asp:label id="Label3" runat="server" Font-Bold="True">STUDENT MARKS</asp:label>
						<table id="Table2" align="center" borderColorLight="#663300" border="4" width="62%">
							<tr>
								<td align="left">StudentID</td>
								<td colspan="3"><asp:dropdownlist id="DropStudID" AutoPostBack="True" Runat="server">
										<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
									</asp:dropdownlist><asp:comparevalidator id="cvStudentId" runat="server" ControlToValidate="DropStudID" ErrorMessage="Student id must be selected"
										Operator="NotEqual" ValueToCompare="---Select---">*</asp:comparevalidator></td>
							</tr>
							<tr>
								<td>Student Name</td>
								<td colspan="3"><asp:textbox id="TxtFname" Runat="server" Enabled="False"></asp:textbox></td>
							</tr>
							<tr>
								<td>Class</td>
								<td><asp:textbox id="Txtclass" Runat="server" Enabled="False"></asp:textbox></td>
								<td align="center">Stream</td>
								<td><asp:textbox id="txtStream" Runat="server" Enabled="False"></asp:textbox></td>
							</tr>
							<TR>
								<TD>Teacher Name</TD>
								<TD>
									<asp:dropdownlist id="DropteacherName" Runat="server" AutoPostBack="True">
										<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
									</asp:dropdownlist>
									<asp:comparevalidator id="Comparevalidator1" runat="server" ValueToCompare="---Select---" Operator="NotEqual"
										ErrorMessage="Teacher name must be selected" ControlToValidate="DropteacherName">*</asp:comparevalidator></TD>
								<TD align="center">Subject</TD>
								<TD>
									<asp:textbox id="TxtSubject" Runat="server" Enabled="False"></asp:textbox></TD>
							</TR>
							<tr>
								<td>Exam</td>
								<td><asp:dropdownlist id="Droptest" Runat="server">
										<asp:ListItem Value="---Select---"></asp:ListItem>
										<asp:ListItem Value="Terminal"></asp:ListItem>
										<asp:ListItem Value="Half Yearly"></asp:ListItem>
										<asp:ListItem Value="Final"></asp:ListItem>
									</asp:dropdownlist><asp:comparevalidator id="cvExam" runat="server" ControlToValidate="Droptest" ErrorMessage="Exam must be selected"
										Operator="NotEqual" ValueToCompare="---Select---">*</asp:comparevalidator></td>
								<td align="center">
									Marks</td>
								<td>
									<asp:textbox id="TxtMarks" Runat="server" onkeypress="return GetOnlyNumbers(this, event, false,true);"></asp:textbox>
									<asp:requiredfieldvalidator id="Refpinco" Runat="server" ErrorMessage="You Must Enter Marks" ControlToValidate="TxtMarks"
										Display="Dynamic">*</asp:requiredfieldvalidator>
									<asp:comparevalidator id="Comparevalidator3" Runat="server" Operator="DataTypeCheck" ErrorMessage="Enter in Numeric Format"
										ControlToValidate="TxtMarks" Display="Dynamic" Type="Integer">*</asp:comparevalidator></td>
							</tr>
							<tr>
								<td align="center" colSpan="4">
									<asp:Button id="btnSave" runat="server" Text="Save" CssClass="formbuttonstyle"></asp:Button>
									<asp:button id="BtnReset" Runat="server" Text="Reset" CausesValidation="False" CssClass="formbuttonstyle"></asp:button></td>
							</tr>
							<tr>
								<td colSpan="5">
									<asp:ValidationSummary id="vsStuMarks" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary></td>
							</tr>
						</table>
					</td>
					<td></td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></FORM>
	</BODY>
</HTML>
