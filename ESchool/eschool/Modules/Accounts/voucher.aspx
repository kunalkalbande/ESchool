<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Page language="c#" Codebehind="voucher.aspx.cs" AutoEventWireup="false" Inherits="eschool.Forms.Inventory.voucher" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>eSchool : Voucher Entry</title> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="True" name="vs_snapToGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" id="Searchdrop" src="../../HeaderFooter/shareables/jsfiles/Searchdrop.js"></script>
		<!--script language="javascript" id="Searchdrop1" src="../../shareables/jsfiles/Secrchdrop1.js"></script-->
		<script language="javascript" id="Validations" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		// this method use to split hidden textbox value in to another hidden textbox.
		function getAcountName(t,t1)
		{
			var index = t.selectedIndex;
			var typetext  = t.options[index].text;
			var mainarr = new Array();
			var temp = "", temp1 = "";
			if(typetext == "Contra")
			{
				temp = document.Form1.txtTempContra.value;
				temp1 = document.Form1.txtTempContra1.value;
			}
			else if(typetext == "Credit Note")
			{
				temp = document.Form1.txTempCredit.value;
				temp1 = document.Form1.txTempCredit1.value;
			}
			else if(typetext == "Debit Note")
			{
				temp = document.Form1.txtTempDebit.value;
				temp1 = document.Form1.txtTempDebit1.value;
			}
			else
			{
				temp = document.Form1.txtTempJournal.value;
				temp1 = document.Form1.txtTempJournal1.value;
			}
			var mainarr = new Array();
			mainarr = temp.split("~");
			t1.value = mainarr[0];
			document.Form1.txtID.value = mainarr[0];
			document.Form1.texthiddenprod.value=temp1;
		}
		// this method use to fill value in to textbox.
		function fillCombo(temp,t1)
		{
			var mainarr = new Array();
			mainarr = temp.split("~");
			t1.value = mainarr[0];
			document.Form1.txtID.value = mainarr[0];
		}

		
		function changeType(t)
		{
			var index = t.selectedIndex;
			var temp = t.name;
			var arr = new Array();
			var drop = new Array(document.Form1.dropType_1,document.Form1.dropType_2,document.Form1.dropType_3,document.Form1.dropType_4,document.Form1.dropType_5,document.Form1.dropType_6,document.Form1.dropType_7,document.Form1.dropType_8);
			arr = temp.split("_");
			if(eval(arr[1]) <= 4)
			{
				if(index == 0)
				{
					drop[(eval(arr[1])+4)-1].selectedIndex = 0;
				}
				else
				{
					drop[(eval(arr[1])+4)-1].selectedIndex = 1;
				}
			}	
			else
			{
				if(index == 0)
				{
					drop[(eval(arr[1])-4)-1].selectedIndex = 0;
				}
				else
				{
					drop[(eval(arr[1])-4)-1].selectedIndex = 1;
				}
			}
			calcTotal(); 
		}

		function calcTotal()
		{
			var LDrTotal = 0;
			var LCrTotal = 0;
			var RDrTotal = 0;
			var RCrTotal = 0;
			if(document.Form1.txtAmount1.value != "")
			{
				document.Form1.txtAmount5.value = document.Form1.txtAmount1.value;
				var index = document.Form1.dropType_1.selectedIndex;
				var typetext = document.Form1.dropType_1.options[index].text;
				if(typetext == "Dr")
					LDrTotal = LDrTotal+ eval(document.Form1.txtAmount1.value);
				else
					LCrTotal = LCrTotal+ eval(document.Form1.txtAmount1.value);
			}
			if(document.Form1.txtAmount2.value != "")
			{
				document.Form1.txtAmount6.value = document.Form1.txtAmount2.value;
				var index2 = document.Form1.dropType_2.selectedIndex;
				var typetext2 = document.Form1.dropType_2.options[index2].text;
				if(typetext2 == "Dr")
					LDrTotal = LDrTotal+ eval(document.Form1.txtAmount2.value);
				else
					LCrTotal = LCrTotal+ eval(document.Form1.txtAmount2.value);
			}
			if(document.Form1.txtAmount3.value != "")
			{
				document.Form1.txtAmount7.value = document.Form1.txtAmount3.value;
				var index3 = document.Form1.dropType_3.selectedIndex;
				var typetext3 = document.Form1.dropType_3.options[index3].text;
				if(typetext3 == "Dr")
					LDrTotal = LDrTotal+ eval(document.Form1.txtAmount3.value);
				else
					LCrTotal = LCrTotal+ eval(document.Form1.txtAmount3.value);
			}
			if(document.Form1.txtAmount4.value != "")
			{
				document.Form1.txtAmount8.value = document.Form1.txtAmount4.value;
				var index4 = document.Form1.dropType_4.selectedIndex;
				var typetext4 = document.Form1.dropType_4.options[index4].text;
				if(typetext4 == "Dr")
					LDrTotal = LDrTotal+ eval(document.Form1.txtAmount4.value);
				else
					LCrTotal = LCrTotal+ eval(document.Form1.txtAmount4.value);
			}
			if(document.Form1.txtAmount5.value != "")
			{
				document.Form1.txtAmount1.value = document.Form1.txtAmount5.value;
				var index5 = document.Form1.dropType_5.selectedIndex;
				var typetext5 = document.Form1.dropType_5.options[index5].text;
				if(typetext5 == "Dr")
					RDrTotal = RDrTotal+ eval(document.Form1.txtAmount5.value);
				else
					RCrTotal = RCrTotal+ eval(document.Form1.txtAmount5.value);
			}
			if(document.Form1.txtAmount6.value != "")
			{
				document.Form1.txtAmount2.value = document.Form1.txtAmount6.value;
				var index6 = document.Form1.dropType_6.selectedIndex;
				var typetext6 = document.Form1.dropType_6.options[index6].text;
				if(typetext6 == "Dr")
					RDrTotal = RDrTotal+ eval(document.Form1.txtAmount6.value);
				else
					RCrTotal = RCrTotal+ eval(document.Form1.txtAmount6.value);
			}
			if(document.Form1.txtAmount7.value != "")
			{
				document.Form1.txtAmount3.value = document.Form1.txtAmount7.value;
				var index7 = document.Form1.dropType_7.selectedIndex;
				var typetext7 = document.Form1.dropType_7.options[index7].text;
				if(typetext7 == "Dr")
					RDrTotal = RDrTotal+ eval(document.Form1.txtAmount7.value);
				else
					RCrTotal = RCrTotal+ eval(document.Form1.txtAmount7.value);
			}
			if(document.Form1.txtAmount8.value != "")
			{
				document.Form1.txtAmount4.value = document.Form1.txtAmount8.value;
				var index8 = document.Form1.dropType_8.selectedIndex;
				var typetext8 = document.Form1.dropType_8.options[index8].text;
				if(typetext8 == "Dr")
					RDrTotal = RDrTotal+ eval(document.Form1.txtAmount8.value);
				else
					RCrTotal = RCrTotal+ eval(document.Form1.txtAmount8.value);
			}
			document.Form1.txtLCr.value = LCrTotal;
			makeRound( document.Form1.txtLCr);
			document.Form1.txtLDr.value = LDrTotal;
			makeRound( document.Form1.txtLDr);
			document.Form1.txtRCr.value = RCrTotal;
			makeRound( document.Form1.txtRCr);
			document.Form1.txtRDr.value = RDrTotal;
			makeRound( document.Form1.txtRDr);
		}
		
		
		function makeRound(t)
		{
			var str = t.value;
			if(str != "")
			{
				str = eval(str)*100;
				str = Math.round(str);
				str = eval(str)/100;
				t.value = str;
			}
		}
	
	
		function setValue(t)
		{
			var typetext = t.value;
			if(t.name == "dropAccName1")
				document.Form1.txtAccName1.value = typetext;
			if(t.name == "dropAccName2")
				document.Form1.txtAccName2.value = typetext;
			if(t.name == "dropAccName3")
				document.Form1.txtAccName3.value = typetext;
			if(t.name == "dropAccName4")
				document.Form1.txtAccName4.value = typetext;
			if(t.name == "dropAccName5")
				document.Form1.txtAccName5.value = typetext;
			if(t.name == "dropAccName6")
				document.Form1.txtAccName6.value = typetext;
			if(t.name == "dropAccName7")
				document.Form1.txtAccName7.value = typetext;
			if(t.name == "dropAccName8")
				document.Form1.txtAccName8.value = typetext;
		}
		
		
		function CheckLength(t)
		{
			if(t.value.length>199)
			{
				t.value=t.value.substring(0,199);
				alert("Only 200 Charactors Allowed In Narrations");
			}
		}
		</script>
