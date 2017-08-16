<%@ Page language="c#" Codebehind="StudentRegistration.aspx.cs" AutoEventWireup="false" Inherits="eschool.Forms.Form1" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Student Registration</title><!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<SCRIPT src="../../HeaderFooter/shareables/jsfiles/Country.js" type="text/javascript"></SCRIPT>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<script language="javascript" id="Validations" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY>
		<FORM id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="228" width="778" align="center">
				<tr>
					<td vAlign="top" align="center"><asp:label id="Label3" runat="server" Font-Bold="True">STUDENT REGISTRATION</asp:label>
						<table align="center" borderColorLight="#663300" border="5">
							<TBODY>
								<TR>
									<TD bgColor="white" colSpan="4" rowSpan="1"><asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label><INPUT id="txtState" style="VISIBILITY: hidden; WIDTH: 48px; HEIGHT: 10px" type="text"
											size="2" name="txtState" runat="server" DESIGNTIMEDRAGDROP="3839"> <INPUT id="txtCity" style="VISIBILITY: hidden; WIDTH: 48px; HEIGHT: 10px" type="text" size="2"
											name="txtCity" runat="server"> <INPUT id="txtState1" style="VISIBILITY: hidden; WIDTH: 48px; HEIGHT: 10px" type="text"
											size="2" name="txtState1" runat="server"> <INPUT id="txtCity1" style="VISIBILITY: hidden; WIDTH: 48px; HEIGHT: 10px" type="text"
											size="2" name="txtCity1" runat="server"> <INPUT id="txtName" style="VISIBILITY: hidden; WIDTH: 53px; HEIGHT: 10px" type="text" size="3"
											name="txtName" runat="server"> <INPUT id="txtCountry" style="VISIBILITY: hidden; WIDTH: 48px; HEIGHT: 10px" type="text"
											size="2" name="txtCity1" runat="server"> <INPUT id="txtCountry1" style="VISIBILITY: hidden; WIDTH: 48px; HEIGHT: 10px" type="text"
											size="2" name="txtCity1" runat="server"> <INPUT id="tempCash" style="VISIBILITY: hidden; WIDTH: 48px; HEIGHT: 10px" type="text"
											size="2" name="tempCash" runat="server">
									</TD>
								</TR>
								<tr>
									<td>&nbsp;Registration ID</td>
									<td colSpan="3"><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="DropStudentID"
											BorderStyle="Groove" runat="server" Width="80" AutoPostBack="True" CssClass="TextBoxForms"></asp:textbox>&nbsp;&nbsp;
										<asp:label id="lblStudentID" ForeColor="blue" Runat="server"></asp:label>
										<asp:button id="btnEdit" runat="server" CssClass="FormEditButtonStyle" Text="..." CausesValidation="False"
											ToolTip="Edit the Student Registration Record"></asp:button></td>
								</tr>
								<TR>
									<TD>&nbsp;Class&nbsp;<FONT color="#ff0033" size="1">*</FONT></TD>
									<TD><asp:dropdownlist id="Dropclass" Runat="server" Width="100" CssClass="ComboBox">
											<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
										</asp:dropdownlist>&nbsp;<asp:comparevalidator id="compvalid1" Runat="server" Operator="NotEqual" ErrorMessage="Please Select Class"
											ValueToCompare="---Select---" ControlToValidate="Dropclass">*</asp:comparevalidator><asp:textbox id="txtid" Runat="server" Height="16px" Visible="False" Width="40px"></asp:textbox></TD>
									<td>&nbsp;Stream
									</td>
									<td><asp:dropdownlist id="dropStream" Runat="server" CssClass="ComboBox" Width="100px">
											<asp:ListItem Value="None">None</asp:ListItem>
											<asp:ListItem Value="Bio Group">Bio Group</asp:ListItem>
											<asp:ListItem Value="Commerce Group">Commerce Group</asp:ListItem>
											<asp:ListItem Value="Math Group">Math Group</asp:ListItem>
										</asp:dropdownlist></td>
								</TR>
								<TR>
									<TD>&nbsp;Student&nbsp;Name&nbsp;<FONT color="#ff0033" size="1">*</FONT>
									</TD>
									<TD><asp:textbox onkeypress="return GetOnlyChars(this, event);" id="txtFirstName" BorderStyle="Groove"
											Runat="server" CssClass="TextBoxForms" MaxLength="30"></asp:textbox><asp:regularexpressionvalidator id="revFirstName" runat="server" ErrorMessage="You must enter the first name in alphabetic format"
											ControlToValidate="txtFirstName" ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$">*</asp:regularexpressionvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="You must enter  Student name"
											ControlToValidate="txtFirstName">*</asp:requiredfieldvalidator></TD>
									<td>&nbsp;Father's Name&nbsp; <FONT color="#ff0033" size="1">*</FONT></td>
									<td><asp:textbox onkeypress="return GetOnlyChars(this, event);" id="TxtFathernm" BorderStyle="Groove"
											Runat="server" CssClass="TextBoxForms" MaxLength="30"></asp:textbox><asp:regularexpressionvalidator id="revFatherName" runat="server" ErrorMessage="You must enter in alphabetic format"
											ControlToValidate="TxtFathernm" ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$">*</asp:regularexpressionvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="You must enter  father name"
											ControlToValidate="TxtFathernm">*</asp:requiredfieldvalidator></td>
								</TR>
								<tr>
									<TD>&nbsp;Mother's Name
									</TD>
									<TD><asp:textbox onkeypress="return GetOnlyChars(this, event);" id="TxtMothernm" BorderStyle="Groove"
											Runat="server" CssClass="TextBoxForms" MaxLength="30"></asp:textbox><asp:regularexpressionvalidator id="revMotherName" runat="server" ErrorMessage="You must enter in alphabetic format"
											ControlToValidate="TxtMothernm" ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$">*</asp:regularexpressionvalidator></TD>
									<td>&nbsp;Date Of Birth&nbsp;<FONT color="#ff0033" size="1">*</FONT>
									</td>
									<td><asp:textbox id="txtDob" ReadOnly="True" Runat="server" CssClass="Fontstyle" Width="70px" BorderStyle="Groove"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtDob);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
												border="0"></A>
									</td>
								</tr>
								<TR>
									<TD>&nbsp;Category</TD>
									<TD><asp:dropdownlist id="DropCategory" Runat="server" CssClass="ComboBox" Width="100px">
											<asp:ListItem Value="General">General</asp:ListItem>
											<asp:ListItem Value="OBC">OBC</asp:ListItem>
											<asp:ListItem Value="SC">SC</asp:ListItem>
											<asp:ListItem Value="ST">ST</asp:ListItem>
											<asp:ListItem Value="Other">Other</asp:ListItem>
										</asp:dropdownlist></TD>
									<TD>&nbsp;Gender</TD>
									<TD><asp:dropdownlist id="DropGender" Runat="server" CssClass="ComboBox" Width="100px">
											<asp:ListItem Value="Male">Male</asp:ListItem>
											<asp:ListItem Value="Female">Female</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD>&nbsp;Address&nbsp;<FONT color="#ff0033" size="1">*</FONT></TD>
									<TD><asp:textbox id="TextPerAdd" Runat="server" CssClass="TextBoxForms" Width="160px" MaxLength="30"></asp:textbox>&nbsp;<asp:requiredfieldvalidator id="rfvPAddress" runat="server" ErrorMessage="You Must Enter Address" ControlToValidate="TextPerAdd">*</asp:requiredfieldvalidator></TD>
									<TD>&nbsp;City</TD>
									<TD><asp:dropdownlist id="DropCity1" runat="server" CssClass="ComboBox" Width="100px" Onchange="getBeatInfo(this,document.Form1.dropState,document.Form1.dropCountry);">
											<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD>&nbsp;State</TD>
									<TD><asp:dropdownlist id="dropState" Runat="server" CssClass="ComboBox" Width="100"></asp:dropdownlist></TD>
									<TD>&nbsp;Country</TD>
									<TD><asp:dropdownlist id="dropCountry" Runat="server" CssClass="ComboBox" Width="100"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD>&nbsp;Test Date</TD>
									<TD><asp:textbox id="txtDate" ReadOnly="True" Runat="server" CssClass="Fontstyle" Width="70px" BorderStyle="Groove"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtDate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
												border="0"></A></TD>
									<TD>&nbsp;Test Time&nbsp;<FONT color="#ff0033" size="1">*</FONT></TD>
									<TD><asp:dropdownlist id="Droptimehour" Runat="server" CssClass="ComboBox">
											<asp:ListItem Value="0">0</asp:ListItem>
											<asp:ListItem Value="1">1</asp:ListItem>
											<asp:ListItem Value="2">2</asp:ListItem>
											<asp:ListItem Value="3">3</asp:ListItem>
											<asp:ListItem Value="4">4</asp:ListItem>
											<asp:ListItem Value="5">5</asp:ListItem>
											<asp:ListItem Value="6">6</asp:ListItem>
											<asp:ListItem Value="7">7</asp:ListItem>
											<asp:ListItem Value="8">8</asp:ListItem>
											<asp:ListItem Value="9">9</asp:ListItem>
											<asp:ListItem Value="10">10</asp:ListItem>
											<asp:ListItem Value="11">11</asp:ListItem>
											<asp:ListItem Value="12">12</asp:ListItem>
										</asp:dropdownlist><asp:dropdownlist id="droptimeminit" Runat="server" CssClass="ComboBox">
											<asp:ListItem Value="0">0</asp:ListItem>
											<asp:ListItem Value="10">10</asp:ListItem>
											<asp:ListItem Value="15">15</asp:ListItem>
											<asp:ListItem Value="20">20</asp:ListItem>
											<asp:ListItem Value="30">30</asp:ListItem>
											<asp:ListItem Value="40">40</asp:ListItem>
											<asp:ListItem Value="45">45</asp:ListItem>
											<asp:ListItem Value="50">50</asp:ListItem>
										</asp:dropdownlist><asp:dropdownlist id="Dropam" Runat="server" CssClass="ComboBox">
											<asp:ListItem Value="AM">AM</asp:ListItem>
											<asp:ListItem Value="PM">PM</asp:ListItem>
										</asp:dropdownlist><asp:comparevalidator id="CompareValidator2" runat="server" Operator="NotEqual" ErrorMessage="Please Select The Test Time"
											ValueToCompare="0" ControlToValidate="Droptimehour">*</asp:comparevalidator></TD>
								</TR>
								<TR>
									<TD>&nbsp;Regis. Fee&nbsp;<FONT color="#ff0033" size="1">*</FONT></TD>
									<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtRegFee" BorderStyle="Groove"
											Runat="server" CssClass="TextBoxForms" MaxLength="4"></asp:textbox>&nbsp;<asp:requiredfieldvalidator id="Requiredfieldvalidator4" runat="server" ErrorMessage="Please Enter The Registration Fee"
											ControlToValidate="txtRegFee">*</asp:requiredfieldvalidator></TD>
									<TD>&nbsp;Phone Number</TD>
									<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, true,false);" id="TxtPhNo" BorderStyle="Groove"
											Runat="server" CssClass="TextBoxForms" MaxLength="12"></asp:textbox>&nbsp;<asp:regularexpressionvalidator id="RegularValidator2" runat="server" ErrorMessage="Contact No. Between 6-10 Digits"
											ControlToValidate="TxtPhNo" ValidationExpression="\d{6,12}">*</asp:regularexpressionvalidator></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="4">
										<asp:button id="btnsaveonly" Runat="server" CssClass="FormButtonStyle" Text="Save"></asp:button>&nbsp;&nbsp;
										<asp:button id="btnSave" runat="server" CssClass="FormButtonStyle" Text="Print" Width="80px"></asp:button>&nbsp;&nbsp;
										<asp:button id="BtnReset" Runat="server" CssClass="FormButtonStyle" Text="Reset" CausesValidation="False"></asp:button>&nbsp;
										<asp:button id="btnprint" BorderStyle="Groove" Runat="server" CssClass="FormButtonStyle" Text="Print"
											CausesValidation="False"></asp:button><asp:validationsummary id="vsRegistration" runat="server" Width="100%" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD>
								</TR>
							</TBODY>
						</table>
					</td>
				</tr>
			</table>
			<!--PopCalendar(tag name and id must match) Tags should sit at the page bottom --><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189">
			</iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></FORM>
	</BODY>
</HTML>
