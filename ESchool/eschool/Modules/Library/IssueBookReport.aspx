<%@ Register TagPrefix=uc1 TagName=Header Src="../../HeaderFooter/usercontrol/header.ascx"%>
<%@ Register TagPrefix=uc1 TagName=Footer Src="../../HeaderFooter/usercontrol/Footer.ascx"%>
<%@ Page language="c#" Codebehind="IssueBookReport.aspx.cs" AutoEventWireup="false" Inherits="eschool.Modules.Library.IssueBookReport" %>
<%@ Import namespace="RMG"%>
<%@ Import namespace="eschool.Classes"%>
<%@ Import namespace="System.Data.SqlClient"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Issue Book Report</title> 
		<!--%@ Import namespace="RMG"%--> <!--
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
		<!--<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Styles.css" type="text/css" rel="stylesheet">-->
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="IssueBookReport" method="post" runat="server">
			<uc1:Header id="header" runat="server"></uc1:Header>
			<table height="290" class="border" width="778" align="center">
				<tr>
					<td align="center" colSpan="3"><asp:label id="Label2" runat="server"></asp:label></td>
				</tr>
				<TR>
					<td vAlign="top" align="center"><b>ISSUE BOOK REPORT</b>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="80%" bordercolorlight="#663300"
							border="5">
							<TBODY>
								<TR>
									<TD align="center" colSpan="7">&nbsp;Search&nbsp;Type&nbsp;
										<asp:dropdownlist id="Dropstype" runat="server" AutoPostBack="True" Width="90" CssClass="ComboBox">
											<asp:ListItem Value="Select">Select</asp:ListItem>
											<asp:ListItem Value="All">All</asp:ListItem>
											<asp:ListItem Value="Staff Wise">Staff Wise</asp:ListItem>
											<asp:ListItem Value="Student Wise">Student Wise</asp:ListItem>
										</asp:dropdownlist>&nbsp;Select Option &nbsp;
										<asp:dropdownlist id="Dropsopt" runat="server" Width="100px" CssClass="ComboBox">
											<asp:ListItem Value="  ">Select</asp:ListItem>
										</asp:dropdownlist>&nbsp;From&nbsp;
										<asp:textbox id="Txtfdate" BorderStyle="Groove" runat="server" Width="70px" CssClass="FontStyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.IssueBookReport.Txtfdate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
												border="0"></A>&nbsp;To&nbsp;<asp:textbox id="Txttodate" BorderStyle="Groove" runat="server" Width="70px" CssClass="FontStyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.IssueBookReport.Txttodate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
												border="0"></A></TD>
								</TR>
								<tr>
									<td align="center" colSpan="7">&nbsp;<BUTTON id="Search" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 103px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 22px; BACKGROUND-COLOR: #c0c0c0"
											accessKey="S" type="button" runat="server"><IMG id="txtsearch" height="7" src="../../HeaderFooter/images/search.gif" width="16">
											<U>S</U>earch</BUTTON> &nbsp;<BUTTON class="FormButtonStyle" id="Button1" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 22px; BACKGROUND-COLOR: #c0c0c0"
											accessKey="S" type="button" runat="server">&nbsp;<U>P</U>rint</BUTTON>&nbsp;<BUTTON class="FormButtonStyle" id="Btnexcel" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 22px; BACKGROUND-COLOR: #c0c0c0"
											accessKey="S" type="button" runat="server"><u>E</u>xcel</BUTTON></td>
								</tr>
				
				<% 
							try
								{
								   string sql="";
								   if(flage==1)
								   {
										SqlConnection scon1;
										SqlCommand cmd1;
										scon1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
										scon1.Open();
										if(Dropstype.SelectedItem.Text=="All")
										{
											///sql="select ib.Book_ID,st.bookname,sr.student_fname,sr.student_class,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr,staff_information si where (ib.Book_ID=st.Book_ID and sr.student_id=ib.memberID) union select ib.Book_ID,st.bookname,si.staff_name,si.staff_type,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr,staff_information si where ib.Book_ID=st.Book_ID and si.staff_id=ib.memberID ";    //Comment By vikas sharma Date On 5.1.08
											//22.11.08 sql="select ib.Book_ID,st.bookname,sr.student_fname,sr.student_class,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr,staff_information si where (ib.Book_ID=st.Book_ID and sr.student_id=ib.memberID and Type='Student') union select ib.Book_ID,st.bookname,si.staff_name,si.staff_type,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr,staff_information si where ib.Book_ID=st.Book_ID and si.staff_id=ib.memberID and Type='Staff'";
											sql="select ib.Book_ID,st.bookname,sr.student_fname,sr.student_class,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr,staff_information si where (ib.Book_ID=st.Book_ID and sr.student_id=ib.memberID and Type='Student') and Date_Of_issue between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"' union select ib.Book_ID,st.bookname,si.staff_name,si.staff_type,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr,staff_information si where ib.Book_ID=st.Book_ID and si.staff_id=ib.memberID and Type='Staff' and Date_Of_issue between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
										}
										else if(Dropstype.SelectedItem.Text=="Staff Wise")
										{
										    if(Dropsopt.SelectedItem.Text=="All")
											{
												///sql="select distinct ib.Book_ID,st.bookname,si.staff_name,si.staff_type,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr,staff_information si where ib.Book_ID=st.Book_ID and si.staff_id=ib.memberID"; //Comment By vikas sharma Date On 5.1.08
									            //22.11.08 sql="select distinct ib.Book_ID,st.bookname,si.staff_name,si.staff_type,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr,staff_information si where ib.Book_ID=st.Book_ID and si.staff_id=ib.memberID and Type='Staff'";
										        sql="select distinct ib.Book_ID,st.bookname,si.staff_name,si.staff_type,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr,staff_information si where ib.Book_ID=st.Book_ID and si.staff_id=ib.memberID and Type='Staff' and Date_Of_issue between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
									        }
											else
										        ///sql="select ib.Book_ID,st.bookname,si.staff_name,si.staff_type,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,staff_information si where ib.Book_ID in (select  Book_ID from issue_book where memberid="+Dropsopt.SelectedItem.Text+") and st.book_id in (select  Book_ID from issue_book where memberid="+Dropsopt.SelectedItem.Text+") and si.staff_id="+Dropsopt.SelectedItem.Text+" and ib.memberid="+Dropsopt.SelectedItem.Text;  //Comment By vikas sharma Date On 5.1.08
												//24.11.08 sql="select ib.Book_ID,st.bookname,si.staff_name,si.staff_type,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,staff_information si where ib.Book_ID in (select Book_ID from issue_book where memberid="+Dropsopt.SelectedItem.Text+" and Type='Staff') and st.book_id in (select  Book_ID from issue_book where memberid="+Dropsopt.SelectedItem.Text+" and type='Staff') and si.staff_id="+Dropsopt.SelectedItem.Text+" and ib.memberid="+Dropsopt.SelectedItem.Text+" and Type='Staff'";
												sql="select ib.Book_ID,st.bookname,si.staff_name,si.staff_type,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,staff_information si where ib.memberid="+Dropsopt.SelectedItem.Text+" and Type='Staff'and si.staff_id=ib.memberid and st.book_id=ib.book_id and ib.date_of_issue between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
										}
										else if(Dropstype.SelectedItem.Text=="Student Wise")
										{
										    if(Dropsopt.SelectedItem.Text=="All")
											{
												///sql="select distinct ib.Book_ID,st.bookname,sr.student_fname,sr.student_class,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr,staff_information si where (ib.Book_ID=st.Book_ID and sr.student_id=ib.memberID)";  //Comment By vikas sharma Date On 5.1.08
												//22.11.08 sql="select distinct ib.Book_ID,st.bookname,sr.student_fname,sr.student_class,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr,staff_information si where (ib.Book_ID=st.Book_ID and sr.student_id=ib.memberID and Type='Student')";
												sql="select distinct ib.Book_ID,st.bookname,sr.student_fname,sr.student_class,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr,staff_information si where (ib.Book_ID=st.Book_ID and sr.student_id=ib.memberID and Type='Student') and Date_Of_issue between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
											}
											else
												///sql="select ib.Book_ID,st.bookname,sr.student_class,sr.student_fname,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr where ib.Book_ID in (select  Book_ID from issue_book where memberid="+Dropsopt.SelectedItem.Text+") and st.book_id in (select  Book_ID from issue_book where memberid="+Dropsopt.SelectedItem.Text+") and sr.student_id="+Dropsopt.SelectedItem.Text+" and ib.memberid="+Dropsopt.SelectedItem.Text;  //Comment By vikas sharma Date On 5.1.08
												//sql="select ib.Book_ID,st.bookname,sr.student_class,sr.student_fname,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr where ib.Book_ID in (select  Book_ID from issue_book where memberid="+Dropsopt.SelectedItem.Text+" and Type='Student') and st.book_id in (select  Book_ID from issue_book where memberid="+Dropsopt.SelectedItem.Text+" and Type='Student') and sr.student_id="+Dropsopt.SelectedItem.Text+" and ib.memberid="+Dropsopt.SelectedItem.Text+" and Type='Student'";
												//24.11.08 sql="select ib.Book_ID,st.bookname,sr.student_class,sr.student_fname,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr where ib.Book_ID in (select  Book_ID from issue_book where memberid="+Dropsopt.SelectedItem.Text+" and Type='Student') and st.book_id in (select  Book_ID from issue_book where memberid="+Dropsopt.SelectedItem.Text+" and Type='Student') and sr.student_id="+Dropsopt.SelectedItem.Text+" and ib.memberid="+Dropsopt.SelectedItem.Text+" and Type='Student'";
												sql="select ib.Book_ID,st.bookname,sr.student_class,sr.student_fname,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr where ib.memberid="+Dropsopt.SelectedItem.Text+" and Type='Student' and sr.student_id= ib.memberid and ib.Book_ID = st.book_id and ib.date_of_issue between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
										}
										else if(Dropstype.SelectedItem.Text=="Select")
										{
											MessageBox.Show("Please Select Search Type");
										    //return;
										}
										cmd1=new SqlCommand(sql,scon1);
										dr1=cmd1.ExecuteReader();
										if(dr1.HasRows)
										{
											%>
				<TR bgColor="#663300">
					<TD align="center"><b><font color="#ffffff">Member ID</font></b></TD>
					<td align="center"><b><font color="#ffffff">Member Name</font></b></td>
					<td align="center"><b><font color="#ffffff">Book ID</font></b></td>
					<td align="center"><b><font color="#ffffff">Book Name</font></b></td>
					<td align="center"><b><font color="#ffffff">Class/Desig.</font></b></td>
					<td align="center"><b><font color="#ffffff">Date Of Issue</font></b></td>
					<td align="center"><b><font color="#ffffff">Return Date</font></b></td>
				</TR>
				<%
											while(dr1.Read())
											{
	                 							%>
				<TR>
					<TD align="center"><%=dr1["memberID"].ToString()%></TD>
					<%if(Dropstype.SelectedItem.Text=="Staff Wise")
													{
														%>
					<td align="left"><%=dr1["staff_name"].ToString()%></td>
					<%
													}
													else
													{
														%>
					<td align="left"><%=dr1["student_fname"].ToString()%></td>
					<%
													}
													%>
					<td align="center"><%=dr1["Book_ID"].ToString()%></td>
					<td align="left"><%=dr1["bookname"].ToString()%></td>
					<%if(Dropstype.SelectedItem.Text=="Staff Wise")
													{
														%>
					<td align="left"><%=dr1["staff_type"].ToString()%></td>
					<%
													}
													else
													{
														%>
					<td align="left"><%=dr1["student_class"].ToString()%></td>
					<%
													}
													%>
					<td align="center"><%=GenUtil.str2DDMMYYYY(GenUtil.trimDate(dr1["Date_of_issue"].ToString()))%></td>
					<td align="center"><%=GenUtil.str2DDMMYYYY(GenUtil.trimDate(dr1["Return_Date"].ToString()))%></td>
				</TR>
				<%	
											}
										}
										else
										{
										 MessageBox.Show("Data Not found");
										}
										dr1.Close();
									}
								}
								catch(Exception ex)
								{
									//MessageBox.Show(ex.Message);
								}
								%>
			</TBODY></table>
			</TD></TR></TABLE>
			<uc1:Footer id="footer" runat="server"></uc1:Footer>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0"
				width="174" scrolling="no" height="189"></iframe>
		</form>
	</body>
</HTML>
