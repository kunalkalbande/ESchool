<%@ Page language="c#" Codebehind="ParentsInformation.aspx.cs" AutoEventWireup="false" Inherits="eschool.Reports.ParentsInformation" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ParentsInformation</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="ParentsInformation" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td colSpan="3"></td>
				</tr>
				<tr>
					<td style="HEIGHT: 13px" align="center" colSpan="3"><asp:label id="Label2" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td vAlign="top" align="center"><b>PARENTS INFORMATION REPORT</b>
						<TABLE id="Table1" style="WIDTH: 622px" cellSpacing="-1" cellPadding="-1" width="622" borderColorLight="#663300"
							border="5">
							<TR>
								<TD style="HEIGHT: 24px" align="center"><FONT size="1">Student ID</FONT></TD>
								<TD style="HEIGHT: 24px" align="center"><asp:dropdownlist id="DropSearchName1" runat="server" CssClass="ComboBox" Visible="False">
										<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
									</asp:dropdownlist>
									<asp:TextBox id="DropSearchName" runat="server" Width="65px"></asp:TextBox></TD>
								<TD style="HEIGHT: 24px" align="center"><BUTTON id="Search" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 120px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 24px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server"><IMG id="txtsearch" style="WIDTH: 16px; HEIGHT: 6px" height="6" src="../../HeaderFooter/images/search.gif"
											width="16"> <U>S</U>earch</BUTTON></TD>
								<TD style="HEIGHT: 24px" align="center"><BUTTON id="Button1" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 120px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 24px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server" class="FormButtonStyle"><U>P</U>rint</BUTTON></TD>
							</TR>
							<TR>
								<TD colSpan="4"><asp:datagrid id="dgrdParentsInfo" Width="800px" AutoGenerateColumns="False" Runat="server">
										<AlternatingItemStyle CssClass="DatagridAlternatingStyle"></AlternatingItemStyle>
										<ItemStyle CssClass="DataGridItem"></ItemStyle>
										<HeaderStyle Font-Bold="True" ForeColor="White" CssClass="DataGridHeader" BackColor="#663300"></HeaderStyle>
										<FooterStyle ForeColor="Black" BackColor="#CCCC99"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="Student_FatherName" HeaderText="Fathers Name"></asp:BoundColumn>
											<asp:BoundColumn DataField="Student_MotherName" HeaderText="Mothers Name"></asp:BoundColumn>
											<asp:BoundColumn DataField="Student_FatherMobileno" HeaderText="Father Mobile No"></asp:BoundColumn>
											<asp:BoundColumn DataField="Student_MotherMobileno" HeaderText="Mother Mobile No"></asp:BoundColumn>
											<asp:BoundColumn DataField="Student_FatherOccp" HeaderText="Father Occupation"></asp:BoundColumn>
											<asp:BoundColumn DataField="Student_MotherOccp" HeaderText="Mother Occupation"></asp:BoundColumn>
											<asp:BoundColumn DataField="Student_FatherAnnualIncome" HeaderText=" F Annual Income"></asp:BoundColumn>
											<asp:BoundColumn DataField="Student_MotherAnnualIncome" HeaderText="M Annual Income"></asp:BoundColumn>
											<asp:BoundColumn DataField="Student_FatherEmailID" HeaderText="F Email_ID"></asp:BoundColumn>
											<asp:BoundColumn DataField="Student_MotherEmailID" HeaderText="M Email_ID"></asp:BoundColumn>
											<asp:BoundColumn DataField="Student_Category" HeaderText="Category"></asp:BoundColumn>
											<asp:BoundColumn DataField="scategory" HeaderText="SCategory"></asp:BoundColumn>
											<asp:BoundColumn DataField="rank" HeaderText="Rank"></asp:BoundColumn>
										</Columns>
										<PagerStyle NextPageText="Next" PrevPageText="Previous"></PagerStyle>
									</asp:datagrid></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
