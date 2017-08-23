<%@ Page language="c#" Codebehind="SecurityReport.aspx.cs" AutoEventWireup="false" Inherits="eschool.Reports.SecurityReport" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>eSchool : Security fees Report</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td align="center" colSpan="3"><asp:label id="Label2" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td align="center"><b>SECURITY FEES REPORT</b>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="80%" borderColorLight="#663300"
							border="5">
							<TR>
								<td align="center">Class&nbsp;&nbsp;<asp:dropdownlist id="DropClass" CssClass="ComboBox" Width="80" Runat="server"></asp:dropdownlist>&nbsp;&nbsp; 
									Section&nbsp;&nbsp;<asp:dropdownlist id="DropSection" CssClass="ComboBox" Width="80" Runat="server">
										<asp:ListItem Value="All">All</asp:ListItem>
										<asp:ListItem Value="A">A</asp:ListItem>
										<asp:ListItem Value="B">B</asp:ListItem>
										<asp:ListItem Value="C">C</asp:ListItem>
										<asp:ListItem Value="D">D</asp:ListItem>
										<asp:ListItem Value="E">E</asp:ListItem>
										<asp:ListItem Value="F">F</asp:ListItem>
										<asp:ListItem Value="G">G</asp:ListItem>
										<asp:ListItem Value="H">H</asp:ListItem>
										<asp:ListItem Value="I">I</asp:ListItem>
										<asp:ListItem Value="J">J</asp:ListItem>
									</asp:dropdownlist>&nbsp;&nbsp; <BUTTON id="Search" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 100px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server" class="FormButtonStyle"><IMG id="txtsearch" height="7" src="../../HeaderFooter/images/search.gif" width="16"><U>S</U>earch</BUTTON>&nbsp;&nbsp;
									<asp:button id="Button1" BorderColor="Black" BorderStyle="Groove"  runat="server"
										Width="85px" CssClass="FormButtonStyle" Text="Print" Height="21"  Font-Size="X-Small"></asp:button>&nbsp;&nbsp;
									<asp:button id="Exel" BorderColor="Black" BorderStyle="Groove"  runat="server"
										Width="85px" CssClass="FormButtonStyle" Text="Exel" Height="21"  Font-Size="X-Small"></asp:button>
								</td>
							</TR>
							<asp:Panel ID="pansecu" Runat="server" Visible="false">
        <TR>
          <TD>
<asp:datagrid id=grdSecurity Runat="server" Width="100%" ShowFooter="True" AutoGenerateColumns="False">
											<AlternatingItemStyle CssClass="DatagridAlternatingStyle"></AlternatingItemStyle>
											<ItemStyle CssClass="DataGridItem"></ItemStyle>
											<HeaderStyle HorizontalAlign="Center" CssClass="DataGridHeader" BackColor="#663300"></HeaderStyle>
											<FooterStyle ForeColor="white" BackColor="#663300"></FooterStyle>
											<Columns>
												<asp:BoundColumn DataField="Student_ID" HeaderText="Student ID" FooterText="Total">
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<FooterStyle Font-Bold="True" HorizontalAlign="Center"></FooterStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Student_Class" HeaderText="Class">
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="seq_student_id" HeaderText="Section">
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Left" DataField="Student_FName" HeaderText="Student Name"></asp:BoundColumn>
												<asp:TemplateColumn HeaderText="Security Amount">
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
													<ItemTemplate>
														<%#GetSecurityAmount(DataBinder.Eval(Container.DataItem,"securityfee").ToString())%>
													</ItemTemplate>
													<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
													<FooterTemplate>
														<%=Cache["amt"].ToString()%>
													</FooterTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
										</asp:datagrid></TD></TR>
							</asp:Panel>
						</TABLE>
					</td>
					<td></td>
				</tr>
				<tr>
					<td colSpan="3"><asp:validationsummary id="vsPaySlip" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
				</tr>
			</table>
			<!--PopCalendar(tag name and id must match) Tags should sit at the page bottom --><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189">
			</iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
