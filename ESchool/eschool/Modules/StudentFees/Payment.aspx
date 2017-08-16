<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx"%>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx"%>
<%@ Page language="c#" Codebehind="Payment.aspx.cs" AutoEventWireup="false" Inherits="eschool.Modules.StudentFees.Payment" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Payment</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<script language="javascript" id="validation1" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr align="center">
					<td align="center"><b>PAYMENT</b>
						<table id="table1" cellSpacing="1" cellPadding="1" borderColorLight="#663300" border="5">
							<tr>
								<td colSpan="4"><asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label><INPUT id="tempMode" style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" type="text"
										size="2" name="tempRouteNo" runat="server"></td>
							</tr>
							<tr>
								<td>&nbsp;Payment Id</td>
								<td colSpan="3"><asp:dropdownlist CssClass="ComboBox" id="Dropedit" Runat="server" AutoPostBack="True" Visible="False">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist><asp:label id="LblId" ForeColor="blue" Runat="server"></asp:label>&nbsp;&nbsp;<asp:button id="btnedit" Runat="server" Text="..." Width="20" CssClass="FormButtonStyle" CausesValidation="False"></asp:button>&nbsp;&nbsp;</td>
							</tr>
							<tr>
								<td>&nbsp;Ledger ID &amp; Name&nbsp;<font color="red" size="1">*</font></td>
								<td colSpan="3"><asp:dropdownlist CssClass="ComboBox" id="dropLedgid" Runat="server">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist>&nbsp;<asp:comparevalidator id="CompVali" Runat="server" ErrorMessage="Please Select Ledger ID" ValueToCompare="Select"
										ControlToValidate="dropLedgid" Operator="NotEqual">*</asp:comparevalidator>&nbsp;&nbsp;</td>
							</tr>
							<tr>
								<td>&nbsp;Payment Date</td>
								<td><asp:textbox id="txtDate" Runat="server" CssClass="Fontstyle" ReadOnly=True Width=70px BorderStyle="Groove"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtDate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A></td>
								<td>&nbsp;Payment Mode&nbsp;<font color="red" size="1">*</font></td>
								<td><asp:dropdownlist CssClass="ComboBox" id="Dropmode" Runat="server" AutoPostBack="true">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist>&nbsp;<asp:comparevalidator id="CompVali1" Runat="server" ErrorMessage="Please Select Payment Mode" ValueToCompare="Select"
										ControlToValidate="Dropmode" Operator="NotEqual">*</asp:comparevalidator></td>
							</tr>
							<asp:panel id="panmode" Runat="server" Visible="False">
								<TR>
									<TD>&nbsp;Chack Date</TD>
									<TD>
										<asp:TextBox id="txtchkdt" Runat="server" CssClass="Fontstyle" ReadOnly=True Width=70px BorderStyle="Groove"></asp:TextBox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtchkdt);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
												border="0"></A></TD>
									<TD>&nbsp;Check No.</TD>
									<TD>
										<asp:TextBox onkeypress="return GetOnlyNumbers(this, event, true,true);" id="txtchckno" Runat="server"
											CssClass="TextBoxforms" MaxLength="8"></asp:TextBox></TD>
								</TR>
							</asp:panel>
							<tr>
								<td>&nbsp;Amount&nbsp;<font color="red" size="1">*</font></td>
								<td><asp:textbox CssClass="TextBoxforms" onkeypress="return GetOnlyNumbers(this, event, true,true);"
										id="txtamnt" Runat="server" Width="90px" MaxLength="8"></asp:textbox>&nbsp;<asp:requiredfieldvalidator id="valireq1" Runat="server" ErrorMessage="Please Enter Amount" ControlToValidate="txtamnt">*</asp:requiredfieldvalidator></td>
								<td>&nbsp;Narration</td>
								<td><asp:textbox CssClass="TextBoxforms" id="txtRemark" Runat="server" MaxLength="35" Height="20px"></asp:textbox></td>
							</tr>
							<tr>
								<td align="center" colSpan="4"><asp:button id="btnsave" Runat="server" Text="Save" CssClass="formbuttonstyle"></asp:button></td>
							</tr>
							<asp:validationsummary id="simmry1" Runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></table>
					</td>
				</tr>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0"
				width="174" scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer" runat="server"></uc1:footer></form>
	</body>
</HTML>
