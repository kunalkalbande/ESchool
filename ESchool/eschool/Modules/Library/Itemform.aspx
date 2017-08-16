<%@ Page language="c#" Codebehind="Itemform.aspx.cs" AutoEventWireup="false" Inherits="eschool.Library.FORMS.Itemform" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Book Entry</title> <!--
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
		<form id="Itemform" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td colSpan="3"></td>
				</tr>
				<tr>
					<td align="center"><asp:label id="Label1" runat="server">
							<!--<A href="../../../Form/Menu.aspx">Home</A> COMMENT BY VIKAS SHARMA DATE ON 15/09/07--></asp:label></td>
					<td align="center"><asp:label id="Label3" runat="server" ForeColor="Transparent"></asp:label></td>
					<td align="center">
					</td>
				</tr>
				<tr>
					<td></td>
					<td vAlign="top" align="center"><b>BOOK ENTRY</b>
						<TABLE align="center" borderColorLight="#663300" border="5">
							<TR>
								<TD colSpan="2"><asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label></TD>
							</TR>
							<TR>
								<TD>&nbsp;Book ID</TD>
								<TD><asp:textbox CssClass="TextBoxForms" id="txtBookID" Runat="server" Width="80px" AutoPostBack="True"></asp:textbox>&nbsp;<asp:Label ID="lblBookID" Runat="server" ForeColor="blue"></asp:Label>&nbsp; 
									&nbsp;<asp:button id="btnEdit" Runat="server" CssClass="formeditbuttonstyle" Text="..." CausesValidation="False"></asp:button></TD>
							</TR>
							<TR>
								<TD>&nbsp;Book Name&nbsp;<font color="#ff3300" size="1">*</font>
								</TD>
								<TD><asp:textbox CssClass="TextBoxForms" id="TxtBookName" onkeypress="return GetAnyNumber(this, event);"
										MaxLength="40" Runat="server" Width="250px"></asp:textbox>&nbsp;<asp:RequiredFieldValidator id="RequiredFieldValidator1" Runat="server" ErrorMessage="Please Enter The Book Name"
										ControlToValidate="TxtBookName">*</asp:RequiredFieldValidator></TD>
							</TR>
							<tr>
								<td>&nbsp;Subject Name</td>
								<td><asp:TextBox CssClass="TextBoxForms" ID="txtsubname" onkeypress="return GetAnyNumber(this, event);"
										MaxLength="40" Runat="server" Width="250px"></asp:TextBox></td>
							</tr>
							<TR>
								<TD>&nbsp;Author Name&nbsp;<font size="1" color="#ff3300">*</font>
								</TD>
								<TD><asp:textbox CssClass="TextBoxForms" id="TxtAuthorName" onkeypress="return GetAnyNumber(this, event);"
										MaxLength="40" Runat="server" Width="250px"></asp:textbox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator2" Runat="server" ErrorMessage="Please Enter The Auther Name"
										ControlToValidate="TxtAuthorName">*</asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD>&nbsp;Publisher Name</TD>
								<TD><asp:textbox CssClass="TextBoxForms" onkeypress="return GetAnyNumber(this, event);" MaxLength="40"
										id="TxtPublisherName" Runat="server" Width="250px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>&nbsp;Price&nbsp;Of Book&nbsp;<font size="1" color="#ff3300">*</font>
								</TD>
								<TD><asp:textbox CssClass="TextBoxForms" id="TxtNumberOfBook" MaxLength="6" Runat="server" onkeypress="return GetOnlyNumbers(this, event, false,true);"
										Width="90px"></asp:textbox>&nbsp;<asp:RequiredFieldValidator id="RequiredFieldValidator3" Runat="server" ErrorMessage="Please Enter The Price"
										ControlToValidate="TxtNumberOfBook">*</asp:RequiredFieldValidator></TD>
							</TR>
							<tr>
								<td>&nbsp;Purchase Date</td>
								<td><asp:TextBox ID="txtpdate" Runat="server" CssClass="Fontstyle" ReadOnly="True" Width="70px" BorderStyle="Groove"></asp:TextBox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Itemform.txtpdate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A></td>
							</tr>
							<tr>
								<td>&nbsp;Rack No</td>
								<td><asp:TextBox CssClass="TextBoxForms" ID="txtrno" MaxLength="6" Runat="server" Width="90px"></asp:TextBox></td>
							</tr>
							<tr>
								<td>&nbsp;Quantity&nbsp;<font size="1" color="#ff3300">*</font>
								</td>
								<td><asp:TextBox CssClass="TextBoxForms" ID="txtqty" MaxLength="3" Runat="server" onkeypress="return GetOnlyNumbers(this, event, false,false);"
										Width="90px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="rfv" ControlToValidate="txtqty" Runat="server" ErrorMessage="Please Enter The Quantity">*</asp:RequiredFieldValidator></td>
							</tr>
							<tr>
								<td>&nbsp;Remark</td>
								<td><asp:TextBox CssClass="TextBoxForms" ID="txtremark" MaxLength="40" Runat="server" Width="250px"
										TextMode="MultiLine"></asp:TextBox></td>
							</tr>
							<TR>
								<TD align="center" colSpan="3">
									<asp:button id="BtnOK" Runat="server" Text="Save" CssClass="formbuttonstyle"></asp:button>
									&nbsp;<asp:button id="BtnReset" Runat="server" Text="Reset" CausesValidation="False" CssClass="formbuttonstyle"></asp:button>
									<asp:validationsummary id="vsBookEntry" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></TD>
							</TR>
						</TABLE>
					</td>
					<td></td>
				</tr>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0"
				width="174" scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
