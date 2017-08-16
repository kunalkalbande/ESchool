<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Page language="c#" Codebehind="CardGeneration.aspx.cs" AutoEventWireup="false" Inherits="eschool.Library.FORMS.CardGeneration" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>CardGeneration</title><!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<script language=javascript id=Validations 
src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>

<meta content=C# name=CODE_LANGUAGE>
<meta content=JavaScript name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema><LINK href="../../HeaderFooter/shareables/Style/Styles.css" type=text/css rel=stylesheet >
  </HEAD>
<body>
<form id=CardGeneration method=post runat="server"><uc1:header id=Header1 runat="server"></uc1:header><INPUT 
id=txtNameOFEmployee type=hidden value=0 name=txtNameOFEmployee runat="server"> <INPUT id=Lblmemid type=hidden value=0 
name=txtNameOFEmployee runat="server"> 
<table height=250 width=778 align=center>
  <TBODY>
  <tr>
    <td align=center colSpan=3></td></tr>
  <tr>
    <td align=center><asp:label id=Label1 runat="server">
								<!--<A href="../../../Form/Menu.aspx">Home</A> COMMENT BY VIKAS SHARMA DATE ON 15/09/07--></asp:label></td>
    <td align=center><asp:label id=Label2 runat="server"></asp:label></td>
    <td align=center></td></tr>
  <tr>
    <td></td>
    <td align=center><B>CARD 
      GENERATION</B> 
      <table cellSpacing=1 cellPadding=1 width="70%" borderColorLight=#663300 
      border=5>
        <TBODY>
        <TR>
          <TD colSpan=4><asp:label id=Label4 runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label></TD></TR>
        <tr>
          <td>Member Type</td>
          <td colSpan=3><asp:radiobutton id=chkTeaching runat="server" AutoPostBack="True" Text="Teaching Staff" GroupName="Staff type"></asp:radiobutton><asp:radiobutton id=chkNonTeaching runat="server" AutoPostBack="True" Text="Non Teaching Staff" GroupName="Staff type"></asp:radiobutton><asp:radiobutton id=chkStudent runat="server" AutoPostBack="True" Text="Student" GroupName="Staff type"></asp:radiobutton></td></tr><asp:panel 
        id=panemployee Runat="server">
        <TR>
          <TD>
<asp:label id=lblDesignation runat="server">Designation</asp:label></TD>
          <TD colSpan=1>
<asp:dropdownlist id=DropType runat="server" AutoPostBack="True" CssClass="ComboBox" Width="80px">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist>
<asp:comparevalidator id=cvStaffType runat="server" ControlToValidate="DropType" ErrorMessage="Please select the staff type" Operator="NotEqual" ValueToCompare="---Select---">*</asp:comparevalidator></TD>
          <TD>
<asp:label id=lblEmployeeID Runat="server">Employee ID</asp:label></TD>
          <TD>
<asp:DropDownList id=DropEmpID runat="server" AutoPostBack="True">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:DropDownList></TD></TR></asp:panel><asp:panel 
        id=pansclass Runat="server">
        <TR>
          <TD>Class</TD>
          <TD>
<asp:DropDownList id=DropClass AutoPostBack="True" Runat="server" Width="80px">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:DropDownList></TD>
          <TD>Student ID</TD>
          <TD>
<asp:DropDownList id=DropStudID AutoPostBack="True" Runat="server">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:DropDownList></TD></TR>
        <TR>
          <TD>Student Name</TD>
          <TD>
<asp:textbox id=TxtStname Runat="server" ReadOnly="True" Enabled="False"></asp:textbox></TD></TR></asp:panel>
        <tr>
          <td>Card Number</td>
          <td colSpan=3><asp:textbox id=TxtCardNo Runat="server" ReadOnly="True" Enabled="False"></asp:textbox></td></tr>
        <tr>
          <td>Number OF Card<FONT color=#ff0033 size=2 
            >*</FONT></td>
          <td colSpan=3><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,false);" id=TxtNumberOFCard Runat="server"></asp:textbox><asp:requiredfieldvalidator id=ReqNumOFCard Runat="server" ControlToValidate="TxtNumberOFCard" ErrorMessage="You Must Enter Number OF Card">*</asp:requiredfieldvalidator></td></tr>
        <tr>
          <td>Card Generation Date</td>
          <TD colSpan=3><asp:textbox id=txtDate runat="server" CssClass="TextBoxDate"></asp:textbox><A 
            onclick="if(self.gfPop)gfPop.fPopCalendar(document.CardGeneration.txtDate);return false;" 
            ><IMG class=PopcalTrigger alt="" src="../../HeaderFooter/images/calendar_icon.gif" align=absMiddle border=0 ></A></TD></tr>
        <tr>
          <td>Validity OF Card</td>
          <td colSpan=3><asp:dropdownlist id=dropValiOfCard Runat="server">
												<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
												<asp:ListItem Value="1">1</asp:ListItem>
												<asp:ListItem Value="2">2</asp:ListItem>
												<asp:ListItem Value="3">3</asp:ListItem>
												<asp:ListItem Value="4">4</asp:ListItem>
												<asp:ListItem Value="5">5</asp:ListItem>
											</asp:dropdownlist><asp:comparevalidator id=cvValidity runat="server" ControlToValidate="dropValiOfCard" ErrorMessage="Yoy must select the Validity Of Card" Operator="NotEqual" ValueToCompare="---Select---">*</asp:comparevalidator></td></tr>
        <tr>
          <td>Remark<FONT color=#ff0033 
            >*</FONT></td>
          <td colSpan=3><asp:textbox id=TxtRemark Runat="server" Width="155px" TextMode="MultiLine" Columns="20" Rows="2"></asp:textbox><asp:requiredfieldvalidator id=Requiredfieldvalidator2 runat="server" ControlToValidate="TxtRemark" ErrorMessage="You Must Enter Remarks">*</asp:requiredfieldvalidator></td></tr>
        <tr>
          <td align=center colSpan=4>&nbsp; <asp:button id=btnSave Text="Save" Runat="server" CssClass="formbuttonstyle"></asp:button><INPUT class=formbuttonstyle id=Reset1 type=reset value=Reset name=Reset1 runat="server"> 
<asp:button id=btndel BorderStyle="Groove" runat="server" Text="Delete" CssClass="formbuttonstyle" Width="60px" Height="21px"></asp:button></td></tr>
        <TR>
          <TD align=center colSpan=4><asp:validationsummary id=vsCardGen runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD></TR></TBODY></table></td></tr></TBODY></table></form>
		<!--PopCalendar(tag name and id must match) Tags should sit at the page bottom --><iframe 
id=gToday:contrast:agenda.js 
style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px" 
name=gToday:contrast:agenda.js src="../../HeaderFooter/shareables/Style/ipopeng.htm" 
frameBorder=0 width=174 scrolling=no height=189>
		</iframe><uc1:footer id=Footer1 runat="server"></uc1:footer>
	</body>
</HTML>
