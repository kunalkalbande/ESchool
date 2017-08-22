<%@ Page language="c#" Codebehind="Category.aspx.cs" AutoEventWireup="false" Inherits="eschool.Module.Form.Category" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Category</title> <!--
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
		//function ShowCatRank(t,t1,t2)
		// this method use to show Rank of selected category from hidden text box.
		function ShowCatRank(t)
		{
			var ind=t.selectedIndex
			var val=t.options[ind].value
			val=val.substring(0,val.indexOf(':'))
			var temval=document.Routeedit.tempCatRank.value
			var arr1=new Array()
			var arr2=new Array()
			arr1=temval.split(',')
			for(var i=0;i<arr1.length-1;i++)
			{
				var arr2=arr1[i].split(':')
				if(val==arr2[0])
				{
					document.Routeedit.txtcategory.value=arr2[1]
					document.Routeedit.txtRank.value=arr2[2]
				}
			}
			document.Routeedit.btnadd.value="Update"
			if(ind==0)
			{
				document.Routeedit.txtcategory.value=""
				document.Routeedit.txtRank.value=""
				document.Routeedit.btnadd.value="Add"
			}
		}
		
		// this method use to assign value of of hidden textbox from another textbox.
		function insertvalue(t,t1)
		{
			t1.value=t.value
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Routeedit" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td align="center"><asp:label id="Label1" runat="server" Font-Bold="True"></asp:label>
						<input id="tempCatRank" name="tempCatRank" runat="server" type="hidden"> <input id="tempCat" name="tempCat" runat="server" type="hidden">
						<input id="tempRank" name="tempRank" runat="server" type="hidden"></td>
				</tr>
				<tr>
					<td vAlign="top" align="center"><b>CATEGORY</b>
						<TABLE cellSpacing="1" cellPadding="1" borderColorLight="#663300" border="5">
							<TBODY>
								<tr>
									<td>&nbsp;Category ID</td>
									<td><asp:dropdownlist id="dropcatid" CssClass="ComboBox" Onchange="ShowCatRank(this);" Width="123px" Runat="server"></asp:dropdownlist></td>
								</tr>
								<TR>
									<TD>&nbsp;Category Name<font color=red size=1>&nbsp;*</font></TD>
									<TD><asp:textbox id="txtcategory" OnBlur="insertvalue(this,document.Routeedit.tempCat)" MaxLength="20"
											CssClass="TextBoxForms" Runat="server"></asp:textbox><asp:RequiredFieldValidator ID="RequiValidation1" Runat="server" ControlToValidate="txtcategory" ErrorMessage="Please Enter Category Name">&nbsp;*</asp:RequiredFieldValidator></TD>
								</TR>
								<TR>
									<TD>&nbsp;Rank<font color=red size=1>&nbsp;*</font></TD>
									<TD><asp:textbox id="txtRank" OnBlur="insertvalue(this,document.Routeedit.tempRank)" MaxLength="20"
											CssClass="TextBoxForms" Runat="server"></asp:textbox><asp:RequiredFieldValidator ID="RequValidation2" Runat="server" ControlToValidate="txtRank" ErrorMessage="Please Enter Rank">&nbsp;*</asp:RequiredFieldValidator></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="6">&nbsp;<asp:button id="btnadd" runat="server" Text="Add" CssClass="formbuttonstyle"></asp:button>&nbsp;
										<asp:button id="btnsave" runat="server" Text="Update " CssClass="formbuttonstyle"></asp:button>&nbsp;<asp:button id="btnEdit" runat="server" Text="Edit  " CssClass="formbuttonstyle"></asp:button>&nbsp;&nbsp;<asp:button id="btnDel" runat="server" Text="Delete" CssClass="formbuttonstyle"></asp:button></TD>
								</TR>
							</TBODY>
						</TABLE>
						<asp:validationsummary id="vsRoute" runat="server" Width="158px" ShowMessageBox="True" ShowSummary="False"
							Height="32px"></asp:validationsummary></td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
