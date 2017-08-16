<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="Staff_leave.aspx.cs" AutoEventWireup="false" Inherits="eschool.Form.Staff_leave" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Employee Leave</title> 
		<!--
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
		<script language="javascript" id="validation1" src="../../HeaderFooter/shareables/jsfiles/Searchdrop.js"></script>
		<script language="javascript" id="validation2" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
		<script language="javascript">
		// this method use to show value of employee.
		function showvalue(t)
		{
			var ind=t.selectedIndex
			if(ind!=0)
			{
				var desg=t.options[ind].value
				var val=document.Staff_leave.Tempvalue.value
				var str="Select,";
				var row=new Array()
				var column=new Array()
				row=val.split(",")
				for(var i=0;i<row.length-1;i++)
				{
					column=row[i].split(":")
					if(desg==column[0])
					{
						str+=column[1]+":"+column[2]+","
					}
				}
				document.Staff_leave.Tempvalue1.value=str
			}
			else
			{
				document.Staff_leave.Tempvalue1.value=""
			}
			document.Staff_leave.DropStaffName.value="Select";
			document.Staff_leave.ListStaffName.style.visibility="hidden"
			document.Staff_leave.txtdoa.value=""
			document.Staff_leave.txtnatapp.value=""
		}
		
		// this method use to show value of saveed data from staff_leave table.
		function getvalue()
		{
			document.Staff_leave.txtnatapp.value=""
			document.Staff_leave.txtdoa.value=""
			var txtvalue=document.Staff_leave.DropStaffName.value
		    var val=document.Staff_leave.Tempvalue.value
			var row=new Array()
			var column=new Array()
			row=val.split(",")
				var nameid="";
				for(var i=0;i<row.length-1;i++)
				{
					column=row[i].split(":")
					nameid=column[1]+":"+column[2]
					if(txtvalue==nameid)
					{  
					   	document.Staff_leave.txtdoa.value=column[3]
						if(column[4]=="Select")
							document.Staff_leave.txtnatapp.value=""
						else
							document.Staff_leave.txtnatapp.value=column[4]
					}
				}
			}			
		</script>
	</HEAD>
	<body>
		<form id="Staff_leave" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td colSpan="3"></td>
				</tr>
				<tr>
					<td align="center"><asp:label id="Label1" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td align="center"><b>EMPLOYEE LEAVE </b>
						<TABLE id="Table1" cellSpacing="1" cellPadding="2" width="50%" borderColorLight="#663300"
							border="5">
							<TR>
								<TD colSpan="2"><asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label><input id="Tempvalue" style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" type="text"
										name="Tempvalue" runat="server"><input id="Tempvalue1" style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" type="text"
										name="Tempvalue1" runat="server"></TD>
							</TR>
							<TR>
								<TD><asp:label id="tcid11" runat="server">&nbsp;Leave ID</asp:label></TD>
								<td><asp:dropdownlist id="DropEdit" runat="server" AutoPostBack="True" Width="80px" Height="8px" CssClass="ComboBox">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist>&nbsp;<asp:label id="slid" runat="server" ForeColor="blue"></asp:label>&nbsp;</td>
							</TR>
							<TR>
								<TD>&nbsp;Designation&nbsp;<FONT color="#ff0000" size="1">*</FONT></TD>
								<TD><asp:dropdownlist id="DropDesig" runat="server" Width="168px" OnChange="showvalue(this);" CssClass="ComboBox">
										<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
									</asp:dropdownlist>&nbsp;<asp:comparevalidator id="cvStaffName" runat="server" ErrorMessage="Please Select The Designation" ControlToValidate="DropDesig"
										Operator="NotEqual" ValueToCompare="Select">*</asp:comparevalidator></TD>
							</TR>
							<TR>
								<TD>&nbsp;Staff Name&nbsp;<FONT color="#ff0000" size="1">*</FONT></TD>
								<TD><input class="TextBoxStyle" onkeypress="return GetAnyNumber(this, event);" id="DropStaffName"
										onkeyup="search3(this,document.Staff_leave.ListStaffName,document.Staff_leave.Tempvalue1.value),arrowkeydown(this,event,document.Staff_leave.ListStaffName,document.Staff_leave.Tempvalue1),Selectbyenter(document.Staff_leave.ListStaffName,event,document.Staff_leave.DropStaffName,document.Staff_leave.txtdoa),getvalue()"
										style="Z-INDEX: 10; VISIBILITY: visible; WIDTH: 150px; HEIGHT: 18px" onclick="search1(document.Staff_leave.ListStaffName,document.Staff_leave.Tempvalue1),dropshow(document.Staff_leave.ListStaffName)"
										value="Select" name="DropStaffName" runat="server"><input style="HEIGHT: 18px" class="ComboBoxSearchButtonStyle" onclick="search1(document.Staff_leave.ListStaffName,document.Staff_leave.Tempvalue1),dropshow(document.Staff_leave.ListStaffName)"
										readOnly type="text" name="temp">&nbsp;<asp:CompareValidator ID=validcom1 Runat=server ValueToCompare=Select ControlToValidate=DropStaffName Operator=NotEqual ErrorMessage="Please Select Staff Name">*</asp:CompareValidator><br>
									<div id="Layer1" style="Z-INDEX: 2; POSITION: absolute"><select class="ListBoxBorderStyle" onmousemove="MouseMove(this)" onkeypress="Selectbyenter(this,event,document.Staff_leave.DropStaffName,document.Staff_leave.txtdoa)"
											id="ListStaffName" ondblclick="select(this,document.Staff_leave.DropStaffName),getvalue()" onkeyup="arrowkeyselect(this,event,document.Staff_leave.txtdoa,document.Staff_leave.DropStaffName),getvalue()"
											style="Z-INDEX: 10; VISIBILITY: hidden; WIDTH: 170px; HEIGHT: 0px" onfocusout="HideList(this,document.Staff_leave.DropStaffName)" multiple
											name="ListStaffName" type="select-one"></select></div>
											
								</TD>
							</TR>
							<!--gyanandra 18-04-07-->
							<TR>
								<TD>&nbsp;Date of Joining</TD>
								<TD><asp:textbox id="txtdoa" runat="server" CssClass="TextBoxForms" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>&nbsp;Nature of Appointment</TD>
								<TD><asp:textbox id="txtnatapp" CssClass="TextBoxForms" runat="server" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<!--end-->
							<TR>
								<TD>&nbsp;Leave from
								</TD>
								<TD><asp:textbox id="txtleavefrom" runat="server" CssClass="Fontstyle" Width="70px" BorderStyle="Groove"
										ReadOnly="True"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Staff_leave.txtleavefrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A>
									<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="You Must Enter Leave From"
										ControlToValidate="txtleavefrom">*</asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD>&nbsp;Leave To
								</TD>
								<TD><asp:textbox id="txtleaveto" runat="server" CssClass="Fontstyle" Width="70px" BorderStyle="Groove"
										ReadOnly="True"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Staff_leave.txtleaveto);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A>
									<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" ErrorMessage="You Must Enter Leave To"
										ControlToValidate="txtleaveto">*</asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD>&nbsp;Leave Type&nbsp; <FONT color="#ff0000" size="1">*</FONT></TD>
								<TD><asp:dropdownlist id="DropLeaveType" runat="server" Width="122px" CssClass="ComboBox">
										<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
										<asp:ListItem Value="CL">CL</asp:ListItem>
										<asp:ListItem Value="EL">EL</asp:ListItem>
										<asp:ListItem Value="METERNITY">METERNITY</asp:ListItem>
										<asp:ListItem Value="LWP">LWP</asp:ListItem>
										<asp:ListItem Value="ABSENT">ABSENT</asp:ListItem>
									</asp:dropdownlist>&nbsp;<asp:comparevalidator id="CompareValidator1" runat="server" ErrorMessage="Please Select The Leave Type"
										ControlToValidate="DropLeaveType" Operator="NotEqual" ValueToCompare="---Select---">*</asp:comparevalidator></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="2">
									&nbsp;<asp:button id="btnSave" runat="server" CssClass="formbuttonstyle" Text="Save"></asp:button>
									&nbsp;<asp:button id="btnedit" runat="server" CssClass="formbuttonstyle" Text="Edit" CausesValidation="False"></asp:button>
									&nbsp;<asp:button id="btneditsave" runat="server" CssClass="formbuttonstyle" Text="Update"></asp:button>
									&nbsp;<asp:button id="btndelete" runat="server" CssClass="formbuttonstyle" Text="Delete" CausesValidation="False"></asp:button>
									<asp:validationsummary id="vsEmpLeave" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
		</form>
		<!--PopCalendar(tag name and id must match) Tags should sit at the page bottom --><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
			name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189">
		</iframe>
		<uc1:footer id="Footer1" runat="server"></uc1:footer>
	</body>
</HTML>
