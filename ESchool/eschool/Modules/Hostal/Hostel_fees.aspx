<%@ Page language="c#" Codebehind="Hostel_fees.aspx.cs" AutoEventWireup="false" Inherits="eschool.Hostel.Hostel_fees" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>eSchool : Hostel Fees</title><!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<script language="javascript" id="Validations" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href=../../HeaderFooter/shareables/Style/Styles.css type="text/css" rel="stylesheet">
  </HEAD>
	<body>
		<form id="Hostel_fees" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				
				<tr>
					<td valign="top" align="center"><asp:label id="Label3" runat="server" Font-Bold="True">HOSTEL FEES</asp:label>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="60%" border="5" borderColorLight="#663300">
							<TR>
								<TD colspan="4">
									<asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label></TD>
							</TR>
							<TR>
								<TD>&nbsp;Class Name<FONT color="#ff0033" size=1>*</FONT></TD>
								<TD>
									<asp:dropdownlist CssClass="ComboBox" id="Dropclass" Runat="server" AutoPostBack="True">
										<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
									</asp:dropdownlist>
									<asp:CompareValidator id="cvClass" runat="server" ControlToValidate="Dropclass" ErrorMessage="Please select the class name"
										Operator="NotEqual" ValueToCompare="---Select---">*</asp:CompareValidator></TD>
								<TD vAlign="middle">&nbsp;Hostel Fees&nbsp;<FONT color="#ff0033" size=1>*</FONT></TD>
								<TD>
									<asp:TextBox CssClass="TextBoxforms" id="txtfees" runat="server" MaxLength=6 onkeypress="return GetOnlyNumbers(this, event, false,false);"></asp:TextBox>
									<asp:requiredfieldvalidator id="Requiredfieldvalidator1" Runat="server" Display="Dynamic" ErrorMessage="You Must Enter Hostel Fees"
										ControlToValidate="txtfees">*</asp:requiredfieldvalidator>
									<asp:comparevalidator id="Comparevalidator1" Runat="server" Display="Dynamic" ErrorMessage="Enter in Numeric Format"
										ControlToValidate="txtfees" Type="Integer" Operator="DataTypeCheck">*</asp:comparevalidator>
								</TD>
							</TR>
							<TR>
								<TD align="center" colSpan="4">
									<asp:Button id="btnSave" runat="server" Text="Save" CssClass="FormButtonStyle"></asp:Button>&nbsp;
									<asp:Button ID="BtnReset" Runat="server" Text="Reset" CausesValidation="False" CssClass="FormButtonStyle"></asp:Button>
									<asp:ValidationSummary id="vsFees" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>
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
