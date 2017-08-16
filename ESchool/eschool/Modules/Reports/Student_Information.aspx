<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="Student_Information.aspx.cs" AutoEventWireup="false" Inherits="eschool.Reports.Student_Information" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Student Information Report</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Student_Information" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td align="center" colSpan="3"><asp:label id="Label2" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td vAlign="top" align="center"><b>STUDENT INFORMATION REPORT</b>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" borderColorLight="#663300" border="5">
							<TR>
								<td align="center">&nbsp;Search By&nbsp;<asp:dropdownlist id="Dropstype" runat="server" CssClass="ComboBox" AutoPostBack="True">
										<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
										<asp:ListItem Value="StudentID Wise">StudentID Wise</asp:ListItem>
										<asp:ListItem Value="Class Wise">Class Wise</asp:ListItem>
									</asp:dropdownlist><asp:comparevalidator id="CompareValidator1" Runat="server" ErrorMessage="Select option" ControlToValidate="Dropstype"
										ValueToCompare="---Select---" Display="Dynamic" Operator="NotEqual">*</asp:comparevalidator>
									&nbsp;&nbsp;<asp:label id="lblOption" Runat="server" Visible="False">Select Option</asp:label>&nbsp;&nbsp;<asp:dropdownlist id="Dropsopt" CssClass="ComboBox" Runat="server" Visible="False">
										<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
									</asp:dropdownlist>&nbsp;<asp:dropdownlist id="DropSection" CssClass="ComboBox" Runat="server">
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
									</asp:dropdownlist>&nbsp;&nbsp;
									<asp:textbox id="txtStudentid" BorderStyle="Groove" Runat="server" Visible="False" Width="40"></asp:textbox>&nbsp;&nbsp;<BUTTON id="Search" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 103px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 22px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server"><IMG id="txtsearch" height="7" src="../../HeaderFooter/images/search.gif" width="16">
										<U>S</U>earch</BUTTON> &nbsp;&nbsp;<BUTTON class="FormButtonStyle" id="Print1" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 22px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server">&nbsp; <U>P</U>rint</BUTTON> &nbsp;&nbsp;<BUTTON class="FormButtonStyle" id="excel" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 22px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server">&nbsp; <U>E</U>xcel</BUTTON></td>
							</TR>
							<asp:panel id="GridPanal" Runat="server" Visible="False">
								<TR>
									<TD align="center">
										<asp:datagrid id="dgrdStudentInfo" Runat="server" Width="750px" AutoGenerateColumns="False">
											<AlternatingItemStyle CssClass="DatagridAlternatingStyle"></AlternatingItemStyle>
											<ItemStyle CssClass="DataGridItem"></ItemStyle>
											<HeaderStyle Font-Bold="True" ForeColor="White" CssClass="DataGridHeader" BackColor="#663300"></HeaderStyle>
											<FooterStyle ForeColor="Black" BackColor="#663300"></FooterStyle>
											<Columns>
												<asp:TemplateColumn HeaderText="SNo">
													<ItemTemplate>
														<%=i++%>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="Student_ID" HeaderText="Student ID"></asp:BoundColumn>
												<asp:BoundColumn DataField="scategory" HeaderText="SCategory"></asp:BoundColumn>
												<asp:BoundColumn DataField="Student_FName" HeaderText="Student Name"></asp:BoundColumn>
												<asp:BoundColumn DataField="Student_FatherName" HeaderText="Father Name"></asp:BoundColumn>
												<asp:BoundColumn DataField="Student_PAddress" HeaderText="P-Address"></asp:BoundColumn>
												<asp:BoundColumn DataField="Student_PHNo" HeaderText="Phone No"></asp:BoundColumn>
												<asp:BoundColumn DataField="Student_Class" HeaderText="Class "></asp:BoundColumn>
												<asp:BoundColumn DataField="Seq_Student_id" HeaderText="Section"></asp:BoundColumn>
												<asp:BoundColumn DataField="Student_Stream" HeaderText="Stream"></asp:BoundColumn>
												<asp:BoundColumn DataField="house" HeaderText="House Name"></asp:BoundColumn>
												<asp:BoundColumn DataField="rank" HeaderText="Rank"></asp:BoundColumn>
												<asp:BoundColumn DataField="Student_Category" HeaderText="Category"></asp:BoundColumn>
												<asp:BoundColumn DataField="Student_AdmissionDate" HeaderText="Admission Date" DataFormatString="{0:d}"></asp:BoundColumn>
												<asp:BoundColumn DataField="Student_BirthDate" HeaderText="Birth Date" DataFormatString="{0:d}"></asp:BoundColumn>
											</Columns>
											<PagerStyle Visible="False" NextPageText="Next" PrevPageText="Previous"></PagerStyle>
										</asp:datagrid></TD>
								</TR>
							</asp:panel></TABLE>
						<table id="Table2" cellSpacing="1" cellPadding="1" width="400" borderColorLight="#663300"
							border="1">
							<asp:panel id="GridStudWise" Runat="server" Visible="False">
								<TBODY>
									<TR>
										<TD align="center" bgColor="#663300"><B><FONT color="#ffffff">Student ID</FONT></B></TD>
										<TD>&nbsp;&nbsp;&nbsp;<%=Student_Id.ToString()%></TD>
									</TR>
									<TR>
										<TD align="center" bgColor="#663300"><B><FONT color="#ffffff">Scategory</FONT></B></TD>
										<TD>&nbsp;&nbsp;&nbsp;<%=Scategory%></TD>
									</TR>
									<TR>
										<TD align="center" bgColor="#663300"><B><FONT color="#ffffff">Student Name</FONT></B></TD>
										<TD>&nbsp;&nbsp;&nbsp;<%=Student_Name%></TD>
									</TR>
									<TR>
										<TD align="center" bgColor="#663300"><B><FONT color="#ffffff">Father Name</FONT></B></TD>
										<TD>&nbsp;&nbsp;&nbsp;<%=Student_Fname%></TD>
									</TR>
									<TR>
										<TD align="center" bgColor="#663300"><B><FONT color="#ffffff">Address</FONT></B></TD>
										<TD>&nbsp;&nbsp;&nbsp;<%=Addr%></TD>
									</TR>
									<TR>
										<TD align="center" bgColor="#663300"><B><FONT color="#ffffff">Phone</FONT></B></TD>
										<TD>&nbsp;&nbsp;&nbsp;<%=Phone%></TD>
									</TR>
									<TR>
										<TD align="center" bgColor="#663300"><B><FONT color="#ffffff">Class</FONT></B></TD>
										<TD>&nbsp;&nbsp;&nbsp;<%=Class%></TD>
									</TR>
									<TR>
										<TD align="center" bgColor="#663300"><B><FONT color="#ffffff">Section</FONT></B></TD>
										<TD>&nbsp;&nbsp;&nbsp;<%=Sec%></TD>
									</TR>
									<TR>
										<TD align="center" bgColor="#663300"><B><FONT color="#ffffff">Stream</FONT></B></TD>
										<TD>&nbsp;&nbsp;&nbsp;<%=Stream%></TD>
									</TR>
									<TR>
										<TD align="center" bgColor="#663300"><B><FONT color="#ffffff">House</FONT></B></TD>
										<TD>&nbsp;&nbsp;&nbsp;<%=House%></TD>
									</TR>
									<TR>
										<TD align="center" bgColor="#663300"><B><FONT color="#ffffff">Rank</FONT></B></TD>
										<TD>&nbsp;&nbsp;&nbsp;<%=Rank%></TD>
									</TR>
									<TR>
										<TD align="center" bgColor="#663300"><B><FONT color="#ffffff">Category</FONT></B></TD>
										<TD>&nbsp;&nbsp;&nbsp;<%=Categ%></TD>
									</TR>
									<TR>
										<TD align="center" bgColor="#663300"><B><FONT color="#ffffff">Date Of Admission</FONT></B></TD>
										<TD>&nbsp;&nbsp;&nbsp;<%=DoAdm%></TD>
									</TR>
									<TR>
										<TD align="center" bgColor="#663300"><B><FONT color="#ffffff">Date Of Birth</FONT></B></TD>
										<TD>&nbsp;&nbsp;&nbsp;<%=DOB%></TD>
									</TR>
							</asp:panel></table>
					</td>
					<td></td>
				</tr>
				<TR>
					<TD colSpan="3"></TD>
				</TR>
				</TBODY></table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
