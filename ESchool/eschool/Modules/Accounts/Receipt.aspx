<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Page language="c#" Codebehind="Receipt.aspx.cs" AutoEventWireup="false" Inherits="eschool.Modules.Accounts.Receipt" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Receipt</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<script language="javascript" id="validation1" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr align="center">
					<td align="center"><b>RECEIPT</b>
						<table id="table1" cellSpacing="1" cellPadding="1" borderColorLight="#663300" border="5">
							<TBODY>
								<tr>
									<td colSpan="4"><asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label><INPUT id="tempMode" style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" type="text" size="2" name="tempRouteNo" runat="server"></td>
								</tr>
								<tr>
									<td>&nbsp;Receipt Id</td>
									<td colSpan="3"><asp:dropdownlist id="Dropedit" Runat="server" CssClass="ComboBox" AutoPostBack="True" Visible="False">
											<asp:ListItem Value="Select">Select</asp:ListItem>
										</asp:dropdownlist>&nbsp;<asp:label id="LblId" ForeColor="blue" Runat="server"></asp:label>&nbsp;<asp:button id="btnedit" Runat="server" Text="..." Width="20" CssClass="FormButtonStyle" CausesValidation="False"></asp:button>&nbsp;</td>
								</tr>
								<tr>
									<td>&nbsp;Received From<font color="red">*</font></td>
									<td colSpan="3"><asp:dropdownlist CssClass="ComboBox" id="dropLedgid" Runat="server">
											<asp:ListItem Value="Select">Select</asp:ListItem>
										</asp:dropdownlist>&nbsp;<asp:comparevalidator id="CompVali" Runat="server" ErrorMessage="Please Select Ledger ID" ValueToCompare="Select"
											ControlToValidate="dropLedgid" Operator="NotEqual">*</asp:comparevalidator>&nbsp;&nbsp;</td>
								</tr>
								<tr>
									<td>&nbsp;Received Date</td>
									<td><asp:textbox id="txtDate" Runat="server" CssClass="Fontstyle"  Width=70px BorderStyle="Groove"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtDate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
												border="0"></A></td>
									<td>&nbsp;Receive Mode <font color="red">*</font></td>
									<td><asp:dropdownlist id="Dropmode" CssClass="ComboBox" Runat="server" AutoPostBack="true"></asp:dropdownlist>&nbsp;<asp:comparevalidator id="CompVali1" Runat="server" ErrorMessage="Please Select Payment Mode" ValueToCompare="Select"
											ControlToValidate="Dropmode" Operator="NotEqual">*</asp:comparevalidator></td>
								</tr>
								<asp:panel id="panmode" Runat="server" Visible="False">
									<TR>
										<TD>&nbsp;Chack Date</TD>
										<TD>
											<asp:TextBox id="txtchkdt" Runat="server" CssClass="Fontstyle" Width=70px BorderStyle="Groove"></asp:TextBox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtchkdt);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
													border="0"></A></TD>
										<TD>&nbsp;Check No.</TD>
										<TD>
											<asp:TextBox CssClass="TextBoxforms" onkeypress="return GetOnlyNumbers(this, event, true,true);" id="txtchckno" Runat="server"
												MaxLength="8"></asp:TextBox></TD>
									</TR>
								</asp:panel>
								<tr>
									<td>&nbsp;Amount <font color="red">*</font></td>
									<td><asp:textbox CssClass="TextBoxforms" onkeypress="return GetOnlyNumbers(this, event, true,true);" id="txtamnt" Runat="server"
											Width="90px" MaxLength="8"></asp:textbox>&nbsp;<asp:requiredfieldvalidator id="valireq1" Runat="server" ErrorMessage="Please Enter Amount" ControlToValidate="txtamnt">*</asp:requiredfieldvalidator></td>
									<td>&nbsp;Narration</td>
									<td><asp:textbox CssClass="TextBoxforms" id="txtRemark" Runat="server" MaxLength="30" Height="20px"></asp:textbox></td>
								</tr>
								<tr>
									<td align="center" colSpan="4"><asp:button id="btnsave" Runat="server" Text="Save" CssClass="formbuttonstyle"></asp:button></td>
								</tr>
							</TBODY>
						</table>
					</td>
					<asp:validationsummary id="simmry1" Runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></tr>
			</table>
			</TD></TR></TBODY></TABLE><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0" width="174" scrolling="no"
				height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
