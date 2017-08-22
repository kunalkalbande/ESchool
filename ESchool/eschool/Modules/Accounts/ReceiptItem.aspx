<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="ReceiptItem.aspx.cs" AutoEventWireup="false" Inherits="eschool.StudentFees.ReceiptItem" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Receipt Item</title> 
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
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		// this method use to take value from dropdown in hidden textbox.	
		function selectCountry()
		{
		 	var index=document.Form1.DropCountry.selectedIndex
  			var CountryName = document.Form1.DropCountry.options[index].text
  			document.Form1.DropCountryValue.value= CountryName
		}
		// this method use to show and hide the textbox.
		function CheckOther(t)
		{
			//alert("Test");
			if(t.name=="DropVendername")
			{
			    var index=t.selectedIndex
				var name = t.options[index].text
				if(name=="Other")
				{
					document.Form1.txtVName.style.visibility="visible"
				}
				else
				{
					document.Form1.txtVName.style.visibility="hidden"
				}
			}	
		}
		
		// this method use to calculate quty * total amount.
		function Amount()
		{
			var rate= document.Form1.all.TxtRate.value
			//alert("rate:"+rate)
			//alert("qty:"+qty)
			var qty= document.Form1.all.txtQty.value
			if(rate!=null&&qty!=null)
			document.Form1.all.TxtAmount.value=rate * qty
		}
  
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td vAlign="top" align="center"><B>RECEIPT ITEM</B>
						<TABLE cellpadding="1" cellspacing="1" align="center" borderColorLight="#663300" border="5">
							<TBODY>
								<TR>
									<TD colSpan="4"><asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label><INPUT id="txtState" style="VISIBILITY: hidden; WIDTH: 48px; HEIGHT: 10px" type="text"
											size="2" name="txtState" runat="server" DESIGNTIMEDRAGDROP="3839"><INPUT id="txtCity" style="VISIBILITY: hidden; WIDTH: 48px; HEIGHT: 10px" type="text" size="2"
											name="txtCity" runat="server"><INPUT id="txtState1" style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" type="text"
											size="2" name="txtState1" runat="server"><INPUT id="txtCity1" style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" type="text"
											size="2" name="txtCity1" runat="server"><INPUT id="txtName" style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" type="text" size="1"
											name="txtName" runat="server"><INPUT id="Txtitemcat" style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" type="text"
											size="1" name="Txtitemcat" runat="server"> <INPUT id="DropCountryValue" style="VISIBILITY: hidden; WIDTH: 53px; HEIGHT: 10px" type="text"
											name="DropCountryValue" runat="server"></TD>
								</TR>
								<tr>
									<td>&nbsp;Stock ID</td>
									<td class="ComboBox" colSpan="3"><asp:dropdownlist CssClass="ComboBox" id="DropStockID" Runat="server" AutoPostBack="True"></asp:dropdownlist>
										&nbsp;<asp:label id="lblStockID" ForeColor="blue" Runat="server"></asp:label>
										&nbsp;&nbsp;<asp:button id="btnEdit" Runat="server" CausesValidation="False" Text="..." CssClass="formeditbuttonstyle"></asp:button></td>
								</tr>
								<TR>
									<TD>&nbsp;Item Category&nbsp;<font color="red" size="1">*</font></TD>
									<TD><asp:dropdownlist CssClass="ComboBox" id="DropOutSider" runat="server" Width="130px" AutoPostBack="True"
											onchange="getitemunit(this,document.Form1.DropUnit);"></asp:dropdownlist>&nbsp;
										<asp:comparevalidator id="compvadation1" Runat="server" Operator="NotEqual" ControlToValidate="DropOutSider"
											ErrorMessage="Please Select Item Category" ValueToCompare="Select">*</asp:comparevalidator>
										<!--<input type="text" name="txtItemOther" style="VISIBILITY: hidden">--></TD>
									<td>&nbsp;Unit</td>
									<TD><asp:dropdownlist CssClass="ComboBox" Width="130px" id="DropUnit" runat="server"></asp:dropdownlist>
										<!--<input type="text" name="txtUnit" style="VISIBILITY: hidden">--></TD>
								</TR>
								<tr>
									<TD>&nbsp;Name Of Item&nbsp;<font color="red" size="1">*</font></TD>
									<TD>
										<!--<asp:textbox id=txtItem Runat="server"></asp:textbox>--><asp:dropdownlist CssClass="ComboBox" id="DropItem" Width="130px" runat="server" AutoPostBack="True"></asp:dropdownlist>&nbsp;
										<asp:comparevalidator id="Comparevalidator1" Runat="server" Operator="NotEqual" ControlToValidate="DropItem"
											ErrorMessage="Please Select Name Of Item" ValueToCompare="Select">*</asp:comparevalidator></TD>
									<td>&nbsp;Quantity&nbsp;<font color="red" size="1">*</font></td>
									<td><asp:textbox CssClass="TextBoxforms" onkeypress="return GetOnlyNumbers(this, event, false,true);"
											id="txtQty" onblur="Amount();" Runat="server" MaxLength="8" Width="130px"></asp:textbox>&nbsp;<asp:requiredfieldvalidator id="reqvali1" Runat="server" ControlToValidate="txtQty" ErrorMessage="Please Enter Quantity">*</asp:requiredfieldvalidator></td>
								</tr>
								<TR>
									<TD>&nbsp;Rate&nbsp;<font color="red" size="1">*</font></TD>
									<TD><asp:textbox CssClass="TextBoxforms" onkeypress="return GetOnlyNumbers(this, event, false,true);"
											id="TxtRate" onblur="Amount();" Runat="server" MaxLength="8" Width="130px"></asp:textbox>&nbsp;<asp:requiredfieldvalidator id="Requiredfieldvalidator2" Runat="server" ControlToValidate="TxtRate" ErrorMessage="Please Enter Rate">*</asp:requiredfieldvalidator></TD>
									<TD>&nbsp;Amount&nbsp;<font color="red" size="1">*</font></TD>
									<TD><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.TxtBilDate);return false;"></A><asp:textbox CssClass="TextBoxforms" onkeypress="return GetOnlyNumbers(this, event, false,true);"
											id="TxtAmount" runat="server" Width="130px"></asp:textbox>&nbsp;<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="TxtAmount" ErrorMessage="You Must Enter Amount">*</asp:requiredfieldvalidator></TD>
								</TR>
								<TR>
									<TD>&nbsp;Invoice No.</TD>
									<TD><asp:textbox CssClass="TextBoxforms" onkeypress="return GetOnlyNumbers(this, event, false,false);"
											id="Txtinvoice" Runat="server" MaxLength="6" Width="130px"></asp:textbox></TD>
									<TD>&nbsp;Date</TD>
									<TD><asp:textbox id="TxtBilDate" runat="server" CssClass="Fontstyle" Width="70px"
											BorderStyle="Groove"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.TxtBilDate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
												border="0"></A>
										<asp:requiredfieldvalidator id="Requiredfieldvalidator6" runat="server" ControlToValidate="TxtBilDate" ErrorMessage="You Must Enter Date">*</asp:requiredfieldvalidator></TD>
								</TR>
								<TR>
									<td>&nbsp;Vender Name&nbsp;<font color="red" size="1">*</font></td>
									<td><asp:dropdownlist CssClass="ComboBox" Width="165px" id="DropVendername" Runat="server"></asp:dropdownlist>&nbsp;
										<asp:comparevalidator id="Comparevalidator2" Runat="server" Operator="NotEqual" ControlToValidate="DropVendername"
											ErrorMessage="Please Select Vendor Name" ValueToCompare="Select">*</asp:comparevalidator>
									</td>
									<td>&nbsp;Stock Location</td>
									<td><asp:dropdownlist CssClass="ComboBox" id="DropLocation" Width="130px" Runat="server" onchange="CheckOther(this);"></asp:dropdownlist></td>
								</TR>
								<tr>
									<TD>&nbsp;Remark</TD>
									<TD><asp:textbox id="TxtRemark" CssClass="TextBoxforms" runat="server" Width="165px"></asp:textbox></TD>
									<td>&nbsp;Vehicle No</td>
									<td><asp:textbox CssClass="TextBoxforms" onkeypress="return GetAnyNumber(this, event);" id="TxtVehicle"
											Runat="server" MaxLength="12" Width="130px"></asp:textbox></td>
								</tr>
								<!--/table>
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" borderColorLight="#663300" border="5"
				width="80%"-->
								<tr>
									<td align="center" colSpan="4"><asp:button id="btnSave" runat="server" Text="Save" CssClass="formbuttonstyle"></asp:button>&nbsp;
										<asp:button id="BtnUpdate" runat="server" Text="Update" CssClass="formbuttonstyle"></asp:button>&nbsp;
										<asp:button id="BtnReset" Runat="server" CausesValidation="False" Text="Reset" CssClass="formbuttonstyle"></asp:button>
										<asp:validationsummary id="svInvestment" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></td>
								</tr>
					</td>
			</table>
			</TD></TR></TBODY></TABLE> 
			<!--PopCalendar(tag name and id must match) Tags should sit at the page bottom -->
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0"
				width="174" scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer>
		</form>
	</body>
</HTML>
