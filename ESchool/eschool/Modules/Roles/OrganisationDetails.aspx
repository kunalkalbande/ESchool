<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="OrganisationDetails.aspx.cs" AutoEventWireup="false" Inherits="eschool.OrganisationDetails" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : School Information</title> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<SCRIPT src="Country.js" type="text/javascript"></SCRIPT>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<script language="javascript" id="Validations" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<script language="javascript" id="country" src="../../HeaderFooter/shareables/jsfiles/Country.js"></script>
		<script language="javascript">
		//this method not in use
		function view(t)
		{
			var ind=t.selectedIndex
			//var id=t.options[ind].text
			var val=document.Form1.temporgdata.value
			var field=new Array()
			field=val.split(':')
			if(ind==1)
			{
				document.Form1.txtOwnerName.value=field[1]
				document.Form1.TxtOrganisationName.value=field[1]
				document.Form1.TxtAddress.value=field[1]
				document.Form1.DropCity.value=field[1]
				document.Form1.txtOwnerName.value=field[1]
				document.Form1.txtOwnerName.value=field[1]
				document.Form1.txtOwnerName.value=field[1]
				document.Form1.txtOwnerName.value=field[1]
				document.Form1.txtOwnerName.value=field[1]
				document.Form1.txtOwnerName.value=field[1]
				document.Form1.txtOwnerName.value=field[1]
				document.Form1.txtOwnerName.value=field[1]
				document.Form1.txtOwnerName.value=field[1]
				document.Form1.txtOwnerName.value=field[1]
			}
			alert(field[0])
		}
		
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="228" width="778" align="center">
				<tr>
					<td></td>
					<td vAlign="top" align="center"><b>SCHOOL INFORMATION</b>
						<table cellSpacing="1" cellPadding="0" align="center" borderColorLight="#663300" border="5">
							<TBODY>
								<TR>
									<TD bgColor="white" colSpan="4" rowSpan="1"><asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label>
										<INPUT id="txtState" style="VISIBILITY: hidden; WIDTH: 30px; HEIGHT: 10px" type="text"
											size="2" name="txtState" runat="server"> <INPUT id="txtCity" style="VISIBILITY: hidden; WIDTH: 30px; HEIGHT: 10px" type="text" size="2"
											name="txtCity" runat="server"> <INPUT id="txtdumy" style="VISIBILITY: hidden; WIDTH: 30px; HEIGHT: 10px" type="text" size="2"
											name="txtState1" runat="server"> <INPUT id="txtCity1" style="VISIBILITY: hidden; WIDTH: 30px; HEIGHT: 10px" type="text"
											size="2" name="txtCity1" runat="server"> <INPUT id="txtName" style="VISIBILITY: hidden; WIDTH: 30px; HEIGHT: 10px" type="text" size="3"
											name="txtName" runat="server"> <INPUT id="txtCountry" style="VISIBILITY: hidden; WIDTH: 30px; HEIGHT: 10px" type="text"
											size="2" name="txtCity1" runat="server"> <INPUT id="txtCountry1" style="VISIBILITY: hidden; WIDTH: 30px; HEIGHT: 10px" type="text"
											size="2" name="txtCity1" runat="server"> <INPUT id="Text1" style="VISIBILITY: hidden; WIDTH: 48px; HEIGHT: 10px" type="text" size="2"
											name="txtName" runat="server"> <INPUT id="temporgdata" style="VISIBILITY: hidden; WIDTH: 48px; HEIGHT: 10px" type="text"
											size="2" name="temporgdata" runat="server"></TD>
								</TR>
								<TR>
									<TD>&nbsp;<asp:label id="Label1" runat="server" Width="94px">School ID</asp:label></TD>
									<TD colSpan="3"><asp:dropdownlist id="DropID" runat="server" Width="104px" AutoPostBack="True" Visible="False" CssClass="ComboBox">
											<asp:ListItem Value="Select">Select</asp:ListItem>
										</asp:dropdownlist>&nbsp;<asp:label id="LblCompanyID" ForeColor="Blue" Runat="server"></asp:label>&nbsp;<asp:button id="Button1" runat="server" CssClass="formeditbuttonstyle" CausesValidation="False"
											Text="..."></asp:button>
										<asp:comparevalidator id="CompareValidator2" runat="server" Operator="NotEqual" ValueToCompare="---Select---"
											ErrorMessage="Please Select The Affiliation No" ControlToValidate="DropID">*</asp:comparevalidator></TD>
								</TR>
								<TR>
									<TD>&nbsp;Affiliation No&nbsp;<font color="#ff3300" size="1">*</font></TD>
									<TD colSpan="3"><asp:textbox id="txtOwnerName" BorderStyle="Groove" CssClass="TextBoxForms" runat="server" Width="352"
											MaxLength="20"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter The Affiliation No"
											ControlToValidate="txtOwnerName">*</asp:requiredfieldvalidator></TD>
								</TR>
								<TR>
									<TD>&nbsp;School Name&nbsp;<font color="#ff3300" size="1">*</font></TD>
									<TD colSpan="3"><asp:textbox id="TxtOrganisationName" BorderStyle="Groove" CssClass="TextBoxForms" runat="server"
											Width="352" MaxLength="40"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter The Organisation Name"
											ControlToValidate="TxtOrganisationName">*</asp:requiredfieldvalidator></TD>
								</TR>
								<TR>
									<TD>&nbsp;Address&nbsp;<font color="#ff3300" size="1">*</font>
									</TD>
									<TD colSpan="3"><asp:textbox CssClass="TextBoxForms" id="TxtAddress" BorderStyle="Groove" runat="server" Width="352"
											MaxLength="30"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter The Address"
											ControlToValidate="TxtAddress">*</asp:requiredfieldvalidator></TD>
								</TR>
								<TR>
									<TD>&nbsp;</TD>
									<TD colSpan="3"><asp:textbox id="TxtAddress1" CssClass="TextBoxForms" BorderStyle="Groove" runat="server" Width="352"
											MaxLength="30"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;</TD>
									<TD colSpan="3"><asp:textbox id="TxtAddress2" CssClass="TextBoxForms" BorderStyle="Groove" runat="server" Width="352"
											MaxLength="30"></asp:textbox></TD>
								</TR>
								<TR>
								<TR>
									<TD>&nbsp;City&nbsp;<font color="#ff3300" size="1">*</font>
									</TD>
									<TD><asp:dropdownlist id="DropCity" runat="server" Width="106px" CssClass="ComboBox" onchange="getBeatInfo(this,document.Form1.DropState,document.Form1.DropCountry);"></asp:dropdownlist><asp:comparevalidator id="CompareValidator1" runat="server" Operator="NotEqual" ValueToCompare="---Select---"
											ErrorMessage="Please Select The City" ControlToValidate="DropCity">*</asp:comparevalidator></TD>
									<TD>&nbsp;Phone No
									</TD>
									<TD><asp:textbox CssClass="TextBoxForms" onkeypress="return GetOnlyNumbers(this, event, false,false);"
											id="txtPhoneOff" BorderStyle="Groove" runat="server" Width="139px" MaxLength="12"></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" ErrorMessage="Contact No. Between 6-10 Digits"
											ControlToValidate="txtPhoneOff" ValidationExpression="\d{6,12}">*</asp:regularexpressionvalidator></TD>
								</TR>
								<TR>
									<TD>&nbsp;State</TD>
									<TD><asp:dropdownlist id="DropState" runat="server" Width="106px" CssClass="ComboBox"></asp:dropdownlist></TD>
									<TD>&nbsp;Fax No
									</TD>
									<TD><asp:textbox CssClass="TextBoxForms" onkeypress="return GetOnlyNumbers(this, event, false,false);"
											id="TxtFaxNo" BorderStyle="Groove" runat="server" Width="139px" MaxLength="12"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" ErrorMessage="Contact No. Between 6-10 Digits"
											ControlToValidate="TxtFaxNo" ValidationExpression="\d{6,12}">*</asp:regularexpressionvalidator>&nbsp;</TD>
								</TR>
								<TR>
									<TD>&nbsp;Country</TD>
									<TD><asp:dropdownlist id="DropCountry" runat="server" Width="106px" CssClass="ComboBox"></asp:dropdownlist></TD>
									<TD>&nbsp;</TD>
									<TD>&nbsp;</TD>
								</TR>
								<TR>
									<TD>&nbsp;E-Mail</TD>
									<TD colSpan="3"><asp:textbox CssClass="TextBoxForms" id="txtEMail" BorderStyle="Groove" runat="server" Width="352px"></asp:textbox>&nbsp;<asp:regularexpressionvalidator id="Regularexpressionvalidator3" runat="server" ErrorMessage="Please Fill Valid E-mail"
											ControlToValidate="txtEMail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:regularexpressionvalidator></TD>
								</TR>
								<TR>
									<TD>&nbsp;Web Site</TD>
									<TD colSpan="3"><asp:textbox CssClass="TextBoxForms" id="TxtWebsite" BorderStyle="Groove" runat="server" Width="352px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;School Logo</TD>
									<TD colSpan="3"><input id="txtFileContents" style="WIDTH: 350px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
											dataSrc="d:\test\" type="file" size="39" name="txtFileContents" Runat="Server"></TD>
								</TR>
								<TR>
									<TD>&nbsp;Message</TD>
									<TD colSpan="3"><asp:textbox CssClass="TextBoxForms" id="txtMsg" BorderStyle="Groove" runat="server" Width="352"
											MaxLength="49"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;Accounts Period From</TD>
									<TD><asp:textbox id="txtDateFrom" BorderStyle="Groove" runat="server" Width="70px" CssClass="FontStyle"
											ReadOnly="True"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtDateFrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
												border="0"></A></TD>
									<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; To</TD>
									<TD><asp:textbox id="txtDateTo" BorderStyle="Groove" runat="server" Width="70px" CssClass="FontStyle"
											ReadOnly="True"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtDateTo);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
												border="0"></A></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="4"><asp:button id="btnUpdate" runat="server" CssClass="formbuttonstyle" Text="Save"></asp:button>&nbsp;
										<asp:button id="btnPrint" runat="server" Width="80px" Visible="False" CssClass="formbuttonstyle"
											Text="Print"></asp:button></TD>
								</TR>
							</TBODY>
						</table>
						<asp:validationsummary id="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True"
							Height="16px"></asp:validationsummary></td>
				</tr>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm"
				frameBorder="0" width="174" scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></FORM>
	</body>
</HTML>
