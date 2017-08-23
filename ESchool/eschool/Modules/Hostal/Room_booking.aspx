<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="Room_booking.aspx.cs" AutoEventWireup="false" Inherits="eschool.Hostel.Room_booking" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Room Booking</title> <!--
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
		<form id="Room_booking" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<TBODY>
					<tr>
						<td vAlign="top" align="center"><asp:label id="Label3" runat="server" Font-Bold="True">ROOM BOOKING</asp:label>
							<TABLE id="Table1" cellSpacing="1" cellPadding="1" borderColorLight="#663300" border="5">
								<TBODY>
									<TR>
										<TD colSpan="4"><asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label></TD>
									</TR>
									<TR>
										<TD>&nbsp;Class&nbsp;<font color="red" size="1">*</font></TD>
										<TD><asp:dropdownlist id="Dropclass" runat="server" CssClass="ComboBox" Width=130px AutoPostBack="True"></asp:dropdownlist>&nbsp;<asp:comparevalidator id="Comparevalidator2" runat="server" ValueToCompare="---Select---" Operator="NotEqual"
												ErrorMessage="Please select the Student Class" ControlToValidate="Dropclass" Width="4px">*</asp:comparevalidator></TD>
										<TD>&nbsp;Student ID&nbsp;<font color="red" size="1">*</font></TD>
										<TD><asp:dropdownlist id="Dropstudentid" runat="server" CssClass="ComboBox" AutoPostBack="True" Width=130px>
												<asp:ListItem Value="---Select---"></asp:ListItem>
											</asp:dropdownlist>&nbsp;<asp:comparevalidator id="CompareValidator1" runat="server" ValueToCompare="---Select---" Operator="NotEqual"
												ErrorMessage="Please select the Student ID" ControlToValidate="Dropstudentid" Width="4px">*</asp:comparevalidator></TD>
									</TR>
									<TR>
										<TD>&nbsp;Name</TD>
										<TD><asp:textbox id="txtstudentname" runat="server" CssClass="TextBoxforms" Width=130px Enabled="False" ></asp:textbox></TD>
										<TD>&nbsp;Hostel Fees
										</TD>
										<TD><asp:textbox id="txtfees" runat="server" CssClass="TextBoxforms" Width="130px" Enabled="False"
												></asp:textbox><FONT face="Arial" size="2"></FONT></TD>
									</TR>
									<TR>
										<TD>&nbsp;Room No&nbsp;<font color="red" size="1">*</font></TD>
										<TD><asp:dropdownlist id="DropDownList2" runat="server" CssClass="ComboBox" width="130px" AutoPostBack="True">
												<asp:ListItem Value="---Select---"></asp:ListItem>
											</asp:dropdownlist>&nbsp;<asp:comparevalidator id="cvRoomNo" runat="server" ValueToCompare="---Select---" Operator="NotEqual" ErrorMessage="Please select the Room Number"
												ControlToValidate="DropDownList2">*</asp:comparevalidator><FONT face="Arial" size="2"></FONT></TD>
										<!--TD>Mess Fees</TD>
										<TD><FONT face="Arial" size="2"><asp:textbox id="txtmessfees" runat="server" Width="87px" Enabled="False" ReadOnly="True"></asp:textbox></FONT></TD-->
										<TD>&nbsp;Bed No&nbsp;<font color="red" size="1">*</font></TD>
										<TD><asp:dropdownlist id="DropBed1" runat="server" CssClass="ComboBox" Width="130px">
												<asp:ListItem Value="--Select--">--Select--</asp:ListItem>
											</asp:dropdownlist>&nbsp;<asp:comparevalidator id="Comparevalidator3" runat="server" ValueToCompare="--Select--" Operator="NotEqual"
												ErrorMessage="Please select the Bed Number" ControlToValidate="DropBed1">*</asp:comparevalidator></TD>
									</TR>
									<TR>
										<TD>&nbsp;Date</TD>
										<TD colSpan="3"><asp:textbox id="txtdate" runat="server" CssClass="Fontstyle"  Width=70px BorderStyle="Groove"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Room_booking.txtdate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
													border="0"></A><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="You Must Enter Lab Date"
												ControlToValidate="txtdate">*</asp:requiredfieldvalidator></TD>
									</TR>
									<TR>
										<TD align="center" colSpan="4"><asp:button id="btnSave" runat="server" CssClass="FormButtonStyle" Text="Save"></asp:button>&nbsp;&nbsp;&nbsp;<asp:button id="BtnReset" CssClass="FormButtonStyle" Text="Reset" Runat="server" CausesValidation="False"></asp:button>
											<asp:validationsummary id="vsRoomBooking" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></TD>
									</TR>
									<!--PopCalendar(tag name and id must match) Tags should sit at the page bottom --><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
										name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189">
									</iframe>
								</TBODY>
							</TABLE>
						</td>
					</tr>
				</TBODY>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
