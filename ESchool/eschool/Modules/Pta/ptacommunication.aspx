<%@ Page language="c#" Codebehind="ptacommunication.aspx.cs" AutoEventWireup="false" Inherits="eschool.Pta.ptacommunication" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>eSchool : PTA Communication</title> 
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
		<script language="javascript" id="Validations" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body>
		<form id="ptacommunication" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td vAlign="top" align="center"><asp:label id="Label1" runat="server" Font-Bold="True">PTA COMMUNICATION</asp:label>
						<TABLE id="Table1" width="639" cellSpacing="1" cellPadding="1" borderColorLight="#663300"
							border="5" >
							<TR>
								<TD colspan="4">
									<asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label></TD>
							</TR>
							<TR>
								<TD >&nbsp;Member Id&nbsp;<FONT color="#ff0033" size=1>*</FONT></TD>
								<TD ><asp:dropdownlist CssClass="ComboBox" Width=130px id="Dropmember" runat="server" AutoPostBack="True">
									 <asp:ListItem Value="---Select---">---Select---</asp:ListItem>
									 </asp:dropdownlist>&nbsp;<asp:CompareValidator ID=vialid1 Runat=server ControlToValidate=Dropmember ValueToCompare=---Select--- Operator=NotEqual ErrorMessage="Please Select Member ID">*</asp:CompareValidator></TD>
								<TD >&nbsp;Member Name <FONT color="#ff0033" size=1></FONT>
								</TD>
								<TD><asp:textbox CssClass="TextBoxforms" id="txtmname" runat="server" Enabled="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD >&nbsp;Address</TD>
								<TD ><asp:textbox CssClass="TextBoxforms" id="txtadd" runat="server" Enabled="False" ></asp:textbox></TD>
								<TD >&nbsp;City</TD>
								<TD><asp:textbox CssClass="TextBoxforms" id="txtcity" runat="server" Enabled="False" ></asp:textbox></TD>
							</TR>
							<TR>
								<TD >&nbsp;State</TD>
								<TD ><asp:textbox CssClass="TextBoxforms" id="txtstate" runat="server" Enabled="False" ></asp:textbox></TD>
								<TD >&nbsp;Country</TD>
								<TD><asp:textbox CssClass="TextBoxforms" id="txtcountry" runat="server" Enabled="False" ></asp:textbox></TD>
							</TR>
							<TR>
								<TD >&nbsp;Phone</TD>
								<TD ><asp:textbox CssClass="TextBoxforms" id="txtphone" onkeypress="return GetOnlyNumbers(this, event, true,false);" runat="server"
										Enabled="False" ></asp:textbox></TD>
								<TD >&nbsp;E-mail</TD>
								<TD><asp:textbox CssClass="TextBoxforms" id="txtemail" runat="server" Enabled="False" ></asp:textbox></TD>
							</TR>
							<TR>
								<TD >&nbsp;Meeting Date&nbsp;<FONT color="#ff0033" size=1>*</FONT></TD>
								<TD ><asp:textbox id="txtmdate" CssClass="Fontstyle"  Width=70px BorderStyle="Groove" runat="server" ></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.ptacommunication.txtmdate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A>
									<asp:requiredfieldvalidator id="Requiredfieldvalidator4" runat="server" ErrorMessage="You Must Enter Meeting Date "
										ControlToValidate="txtmdate">*</asp:requiredfieldvalidator></TD>
								<TD >&nbsp;Agenda&nbsp;<font color=red size=1></font></TD>
								<TD>
									<asp:DropDownList CssClass="ComboBox" id="DropAgenda" runat="server" Width="130px">
										<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
									</asp:DropDownList>&nbsp;<asp:CompareValidator ID="Comparevalidator1" Runat=server ControlToValidate=DropAgenda ValueToCompare=---Select--- Operator=NotEqual ErrorMessage="Please Select Agenda">*</asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD >&nbsp;Type of Communication</TD>
								<TD ><asp:dropdownlist CssClass="ComboBox" id="Dropcomm" runat="server" Width="130px">
										<asp:ListItem Value="---Select--">---Select--</asp:ListItem>
										<asp:ListItem Value="E-Mail">E-Mail</asp:ListItem>
										<asp:ListItem Value="SMS">SMS</asp:ListItem>
										<asp:ListItem Value="Post">Post</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD >&nbsp;Sending Date&nbsp;<FONT color="#ff0033" size=1>*</FONT></TD>
								<TD><asp:textbox id="txtsdate" runat="server" CssClass="TextBoxDate" ></asp:textbox></TD>
							</TR>
							<TR>
								<TD >&nbsp;Sender Name</TD>
								<TD colspan="3"><asp:dropdownlist CssClass="TextBoxforms" id="Dropdownlist1" runat="server" Width="130px">
										<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="4" style="HEIGHT: 28px">
									<asp:Button id="btnSave" runat="server" Text="Save" CssClass="FormButtonStyle"></asp:Button>&nbsp;
									<asp:button id="BtnReset" Runat="server" Text="Reset" CausesValidation="False" CssClass="FormButtonStyle"></asp:button>
									<asp:ValidationSummary id="vsPtaCommunication" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary></TD>
							</TR>
							
						</TABLE>
					</td>
				</tr>
			</table>
		
		<!--PopCalendar(tag name and id must match) Tags should sit at the page bottom --><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
			name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189">
		</iframe>
		<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
