<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Import namespace="eschool.Classes" %>
<%@ Page language="c#" Codebehind="FeesReceipt.aspx.cs" AutoEventWireup="false" Inherits="eschool.Modules.StudentFees.FeesReceipt" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Fees Receipt Report</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<script language="javascript" id="Validations" src=../../HeaderFooter/shareables/jsfiles/Validations.js></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="FeesReceipt" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="231" width="778" align="center">
				<tbody>
					<tr>
						<td vAlign="top" align="center"><b>FEES RECEIPT REPORT</b>
							<TABLE id="Table2" cellSpacing="1" cellPadding="1" borderColorLight="#663300" border="5">
								<tbody>
									<tr align="center">
										<td align="center">&nbsp;Student ID&nbsp;<font color="red" size="1">*</font>&nbsp;
											<asp:textbox id="DropRecuID" BorderStyle="Groove" runat="server" CssClass="FontStyle" MaxLength="8"
												Width="60px"></asp:textbox>
												<asp:RequiredFieldValidator ID=valid1 Runat=server ControlToValidate=DropRecuID ErrorMessage="Please Entre StudentID">*</asp:RequiredFieldValidator>
												&nbsp;<asp:Label ID="labname" Runat="server" Visible="False">Student Name</asp:Label>
											<asp:textbox id="Txtsname" BorderStyle="Groove" Visible="False" runat="server" CssClass="FontStyle"
												MaxLength="28" Width="250px" ReadOnly="True"></asp:textbox>
											From Date&nbsp;<asp:textbox id="TxtFromdate" CssClass="FontStyle" BorderStyle="Groove" Runat="server" Width="70px"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.FeesReceipt.TxtFromdate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
													border="0"></A> To Date&nbsp;<asp:textbox id="Txttodate" BorderStyle="Groove" CssClass="FontStyle" Runat="server" Width="70px"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.FeesReceipt.Txttodate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
													border="0"></A></td>
									</tr>
									<tr>
										<td align="center"><BUTTON id="Search" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 100px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
												accessKey="S" type="button" runat="server" class="FormButtonStyle"><IMG id="txtsearch" style="WIDTH: 16px; HEIGHT: 7px" height="7" src="../../HeaderFooter/images/search.gif"
													width="16"> <U>S</U>earch</BUTTON>&nbsp;<BUTTON class="FormButtonStyle" id="BtnPrint" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
												accessKey="S" type="button" runat="server">Print</BUTTON>
											<asp:button id="btnExcel" BorderColor="Black" BorderStyle="Outset" BackColor="#E0E0E0" runat="server"
												Width="85px" Height="21px" CssClass="FormButtonStyle" Font-Size="X-Small" Text="Excel" BorderWidth="2px"
												CausesValidation="True"></asp:button><asp:ValidationSummary ID=summry1 Runat=server ShowMessageBox=True ShowSummary=False></asp:ValidationSummary>
										</td>
									</tr>
									<asp:Panel ID="panfees" Runat="server" Visible="False">
										<TR>
											<TD>
												<asp:datagrid id="DataGrid1" Runat="server" AutoGenerateColumns="False"
													ShowFooter="True">
													<AlternatingItemStyle CssClass="DatagridAlternatingStyle"></AlternatingItemStyle>
													<ItemStyle CssClass="DataGridItem"></ItemStyle>
													<HeaderStyle ForeColor="White" Font-Bold="True" BackColor="#663300"></HeaderStyle>
													<FooterStyle Font-Bold="True" ForeColor="White" BackColor="#663300"></FooterStyle>
													<Columns>
														<asp:TemplateColumn HeaderText="SNo">
															<ItemTemplate>
																<%=i++%>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="Student_Class" HeaderText="Class" FooterText="Total">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="seq_student_id" HeaderText="Sec">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="RecuringID" HeaderText="Rec No">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="feesubdt" HeaderText="Rec Date" DataFormatString="{0:dd/MM/yyyy}">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Tution_fee" HeaderText="Tution Fee">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="securityfee" HeaderText="Security Fee">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Diary_fee" HeaderText="Diary Fee">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Activity_fee" HeaderText="Activity Fee">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Admission_fee" HeaderText="Admission Fee">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Annual_fee" HeaderText="Annual Fee">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Envp_fee" HeaderText="Envp Fee">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Computer_Fee" HeaderText="Computer Fee">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Science_Fee" HeaderText="Science Fee">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Game_Fee" HeaderText="Games Fee">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Latefee" HeaderText="Late Fee">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Hostel_Fee" HeaderText="House Fee">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="RegFee" HeaderText="Reg Fee">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Transport_fee" HeaderText="Transport">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Amount">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<ItemTemplate>
																<%#TotalAmt(DataBinder.Eval(Container.DataItem, "Fees_Amount").ToString()) %>
															</ItemTemplate>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
															<FooterTemplate>
																<%=GenUtil.strNumericFormat(Cache["Amount"].ToString())%>
															</FooterTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="ChNo" HeaderText="Cheque/DD No">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="chdate" HeaderText="Cheque\DD Date" DataFormatString="{0:dd/MM/yyyy}">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="chbank" HeaderText="Bank Name">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Remarks" HeaderText="Remarks">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														</asp:BoundColumn>
													</Columns>
												</asp:datagrid>
												</td>
										</TR>
									</asp:Panel>
								</tbody>
							</TABLE>
						</td>
					</tr>
				</tbody>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src=../../HeaderFooter/shareables/Style/ipopeng.htm frameBorder="0"
				width="174" scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
		</FORM>
	</body>
</HTML>
