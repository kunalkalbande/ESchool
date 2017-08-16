<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="Dinner.aspx.cs" AutoEventWireup="false" Inherits="eschool.Hostel.Dinner" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Menu Creation</title> <!--
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
		<LINK href=../../HeaderFooter/shareables/Style/Styles.css type="text/css" rel="stylesheet">
		<script language=javascript id=validation src=../../HeaderFooter/shareables/jsfiles/Validations.js></script>
	</HEAD>
	<body>
		<form id="Dinner" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td colspan="3"></td>
				</tr>
				<tr>
					</TD>
					<td valign="top" align="center"><asp:label id="Label3" runat="server" Font-Bold="True">MENU CREATION</asp:label>
						<TABLE id="Table1" width="60%" cellSpacing="1" cellPadding="1" border="5" borderColorLight="#663300">
							<TR>
								<TD colspan="4">
									<asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label></TD>
							</TR>
							<TR>
								<TD>&nbsp;Time&nbsp;<font color=red size=1>*</font></TD>
								<TD>
									<asp:dropdownlist CssClass="ComboBox" id="Droptime" Width=130px runat="server" AutoPostBack="True">
										<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
										<asp:ListItem Value="Break Fast">Break Fast</asp:ListItem>
										<asp:ListItem Value="Lunch">Lunch</asp:ListItem>
										<asp:ListItem Value="Dinner">Dinner</asp:ListItem>
									</asp:dropdownlist>
									<asp:CompareValidator id="cvTime" runat="server" ControlToValidate="Droptime" ErrorMessage="Please select the time"
										ValueToCompare="---Select---" Operator="NotEqual">*</asp:CompareValidator></TD>
								<TD >&nbsp;Day&nbsp;<font color=red size=1>*</font></TD>
								<TD >
									<asp:DropDownList CssClass="ComboBox" Width=130px id="Dropblday" runat="server" AutoPostBack="True">
										<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
										<asp:ListItem Value="Monday">Monday</asp:ListItem>
										<asp:ListItem Value="Tuesday">Tuesday</asp:ListItem>
										<asp:ListItem Value="Wednesday">Wednesday</asp:ListItem>
										<asp:ListItem Value="Thursday">Thursday</asp:ListItem>
										<asp:ListItem Value="Friday">Friday</asp:ListItem>
										<asp:ListItem Value="Saturday">Saturday</asp:ListItem>
										<asp:ListItem Value="Sunday">Sunday</asp:ListItem>
									</asp:DropDownList>
									<asp:CompareValidator id="cvDay" runat="server" ControlToValidate="Dropblday" ErrorMessage="Please select the day"
										ValueToCompare="---Select---" Operator="NotEqual">*</asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD>&nbsp;Dishes1&nbsp;<FONT color="#ff0033" size=1>*</FONT></TD>
								<TD>
									<asp:TextBox CssClass="TextBoxforms" id="txtdes1" onkeypress="return GetOnlyChars(this, event);" MaxLength=25 runat="server"></asp:TextBox>
									
									<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="You Must Enter Dishes1"
										ControlToValidate="txtdes1">*</asp:RequiredFieldValidator></TD>
								<TD>&nbsp;Dishes2&nbsp;<FONT color="#ff0033" size=1>*</FONT></TD>
								<TD>
									<asp:TextBox CssClass="TextBoxforms" id="txtdes2" onkeypress="return GetOnlyChars(this, event);" MaxLength=25 runat="server"></asp:TextBox>
									
									<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="You Must Enter  Dishes2"
										ControlToValidate="txtdes2">*</asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD>&nbsp;Dishes3&nbsp;<FONT color="#ff0033" size=1>*</FONT></TD>
								<TD>
									<asp:TextBox CssClass="TextBoxforms" id="txtdes3" onkeypress="return GetOnlyChars(this, event);" MaxLength=25 runat="server"></asp:TextBox>
									
									<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="You Must Enter  Dishes3"
										ControlToValidate="txtdes3">*</asp:RequiredFieldValidator></TD>
								<TD>&nbsp;Dishes4</TD>
								<TD>
									<asp:TextBox CssClass="TextBoxforms" id="txtdes4" onkeypress="return GetOnlyChars(this, event);" MaxLength=25 runat="server"></asp:TextBox>
									<asp:RegularExpressionValidator id="revDish4" runat="server" ControlToValidate="txtdes4" ErrorMessage="Dish4 must be alphabetic"
										ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$">*</asp:RegularExpressionValidator></TD>
							</TR>
							<TR>
								<TD>&nbsp;Dishes5</TD>
								<TD>
									<asp:TextBox CssClass="TextBoxforms" id="txtdes5" onkeypress="return GetOnlyChars(this, event);" MaxLength=25 runat="server"></asp:TextBox>
									<asp:RegularExpressionValidator id="revDish5" runat="server" ControlToValidate="txtdes5" ErrorMessage="Dish5 must be alphabetic"
										ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$">*</asp:RegularExpressionValidator></TD>
								<TD>&nbsp;Dishes6</TD>
								<TD>
									<asp:TextBox CssClass="TextBoxforms" id="txtdes6" onkeypress="return GetOnlyChars(this, event);" MaxLength=25 runat="server"></asp:TextBox>
									<asp:RegularExpressionValidator id="revDish6" runat="server" ControlToValidate="txtdes6" ErrorMessage="Dish6 must be alphabetic"
										ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$">*</asp:RegularExpressionValidator></TD>
							</TR>
							<TR>
								<TD>&nbsp;Dishes7</TD>
								<TD>
									<asp:TextBox CssClass="TextBoxforms" id="txtdes7" onkeypress="return GetOnlyChars(this, event);" MaxLength=25 runat="server"></asp:TextBox>
									<asp:RegularExpressionValidator id="revDish7" runat="server" ControlToValidate="txtdes7" ErrorMessage="Dish7 must be alphabetic"
										ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$">*</asp:RegularExpressionValidator></TD>
								<TD>&nbsp;Dishes8</TD>
								<TD>
									<asp:TextBox CssClass="TextBoxforms" id="txtdes8" onkeypress="return GetOnlyChars(this, event);" MaxLength=25 runat="server"></asp:TextBox>
									<asp:RegularExpressionValidator id="revDish8" runat="server" ControlToValidate="txtdes8" ErrorMessage="Dish8 must be alphabetic"
										ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$">*</asp:RegularExpressionValidator></TD>
							</TR>
							<TR>
								<TD colspan="4" align="center">
									<asp:Button id="btnSave" runat="server" Text="Save" CssClass="FormButtonStyle"></asp:Button>&nbsp;
									<asp:Button ID="BtnReset" Runat="server" Text="Reset" CausesValidation="False" CssClass="FormButtonStyle"></asp:Button>
									<asp:ValidationSummary id="vsMenu" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>
								</TD>
							</TR>
							
						</TABLE>
					</td>
				</tr>
			</table>
			<uc1:Footer id="Footer1" runat="server"></uc1:Footer>
		</form>
	</body>
</HTML>
