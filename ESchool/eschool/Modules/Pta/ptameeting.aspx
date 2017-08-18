<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="ptameeting.aspx.cs" AutoEventWireup="false" Inherits="eschool.Pta.ptameeting" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : PTA Meeting Discussion</title> <!--
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
		<script language=javascript id=validation1 src=../../HeaderFooter/shareables/jsfiles/Validations.js></script>
	</HEAD>
	<body>
		<form id="ptameeting" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="228" width="778" align="center">
				<tr>
					<td></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td></td>
					<td vAlign="top" align="center"><asp:label id="Label1" runat="server" Font-Bold="True">PTA MEETING DISCUSSION</asp:label>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" borderColorLight="#663300" border="5">
							<TR>
								<TD colSpan="2"><asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label></TD>
							</TR>
							<TR>
								<TD>Agenda</TD>
								<TD><asp:textbox CssClass="TextBoxforms" onkeypress="return GetAnyNumber(this, event);" id="txtagenda" runat="server" MaxLength="30"></asp:textbox><asp:requiredfieldvalidator id="rfvAgenda" runat="server" ControlToValidate="txtagenda" ErrorMessage="Please enter the agenda of meeting">*</asp:requiredfieldvalidator><asp:dropdownlist CssClass="ComboBox" id="DropDownList1" runat="server" AutoPostBack="True" Width="156px"></asp:dropdownlist><asp:button id="Button1" runat="server" CssClass="formeditbuttonstyle" CausesValidation="False"
										Text="..."></asp:button></TD>
							</TR>
							<TR>
								<TD>Date&nbsp;<FONT color="#ff0033">*</FONT></TD>
								<TD><asp:textbox id="txtdt" runat="server" CssClass="Fontstyle"  Width=70px BorderStyle="Groove"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.ptameeting.txtdt);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A>
									<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtdt" ErrorMessage="You Must Enter Date">*</asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="2"><STRONG>Discussion</STRONG></TD>
							</TR>
							<TR>
								<TD align="center">1&nbsp;<FONT color="#ff0033" size=1>*</FONT></TD>
								<TD><asp:textbox CssClass="TextBoxforms" id="txtdis1" runat="server" Width="155px" TextMode="MultiLine"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" ControlToValidate="txtdis1" ErrorMessage="You Must Enter discussion description 1">*</asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD align="center">2&nbsp;<FONT color="#ff0033" size="1">*</FONT></TD>
								<TD><asp:textbox CssClass="TextBoxforms" id="txtdis2" runat="server" Width="155px" TextMode="MultiLine"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" ControlToValidate="txtdis2" ErrorMessage="You Must Enter discussion description 2">*</asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD align="center">3&nbsp;<FONT color="#ff0033" size="1">*</FONT></TD>
								<TD><asp:textbox CssClass="TextBoxforms" id="txtdis3" runat="server" Width="155px" TextMode="MultiLine"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator4" runat="server" ControlToValidate="txtdis3" ErrorMessage="You Must Enter discussion description 3">*</asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD align="center">4&nbsp;</TD>
								<TD><asp:textbox CssClass="TextBoxforms" id="txtdis4" runat="server" Width="155px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="center">5&nbsp;</TD>
								<TD><asp:textbox CssClass="TextBoxforms" id="txtdis5" runat="server" Width="155px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="center">6&nbsp;</TD>
								<TD><asp:textbox CssClass="TextBoxforms" id="txtdis6" runat="server" Width="155px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="2"><asp:button id="btnSave" runat="server" CssClass="FormButtonStyle" Text="Save"></asp:button>&nbsp;
									<asp:button id="BtnEdit" CssClass="FormButtonStyle" CausesValidation="False" Text="Update" Runat="server"></asp:button>&nbsp;
									<asp:button id="BtnDelete" CssClass="FormButtonStyle" CausesValidation="False" Text="Delete"
										Runat="server"></asp:button><asp:validationsummary id="vsPtameeting" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD>
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
	</body>
</HTML>
