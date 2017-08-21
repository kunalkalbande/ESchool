<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="Labmast.aspx.cs" AutoEventWireup="false" Inherits="eschool.Lab.Labmast" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>eSchool : Lab Master</TITLE> 
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
		<script language="javascript" id="validation1" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
	</HEAD>
	<body>
		<form id="Labmast" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table id="Table3" height="250" width="778" align="center">
				<tr>
					</TD>
					<td vAlign="top" align="center"><asp:label id="Label3" runat="server" Font-Bold="True">LAB MASTER</asp:label>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="40%" borderColorLight="#663300"
							border="5">
							<TR>
								<TD colSpan="2"><asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label></TD>
							</TR>
							<TR>
								<TD>&nbsp;Lab ID</TD>
								<TD><asp:dropdownlist id="DropEdit" CssClass="ComboBox" runat="server" AutoPostBack="True" Width="124px"></asp:dropdownlist>&nbsp;<asp:label id="Labid" ForeColor="blue" runat="server" Width="56px"></asp:label></TD>
							</TR>
							<TR>
								<TD>&nbsp;Lab Name&nbsp;<FONT color="#ff0033" size="1">*</FONT></TD>
								<TD><asp:textbox id="txtlabtype" CssClass="TextBoxForms" onkeypress="return GetOnlyChars(this, event);"
										MaxLength="20" runat="server"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtlabtype" ErrorMessage="You Must Enter Lab Name">*</asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD>&nbsp;Lab No&nbsp;<FONT color="#ff0033" size="1">*</FONT></TD>
								<TD><asp:textbox id="txtlabhallno" CssClass="TextBoxForms" onkeypress="return GetOnlyNumbers(this, event, false,false);"
										MaxLength="6" runat="server"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" ControlToValidate="txtlabhallno" ErrorMessage="You Must Enter Lab No.">*</asp:requiredfieldvalidator><asp:comparevalidator id="cmppin" ControlToValidate="txtlabhallno" ErrorMessage="Lab No must be Numeric"
										Operator="DataTypeCheck" Type="Integer" Display="Dynamic" Runat="server">*</asp:comparevalidator></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="4">
									&nbsp;<asp:button id="btnSave" runat="server" Text="Save" CssClass="formbuttonstyle"></asp:button>
									&nbsp;<asp:button id="btnedit" runat="server" Text="Edit" CausesValidation="False" CssClass="formbuttonstyle"></asp:button>
									&nbsp;<asp:button id="btneditsave" runat="server" Text="Update" CssClass="formbuttonstyle"></asp:button>
									&nbsp;<asp:button id="btndelete" runat="server" Text="Delete" CssClass="formbuttonstyle"></asp:button>
									<asp:validationsummary id="vsLabMaster" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
