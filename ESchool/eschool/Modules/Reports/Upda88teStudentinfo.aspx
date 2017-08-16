<%@ Page language="c#" Codebehind="Upda88teStudentinfo.aspx.cs" AutoEventWireup="false" Inherits="eschool.Modules.Reports.UpdateStudentinfo" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="DBOperations"%>
<%@ Import namespace="eschool.Classes"%>
<%@ Import namespace="RMG"%>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Update Studentinfo</title>
<meta content="Microsoft Visual Studio .NET 7.1" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content=JavaScript name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema><LINK href="../../HeaderFooter/shareables/Style/Styles.css" type=text/css rel=stylesheet >
  </HEAD>
<body MS_POSITIONING="GridLayout">
<form id="Form1" method=post runat="server"><uc1:header id=Header1 runat="server"></uc1:header>
<table height=250 width=778 align=center>
  <TBODY>
  <tr>
    <td colSpan=3></td></tr>
  <tr>
    <td align=center colSpan=3><asp:label id=Label2 runat="server"></asp:label></td></tr>
  <tr>
    <td></td>
    <td vAlign=top align=center><b 
      >STUDENT INFORMATION REPORT</b> 
      <TABLE id=Table1 cellSpacing=1 cellPadding=1 width=750 
      borderColorLight=#663300 border=5>
        <TBODY>
        <TR>
          <td align=center>Search By&nbsp;&nbsp;&nbsp;<asp:dropdownlist id=Dropstype runat="server" AutoPostBack="True" CssClass="ComboBox">
										<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
										<asp:ListItem Value="Category Wise">Category Wise</asp:ListItem>
										<asp:ListItem Value="Rank Wise">Rank Wise</asp:ListItem>
										<asp:ListItem Value="SCategory Wise">SCategory Wise</asp:ListItem>
										<asp:ListItem Value="StudentID Wise">StudentID Wise</asp:ListItem>
										<asp:ListItem Value="Class Wise">Class Wise</asp:ListItem>
									</asp:dropdownlist></td>
          <td>&nbsp;&nbsp;<asp:label id=lblOption Runat="server">Select Option</asp:label>&nbsp;&nbsp;<asp:dropdownlist id=Dropsopt Runat="server">
										<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
									</asp:dropdownlist><asp:dropdownlist id=DropSection Runat="server">
										<asp:ListItem Value="All">All</asp:ListItem>
										<asp:ListItem Value="A">A</asp:ListItem>
										<asp:ListItem Value="B">B</asp:ListItem>
										<asp:ListItem Value="C">C</asp:ListItem>
										<asp:ListItem Value="D">D</asp:ListItem>
									</asp:dropdownlist> <asp:textbox id=txtStudentid Runat="server" BorderStyle="Groove" Visible="False" Width="40"></asp:textbox></td>
          <TD align=center><BUTTON id=Search 
            style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 92px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 24px; BACKGROUND-COLOR: #e1e1e1" 
            accessKey=S type=button runat="server"><IMG id=txtsearch height=7 src="../../HeaderFooter/images/search.gif" width=16 > <U 
            >S</U>earch</BUTTON></TD>
          <TD align=center><BUTTON class=FormButtonStyle 
            id=Print1 
            style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 88px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 24px; BACKGROUND-COLOR: #e1e1e1" 
            accessKey=S type=button runat="server">&nbsp; 
            <U>P</U>rint</BUTTON></TD></TR>
        <TR>
          <TD align=center colSpan=4>
<%
	if(DropsType.SelectedIndex != 0)
	{
		InventoryClass obj=new InventoryClass();
		SqlDataReader SqlDtr=null,rdr=null;
		string str="";
		if(Dropstyal.selecteditem.text=="catagory wise")
		{
			if(Dropsopt.SelectedIndex ==0)
				str="select * from Student_Record;
			else
				str="select * from Student_Record where catagory='"+Dropsopet.SelectedItem.Text+"'";
		}
		else if(Dropstyal.selecteditem.text=="Rank wise")
		{
			if(Dropsopt.SelectedIndex ==0)
				str="select * from Student_Record;
			else
				str="select * from Student_Record where rank='"+Dropsopet.SelectedItem.Text+"'";
		}
		else if(Dropstyal.selecteditem.text=="SCatagory wise")
		{
			if(Dropsopt.SelectedIndex ==0)
				str="select * from Student_Record;
			else
				str="select * from Student_Record where scatagory='"+Dropsopet.SelectedItem.Text+"'";
		}
		else if(Dropstyal.selecteditem.text=="StudentID Wise")
		{
			if(Dropsopt.SelectedIndex ==0)
				str="select * from Student_Record;
			else
				str="select * from Student_Record where Student_ID='"+Dropsopet.SelectedItem.Text+"'";
		}
		else if(Dropstyal.selecteditem.text=="Class wise")
		{
			if(Dropsopt.SelectedIndex==0)
			{
				if(DropSection.SelectedIndex==0)
					str="select * from Student_Record;
				else
					str="select * from Student_Record where Seq_Student_ID='"+DropSection.SelectedIndex+"'";
			}
			else
			{
				if(DropSection.SelectedIndex==0)
					str="select * from Student_Record where Student_class='"+Dropstyal.selecteditem.text+"'";
				else
					str="select * from Student_Record where Seq_Student_ID='"+DropSection.SelectedIndex+"'";
			}
		}
		int i=0;
	%>
		<TABLE id=Table3 cellSpacing=cellPadding= width="80%" 
            borderColorLight=#663300 border=5>
              <TR class=DataGridHeader>
                <TD>StudentID</TD>
                <TD>Student Name</TD>
                <TD>Class</TD>
                <TD>Section</TD>
                <TD>Stream</TD>
                <TD>SCatagory</TD>
                <TD>Rank</TD>
                <TD>Logistic</TD>
                <TD>Root No</TD></TR>
                <%
                 while(SqlDtr.Read())
                 {
                  %>
                  <tr>
                  <td><%=Sqldtr["Student_id"]%></td>
                  <td><%=Sqldtr["student_fname"]%></td>
                  <td><%=Sqldtr["student_class"]%></td>
                  <td><%=Sqldtr["seq_section_id"]%></td>
                  <td><select name="DropStream<%=i%>"><OPTION value=Select selected ?>Select</OPTION></select></td>
                    <td><select name="DropCat<%=i%>"><OPTION value=Select selected ?>Select</OPTION></select></td>
                    <td><select name="DropRank<%=i%>"><OPTION value=Select selected ?>Select</OPTION></select></td>
                    <td><select name="DropLogistic<%=i%>"><OPTION value=Select selected ?>Select</OPTION></select></td>
                   <td><select name="DropRoot<%=i%>"><OPTION value=Select selected ?>Select</OPTION></select></td> 
                </tr><%i++;
                 }
                %></TABLE></TD></TR></TBODY></TABLE><%}%></td>
  <TR>
    <TD></TD></TR>
  <TR>
    <TD 
colSpan=3></TD></TR></TBODY></table></TD></TR></TBODY></TABLE></form></body>
</HTML>
