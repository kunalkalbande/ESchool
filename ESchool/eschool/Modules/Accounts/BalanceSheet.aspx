<%@ Page language="c#" Codebehind="BalanceSheet.aspx.cs" AutoEventWireup="false" Inherits="eRetail.Forms.Reports.BalanceSheet" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Balance Sheet</title> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="False" name="vs_snapToGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:textbox id="TextBox2" style="Z-INDEX: 102; LEFT: 144px; POSITION: absolute; TOP: 16px" runat="server"
				Width="8px" Visible="False"></asp:textbox><uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="775" align="center">
				<TR>
					<Td align="center">
						<b>BALANCE SHEET</b>
						<table cellpadding="1" cellspacing="1" border="5" bordercolorlight="#663300">
							<tr>
								<td align="center">Date From&nbsp;
									<asp:requiredfieldvalidator id="rfvDateFrom" runat="server" ControlToValidate="txtDateFrom" ErrorMessage="Please Select From Date From the Calender">*</asp:requiredfieldvalidator>&nbsp;
									<asp:textbox id="txtDateFrom" runat="server" Width="70px" CssClass="FontStyle" BorderStyle="Groove"
										ReadOnly="True"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtDateFrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A> Date To&nbsp;
									<asp:requiredfieldvalidator id="rfvDateTo" runat="server" ControlToValidate="txtDateTo" ErrorMessage="Please Select To Date From the Calender">*</asp:requiredfieldvalidator>&nbsp;
									<asp:textbox id="txtDateTo" CssClass="FontStyle" Width="70px" runat="server" BorderStyle="Groove"
										ReadOnly="True"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtDateTo);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A>
								</td>
							</tr>
							<TR>
								<TD align="center">
									<asp:button id="btnShow" CssClass="FormButtonStyle" BorderColor="black" BorderStyle="Groove"
										BorderWidth="2" BackColor="#E0E0E0" Width="100" Font-Size="X-Small" runat="server" Text="View"></asp:button>&nbsp;&nbsp;&nbsp;
									<asp:button id="BtnPrint" CssClass="FormButtonStyle" BorderColor="black" BorderStyle="Groove"
										BorderWidth="2" BackColor="#E0E0E0" Width="85" Font-Size="X-Small" Text="Print" Runat="server"></asp:button>&nbsp;&nbsp;&nbsp;
									<asp:button id="btnExcel" Text="Excel" CssClass="FormButtonStyle" BorderColor="black" BorderStyle="Groove"
										BorderWidth="2" BackColor="#E0E0E0" Width="85" Font-Size="X-Small" Runat="server"></asp:button>&nbsp;
								</TD>
							</TR>
						</table>
				<TR>
					<TD style="HEIGHT: 170px" vAlign="top" align="center">
						<TABLE id="Table1" border="1" runat="server">
							<tr>
								<th align="center" colSpan="5">
									<b>LIABILITIES</b></th>
								<th align="center">
									<b>ASSETS</b></th>
							</tr>
							<TR>
								<TD style="HEIGHT: 110px" vAlign="top" align="center" colSpan="5">
									<table border="0">
										<tr>
											<!--<th align="center" colspan="2"><b>LIABILITIES</b>
												</th><th align="center" colspan="3"><b></b></th>-->
										</tr>
										<tr>
											<td><asp:label id="lblCapital" runat="server" Font-Size="8pt" Font-Bold="True">Capital</asp:label></td>
											<td align="right" width="80"><asp:label id="lblCapitalValue" runat="server" Width="80px" ForeColor="Black"></asp:label></td>
										</tr>
										<tr>
											<td><asp:label id="lblRes_Surplus" runat="server" Font-Size="8pt" Font-Bold="True">Reserve & Surplus</asp:label></td>
											<td align="right" width="80"><asp:label id="lblRes_Sur_Value" runat="server" Width="75px"></asp:label></td>
										</tr>
										<tr>
											<td><asp:label id="lblSecuredLoans" runat="server" Font-Size="8pt" Font-Bold="True">Secured Loans</asp:label></td>
											<td align="right" width="80"><asp:label id="lblSecuredLoansValue" runat="server" Width="75px"></asp:label></td>
										</tr>
										<tr>
											<td><asp:label id="lblUnsecuredLoans" runat="server" Font-Size="8pt" Font-Bold="True">Unsecured Loans</asp:label></td>
											<td align="right" width="80"><asp:label id="lblunsecuredValue" runat="server" Width="75px"></asp:label></td>
										</tr>
										<tr>
											<td style="HEIGHT: 15px"><asp:label id="lblCurrentLiabilities" runat="server" Font-Size="8pt" Font-Bold="True">Current Liabilities</asp:label></td>
											<td style="HEIGHT: 15px" align="right" width="80"><asp:label id="lblCurrentValue" runat="server" Width="75px"></asp:label></td>
										</tr>
										<tr>
											<td><asp:label id="lblProvisions" runat="server" Font-Size="8pt" Font-Bold="True">Provisions</asp:label></td>
											<td align="right" width="80"><asp:label id="lblProvisionsValue" runat="server" Width="75px"></asp:label></td>
										</tr>
										<TR>
											<TD><asp:label id="lblDiffCreditBal" runat="server" Font-Size="8pt" Font-Bold="True">Diff. In Opening Balance</asp:label>&nbsp;</TD>
											<TD align="right" width="80"><asp:label id="lblDiffBal1" runat="server" Width="75px" ForeColor="DarkGreen"></asp:label></TD>
										</TR>
										<TR>
											<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
											<TD align="right" width="80">&nbsp;</TD>
										</TR>
										<TR>
											<TD>
												<HR style="COLOR: black; HEIGHT: 1px">
												<asp:label id="Label1" runat="server" Font-Size="8pt" Font-Bold="True">TOTAL</asp:label>
												<HR style="FONT-WEIGHT: normal; COLOR: buttontext; BORDER-TOP-STYLE: double; BORDER-RIGHT-STYLE: double; BORDER-LEFT-STYLE: double; HEIGHT: 1px; BORDER-BOTTOM-STYLE: double">
											</TD>
											<TD align="right" width="80"><asp:label id="lblTotal1Value" runat="server" Width="80px" Font-Bold="True"></asp:label></TD>
										</TR>
									</table>
								</TD>
								<TD style="HEIGHT: 120px" align="center" colSpan="5">
									<table border="0">
										<tr>
											<td></td>
											<td></td>
											<td></td>
											<td><asp:label id="lblFixedAssets" runat="server" Font-Size="8pt" Font-Bold="True">Fixed Assets</asp:label></td>
											<td align="right" width="80"><asp:label id="lblFixedAssetsValue" runat="server" Width="75px"></asp:label></td>
										</tr>
										<tr>
											<td></td>
											<td></td>
											<td></td>
											<td><asp:label id="lblInvestments" runat="server" Font-Size="8pt" Font-Bold="True">Investments</asp:label></td>
											<td align="right" width="80"><asp:label id="lblInvestmentValue" runat="server" Width="75px"></asp:label></td>
										</tr>
										<tr>
											<td></td>
											<td></td>
											<td></td>
											<td><asp:label id="lblCurrentAssets" runat="server" Font-Size="8pt" Font-Bold="True">Current Assets</asp:label></td>
											<td align="right" width="80"><asp:label id="lblCurrentAssetsValue" runat="server" Width="75px"></asp:label></td>
										</tr>
										<tr>
											<td></td>
											<td></td>
											<td></td>
											<td><asp:label id="lblLoansAdvances" runat="server" Font-Size="8pt" Font-Bold="True">Loans & Advances</asp:label></td>
											<td align="right" width="80"><asp:label id="lblLoansAdvancesValue" runat="server" Width="75px"></asp:label></td>
										</tr>
										<tr>
											<td></td>
											<td></td>
											<td></td>
											<td style="HEIGHT: 15px"><asp:label id="lblProfitLossAC" runat="server" Font-Size="8pt" Font-Bold="True">Profit & Loss A/C</asp:label></td>
											<td style="HEIGHT: 15px" align="right" width="80"><asp:label id="lblProfitLossValue" runat="server" Width="75px"></asp:label></td>
										</tr>
										<tr>
											<td></td>
											<td></td>
											<td></td>
											<td><asp:label id="lblMiscExp" runat="server" Font-Size="8pt" Font-Bold="True">Misc. Expenditure</asp:label></td>
											<td align="right" width="80"><asp:label id="lblMiscExpValue" runat="server" Width="75px"></asp:label></td>
										</tr>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD><asp:label id="lblDiffBalDebit" runat="server" Font-Size="8pt" Font-Bold="True">Diff. In Opening Balance</asp:label>&nbsp;</TD>
											<TD align="right" width="80"><asp:label id="lblDiffBal2" runat="server" Width="75px" ForeColor="DarkGreen"></asp:label></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
											<TD align="right" width="80">&nbsp;</TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD><HR style="FONT-WEIGHT: normal; COLOR: buttontext; BORDER-TOP-STYLE: double; BORDER-RIGHT-STYLE: double; BORDER-LEFT-STYLE: double; HEIGHT: 1px; BORDER-BOTTOM-STYLE: double">
												<asp:label id="Label2" runat="server" Font-Size="8pt" Font-Bold="True">TOTAL</asp:label>
												<HR style="COLOR: black; HEIGHT: 1px">
											</TD>
											<TD align="right" width="80"><asp:label id="lblTotal2Value" runat="server" Width="80px" Font-Bold="True"></asp:label></TD>
										</TR>
									</table>
								</TD>
							</TR>
						</TABLE>
						<asp:validationsummary id="ValidationSummary1" runat="server" Width="138px" Height="22px" ShowSummary="False"
							ShowMessageBox="True"></asp:validationsummary></TD>
				</TR>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm"
				frameBorder="0" width="174" scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
