<%@ Page language="c#" Codebehind="Stuck_Off.aspx.cs" AutoEventWireup="false" Inherits="eschool.certificate.Stuck_Off" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>eSchool : Stuck Off</title> 
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
		<script language="javascript">
		// this method use to show and hide hidden textbox.
		function Other(t)
		{
			if(t.name=="txtreason")
			{
				var index=t.selectedIndex
				var name = t.options[index].text
				if(name=="Other")
				{ 
					document.all.txtItemOther.style.visibility="visible"
				}
				else
				{
					document.all.txtItemOther.style.visibility="hidden"
				}
			}
		}
		</script>
</HEAD>
	<body>
		<form id="Tc" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td align="center" colSpan="3"></td>
				</tr>
				<tr>
					<td></td>
					<td vAlign="top" align="center"><asp:label id="Label1" runat="server" Font-Bold="True"><B>STUCK 
								OFF</B></asp:label>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="70%" borderColorLight="#663300"
							border="5">
							<TR>
								<TD colSpan="4"><asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label></TD>
							</TR>
							<TR>
								<TD>
									<asp:label id="tcid11" runat="server">&nbsp;ID</asp:label>&nbsp;</TD>
								<td colSpan="6"><asp:dropdownlist CssClass="ComboBox" id="DropEdit" runat="server" Height="15px" Width="83px" AutoPostBack="True">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist>&nbsp;<asp:label id="tcid" runat="server" ForeColor="blue"></asp:label>&nbsp;
								</td>
							</TR>
							<TR>
								<TD>&nbsp;Class&nbsp;<FONT color="#ff0000" size="1">*</FONT></TD>
								<TD><asp:dropdownlist CssClass="ComboBox" id="Dropclass" runat="server" Height="15px" Width="83px" AutoPostBack="True">
										<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
									</asp:dropdownlist>&nbsp;<asp:CompareValidator ID="compvalid1" Runat="server" ControlToValidate="Dropclass" Operator="NotEqual"
										ValueToCompare="---Select---" ErrorMessage="Please Select Class">*</asp:CompareValidator></TD>
								<TD>&nbsp;Student ID&nbsp;<FONT color="#ff0000" size="1">*</FONT></TD>
								<TD><asp:dropdownlist CssClass="ComboBox" id="Dropstudentid" runat="server" AutoPostBack="True">
										<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
									</asp:dropdownlist>&nbsp;<asp:CompareValidator ID="Comparevalidator1" Runat="server" ControlToValidate="Dropstudentid" Operator="NotEqual"
										ValueToCompare="---Select---" ErrorMessage="Please Select Student ID">*</asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD>&nbsp;Student Name</TD>
								<TD><asp:textbox CssClass="TextBoxForms" id="txtstudentname" runat="server" Enabled="False"></asp:textbox></TD>
								<TD>&nbsp;Father Name&nbsp;</TD>
								<TD><asp:textbox CssClass="TextBoxForms" id="txtfaname" Enabled="False" Runat="server"></asp:textbox></TD>
							</TR>
							<tr>
								<td>&nbsp;Admission Date</td>
								<td><asp:textbox CssClass="TextBoxForms" id="txtadddt" runat="server" Enabled="False"></asp:textbox></td>
								<td>&nbsp;Date of Birth</td>
								<td><asp:textbox CssClass="TextBoxForms" id="txtdob" Enabled="False" Runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td>&nbsp;Fees Paid</td>
								<td><asp:textbox CssClass="TextBoxForms" id="txtduefee" Enabled="False" Runat="server"></asp:textbox></td>
								<td>&nbsp;Date<FONT color="#ff0000"><FONT size="1">*</FONT></FONT></td>
								<td><asp:textbox CssClass="Fontstyle" Width=70px BorderStyle=Groove id="txttcdt" runat="server" ></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Tc.txttcdt);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A>
									<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="you must be enter tc date"
										ControlToValidate="txttcdt">*</asp:requiredfieldvalidator><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Tc.txtisdate);return false;"></A></td>
							</tr>
							<TR>
								<TD align="center" colSpan="4"><asp:button id="btnSave" BorderStyle="Groove" runat="server" ForeColor="Black" Width="56px"	Text="Save" CssClass="formbuttonstyle"></asp:button>
									&nbsp;<asp:button id="BtnEdit" CausesValidation="False" BorderStyle="Groove" runat="server" ForeColor="Black" Width="60px" Text="Edit" CssClass="formbuttonstyle"></asp:button>
									&nbsp;<asp:button id="BtnEditSave" BorderStyle="Groove" runat="server" ForeColor="Black" Text="Update" CssClass="formbuttonstyle"></asp:button>
									&nbsp;<asp:button id="BtnDelete" BorderStyle="Groove" runat="server" ForeColor="Black" Text="Delete" CssClass="formbuttonstyle"></asp:button>
									&nbsp;<asp:button id="btnreset" BorderStyle="Groove" runat="server" ForeColor="Black" Width="59px" Text="Reset" CausesValidation=False CssClass="formbuttonstyle"></asp:button>
									&nbsp;<asp:button id="btnprint" Visible="False" BorderStyle="Groove" runat="server" ForeColor="Black" Width="59px" Text="Print" CssClass="formbuttonstyle"></asp:button>
										<asp:validationsummary id="vsTC" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></TD>
							</TR>
							
						</TABLE>
					</td>
					<td></td>
				</tr>
				<tr>
					<td colSpan="3"></td>
				</tr>
			</table>
			<!--PopCalendar(tag name and id must match) Tags should sit at the page bottom --><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
