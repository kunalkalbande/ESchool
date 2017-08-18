<%@ Page language="c#" Codebehind="IssueBookDuplicate.aspx.cs" AutoEventWireup="false" Inherits="eschool.Library.FORMS.IssueBookDuplicate" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Book Issue</title><!--
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
		<script language="javascript" id="valid" src="../../HeaderFooter/shareables/jsfiles/Searchdrop.js"></script>
		<script language="javascript" id="valid1" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
		<script language="javascript">
		
		// this method use to get value in to hidden textbox from dropissuebookid.
		function getvalue()
		{
		  var value=document.IssueBookDuplicate.DropIssueBookID.value
		  var value1=value.split(':')
		  document.IssueBookDuplicate.txtbname.value=value1[1]
		}
		</script>
	</HEAD>
	<body>
		<form id="IssueBookDuplicate" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><input id="texthidden" style="WIDTH: 1px" type="hidden" name="texthidden" runat="server">
			<input id="texthidden1" style="WIDTH: 1px" type="hidden" name="texthidden1" runat="server">
			<table height="250" width="778" align="center">
				<tr>
					<td align="center"><asp:label id="Label1" runat="server">
							<!--<A href="../../../Form/Menu.aspx">Home</A> COMMENT BY VIKAS SHARMA DATE ON 15/09/07--></asp:label></td>
					<td align="center"><asp:label id="Label2" runat="server"></asp:label></td>
					<td align="center"></td>
				</tr>
				<tr>
					<td></td>
					<td vAlign="top" align="center"><b>BOOK ISSUE</b>
						<TABLE width="60%" align="center" borderColorLight="#663300" border="5">
							<TR>
								<TD colSpan="5"><asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label></TD>
							</TR>
							<tr>
								<td>&nbsp;Member Type&nbsp;<font color="#ff0033" size="1">*</font></td>
								<td colSpan="4" style="HEIGHT: 24px"><asp:radiobutton id="rediteaching" GroupName="staff type" Text="Staff" AutoPostBack="true" Runat="server"></asp:radiobutton>
									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:radiobutton id="redistudent" AutoPostBack="true" GroupName="staff type" Text="Student" Runat="server"></asp:radiobutton></td>
							</tr>
							<asp:panel id="PanEmpid" Runat="server" Visible="False">
								<TR>
									<TD>&nbsp;Employee ID&nbsp;<FONT color="#ff0033" size="1">*</FONT></TD>
									<TD>
										<asp:TextBox onkeypress="return GetOnlyNumbers(this, event, false,false);" id="TxtEmpid" Runat="server"
											AutoPostBack="True" CssClass="TextBoxForms" MaxLength="6" Width="65px"></asp:TextBox></TD>
									<TD>&nbsp;Name
									</TD>
									<TD>
										<asp:TextBox onkeypress="return GetOnlyChars(this, event);" id="TxtEmpName" Runat="server" CssClass="TextBoxForms"
											></asp:TextBox></TD>
								</TR>
							</asp:panel>
							<asp:panel id="PanStudid" Runat="server" Visible="False">
								<TR>
									<TD>&nbsp;Student ID&nbsp;<FONT color="#ff0033" size="1">*</FONT></TD>
									<TD>
										<asp:TextBox id="TxtStudid" Runat="server" AutoPostBack="True" CssClass="TextBoxForms" Width="65px"></asp:TextBox></TD>
									<TD>&nbsp;Name
									</TD>
									<TD>
										<asp:TextBox id="TxtStudName" Runat="server" CssClass="TextBoxForms" ></asp:TextBox></TD>
								</TR>
							</asp:panel>
							<tr>
								<td>&nbsp;Book ID&nbsp;<font color="#ff0033" size="1">*</font></td>
								<td colSpan="4"><input class="TextBoxStyle" id="DropIssueBookID" onkeyup="search3(this,document.IssueBookDuplicate.ListIssueBookID,document.IssueBookDuplicate.texthidden1.value),arrowkeydown(this,event,document.IssueBookDuplicate.ListIssueBookID,document.IssueBookDuplicate.texthidden1),Selectbyenter(document.IssueBookDuplicate.ListIssueBookID,event,document.IssueBookDuplicate.DropIssueBookID,document.IssueBookDuplicate.txtIssue),getvalue()"
										style="Z-INDEX: 10; VISIBILITY: visible; WIDTH: 150px; HEIGHT: 18px" onclick="search1(document.IssueBookDuplicate.ListIssueBookID,document.IssueBookDuplicate.texthidden1),dropshow(document.IssueBookDuplicate.ListIssueBookID)"
										value="Select" name="DropIssueBookID" runat="server"><input style="HEIGHT: 18px" class="ComboBoxSearchButtonStyle" onclick="search1(document.IssueBookDuplicate.ListIssueBookID,document.IssueBookDuplicate.texthidden1),dropshow(document.IssueBookDuplicate.ListIssueBookID)"
										readOnly type="text" name="temp"><br>
									<div id="Layer1" style="Z-INDEX: 2; POSITION: absolute"><select class="ListBoxBorderStyle" onmousemove="MouseMove(this)" onkeypress="Selectbyenter(this,event,document.IssueBookDuplicate.DropIssueBookID,document.IssueBookDuplicate.txtIssue)"
											id="ListIssueBookID" ondblclick="select(this,document.IssueBookDuplicate.DropIssueBookID),getvalue()" onkeyup="arrowkeyselect(this,event,document.IssueBookDuplicate.txtIssue,document.IssueBookDuplicate.DropIssueBookID),getvalue()"
											style="Z-INDEX: 10; VISIBILITY: hidden; WIDTH: 170px; HEIGHT: 0px" onfocusout="HideList(this,document.IssueBookDuplicate.DropIssueBookID)"
											multiple name="ListIssueBookID" type="select-one"></select></div>
								</td>
							</tr>
							<tr>
								<td>&nbsp;Book Name</td>
								<td colSpan="4">
									<asp:textbox id="txtbname" CssClass="TextBoxForms" Runat="server" ReadOnly="True" Width="216px"></asp:textbox></td>
							</tr>
							<tr>
								<td>&nbsp;Date of Issue</td>
								<TD colSpan="4"><asp:textbox id="txtIssue" runat="server" CssClass="Fontstyle" ReadOnly="True" Width="70px" BorderStyle="Groove"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.IssueBookDuplicate.txtIssue);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A>
									<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ControlToValidate="txtIssue" ErrorMessage="  Enter Book Issue Date">*</asp:requiredfieldvalidator></TD>
							</tr>
							<tr>
								<td>&nbsp;Return Date</td>
								<TD colSpan="4"><asp:textbox id="txtReturn" runat="server" CssClass="Fontstyle" ReadOnly="True" Width="70px"
										BorderStyle="Groove"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.IssueBookDuplicate.txtReturn);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A><asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" ControlToValidate="txtReturn" ErrorMessage="  Enter Return Date">*</asp:requiredfieldvalidator></TD>
							</tr>
							<tr>
								<td align="center" colSpan="5"><asp:button id="btnSave" runat="server" Text="Save" CssClass="formbuttonstyle"></asp:button>
									&nbsp;<asp:button id="BtnReset" Text="Reset" Runat="server" CssClass="formbuttonstyle" CausesValidation="False"></asp:button>
									<asp:validationsummary id="vsBookIssue" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
							</tr>
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
