<%@ Page language="c#" Codebehind="Supplier_Entry.aspx.cs" AutoEventWireup="false" Inherits="eschool.Modules.Form.Supplier_Entry" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Vendor Entry</title> <!--
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
		<script language="javascript" id="Validations" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
		<script language="javascript" id="Beat1" src="../../HeaderFooter/shareables/jsfiles/Country.js"></script>
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><asp:textbox id="txtName" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" Runat="server"
				Height="1" Width="1"></asp:textbox><asp:textbox id="TextBox1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" runat="server"
				Width="1px" Visible="False"></asp:textbox><asp:TextBox id="TempVenderName" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px"
				runat="server" Width="1px" Visible="False"></asp:TextBox>
			<table height="250" width="778" align="center">
				<TR>
					<td align="center"><b>VENDOR&nbsp;ENTRY</b>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" borderColorLight="#663300" border="5">
							<TBODY>
								<tr>
									<td colspan="4"><asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label></td>
								</tr>
								<TR>
									<TD>&nbsp;Vendor ID</TD>
									<TD colSpan="3"><asp:dropdownlist AutoPostBack="True" CssClass="ComboBox" id="DropID" Runat="server" Visible="False">
											<asp:ListItem Value="Select">Select</asp:ListItem>
										</asp:dropdownlist>&nbsp;<asp:label id="lblSupplierID" Runat="server" ForeColor="Blue"></asp:label>&nbsp;
										<asp:button id="btnedit" Runat="server" Width="20px" CssClass="FormButtonStyle" Text="..." CausesValidation="False"></asp:button>
										&nbsp;</TD>
								</TR>
								<TR>
									<TD>&nbsp;Name&nbsp;<FONT color="#ff0000" size="1">*</FONT></TD>
									<TD colspan="3"><asp:textbox id="txtFName" BorderStyle="Groove" runat="server" Width="268px" MaxLength="40" CssClass="TextBoxForms"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtFName" ErrorMessage="Please Fill Vendor Name">*</asp:requiredfieldvalidator></TD>
								</TR>
								<TR>
									<TD>&nbsp;City&nbsp;&nbsp;<FONT color="#ff0000" size="1">*</FONT></TD>
									<TD><asp:dropdownlist id="DropCity" CssClass="ComboBox" runat="server" Width="130px" AutoPostBack="false"
											Onchange="getBeatInfo(this,document.Form1.DropState,document.Form1.DropCountry);">
											<asp:ListItem Value="Select">Select</asp:ListItem>
										</asp:dropdownlist><asp:comparevalidator id="CompareValidator1" runat="server" ControlToValidate="DropCity" ErrorMessage="Please Select City Name"
											ValueToCompare="Select" Operator="NotEqual">*</asp:comparevalidator></TD>
									<TD>&nbsp;Phone (Off.)</TD>
									<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event);" id="txtPhoneOff" BorderStyle="Groove"
											runat="server" Width="130px" MaxLength="12" CssClass="TextBoxForms"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator6" runat="server" ControlToValidate="txtPhoneOff"
											ErrorMessage="Contact No. Between 6-10 Digits" ValidationExpression="\d{6,12}">*</asp:regularexpressionvalidator></TD>
								</TR>
								<TR>
									<TD>&nbsp;District&nbsp;</TD>
									<TD><asp:dropdownlist id="DropState" runat="server" Width="130px" CssClass="ComboBox">
											<asp:ListItem Value="Select">Select</asp:ListItem>
										</asp:dropdownlist></TD>
									<TD>&nbsp;Op. Balance&nbsp;</TD>
									<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event,false,true);" id="txtOpBalance" BorderStyle="Groove"
											runat="server" Width="130px" MaxLength="8" CssClass="TextBoxForms"></asp:textbox>&nbsp;
										<asp:dropdownlist id="DropBal" Runat="server" CssClass="ComboBox">
											<asp:ListItem Value="Cr.">Cr.</asp:ListItem>
											<asp:ListItem Value="Dr.">Dr.</asp:ListItem>
										</asp:dropdownlist><asp:regularexpressionvalidator id="RegularExpressionValidator5" runat="server" ControlToValidate="txtOpBalance"
											ErrorMessage="Opening Balance Should be Correct" ValidationExpression="(\d+\.\d+)|(\d+)">*</asp:regularexpressionvalidator></TD>
								</TR>
								<TR>
									<TD>&nbsp;State</TD>
									<TD><asp:dropdownlist id="DropCountry" runat="server" Width="130px" CssClass="ComboBox">
											<asp:ListItem Value="Select">Select</asp:ListItem>
										</asp:dropdownlist></TD>
									<TD>&nbsp;Mobile</TD>
									<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event);" id="txtMobile" BorderStyle="Groove"
											runat="server" Width="130px" MaxLength="12" CssClass="TextBoxForms"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator8" runat="server" ControlToValidate="txtMobile" ErrorMessage="Mobile No. Between 10-12 Digits"
											ValidationExpression="\d{10,12}">*</asp:regularexpressionvalidator></TD>
								</TR>
								<TR>
									<TD>&nbsp;Address</TD>
									<TD colSpan="3"><asp:textbox id="txtAddress" BorderStyle="Groove" runat="server" Width="100%" MaxLength="99"
											CssClass="TextBoxForms" Font-Names="Verdana"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;E-Mail</TD>
									<TD colSpan="3"><asp:textbox id="txtEMail" BorderStyle="Groove" runat="server" Width="268px" MaxLength="49" CssClass="TextBoxForms"></asp:textbox>&nbsp;<asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ControlToValidate="txtEMail" ErrorMessage="Please Fill Valid E-mail"
											ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:regularexpressionvalidator></TD>
								</TR>
								<tr align="center">
									<TD align="center" colSpan="4">
										<asp:button id="btnUpdate" runat="server" Width="90px" CssClass="FormButtonStyle" Text="Save"></asp:button>&nbsp;
										<asp:Button ID="btndelete" Runat="server" Visible="False" Width="90" CssClass="Formbuttonstyle"
											Text="Delete"></asp:Button></TD>
					</td>
				</TR>
			</table>
			<asp:validationsummary id="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD></TR></TBODY></TABLE>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
