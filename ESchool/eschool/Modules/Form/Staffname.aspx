<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="Staffname.aspx.cs" EnableEventValidation="false" AutoEventWireup="false" Inherits="eschool.Form.teacher" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Employee Details</title>
		<script language="javascript">
		// this method not in use.
		function GetImage(str)
		{
			document.Form1.ImgUrl1.src=str.value
		}
		
		// this method use check digits should be less then 13.
		function compareValue(t)
		{
			//alert("test")
			var val=t.value
			if(val.length>13)
			{
				alert("Please Enter only 12 digit")
				t.value="";
			}
		}
		</script>
		<!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a S
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<SCRIPT src="../../HeaderFooter/shareables/jsfiles/Country.js" type="text/javascript"></SCRIPT>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<script language="javascript" id="validation1" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table id="Table2" height="228" width="778" align="center">
				<tr>
					<td align="center"><asp:label id="lblDetails" runat="server"><b>EMPLOYEE 
								DETAILS</b></asp:label>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" borderColorLight="#663300" border="5">
							<TR>
								<TD colSpan="4"><INPUT id="txtState" style="VISIBILITY: hidden; WIDTH: 48px; HEIGHT: 10px" type="text"
										size="2" name="txtState" runat="server"><INPUT id="txtCity" style="VISIBILITY: hidden; WIDTH: 48px; HEIGHT: 10px" type="text" size="2"
										name="txtCity" runat="server"><INPUT id="txtState1" style="VISIBILITY: hidden; WIDTH: 48px; HEIGHT: 10px" type="text"
										size="2" name="txtState1" runat="server"><INPUT id="txtCity1" style="VISIBILITY: hidden; WIDTH: 48px; HEIGHT: 10px" type="text"
										size="2" name="txtCity1" runat="server"><INPUT id="txtName" style="VISIBILITY: hidden; WIDTH: 53px; HEIGHT: 10px" type="text" size="3"
										name="txtName" runat="server"><input id="getUrl" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="getUrl"
										runat="server">
								</TD>
								<td vAlign="baseline" align="center" colSpan="2" rowSpan="6"><asp:image id="ImgUrl1" runat="server" Height="115px"></asp:image></td>
							</TR>
							<TR>
								<TD colspan="4">
									<asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label>
								</TD>
							</TR>
							<TR>
								<TD>
									<asp:label id="lblType" runat="server">&nbsp;Staff Type</asp:label>
								</TD>
								<td colSpan="3">
									<asp:radiobutton id="chkTeaching" runat="server" GroupName="Staff type" Text="Teaching Staff" AutoPostBack="True"></asp:radiobutton>
									<asp:radiobutton id="chkNonTeaching" runat="server" GroupName="Staff type" Text="Non Teaching Staff"
										AutoPostBack="True"></asp:radiobutton>
									<asp:radiobutton id="chkGroupD" runat="server" GroupName="Staff type" Text="Group D Staff" AutoPostBack="True"></asp:radiobutton>
									<asp:radiobutton id="chkactivity" runat="server" GroupName="Staff type" Text="Activity Staff" AutoPostBack="True"></asp:radiobutton>
								</td>
							</TR>
							<tr>
								<td>
									<asp:label id="lblDesignation" runat="server">&nbsp;Staff Desig.&nbsp;</asp:label><FONT color="red" size="1">*</FONT>
								</td>
								<td><asp:dropdownlist id="DropType" runat="server" AutoPostBack="True" CssClass="ComboBox" Width="120px">
										<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
									</asp:dropdownlist><asp:comparevalidator id="cvStaffType" runat="server" ValueToCompare="---Select---" Operator="NotEqual"
										ControlToValidate="DropType" ErrorMessage="Please Select The Staff Designation">*</asp:comparevalidator>
								</td>
								<TD>
									<asp:label id="lblEmployeeID" Runat="server">&nbsp;Employee ID</asp:label>
								</TD>
								<TD><asp:dropdownlist id="DropEmpID" CssClass="ComboBox" runat="server" AutoPostBack="True" Width="120"></asp:dropdownlist><asp:comparevalidator id="compairvali1" ValueToCompare="Select" Operator="NotEqual" ControlToValidate="DropEmpID"
										ErrorMessage="Please Select EmployeeID" Runat="server"><font color="#ff3333"></font>*</asp:comparevalidator>&nbsp;<asp:label id="lblEmpID" ForeColor="blue" Runat="server"></asp:label></TD>
							</tr>
							<TR>
								<TD>
									<asp:label id="lblName" runat="server">&nbsp;Name</asp:label>&nbsp;<font color="red" size="1">*</font>
								</TD>
								<TD>
									<asp:textbox id="txtstaffname" onkeypress="return GetOnlyChars(this, event);" MaxLength="30"
										runat="server" CssClass="TextBoxDate" Width="232px"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator1" ControlToValidate="txtstaffname" ErrorMessage="Please Enter Name "
										Runat="server">*</asp:requiredfieldvalidator>
								</TD>
								<TD>
									<asp:label id="lblFatherName" Runat="server">&nbsp;Father Name</asp:label>&nbsp;<font color="red" size="1">*</font>
								</TD>
								<TD>
									<asp:textbox id="txtFatherName" onkeypress="return GetOnlyChars(this, event);" BorderStyle="Groove"
										CssClass="TextBoxDate" Width="110px" MaxLength="25" Runat="server"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator2" ControlToValidate="txtFatherName" ErrorMessage="Please Enter Father Name"
										Runat="server">*</asp:requiredfieldvalidator>
								</TD>
							</TR>
							<TR>
								<TD>
									<asp:label id="lblQualification" runat="server">&nbsp;Qualification&nbsp;</asp:label><FONT color="red" size="1">*</FONT>
								</TD>
								<TD>
									<asp:textbox id="txtstaffeducation" MaxLength="10" onkeypress="return GetAnyNumber(this, event);"
										CssClass="TextBoxDate" Width="101px" Runat="server"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator4" ControlToValidate="txtstaffeducation" ErrorMessage="You Must Enter Qualification "
										Runat="server">*</asp:requiredfieldvalidator>
								</TD>
								<td>
									&nbsp;Prof. Qualification
								</td>
								<td>
									<asp:textbox id="txtprofequa" MaxLength="10" onkeypress="return GetAnyNumber(this, event);" CssClass="TextBoxDate"
										Width="110px" Runat="server"></asp:textbox>
								</td>
							</TR>
							<tr>
								<td>
									<asp:label id="lbldob" runat="server">&nbsp;Date of Birth</asp:label>
								</td>
								<td>
									<asp:textbox id="txtage" CssClass="Fontstyle" Width="80px" BorderStyle="Groove" Runat="server"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtage);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A>
								</td>
								<td colSpan="4">
									&nbsp;<INPUT id="studentphoto" style="WIDTH: 382px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="file" onchange="GetImage(this)" size="44" runat="server" class="fontstyle">
								</td>
							</tr>
							<tr>
								<td>
									&nbsp;Saving&nbsp;Ac No
								</td>
								<td>
									<asp:textbox id="txtperacno" onkeypress="return GetOnlyNumbers(this, event, false,false);" MaxLength="12"
										onblur="compareValue(this)" CssClass="TextBoxDate" Runat="server" Width="101px"></asp:textbox>
								</td>
								<td>
									&nbsp;E.P.F. Ac No
								</td>
								<td>
									<asp:textbox id="txtepfacno" onblur="compareValue(this)" MaxLength="12" BorderStyle="Groove"
										CssClass="TextBoxDate" Runat="server" Width="93px"></asp:textbox>
								</td>
								<td>
									<asp:label id="lblmaritialstatus" runat="server">&nbsp;Maritial Status&nbsp;</asp:label>
								</td>
								<td>
									<asp:dropdownlist id="Dropmstatus" runat="server" CssClass="ComboBox" Width="93px">
										<asp:ListItem Value="Married">Married</asp:ListItem>
										<asp:ListItem Value="Unmarried">Unmarried</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td>
									<asp:label id="lbldojoin" runat="server">&nbsp;Date of Joining</asp:label>
								</td>
								<td>
									<asp:textbox id="txtdojoin" CssClass="Fontstyle" Width="80px" BorderStyle="Groove" Runat="server"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtdojoin);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A>
								</td>
								<TD>
									<asp:label id="lblExp" runat="server">&nbsp;Experience&nbsp;</asp:label><FONT color="red" size="1">*</FONT>
								</TD>
								<TD>
									<asp:dropdownlist id="Dropstaffexp" Width="92" runat="server" CssClass="ComboBox">
										<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
									</asp:dropdownlist><asp:comparevalidator id="cvExp" runat="server" ValueToCompare="---Select---" Operator="NotEqual" ControlToValidate="Dropstaffexp"
										ErrorMessage="You Must Select The Experience.">*</asp:comparevalidator>
								</TD>
								<td>
									<asp:label id="lblsex" runat="server">&nbsp;Gender &nbsp;</asp:label>
								</td>
								<td>
									<asp:dropdownlist id="Dropsex" runat="server" CssClass="ComboBox" Width="92px">
										<asp:ListItem Value="Male">Male</asp:ListItem>
										<asp:ListItem Value="Female">Female</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</tr>
							<TR>
								<td>
									<asp:label id="lblPerAddress" runat="server">&nbsp;Permanent Addr.</asp:label>
								</td>
								<TD>
									<asp:textbox id="txtpaddress" runat="server" MaxLength="40" CssClass="TextBoxDate" Width="232px"></asp:textbox>
								</TD>
								<TD><asp:label id="lblPerPin" runat="server">&nbsp;Pin Code</asp:label></TD>
								<TD colSpan="3"><asp:textbox id="txtppin" MaxLength="8" onkeypress="return GetOnlyNumbers(this, event, false,false);"
										runat="server" CssClass="TextBoxDate" Width="93px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD><asp:label id="lblPerCountry" runat="server">&nbsp;City</asp:label>&nbsp;<font color="red" size="1">*</font></TD>
								<TD><asp:dropdownlist id="DropCity" CssClass="ComboBox" runat="server" Width="100px" onchange="getBeatInfo(this,document.Form1.DropState,document.Form1.DropCountry)"></asp:dropdownlist><asp:comparevalidator id="Comparevalidator1" runat="server" ValueToCompare="---Select---" Operator="NotEqual"
										ControlToValidate="DropCity" ErrorMessage="Please Select City">*</asp:comparevalidator></TD>
								<TD><asp:label id="lblPerState" runat="server">&nbsp;State</asp:label></TD>
								<TD><asp:dropdownlist id="DropState" Enabled="False" CssClass="ComboBox" runat="server" Width="92px"></asp:dropdownlist></TD>
								<TD><asp:label id="lblPerCity" runat="server">&nbsp;Country</asp:label></TD>
								<TD><asp:dropdownlist id="DropCountry" Enabled="False" CssClass="ComboBox" runat="server" Width="93px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD><asp:label id="lblLoAddress" runat="server">&nbsp;Local Addr.</asp:label></TD>
								<TD><asp:textbox id="txtloaddress" runat="server" MaxLength="40" CssClass="TextBoxDate" Width="232px"></asp:textbox></TD>
								<TD><asp:label id="lblLoPin" runat="server">&nbsp;Pin Code</asp:label></TD>
								<TD colSpan="3"><asp:textbox id="txtlpin" onkeypress="return GetOnlyNumbers(this, event, false,false);" MaxLength="8"
										runat="server" CssClass="TextBoxDate" Width="93px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD><asp:label id="lblLoCountry" runat="server">&nbsp;City</asp:label></TD>
								<TD><asp:dropdownlist id="DropCity1" CssClass="ComboBox" runat="server" Width="101px" onchange="getBeatInfo(this,document.Form1.DropState1,document.Form1.DropCountry1)"></asp:dropdownlist></TD>
								<TD><asp:label id="lblLoState" runat="server">&nbsp;State</asp:label></TD>
								<TD><asp:dropdownlist id="DropState1" CssClass="ComboBox" Enabled="False" runat="server" Width="92px"></asp:dropdownlist></TD>
								<TD><asp:label id="lblLoCity" runat="server">&nbsp;Country</asp:label></TD>
								<TD><asp:dropdownlist id="DropCountry1" CssClass="ComboBox" Enabled="False" runat="server" Width="93px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD><asp:label id="lblEmail" runat="server">&nbsp;Email-Id</asp:label></TD>
								<TD><asp:textbox id="txtemail" runat="server" CssClass="TextBoxDate" Width="232px"></asp:textbox><asp:regularexpressionvalidator id="revEmail" runat="server" ControlToValidate="txtemail" ErrorMessage="Must be in Email format in correct format."
										ValidationExpression="^[\w-]+@[\w-]+\.(com|net|org|edu|mil)$">*</asp:regularexpressionvalidator></TD>
								<TD><asp:label id="lblMobNo" runat="server">&nbsp;Mobile No</asp:label></TD>
								<TD><asp:textbox id="txtsmobile" MaxLength="12" onkeypress="return GetOnlyNumbers(this, event, false,false);"
										runat="server" CssClass="TextBoxDate" Width="93px"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" ErrorMessage="Contact No. Between 6-10 Digits"
										ControlToValidate="txtsmobile" ValidationExpression="\d{6,12}">*</asp:regularexpressionvalidator></TD>
								<TD><asp:label id="lblPhNo" runat="server">&nbsp;Phone No</asp:label></TD>
								<TD><asp:textbox id="txtsphone" MaxLength="12" onkeypress="return GetOnlyNumbers(this, event, false,false);"
										runat="server" CssClass="TextBoxDate" Width="93px"></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" ErrorMessage="Contact No. Between 6-10 Digits"
										ControlToValidate="txtsphone" ValidationExpression="\d{6,12}">*</asp:regularexpressionvalidator></TD>
							</TR>
							<TR>
								<TD><asp:label id="lblSub" runat="server">&nbsp;Subject Taken</asp:label></TD>
								<TD><asp:listbox id="lstSubject" runat="server" Width="150px" SelectionMode="Multiple"
										Rows="1" Height="18px"></asp:listbox></TD>
								<td>&nbsp;Nature Of Appoint.</td>
								<td colSpan="3"><asp:dropdownlist CssClass="ComboBox" id="DropNatApp" Width="150px" Runat="server">
										<asp:ListItem Value="Permanent">Permanent</asp:ListItem>
										<asp:ListItem Value="Adhoc">Adhoc</asp:ListItem>
										<asp:ListItem Value="Casual">Casual</asp:ListItem>
										<asp:ListItem Value="Probation">Probation</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</TR>
							<asp:panel Visible="False" id="panDriver" Runat="server">
								<TR>
									<TD>
										<asp:label id="Label19" runat="server">&nbsp;Driving License No.</asp:label></TD>
									<TD>
										<asp:textbox id="Textbox1" runat="server" CssClass="TextBoxForms"></asp:textbox></TD>
									<TD>
										<asp:label id="Label20" runat="server">&nbsp;Validity In</asp:label></TD>
									<TD colSpan="3">
										<asp:textbox id="Textbox2" runat="server" Width="92px" CssClass="TextBoxForms"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>
										<asp:label id="Label21" runat="server">&nbsp;Driver LIC Policy No.</asp:label></TD>
									<TD>
										<asp:textbox id="Textbox3" runat="server" CssClass="TextBoxForms"></asp:textbox></TD>
									<TD>
										<asp:label id="Label22" runat="server">&nbsp;Validity In</asp:label></TD>
									<TD colSpan="3">
										<asp:textbox id="Textbox4" runat="server" Width="92px" CssClass="TextBoxForms"></asp:textbox></TD>
								</TR>
							</asp:panel>
							<!--TR>
								<TD><asp:label id="Label23" runat="server">&nbsp;Vehicle No.</asp:label></TD>
								<TD colSpan="5"><asp:dropdownlist id="DropDownList1" runat="server" AutoPostBack="True" Width="127px"></asp:dropdownlist></TD>
							</TR-->
							<tr>
								<td align="center" colSpan="6"><asp:button id="btnSave" runat="server" Text="Save" CssClass="FormButtonStyle"></asp:button>&nbsp;<asp:button id="BtnReset" Text="Reset" CssClass=" FormButtonStyle" Runat="server" CausesValidation="False"></asp:button>&nbsp;
									<asp:button id="btnEdit" runat="server" Text="Edit" CssClass="FormButtonStyle" CausesValidation="False"></asp:button>&nbsp;
									<asp:button id="btnDel" runat="server" Text="Delete" CssClass="FormButtonStyle" CausesValidation="False"></asp:button><asp:validationsummary id="vsStaffName" runat="server" Width="136px" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></td>
							</tr>
						</TABLE>
					</td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
		<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
			name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0"
			width="174" scrolling="no" height="189"></iframe>
	</body>
</HTML>
