<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="Attendance.aspx.cs" AutoEventWireup="false" Inherits="eschool.Form.Attendance" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Employee Attendance</title><!--
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
		<LINK href=../../HeaderFooter/shareables/Style/Styles.css type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Attendance" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<!--<tr>
					<td colSpan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:Label id="Label1" runat="server" ForeColor="Transparent">
							
						</asp:Label></td>
				</tr>
				<tr>
					<td align="center" colSpan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:LinkButton id="LinkButton1" runat="server" CausesValidation="False">Attendance For All staff</asp:LinkButton></td>
				</tr>-->
				<tr>
					<td vAlign="top" align="center"><b>EMPLOYEE ATTENDANCE</b>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" borderColorLight="#663300" border="5">
							<TR>
								<TD>Employee ID</TD>
								<TD><asp:dropdownlist id="Dropempid" runat="server" AutoPostBack="True">
										<asp:ListItem Value="---Select---"></asp:ListItem>
									</asp:dropdownlist>
									<asp:CompareValidator id="cvEmpID" runat="server" ControlToValidate="Dropempid" ErrorMessage="You must be select the employee id"
										Operator="NotEqual" ValueToCompare="---Select---">*</asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD>Employee Name</TD>
								<TD><asp:textbox id="txtempnm" runat="server" Enabled="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Attandance Status</TD>
								<TD>
									<asp:DropDownList id="DropDownList1" runat="server">
										<asp:ListItem Value="---Select---"></asp:ListItem>
										<asp:ListItem Value="Yes"></asp:ListItem>
										<asp:ListItem Value="No"></asp:ListItem>
										<asp:ListItem Value="Ist Half"></asp:ListItem>
										<asp:ListItem Value="IInd Half"></asp:ListItem>
										<asp:ListItem Value="HoliDay"></asp:ListItem>
									</asp:DropDownList>
									<asp:CompareValidator id="cvAttd" runat="server" ControlToValidate="DropDownList1" ErrorMessage="You must be select the attendance status"
										ValueToCompare="---Select---" Operator="NotEqual">*</asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3">
									<asp:Button id="btnSave" runat="server" Text="Save" CssClass="formbuttonstyle"></asp:Button>
									<asp:button id="BtnReset" Runat="server" Text="Reset" CausesValidation="False" CssClass="formbuttonstyle"></asp:button></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3">
									<asp:ValidationSummary id="vsEmpAttendance" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary></TD>
							</TR>
						</TABLE>
						&nbsp;
					</td>
					<td></td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer>
		</form>
	</body>
</HTML>
