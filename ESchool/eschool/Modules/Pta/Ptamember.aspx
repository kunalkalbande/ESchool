<%@ Page language="c#" Codebehind="Ptamember.aspx.cs" AutoEventWireup="false" Inherits="eschool.Modules.Pta.Form1" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>eSchool : PTA Membership</title>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<SCRIPT src="../../HeaderFooter/shareables/jsfiles/Country.js" type=text/javascript></SCRIPT>

<meta content=JavaScript name=vs_defaultClientScript>
<script language=javascript id=country src="../../HeaderFooter/shareables/jsfiles/Country.js"></script>
		<script language="javascript" id="Validations" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type=text/css rel=stylesheet >
<script language=javascript>

//this method not in use.
function selectCountry()
{
	var index=document.Form1.DropCountry1.selectedIndex
	var CountryName = document.Form1.DropCountry1.options[index].text
    document.Form1.DropCountryValue.value= CountryName
}
	
		</script>
</HEAD>
<body MS_POSITIONING="GridLayout">
	<form id=Form1 method=post runat="server">
		<uc1:header id=Header1 runat="server"></uc1:header>
			<table height=250 width=778 align=center>
				<TBODY>
					<tr>
						<td align=center><asp:label id=Label1 runat="server" Font-Bold="True"></asp:label></td>
					</tr>
					<tr>
						<td vAlign=top align=center><b>PTA MEMBERSHIP</b> 
						   <TABLE id=Table1 height=228 cellSpacing=1 cellPadding=1 width=550 borderColorLight=#663300 border=5>
								<TBODY>
									<TR>
										<TD colSpan=6><asp:label id=Label4 runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label>
											<INPUT id=txtState style="VISIBILITY: hidden; WIDTH: 48px; HEIGHT: 10px" type=text size=2 name=txtState runat="server">
											<INPUT id=txtCity style="VISIBILITY: hidden; WIDTH: 48px; HEIGHT: 10px" type=text size=2 name=txtCity runat="server"> 
											<INPUT id=txtState1 style="VISIBILITY: hidden; WIDTH: 48px; HEIGHT: 10px" type=text size=2 name=txtState1 runat="server">
											<INPUT id=txtCity1 style="VISIBILITY: hidden; WIDTH: 48px; HEIGHT: 10px" type=text size=2 name=txtCity1 runat="server">
											<INPUT id=txtName style="VISIBILITY: hidden; WIDTH: 48px; HEIGHT: 10px" type=text size=2 name=txtName runat="server">
											<INPUT id=DropCountryValue style="VISIBILITY: hidden; WIDTH: 48px; HEIGHT: 10px" type=text name=DropCountryValue runat="server">
										</TD>
									</TR>
									<TR>
										<TD>&nbsp;Member Name&nbsp;<FONT color=#ff0033 size=1>*</FONT></TD>
										<TD><asp:textbox CssClass="TextBoxforms" id=txtname1  onkeypress="return GetOnlyChars(this, event);" MaxLength=30 runat="server"></asp:textbox>&nbsp;<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtname1" ErrorMessage="You Must Enter Member Name ">*</asp:requiredfieldvalidator><asp:regularexpressionvalidator id=revName runat="server" ErrorMessage="You must enter in alphabetic format" ControlToValidate="txtname1" ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$">*</asp:regularexpressionvalidator></TD>
										<TD>&nbsp;Type of Member&nbsp;<FONT color=#ff0033 size=1>*</FONT></TD>
										<TD><asp:dropdownlist id=Droptypemem CssClass="ComboBox" runat="server" AutoPostBack="true" Width="130px">
												<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
												<asp:ListItem Value="Official">Official</asp:ListItem>
												<asp:ListItem Value="Non Official">Non Official</asp:ListItem>
											</asp:dropdownlist>&nbsp;
											<asp:comparevalidator id=cvTypeOfMem runat="server" ErrorMessage="Please select the member type" ControlToValidate="Droptypemem" ValueToCompare="---Select---" Operator="NotEqual">*</asp:comparevalidator></TD>
									</TR>
									<tr>
										<TD>&nbsp;Designation&nbsp;<FONT color=#ff0033 size=1>*</FONT></TD>
										<TD><asp:dropdownlist CssClass="ComboBox" id=Dropdesi runat="server" Width="130px">
												<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
												<asp:ListItem Value="President">President</asp:ListItem>
												<asp:ListItem Value="Vice_President">Vice_President</asp:ListItem>
												<asp:ListItem Value="Secretary">Secretary</asp:ListItem>
												<asp:ListItem Value="Cashier">Cashier</asp:ListItem>
												<asp:ListItem Value="Member">Member</asp:ListItem>
											</asp:dropdownlist>&nbsp;<asp:comparevalidator id=cvDesignation runat="server" ErrorMessage="Please select designation" ControlToValidate="Dropdesi" ValueToCompare="---Select---" Operator="NotEqual">*</asp:comparevalidator></TD>
										<TD>&nbsp;Checked By&nbsp;<FONT color=#ff0033 size=1>*</FONT></TD>
										<TD><asp:dropdownlist id=Dropstaffid CssClass="ComboBox" runat="server" Width="130px">
												<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
												</asp:dropdownlist>&nbsp;<asp:comparevalidator id=cvCheckedBy runat="server" ErrorMessage="Checked by name must be selected" ControlToValidate="Dropstaffid" ValueToCompare="---Select---" Operator="NotEqual">*</asp:comparevalidator></TD>
									</tr>
									<TR>
										<TD>&nbsp;City</TD>
										<TD><asp:dropdownlist CssClass="ComboBox" Width=130px id=DropCity runat="server" onchange="getBeatInfo(this,document.Form1.DropState,document.Form1.DropCountry);">
												<asp:ListItem Value="---Select---" Selected="True">---Select---</asp:ListItem>
												</asp:dropdownlist></TD>
										<TD>&nbsp;Country</TD>
										<TD><asp:dropdownlist CssClass="ComboBox" Width=130px id=DropCountry runat="server">
												<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
												</asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD>&nbsp;State</TD>
										<TD><asp:dropdownlist CssClass="ComboBox" Width=130px id=DropState runat="server">
												<asp:ListItem Value="---Select---" Selected>---Select---</asp:ListItem>
												</asp:dropdownlist></TD>
										<TD>&nbsp;Pincode</TD>
										<TD><asp:textbox CssClass="TextBoxforms" MaxLength=8 onkeypress="return GetOnlyNumbers(this, event, false,false);" id=Textpin runat="server" Width="130px"></asp:textbox>&nbsp;</TD>
									</TR>
									<TR>
										<TD>&nbsp;Phone No</TD>
										<TD><asp:textbox CssClass="TextBoxforms" onkeypress="return GetOnlyNumbers(this, event, true,false);" MaxLength=12 id=Texthone runat="server"></asp:textbox></TD>
										<TD>&nbsp;Mobile No</TD>
										<TD><asp:textbox CssClass="TextBoxforms" onkeypress="return GetOnlyNumbers(this, event, false,false);" MaxLength=12 id=txtmobile runat="server"></asp:textbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;E-mail</TD>
										<TD><asp:textbox CssClass="TextBoxforms" id=txtemail runat="server"></asp:textbox><asp:regularexpressionvalidator id=RegExpEid ErrorMessage="You Must Enter Email ID in correct format" ControlToValidate="txtemail" Runat="server" ValidationExpression="\w+([-+.]\w+)*@[\w-]+\.(com|net|org|edu|mil)$">*</asp:regularexpressionvalidator></TD>
										<TD>&nbsp;Address&nbsp;<font color=red size=1>*</font></TD>
										<TD><asp:textbox CssClass="TextBoxforms" id=Textadd runat="server" Width="130px"  MaxLength=30></asp:textbox>&nbsp;<asp:requiredfieldvalidator id=Requiredfieldvalidator2 runat="server" ErrorMessage="You Must Enter Address " ControlToValidate="Textadd">*</asp:requiredfieldvalidator></TD>
									</TR>
								<asp:panel id=panoff Visible="False" Runat="server">
        <TR>
          <TD id=td1>
