<%@ Import namespace="RMG"%>
<%@ Import namespace="eschool.Classes"%>
<%@ Import namespace="DBOperations"%>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Page language="c#" Codebehind="Timetableadjustment.aspx.cs" AutoEventWireup="false" Inherits="eschool.Form.Timetableadjustment" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Time Table Adjustment</title><!--
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
		<form id="Timetableadjustment" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" align="center">
			
				<tr>
					<td vAlign="top" align="center"><asp:label id="Label1" runat="server">
							<b>TIME TABLE ADJUSTMENT</b></asp:label>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" borderColorLight="#663300" border="5">
						<tr>
								<td colspan=2><asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label></td>
							</tr>
							<TR>
								<TD>&nbsp;Teacher&nbsp;Name&amp;&nbsp;ID&nbsp;<font color="#ff0300" size=1>*</font></TD>
								<TD><asp:dropdownlist CssClass="ComboBox" id="Dropempid" runat="server" AutoPostBack="True" Width="180px"></asp:dropdownlist>
									<asp:CompareValidator ID="validationIdName" Runat="server" ControlToValidate="Dropempid" ValueToCompare="Select"
										Operator="NotEqual" ErrorMessage="Please Select Employee Name And ID">*</asp:CompareValidator>&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:textbox id="txtdesig" runat="server" Width="100px" Visible="False" Enabled="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>&nbsp;Designation&nbsp;<font color="#ff0033" size=1>*</font></TD>
								<TD><asp:dropdownlist CssClass="ComboBox" id="Dropdesig" runat="server" Width="100px">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist><asp:CompareValidator ID="compvaliDesgi" Runat="server" ControlToValidate="Dropdesig" ValueToCompare="Select"
										Operator="NotEqual" ErrorMessage="Please Select Designation">*</asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD>&nbsp;Day&nbsp;<font color="#ff0033" size=1>*</font></TD>
								<TD><asp:dropdownlist CssClass="ComboBox" id="Dropday" runat="server" AutoPostBack="True" Width="100px">
										<asp:ListItem Value="Select">Select</asp:ListItem>
										<asp:ListItem Value="Monday">Monday</asp:ListItem>
										<asp:ListItem Value="Tuesday">Tuesday</asp:ListItem>
										<asp:ListItem Value="Wednesday">Wednesday</asp:ListItem>
										<asp:ListItem Value="Thrusday">Thrusday</asp:ListItem>
										<asp:ListItem Value="Friday">Friday</asp:ListItem>
										<asp:ListItem Value="Saturday">Saturday</asp:ListItem>
									</asp:dropdownlist><asp:CompareValidator ID="comvaliday" Runat="server" ControlToValidate="Dropday" ValueToCompare="Select"
										Operator="NotEqual" ErrorMessage="Please Select Day">*</asp:CompareValidator></TD>
							</TR>
							<asp:panel id="PanStaff" Runat="server">
								<TR>
									<TD colSpan="2">
										<TABLE borderColor="#663300" border="3">
											<TR>
												<%
			try
			{
              InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr=null;
				string str="";
				if(Dropday.SelectedIndex!=0)
				{
					if(Dropday.SelectedItem.Text=="Monday")
						str="select mon1,mon2,mon3,mon4,mon5,mon6,mon7,mon8 from teachertimetable where employee_id=(select staff_id from staff_information where staff_name='"+Dropempid.SelectedItem.Text.Trim().Substring((Dropempid.SelectedItem.Text.Trim().IndexOf(":")+1),(Dropempid.SelectedItem.Text.Trim().Length-Dropempid.SelectedItem.Text.Trim().IndexOf(":")-1))+"')";
					else if(Dropday.SelectedItem.Text=="Tuesday")
					    str="select tue1,tue2,tue3,tue4,tue5,tue6,tue7,tue8 from teachertimetable where employee_id=(select staff_id from staff_information where staff_name='"+Dropempid.SelectedItem.Text.Trim().Substring((Dropempid.SelectedItem.Text.Trim().IndexOf(":")+1),(Dropempid.SelectedItem.Text.Trim().Length-Dropempid.SelectedItem.Text.Trim().IndexOf(":")-1))+"')";
					else if(Dropday.SelectedItem.Text=="Wednesday")
						str="select wed1,wed2,wed3,wed4,wed5,wed6,wed7,wed8 from teachertimetable where employee_id=(select staff_id from staff_information where staff_name='"+Dropempid.SelectedItem.Text.Trim().Substring((Dropempid.SelectedItem.Text.Trim().IndexOf(":")+1),(Dropempid.SelectedItem.Text.Trim().Length-Dropempid.SelectedItem.Text.Trim().IndexOf(":")-1))+"')";
					else if(Dropday.SelectedItem.Text=="Thrusday")
						str="select thu1,thu2,thu3,thu4,thu5,thu6,thu7,thu8 from teachertimetable where employee_id=(select staff_id from staff_information where staff_name='"+Dropempid.SelectedItem.Text.Trim().Substring((Dropempid.SelectedItem.Text.Trim().IndexOf(":")+1),(Dropempid.SelectedItem.Text.Trim().Length-Dropempid.SelectedItem.Text.Trim().IndexOf(":")-1))+"')";
					else if(Dropday.SelectedItem.Text=="Friday")
						str="select fri1,fri2,fri3,fri4,fri5,fri6,fri7,fri8 from teachertimetable where employee_id=(select staff_id from staff_information where staff_name='"+Dropempid.SelectedItem.Text.Trim().Substring((Dropempid.SelectedItem.Text.Trim().IndexOf(":")+1),(Dropempid.SelectedItem.Text.Trim().Length-Dropempid.SelectedItem.Text.Trim().IndexOf(":")-1))+"')";
					else if(Dropday.SelectedItem.Text=="Saturday")
						str="select sat1,sat2,sat3,sat4,sat5,sat6,sat7,sat8 from teachertimetable where employee_id=(select staff_id from staff_information where staff_name='"+Dropempid.SelectedItem.Text.Trim().Substring((Dropempid.SelectedItem.Text.Trim().IndexOf(":")+1),(Dropempid.SelectedItem.Text.Trim().Length-Dropempid.SelectedItem.Text.Trim().IndexOf(":")-1))+"')";
					SqlDtr=obj.GetRecordSet(str);
						if(SqlDtr.Read())
						{
				%>
												<TH style="COLOR: white; BACKGROUND-COLOR: #663300">
													D / P</TH>
												<TH style="COLOR: white; BACKGROUND-COLOR: #663300">
													I</TH>
												<TH style="COLOR: white; BACKGROUND-COLOR: #663300">
													II</TH>
												<TH style="COLOR: white; BACKGROUND-COLOR: #663300">
													III</TH>
												<TH style="COLOR: white; BACKGROUND-COLOR: #663300">
													IV</TH>
												<TH style="COLOR: white; BACKGROUND-COLOR: #663300">
													V</TH>
												<TH style="COLOR: white; BACKGROUND-COLOR: #663300">
													VI</TH>
												<TH style="COLOR: white; BACKGROUND-COLOR: #663300">
													VII</TH>
												<TH style="COLOR: white; BACKGROUND-COLOR: #663300">
													VIII</TH></TR>
											<TR>
												<%if(Dropday.SelectedItem.Text=="Monday")
                {%>
												<TH style="COLOR: white; BACKGROUND-COLOR: #663300">
													Monday</TH>
												<TD><%=SqlDtr["mon1"].ToString()%></TD>
												<TD><%=SqlDtr["mon2"].ToString()%></TD>
												<TD><%=SqlDtr["mon3"].ToString()%></TD>
												<TD><%=SqlDtr["mon4"].ToString()%></TD>
												<TD><%=SqlDtr["mon5"].ToString()%></TD>
												<TD><%=SqlDtr["mon6"].ToString()%></TD>
												<TD><%=SqlDtr["mon7"].ToString()%></TD>
												<TD><%=SqlDtr["mon8"].ToString()%></TD>
												<%}%>
												<%else if(Dropday.SelectedItem.Text=="Tuesday")
                {%>
												<TH style="COLOR: white; BACKGROUND-COLOR: #663300">
													Tuesday</TH>
												<TD><%=SqlDtr["tue1"].ToString()%></TD>
												<TD><%=SqlDtr["tue2"].ToString()%></TD>
												<TD><%=SqlDtr["tue3"].ToString()%></TD>
												<TD><%=SqlDtr["tue4"].ToString()%></TD>
												<TD><%=SqlDtr["tue5"].ToString()%></TD>
												<TD><%=SqlDtr["tue6"].ToString()%></TD>
												<TD><%=SqlDtr["tue7"].ToString()%></TD>
												<TD><%=SqlDtr["tue8"].ToString()%></TD>
												<%}%>
												<%else if(Dropday.SelectedItem.Text=="Wednesday")
                {%>
												<TH style="COLOR: white; BACKGROUND-COLOR: #663300">
													Wednesday</TH>
												<TD><%=SqlDtr["wed1"].ToString()%></TD>
												<TD><%=SqlDtr["wed2"].ToString()%></TD>
												<TD><%=SqlDtr["wed3"].ToString()%></TD>
												<TD><%=SqlDtr["wed4"].ToString()%></TD>
												<TD><%=SqlDtr["wed5"].ToString()%></TD>
												<TD><%=SqlDtr["wed6"].ToString()%></TD>
												<TD><%=SqlDtr["wed7"].ToString()%></TD>
												<TD><%=SqlDtr["wed8"].ToString()%></TD>
												<%}%>
												<%else if(Dropday.SelectedItem.Text=="Thrusday")
                {%>
												<TH style="COLOR: white; BACKGROUND-COLOR: #663300">
													Thrusday</TH>
												<TD><%=SqlDtr["thu1"].ToString()%></TD>
												<TD><%=SqlDtr["thu2"].ToString()%></TD>
												<TD><%=SqlDtr["thu3"].ToString()%></TD>
												<TD><%=SqlDtr["thu4"].ToString()%></TD>
												<TD><%=SqlDtr["thu5"].ToString()%></TD>
												<TD><%=SqlDtr["thu6"].ToString()%></TD>
												<TD><%=SqlDtr["thu7"].ToString()%></TD>
												<TD><%=SqlDtr["thu8"].ToString()%></TD>
												<%}%>
												<%else if(Dropday.SelectedItem.Text=="Friday")
                {%>
												<TH style="COLOR: white; BACKGROUND-COLOR: #663300">
													Friday</TH>
												<TD><%=SqlDtr["fri1"].ToString()%></TD>
												<TD><%=SqlDtr["fri2"].ToString()%></TD>
												<TD><%=SqlDtr["fri3"].ToString()%></TD>
												<TD><%=SqlDtr["fri4"].ToString()%></TD>
												<TD><%=SqlDtr["fri5"].ToString()%></TD>
												<TD><%=SqlDtr["fri6"].ToString()%></TD>
												<TD><%=SqlDtr["fri7"].ToString()%></TD>
												<TD><%=SqlDtr["fri8"].ToString()%></TD>
												<%}%>
												<%else if(Dropday.SelectedItem.Text=="Saturday")
                {%>
												<TH style="COLOR: white; BACKGROUND-COLOR: #663300">
													Saturday</TH>
												<TD><%=SqlDtr["sat1"].ToString()%></TD>
												<TD><%=SqlDtr["sat2"].ToString()%></TD>
												<TD><%=SqlDtr["sat3"].ToString()%></TD>
												<TD><%=SqlDtr["sat4"].ToString()%></TD>
												<TD><%=SqlDtr["sat5"].ToString()%></TD>
												<TD><%=SqlDtr["sat6"].ToString()%></TD>
												<TD><%=SqlDtr["sat7"].ToString()%></TD>
												<TD><%=SqlDtr["sat8"].ToString()%></TD>
												<%}%>
											</TR>
											<%}
                SqlDtr.Close();
                
             %>
											<TR>
												<TD>&nbsp;</TD>
												<TD>
													<asp:DropDownList id="Drop1" Width="115px" CssClass="ComboBox" Runat="server"></asp:DropDownList></TD>
												<TD>
													<asp:DropDownList id="Drop2" Width="115px" CssClass="ComboBox" Runat="server"></asp:DropDownList></TD>
												<TD>
													<asp:DropDownList id="Drop3" Width="115px" CssClass="ComboBox" Runat="server"></asp:DropDownList></TD>
												<TD>
													<asp:DropDownList id="Drop4" Width="115px" CssClass="ComboBox" Runat="server"></asp:DropDownList></TD>
												<TD>
													<asp:DropDownList id="Drop5" Width="115px" CssClass="ComboBox" Runat="server"></asp:DropDownList></TD>
												<TD>
													<asp:DropDownList id="Drop6" Width="115px" CssClass="ComboBox" Runat="server"></asp:DropDownList></TD>
												<TD>
													<asp:DropDownList id="Drop7" Width="115px" CssClass="ComboBox" Runat="server"></asp:DropDownList></TD>
												<TD>
													<asp:DropDownList id="Drop8" Width="115px" CssClass="ComboBox" Runat="server"></asp:DropDownList></TD>
											</TR>
											<%}
											}
                catch(Exception ex)
				{
					CreateLogFiles.ErrorLog ("Form: Timetableadjustment.aspx.cs, Method: HTMLPart. Exception: " + ex.Message + " User: " +Session["password"] );
				}
             %>
										</TABLE>
									</TD>
								</TR>
							</asp:panel>
							<TR>
								<TD align="right">Adjust Date&nbsp;&nbsp;</TD>
								<TD><asp:textbox id="txtadjustdate" CssClass="Fontstyle"  Width=70px BorderStyle=Groove Runat="server"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Timetableadjustment.txtadjustdate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A>
									<asp:requiredfieldvalidator id="rfvDoa" runat="server" ControlToValidate="txtadjustdate" ErrorMessage="You must enter  date of adjust Date">*</asp:requiredfieldvalidator>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								</TD>
							</TR>
							<TR>
								<TD align="center" colSpan="2">
								&nbsp;<asp:button id="btnSave" runat="server" CssClass="formbuttonstyle" Text="Save"></asp:button>
								&nbsp;<asp:button id="BtnReset" Runat="server" CssClass="formbuttonstyle" Text="Reset" CausesValidation="False"></asp:button>
								&nbsp;<asp:button id="btnPrint" Runat="server" CssClass="formbuttonstyle" Text="Print" CausesValidation="False"></asp:button>
								<asp:validationsummary id="svTmeTableAdjust" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD>
							</TR>
							</TABLE>
						</td>
					</tr>
			</table>
			<!--PopCalendar(tag name and id must match) Tags should sit at the page bottom --><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189">
			</iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
