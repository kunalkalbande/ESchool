<%@ Page language="c#" Codebehind="Investments.aspx.cs" AutoEventWireup="false" Inherits="eschool.StudentFees.Stock" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>eSchool : Stock Master</title> 
		<!--
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
		<SCRIPT src="../../HeaderFooter/shareables/jsfiles/Country.js" type="text/javascript"></SCRIPT>
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
	// this method use to hide and show textbox when dropdown select 'Other' value. 
	function Other(t)
	{
		if(t.name=="DropOutSider")
		{
		 var index=t.selectedIndex
	     var name = t.options[index].text
		    if(name=="Other")
			{ 
				document.all.txtItemOther.style.visibility="visible"
			}
			else
			{
				document.all.txtItemOther.style.visibility="hidden"
			}
		}
		else if(t.name=="DropUnit")
		{
		 var index=t.selectedIndex
	     var name = t.options[index].text
		    if(name=="Other")
			{ 
				document.all.txtUnit.style.visibility="visible"
			}
			else
			{
				document.all.txtUnit.style.visibility="hidden"
			}
		}
		else if(t.name=="Droplocation")
		{
		 var index=t.selectedIndex
	     var name = t.options[index].text
		    if(name=="Other")
			{ 
				document.all.TxtLocation.style.visibility="visible"
			}
			else
			{
				document.all.TxtLocation.style.visibility="hidden"
			}
		}
		
	}
	
		</script>
</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Stock" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td align="center"><asp:label id="Label3" runat="server" Font-Bold="True"></asp:label></td>
				</tr>
				<tr>
					<td vAlign="top" align="center"><B>STOCK MASTER</B>
						<TABLE cellSpacing="1" cellPadding="1" width="80%" align="center" borderColorLight="#663300"
							border="5">
							<TBODY>
								<tr>
									<td colSpan="4"><asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label></td>
								</tr>
								<tr>
									<td>&nbsp;Stock ID</td>
									<td colSpan="3"><asp:dropdownlist id="DropStockID" Runat="server" AutoPostBack="True" CssClass="ComboBox"></asp:dropdownlist>&nbsp;<asp:label id="lblStockID" ForeColor="blue" Runat="server"></asp:label>&nbsp;
										
										<asp:button id="btnEdit" Runat="server" CssClass="formeditbuttonstyle" CausesValidation="False"
											Text="..."></asp:button></td>
								</tr>
								<TR>
									<TD>&nbsp;Item Category&nbsp;<font color="#ff3300" size="1">*</font></TD>
									<TD colSpan="1"><asp:dropdownlist id="DropOutSider" runat="server" Width="100px" CssClass="ComboBox" onchange="Other(this)"></asp:dropdownlist>&nbsp;<asp:comparevalidator id="validatin2" Runat="server" ErrorMessage="Please Select The Item Category" ValueToCompare="Select"
											Operator="NotEqual" ControlToValidate="DropOutSider">*</asp:comparevalidator>
										<input class="TextBoxForms" onkeypress="return GetAnyNumber(this, event);" id="txtItemOther"
											style="VISIBILITY: hidden; WIDTH: 120px;" type="text" maxLength="30" name="txtItemOther"> <!--<input id=ItemOther style="VISIBILITY: hidden" type=hidden>--></TD>
									<TD>&nbsp;Name Of Item&nbsp;<font color="#ff3300" size="1">*</font></TD>
									<TD><asp:textbox onkeypress="return GetAnyNumber(this, event);" id="txtItem" Runat="server" CssClass="TextBoxForms"
											MaxLength="40"></asp:textbox>&nbsp;
										<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Name Of Item"
											ControlToValidate="txtItem">*</asp:requiredfieldvalidator></TD>
								</TR>
								<tr>
									<TD>&nbsp;Unit&nbsp;<font color="#ff3333" size="1">*</font></TD>
									<TD><asp:dropdownlist id="DropUnit" runat="server" Width="100px" CssClass="ComboBox" onchange="Other(this)"></asp:dropdownlist>
										<asp:comparevalidator id="com1" Runat="server" ErrorMessage="Please Select the Unit" ValueToCompare="Select"
											Operator="NotEqual" ControlToValidate="DropUnit">*</asp:comparevalidator>
										<input class="TextBoxForms" onkeypress="return GetOnlyChars(this, event);" id="txtUnit"
											style="VISIBILITY: hidden; WIDTH: 120px;" type="text" maxLength="10" name="txtUnit"></TD>
									<td>&nbsp;Opening Qty.&nbsp;<font color="#ff3300" size="1">*</font></td>
									<td><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtQty" Runat="server"
											CssClass="TextBoxForms" MaxLength="10"></asp:textbox>&nbsp;
										<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" ErrorMessage="Please Enter Quantity"
											ControlToValidate="txtQty">*</asp:requiredfieldvalidator></td>
								</tr>
								<tr>
									<td>&nbsp;Rate&nbsp;<font color="#ff3300" size="1">*</font></td>
									<td><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtRate" Runat="server"
											CssClass="TextBoxForms" MaxLength="10"></asp:textbox>&nbsp;
										<asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" ErrorMessage="Please Enter Rate" ControlToValidate="txtRate">*</asp:requiredfieldvalidator></td>
									<td>&nbsp;Stock Location</td>
									<td><asp:dropdownlist id="Droplocation" Runat="server" CssClass="ComboBox" onchange="Other(this)"></asp:dropdownlist><input class="TextBoxForms" onkeypress="return GetAnyNumber(this, event);" style="VISIBILITY: hidden; WIDTH: 120px"
											type="text" maxLength="20" name="TxtLocation"></td>
								</tr>
								<tr>
									<TD>&nbsp;Remark</TD>
									<TD><asp:textbox id="txtrem" Runat="server" CssClass="TextBoxForms" MaxLength="40" Height="20px"
											TextMode="MultiLine" Width="124px"></asp:textbox></TD>
									<td>&nbsp;Current Date</td>
									<td><asp:textbox id="Txtdate" Runat="server" CssClass="Fontstyle" Width=70px BorderStyle=Groove ></asp:textbox>
										<A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Stock.Txtdate);return false;">
											<IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
												border="0"></A></td>
								</tr>
								<tr>
									<td align="center" colSpan="4"><asp:button id="btnSave" runat="server" CssClass="formbuttonstyle" Text="Save"></asp:button>&nbsp; 
										&nbsp;
										<asp:button id="BtnUpdate" runat="server" CssClass="formbuttonstyle" Text="Update"></asp:button>&nbsp;<asp:button id="BtnReset" Runat="server" CssClass="formbuttonstyle" CausesValidation="False"
											Text="Reset"></asp:button><asp:validationsummary id="summary1" Runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
								</tr>
				</tr>
			</table>
		</form>
		<!--PopCalendar(tag name and id must match) Tags should sit at the page bottom --><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
			name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189">
		</iframe></TD></TR></TBODY></TABLE><uc1:footer id="Footer1" runat="server"></uc1:footer>
	</body>
</HTML>
