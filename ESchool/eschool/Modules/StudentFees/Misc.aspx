<%@ Page language="c#" Codebehind="Misc.aspx.cs" AutoEventWireup="false" Inherits="eschool.StudentFees.Form2" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>eSchool : Issue Item</title> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content=JavaScript name=vs_defaultClientScript>
<script language=javascript id=Validations 
src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>

<SCRIPT src="../../HeaderFooter/shareables/jsfiles/Country.js" type=text/javascript></SCRIPT>
<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type=text/css rel=stylesheet >
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema><LINK href="../../HeaderFooter/shareables/Style/Styles.css" type=text/css rel=stylesheet >
<script language=javascript>
	// this method not in use.
	function selectCountry()
	{
		var index=document.Form2.DropCountry1.selectedIndex
		var CountryName = document.Form2.DropCountry1.options[index].text
	    document.Form2.DropCountryValue.value= CountryName
	}
	
	
		</script>
</HEAD>
<body MS_POSITIONING="GridLayout">
<form id=Form2 method=post runat="server"><uc1:header id=Header1 runat="server"></uc1:header>
<table height=250 width=778 align=center>
  <TBODY>
  <tr>
    <td vAlign=top align=center><B 
      >ISSUE ITEM</B> 
      <TABLE align=center borderColorLight=#663300 border=5 
      >
        <TBODY>
        <tr>
          <td colSpan=4><asp:label id=Label4 runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label>
          <INPUT id=txtState1 style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" type=text size=2 name=txtState1 runat="server"> 
          <INPUT id=txtCity style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" type=text size=2 name=txtCity runat="server">
          <INPUT id=txtCountry style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" type=text size=2 name=txtCountry runat="server"> 
          <INPUT id=txtCity1 style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" type=text size=2 name=txtCity1 runat="server"> 
          <INPUT id=txtName style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" type=text size=3 name=txtName runat="server"> 
          <INPUT id=DropCountryValue style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" type=text size=1 name=DropCountryValue runat="server"></td></tr>
        <tr>
          <td>&nbsp;Issue ID</td>
          <td colSpan=3><asp:dropdownlist id=DropIssueID Runat="server" CssClass="ComboBox" AutoPostBack="True"></asp:dropdownlist> 
          &nbsp;<asp:label id=lblIssueID ForeColor="blue" Runat="server"></asp:label>&nbsp;
            &nbsp;<asp:button id=btnEdit Runat="server" CssClass="formeditbuttonstyle" Text="..." CausesValidation="False"></asp:button></td></tr>
        <TR>
          <td>&nbsp;Employee Name<font color=#ff3300 
            size=1>&nbsp;*</font></td>
          <td><asp:dropdownlist id=DropEmpID runat="server" CssClass="ComboBox" Width="150px">
              <asp:ListItem Value="Select">Select</asp:ListItem>
			</asp:dropdownlist>&nbsp; <asp:comparevalidator id=compvadation1 Runat="server" Operator="NotEqual" ControlToValidate="DropEmpID" ErrorMessage="Please Select EmployeeID" ValueToCompare="Select">*</asp:comparevalidator></td>
          <TD>&nbsp;Item Category<font color=#ff3300 
            size=1>&nbsp;*</font></TD>
          <td><asp:dropdownlist id=DropItemCategory Runat="server" CssClass="ComboBox" Width=150px AutoPostBack="True"></asp:dropdownlist>&nbsp;<asp:comparevalidator id=Comparevalidator1 Runat="server" Operator="NotEqual" ControlToValidate="DropItemCategory" ErrorMessage="Please Select Item Category" ValueToCompare="Select">*</asp:comparevalidator></td>
        <tr>
          <TD>&nbsp;Item Name<font color=#ff3300 size=1 
            >&nbsp;*</font></TD>
          <TD><asp:dropdownlist id=DropItemName Runat="server" CssClass="ComboBox" Width=150px></asp:dropdownlist>&nbsp;<asp:comparevalidator id=Comparevalidator2 Runat="server" Operator="NotEqual" ControlToValidate="DropItemName" ErrorMessage="Please Select Item Name" ValueToCompare="Select">*</asp:comparevalidator></TD>
          <TD>&nbsp;Qty<font color=#ff3300 size=1 
            >&nbsp;*</font></TD>
          <TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,false);" id=txtqty runat="server" CssClass="TextBoxforms" Width=150px MaxLength="5"></asp:textbox>&nbsp; 
			<asp:requiredfieldvalidator id=reqvali1 Runat="server" ControlToValidate="txtqty" ErrorMessage="Please Enter Quantity">*</asp:requiredfieldvalidator></TD></tr>
        <TR>
          <td>&nbsp;Unit</td>
          <td><asp:dropdownlist id=DropUnit Runat="server" Width=150px CssClass="ComboBox"></asp:dropdownlist></td>
          <td>&nbsp;Stock Location</td>
          <td><asp:dropdownlist id=Droplocation Runat="server" Width=150px CssClass="ComboBox"></asp:dropdownlist></td></TR>
        <tr>
          <TD>&nbsp;Issue Date</TD>
          <TD><asp:textbox id=txtdate runat="server" CssClass="Fontstyle" ReadOnly=True Width=70px BorderStyle="Groove"></asp:textbox><A 
            onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form2.txtdate);return false;" 
            ><IMG class=PopcalTrigger alt="" src="../../HeaderFooter/images/calendar_icon.gif" align=absMiddle border=0 ></A> <asp:requiredfieldvalidator id=Requiredfieldvalidator6 runat="server" ControlToValidate="txtdate" ErrorMessage="You Must Enter Date">*</asp:requiredfieldvalidator></TD>
          <TD>&nbsp;Remarks</TD>
          <TD><asp:textbox id=txtremark runat="server" CssClass="TextBoxforms" Width=150px ></asp:textbox></TD></tr>
        <TR>
          <TD align=center colSpan=6><asp:button id=btnSave runat="server" CssClass="formbuttonstyle" Text="Save"></asp:button>&nbsp; 
            &nbsp;<asp:button id=btnUpdate BorderStyle="Groove" runat="server" CssClass="formbuttonstyle" Text="Update"></asp:button> 
            &nbsp;<asp:button id=BtnReset Runat="server" CssClass="formbuttonstyle" Text="Reset" CausesValidation="False"></asp:button> 
			<asp:validationsummary id=svMisc runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></TD></TR></td></tr></TBODY></table>
			<iframe id=gToday:contrast:agenda.js style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px" name=gToday:contrast:agenda.js src="../../HeaderFooter/shareables/Style/ipopeng.htm" 
				frameBorder=0 width=174 scrolling=no height=189> 
		<TD>
			</tr>
			</TBODY>
			</iframe></TD></TR></TBODY></TABLE><uc1:footer id=Footer1 runat="server"></uc1:footer></form></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></FORM>
	</body>
</HTML>
