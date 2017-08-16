<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="FeesDecisionReport.aspx.cs" AutoEventWireup="false" Inherits="eschool.StudentFees.FeesDecisionReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Fees Decision Report</title><!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<script src="menu81_com.js" type="text/javascript"></script>
		<form id="FeesDecisionReport" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<TR>
					<td align="center" colSpan="3"><asp:label id="Label2" runat="server"></asp:label></td>
				</TR>
				<tr>
					<td vAlign="top" align="center"><b>FEES DECISION REPORT</b>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="70%" borderColorLight="#663300"
							border="5">
							<TR>
								<TD align="center">Class
									<asp:dropdownlist id="dropStudentClasss" Runat="server" CssClass="ComboBox">
										<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
										<asp:ListItem Value="All">All</asp:ListItem>
									</asp:dropdownlist>
									&nbsp;&nbsp;&nbsp;&nbsp;<BUTTON class="FormButtonStyle" id="Search" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 100px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server"><IMG id="txtsearch" height="7" src="../../HeaderFooter/images/search.gif" width="16"><U>S</U>earch</BUTTON>
									&nbsp;&nbsp;&nbsp;&nbsp;<BUTTON id="BtnPrint" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server">Print</BUTTON> &nbsp;&nbsp;&nbsp;&nbsp;<BUTTON id="BtnExcel" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server">Excel</BUTTON>
								</TD>
							</TR>
							<asp:Panel ID="panfees" Runat="server" Visible="False">
								<TR>
									<TD>
										<asp:datagrid id="gridfeesdecision" Runat="server" AutoGenerateColumns="False" Width="70%">
											<AlternatingItemStyle CssClass="DatagridAlternatingStyle"></AlternatingItemStyle>
											<ItemStyle CssClass="DataGridItem"></ItemStyle>
											<HeaderStyle HorizontalAlign="Center" ForeColor="White" Font-Bold="True" BackColor="#663300"></HeaderStyle>
											<FooterStyle ForeColor="Black" BackColor="#CCCC99"></FooterStyle>
											<Columns>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="class_name" HeaderText="Class"></asp:BoundColumn>
												<asp:BoundColumn DataField="student_stream" HeaderText="Stream"></asp:BoundColumn>
												<asp:BoundColumn DataField="feemode" HeaderText="Fee_Mode"></asp:BoundColumn>
												<asp:BoundColumn DataField="scategory" HeaderText="SCategory"></asp:BoundColumn>
												<asp:BoundColumn DataField="srank" HeaderText="Rank"></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Right" DataField="diary_fee" HeaderText="Diary" DataFormatString="{0:N2}"></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Right" DataField="tution_fee" HeaderText="Tution" DataFormatString="{0:N2}"></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Right" DataField="computer_fee" HeaderText="Computer"
													DataFormatString="{0:N2}"></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Right" DataField="science_fee" HeaderText="Science" DataFormatString="{0:N2}"></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Right" DataField="games_fee" HeaderText="Games" DataFormatString="{0:N2}"></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Right" DataField="admission_fee" HeaderText="Admission"
													DataFormatString="{0:N2}"></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Right" DataField="caution_fee" HeaderText="Security"
													DataFormatString="{0:N2}"></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Right" DataField="annual_fee" HeaderText="Annual" DataFormatString="{0:N2}"></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Right" DataField="envp_fee" HeaderText="Env" DataFormatString="{0:N2}"></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Right" DataField="hostel_fee" HeaderText="Hostel" DataFormatString="{0:N2}"></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Right" DataField="total" HeaderText="Total" DataFormatString="{0:N2}"></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Right" DataField="remarks" HeaderText="Remarks"></asp:BoundColumn>
											</Columns>
										</asp:datagrid></TD>
								</TR>
							</asp:Panel></TABLE>
					</td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
