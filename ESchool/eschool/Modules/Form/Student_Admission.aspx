<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Page language="c#" Codebehind="Student_Admission.aspx.cs" AutoEventWireup="false" Inherits="eschool.Form.Student_Admission" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Student Admission</title>
		<script language="javascript">
		function GetImage(str)
		{
			document.Form1.Image1.src=str.value
		}
		
		function getenableLogst(t)
		{
			if(t.value=="Yes")
			{
				document.Form1.txtRouteNo.disabled=false;
				document.Form1.DropRoueName.disabled=false;
			}
			else
			{
				document.Form1.txtRouteNo.disabled=true;
				document.Form1.DropRoueName.disabled=true;
			}
		}
		
		function ShowRank(t,tr)
		{
			var ind=t.selectedIndex
			var Value=t.options[ind].text
			var Catrank=document.Form1.TempCatRank.value
			var Cat=Catrank.split(',')
			var rank=new Array()
			var l=0
			tr.length=1
			for(var i=0;i<Cat.length-1;i++)
			{
				rank=Cat[i].split(':')
				var Rank=rank[1]
				if(Value==rank[0])
				{
					l++
					tr.add(new Option)
					tr.options[l].text=Rank
				}
			}
		}
		
		function getrank(t)
		{
		  var ind=t.selectedIndex
		  var value=t.options[ind].text
		  document.Form1.Temprank.value=value
		}
		</script>
		<!--
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
		<SCRIPT src="../../HeaderFooter/shareables/jsfiles/Country.js" type="text/javascript"></SCRIPT>
		<script language="javascript" id="Validations" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY>
		<FORM id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="228" width="778" align="center">
				<tr>
					<td></td>
					<td vAlign="top" align="center"><asp:label id="Label3" runat="server" Font-Bold="True">STUDENT ADMISSION</asp:label>
						<table align="center" borderColorLight="#663300" border="5">
							<TBODY>
								<TR>
									<TD bgColor="white" colSpan="3" rowSpan="1"><asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label><INPUT id="txtPhoto" style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" type="text"
											size="2" name="txtPhoto" runat="server" DESIGNTIMEDRAGDROP="3839"><INPUT id="txtCity" style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" type="text" size="2"
											name="txtCity" runat="server"><INPUT id="txtState1" style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" type="text"
											size="2" name="txtState1" runat="server"><INPUT id="txtCity1" style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" type="text"
											size="2" name="txtCity1" runat="server"><INPUT id="txtName" style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" type="text" size="3"
											name="txtName" runat="server"> <INPUT id="txtCountry" style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" type="text"
											size="2" name="txtCity1" runat="server"><INPUT id="txtCountry1" style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" type="text"
											size="2" name="txtCity1" runat="server"><INPUT id="tempstudentcount" style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" type="text"
											size="2" name="tempstudentcount" runat="server"><INPUT id="tempRouteNo" style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" type="text"
											size="2" name="tempRouteNo" runat="server"><INPUT id="TempCatRank" style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" type="text"
											size="2" name="TempCatRank" runat="server"><INPUT id="Temprank" style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" type="text"
											size="2" name="Temprank" runat="server"></TD>
									<td align="center" rowSpan="5"><asp:image id="Image1" runat="server" Height="120px" Width="106px"></asp:image></td>
								</TR>
								<tr>
									<td>&nbsp;Admission ID</td>
									<td colSpan="2"><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,false);" id="DropAdmissionID"
											BorderStyle="Groove" Width="70" CssClass="TextBoxForms" Runat="server" AutoPostBack="True"></asp:textbox>&nbsp;
										<asp:label id="lblStudentID" ForeColor="blue" Runat="server"></asp:label>&nbsp;<asp:dropdownlist id="DropAdmissionID1" runat="server" Width="20px" Visible="False" AutoPostBack="True"></asp:dropdownlist>&nbsp;
										<asp:button id="btnEdit" runat="server" CssClass="formeditbuttonstyle" Text="..." CausesValidation="False"></asp:button></td>
								</tr>
								<tr>
									<td style="HEIGHT: 21px">&nbsp;Student Registration ID&nbsp;<font color="red" size="1">*</font></td>
									<td colSpan="2" style="HEIGHT: 21px"><asp:TextBox ID="txtReg_Id" CssClass="TextBoxForms" Runat="server" Visible="False" Width="70"
											></asp:TextBox><asp:dropdownlist CssClass="ComboBox" id="DropStudentID" Width="285" Runat="server" AutoPostBack="True">
											<asp:ListItem Value="Select">Select</asp:ListItem>
										</asp:dropdownlist><asp:comparevalidator id="CompareValidator1" runat="server" ErrorMessage="Please Select Student Registration ID"
											ValueToCompare="Select" Operator="NotEqual" ControlToValidate="DropStudentID">
											<font color="red"></font>
										</asp:comparevalidator></td>
								</tr>
								<TR>
									<TD>&nbsp;Class&nbsp;<font color="red" size="1">*</font></TD>
									<TD><asp:textbox id="txtclass" CssClass="TextBoxForms" Enabled="false" runat="server" Width="70px"></asp:textbox><asp:dropdownlist CssClass="ComboBox" Width="55" id="Dropclass" Runat="server">
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
										</asp:dropdownlist></TD>
									<td>&nbsp;</td>
								</TR>
								<tr>
									<td>&nbsp;Stream&nbsp;
									</td>
									<td><asp:dropdownlist CssClass="ComboBox" id="dropStream" Width="100px" Runat="server">
											<asp:ListItem Value="None">None</asp:ListItem>
											<asp:ListItem Value="Bio Group">Bio Group</asp:ListItem>
											<asp:ListItem Value="Commerce Group">Commerce Group</asp:ListItem>
											<asp:ListItem Value="Math Group">Math Group</asp:ListItem>
										</asp:dropdownlist></td>
									<td>&nbsp;</td>
								</tr>
								<TR>
									<TD>&nbsp;Student Name&nbsp;
									</TD>
									<TD><asp:textbox CssClass="TextBoxForms" id="txtFirstName" Enabled="False" Runat="server"></asp:textbox><asp:regularexpressionvalidator id="revFirstName" runat="server" ErrorMessage="You must enter the first name in alphabetic format"
											ControlToValidate="txtFirstName" ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$">*</asp:regularexpressionvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="You must enter  Student name"
											ControlToValidate="txtFirstName">*</asp:requiredfieldvalidator></TD>
									<td>&nbsp;Date Of Birth<FONT color="#ff0033" size="1">*</FONT></td>
									<td><asp:textbox id="txtDob" Runat="server" CssClass="Fontstyle" Width="70px" BorderStyle="Groove"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtDob);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
												border="0"></A>&nbsp;</td>
								</TR>
								<TR>
									<TD>&nbsp;Father's Name&nbsp;</TD>
									<TD><asp:textbox CssClass="TextBoxForms" id="TxtFathernm" Enabled="False" Runat="server"></asp:textbox>&nbsp;<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="You must enter  father name"
											ControlToValidate="TxtFathernm">*</asp:requiredfieldvalidator></TD>
									<TD>&nbsp;Mother's Name</TD>
									<TD><asp:textbox CssClass="TextBoxForms" id="TxtMothernm" Enabled="False" Runat="server"></asp:textbox><asp:regularexpressionvalidator id="revMotherName" runat="server" ErrorMessage="You must enter in alphabetic format"
											ControlToValidate="TxtMothernm" ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$">*</asp:regularexpressionvalidator></TD>
								</TR>
								<TR>
									<TD>&nbsp;Father's Mobile No</TD>
									<TD><asp:textbox CssClass="TextBoxForms" onkeypress="return GetOnlyNumbers(this, event, false,false);"
											id="txtFMobileno" Runat="server" MaxLength="12"></asp:textbox></TD>
									<TD>&nbsp;Mother's Mobile No</TD>
									<TD><asp:textbox CssClass="TextBoxForms" onkeypress="return GetOnlyNumbers(this, event, false,false);"
											id="txtMMobileno" Runat="server" MaxLength="12"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;Father's Occp</TD>
									<TD><asp:textbox CssClass="TextBoxForms" id="txtFoccp" onkeypress="return GetOnlyChars(this, event);"
											MaxLength="40" Runat="server"></asp:textbox><asp:regularexpressionvalidator id="revFatherOccp" runat="server" ErrorMessage="You must enter in alphabetic format"
											ControlToValidate="txtFoccp" ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$">*</asp:regularexpressionvalidator></TD>
									<TD>&nbsp;Mother's Occp</TD>
									<TD><asp:textbox CssClass="TextBoxForms" id="txtMoccp" onkeypress="return GetOnlyChars(this, event);"
											MaxLength="40" Runat="server"></asp:textbox><asp:regularexpressionvalidator id="revMotherOccp" runat="server" ErrorMessage="You must enter in alphabetic format"
											ControlToValidate="txtMoccp" ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$">*</asp:regularexpressionvalidator></TD>
								</TR>
								<TR>
									<TD>&nbsp;Father Annual Income</TD>
									<TD><asp:textbox CssClass="TextBoxForms" onkeypress="return GetOnlyNumbers(this, event, false,true);"
											id="txtFannualin" MaxLength="8" Runat="server"></asp:textbox><asp:comparevalidator id="Comparevalidator3" Runat="server" ErrorMessage="Enter in Numeric Format" Operator="DataTypeCheck"
											ControlToValidate="txtFannualin" Display="Dynamic" Type="Double">*</asp:comparevalidator></TD>
									<TD>&nbsp;Mother Annual Income</TD>
									<TD><asp:textbox CssClass="TextBoxForms" onkeypress="return GetOnlyNumbers(this, event, false,true);"
											id="txtMannualin" MaxLength="8" Runat="server"></asp:textbox><asp:comparevalidator id="Comparevalidator4" Runat="server" ErrorMessage="Enter in Numeric Format" Operator="DataTypeCheck"
											ControlToValidate="txtMannualin" Display="Dynamic" Type="Double">*</asp:comparevalidator></TD>
								</TR>
								<TR>
									<TD>&nbsp;Father Email ID</TD>
									<TD><asp:textbox CssClass="TextBoxForms" id="txtFemail" MaxLength="35" Runat="server"></asp:textbox><asp:regularexpressionvalidator id="revFEmail" Runat="server" ErrorMessage="Please enter the father email id in correct format"
											ControlToValidate="txtFemail" ValidationExpression="\w+@[\w-]+\.(com|net|org|edu|mil)$">*</asp:regularexpressionvalidator></TD>
									<TD>&nbsp;Mother Email ID</TD>
									<TD><asp:textbox CssClass="TextBoxForms" id="txtMemail" MaxLength="35" Runat="server"></asp:textbox><asp:regularexpressionvalidator id="revMEmail" Runat="server" ErrorMessage="Please enter the mother email id in correct format"
											ControlToValidate="txtMemail" ValidationExpression="\w+([-+.]\w+)*@[\w-]+\.(com|net|org|edu|mil)$">*</asp:regularexpressionvalidator></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 18px">&nbsp;Category</TD>
									<TD style="HEIGHT: 18px"><asp:dropdownlist CssClass="ComboBox" Width="100" id="DropCategory" Runat="server">
											<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
											<asp:ListItem Value="General">General</asp:ListItem>
											<asp:ListItem Value="OBC">OBC</asp:ListItem>
											<asp:ListItem Value="SC">SC</asp:ListItem>
											<asp:ListItem Value="ST">ST</asp:ListItem>
											<asp:ListItem Value="Other">Other</asp:ListItem>
										</asp:dropdownlist><asp:comparevalidator id="Comparevalidator5" runat="server" ErrorMessage="Please select the Category"
											ValueToCompare="---Select---" Operator="NotEqual" ControlToValidate="DropCategory">*</asp:comparevalidator></TD>
									<TD style="HEIGHT: 18px">&nbsp;Gender</TD>
									<TD style="HEIGHT: 18px"><asp:dropdownlist CssClass="ComboBox" Width="100" id="DropGender" Runat="server">
											<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
											<asp:ListItem Value="Male">Male</asp:ListItem>
											<asp:ListItem Value="Female">Female</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<tr>
									<td>&nbsp;S Category&nbsp;<font color="red" size="1">*</font></td>
									<td><asp:dropdownlist CssClass="ComboBox" id="DropScat" Width="100" Runat="server" onchange="ShowRank(this,document.Form1.DropRank)">
											<asp:ListItem Value="Select">Select</asp:ListItem>
										</asp:dropdownlist><asp:comparevalidator id="Comparevalidator6" runat="server" ErrorMessage="Please select the Scategory"
											ValueToCompare="Select" Operator="NotEqual" ControlToValidate="DropScat">*</asp:comparevalidator></td>
									<TD>&nbsp;Rank&nbsp;<font color="red" size="1">*</font></TD>
									<td>
										<select name="DropRank" id="DropRank" onchange="getrank(this)" class="ComboBox" style="WIDTH: 100px"
											runat="server">
											<option value="Select" selected>Select</option>
										</select><asp:CompareValidator ID="valid1" Runat="server" ControlToValidate="DropRank" ValueToCompare="Select"
											Operator="NotEqual" ErrorMessage="Please Select Rank">*</asp:CompareValidator>
									</td>
								</tr>
								<TR>
									<TD>&nbsp;Email ID</TD>
									<TD><asp:textbox CssClass="TextBoxForms" id="TxtEmail" MaxLength="35" Runat="server"></asp:textbox><asp:regularexpressionvalidator id="RegExpEid" Runat="server" ErrorMessage="Please enter the student Email ID in correct format"
											ControlToValidate="TxtEmail" ValidationExpression="\w+([-+.]\w+)*@[\w-]+\.(com|net|org|edu|mil)$">*</asp:regularexpressionvalidator></TD>
									<TD>&nbsp;Admission Date<FONT color="#ff0033" size="1">*</FONT></TD>
									<TD><asp:textbox id="txtDoa" Runat="server" CssClass="Fontstyle" Width="70px" BorderStyle="Groove"
											></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtDoa);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
												border="0"></A></TD>
								</TR>
								<TR>
									<TD>&nbsp;Local Address</TD>
									<TD><asp:textbox CssClass="TextBoxForms" id="TxtLAdd" onkeypress="return GetAnyNumber(this, event);"
											Width="130px" MaxLength="49" Runat="server"></asp:textbox></TD>
									<TD>&nbsp;City</TD>
									<TD><asp:dropdownlist CssClass="ComboBox" id="DropCity" Width="100" runat="server" Onchange="getBeatInfo(this,document.Form1.DropState,document.Form1.DropCountry);"></asp:dropdownlist></TD>
					</td>
				</tr>
				<TR>
					<TD>&nbsp;State</TD>
					<TD><asp:dropdownlist id="DropState" Width="100" CssClass="ComboBox" runat="server" Enabled="False"></asp:dropdownlist></TD>
					<TD>&nbsp;Country</TD>
					<TD><asp:dropdownlist id="DropCountry" Width="100" CssClass="ComboBox" runat="server" Enabled="False"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>&nbsp;PinCode</TD>
					<TD><asp:textbox CssClass="TextBoxForms" onkeypress="return GetOnlyNumbers(this, event, false,false);"
							id="TxtPincode" MaxLength="8" Runat="server"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator3" Runat="server" ErrorMessage="Pincode no must be equal to 6 digit."
							ControlToValidate="TxtPincode" ValidationExpression="^\d{6}$">*</asp:regularexpressionvalidator></TD>
					<TD>&nbsp;Mobile Number</TD>
					<TD><asp:textbox CssClass="TextBoxForms" onkeypress="return GetOnlyNumbers(this, event, false,false);"
							MaxLength="12" id="TxtMoNo" Runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD>&nbsp;Permanent Address&nbsp; <FONT color="#ff0033" size="1">*</FONT></TD>
					<TD><asp:textbox CssClass="TextBoxForms" id="TextPerAdd" onkeypress="return GetAnyNumber(this, event);"
							MaxLength="49" Width="130px" Runat="server"></asp:textbox>
						<asp:requiredfieldvalidator id="rfvPAddress" runat="server" ErrorMessage="You Must Enter Permanent Address"
							ControlToValidate="TextPerAdd">*</asp:requiredfieldvalidator></TD>
					<TD>&nbsp;City</TD>
					<TD><asp:dropdownlist CssClass="ComboBox" id="DropCity1" runat="server" Width="100" onchange="getBeatInfo(this,document.Form1.DropState1,document.Form1.DropCountry1);"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>&nbsp;State</TD>
					<TD><asp:dropdownlist CssClass="ComboBox" id="DropState1" Width="100" runat="server" Enabled="False"></asp:dropdownlist></TD>
					<TD>&nbsp;Country</TD>
					<TD><asp:dropdownlist CssClass="ComboBox" id="DropCountry1" Width="100" runat="server" Enabled="False"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>&nbsp;PinCode</TD>
					<TD><asp:textbox CssClass="TextBoxForms" onkeypress="return GetOnlyNumbers(this, event, false,false);"
							MaxLength="8" id="TxtPerPincode" Runat="server"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator4" Runat="server" ErrorMessage="Pincode no must be equal to 6 digit."
							ControlToValidate="TxtPerPincode" ValidationExpression="^\d{6}$">*</asp:regularexpressionvalidator>
					<TD>&nbsp;Phone Number</TD>
					<TD><asp:textbox CssClass="TextBoxForms" onkeypress="return GetOnlyNumbers(this, event, true,false);"
							MaxLength="12" id="TxtPhNo" Runat="server"></asp:textbox></TD>
				</TR>
				<tr>
					<TD>Attachment&nbsp; Photo</TD>
					<TD colSpan="3"><INPUT id="SPhoto" Class="TextBoxForms" type="file" onchange="GetImage(this)" size="60"
							runat="server"></TD>
				</tr>
				<TR>
					<TD>&nbsp;Logistic</TD>
					<TD><!--<SELECT id="Droplogistic" style="WIDTH: 85px" name="Droplogistic">
							<OPTION value="Select" selected>Select</OPTION>
						</SELECT></TD>--><asp:dropdownlist CssClass="ComboBox" Width="100" id="Droplogistic" runat="server" onchange="getenableLogst(this)">
							<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
							<asp:ListItem Value="Yes">Yes</asp:ListItem>
							<asp:ListItem Value="No">No</asp:ListItem>
						</asp:dropdownlist></TD>
					<td>&nbsp;Computer</td>
					<TD><asp:dropdownlist CssClass="ComboBox" Width="100" id="Dropcomputer" runat="server">
							<asp:ListItem Value="Yes">Yes</asp:ListItem>
							<asp:ListItem Value="No">No</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>&nbsp;Route Name</TD>
					<TD><!--<SELECT style="WIDTH: 85px" disabled name="DropRoueName"><OPTION value="Select" selected>Select</OPTION>
							</SELECT></TD>--><asp:dropdownlist CssClass="ComboBox" id="DropRoueName" Width="157px" Runat="server" Enabled="False"
							onchange="getLogisticInfo(this,document.Form1.txtRouteNo)"></asp:dropdownlist></TD>
					<TD>&nbsp;Route No</TD>
					<TD><asp:textbox CssClass="TextBoxForms" id="txtRouteNo" BorderStyle="Groove" Width="100px" Runat="server"
							Enabled="False"></asp:textbox></TD>
				</TR>
				<tr>
					<td>&nbsp;Blood Group</td>
					<td><asp:dropdownlist CssClass="ComboBox" id="DropBG" Width="100px" Runat="server">
							<asp:ListItem Value="A+">A+</asp:ListItem>
							<asp:ListItem Value="A-">A-</asp:ListItem>
							<asp:ListItem Value="B+">B+</asp:ListItem>
							<asp:ListItem Value="B-">B-</asp:ListItem>
							<asp:ListItem Value="AB+">AB+</asp:ListItem>
							<asp:ListItem Value="AB-">AB-</asp:ListItem>
							<asp:ListItem Value="O+">O+</asp:ListItem>
							<asp:ListItem Value="O-">O-</asp:ListItem>
						</asp:dropdownlist></td>
					<td>&nbsp;House</td>
					<TD><asp:dropdownlist CssClass="ComboBox" id="Drophouse" runat="server" Width="120px">
							<asp:ListItem Value="Select">Select</asp:ListItem>
						</asp:dropdownlist></TD>
				</tr>
				<TR>
					<TD align="center" colSpan="5"><asp:button id="btnSave" runat="server" CssClass="FormButtonStyle" Text="Save"></asp:button>
						&nbsp;<asp:button id="BtnReset" Runat="server" CssClass="FormButtonStyle" Text="Reset" CausesValidation="False"></asp:button>
						<asp:validationsummary id="vsRegistration" runat="server" Width="100%" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></TD>
				</TR>
			</table>
			</TD></TR></TBODY></TABLE></FORM>
		<!--PopCalendar(tag name and id must match) Tags should sit at the page bottom --><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
			name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189">
		</iframe>
		<uc1:footer id="Footer1" runat="server"></uc1:footer>
	</BODY>
</HTML>
