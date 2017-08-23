<%@ Page language="c#" Codebehind="StockMovement_Report.aspx.cs" AutoEventWireup="false" Inherits="eschool.Modules.Reports.StockMovement_Report" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Stock Movement Report</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="750" align="center">
				<TBODY>
					<tr>
						<td align="center"><B>STOCK MOVEMENT REPORT</B>
							<table borderColorLight="#663300" border="5">
								<TBODY>
									<tr align="center">
										<td>Date From&nbsp;
											<asp:textbox id="TxtDatefrom" Runat="server" BorderStyle="Groove" CssClass="FontStyle" Width="70px"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.TxtDatefrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
													border="0"></A>&nbsp; Date To&nbsp;
											<asp:textbox id="TxtDateTo" Runat="server" BorderStyle="Groove" CssClass="FontStyle" Width="70px"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.TxtDateTo);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
													border="0"></A>&nbsp; Transaction Type&nbsp;
											<asp:dropdownlist id="DropTrType" CssClass="ComboBox" Runat="server">
												<asp:ListItem value="All">All</asp:ListItem>
												<asp:ListItem value="Opening Balance">Opening Balance</asp:ListItem>
												<asp:ListItem value="Receipt">Receipt</asp:ListItem>
												<asp:ListItem value="Issue">Issue</asp:ListItem>
												<asp:ListItem value="Closing Balance">Closing Balance</asp:ListItem>
											</asp:dropdownlist></td>
									</tr>
									<tr align="center">
										<td><asp:button id="BtnShow" BorderColor="Black" Height="21" BorderStyle="Groove"  Runat="server" CssClass="FormButtonStyle" Width="100px" Font-Size="X-Small"
												Text="Show"></asp:button>
											&nbsp;&nbsp;&nbsp;<asp:button Height="21" id="BtnPrint" BorderColor="Black" BorderStyle="Groove"  Runat="server" CssClass="FormButtonStyle" Width="85px" Font-Size="X-Small" Text="Print"></asp:button>
											&nbsp;&nbsp;&nbsp;<asp:button Height="21" id="btnexcel" BorderColor="Black" BorderStyle="Groove"  Runat="server" CssClass="FormbuttonStyle" Width="85px" Font-Size="X-Small" Text="Excel"></asp:button>
										</td>
									</tr>
									<asp:Panel ID="panlopen" Runat="server" Visible="False">
										<TR>
											<TD colSpan="6">
												<asp:datagrid id="GridOpenig" runat="server" Width="100%" AutoGenerateColumns="False">
													<HeaderStyle HorizontalAlign="Center" BackColor="#663300" CssClass="DataGridHeader"></HeaderStyle>
													<Columns>
														<asp:BoundColumn DataField="prod_name" HeaderText="Item Name">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="category" HeaderText="Category">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="op" HeaderText="Opening Balance">
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
												</asp:datagrid></TD>
										</TR>
									</asp:Panel>
									<asp:Panel ID="panlreceipt" Runat="server" Visible="False">
										<TR>
											<TD colSpan="6">
												<asp:datagrid id="GridReceipt" runat="server" Width="100%" Visible="false" AutoGenerateColumns="False">
													<HeaderStyle HorizontalAlign="Center" BackColor="#663300" CssClass="DataGridHeader"></HeaderStyle>
													<Columns>
														<asp:BoundColumn DataField="prod_name" HeaderText="Item Name">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="category" HeaderText="Category">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="rcpt" HeaderText="Receipt">
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
												</asp:datagrid></TD>
										</TR>
									</asp:Panel>
									<asp:Panel ID="Panlissue" Runat="server" Visible="False">
										<TR>
											<TD colSpan="6">
												<asp:datagrid id="GridIssue" runat="server" Width="100%" Visible="false" AutoGenerateColumns="False">
													<HeaderStyle HorizontalAlign="Center" BackColor="#663300" CssClass="DataGridHeader"></HeaderStyle>
													<Columns>
														<asp:BoundColumn DataField="prod_name" HeaderText="Item Name">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="category" HeaderText="Category">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="sales" HeaderText="Issue">
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
												</asp:datagrid></TD>
										</TR>
									</asp:Panel>
									<asp:Panel ID="Panlclose" Runat="server" Visible="False">
										<TR>
											<TD colSpan="6">
												<asp:datagrid id="GridClosing" runat="server" Width="100%" Visible="false" AutoGenerateColumns="False">
													<HeaderStyle HorizontalAlign="Center" BackColor="#663300" CssClass="DataGridHeader"></HeaderStyle>
													<Columns>
														<asp:BoundColumn DataField="prod_name" HeaderText="Item Name">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="category" HeaderText="Category">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="cs" HeaderText="Closing Stock">
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
												</asp:datagrid></TD>
										</TR>
									</asp:Panel><asp:Panel ID="Panlall" Runat="server" Visible="False">
										<TR>
											<TD colSpan="6">
												<asp:datagrid id="GridAll" runat="server" Width="100%" AutoGenerateColumns="False">
													<HeaderStyle HorizontalAlign="Left" BackColor="#663300" CssClass="DataGridHeader"></HeaderStyle>
													<Columns>
														<asp:BoundColumn DataField="Prod_name" HeaderText="Item Name">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="category" HeaderText="Category">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="op" HeaderText="Opening Balance">
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="rcpt" HeaderText="Receipt">
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="sales" HeaderText="Issue">
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="cs" HeaderText="Closing Balance">
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
												</asp:datagrid></TD>
										</TR>
									</asp:Panel>
								</TBODY>
							</table>
						</td>
					</tr>
				</TBODY>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0"
				width="174" scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
