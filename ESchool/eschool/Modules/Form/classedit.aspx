<%@ Page language="c#" Codebehind="classedit.aspx.cs" AutoEventWireup="false" Inherits="eschool.Form.classedit" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>eSchool : Class Master</title><!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content=JavaScript name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema><LINK href="../../HeaderFooter/shareables/Style/Styles.css" type=text/css rel=stylesheet >
<script language=javascript>
		// this method use to show and hide some controls and show data.
		function showhidden(t)
		{
			var ind=t.selectedIndex
			var val=t.options[ind].value
			if(ind >0)
			{
				document.classedit.txtOther.style.width="100"
				document.classedit.txtOther.style.visibility="Visible"
				document.classedit.DropClass.style.visibility="Hidden"
				document.classedit.DropClass.style.width="0"
				document.classedit.txtOther.value=val
				document.classedit.btnadd.value="Update"
				
			}
			else
			{
				document.classedit.txtOther.style.width="0"
				document.classedit.txtOther.style.visibility="Hidden"
				document.classedit.DropClass.style.visibility="Visible"
				document.classedit.DropClass.style.width="100"
				document.classedit.txtOther.value=""
				document.classedit.btnadd.value="Add"
				document.classedit.DropClass.selectedIndex=0
			}
			document.classedit.txtOth.style.visibility="Hidden" 
		}
		
		// this method use to show and hide some controls
		function insclass(t)
		{
			var ind=t.selectedIndex
			var val=t.options[ind].value
			document.classedit.tempclass.value=val
			if(val=="Other")
			{
				document.classedit.txtOth.style.visibility="Visible" 
				document.classedit.txtOth.value=""
			}
			else
			{
				document.classedit.txtOth.style.visibility="Hidden" 
			}
		}
		
		// this method use to assign value.
		function insertvalue(t,t1)
		{
			t1.value=t.value
		}
		
		</script>
</HEAD>
<body>
<form id=classedit method=post runat="server">
<uc1:header id=Header1 runat="server"></uc1:header>
<table height=250 width=778 align=center>
  <tr>
    <td align=center colSpan=3><asp:label id=Label1 runat="server"></asp:label>
		<input id=tempclass type=hidden name=tempclass runat="server"> 
		<input id=tempeditclass type=hidden name=tempeditclass runat="server">
    </TD>
  </TR>
  <tr>
    <td vAlign=top align=center><b>CLASS MASTER</B> 
      <TABLE id=Table1 cellSpacing=1 cellPadding=1 borderColorLight=#663300 border=5>
        <TR>
          <TD><asp:label id=Label2 runat="server">&nbsp;Class Name</asp:label></TD>
          <TD>&nbsp;<asp:dropdownlist id=DropDownList1 runat="server" AutoPostBack="False" CssClass="ComboBox" Width="100px" onchange="showhidden(this)">
			  <asp:ListItem Value="---Select---">---Select---</asp:ListItem>
			  </asp:dropdownlist><asp:textbox id=txtclass runat="server" CssClass="TextBoxForms" Width="120px"></asp:textbox></TD></TR>
        <TR>
          <TD><asp:label id=lblAddNewClass runat="server">&nbsp;Add New Class</asp:label><font color=red size=1>&nbsp;*</font></TD>
          <TD><input class=TextBoxForms id=txtOther onblur=insertvalue(this,document.classedit.tempeditclass) style="VISIBILITY: hidden; WIDTH: 0px" type=text maxLength=10 name=txtOther runat="server">
          <select class=ComboBox id=DropClass style="WIDTH: 100px" onchange=insclass(this) name=DropClass runat="server"> 
          <option value=---Select--- selected>---Select---</OPTION> 
          <option value=Nursery>Nursery</OPTION> 
          <option value=LKG>LKG</OPTION> 
          <option value=UKG>UKG</OPTION> 
          <option value=I>I</OPTION> 
          <option value=II>II</OPTION> 
          <option value=III>III</OPTION> 
          <option value=IV>IV</OPTION> 
          <option value=V>V</OPTION> 
          <option value=VI>VI</OPTION> 
          <option value=VII>VII</OPTION> 
          <option value=VIII>VIII</OPTION> 
          <option value=IX>IX</OPTION> 
          <option value=X>X</OPTION> 
          <option value=XI>XI</OPTION> 
          <option value=XII>XII</OPTION> 
          <option value=Other>Other</OPTION></SELECT>
          <input class=TextBoxForms id=txtOth onblur=insertvalue(this,document.classedit.tempeditclass) style="VISIBILITY: hidden; WIDTH: 100px" type=text maxLength=10  runat="server"> 
              </TD></TR>
        <TR>
          <TD align=center colSpan=4>
          <asp:button id=btnadd runat="server" CssClass="formbuttonstyle" Text="Add"></asp:button>&nbsp;<asp:button id=btnEdit runat="server" CssClass="formbuttonstyle" Visible="False" Text="Edit"></asp:button>
		  &nbsp;<asp:button id="btnSEdit" runat="server" Visible=False CssClass="formbuttonstyle" Text="Update"></asp:button>
		  &nbsp;<asp:button id="btnDelete" runat="server" CssClass="formbuttonstyle" Text="Delete"></asp:button>
		  </TD></TR></TABLE></TD></TR></TABLE>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></FORM>
	</body>
</HTML>
