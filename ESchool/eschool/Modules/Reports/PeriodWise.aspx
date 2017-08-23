<%@ Page language="c#" Codebehind="PeriodWise.aspx.cs" AutoEventWireup="false" Inherits="eschool.Reports.PeriodWise" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>eSchool : Period Wise Time Table</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width=778 align="center">
				<tr>
					<td align="center" colSpan="3"><asp:label id="Label2" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td align="center"><b>PERIOD WISE TIME TABLE</b>
						<table bordercolorlight="#663300" width="80%" border="5" align="center">
							<tr>
								<td>Day&nbsp;
								&nbsp;<asp:dropdownlist CssClass=ComboBox id="DropDay" Runat="server">
										<asp:ListItem Value="Select">Select</asp:ListItem>
										<asp:ListItem Value="Monday">Monday</asp:ListItem>
										<asp:ListItem Value="Tuesday">Tuesday</asp:ListItem>
										<asp:ListItem Value="Wednesday">Wednesday</asp:ListItem>
										<asp:ListItem Value="Thruesday">Thruesday</asp:ListItem>
										<asp:ListItem Value="Friday">Friday</asp:ListItem>
										<asp:ListItem Value="Saturday">Saturday</asp:ListItem>
									</asp:dropdownlist>&nbsp;
								&nbsp;Period&nbsp;
								&nbsp;<asp:dropdownlist CssClass=ComboBox id="DropPeriod" Runat="server">
										<asp:ListItem Value="Select">Select</asp:ListItem>
										<asp:ListItem Value="I">I</asp:ListItem>
										<asp:ListItem Value="II">II</asp:ListItem>
										<asp:ListItem Value="III">III</asp:ListItem>
										<asp:ListItem Value="IV">IV</asp:ListItem>
										<asp:ListItem Value="V">V</asp:ListItem>
										<asp:ListItem Value="VI">VI</asp:ListItem>
										<asp:ListItem Value="VII">VII</asp:ListItem>
										<asp:ListItem Value="VIII">VIII</asp:ListItem>
									</asp:dropdownlist>&nbsp;
								&nbsp;&nbsp;<asp:button id="btnShow" Runat="server" Text="Show" CssClass="FormButtonStyle" BorderColor="Black" Width="100px" Height=21 ></asp:button>&nbsp;&nbsp;
								&nbsp;&nbsp;<asp:button id="btnPrint" Runat="server" Text="Print" CssClass="FormButtonStyle" BorderColor="Black" Width="85px" Height=21 ></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
								&nbsp;&nbsp;<asp:button id="Btnexcel" Runat="server" Text="Excel" CssClass="FormButtonStyle" BorderColor="Black" Width="85px" Height=21 ></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;</td>
							</tr>
							<asp:Panel ID=pangrid Runat=server Visible=False>
        <TR>
          <TD>
<asp:DataGrid id=DataGrid1 runat="server" Width="100%" AutoGenerateColumns="False">
										<HeaderStyle CssClass="DataGridHeader" BackColor="#663300"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="shortname" HeaderText="Teacher Short Name">
												<HeaderStyle Font-Bold="True" BackColor="#663300" HorizontalAlign="Center"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="sub" HeaderText="Subject (Class & Sec.)">
												<HeaderStyle Font-Bold="True" BackColor="#663300" HorizontalAlign="Center"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
									</asp:DataGrid></TD></TR>
							</asp:Panel>
						</table>
					</td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form></FORM>
	</body>
</HTML>