</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><asp:textbox id="TextBox1" style="Z-INDEX: 102; LEFT: 144px; POSITION: absolute; TOP: 16px" runat="server"
				Visible="False" Width="1px"></asp:textbox><INPUT id="txtTempContra" style="Z-INDEX: 103; LEFT: 160px; WIDTH: 8px; POSITION: absolute; TOP: 16px; HEIGHT: 24px"
				type="hidden" size="1" name="Hidden1" runat="server"><INPUT id="txtTempContra1" style="Z-INDEX: 103; LEFT: 160px; WIDTH: 8px; POSITION: absolute; TOP: 16px; HEIGHT: 24px"
				type="hidden" size="1" name="Hidden1" runat="server"><INPUT id="txTempCredit" style="Z-INDEX: 104; LEFT: 176px; WIDTH: 8px; POSITION: absolute; TOP: 16px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden1" runat="server"><INPUT id="txTempCredit1" style="Z-INDEX: 104; LEFT: 176px; WIDTH: 8px; POSITION: absolute; TOP: 16px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden1" runat="server"><INPUT id="txtTempDebit" style="Z-INDEX: 105; LEFT: 192px; WIDTH: 8px; POSITION: absolute; TOP: 16px; HEIGHT: 24px"
				type="hidden" size="1" name="Hidden1" runat="server"><INPUT id="txtTempDebit1" style="Z-INDEX: 105; LEFT: 192px; WIDTH: 8px; POSITION: absolute; TOP: 16px; HEIGHT: 24px"
				type="hidden" size="1" name="Hidden1" runat="server"><INPUT id="txtTempJournal" style="Z-INDEX: 106; LEFT: 208px; WIDTH: 8px; POSITION: absolute; TOP: 16px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden1" runat="server"><INPUT id="txtTempJournal1" style="Z-INDEX: 106; LEFT: 208px; WIDTH: 8px; POSITION: absolute; TOP: 16px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden1" runat="server"><INPUT id="texthiddenprod" style="Z-INDEX: 103; VISIBILITY: hidden; WIDTH: 5px; POSITION: absolute; TOP: 0px; HEIGHT: 10px"
				type="text" name="texthiddenprod" runat="server">
			<TABLE height="250" cellSpacing="0" cellPadding="0" width="778" align="center">
				<tr>
					<th align="center">
						<B>VOUCHER ENTRY</B>
					</th>
				</tr>
				<TR>
					<TD vAlign="middle" align="center">
						<TABLE cellSpacing="1" cellPadding="1" align="center" borderColorLight="#663300" border="5">
							<TBODY>
								<TR>
									<TD colSpan="6"><FONT color="#ff0000">
											<asp:label id="lblVid" runat="server" >asterisk (*) fields are mandatory&nbsp;</asp:label></FONT></TD>
								</TR>
								<TR>
									<TD>Voucher Type <FONT color="#ff0000">*</FONT>
										<asp:comparevalidator id="Comparevalidator5" runat="server" ErrorMessage="Please Select Voucher type"
											ControlToValidate="DropVoucherName" Operator="NotEqual" ValueToCompare="Select">*</asp:comparevalidator>
											<asp:dropdownlist id="DropVoucherName" runat="server" Width="130px" onChange="return getAcountName(this,document.Form1.txtVouchID);"
											CssClass="ComboBox">
											<asp:ListItem Value="Select">Select</asp:ListItem>
											<asp:ListItem Value="Contra">Contra</asp:ListItem>
											<asp:ListItem Value="Credit Note">Credit Note</asp:ListItem>
											<asp:ListItem Value="Debit Note">Debit Note</asp:ListItem>
											<asp:ListItem Value="Journal">Journal</asp:ListItem>
										</asp:dropdownlist></TD>
									<TD align="center">&nbsp;Voucher ID <FONT color="#ff0000">*</FONT>
										<asp:comparevalidator id="Comparevalidator6" runat="server" ErrorMessage="Please Select Voucher ID " ControlToValidate="DropDownID"
											Operator="NotEqual" ValueToCompare="Select" ForeColor="White">*</asp:comparevalidator></TD>
									<TD><asp:dropdownlist id="DropDownID" runat="server" Width="69px" AutoPostBack="True" CssClass="dropdownlist">
											<asp:ListItem Value="Select">Select</asp:ListItem>
										</asp:dropdownlist><INPUT id="txtVouchID" style="WIDTH: 55px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
											disabled type="text" size="6" Class="TextBoxForms" name="txtVouchID" runat="server"><asp:button id="btnEdit1" runat="server" CssClass="formbuttonstyle" Width="20px" ToolTip="click here for Edit"
											CausesValidation="False" Text="..."></asp:button><INPUT id="txtID" style="WIDTH: 9px; HEIGHT: 22px" type="hidden" size="1" name="txtID"
											runat="server"></TD>
									<TD align="center">Voucher Date <FONT color="#ff0000">*</FONT>
										<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ErrorMessage="Please Enter Voucher Date"
											ControlToValidate="txtDate" ForeColor="White">*</asp:requiredfieldvalidator></TD>
									<TD colSpan="2"><asp:textbox id="txtDate" runat="server" CssClass="Fontstyle" Width=70px BorderStyle="Groove"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtDate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
												border="0"></A></TD>
								</TR>
								<tr>
									<td align="center"><FONT color="#990066">Account Name</FONT></td>
									<td align="center"><FONT color="#990066">Amount</FONT></td>
									<td>&nbsp;</td>
									<td align="center"><FONT color="#990066">Account Name</FONT></td>
									<td align="center"><FONT color="#990066">Amount</FONT></td>
									<td></td>
								</tr>
								<tr>
									<td><input class="TextBoxStyle" onkeypress="return GetAnyNumber(this, event);" id="dropAccName1"
											onkeyup="search3(this,document.Form1.DropAccountName1,document.Form1.texthiddenprod.value),arrowkeydown(this,event,document.Form1.DropAccountName1,document.Form1.texthiddenprod),Selectbyenter(document.Form1.DropAccountName1,event,document.Form1.dropAccName1,document.Form1.dropAccName2),setValue(document.Form1.dropAccName1)"
											style="Z-INDEX: 10; VISIBILITY: visible; WIDTH: 180px; HEIGHT: 18px" onclick="search1(document.Form1.DropAccountName1,document.Form1.texthiddenprod),dropshow(document.Form1.DropAccountName1)"
											value="Select" name="dropAccName1" runat="server"><input style="HEIGHT: 18px" class="ComboBoxSearchButtonStyle" onclick="search1(document.Form1.DropAccountName1,document.Form1.texthiddenprod),dropshow(document.Form1.DropAccountName1)"
											readOnly type="text" name="temp"><br>
										<div id="Layer1" style="Z-INDEX: 2; POSITION: absolute"><select class="ListBoxBorderStyle" onkeypress="Selectbyenter(this,event,document.Form1.dropAccName1,document.Form1.dropAccName2),setValue(document.Form1.dropAccName1)"
												id="DropAccountName1" ondblclick="select(this,document.Form1.dropAccName1),setValue(document.Form1.dropAccName1)" onkeyup="arrowkeyselect(this,event,document.Form1.dropAccName2,document.Form1.dropAccName1),setValue(document.Form1.dropAccName1)"
												style="Z-INDEX: 10; VISIBILITY: hidden; WIDTH: 200px; HEIGHT: 0px" multiple name="DropAccountName1" onfocusout="HideList(this,document.Form1.dropAccName1)"></select></div>
										<INPUT class="dropdownlist" id="txtAccName1" style="WIDTH: 124px; HEIGHT: 22px" type="hidden"
											size="15" name="Hidden1" runat="server"></td>
									<td><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtAmount1" onblur="return calcTotal();"
											runat="server" Width="84px" BorderStyle="Groove" CssClass="TextBoxForms"></asp:textbox></td>
									<td><asp:dropdownlist id="dropType_1" CssClass="ComboBox" runat="server" Width="40px" onChange="return changeType(this);">
											<asp:ListItem Value="Dr">Dr</asp:ListItem>
											<asp:ListItem Value="Cr">Cr</asp:ListItem>
										</asp:dropdownlist></td>
									<td><input class="TextBoxStyle" onkeypress="return GetAnyNumber(this, event);" id="dropAccName5"
											onkeyup="search3(this,document.Form1.DropAccountName5,document.Form1.texthiddenprod.value),arrowkeydown(this,event,document.Form1.DropAccountName5,document.Form1.texthiddenprod),Selectbyenter(document.Form1.DropAccountName5,event,document.Form1.dropAccName5,document.Form1.dropAccName2),setValue(document.Form1.dropAccName5)"
											style="Z-INDEX: 10; VISIBILITY: visible; WIDTH: 180px; HEIGHT: 18px" onclick="search1(document.Form1.DropAccountName5,document.Form1.texthiddenprod),dropshow(document.Form1.DropAccountName5)"
											value="Select" name="dropAccName5" runat="server"><input style="HEIGHT: 18px" class="ComboBoxSearchButtonStyle" onclick="search1(document.Form1.DropAccountName5,document.Form1.texthiddenprod),dropshow(document.Form1.DropAccountName5)"
											readOnly type="text" name="temp"><br>
										<div id="Layer5" style="Z-INDEX: 2; POSITION: absolute"><select class="ListBoxBorderStyle" onkeypress="Selectbyenter(this,event,document.Form1.dropAccName5,document.Form1.dropAccName2),setValue(document.Form1.dropAccName5)"
												id="DropAccountName5" ondblclick="select(this,document.Form1.dropAccName5),setValue(document.Form1.dropAccName5)" onkeyup="arrowkeyselect(this,event,document.Form1.dropAccName2,document.Form1.dropAccName5),setValue(document.Form1.dropAccName5)"
												style="Z-INDEX: 10; VISIBILITY: hidden; WIDTH: 200px; HEIGHT: 0px" multiple name="DropAccountName5" onfocusout="HideList(this,document.Form1.dropAccName5)"></select></div>
										<INPUT class="dropdownlist" id="txtAccName5" style="WIDTH: 124px; HEIGHT: 22px" type="hidden"
											size="15" name="Hidden1" runat="server"></td>
									<td><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtAmount5" onblur="return calcTotal();"
											runat="server" Width="84px" BorderStyle="Groove" CssClass="TextBoxForms"></asp:textbox></td>
									<td><asp:dropdownlist id="dropType_5" CssClass=ComboBox runat="server" Width="40px" onChange="return changeType(this);">
											<asp:ListItem Value="Cr">Cr</asp:ListItem>
											<asp:ListItem Value="Dr">Dr</asp:ListItem>
										</asp:dropdownlist></td>
								</tr>
								<tr>
									<td><input class="TextBoxStyle" onkeypress="return GetAnyNumber(this, event);" id="dropAccName2"
											onkeyup="search3(this,document.Form1.DropAccountName2,document.Form1.texthiddenprod.value),arrowkeydown(this,event,document.Form1.DropAccountName2,document.Form1.texthiddenprod),Selectbyenter(document.Form1.DropAccountName2,event,document.Form1.dropAccName2,document.Form1.dropAccName3)"
											style="Z-INDEX: 10; VISIBILITY: visible; WIDTH: 180px; HEIGHT: 18px" onclick="search1(document.Form1.DropAccountName2,document.Form1.texthiddenprod),dropshow(document.Form1.DropAccountName2)"
											value="Select" name="dropAccName2" runat="server"><input style="HEIGHT: 18px" class="ComboBoxSearchButtonStyle" onclick="search1(document.Form1.DropAccountName2,document.Form1.texthiddenprod),dropshow(document.Form1.DropAccountName2)"
											readOnly type="text" name="temp"><br>
										<div id="Layer2" style="Z-INDEX: 2; POSITION: absolute"><select class="ListBoxBorderStyle" onkeypress="Selectbyenter(this,event,document.Form1.dropAccName2,document.Form1.dropAccName3)"
												id="DropAccountName2" ondblclick="select(this,document.Form1.dropAccName2)" onkeyup="arrowkeyselect(this,event,document.Form1.dropAccName3,document.Form1.dropAccName2)"
												style="Z-INDEX: 10; VISIBILITY: hidden; WIDTH: 200px; HEIGHT: 0px" multiple name="DropAccountName2" onfocusout="HideList(this,document.Form1.dropAccName2)"></select></div>
										<INPUT class="dropdownlist" id="txtAccName2" style="WIDTH: 124px; HEIGHT: 22px" type="hidden"
											size="15" name="Hidden1" runat="server"></td>
									<td><asp:textbox CssClass="TextBoxForms" onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtAmount2" onblur="return calcTotal();"
											runat="server" Width="84px" BorderStyle="Groove" ></asp:textbox></td>
									<td><asp:dropdownlist id="dropType_2" CssClass="ComboBox" runat="server" Width="40px" onChange="return changeType(this);">
											<asp:ListItem Value="Dr">Dr</asp:ListItem>
											<asp:ListItem Value="Cr">Cr</asp:ListItem>
										</asp:dropdownlist></td>
									<td><input class="TextBoxStyle" onkeypress="return GetAnyNumber(this, event);" id="dropAccName6"
											onkeyup="search3(this,document.Form1.DropAccountName6,document.Form1.texthiddenprod.value),arrowkeydown(this,event,document.Form1.DropAccountName6,document.Form1.texthiddenprod),Selectbyenter(document.Form1.DropAccountName6,event,document.Form1.dropAccName6,document.Form1.dropAccName3)"
											style="Z-INDEX: 10; VISIBILITY: visible; WIDTH: 180px; HEIGHT: 18px" onclick="search1(document.Form1.DropAccountName6,document.Form1.texthiddenprod),dropshow(document.Form1.DropAccountName6)"
											value="Select" name="dropAccName6" runat="server"><input style="HEIGHT: 18px" class="ComboBoxSearchButtonStyle" onclick="search1(document.Form1.DropAccountName6,document.Form1.texthiddenprod),dropshow(document.Form1.DropAccountName6)"
											readOnly type="text" name="temp"><br>
										<div id="Layer6" style="Z-INDEX: 2; POSITION: absolute"><select class="ListBoxBorderStyle" onkeypress="Selectbyenter(this,event,document.Form1.dropAccName6,document.Form1.dropAccName3)"
												id="DropAccountName6" ondblclick="select(this,document.Form1.dropAccName6)" onkeyup="arrowkeyselect(this,event,document.Form1.dropAccName3,document.Form1.dropAccName6)"
												style="Z-INDEX: 10; VISIBILITY: hidden; WIDTH: 200px; HEIGHT: 0px" multiple name="DropAccountName6" onfocusout="HideList(this,document.Form1.dropAccName6)"></select></div>
										<INPUT class="dropdownlist" id="txtAccName6" style="WIDTH: 124px; HEIGHT: 22px" type="hidden"
											size="15" name="Hidden1" runat="server"></td>
									<td><asp:textbox CssClass="TextBoxForms" onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtAmount6" onblur="return calcTotal();"
											runat="server" Width="84px" BorderStyle="Groove"></asp:textbox></td>
									<td><asp:dropdownlist id="dropType_6" CssClass="ComboBox" runat="server" Width="40px" onChange="return changeType(this);">
											<asp:ListItem Value="Cr">Cr</asp:ListItem>
											<asp:ListItem Value="Dr">Dr</asp:ListItem>
										</asp:dropdownlist></td>
								</tr>
								<tr>
									<td><input class="TextBoxStyle" onkeypress="return GetAnyNumber(this, event);" id="dropAccName3"
											onkeyup="search3(this,document.Form1.DropAccountName3,document.Form1.texthiddenprod.value),arrowkeydown(this,event,document.Form1.DropAccountName3,document.Form1.texthiddenprod),Selectbyenter(document.Form1.DropAccountName3,event,document.Form1.dropAccName3,document.Form1.dropAccName4)"
											style="Z-INDEX: 10; VISIBILITY: visible; WIDTH: 180px; HEIGHT: 18px" onclick="search1(document.Form1.DropAccountName3,document.Form1.texthiddenprod),dropshow(document.Form1.DropAccountName3)"
											value="Select" name="dropAccName3" runat="server"><input style="HEIGHT: 18px" class="ComboBoxSearchButtonStyle" onclick="search1(document.Form1.DropAccountName3,document.Form1.texthiddenprod),dropshow(document.Form1.DropAccountName3)"
											readOnly type="text" name="temp"><br>
										<div id="Layer3" style="Z-INDEX: 2; POSITION: absolute"><select class="ListBoxBorderStyle" onkeypress="Selectbyenter(this,event,document.Form1.dropAccName3,document.Form1.dropAccName4)"
												id="DropAccountName3" ondblclick="select(this,document.Form1.dropAccName3)" onkeyup="arrowkeyselect(this,event,document.Form1.dropAccName4,document.Form1.dropAccName3)"
												style="Z-INDEX: 10; VISIBILITY: hidden; WIDTH: 200px; HEIGHT: 0px" multiple name="DropAccountName3" onfocusout="HideList(this,document.Form1.dropAccName3)"></select></div>
										<INPUT class="dropdownlist" id="txtAccName3" style="WIDTH: 124px; HEIGHT: 22px" type="hidden"
											size="15" runat="server"></td>
									<td><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtAmount3" onblur="return calcTotal();"
											runat="server" Width="84px" BorderStyle="Groove" CssClass="TextBoxForms"></asp:textbox></td>
									<td><asp:dropdownlist id="dropType_3" CssClass="ComboBox" runat="server" Width="40px" onChange="return changeType(this);">
											<asp:ListItem Value="Dr">Dr</asp:ListItem>
											<asp:ListItem Value="Cr">Cr</asp:ListItem>
										</asp:dropdownlist></td>
									<td><input class="TextBoxStyle" onkeypress="return GetAnyNumber(this, event);" id="dropAccName7"
											onkeyup="search3(this,document.Form1.DropAccountName7,document.Form1.texthiddenprod.value),arrowkeydown(this,event,document.Form1.DropAccountName7,document.Form1.texthiddenprod),Selectbyenter(document.Form1.DropAccountName7,event,document.Form1.dropAccName7,document.Form1.dropAccName4)"
											style="Z-INDEX: 10; VISIBILITY: visible; WIDTH: 180px; HEIGHT: 18px" onclick="search1(document.Form1.DropAccountName7,document.Form1.texthiddenprod),dropshow(document.Form1.DropAccountName7)"
											value="Select" name="dropAccName7" runat="server"><input style="HEIGHT: 18px" class="ComboBoxSearchButtonStyle" onclick="search1(document.Form1.DropAccountName7,document.Form1.texthiddenprod),dropshow(document.Form1.DropAccountName7)"
											readOnly type="text" name="temp"><br>
										<div id="Layer7" style="Z-INDEX: 2; POSITION: absolute"><select class="ListBoxBorderStyle" onkeypress="Selectbyenter(this,event,document.Form1.dropAccName7,document.Form1.dropAccName4)"
												id="DropAccountName7" ondblclick="select(this,document.Form1.dropAccName7)" onkeyup="arrowkeyselect(this,event,document.Form1.dropAccName4,document.Form1.dropAccName7)"
												style="Z-INDEX: 10; VISIBILITY: hidden; WIDTH: 200px; HEIGHT: 0px" multiple name="DropAccountName7" onfocusout="HideList(this,document.Form1.dropAccName7)"></select></div>
										<INPUT class="dropdownlist" id="txtAccName7" style="WIDTH: 124px; HEIGHT: 22px" type="hidden"
											size="15" name="Hidden1" runat="server"></td>
									<td><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtAmount7" onblur="return calcTotal();"
											runat="server" Width="84px" BorderStyle="Groove" CssClass="TextBoxForms"></asp:textbox></td>
									<td><asp:dropdownlist id="dropType_7" CssClass="ComboBox" runat="server" Width="40px" onChange="return changeType(this);">
											<asp:ListItem Value="Cr">Cr</asp:ListItem>
											<asp:ListItem Value="Dr">Dr</asp:ListItem>
										</asp:dropdownlist></td>
								</tr>
								<tr>
									<td><input class="TextBoxStyle" onkeypress="return GetAnyNumber(this, event);" id="dropAccName4"
											onkeyup="search3(this,document.Form1.DropAccountName4,document.Form1.texthiddenprod.value),arrowkeydown(this,event,document.Form1.DropAccountName4,document.Form1.texthiddenprod),Selectbyenter(document.Form1.DropAccountName4,event,document.Form1.dropAccName4,document.Form1.dropAccName8)"
											style="Z-INDEX: 10; VISIBILITY: visible; WIDTH: 180px; HEIGHT: 18px" onclick="search1(document.Form1.DropAccountName4,document.Form1.texthiddenprod),dropshow(document.Form1.DropAccountName4)"
											value="Select" name="dropAccName4" runat="server"><input style="HEIGHT: 18px" class="ComboBoxSearchButtonStyle" onclick="search1(document.Form1.DropAccountName4,document.Form1.texthiddenprod),dropshow(document.Form1.DropAccountName4)"
											readOnly type="text" name="temp"><br>
										<div id="Layer4" style="Z-INDEX: 2; POSITION: absolute"><select class="ListBoxBorderStyle" onkeypress="Selectbyenter(this,event,document.Form1.dropAccName4,document.Form1.dropAccName8)"
												id="DropAccountName4" ondblclick="select(this,document.Form1.dropAccName4)" onkeyup="arrowkeyselect(this,event,document.Form1.dropAccName8,document.Form1.dropAccName4)"
												style="Z-INDEX: 10; VISIBILITY: hidden; WIDTH: 200px; HEIGHT: 0px" multiple name="DropAccountName4" onfocusout="HideList(this,document.Form1.dropAccName4)"></select></div>
										<INPUT class="dropdownlist" id="txtAccName4" style="WIDTH: 124px; HEIGHT: 22px" type="hidden"
											size="15" name="Hidden1" runat="server"></td>
									<td><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtAmount4" onblur="return calcTotal();"
											runat="server" Width="84px" BorderStyle="Groove" CssClass="TextBoxForms"></asp:textbox></td>
									<td><asp:dropdownlist id="dropType_4" CssClass="ComboBox" runat="server" Width="40px" onChange="return changeType(this);">
											<asp:ListItem Value="Dr">Dr</asp:ListItem>
											<asp:ListItem Value="Cr">Cr</asp:ListItem>
										</asp:dropdownlist></td>
									<td><input class="TextBoxStyle" onkeypress="return GetAnyNumber(this, event);" id="dropAccName8"
											onkeyup="search3(this,document.Form1.DropAccountName8,document.Form1.texthiddenprod.value),arrowkeydown(this,event,document.Form1.DropAccountName8,document.Form1.texthiddenprod),Selectbyenter(document.Form1.DropAccountName8,event,document.Form1.dropAccName8,document.Form1.btnSave)"
											style="Z-INDEX: 10; VISIBILITY: visible; WIDTH: 180px; HEIGHT: 18px" onclick="search1(document.Form1.DropAccountName8,document.Form1.texthiddenprod),dropshow(document.Form1.DropAccountName8)"
											value="Select" name="dropAccName8" runat="server"><input style="HEIGHT: 18px" class="ComboBoxSearchButtonStyle" onclick="search1(document.Form1.DropAccountName8,document.Form1.texthiddenprod),dropshow(document.Form1.DropAccountName8)"
											readOnly type="text" name="temp"><br>
										<div id="Layer8" style="Z-INDEX: 2; POSITION: absolute"><select class="ListBoxBorderStyle" onkeypress="Selectbyenter(this,event,document.Form1.dropAccName8,document.Form1.btnSave)"
												id="DropAccountName8" ondblclick="select(this,document.Form1.dropAccName8)" onkeyup="arrowkeyselect(this,event,document.Form1.btnSave,document.Form1.dropAccName8)"
												style="Z-INDEX: 10; VISIBILITY: hidden; WIDTH: 200px; HEIGHT: 0px" multiple name="DropAccountName8" onfocusout="HideList(this,document.Form1.dropAccName8)"></select></div>
										<INPUT class="dropdownlist" id="txtAccName8" style="WIDTH: 124px; HEIGHT: 22px" type="hidden"
											size="15" name="Hidden1" runat="server"></td>
									<td><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtAmount8" onblur="return calcTotal();"
											runat="server" Width="84px" BorderStyle="Groove" CssClass="TextBoxForms"></asp:textbox></td>
									<td><asp:dropdownlist id="dropType_8" CssClass="ComboBox" runat="server" Width="40px" onChange="return changeType(this);">
											<asp:ListItem Value="Cr">Cr</asp:ListItem>
											<asp:ListItem Value="Dr">Dr</asp:ListItem>
										</asp:dropdownlist></td>
								</tr>
								<tr>
									<td align="right"><b>Total CR&nbsp;: </b>
									</td>
									<td><asp:textbox id="txtLCr" runat="server" Width="84px" BorderStyle="Groove" CssClass="TextBoxForms"></asp:textbox></td>
									<td></td>
									<td></td>
									<td><asp:textbox id="txtRCr" runat="server" Width="84px" BorderStyle="Groove" CssClass="TextBoxForms"></asp:textbox></td>
									<td></td>
								</tr>
								<tr>
									<td align="right"><b>Total DR : </b>
									</td>
									<td><asp:textbox id="txtLDr" runat="server" Width="84px" BorderStyle="Groove" CssClass="TextBoxForms"></asp:textbox></td>
									<td></td>
									<td></td>
									<td><asp:textbox id="txtRDr" runat="server" Width="84px" BorderStyle="Groove" CssClass="TextBoxForms"></asp:textbox></td>
									<td></td>
								</tr>
								<tr>
									<TD vAlign="top" colSpan="3"><FONT color="#ff0000"><b><FONT color="black">Narration:&nbsp; </FONT>
											</b>&nbsp;
											<asp:textbox onkeypress="CheckLength(this);" id="txtNarration" runat="server" Width="320px" BorderStyle="Groove"
												TextMode="MultiLine" MaxLength="10" CssClass="TextBoxForms"></asp:textbox></FONT></TD>
									<td align="right" colSpan="3">
										<asp:button id="btnAdd" runat="server" Width="75px" Text="Save" CssClass="formbuttonstyle"></asp:button>
										<asp:button id="btnEdit" runat="server" Width="75px" Text="Edit" CssClass="formbuttonstyle"></asp:button>
										<asp:button id="btnDelete" runat="server" Width="75px" CssClass="formbuttonstyle" Text="Delete"></asp:button>
										<asp:button id="btnPrint" runat="server" Width="75px" Text="Print" CssClass="formbuttonstyle"></asp:button></td>
								</tr>
							</TBODY>
						</TABLE>
						<asp:validationsummary id="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD>
				</TR>
			</TABLE>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0"
				width="174" scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
