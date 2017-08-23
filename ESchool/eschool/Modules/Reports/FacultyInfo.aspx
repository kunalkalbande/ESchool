<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="FacultyInfo.aspx.cs" AutoEventWireup="false" Inherits="eschool.e_Coaching.Form.FacultyInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>eSchool : Staff Information Report</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body>
		<form id="FacultyInfo" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td style="HEIGHT: 19px" align="center" colSpan="3"><asp:label id="Label2" runat="server">
							<b>STAFF INFORMATION REPORT</b></asp:label>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" borderColorLight="#663300" border="5">
							<TBODY>
								<TR borderColorLight="#663300">
									<TD align="center" colSpan="3">Staff Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:dropdownlist id="Dropstype" runat="server" CssClass="ComboBox" AutoPostBack="true">
											<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
											<asp:ListItem Value="All">All</asp:ListItem>
											<asp:ListItem Value="Teaching">Teaching</asp:ListItem>
											<asp:ListItem Value="Non Teaching">Non Teaching</asp:ListItem>
											<asp:ListItem Value="Group D">Group D</asp:ListItem>
											<asp:ListItem Value="Activity">Activity</asp:ListItem>
										</asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp; Designation
										<asp:dropdownlist id="Dropsopt" runat="server" CssClass="ComboBox">
											<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
										</asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:button id="Button1" runat="server" CssClass="formbuttonstyle" Text="Search" BorderColor="Black"
											 Width="100px" Height="21" Font-Size="X-Small"></asp:button>&nbsp;
										<asp:button id="btnPrint1" runat="server" CssClass="formbuttonstyle" Text="Print" BorderColor="Black"
											 Width="85px" Height="21" Font-Size="X-Small"></asp:button>&nbsp;
										<asp:button id="Btnexcel" runat="server" CssClass="formbuttonstyle" Text="Excel" BorderColor="Black"
											 Width="85px" Height="21" Font-Size="X-Small"></asp:button></TD>
								</TR>
								<asp:Panel ID="panal1" Runat="server" Visible="False">
        <TR>
          <TD vAlign=top align=center>
<asp:datagrid id=dgrdFaculty Width="406px" Runat="server" AutoGenerateColumns="False">
												<AlternatingItemStyle CssClass="DatagridAlternatingStyle"></AlternatingItemStyle>
												<ItemStyle CssClass="DataGridItem"></ItemStyle>
												<HeaderStyle HorizontalAlign="Center" CssClass="DataGridHeader" BackColor="#663300"></HeaderStyle>
												<FooterStyle ForeColor="Black" BackColor="#663300"></FooterStyle>
												<Columns>
													<asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="Staff_ID" HeaderText="Staff_ID"></asp:BoundColumn>
													<asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="Staff_Type" HeaderText="Designation"></asp:BoundColumn>
													<asp:BoundColumn ItemStyle-HorizontalAlign="Right" DataField="Doj" HeaderText="Date of Joining " 
 DataFormatString="{0:d}"></asp:BoundColumn>
													<asp:BoundColumn DataField="natapp" HeaderText=" Nature of Appointmemt"></asp:BoundColumn>
													<asp:BoundColumn DataField="Staff_Name" HeaderText="Employee_Name"></asp:BoundColumn>
													<asp:BoundColumn DataField="father_name" HeaderText="Father_Name"></asp:BoundColumn>
													<asp:BoundColumn DataField="Staff_education" HeaderText="Qualification "></asp:BoundColumn>
													<asp:BoundColumn DataField="prof_qui" HeaderText=" Prof Quli"></asp:BoundColumn>
													<asp:BoundColumn DataField="age" HeaderText="Dob" DataFormatString="{0:d}"></asp:BoundColumn>
													<asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="Staff_exp" HeaderText="Experience"></asp:BoundColumn>
													<asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="sex" HeaderText="Gender "></asp:BoundColumn>
													<asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="maritial_status" HeaderText=" Maritial Status"></asp:BoundColumn>
													<asp:BoundColumn DataField="Staff_EmailID" HeaderText="EMail ID"></asp:BoundColumn>
													<asp:BoundColumn DataField="Subject_Take" HeaderText="Subject Take"></asp:BoundColumn>
													<asp:BoundColumn DataField="Phone_No" HeaderText="Phone No "></asp:BoundColumn>
													<asp:BoundColumn DataField="Mobile_No" HeaderText=" Mobile No"></asp:BoundColumn>
													<asp:BoundColumn DataField="Staff_LocalAddress" HeaderText="LocalAddress"></asp:BoundColumn>
												</Columns>
												<PagerStyle NextPageText="Next" PrevPageText="Previous"></PagerStyle>
											</asp:datagrid></TD></TR><!--TR>
									<TD align="center" colSpan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:button id="BtnPrint" CssClass="formbuttonstyle" Text="Print Preview" Runat="server" Width="95px"
										Enabled="False" Visible="False"></asp:button>&nbsp;</TD>
								</TR-->
								</asp:Panel>
							</TBODY>
						</TABLE>
					</td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