<asp:label id=labelid runat="server">&nbsp;Student ID</asp:label></TD>
          <TD>
<asp:dropdownlist id=Dropstudentid runat="server" CssClass="ComboBox" AutoPostBack="True">
											<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
											</asp:dropdownlist>
<asp:comparevalidator id=cvStuId runat="server" ErrorMessage="Student id must be selected" ControlToValidate="Dropstudentid" Operator="NotEqual" ValueToCompare="---Select---">*</asp:comparevalidator></TD></TR>
        <TR>
          <TD>
<asp:label id=Labelname runat="server">&nbsp;Name</asp:label></TD>
          <TD>
<asp:textbox id=txtstudentname runat="server" CssClass="TextBoxforms" ReadOnly="True"></asp:textbox></TD>
          <TD id=td3>
<asp:label id=LabelClass runat="server">&nbsp;Class</asp:label></TD>
          <TD>
<asp:textbox id=txtclass runat="server" CssClass="TextBoxforms" ReadOnly="True"></asp:textbox></TD></TR>
								</asp:panel>
       							<asp:panel id="pannon" Runat="server" Visible="False">
        <TR>
          <TD>
<asp:label id=Labelstaff runat="server">&nbsp;Staff Id</asp:label></TD>
          <TD>
<asp:dropdownlist id=Dropdownlist1 runat="server" CssClass="ComboBox" AutoPostBack="True">
											<asp:ListItem Value="---Select---"></asp:ListItem>
											</asp:dropdownlist>
<asp:comparevalidator id=cvStaffId runat="server" ErrorMessage="Staff id must be selected" ControlToValidate="Dropdownlist1" Operator="NotEqual" ValueToCompare="---Select---">*</asp:comparevalidator></TD>
          <TD id=td2>
<asp:label id=Labelsn runat="server">&nbsp;Name</asp:label></TD>
          <TD>
<asp:textbox id=txtempnm runat="server" CssClass="TextBoxforms" ReadOnly="True"></asp:textbox></TD></TR>
								</asp:panel>
									<TR>
										<TD align=center colSpan=6><asp:button id="btnSave" Runat="server" Text="Save" CssClass="FormButtonStyle"></asp:button>&nbsp;
											<asp:button id="BtnReset"  Runat="server" Text="Reset" CssClass="FormButtonStyle"
											CausesValidation="False"></asp:button>
											<asp:validationsummary id="vsPtaMember" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></TD>
									</TR>
								</TBODY>
							</TABLE>
							</td></tr>
		</TBODY></table> 
		<!--PopCalendar(tag name and id must match) Tags should sit at the page bottom --><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
			name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189">
		</iframe>
		<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
