<%@ Page language="c#" Codebehind="CollectionDetailsofFees.aspx.cs" AutoEventWireup="false" Inherits="eschool.StudentFees.CollectionDetailsofFees" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="eschool.Classes"%>
<%@ Import namespace="RMG"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CollectionDetailsofFees</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="CollectionDetailsofFees" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="228" width="778" align="center">
				<tr>
					<td align="center"><asp:label id="Label2" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td vAlign="top" align="center"><b>COLLECTION DETAILS OF FEES REPORT</b>
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" borderColorLight="#663300"
							border="5">
							<TR>
								<TD align="center" colSpan="22">class&nbsp;<asp:dropdownlist id="DropClass" Runat="server" CssClass="ComboBox" AutoPostBack="False" width="50px">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist>&nbsp;Section&nbsp;<asp:dropdownlist id="DropSec" Runat="server" CssClass="ComboBox" AutoPostBack="False" width="50px">
										<asp:ListItem Value="Select">Select</asp:ListItem>
										<asp:ListItem Value="A">A</asp:ListItem>
										<asp:ListItem Value="B">B</asp:ListItem>
										<asp:ListItem Value="C">C</asp:ListItem>
										<asp:ListItem Value="D">D</asp:ListItem>
										<asp:ListItem Value="E">E</asp:ListItem>
									</asp:dropdownlist>&nbsp;Duration From&nbsp;
									<asp:textbox id="Txtfromdate" BorderStyle="Groove" runat="server" Width="70px"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.CollectionDetailsofFees.Txtfromdate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A>&nbsp;To&nbsp;<asp:textbox id="Txttodate" BorderStyle="Groove" runat="server" Width="70px"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.CollectionDetailsofFees.Txttodate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A>&nbsp;<BUTTON id="Search" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 90px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 22px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server"><IMG id="txtsearch" style="WIDTH: 16px; HEIGHT: 7px" height="7" src="../../HeaderFooter/images/search.gif"
											width="16"> <U>S</U>earch</BUTTON>&nbsp;<BUTTON id="print" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 70px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 22px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server">Print</BUTTON> &nbsp;<BUTTON id="Exel" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 70px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 22px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server">Exel</BUTTON>
								</TD>
							<TR>
							<TR class="DataGridHeader">
								<TD>Rank</TD>
								<TD>Stream</TD>
								<TD>Fee Rate</TD>
								<TD>Strength</TD>
								<TD>Amount</TD>
							</TR>
							<%
			try
			{
				 rank="";
				 count=0;
				 gTotal=0;
         		InventoryClass obj=new InventoryClass();
         		InventoryClass obj1=new InventoryClass();
				SqlDataReader SqlDtr=null,rdr;
				string  strSelect="";
				if(DropClass.SelectedIndex!=0||DropSec.SelectedIndex!=0)
				{
				if(!Txtfromdate.Text.Equals("")&&!Txttodate.Text.Equals(""))
				{
						for(int i=0;i<feetype.Length-2;i++)
						{
						   strSelect ="select rank,count(rank),student_stream from student_record where student_class='"+DropClass.SelectedItem.Text+"' and Seq_Student_id='"+DropSec.SelectedItem.Text+"' group by rank,student_stream";
							SqlDtr=obj.GetRecordSet(strSelect);
					
						%>
							<tr class="DataGridItem" bgColor="aliceblue">
								<td align="center" colSpan="5"><strong><%=feetype[i].ToString()%></strong></td>
							</tr>
							<%
						while(SqlDtr.Read())
						{
							rank=SqlDtr.GetString(0).ToString().Trim();
							count=System.Convert.ToInt32(SqlDtr.GetValue(1).ToString().Trim());
							stream=SqlDtr.GetString(2).ToString().Trim();
							/*
							rdr = obj1.GetRecordSet("select sum(diary_fee+tution_fee+activity_fee+transport_fee+envp_fee+securityfee+latefee+game_fee+science_fee+admission_fee+annual_fee+hostel_fee+computer_fee) from recuringreceipt where student_id='"+SqlDtr["student_ID"].ToString()+"' and cast(floor(cast(cast(periodto as datetime) as float)) as datetime)>='"+GenUtil.str2DDMMYYYY(Txtfromdate.Text)+"' and cast(floor(cast(cast(period as datetime) as float)) as datetime)<='"+GenUtil.str2DDMMYYYY(Txttodate.Text)+"'");
							if(rdr.Read())
							{
								if(!rdr.GetValue(0).ToString().Equals(""))
									feeamount=double.Parse(rdr.GetValue(0).ToString());
								//else
								//	feeamount=0;
							}
							rdr.Close();
							*/
							feeamount=feesdecisionmonthly(rank,stream,feetype[i]);
							Total=count*feeamount;
							//gCount=gCount+count;	
							gTotal=gTotal+Total;				
						%>
							<tr class="DataGridItem">
								<td align="center"><%=rank.ToString()%></td>
								<td align="center"><%=stream.ToString()%></td>
								<td align="center"><%=feeamount.ToString()%></td>
								<td align="center"><%=count.ToString()%></td>
								<td align="center"><%=Total.ToString()%></td>
								<%
						}
						SqlDtr.Close();
					}
					for(int i=feetype.Length-2;i<feetype.Length;i++)
						{
						   //strSelect ="select rank,count(rank),student_stream from student_record where student_class='"+DropClass.SelectedItem.Text+"' and Seq_Student_id='"+DropSec.SelectedItem.Text+"' group by rank,student_stream";    //add by vikas sharma date 15.11.07
						   strSelect="select rank,count(rank),student_stream from student_record where student_class='"+DropClass.SelectedItem.Text+"' and Seq_Student_id='"+DropSec.SelectedItem.Text+"'  and student_id not in (select student_id from recuringreceipt) group by rank,student_stream";
							SqlDtr=obj.GetRecordSet(strSelect);
					
						%>
							<tr class="DataGridItem" bgColor="aliceblue">
								<td align="center" colSpan="5"><strong><%=feetype[i].ToString()%></strong></td>
							</tr>
							<%
						while(SqlDtr.Read())
						{
							rank=SqlDtr.GetString(0).ToString().Trim();
							count=System.Convert.ToInt32(SqlDtr.GetValue(1).ToString().Trim());
							stream=SqlDtr.GetString(2).ToString().Trim();
							feeamount=feesdecisionmonthly(rank,stream,feetype[i]);
							/*
							rdr = obj1.GetRecordSet("select sum(diary_fee+tution_fee+activity_fee+transport_fee+envp_fee+securityfee+latefee+game_fee+science_fee+admission_fee+annual_fee+hostel_fee+computer_fee) from recuringreceipt where student_id='"+SqlDtr["student_ID"].ToString()+"' and cast(floor(cast(cast(periodto as datetime) as float)) as datetime)>='"+GenUtil.str2DDMMYYYY(Txtfromdate.Text)+"' and cast(floor(cast(cast(period as datetime) as float)) as datetime)<='"+GenUtil.str2DDMMYYYY(Txttodate.Text)+"'");
							if(rdr.Read())
							{
								//string s=rdr.GetValue(0).ToString();
								if(!rdr.GetValue(0).ToString().Equals(""))
									feeamount=double.Parse(rdr.GetValue(0).ToString());
								//else
								//	feeamount=0;
							}
							rdr.Close();
							*/
							Total=count*feeamount;
							//gCount=gCount+count;
							gTotal=gTotal+Total;					
						%>
							<tr class="DataGridItem">
								<td align="center"><%=rank.ToString()%></td>
								<td align="center"><%=stream.ToString()%></td>
								<td align="center"><%=feeamount.ToString()%></td>
								<td align="center"><%=count.ToString()%></td>
								<td align="center"><%=Total.ToString()%></td>
								<%
						}
						SqlDtr.Close();
					}
						
											
						%>
							<tr class="DataGridItem" bgColor="aliceblue">
								<td align="center" colSpan="5"><strong>TRANSPORT FEE</strong></td>
							</tr>
							<%
						//strSelect="select (select route_name from route r where r.route_id= s.routeno),  s.routeno,count(s.routeno) from student_record s where s.student_class='"+DropClass.SelectedItem.Text+"' and s.Seq_Student_id='"+DropSec.SelectedItem.Text+"' and s.service_bus='Yes' group by s.routeno"; //vikas sharma 15.11.07
						strSelect="select (select trfee from route r where r.route_id= s.routeno),  s.routeno,count(s.routeno) from student_record s where s.student_class='"+DropClass.SelectedItem.Text+"' and s.Seq_Student_id='"+DropSec.SelectedItem.Text+"' and s.service_bus='Yes' group by s.routeno";
						SqlDtr=obj.GetRecordSet(strSelect);
					
						while(SqlDtr.Read())
						{
							//routename=SqlDtr.GetString(0).ToString().Trim();
							routename=SqlDtr.GetValue(0).ToString();
							routeid=SqlDtr.GetValue(1).ToString().Trim();
							count=System.Convert.ToInt32(SqlDtr.GetValue(2).ToString().Trim());
							feeamount=feesdecisionmonthly(routeid);
							Total=count*feeamount;
							//gCount=gCount+count;
							gTotal=gTotal+Total;
						%>
							<tr class="DataGridItem">
								<td align="center"><%=routename.ToString()%></td>
								<td align="center"><%=stream.ToString()%></td>
								<td align="center"><%=feeamount.ToString()%></td>
								<td align="center"><%=count.ToString()%></td>
								<td align="center"><%=Total.ToString()%></td>
								<%
						}
						SqlDtr.Close();
				}
			}		
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :CollectionDetailsofFee.aspx,Method  Search_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}	
			%>
							</tr>
							<tr class="DataGridHeader">
								<td align="center">Grand Total</td>
								<td align="center"></td>
								<td align="center"></td>
								<td align="center"></td>
								<td align="center"><%=gTotal.ToString()%></td>
							</tr>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td colSpan="3"></td>
				</tr>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0"
				width="174" scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
