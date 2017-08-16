<%@ Page language="c#" Codebehind="PaySlip.aspx.cs" AutoEventWireup="false" Inherits="eschool.StudentFees.PaySlip" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>eSchool : Pay Slip</title><!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<script language="javascript" id="Validations" src="../Validations.js"></script>
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body>
		<form id="PaySlip" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="228" width="778" align="center">
				<tr>
					<td align="center" colSpan="3"></td>
				</tr>
				<tr>
					<td></td>
					<td align="center"><asp:label id="Label3" runat="server" Font-Bold="True">
							</asp:label></td>
					<td></td>
				</tr>
				<tr>
					
					<td vAlign="top" align="center"><b>PAY SLIP</b>
						<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="80%" align="center" borderColorLight="#663300"
							border="5">
							<TBODY>
								<TR>
									<TD>&nbsp;Employee ID</TD>
									<TD><asp:dropdownlist CssClass="ComboBox" id="dropEmpName" runat="server" AutoPostBack="True">
											<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
										</asp:dropdownlist></TD>
									<TD>&nbsp;Employee Name</TD>
									<TD><asp:textbox id="txtEmpID" CssClass="TextBoxforms" runat="server" Width="180px" BorderStyle="Groove"></asp:textbox></TD>
								</TR>
								<tr>
									<td>&nbsp;Designation</td>
									<td><asp:TextBox ID="txtdesig" CssClass="TextBoxforms" Runat="server" ReadOnly="True" Enabled="False" BorderStyle="Groove"></asp:TextBox></td>
									<td>&nbsp;Date of Joining</td>
									<td><asp:TextBox ID="txtdoj" CssClass="TextBoxforms" Runat="server" ReadOnly="True" Enabled="False" Width="130px" BorderStyle="Groove"></asp:TextBox></td>
								</tr>
								<tr>
									<td>&nbsp;Saving &nbsp;A\C No</td>
									<td><asp:TextBox ID="txtperacno" CssClass="TextBoxforms" Runat="server" ReadOnly="True" Enabled="False" BorderStyle="Groove"></asp:TextBox></td>
									<td>&nbsp;E.P.F. A\C No</td>
									<td><asp:TextBox ID="txtepfacno" CssClass="TextBoxforms" Runat="server" ReadOnly="True" Enabled="False" Width="130px" BorderStyle="Groove"></asp:TextBox></td>
								</tr>
								<TR>
									<TD align="left">&nbsp;Basic Salary</TD>
									<td>
										<asp:textbox id="txtBasic" CssClass="TextBoxforms" runat="server" BorderStyle="Groove"></asp:textbox></td>
									<TD>&nbsp;D.A.</TD>
									<TD><asp:textbox id="txtda" onkeypress="return GetOnlyNumbers(this, event, false,true);" runat="server"
											BorderStyle="Groove" Width="130"></asp:textbox></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2"><STRONG><EM><FONT size="1">Allowances</FONT></EM></STRONG></TD>
									<TD align="center" colSpan="2"><STRONG><EM><FONT size="1">Deductions</FONT></EM></STRONG></TD>
								</TR>
								<TR>
									<TD>&nbsp;H.R.A</TD>
									<TD><asp:textbox id="txthra" CssClass="TextBoxforms" onkeypress="return GetOnlyNumbers(this, event, false,true);" runat="server"
											BorderStyle="Groove"></asp:textbox></TD>
									<TD>&nbsp;E.P.F.&nbsp;
									</TD>
									<TD><asp:textbox id="txtpf" CssClass="TextBoxforms" onkeypress="return GetOnlyNumbers(this, event, false,true);" runat="server"
											BorderStyle="Groove"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;T.A.</TD>
									<TD><asp:textbox id="txtta" CssClass="TextBoxforms" onkeypress="return GetOnlyNumbers(this, event, false,true);" runat="server"
											BorderStyle="Groove"></asp:textbox></TD>
									<TD>&nbsp;
										Professional Tax</TD>
									<TD><asp:textbox id="txttax" CssClass="TextBoxforms" onkeypress="return GetOnlyNumbers(this, event, false,true);" runat="server"
											BorderStyle="Groove"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;CCA</TD>
									<TD>
										<asp:textbox id="txtcca" CssClass="TextBoxforms" onkeypress="return GetOnlyNumbers(this, event, false,true);" runat="server"
											BorderStyle="Groove"></asp:textbox></TD>
									<TD>&nbsp;Loan</TD>
									<TD><asp:textbox id="txtothertax" CssClass="TextBoxforms" onkeypress="return GetOnlyNumbers(this, event, false,true);" runat="server"
											BorderStyle="Groove"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;Special Allowance</TD>
									<td><asp:TextBox ID="txtMedical" CssClass="TextBoxforms" Runat="server" BorderStyle="Groove"></asp:TextBox></td>
									<TD>&nbsp;Penel Deduction</TD>
									<TD>
										<asp:textbox id="txtpenDeduction" CssClass="TextBoxforms" onkeypress="return GetOnlyNumbers(this, event, false,true);"
											runat="server" ReadOnly="True" Enabled="False" BorderStyle="Groove"></asp:textbox></TD>
								</TR>
								<TR>
									<td>&nbsp;Arrears</td>
									<td><asp:TextBox ID="txtArrears" CssClass="TextBoxforms" Runat="server" BorderStyle="Groove" Enabled="False"></asp:TextBox></td>
									<td>&nbsp;Security</td>
									<td><asp:TextBox CssClass="TextBoxforms" ID="txtsec" Runat="server" ReadOnly="True" Enabled="False" BorderStyle="Groove"></asp:TextBox></td>
								</TR>
								<TR>
									<TD>&nbsp;Benifits</TD>
									<TD>
										<asp:textbox id="txtbenefits" CssClass="TextBoxforms" onkeypress="return GetOnlyNumbers(this, event, false,true);" runat="server"
											BorderStyle="Groove"></asp:textbox></TD>
									<td>&nbsp;Leave Without Pay</td>
									<td><asp:TextBox ID="txtlwp" CssClass="TextBoxforms" Runat="server" ReadOnly="True" Enabled="False" BorderStyle="Groove"></asp:TextBox></td>
								</TR>
								<TR>
									<TD>&nbsp;Total Allowances</TD>
									<TD>
										<asp:textbox id="txtAllowances" CssClass="TextBoxforms" onkeypress="return GetOnlyNumbers(this, event, false,true);"
											runat="server" ReadOnly="True" BorderStyle="Groove"></asp:textbox></TD>
									<td>&nbsp;Total Deduction</td>
									<td><asp:TextBox ID="txtDeduction" CssClass="TextBoxforms" Runat="server" BorderStyle="Groove"></asp:TextBox></td>
								</TR>
								<TR>
									<TD>&nbsp;
										lncrements</TD>
									<TD colspan="3">
										<asp:textbox id="txtincrement" CssClass="TextBoxforms" onkeypress="return GetOnlyNumbers(this, event, false,true);" runat="server"
											BorderStyle="Groove"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;Gross Total</TD>
									<TD>
										<asp:textbox id="txtGross" CssClass="TextBoxforms" onkeypress="return GetOnlyNumbers(this, event, false,true);" runat="server"
											ReadOnly="True" BorderStyle="Groove"></asp:textbox>
									<td>&nbsp;Net Salary</td>
									<td><asp:textbox id="txtNetSalary" CssClass="TextBoxforms" onkeypress="return GetOnlyNumbers(this, event, false,true);" runat="server"
											ReadOnly="True" BorderStyle="Groove"></asp:textbox></td>
								</TR>
								<TR>
									<TD align="center" colSpan="4">&nbsp;
										<asp:button id="btnEdit" Runat="server" Text="Edit" CssClass="formbuttonstyle"></asp:button>&nbsp;&nbsp;
										<asp:button id="btnprint" Runat="server" CssClass="formbuttonstyle" Text="Print"></asp:button>
										<asp:validationsummary id="svPaySlip" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD>
								</TR>
								
							</TBODY>
						</TABLE>
					</td>
					<td></td>
				</tr>
			</table>
		</form> <!--PopCalendar(tag name and id must match) Tags should sit at the page bottom --><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
			name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189">
		</iframe>
		<uc1:footer id="Footer1" runat="server"></uc1:footer>
	</body>
</HTML>
