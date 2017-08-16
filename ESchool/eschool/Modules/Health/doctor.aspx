<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="doctor.aspx.cs" AutoEventWireup="false" Inherits="eschool.Health.Doctor" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Doctor</title><!--
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
		<SCRIPT src="../../HeaderFooter/shareables/jsfiles/Country.js" type="text/javascript"></SCRIPT>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		
		//this method use to hide or visible textbox on the form to accept the other value which is not in dropdown.
		function CheckOther(t)
			{
				if(t.name=="dropDoctor")
				  {
					var index=t.selectedIndex
					var name = t.options[index].text
					if(name=="Other")
					  {
						document.Form1.Textdname.style.visibility="visible"
					  }
					else
					  {
						document.Form1.Textdname.style.visibility="hidden"
					  }
				  }	
			}
			
			// This method use to assin value of dropdown to textbox
			function getvalue(t)
			{
			   document.all.tempdoctorname.value=t.value
			   // alert(document.all.txtdoctorname.value)
			}
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="228" width="778" align="center">
				<tr>
					<td align="center"><STRONG>DOCTOR'S &nbsp;DETAIL</STRONG>
						<TABLE id="Table1" style="VISIBILITY: visible" cellSpacing="1" cellPadding="1" align="center"
							borderColorLight="#663300" border="5">
							<TBODY>
								<tr>
									<td colspan="2"><asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label><INPUT id="txtName" style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" type="text" size="3"
											name="txtName" runat="server"> <INPUT id="tempdoctorname" style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" type="text"
											size="3" name="tempdoctorname" runat="server"></td>
								</tr>
								<asp:panel id="pan1" Runat="server">
									<TR>
										<TD>&nbsp;Doctor ID</TD>
										<TD><asp:dropdownlist id="Dropedit" runat="server" CssClass="ComboBox" AutoPostBack="true" Visible="False">
												<asp:ListItem Value="Select">---Select---</asp:ListItem>
											</asp:dropdownlist>
											<asp:Label id="lbldocid" Runat="server" ForeColor="blue"></asp:Label>&nbsp;
											<asp:Button id="btnedit1" Runat="server" Text="..." CausesValidation="False" Width="20" CssClass="FormButtonStyle"></asp:Button>
										</TD>
									</TR>
								</asp:panel><asp:panel id="pan2" Runat="server">
									<TR>
										<TD>&nbsp;Doctor Name <FONT color="#ff3333" size="1">*</FONT></TD>
										<TD>
											<asp:TextBox onkeypress="return GetOnlyChars(this, event);" id="txtdoctor" Runat="server" Width="200"
												CssClass="TextBoxForms" MaxLength="30"></asp:TextBox>&nbsp;
											<asp:RequiredFieldValidator id="RequiValidation1" Runat="server" ControlToValidate="txtdoctor" ErrorMessage="Please Enter Doctor Name">*</asp:RequiredFieldValidator></TD>
									</TR>
								</asp:panel>
								<TR>
									<TD>&nbsp;Reg No</TD>
									<TD><asp:textbox id="txtregno" runat="server" MaxLength="12" CssClass="TextBoxForms" Width="200px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;Specialization <FONT color="#ff3333" size="1">*</FONT></TD>
									<TD><asp:dropdownlist id="DropSpecial" Width="102" CssClass="ComboBox" runat="server">
											<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
											<asp:ListItem Value="Dental">Dental</asp:ListItem>
											<asp:ListItem Value="Ent">Ent</asp:ListItem>
											<asp:ListItem Value="Orthopedic">Orthopedic</asp:ListItem>
											<asp:ListItem Value="Pethology">Pethology</asp:ListItem>
											<asp:ListItem Value="Physiotherepy">Physiotherepy</asp:ListItem>
										</asp:dropdownlist>&nbsp;<asp:comparevalidator id="Comparevalidator3" runat="server" ControlToValidate="DropSpecial" ErrorMessage="Please Select Specialization"
											ValueToCompare="---Select---" Operator="NotEqual">*</asp:comparevalidator></TD>
								</TR>
								<TR>
									<TD>&nbsp;Address</TD>
									<TD><asp:textbox id="Textadd" runat="server" CssClass="TextBoxForms" MaxLength="49" Width="200px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;City <FONT color="#ff3333" size="1">*</FONT></TD>
									<TD><asp:dropdownlist id="DropCity" CssClass="ComboBox" runat="server" AutoPostBack="false" Onchange="getBeatInfo(this,document.Form1.DropState,document.Form1.DropCountry);"
											Width="102px">
											<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
										</asp:dropdownlist>&nbsp;<asp:comparevalidator id="CompareValidator1" runat="server" ControlToValidate="DropCity" ErrorMessage="Please Select City"
											ValueToCompare="---Select---" Operator="NotEqual">*</asp:comparevalidator></TD>
								</TR>
								<TR>
									<TD>&nbsp;State</TD>
									<TD><asp:dropdownlist id="DropState" CssClass="ComboBox" runat="server" Width="102px" Enabled="False">
											<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD>&nbsp;Country</TD>
									<TD><asp:dropdownlist id="DropCountry" CssClass="ComboBox" runat="server" Width="102px" Enabled="False">
											<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD>&nbsp;Phone (Off)</TD>
									<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, true,false);" id="txtphoneoff" runat="server"
											CssClass="TextBoxForms" Width="129px" MaxLength="12"></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" ErrorMessage="Contact No. Between 6-10 Digits"
											ControlToValidate="txtphoneoff" ValidationExpression="\d{6,12}">*</asp:regularexpressionvalidator></TD>
								</TR>
								<TR>
									<TD>&nbsp;Phone (Res)</TD>
									<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event,true,false);" id="txtphoneres" runat="server"
											CssClass="TextBoxForms" MaxLength="12" Width="129px"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" ErrorMessage="Contact No. Between 6-10 Digits"
											ControlToValidate="txtphoneres" ValidationExpression="\d{6,12}">*</asp:regularexpressionvalidator></TD>
								</TR>
								<TR>
									<TD>&nbsp;Mobile</TD>
									<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,false);" id="txtmobile" runat="server"
											CssClass="TextBoxForms" MaxLength="12" Width="129px"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator3" runat="server" ErrorMessage="Contact No. Between 6-10 Digits"
											ControlToValidate="txtmobile" ValidationExpression="\d{6,12}">*</asp:regularexpressionvalidator></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2"><asp:button id="btnSave" runat="server" CssClass="FormButtonStyle" Text="Save"></asp:button>&nbsp;
										<asp:button id="btnEdit" runat="server" CausesValidation="False" CssClass="FormButtonStyle"
											Text="Update"></asp:button>&nbsp;
										<asp:button id="BtnReset" Runat="server" CssClass="FormButtonStyle" Text="Delete" CausesValidation="False"></asp:button><asp:validationsummary id="vsDoctor" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></TD>
								</TR>
							</TBODY>
						</TABLE>
					</td>
				</tr>
			</table>
		</form>
		<uc1:footer id="Footer1" runat="server"></uc1:footer>
	</body>
</HTML>
