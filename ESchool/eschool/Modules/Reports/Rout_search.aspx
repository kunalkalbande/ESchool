<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="Rout_search.aspx.cs" AutoEventWireup="false" Inherits="eschool.localuserReports.Rout_search" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>eSchool : Route Search Report</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Rout_search" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<TBODY>
					<tr>
						<td vAlign="top" align="center"><B>ROUTE SEARCH REPORT</B>
							<TABLE id="Table1" cellSpacing="1" cellPadding="1" borderColorLight="#663300" border="5">
								<TBODY>
									<TR>
										<TD align="center">Search By &nbsp;<asp:dropdownlist id="Dropstype" runat="server" CssClass="ComboBox" AutoPostBack="True">
												<asp:ListItem Value="---Select--">---Select--</asp:ListItem>
												<asp:ListItem Value="Class Wise">Class Wise</asp:ListItem>
												<asp:ListItem Value="Route Name Wise">Route Name Wise</asp:ListItem>
												<asp:ListItem Value="Route No Wise">Route No Wise</asp:ListItem>
												<asp:ListItem Value="StudentID Wise">StudentID Wise</asp:ListItem>
											</asp:dropdownlist>&nbsp; &nbsp;Select Option&nbsp; &nbsp;<asp:dropdownlist id="Dropsopt" runat="server" CssClass="ComboBox" AutoPostBack="False">
												<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
											</asp:dropdownlist>&nbsp;&nbsp;&nbsp;<asp:dropdownlist id="DropSection" AutoPostBack="False" CssClass="ComboBox" Runat="server">
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
											</asp:dropdownlist>&nbsp; <BUTTON id="Search" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 100px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
												accessKey="S" type="button" runat="server"><IMG id="txtsearch" height="7" src="../../HeaderFooter/images/search.gif" width="16">
												<U>S</U>earch</BUTTON>&nbsp;<BUTTON id="BtnPrint" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
												accessKey="S" type="button" runat="server" class="FormButtonStyle">&nbsp;<U>P</U>rint</BUTTON>&nbsp;<BUTTON id="BtnExcel" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
												accessKey="S" type="button" runat="server" class="FormButtonStyle">&nbsp;<U>E</U>xcel</BUTTON></TD>
									</TR>
									<asp:Panel ID="pangrid" Runat="server" Visible="False">
        <TR>
          <TD>
<asp:datagrid id=DataGridsearch Runat="server" Width="750" AutoGenerateColumns="False" Height="104px">
													<AlternatingItemStyle CssClass="DatagridAlternatingStyle"></AlternatingItemStyle>
													<ItemStyle CssClass="DataGridItem"></ItemStyle>
													<HeaderStyle CssClass="DataGridHeader" BackColor="#663300"></HeaderStyle>
													<FooterStyle ForeColor="Black" BackColor="#CCCC99"></FooterStyle>
													<Columns>
														<asp:BoundColumn DataField="routeno" HeaderText="Route No"></asp:BoundColumn>
														<asp:BoundColumn DataField="routename" HeaderText="Route Name"></asp:BoundColumn>
														<asp:BoundColumn DataField="Student_ID" HeaderText="Student ID"></asp:BoundColumn>
														<asp:BoundColumn DataField="Student_FName" HeaderText="Student Name"></asp:BoundColumn>
														<asp:BoundColumn DataField="Student_Class" HeaderText="Class "></asp:BoundColumn>
														<asp:BoundColumn DataField="Seq_Student_id" HeaderText="Section"></asp:BoundColumn>
														<asp:BoundColumn DataField="Student_Stream" HeaderText="Stream"></asp:BoundColumn>
														<asp:BoundColumn DataField="scategory" HeaderText="SCategory"></asp:BoundColumn>
														<asp:BoundColumn DataField="rank" HeaderText="Rank"></asp:BoundColumn>
														<asp:BoundColumn DataField="bg" HeaderText="Blood Group"></asp:BoundColumn>
														<asp:BoundColumn DataField="Student_PAddress" HeaderText="Loc Address"></asp:BoundColumn>
														<asp:BoundColumn DataField="Student_PHNo" HeaderText="Phone No"></asp:BoundColumn>
													</Columns>
													<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
												</asp:datagrid></TD></TR>
									</asp:Panel>
						</td>
					</tr>
					<!--tr>
						<td colSpan="7"><asp:validationsummary id="vsRouteSearch" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></td>
					</tr-->
				</TBODY>
			</table></TD></TR></TBODY></TABLE>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
