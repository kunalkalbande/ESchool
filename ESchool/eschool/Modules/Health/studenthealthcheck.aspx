<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="studenthealthcheck.aspx.cs" AutoEventWireup="false" Inherits="eschool.Health.studenthealthcheck" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Student Health Checkup</title><!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a s
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY>
		<form id="studenthealthcheck" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="228" width="778" align="center">
				<TBODY>
					<tr>
						<td></td>
						<td vAlign="top" align="center"><asp:label id="Label1" runat="server" Font-Bold="True">STUDENT HEALTH CHECKUP</asp:label>
							<TABLE id="Table1" style="WIDTH: 493px; HEIGHT: 445px" cellSpacing="1" cellPadding="1"
								width="493" borderColorLight="#663300" border="5">
								<TBODY>
									<tr>
										<td colspan="4"><asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label></td>
									</tr>
									<TR>
										<TD>&nbsp;Class&nbsp;<font color="red" size="1">*</font></TD>
										<TD colspan="3"><asp:dropdownlist CssClass="ComboBox" id="Dropclass" runat="server" AutoPostBack="True" Width="100px">
												<asp:ListItem Value="Select">Select</asp:ListItem>
											</asp:dropdownlist>
											<asp:comparevalidator id="Comparevalidator1" runat="server" ControlToValidate="Dropclass" ErrorMessage="Student class must be selected"
												ValueToCompare="---Select---" Operator="NotEqual">*</asp:comparevalidator></TD>
									</TR>
									<TR>
										<TD>&nbsp;Student ID&nbsp;<font color="red" size="1">*</font></TD>
										<TD><asp:dropdownlist CssClass="ComboBox" id="Dropstudentid" runat="server" AutoPostBack="True" Width="100px">
												<asp:ListItem Value="---Select---">Select</asp:ListItem>
											</asp:dropdownlist><asp:comparevalidator id="cvStudentId" runat="server" ControlToValidate="Dropstudentid" ErrorMessage="Student id must be selected"
												ValueToCompare="---Select---" Operator="NotEqual">*</asp:comparevalidator></TD>
										<TD>&nbsp;Name&nbsp;<font color="red" size="1">*</font>
										</TD>
										<TD><asp:textbox CssClass="TextBoxForms" id="txtstudentname" runat="server" Width="155px" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;Duration&nbsp;<font color="red" size="1">*</font></TD>
										<TD><asp:dropdownlist CssClass="ComboBox" id="Dropdocname" runat="server" Width="100px">
												<asp:ListItem Value="Select">Select</asp:ListItem>
												<asp:ListItem Value="Monthly">Monthly</asp:ListItem>
												<asp:ListItem Value="Quaterly">Quaterly</asp:ListItem>
												<asp:ListItem Value="HalfYearly">HalfYearly</asp:ListItem>
												<asp:ListItem Value="Yearly">Yearly</asp:ListItem>
											</asp:dropdownlist><asp:comparevalidator id="cvDuration" runat="server" ControlToValidate="Dropdocname" ErrorMessage="Please select the duration"
												ValueToCompare="Select" Operator="NotEqual">*</asp:comparevalidator></TD>
										<TD>&nbsp;Checked By Doctor&nbsp;<font color="red" size="1">*</font></TD>
										<TD><asp:dropdownlist CssClass="ComboBox" id="Dropchdoc" Width="155px" runat="server"></asp:dropdownlist><asp:comparevalidator id="cvDocCheck" runat="server" ControlToValidate="Dropchdoc" ErrorMessage="Doctor must be selected"
												ValueToCompare="Select" Operator="NotEqual">*</asp:comparevalidator></TD>
									</TR>
									<TR>
										<td>&nbsp;Blood Group&nbsp;<font color="red" size="1">*</font></td>
										<td><asp:dropdownlist CssClass="ComboBox" id="Dropbg" Width="100px" Runat="server">
												<asp:ListItem Value="Select">Select</asp:ListItem>
											</asp:dropdownlist></td>
										<TD>&nbsp;Checked By Staff&nbsp;<font color="red" size="1">*</font></TD>
										<TD><asp:dropdownlist CssClass="ComboBox" id="Dropstaff" Width="155px" runat="server"></asp:dropdownlist>
											<asp:comparevalidator id="cvStaff" runat="server" ControlToValidate="Dropstaff" ErrorMessage="Staff must be selected"
												ValueToCompare="Select" Operator="NotEqual">*</asp:comparevalidator></TD>
									</TR>
									<TR>
										<TD>&nbsp;Eyes&nbsp;</TD>
										<TD><asp:dropdownlist CssClass="ComboBox" id="Dropeye" runat="server" Width="100px">
												<asp:ListItem Value="Satisfied">Satisfied</asp:ListItem>
												<asp:ListItem Value="UnSatisfied">UnSatisfied</asp:ListItem>
											</asp:dropdownlist></TD>
										<TD>&nbsp;Description</TD>
										<TD><asp:textbox CssClass="TextBoxForms" id="Textdeseye1" MaxLength="30" runat="server" Width="155px"
												TextMode="SingleLine"></asp:textbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;Nose&nbsp;</TD>
										<TD><asp:dropdownlist CssClass="ComboBox" id="Dropnoise" runat="server" Width="100px">
												<asp:ListItem Value="Satisfied">Satisfied</asp:ListItem>
												<asp:ListItem Value="UnSatisfied">UnSatisfied</asp:ListItem>
											</asp:dropdownlist></TD>
										<TD>&nbsp;Description</TD>
										<TD><asp:textbox CssClass="TextBoxForms" id="Textdesnoise1" MaxLength="30" runat="server" Width="155px"
												TextMode="SingleLine"></asp:textbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;Hands&nbsp;</TD>
										<TD><asp:dropdownlist CssClass="ComboBox" id="Drophands" runat="server" Width="100px">
												<asp:ListItem Value="Satisfied">Satisfied</asp:ListItem>
												<asp:ListItem Value="UnSatisfied">UnSatisfied</asp:ListItem>
											</asp:dropdownlist></TD>
										<TD>&nbsp;Description</TD>
										<TD><asp:textbox CssClass="TextBoxForms" id="Textdeshands1" MaxLength="30" runat="server" Width="155px"
												TextMode="SingleLine"></asp:textbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;Legs&nbsp;</TD>
										<TD><asp:dropdownlist CssClass="ComboBox" id="Droplegs" runat="server" Width="100px">
												<asp:ListItem Value="Satisfied">Satisfied</asp:ListItem>
												<asp:ListItem Value="UnSatisfied">UnSatisfied</asp:ListItem>
											</asp:dropdownlist></TD>
										<TD>&nbsp;Description</TD>
										<TD><asp:textbox CssClass="TextBoxForms" id="Textdeslegs1" MaxLength="30" runat="server" Width="155px"
												TextMode="SingleLine"></asp:textbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;Teeth&nbsp;</TD>
										<TD><asp:dropdownlist CssClass="ComboBox" id="Dropteeth" runat="server" Width="100px">
												<asp:ListItem Value="Satisfied">Satisfied</asp:ListItem>
												<asp:ListItem Value="UnSatisfied">UnSatisfied</asp:ListItem>
											</asp:dropdownlist></TD>
										<TD>&nbsp;Description</TD>
										<TD><asp:textbox CssClass="TextBoxForms" id="Textdesteeth1" MaxLength="30" runat="server" Width="155px"
												TextMode="SingleLine"></asp:textbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;Bp&nbsp;</TD>
										<TD><asp:dropdownlist CssClass="ComboBox" id="Dropbp" runat="server" Width="100px">
												<asp:ListItem Value="Satisfied">Satisfied</asp:ListItem>
												<asp:ListItem Value="UnSatisfied">UnSatisfied</asp:ListItem>
											</asp:dropdownlist></TD>
										<TD>&nbsp;Description</TD>
										<TD><asp:textbox CssClass="TextBoxForms" id="Textdesbp1" MaxLength="30" runat="server" Width="155px"
												TextMode="SingleLine"></asp:textbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;Heart Beat&nbsp;</TD>
										<TD><asp:dropdownlist CssClass="ComboBox" id="Dropheart" runat="server" Width="100px">
												<asp:ListItem Value="Satisfied">Satisfied</asp:ListItem>
												<asp:ListItem Value="UnSatisfied">UnSatisfied</asp:ListItem>
											</asp:dropdownlist></TD>
										<TD>&nbsp;Description</TD>
										<TD><asp:textbox CssClass="TextBoxForms" id="Textdesheart1" MaxLength="30" runat="server" Width="155px"
												TextMode="SingleLine"></asp:textbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;Skin&nbsp;</TD>
										<TD><asp:dropdownlist CssClass="ComboBox" id="DropSkin" runat="server" Width="100px">
												<asp:ListItem Value="Satisfied">Satisfied</asp:ListItem>
												<asp:ListItem Value="Unsatisfied">Unsatisfied</asp:ListItem>
											</asp:dropdownlist></TD>
										<TD>&nbsp;Description</TD>
										<TD><asp:textbox CssClass="TextBoxForms" id="txtSkindes1" MaxLength="30" runat="server" Width="155px"
												TextMode="SingleLine"></asp:textbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;Mental&nbsp;</TD>
										<TD><asp:dropdownlist CssClass="ComboBox" id="Dropmental" runat="server" Width="100px">
												<asp:ListItem Value="Satisfied">Satisfied</asp:ListItem>
												<asp:ListItem Value="UnSatisfied">UnSatisfied</asp:ListItem>
											</asp:dropdownlist></TD>
										<TD>&nbsp;Description</TD>
										<TD><asp:textbox CssClass="TextBoxForms" id="Textdesmentalt1" MaxLength="30" runat="server" Width="155px"
												TextMode="SingleLine"></asp:textbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;Ears&nbsp;</TD>
										<TD><asp:dropdownlist CssClass="ComboBox" id="Dropear" runat="server" Width="100px">
												<asp:ListItem Value="Satisfied">Satisfied</asp:ListItem>
												<asp:ListItem Value="UnSatisfied">UnSatisfied</asp:ListItem>
											</asp:dropdownlist></TD>
										<TD>&nbsp;Description</TD>
										<TD><asp:textbox CssClass="TextBoxForms" id="Textdesear1" runat="server" MaxLength="30" Width="155px"
												TextMode="SingleLine"></asp:textbox></TD>
									</TR>
									<TR>
										<TD align="center" colSpan="4">&nbsp;<asp:button id="btnSave" runat="server" CssClass="formbuttonstyle" Text="Save"></asp:button>
											&nbsp;<asp:button id="BtnReset" CssClass="formbuttonstyle" Text="Reset" CausesValidation="False" Runat="server"></asp:button>
											&nbsp;
											<asp:ValidationSummary id="vsHealthcheck" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary></TD>
									</TR>
								</TBODY>
							</TABLE>
						</td>
						<td></td>
					</tr>
				</TBODY>
			</table>
		</form>
		<uc1:Footer id="Footer1" runat="server"></uc1:Footer></TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>
	</BODY>
</HTML>
