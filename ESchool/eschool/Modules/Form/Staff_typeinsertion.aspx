<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="Staff_typeinsertion.aspx.cs" EnableViewState="true" AutoEventWireup="false" Inherits="eschool.Form.Staff_typeinsertion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Staff Type Insertion</title><!--
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
		<script language="javascript" id="validation1" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
		<script language="javascript">
		// This method use to show information which is save in hidden textbox.
		function Showtype(t,t1)
		{
			document.Staff_typeinsertion.tempdropval.value=""
			document.Staff_typeinsertion.tempnewtype.value=""
			document.Staff_typeinsertion.btnSave.value="Add"
			document.Staff_typeinsertion.txtstafftype.value=""
			var k
			var objval=t.value
			var allstaff=new Array()
			var onestaff=new Array()
			var val=document.Staff_typeinsertion.temptype.value
			allstaff=val.split(',')
			k=0
			t1.length=1
			for(var i=0;i<allstaff.length-1;i++)
			{
			    onestaff=allstaff[i].split(':')
			   	if(objval=="chkTeachingType")
				{	
					if(onestaff[0]=="True")
					{
						k++
						t1.add(new Option)
						t1.options[k].text=onestaff[2]
					}
				}
				else if(objval=="chkNonTeachingType")
				{
					if(onestaff[1]=="True")
					{
						k++
						t1.add(new Option)
						t1.options[k].text=onestaff[2]
					}
				}
				else if(objval=="chkGroupDType")
				{
					if(onestaff[3]=="True")
					{
						k++
						t1.add(new Option)
						t1.options[k].text=onestaff[2]
					}
				}
				else if(objval=="chkActivityType")
				{
				
					if(onestaff[4]=="True")
					{
						k++
						t1.add(new Option)
						t1.options[k].text=onestaff[2]
						
					}
				}
			}
		}
		//this method use to check id dropdown has select value then controls blank.
		function getval(t,t1)
		{
			var ind=t.selectedIndex
			var val=t.options[ind].text
			//alert(val)
			if(val!="Select")
			{
				t1.value=val
				document.Staff_typeinsertion.btnSave.value="Update"
				document.Staff_typeinsertion.tempnewtype.value=val
			}
			else
			{
				t1.value=""
				document.Staff_typeinsertion.tempnewtype.value=""
				document.Staff_typeinsertion.btnSave.value="Add"
			}
		}
		
		// this method use to assign value.		
		function insertvalue(t,t1)
		{
			t1.value=t.value
		}
		
		// this method use to show dropdown value in to textbox.
		function tempstafftype(t,t1)
		{
		   var ind=t.selectedIndex
		   var val=t.options[ind].text
		   t1.value=val
		  //document.Staff_typeinsertion.tempnewtype.value=val
		   
		}
		</script>
	</HEAD>
	<body>
		<form id="Staff_typeinsertion" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<input id="temptype" type="hidden" name="temptype" runat="server"> <input id="tempnewtype" type="hidden" name="tempnewtype" runat="server">
			<input id="tempdropval" type="hidden" name="tempdropval" runat="server">
			<table height="250" width="778" align="center">
				<tr>
					<td vAlign="top" align="center"><asp:label id="Label2" runat="server">
							<b>STAFF TYPE INSERTION</b></asp:label>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="65%" borderColorLight="#663300"
							border="5">
							<TBODY>
								<TR>
									<TD>&nbsp;Staff Type</TD>
									<TD>
										<P>
											<!--Name:Mahesh & Bhalchand,Modify Date: 08/08/06
											Changes:Remove the CheckBox and placed RadioButton--><asp:radiobutton id="chkTeachingType" onclick="Showtype(this,document.Staff_typeinsertion.DropstaffType)"
												runat="server" GroupName="staff" AutoPostBack="False"></asp:radiobutton>Teaching&nbsp;&nbsp;
											<asp:radiobutton id="chkNonTeachingType" onclick="Showtype(this,document.Staff_typeinsertion.DropstaffType)"
												runat="server" GroupName="staff" AutoPostBack="False"></asp:radiobutton>Non 
											Teaching Staff
											<asp:radiobutton id="chkGroupDType" onclick="Showtype(this,document.Staff_typeinsertion.DropstaffType)"
												runat="server" GroupName="staff" AutoPostBack="False"></asp:radiobutton>Group 
											D&nbsp;&nbsp;
											<asp:radiobutton id="chkActivityType" onclick="Showtype(this,document.Staff_typeinsertion.DropstaffType)"
												runat="server" GroupName="staff" AutoPostBack="False"></asp:radiobutton>Activity 
											Staff
										</P>
									</TD>
								</TR>
								<TR>
									<TD>&nbsp;Designation</TD>
									<td><select class="ComboBox" id="DropstaffType" style="WIDTH: 150px" onchange="getval(this,document.Staff_typeinsertion.txtstafftype),tempstafftype(this,document.Staff_typeinsertion.tempdropval)"
											runat="server"><option value="Select" selected>Select</option>
										</select></td>
								</TR>
								<TR>
									<TD>&nbsp;Add New Designation<font color="red" size="1">&nbsp;*</font></TD>
									<TD><asp:textbox onkeypress="return GetOnlyChars(this, event);" id="txtstafftype" OnBlur="insertvalue(this,document.Staff_typeinsertion.tempnewtype)"
											BorderStyle="Groove" runat="server" Width="150px" MaxLength="15" CssClass="TextBoxForms"></asp:textbox>
										<asp:RequiredFieldValidator ID="Reqvali1" Runat="server" ErrorMessage="Please enter Designation" ControlToValidate="txtstafftype">*</asp:RequiredFieldValidator></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2">&nbsp;<asp:button id="btnSave" runat="server" CssClass="FormButtonStyle" Text="Add"></asp:button>
										&nbsp;<asp:button id="btnEdit" runat="server" CssClass="FormButtonStyle" Text="Edit" Visible="False"></asp:button>
										&nbsp;<asp:button id="btnSEdit" runat="server" CssClass="FormButtonStyle" Text="Update"></asp:button>
										&nbsp;<asp:button id="btnDelete" runat="server" CssClass="FormButtonStyle" Text="Delete"></asp:button>
										&nbsp;<asp:ValidationSummary ID="summary1" Runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary></TD>
								</TR>
							</TBODY>
						</TABLE>
						</FONT></td>
					<td></td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
