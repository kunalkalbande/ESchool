<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Import namespace="eschool.Classes"%>
<%@ Page language="c#" Codebehind="LedgerReport.aspx.cs" AutoEventWireup="false" Inherits="eschool.Forms.Reports.CustomerLedger" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Ledger Report</title> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><asp:textbox id="TextBox1" style="Z-INDEX: 102; LEFT: 144px; POSITION: absolute; TOP: 16px" runat="server"
				Width="8px" Visible="False"></asp:textbox>
			<table height="250" width="778" align="center">
				<tr>
					<td align="center"><b>LEDGER REPORT</b>
						<table cellSpacing="1" cellPadding="1" borderColorLight="#663300" border="5" align="center">
							<TBODY>
								<TR>
									<TD vAlign="top" align="center">
										<TABLE align="center">
											<TR>
												<TD vAlign="middle" align="center"></TD>
												<TD vAlign="top" align="center"></TD>
												<TD vAlign="middle" align="center">Date From</TD>
												<TD vAlign="top"><asp:textbox id="txtDateFrom" runat="server" Width="70px" CssClass="FontStyle" BorderStyle="Groove"
														ReadOnly="True"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtDateFrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
															border="0"></A></TD>
												<TD vAlign="middle" align="center" colSpan="1" rowSpan="1">To</TD>
												<TD vAlign="top"><asp:textbox id="txtDateTo" runat="server" Width="70px" CssClass="FontStyle" BorderStyle="Groove"
														ReadOnly="True"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtDateTo);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
															border="0"></A></TD>
											</TR>
											<TR>
												<TD vAlign="middle" align="center"></TD>
												<TD vAlign="top" align="center"></TD>
												<TD vAlign="middle" align="center">Party Name&nbsp;
												</TD>
												<TD vAlign="top" colSpan="2"><asp:dropdownlist id="DropPartyName" runat="server" Width="230px" CssClass="FontStyle">
														<asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
													</asp:dropdownlist></TD>
												<td><u>Remark:</u> <STRONG>CB</STRONG> (Closing Balance)</td>
											</TR>
											<TR>
											<tr>
												<TD align="center" colSpan="11"><asp:button id="cmdrpt" Height="21px" runat="server" Text="Show " CssClass="FormButtonStyle"
														BorderColor="black" BorderStyle="Groove" BorderWidth="2" BackColor="#E0E0E0" Width="100px" Font-Size="X-Small"></asp:button>&nbsp;&nbsp;&nbsp;
													<asp:button id="BtnPrint" Height="21px" Text="Print" Runat="server" CssClass="FormButtonStyle"
														BorderColor="black" BorderStyle="Groove" BorderWidth="2" BackColor="#E0E0E0" Width="85px"
														Font-Size="X-Small"></asp:button>&nbsp;&nbsp;&nbsp;
													<asp:button id="btnExcel" Height="21px" Text="Excel" Runat="server" CssClass="FormButtonStyle"
														BorderColor="black" BorderStyle="Groove" BorderWidth="2" BackColor="#E0E0E0" Width="85px"
														Font-Size="X-Small"></asp:button>&nbsp;&nbsp;</TD>
											</tr>
										</TABLE>
									</TD>
								</TR>
								<asp:Panel ID="pangrid" Runat="server" Visible="False">
									<TR>
										<TD>
											<asp:datagrid id="Datagrid1" runat="server" AutoGenerateColumns="False">
												<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
												<AlternatingItemStyle CssClass="DatagridAlternatingStyle"></AlternatingItemStyle>
												<ItemStyle CssClass="DataGridItem"></ItemStyle>
												<HeaderStyle CssClass="DataGridHeader" BackColor="#663300"></HeaderStyle>
												<FooterStyle ForeColor="White" BackColor="#663300"></FooterStyle>
												<Columns>
													<asp:BoundColumn SortExpression="Entry_Date" HeaderText="Transaction No." FooterText="Total:">
														<HeaderStyle Width="60px"></HeaderStyle>
														<ItemStyle Width="60px"></ItemStyle>
														<FooterStyle Font-Bold="True"></FooterStyle>
													</asp:BoundColumn>
													<asp:BoundColumn HeaderStyle-HorizontalAlign="Center" DataField="Particulars" SortExpression="Particulars"
														HeaderText="Transaction Type">
														<HeaderStyle Width="120px"></HeaderStyle>
														<ItemStyle Width="120px"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn HeaderStyle-HorizontalAlign="Center" DataField="Entry_Date" SortExpression="Entry_Date"
														HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}">
														<HeaderStyle Width="60px"></HeaderStyle>
														<ItemStyle Width="60px"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="Debit_Amount" HeaderStyle-HorizontalAlign="Center" SortExpression="Debit_Amount"
														HeaderText="Debit" DataFormatString="{0:N2}">
														<HeaderStyle Width="60px"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right" Width="60px"></ItemStyle>
														<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="Credit_Amount" HeaderStyle-HorizontalAlign="Center" SortExpression="Credit_Amount"
														HeaderText="Credit" DataFormatString="{0:N2}">
														<HeaderStyle Width="60px"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right" Width="60px"></ItemStyle>
														<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn SortExpression="balance" HeaderStyle-HorizontalAlign="Center" HeaderText="Closing Balance">
														<HeaderStyle Width="100px"></HeaderStyle>
														<ItemStyle HorizontalAlign="right" Width="120px"></ItemStyle>
														<ItemTemplate>
															<%#setBal(GenUtil.strNumericFormat(DataBinder.Eval(Container.DataItem,"balance","{0:N2}").ToString()))%>
															<%#setType(DataBinder.Eval(Container.DataItem,"bal_type").ToString())%>
														</ItemTemplate>
														<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
														<FooterTemplate>
															<%//#GetSecurityAmount(DataBinder.Eval(Container.DataItem,"securityfee").ToString())%>
														</FooterTemplate>
													</asp:TemplateColumn>
												</Columns>
												<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
											</asp:datagrid>
											<asp:datagrid id="CustomerGrid" runat="server" AutoGenerateColumns="False" ShowFooter="True" OnItemDataBound="ItemTotal">
												<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
												<AlternatingItemStyle CssClass="DatagridAlternatingStyle"></AlternatingItemStyle>
												<ItemStyle CssClass="DataGridItem"></ItemStyle>
												<HeaderStyle CssClass="DataGridHeader" BackColor="#663300"></HeaderStyle>
												<FooterStyle ForeColor="White" BackColor="#663300"></FooterStyle>
												<Columns>
													<asp:BoundColumn SortExpression="Entry_Date" HeaderText="Transaction No." FooterText="Total:">
														<HeaderStyle Width="65px"></HeaderStyle>
														<ItemStyle Width="65px"></ItemStyle>
														<FooterStyle Font-Bold="True"></FooterStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="Particulars" SortExpression="Particulars" HeaderText="Transaction Type">
														<HeaderStyle Width="120px"></HeaderStyle>
														<ItemStyle Width="120px"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="Entry_Date" SortExpression="Entry_Date" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}">
														<HeaderStyle Width="60px"></HeaderStyle>
														<ItemStyle Width="60px"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="Debit_Amount" SortExpression="Debit_Amount" HeaderText="Debit" DataFormatString="{0:N2}">
														<HeaderStyle Width="60px"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right" Width="60px"></ItemStyle>
														<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="Credit_Amount" SortExpression="Credit_Amount" HeaderText="Credit" DataFormatString="{0:N2}">
														<HeaderStyle Width="60px"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right" Width="60px"></ItemStyle>
														<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn SortExpression="balance" HeaderText="Closing Balance">
														<HeaderStyle Width="120px"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right" Width="120px"></ItemStyle>
														<ItemTemplate>
															<%#setBal(GenUtil.strNumericFormat(DataBinder.Eval(Container.DataItem,"balance","{0:N2}").ToString()))%>
															<%#setType(DataBinder.Eval(Container.DataItem,"bal_type").ToString())%>
														</ItemTemplate>
														<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
													</asp:TemplateColumn>
												</Columns>
												<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
											</asp:datagrid>
											<asp:datagrid id="TotalSales" runat="server" AutoGenerateColumns="False" ShowFooter="True">
												<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
												<AlternatingItemStyle CssClass="DatagridAlternatingStyle"></AlternatingItemStyle>
												<ItemStyle CssClass="DataGridItem"></ItemStyle>
												<HeaderStyle CssClass="DataGridHeader" BackColor="#663300"></HeaderStyle>
												<FooterStyle ForeColor="White" BackColor="#663300"></FooterStyle>
												<Columns>
													<asp:BoundColumn SortExpression="Entry_Date" HeaderText="Transaction No." FooterText="Total:">
														<HeaderStyle Width="60px"></HeaderStyle>
														<ItemStyle Width="60px"></ItemStyle>
														<FooterStyle Font-Bold="True"></FooterStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="Particulars" SortExpression="Particulars" HeaderText="Transaction Type">
														<HeaderStyle Width="120px"></HeaderStyle>
														<ItemStyle Width="120px"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="Entry_Date" SortExpression="Entry_Date" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}">
														<HeaderStyle Width="60px"></HeaderStyle>
														<ItemStyle Width="60px"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="Debit_Amount" SortExpression="Debit_Amount" HeaderText="Debit" DataFormatString="{0:N2}">
														<HeaderStyle Width="60px"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right" Width="60px"></ItemStyle>
														<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="Credit_Amount" SortExpression="Credit_Amount" HeaderText="Credit" DataFormatString="{0:N2}">
														<HeaderStyle Width="60px"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right" Width="60px"></ItemStyle>
														<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn SortExpression="balance" HeaderText="Closing Balance">
														<HeaderStyle Width="120px"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right" Width="120px"></ItemStyle>
														<ItemTemplate>
															<%#setBalance1(DataBinder.Eval(Container.DataItem,"Debit_Amount").ToString(),DataBinder.Eval(Container.DataItem,"Credit_Amount").ToString())%>
															<%="Dr"%>
														</ItemTemplate>
														<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
													</asp:TemplateColumn>
												</Columns>
												<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
											</asp:datagrid></TD>
									</TR>
								</asp:Panel>
							</TBODY>
						</table>
					</td>
				</tr>
			</table>
			</TD></TR></TBODY></TABLE><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0" width="174"
				scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
