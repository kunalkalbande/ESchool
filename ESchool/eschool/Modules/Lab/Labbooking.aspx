<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="Labbooking.aspx.cs" AutoEventWireup="false" Inherits="eschool.Lab.Labbooking" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Lab Booking</title><!--
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
	</HEAD>
	<body>
		<form id="Labbooking" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td vAlign="top" align="center">
					<asp:label id="Label3" runat="server" Font-Bold="True">LAB BOOKING</asp:label>
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" borderColorLight="#663300" border="5">
							<TR>
								<TD colSpan="4"><asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label></TD>
							</TR>
							<TR>
								<TD>
									<asp:label id="lid" runat="server">&nbsp;LabBookID</asp:label>&nbsp;</TD>
								<td colSpan="6"><asp:dropdownlist CssClass="ComboBox" id="DropEdit" runat="server" AutoPostBack="True" Height="15px" Width="80px">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist>&nbsp;<asp:label id="lbid" ForeColor=blue runat="server"></asp:label>
								</td>
							</TR>
							<TR>
								<TD>&nbsp;Lab ID&nbsp;<FONT color="#ff0033" size="1">*</FONT></TD>
								<TD><asp:dropdownlist CssClass="ComboBox" id="Droplabid" runat="server" AutoPostBack="True">
										<asp:ListItem Value="---Select---"></asp:ListItem>
									</asp:dropdownlist><asp:comparevalidator id="cvLab" runat="server" ValueToCompare="---Select---" Operator="NotEqual" ErrorMessage="Please Select the Lab  Id"
										ControlToValidate="Droplabid">*</asp:comparevalidator>&nbsp;
									<asp:textbox CssClass="TextBoxForms" id="TextBox1" runat="server" Width="138px"></asp:textbox></TD>
								<TD>&nbsp;Class&nbsp;<FONT color="#ff0033" size="1">*</FONT></TD>
								<TD><asp:dropdownlist CssClass="ComboBox" id="Dropclass" runat="server" AutoPostBack="True">
										<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
									</asp:dropdownlist><asp:comparevalidator id="CvStuId" runat="server" ValueToCompare="---Select---" Operator="NotEqual" ErrorMessage="Please Select the Student class"
										ControlToValidate="Dropclass">*</asp:comparevalidator></TD>
							</tr>
							<TR>
								<TD>&nbsp;Date</TD>
								<TD><asp:textbox id="Textday1" CssClass="Fontstyle"  Width=70px BorderStyle=Groove runat="server"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Labbooking.Textday1);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A>
								</TD>
								<TD>&nbsp;Time &nbsp;<FONT color="#ff0033" size="1">*</FONT> (hh:mm)</TD>
								<TD><asp:textbox CssClass="TextBoxForms" id="txtdate" runat="server" name="t1" MaxLength="5"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="You Must Enter Time" ControlToValidate="txtdate">*</asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="4"><asp:button id="btnSave" runat="server" CssClass="formbuttonstyle" Text="Save"></asp:button>
								&nbsp;<asp:button id="btnedit" runat="server" CssClass="formbuttonstyle" Text="Edit" CausesValidation="False"></asp:button>
								&nbsp;<asp:button id="btneditsave" runat="server" CssClass="formbuttonstyle" Text="Update"></asp:button>
								&nbsp;<asp:button id="btndelete" runat="server" CssClass="formbuttonstyle" Text="Delete"></asp:button>
								<asp:validationsummary id="vsLabBooking" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
			<!--PopCalendar(tag name and id must match) Tags should sit at the page bottom --><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
			name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189">
		</iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer>
		</form>
		</body>
</HTML>
