<%@ Page language="c#" Codebehind="StudentAttendance.aspx.cs" AutoEventWireup="false" Inherits="eschool.Form.StudentAttendance" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Student Attendance</title>
		<meta content="False" name="vs_snapToGrid"> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<script language="JavaScript">
		// this method use to select all check box on a single click.
		function selectAll()
		{
			var f=document.Form1
			if(f.chkSelectAll.checked)
				for(var i=0;i<f.length;i++)
					f.elements[i].checked=true
			else
				for(var i=0;i<f.length;i++)
					f.elements[i].checked=false
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table id="Table1" height="250" width="778" align="center">
				<tr>
					<td vAlign="top" align="center"><asp:label id="Label3" runat="server" Font-Bold="True">STUDENT ATTENDANCE</asp:label>
						<table id="Table2" align="center" borderColorLight="#663300" border="5">
							<tr>
								<td>&nbsp;Class&nbsp;<font color="red" size="1">*</font>&nbsp;<asp:dropdownlist id="Dropclass" CssClass="ComboBox" Runat="server">
										<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
									</asp:dropdownlist>
									<asp:comparevalidator id="Comparevalidator1" runat="server" ControlToValidate="Dropclass" ErrorMessage="Please Select The Class"
										Operator="NotEqual" ValueToCompare="---Select---">*</asp:comparevalidator>&nbsp;Section&nbsp;
									<font color="red" size="1">*</font>&nbsp;<asp:dropdownlist id="dropSection" runat="server" CssClass="ComboBox">
										<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
										<asp:ListItem Value="A">A</asp:ListItem>
										<asp:ListItem Value="B">B</asp:ListItem>
										<asp:ListItem Value="C">C</asp:ListItem>
										<asp:ListItem Value="D">D</asp:ListItem>
										<asp:ListItem Value="E">E</asp:ListItem>
										<asp:ListItem Value="F">F</asp:ListItem>
										<asp:ListItem Value="G">G</asp:ListItem>
										<asp:ListItem Value="H">H</asp:ListItem>
										<asp:ListItem Value="I">I</asp:ListItem>
										<asp:ListItem Value="J">j</asp:ListItem>
									</asp:dropdownlist>
									<asp:comparevalidator id="Comparevalidator2" runat="server" ControlToValidate="DropSection" ErrorMessage="Please Select The Section"
										Operator="NotEqual" ValueToCompare="---Select---">*</asp:comparevalidator>&nbsp;Stream&nbsp;
									<asp:dropdownlist id="dropStream" runat="server" CssClass="ComboBox">
										<asp:ListItem Value="None">None</asp:ListItem>
										<asp:ListItem Value="Bio Group">Bio Group</asp:ListItem>
										<asp:ListItem Value="Commerce Group">Commerce Group</asp:ListItem>
										<asp:ListItem Value="Math Group">Math Group</asp:ListItem>
									</asp:dropdownlist>&nbsp;
								</td>
							</tr>
							<tr>
								<TD align="center">&nbsp;<asp:button id="btnShow" runat="server" CssClass="FormButtonStyle" Text="Show"></asp:button>&nbsp;
									<asp:button id="btnSave" CssClass="FormButtonStyle" Runat="server" Text="Save"></asp:button>&nbsp;
									<asp:button id="btnReset" CssClass="FormButtonStyle" Runat="server" Text="Reset" CausesValidation="False"
										Visible="False"></asp:button>&nbsp;<asp:ValidationSummary ID="Summary" Runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary></TD>
							</tr>
							<asp:panel id="panatted" Runat="server" Visible="False">
								<TR>
									<TD>
										<asp:datagrid id="dgrdStudentAttendance" runat="server" AutoGenerateColumns="False" AllowCustomPaging="True"
											Width="100%" AllowPaging="True" PageSize="50" OnItemDataBound="ItemDataBound">
											<AlternatingItemStyle CssClass="DatagridAlternatingStyle"></AlternatingItemStyle>
											<ItemStyle HorizontalAlign="Center" CssClass="DataGridItem"></ItemStyle>
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center" CssClass="DataGridHeader" BackColor="#663300"></HeaderStyle>
											<Columns>
												<asp:BoundColumn DataField="RollNo" HeaderText="Roll No"></asp:BoundColumn>
												<asp:BoundColumn DataField="SName" HeaderText="Student Name">
													<ItemStyle HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn HeaderText="Attendance">
													<ItemTemplate>
														<asp:CheckBox id="Chk" runat="server"></asp:CheckBox>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle NextPageText="Next" PrevPageText="Previous" CssClass="DatagridPagerstyle"></PagerStyle>
										</asp:datagrid></TD>
								</TR>
								<TR>
									<TD align="right"><INPUT onclick="selectAll();" type="checkbox" name="chkSelectAll">
										<asp:label id="Label1" runat="server" ForeColor="Red">Select All</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:validationsummary id="vsStuMarks" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD>
								</TR>
							</asp:panel></table>
					</td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
