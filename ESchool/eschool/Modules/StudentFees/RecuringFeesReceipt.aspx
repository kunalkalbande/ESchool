<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="RecuringFeesReceipt.aspx.cs" AutoEventWireup="false" Inherits="eschool.StudentFees.RecuringFeesReceipt" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Recuring Fees Receipt</title><!--
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
		<script language="javascript" id="Validations" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
		<script language="javascript" id="Validations1" src="../../shareables/jsfiles/Searchdrop.js"></script>
		<script language="javascript">
	// this method use to show bank dropdown.
	function Other(t)
	{
		if(t.name=="Dropbankdr")
		{
		 var index=t.selectedIndex
	     var name = t.options[index].text
		    if(name=="Other")
			{ 
				document.all.txtBankdrftOther.style.visibility="visible"
			}
			else
			{
				document.all.txtBankdrftOther.style.visibility="hidden"
			}
		}
		else if(t.name=="Dropbankch")
		{
		 var index=t.selectedIndex
	     var name = t.options[index].text
		    if(name=="Other")
			{ 
				document.all.txtBankchqOther.style.visibility="visible"
			}
			else
			{
				document.all.txtBankchqOther.style.visibility="hidden"
			}
		}
			
	}
	
		</script>
	</HEAD>
	<body>
		<form id="RecuringFeesReceipt" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><input id="TempCaution" style="WIDTH: 1px" type="hidden" value="0" name="TempCaution" runat="server">
			<input id="TempYearly" style="WIDTH: 1px" type="hidden" value="0" name="TempYearly" runat="server">
			<input id="TempSection" style="WIDTH: 1px" type="hidden" name="TempSection" runat="server">
			<input id="txtBankname" style="WIDTH: 1px" type="hidden" name="FeesDec" runat="server">
			<input id="TempLate" style="WIDTH: 1px" type="hidden" value="0" name="TempLate" runat="server">
			<input id="Tempanual" style="WIDTH: 1px" type="hidden" value="0" name="Tempanual" runat="server">
			<input id="TempDevlop" style="WIDTH: 1px" type="hidden" value="0" name="TempDevlop" runat="server">
			<input id="Tempdiary" style="WIDTH: 1px" type="hidden" value="0" name="Tempdiary" runat="server">
			<input id="TempTuti" style="WIDTH: 1px" type="hidden" value="0" name="TempTuti" runat="server">
			<input id="TempCompu" style="WIDTH: 1px" type="hidden" value="0" name="TempCompu" runat="server">
			<input id="TempHouse" style="WIDTH: 1px" type="hidden" value="0" name="TempHouse" runat="server">
			<input id="TempScie" style="WIDTH: 1px" type="hidden" value="0" name="TempScie" runat="server">
			<input id="TempActi" style="WIDTH: 1px" type="hidden" value="0" name="TempActi" runat="server">
			<input id="TempTrans" style="WIDTH: 1px" type="hidden" value="0" name="TempTrans" runat="server">
			<input id="TempGemes" style="WIDTH: 1px" type="hidden" value="0" name="TempGemes" runat="server">
			<input id="TempAdmiss" style="WIDTH: 1px" type="hidden" value="0" name="TempAdmiss" runat="server">
			<input id="texthidden" style="WIDTH: 1px" type="hidden" name="texthidden" runat="server">
			<table height="228" cellSpacing="0" cellPadding="0" width="778" align="center">
				<tr>
					<td align="center"><asp:label id="Label3" runat="server" Font-Bold="True"></asp:label></td>
				</tr>
				<tr>
					<td vAlign="top" align="center"><b>RECURING FEES RECEIPT</b>
						<TABLE cellSpacing="1" cellPadding="0" align="center" borderColorLight="#663300" border="5">
							<TBODY>
								<TR>
									<TD colSpan="4"><asp:label id="Label4" runat="server" ForeColor="Red">&nbsp;asterisk (*) fields are mandatory</asp:label></TD>
								</TR>
								<tr>
									<td>&nbsp;Fee Receipt ID</td>
									<td><asp:dropdownlist CssClass="ComboBox" id="DropFeeID" Runat="server" AutoPostBack="True"></asp:dropdownlist><asp:comparevalidator id="Comparevalidator1" runat="server" ControlToValidate="DropFeeID" ErrorMessage="Please select the Fee Receipt ID"
											Operator="NotEqual" ValueToCompare="Select">*</asp:comparevalidator>&nbsp;<asp:label id="lblFeeID" ForeColor="blue" Runat="server" CssClass="FontStyle"></asp:label>&nbsp;
										<asp:button id="btnEdit" Runat="server" CssClass="formeditbuttonstyle" Text="..." CausesValidation="False"
											tooltip="Edit"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
									<td>&nbsp;Student ID&nbsp;<FONT color="#ff0033" size="1">*</FONT></td>
									<td><asp:textbox id="DropStudentID" BorderStyle="Groove" Runat="server" CssClass="TextBoxForms" AutoPostBack="True"
											MaxLength="6" Width="70"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" ControlToValidate="DropStudentID" ErrorMessage="You Must Enter StudentID">*</asp:requiredfieldvalidator>&nbsp;&nbsp;Class&nbsp;&nbsp;
										<asp:textbox id="DropClass" BorderStyle="Groove" Runat="server" CssClass="TextBoxForms" Width="55px"
											Enabled="False"></asp:textbox>&nbsp;<asp:textbox CssClass="TextBoxForms" id="txtSection" BorderStyle="Groove" Runat="server" Width="30px"
											Enabled="False"></asp:textbox></td>
								</tr>
								<tr>
									<TD>&nbsp;Student Name</TD>
									<TD><asp:textbox id="TxtFname" BorderStyle="Groove" runat="server" CssClass="TextBoxForms" Width="150px"
											Enabled="False" ></asp:textbox></TD>
									<TD>&nbsp;Stream</TD>
									<TD><asp:textbox id="TextStream" BorderStyle="Groove" runat="server" CssClass="TextBoxForms" MaxLength="8"
											Width="110px" Enabled="False" ></asp:textbox>&nbsp;<asp:textbox id="TextComputer" BorderStyle="Groove" runat="server" CssClass="TextBoxForms" MaxLength="7"
											Width="100px" Enabled="False"></asp:textbox></TD>
								</tr>
								<TR>
									<TD>&nbsp;Father Name</TD>
									<TD><asp:textbox id="txtFathername" BorderStyle="Groove" runat="server" CssClass="TextBoxForms" MaxLength="9"
											Width="150px" Enabled="False"></asp:textbox></TD>
									<td>&nbsp;Scategory / Rank</td>
									<td><asp:textbox id="txtscat" BorderStyle="Groove" Runat="server" CssClass="TextBoxForms" Width="110px"
											Enabled="False"></asp:textbox>&nbsp;<asp:textbox id="txtrank" BorderStyle="Groove" Runat="server" CssClass="TextBoxForms" Width="100px"
											Enabled="False"></asp:textbox></td>
								</TR>
								<tr>
									<td style="HEIGHT: 14px">&nbsp;Fees Start From&nbsp;<FONT color="#ff0033" size="1">*</FONT></td>
									<td style="HEIGHT: 14px"><asp:dropdownlist id="dropselect" Runat="server" CssClass="ComboBox" AutoPostBack="True"></asp:dropdownlist>&nbsp;
										<asp:dropdownlist id="Dropyearfrom" Runat="server" CssClass="ComboBox" AutoPostBack="True"></asp:dropdownlist>&nbsp;
										<asp:comparevalidator id="Comparevalidator5" runat="server" ControlToValidate="dropselect" ErrorMessage="Please select the Instalation Of Fee Type"
											Operator="NotEqual" ValueToCompare="Select">*</asp:comparevalidator></td>
									<td style="HEIGHT: 14px">&nbsp;To</td>
									<td style="HEIGHT: 14px"><asp:dropdownlist id="DropTo" Runat="server" CssClass="ComboBox" AutoPostBack="True">
											<asp:ListItem Value="Select">Select</asp:ListItem>
										</asp:dropdownlist><asp:dropdownlist id="Dropyearto" Runat="server" CssClass="FontStyle" AutoPostBack="True"></asp:dropdownlist>&nbsp;
									</td>
								</tr>
								<TR>
									<td colSpan="4">
										<table cellSpacing="1" cellPadding="0" width="100%" align="center" borderColorLight="#663300"
											border="1">
											<tr>
												<TD>&nbsp;Diary Fee</TD>
												<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, true,true);" id="txtdf"
														BorderStyle="Groove" Runat="server" CssClass="TextBoxForms" AutoPostBack="False" MaxLength="9"
														Width="80px" Enabled="True" onchange="AdjustAmount(this)"></asp:textbox></TD>
												<TD>&nbsp;Tution Fee</TD>
												<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, true,true);" id="txttf"
														BorderStyle="Groove" Runat="server" CssClass="TextBoxForms" AutoPostBack="False" MaxLength="9"
														Width="80px" Enabled="True" onchange="AdjustAmount(this)"></asp:textbox></TD>
												<TD>&nbsp;Computer Fee</TD>
												<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, true,true);" id="txtcf"
														BorderStyle="Groove" Runat="server" CssClass="TextBoxForms" AutoPostBack="False" MaxLength="9"
														Width="80px" Enabled="True" onchange="AdjustAmount(this)"></asp:textbox></TD>
											</tr>
											<TR>
												<TD>&nbsp;Science Fee</TD>
												<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, true,true);" id="txtsf"
														BorderStyle="Groove" Runat="server" CssClass="TextBoxForms" AutoPostBack="False" MaxLength="9"
														Width="80px" Enabled="True" onchange="AdjustAmount(this)"></asp:textbox></TD>
												<TD>&nbsp;Activity Fee</TD>
												<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, true,true);" id="txtaf"
														BorderStyle="Groove" Runat="server" CssClass="TextBoxForms" AutoPostBack="False" MaxLength="9"
														Width="80px" Enabled="True" onchange="AdjustAmount(this)"></asp:textbox></TD>
												<TD>&nbsp;Games Fee</TD>
												<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, true,true);" id="txtgf"
														BorderStyle="Groove" Runat="server" CssClass="TextBoxForms" AutoPostBack="False" MaxLength="9"
														Width="80px" Enabled="True" onchange="AdjustAmount(this)"></asp:textbox></TD>
											</TR>
											<TR>
												<TD>&nbsp;Late Fee</TD>
												<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, true,true);" id="txtlf" BorderStyle="Groove"
														Runat="server" CssClass="TextBoxForms" AutoPostBack="False" MaxLength="9" Width="80px" onchange="AdjustAmount(this)"></asp:textbox></TD>
												<TD>&nbsp;Transport Fee</TD>
												<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, true,true);" id="txttrf" BorderStyle="Groove"
														Runat="server" CssClass="TextBoxForms" AutoPostBack="False" MaxLength="9" Width="80px" Enabled="True"
														onchange="AdjustAmount(this)" ></asp:textbox></TD>
												<TD>&nbsp;Admission Fee</TD>
												<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, true,true);" id="txtadf"
														BorderStyle="Groove" Runat="server" CssClass="TextBoxForms" AutoPostBack="False" MaxLength="9"
														Width="80px" Enabled="True" onchange="AdjustAmount(this)"></asp:textbox></TD>
											</TR>
											<tr>
												<TD>&nbsp;Security Fee</TD>
												<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, true,true);" id="txtcmf"
														BorderStyle="Groove" Runat="server" CssClass="TextBoxForms" AutoPostBack="False" MaxLength="9"
														Width="80px" Enabled="True"></asp:textbox></TD>
												<TD>&nbsp;Annual Fee</TD>
												<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, true,true);" id="txtanf"
														BorderStyle="Groove" Runat="server" CssClass="TextBoxForms" AutoPostBack="False" MaxLength="9"
														Width="80px" Enabled="True" onchange="AdjustAmount(this)"></asp:textbox></TD>
												<TD>&nbsp;Env. Fee</TD>
												<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, true,true);" id="txtef"
														BorderStyle="Groove" Runat="server" CssClass="TextBoxForms" AutoPostBack="False" MaxLength="9"
														Width="80px" Enabled="True" onchange="AdjustAmount(this)"></asp:textbox></TD>
											</tr>
											<TR>
												<TD>&nbsp;House Fee</TD>
												<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, true,true);" id="txthf"
														BorderStyle="Groove" Runat="server" CssClass="TextBoxForms" AutoPostBack="False" MaxLength="9"
														Width="80px" Enabled="True" onchange="AdjustAmount(this)"></asp:textbox></TD>
												<TD>&nbsp;Fees Amount<FONT color="#ff0033">*</FONT></TD>
												<TD><asp:textbox id="TxtAmount" BorderStyle="Groove" runat="server" CssClass="TextBoxForms"
														Width="80px" Enabled="False"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" ControlToValidate="TxtAmount" ErrorMessage="You Must Enter Fees Amount">*</asp:requiredfieldvalidator><asp:comparevalidator id="Comparevalidator3" Runat="server" ControlToValidate="TxtAmt" ErrorMessage="Fees amount must be numeric"
														Operator="DataTypeCheck" Type="Double" Display="Dynamic">*</asp:comparevalidator></TD>
												<td>&nbsp;Paid&nbsp;Amount</td>
												<td><asp:textbox id="txtamt" BorderStyle="Groove" Runat="server" CssClass="TextBoxForms"
														AutoPostBack="False" Width="80"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator4" runat="server" ControlToValidate="txtamt" ErrorMessage="You Must Enter Amount">*</asp:requiredfieldvalidator></td>
											</TR>
										</table>
									</td>
								</TR>
								<tr>
									<td>&nbsp;Mode Of Payment</td>
									<td><asp:dropdownlist id="dropmop" Runat="server" CssClass="ComboBox" AutoPostBack="True">
											<asp:ListItem Value="By Cheque">By Cheque</asp:ListItem>
											<asp:ListItem Value="By Draft">By Draft</asp:ListItem>
											<asp:ListItem Value="By Cash">By Cash</asp:ListItem>
										</asp:dropdownlist></td>
									<TD>&nbsp;Start Period Date</TD>
									<TD><asp:textbox id="TxtPeriod" CssClass="Fontstyle" Width="70px" BorderStyle="Groove"
											runat="server"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.RecuringFeesReceipt.TxtPeriod);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
												border="0"></A></TD>
								</tr>
								<asp:panel id="PanCheque" Runat="server">
									<TR>
										<TD>&nbsp;Cheque No&nbsp;<FONT color="#ff0033" size="1">*</FONT></TD>
										<TD>
											<asp:textbox onkeypress="return GetOnlyNumbers(this, event, true,true);" id="txtchno" BorderStyle="Groove"
												Runat="server" CssClass="TextBoxForms" Width="80" MaxLength="8"></asp:textbox>
											<asp:requiredfieldvalidator id="Requiredfieldvalidator8" runat="server" ErrorMessage="Please Enter Cheque No"
												ControlToValidate="txtchno">*</asp:requiredfieldvalidator></TD>
										<TD>&nbsp;Student Bank&nbsp;<FONT color="#ff0033" size="1">*</FONT></TD>
										<TD>
											<asp:dropdownlist id="Dropbankch" runat="server" CssClass="ComboBox" onchange="Other(this)">
												<asp:ListItem Value="Select">Select</asp:ListItem>
											</asp:dropdownlist>
											<asp:comparevalidator id="Comparevalidator2" Runat="server" ValueToCompare="Select" Operator="NotEqual"
												ErrorMessage="Please Select Student Bank" ControlToValidate="Dropbankch" Display="Dynamic" Type="String">*</asp:comparevalidator><INPUT class="TextBoxforms" onkeypress="return GetAnyNumber(this, event);" id="txtBankchqOther"
												style="VISIBILITY: hidden" type="text" maxLength="30" name="txtBankchqOther">
										</TD>
									</TR>
									<TR>
										<TD>&nbsp;Cheque Date</TD>
										<TD>
											<asp:textbox id="txtchDate" BorderStyle="Groove" Runat="server" CssClass="Fontstyle" Width="70px"
												></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.RecuringFeesReceipt.txtchDate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
													border="0"></A>
											<asp:requiredfieldvalidator id="Requiredfieldvalidator5" runat="server" ErrorMessage="Please Enter Cheque Date"
												ControlToValidate="txtchDate">*</asp:requiredfieldvalidator></TD>
										<TD>&nbsp;Current Date</TD>
										<TD>
											<asp:textbox id="TxtcurDate" BorderStyle="Groove" runat="server" CssClass="Fontstyle" Width="70px"
												></asp:textbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;Bank Name&nbsp;<FONT color="#ff0033" size="1">*</FONT></TD>
										<TD colSpan="3">
											<asp:dropdownlist id="DropBankChque" runat="server" CssClass="ComboBox">
												<asp:ListItem Value="Select">Select</asp:ListItem>
											</asp:dropdownlist>
											<asp:comparevalidator id="Comparevalidator4" Runat="server" ValueToCompare="Select" Operator="NotEqual"
												ErrorMessage="Please Select The Bank Name" ControlToValidate="DropBankChque" Display="Dynamic" Type="String">*</asp:comparevalidator></TD>
									</TR>
								</asp:panel>
								<asp:panel id="PanDraft" Runat="server">
									<TR>
										<TD>&nbsp;Draft No
											<asp:requiredfieldvalidator id="Requiredfieldvalidator6" runat="server" ControlToValidate="txtdraftno" ErrorMessage="Please  Enter Draft No">*</asp:requiredfieldvalidator></TD>
										<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, true,true);" id="txtdraftno" BorderStyle="Groove"
												Runat="server" CssClass="TextBoxForms" MaxLength="8" Width="80"></asp:textbox></TD>
										<TD>&nbsp;Student Bank
										</TD>
										<TD><asp:dropdownlist id="Dropbankdr" runat="server" CssClass="ComboBox" onchange="Other(this)">
												<asp:ListItem Value="Select">Select</asp:ListItem>
											</asp:dropdownlist><asp:comparevalidator id="Comparevalidator6" Runat="server" ControlToValidate="Dropbankdr" ErrorMessage="Please Select Student Bank"
												Operator="NotEqual" ValueToCompare="Select" Type="String" Display="Dynamic">*</asp:comparevalidator>
											<input onkeypress="return GetAnyNumber(this, event);" style="VISIBILITY: hidden" class="TextBoxforms"
												id="txtBankdrftOther" type="text" maxLength="30" name="txtBankdrftOther"></TD>
									</TR>
									<TR>
										<TD>&nbsp;Draft Date</TD>
										<TD><asp:textbox id="txtdraftDate" Runat="server" CssClass="Fontstyle" Width="70px"
												BorderStyle="Groove"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.RecuringFeesReceipt.txtdraftDate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
													border="0"></A>
											<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ControlToValidate="txtdraftDate" ErrorMessage="Please Enter Draft Date">*</asp:requiredfieldvalidator></TD>
					</td>
					<TD>&nbsp;Current Date</TD>
					<TD><asp:textbox id="TxtcurDate1" runat="server" CssClass="Fontstyle" Width="70px"
							BorderStyle="Groove"></asp:textbox></TD>
				</tr>
				<tr>
					<TD style="HEIGHT: 13px">&nbsp;Bank Name&nbsp;<FONT color="#ff0033">*</FONT></TD>
					<TD colSpan="3" style="HEIGHT: 13px"><asp:dropdownlist id="Dropbankdrft" runat="server" CssClass="ComboBox">
							<asp:ListItem Value="Select">Select</asp:ListItem>
						</asp:dropdownlist><asp:comparevalidator id="Comparevalidator7" Runat="server" ControlToValidate="Dropbankdrft" ErrorMessage="Please Select The Bank Name"
							Operator="NotEqual" ValueToCompare="Select" Type="String" Display="Dynamic">*</asp:comparevalidator></TD>
				</tr>
				</asp:panel>
				<TR>
					<TD>&nbsp;Remarks</TD>
					<TD colSpan="3"><asp:textbox CssClass="TextBoxForms" id="TxtRemarks" BorderStyle="Groove" runat="server" Width="500px"
							Font-Name="Arial" Height="20" TextMode="MultiLine"></asp:textbox><asp:regularexpressionvalidator id="revRemarks" runat="server" ControlToValidate="TxtRemarks" ErrorMessage="Remarks must be alphabetic"
							ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$">*</asp:regularexpressionvalidator></TD>
				</TR>
				<!--TR>
									<TD></TD>
									<TD><asp:textbox id="TxtTo" BorderStyle="Groove" runat="server" Width="80px" ReadOnly="True" Visible="False"
											CssClass="FontStyle"></asp:textbox></TD>
								</TR-->
				<TR>
					<TD align="center" colSpan="6"><asp:button id="btnupdate" Runat="server" CssClass="FormButtonStyle" Text="Update"></asp:button>
						&nbsp;<asp:button id="btnSave" runat="server" CssClass="FormButtonStyle" Text="Save" CausesValidation="True"></asp:button>&nbsp;
						<asp:button id="BtnReset" Runat="server" CssClass="FormButtonStyle" Text="Reset" CausesValidation="False"></asp:button>&nbsp;
						<asp:button id="btnprint" Runat="server" CssClass="FormButtonStyle" Text="Print" CausesValidation="False"></asp:button>&nbsp;
						<asp:validationsummary id="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD>
				</TR>
				</TD></TR></table>
			</TD></TR></TBODY></TABLE> 
			<!--PopCalendar(tag name and id must match) Tags should sit at the page bottom -->
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm"
				frameBorder="0" width="174" scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
