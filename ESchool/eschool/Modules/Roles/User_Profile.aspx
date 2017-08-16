<%@ Page language="c#" Codebehind="User_Profile.aspx.cs" AutoEventWireup="false" Inherits="eschool.Roles.User_Profile" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : User Profile</title><!--
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
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		// this method use to show value on the form  from hidden text box.
		function checkValidorNot()
		{
		    var newpass=document.Form1.txtPassword.value
		    var newlog=document.Form1.txtLoginName.value
		  	var value=document.Form1.TxtHidden1.value
		 	var logpass=new Array()
			var log=new Array()
				logpass=value.split(',')
				for(var i=0;i<logpass.length-1;i++)
				{     
				       var pass=logpass[i]
				       log=pass.split(':')
				       for(var j=0;j<log.length;j++)
				       {
							if(newpass==log[0] && newlog==log[1])
							{
							    alert("Login Name All Ready Exist")
							    document.Form1.txtPassword.value=""
							    document.Form1.txtLoginName.value=""
							    break
							}
					  }
				}
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<INPUT id="TxtHidden1" style="VISIBILITY: hidden; WIDTH: 48px; POSITION: absolute; TOP: 5px; HEIGHT: 10px"
				type="text" size="2" name="TxtHidden1" runat="server">
			<table height="250" width="778" align="center">
				<tr>
					<td valign="top" align="center"><b>USER PROFILE</b>
						<TABLE cellSpacing="1" cellPadding="1" width="80%" borderColorLight="#663300" border="5">
							<TR>
								<TD colSpan="4"><asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label></TD>
							</TR>
							<TR>
								<TD>&nbsp;User ID
								</TD>
								<TD colSpan="3">
									<asp:dropdownlist id="DropEdit" runat="server" CssClass="ComboBox" AutoPostBack="True">
										<asp:ListItem Value="--Select--">--Select--</asp:ListItem>
									</asp:dropdownlist>&nbsp;<asp:label id="lblUserID" ForeColor="Blue" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>&nbsp;Login Name&nbsp;<FONT color="red" size="1">*</FONT>
								</TD>
								<TD colSpan="3"><asp:textbox id="txtLoginName" MaxLength="20" runat="server" CssClass="TextBoxForms"></asp:textbox><asp:requiredfieldvalidator id="rfvLoginName" runat="server" ControlToValidate="txtLoginName" ErrorMessage="You must enter login name">&nbsp;*</asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD>&nbsp;Password&nbsp;<FONT color="red" size="1">*</FONT></TD>
								<TD colSpan="3"><asp:textbox id="txtPassword" onblur="checkValidorNot()" runat="server" CssClass="TextBoxForms"
										TextMode="Password"></asp:textbox><asp:requiredfieldvalidator id="rfvPassward" runat="server" ControlToValidate="txtPassword" ErrorMessage="you must enter passward">&nbsp;*</asp:requiredfieldvalidator>
									<asp:RegularExpressionValidator id="Regularexpressionvalidator2" runat="server" ControlToValidate="txtPassword"
										ErrorMessage="Minimum 5 Maximum 30 characters allowed" ValidationExpression="\w{5,30}">*</asp:RegularExpressionValidator></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
								<TD align="center">First Name</TD>
								<TD align="center">Middle Name</TD>
								<TD align="center">Last Name</TD>
							</TR>
							<TR>
								<TD>&nbsp;Name <FONT color="red" size="1">*</FONT></TD>
								<TD><asp:textbox id="txtFName" runat="server" CssClass="TextBoxForms" MaxLength="15"></asp:textbox><asp:regularexpressionvalidator id="revFirstName" runat="server" ControlToValidate="txtFName" ErrorMessage="You must enter first name  in alphabetic format"
										ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$">*</asp:regularexpressionvalidator><asp:requiredfieldvalidator id="rfvName" runat="server" ControlToValidate="txtFName" ErrorMessage="You must enter first name">*</asp:requiredfieldvalidator></TD>
								<TD><asp:textbox id="txtMName" runat="server" CssClass="TextBoxForms" MaxLength="10"></asp:textbox><asp:regularexpressionvalidator id="revMiddleName" runat="server" ControlToValidate="txtMName" ErrorMessage="You must enter middle name  in alphabetic format"
										ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$">*</asp:regularexpressionvalidator></TD>
								<TD><asp:textbox id="txtLName" runat="server" CssClass="TextBoxForms" MaxLength="20"></asp:textbox><asp:regularexpressionvalidator id="revLastName" runat="server" ControlToValidate="txtLName" ErrorMessage="You must enter last name  in alphabetic format"
										ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$">*</asp:regularexpressionvalidator></TD>
							</TR>
							<TR>
								<TD>&nbsp;Role&nbsp; <FONT color="red" size="1">*</FONT></TD>
								<TD><asp:dropdownlist Width="130" id="DropRole" runat="server" CssClass="ComboBox"></asp:dropdownlist><asp:comparevalidator id="cvRole" runat="server" ControlToValidate="DropRole" ErrorMessage="Please select Role"
										ValueToCompare="---Select---" Operator="NotEqual">&nbsp;*</asp:comparevalidator></TD>
								<td align="center"><asp:label id="Label1" runat="server">Description</asp:label><FONT color="red" size="1">&nbsp;*</FONT></td>
								<td><asp:textbox id="txtDescription" runat="server" MaxLength="30" CssClass="TextBoxForms"></asp:textbox>&nbsp;<asp:requiredfieldvalidator id="rfvDesc" runat="server" ControlToValidate="txtDescription" ErrorMessage="You must enter description">*</asp:requiredfieldvalidator></td>
							</TR>
							<TR>
								<TD align="center" colSpan="4"><asp:button id="btnSaveProfile" runat="server" CssClass="FormButtonStyle" Text="Save "></asp:button>&nbsp;<asp:button id="btnedit" runat="server" CssClass="FormButtonStyle" Text="Edit" CausesValidation="False"></asp:button>&nbsp;<asp:button id="btneditsave" runat="server" CssClass="FormButtonStyle" Text="Update"></asp:button>&nbsp;<asp:button id="btndelete" runat="server" CssClass="FormButtonStyle" Text="Delete" CausesValidation="False"></asp:button>
									<asp:validationsummary id="vsUserProfile" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
