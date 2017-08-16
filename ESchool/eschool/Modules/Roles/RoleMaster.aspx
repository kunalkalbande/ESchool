<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Page language="c#" Codebehind="RoleMaster.aspx.cs" AutoEventWireup="false" Inherits="eschool.Roles.RoleMaster" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Role Master</title><!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<script language="javascript" id="validation1" src=../../HeaderFooter/shareables/jsfiles/Validations.js></script>
		<script language="javascript">
			function show1(t)
			{
				var ind=t.selectedIndex
				var val=t.options[ind].value	
				if(val!="---Select---")
				{
					document.Oiledit.txtRole.value=val
					document.Oiledit.brnaddNew.value="Update"
				}
				else
				{
					document.Oiledit.txtRole.value=""
					document.Oiledit.brnaddNew.value="Add"
				}
			}
			
			function change(t,t1)
			{
				t1.value=t.value
			} 
		</script>
	</HEAD>
	<body>
		<form id="Oiledit" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<TBODY>
					<tr>
						<td valign="top" align="center">
							<asp:Label id="Label1" runat="server">
								<b>ROLE MASTER</b></asp:Label><br>
							<TABLE id="Table1" cellSpacing="1" cellPadding="1" border="5" borderColorLight="#663300"
								width="42%">
								<TBODY>
									<TR>
										<TD>
											<asp:Label id="lblRoleName" runat="server">&nbsp;&nbsp;Role Name</asp:Label></FONT></TD>
										<TD>
											<asp:DropDownList id="DropDownList1" Onchange="show1(this)" runat="server" Width="150" CssClass="ComboBox"></asp:DropDownList></TD>
									</TR>
									<TR>
										<TD>&nbsp;
											<asp:Label id="lblNewRoleName" runat="server">Add New Role&nbsp;<font color="red" size="1">
													*</font></asp:Label></TD>
										<TD>
											<asp:TextBox id="txtRole" runat="server" Width="150" onblur="change(this,document.Oiledit.tempRole)"
												CssClass="TextBoxForms" MaxLength="30" onkeypress="return GetOnlyChars(this, event);"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiValidation1" ControlToValidate="txtRole" ErrorMessage="Please Fill the Role Name"
												Runat="server">*</asp:RequiredFieldValidator>
											<asp:RegularExpressionValidator id="revRole" runat="server" ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$"
												ErrorMessage="You must enter Role  in alphabetic format" ControlToValidate="txtRole">*</asp:RegularExpressionValidator></TD>
									</TR>
									<TR>
										<TD colspan="5" align="center">
											<asp:Button id="brnaddNew" runat="server" Text="Add  " CssClass="FormButtonStyle"></asp:Button>&nbsp;
											<asp:Button id="btnEditSave" runat="server" CssClass="FormButtonStyle" Text="Update"></asp:Button>&nbsp;
											<asp:Button id="buttonDelete" runat="server" CssClass="FormButtonStyle" Text="Delete"></asp:Button>
											<asp:ValidationSummary id="vsRole" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>
											<input id="tempRole" runat="server" type="hidden" name="tempRole" style="WIDTH: 1px; HEIGHT: 1px">
										</TD>
									</TR>
								</TBODY>
							</TABLE>
						</td>
						<td></td>
					</tr>
				</TBODY>
			</table>
			<uc1:Footer id="Footer1" runat="server"></uc1:Footer>
		</form>
		</TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>
	</body>
</HTML>
