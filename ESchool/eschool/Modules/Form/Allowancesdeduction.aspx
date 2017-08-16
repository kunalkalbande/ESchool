<%@ Page language="c#" Codebehind="Allowancesdeduction.aspx.cs" AutoEventWireup="false" Inherits="eschool.Form.Allowancesdeduction" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Employee Salary</title> 
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
		<script language="javascript" id="Validations" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY>
		<form id="Allowancesdeduction" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td vAlign="top" align="center"><asp:label id="Label2" runat="server">
							<b>EMPLOYEE SALARY</b></asp:label>
						<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="80%" align="center" borderColorLight="#663300"
							border="5">
							<TR>
								<TD colSpan="4"><asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label></TD>
							</TR>
							<asp:panel id="Panaledit" Runat="server" Visible="False">
								<TR>
									<TD>&nbsp;Salary ID</TD>
									<TD colSpan="3">
										<asp:DropDownList id="DropEdit" Runat="server" CssClass="ComboBox" AutoPostBack="True"></asp:DropDownList></TD>
								</TR>
							</asp:panel>
							<TR>
								<TD>&nbsp;Emp. Name &nbsp;&amp; ID&nbsp; <font color="#ff0033" size="1">*</font></TD>
								<TD><asp:dropdownlist id="Dropdownlist1" runat="server" CssClass="ComboBox" AutoPostBack="False">
										<asp:ListItem Value="---Select---"></asp:ListItem>
									</asp:dropdownlist>&nbsp;<asp:comparevalidator id="comvalid1" Runat="server" ValueToCompare="---Select---" ControlToValidate="Dropdownlist1"
										Operator="NotEqual" ErrorMessage="Please Select Employee Name">*</asp:comparevalidator></TD>
								<TD align="left">&nbsp;Basic Salary&nbsp; <FONT color="#ff0033" size="1">*</FONT>
								</TD>
								<td><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,false);" id="txtSalary" BorderStyle="Groove"
										runat="server" CssClass="TextBoxForms" MaxLength="6"></asp:textbox>&nbsp;<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" ControlToValidate="txtSalary" ErrorMessage="You must enter Basic Salary">*</asp:requiredfieldvalidator></td>
							</TR>
							<tr>
								<td>&nbsp;Date From</td>
								<td><asp:textbox id="TxtDtFrom" BorderStyle="Groove" runat="server" CssClass="Fontstyle" ReadOnly="True"
										Width="70px"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Allowancesdeduction.TxtDtFrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A>
								</td>
								<td>&nbsp;Date To</td>
								<td><asp:textbox id="TxtDtTo" BorderStyle="Groove" runat="server" CssClass="Fontstyle" ReadOnly="True"
										Width="70px"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Allowancesdeduction.TxtDtTo);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A>
								</td>
							</tr>
							<TR>
								<TD align="center" colSpan="2"><STRONG><EM><FONT size="1">Allowances</FONT></EM></STRONG></TD>
								<TD align="center" colSpan="2"><STRONG><EM><FONT size="1">Deduction</FONT></EM></STRONG></TD>
							</TR>
							<TR>
								<TD>&nbsp;H.R.A</TD>
								<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txthra" BorderStyle="Groove"
										runat="server" CssClass="TextBoxForms" MaxLength="4"></asp:textbox>(Rs.)</TD>
								<TD>&nbsp;E.P.F.&nbsp;</TD>
								<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtpf" BorderStyle="Groove"
										runat="server" CssClass="TextBoxForms" MaxLength="3"></asp:textbox>(%)</TD>
							</TR>
							<TR>
								<TD>&nbsp;T.A.</TD>
								<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtta" BorderStyle="Groove"
										runat="server" CssClass="TextBoxForms" MaxLength="4"></asp:textbox>(Rs.)</TD>
								<TD>&nbsp;Professional Tax</TD>
								<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txttax" BorderStyle="Groove"
										runat="server" CssClass="TextBoxForms" MaxLength="4"></asp:textbox>(Rs.)</TD>
							</TR>
							<TR>
								<TD>&nbsp;D.A.</TD>
								<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtda" BorderStyle="Groove"
										runat="server" CssClass="TextBoxForms" MaxLength="3"></asp:textbox>(%)</TD>
								<TD>&nbsp;Loan</TD>
								<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtothertax" BorderStyle="Groove"
										runat="server" CssClass="TextBoxForms" MaxLength="4"></asp:textbox>(Rs.)</TD>
							</TR>
							<TR>
								<TD>&nbsp;CCA</TD>
								<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtcca" BorderStyle="Groove"
										runat="server" CssClass="TextBoxForms" MaxLength="4"></asp:textbox>(Rs.)</TD>
								<td>&nbsp;Penel Deduction</td>
								<td><asp:textbox id="txtpenDeduction" BorderStyle="Groove" Runat="server" CssClass="TextBoxForms"
										MaxLength="4"></asp:textbox>(Rs.)</td>
							</TR>
							<TR>
								<TD vAlign="top">&nbsp;Special Allowance</TD>
								<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtMedical" BorderStyle="Groove"
										runat="server" CssClass="TextBoxForms" MaxLength="4"></asp:textbox>(Rs.)</TD>
								<td>&nbsp;Security</td>
								<td><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtsec" BorderStyle="Groove"
										Runat="server" CssClass="TextBoxForms" MaxLength="4"></asp:textbox>(Rs.)</td>
							</TR>
							<tr>
								<td>&nbsp;Arrears</td>
								<td><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtArrears" BorderStyle="Groove"
										Runat="server" CssClass="TextBoxForms" MaxLength="4"></asp:textbox></td>
								<TD>&nbsp;Benefits</TD>
								<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtbenefits" BorderStyle="Groove"
										runat="server" CssClass="TextBoxForms" MaxLength="4"></asp:textbox>(Rs.)</TD>
							</tr>
							<TR>
								<TD>&nbsp;Increments</TD>
								<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtincrement" BorderStyle="Groove"
										runat="server" CssClass="TextBoxForms" MaxLength="4"></asp:textbox>(Rs.)</TD>
								<td colSpan="2">&nbsp;</td>
							</TR>
							<TR>
								<TD align="center" colSpan="4"><asp:button id="btnSave" runat="server" CssClass="formbuttonstyle" Text="Save"></asp:button>&nbsp;<asp:button id="btnUpdate" runat="server" Visible="False" CssClass="formbuttonstyle" Text="Update"></asp:button>
									&nbsp;<asp:button id="ButtnEdit" Runat="server" CssClass="formbuttonstyle" Text="Edit" CausesValidation="False"
										Width="72px"></asp:button>
									&nbsp;<asp:button id="BtnReset" Runat="server" CssClass="formbuttonstyle" Text="Reset" CausesValidation="False"></asp:button>
									<asp:validationsummary id="vsEmpAllowancesDeduction" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
		</form>
		<!--PopCalendar(tag name and id must match) Tags should sit at the page bottom --><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
			name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189">
		</iframe>
		<uc1:footer id="Footer1" runat="server"></uc1:footer>
	</BODY>
</HTML>
