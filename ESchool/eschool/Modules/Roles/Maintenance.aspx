<%@ Page language="c#" Codebehind="Maintenance.aspx.cs" AutoEventWireup="false" Inherits="eschool.Roles.BeatMaster_Entry" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : City Master</title><!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" id="Validations" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
		<script language="javascript">
		// this method not in use.
		function Show(t1,t2)
		{
			var index=t1.selectedIndex
			var valdrop=t1.options[index].value
			if(valdrop=="Others...")
			{
				t2.style.visibility="visible"
			}
			else
			{
				t2.style.visibility="hidden"
			}
		}
		</script>
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td align="center"><b>CITY MASTER</b>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="52%" borderColorLight="#663300"
							border="5">
							<TR>
								<TD colSpan="2"><FONT color="#ff0000">Fields Marked as (*) Are Mandatory</FONT></TD>
							</TR>
							<TR>
								<TD>&nbsp;City&nbsp;ID.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD><asp:dropdownlist id="DropBeatNo" runat="server" Visible="False" AutoPostBack="True" CssClass="ComboBox" Width="60px"></asp:dropdownlist><asp:label id="lblBeatNo" runat="server" ForeColor="Blue"></asp:label>
									</TD>
							</TR>
							<TR>
								<TD>&nbsp;City&nbsp; <FONT color="#ff0000" size="1">*</FONT></TD>
								<TD><asp:textbox onkeypress="return GetOnlyChars(this, event);" id="txtCity" BorderStyle="Groove"
										runat="server" CssClass="TextBoxForms" MaxLength="25" Width="160px"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Please Fill City" ControlToValidate="txtCity">*</asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD>&nbsp;State&nbsp;</TD>
								<TD><asp:dropdownlist id="DropState" runat="server" CssClass="ComboBox" Width="160px" onchange="Show(this,document.Form1.txtState)"></asp:dropdownlist>&nbsp;<input class="TextBoxForms" onkeypress="return GetOnlyChars(this, event);" id="txtState"
										style="VISIBILITY: hidden; WIDTH: 160px" type="text" maxLength="25" name="txtState"></TD>
							</TR>
							<TR>
								<TD>&nbsp;Country&nbsp;</TD>
								<TD><asp:dropdownlist id="DropCountry" runat="server" CssClass="ComboBox" Width="160px" onchange="Show(this,document.Form1.txtCountry)"></asp:dropdownlist>&nbsp;<input class="TextBoxForms" onkeypress="return GetOnlyChars(this, event);" id="txtCountry"
										style="VISIBILITY: hidden; WIDTH: 160px" type="text" maxLength="25" name="txtCountry"></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="2"><asp:button id="btnSave" runat="server" CssClass="formbuttonstyle" Text="Add"></asp:button>&nbsp;<asp:button id="btnEdit" runat="server" CssClass="formbuttonstyle" Text="Edit" CausesValidation="False"></asp:button>
									&nbsp;<asp:button id="Edit1" runat="server" CssClass="formbuttonstyle" Text="Update"></asp:button>
									&nbsp;<asp:button id="btnDelete" runat="server" CssClass="formbuttonstyle" Text="Delete" CausesValidation="False"></asp:button>
								</TD>
							</TR>
						</TABLE>
						<asp:validationsummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
