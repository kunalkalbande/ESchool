<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="FeesSearch.aspx.cs" AutoEventWireup="false" Inherits="eschool.StudentFees.FeesSearch" %>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="eschool.Classes"%>
<%@ Import namespace="RMG"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>eSchool : Reconcilation Report</title> 
		<!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<script language="javascript">
		
		// this method use to show total amount of fees.
		function Amount()
		{
			var frm=document.FeesSearch.all
			var rem=document.FeesSearch.all.amount.value;
			var temp=document.FeesSearch.all.tempamount.value
			if(temp>0 && document.FeesSearch.all.amount.value!="" && FeesSearch.all.gamount!=null) 
			{
				document.FeesSearch.all.gamount.value=temp-rem
				document.FeesSearch.all.txtCurrQtrDue.value=temp-rem
				frm.txtTotalDue.value=parseFloat(frm.txtLastQtrDue.value)+parseFloat(frm.txtCurrQtrDue.value)
				frm.txtDueQtr.value=parseFloat(frm.txtTotalDue.value)-parseFloat(frm.txtPrevAdv.value)+parseFloat(frm.txtAdvColNextQtr.value)-parseFloat(frm.txtColCurrQtr.value)
   			}
   			else if((document.FeesSearch.all.amount.value=="" || rem==0) && FeesSearch.all.gamount!=null)
   			{
	   			document.FeesSearch.all.gamount.value=temp
   				document.FeesSearch.all.txtCurrQtrDue.value=temp
  			}   		   
		}
		
		// this method use to adjust fees amount.
		function Reconcilation()
		{
			var frm=document.FeesSearch.all
			var val=frm.txtOthers.value
			if(frm.txtOthers.value>=0 && frm.txtOthers.value!="")
			{
				frm.txtTotalDue.value=parseFloat(frm.txtLastQtrDue.value)+parseFloat(val)+parseFloat(frm.txtCurrQtrDue.value)
				frm.txtDueQtr.value=parseFloat(frm.txtTotalDue.value)-parseFloat(frm.txtPrevAdv.value)+parseFloat(frm.txtAdvColNextQtr.value)-parseFloat(frm.txtColCurrQtr.value)
			}
			else if(frm.txtOthers.value<0 && frm.txtOthers.value!="")
			{
				frm.txtTotalDue.value=parseFloat(frm.txtLastQtrDue.value)+parseFloat(frm.txtCurrQtrDue.value)+parseFloat(val)
				frm.txtDueQtr.value=parseFloat(frm.txtTotalDue.value)-parseFloat(frm.txtPrevAdv.value)+parseFloat(frm.txtAdvColNextQtr.value)-parseFloat(frm.txtColCurrQtr.value)
			}
		}

		</script>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body>
		<form id="FeesSearch" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td colSpan="3"></td>
				</tr>
				<tr>
					<td align="center" colSpan="3"><asp:label id="Label2" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td vAlign="top" align="center"><b>RECONCILIATION REPORT</b>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" borderColorLight="#663300"
							border="5">
							<TBODY>
								<TR>
									<TD align="center" colSpan="7">Previous Duration
										<asp:textbox id="TextPrevfrom" BorderStyle="Groove" Runat="server" Width="70px" CssClass="FontStyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.FeesSearch.TextPrevfrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
												border="0"></A>To
										<asp:textbox id="TextPrevto" BorderStyle="Groove" Runat="server" Width="70px" CssClass="FontStyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.FeesSearch.TextPrevto);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
												border="0"></A> Next Duration
										<asp:textbox id="TextNextfrom" BorderStyle="Groove" Runat="server" Width="70px" CssClass="FontStyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.FeesSearch.TextNextfrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
												border="0"></A>To
										<asp:textbox id="TextNextto" BorderStyle="Groove" Runat="server" Width="70px" CssClass="FontStyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.FeesSearch.TextNextto);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
												border="0"></A></TD>
								<tr>
									<td align="center" colSpan="7">Class<asp:dropdownlist CssClass=ComboBox id="DropClass" runat="server" Width="60px">
											<asp:ListItem Value="All">All</asp:ListItem>
										</asp:dropdownlist>
										Section<asp:dropdownlist id="DropSection" CssClass=ComboBox runat="server" Width="60px">
											<asp:ListItem Value="Select">Select</asp:ListItem>
											<asp:ListItem Value="A">A</asp:ListItem>
											<asp:ListItem Value="B">B</asp:ListItem>
											<asp:ListItem Value="C">C</asp:ListItem>
											<asp:ListItem Value="D">D</asp:ListItem>
											<asp:ListItem Value="E">E</asp:ListItem>
											<asp:ListItem Value="F">F</asp:ListItem>
											<asp:ListItem Value="G">G</asp:ListItem>
											<asp:ListItem Value="H">H</asp:ListItem>
											<asp:ListItem Value="I">I</asp:ListItem>
											<asp:ListItem Value="J">J</asp:ListItem>
	
										</asp:dropdownlist>
										Current Duration From
										<asp:textbox id="TxtFrom" BorderStyle="Groove" Runat="server" Width="70px" CssClass="FontStyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.FeesSearch.TxtFrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
												border="0"></A> To
										<asp:textbox id="TxtTo" BorderStyle="Groove" Runat="server" Width="70px" CssClass="FontStyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.FeesSearch.TxtTo);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
												border="0"></A></td>
					</td>
				</tr>
				<tr align=center><td><BUTTON id="Search" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 100px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
											accessKey="S" type="button" runat="server"><IMG id="txtsearch" style="WIDTH: 16px; HEIGHT: 7px" height="7" src="../../HeaderFooter/images/search.gif"
												width="16"> <U>S</U>earch</BUTTON>&nbsp;&nbsp;<BUTTON class="FormButtonStyle" id="BtnPrint" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
											accessKey="S" type="button" runat="server">Print</BUTTON>&nbsp;&nbsp;<BUTTON class="FormButtonStyle" id="Btnexcel" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
											accessKey="S" type="button" runat="server">Excel</BUTTON></td></tr>
			</table>
			<TABLE cellSpacing="1" cellPadding="1" width="100%" borderColorLight="#663300" border="5">
				<TR bgColor="#663300">
					<TD align="center"><b><font color="#ffffff">Rank</font></b></TD>
					<TD align="center"><b><font color="#ffffff">Stream</font></b></TD>
					<TD align="center"><b><font color="#ffffff">Fee Rate</font></b></TD>
					<TD align="center"><b><font color="#ffffff">Strength</font></b></TD>
					<TD align="center"><b><font color="#ffffff">Amount</font></b></TD></TD></TR>
				<%
				bool f=false;
				try
				{
					rank="";
					count=0;
					gTotal=0;
         			InventoryClass obj=new InventoryClass();
         			InventoryClass obj1=new InventoryClass();
					SqlDataReader SqlDtr=null,rdr;
					string  strSelect="";
					if(DropClass.SelectedIndex!=0||DropSection.SelectedIndex!=0)
					{
						if(!TxtFrom.Text.Equals("")&&!TxtTo.Text.Equals(""))
						{
							for(int i=0;i<feetype.Length-2;i++)
							{
								//strSelect ="select rank,count(rank),student_stream from student_record where student_class='"+DropClass.SelectedItem.Text+"' and Seq_Student_id='"+DropSection.SelectedItem.Text+"' and student_admissiondate <='"+GenUtil.str2MMDDYYYY(TxtFrom.Text.ToString())+"' group by rank,student_stream";
							    strSelect ="select rank,count(rank),student_stream from student_record where student_class='"+DropClass.SelectedItem.Text+"' and Seq_Student_id='"+DropSection.SelectedItem.Text+"' and student_admissiondate <='"+GenUtil.str2MMDDYYYY(TxtTo.Text.ToString())+"' group by rank,student_stream";//added by vishnu 23/11
								SqlDtr=obj.GetRecordSet(strSelect);
								%>
								<tr class="DataGridItem" bgColor="aliceblue">
									<td align="center" colSpan="5"><strong><%=feetypeT[i].ToString()%></strong></td>
								</tr>
								<%
								while(SqlDtr.Read())
								{
									rank=SqlDtr.GetString(0).ToString().Trim();
									count=System.Convert.ToInt32(SqlDtr.GetValue(1).ToString().Trim());
									stream=SqlDtr.GetString(2).ToString().Trim();
									feeamount=collectionmonthly(rank,stream,feetype[i]);
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
							for(int i=feetype.Length;i<feetype.Length-2;i++)
							{
								//strSelect ="select rank,count(rank),student_stream from student_record where student_class='"+DropClass.SelectedItem.Text+"' and Seq_Student_id='"+DropSec.SelectedItem.Text+"' group by rank,student_stream";    //add by vikas sharma date 15.11.07
								//strSelect="select rank,count(rank),student_stream from student_record where student_class='"+DropClass.SelectedItem.Text+"' and Seq_Student_id='"+DropSection.SelectedItem.Text+"'  and student_id not in (select student_id from recuringreceipt) and student_admissiondate <='"+GenUtil.str2MMDDYYYY(TxtFrom.Text.ToString())+"' group by rank,student_stream";
								strSelect="select rank,count(rank),student_stream from student_record where student_class='"+DropClass.SelectedItem.Text+"' and Seq_Student_id='"+DropSection.SelectedItem.Text+"'  and student_id not in (select student_id from recuringreceipt) and student_admissiondate <='"+GenUtil.str2MMDDYYYY(TxtTo.Text.ToString())+"' group by rank,student_stream";//added by vishnu 23/11
								SqlDtr=obj.GetRecordSet(strSelect);
								%>
								<tr class="DataGridItem" bgColor="aliceblue">
									<td align="center" colSpan="5"><strong><%=feetypeT[i].ToString()%></strong></td>
								</tr>
								<%
								while(SqlDtr.Read())
								{
									rank=SqlDtr.GetString(0).ToString().Trim();
									count=System.Convert.ToInt32(SqlDtr.GetValue(1).ToString().Trim());
									stream=SqlDtr.GetString(2).ToString().Trim();
									feeamount=collectionmonthly(rank,stream,feetype[i]);
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
							<tr bgColor="#663300">
								<td align="right" colSpan="4"><b><font color="#ffffff">Grand Total</font></b> &nbsp;&nbsp;&nbsp;&nbsp;</td>
								<td align="center"><font color="#ffffff"><b><%=gTotal.ToString()%></b< font></B></font></td>
							</tr>
							<%
							//strSelect="select student_id,fees_amount  from recuringreceipt  where student_id in( select student_id from student_record where student_class='I' and Seq_Student_id='A'  and student_admissiondate between '10/1/2007' and '12/31/2007')";
							//strSelect="select student_id,Tution_fee,latefee,admission_fee,annual_fee,envp_fee,fees_amount  from recuringreceipt  where student_id in( select student_id from student_record where student_class='"+DropClass.SelectedItem.Text+"' and Seq_Student_id=' "+DropSection.SelectedItem.Text+"' and student_admissiondate between '10/1/2007' and '12/31/2007')";
							strSelect="select student_id,Fees_type,Tution_fee,latefee,admission_fee,securityfee,annual_fee,envp_fee,diary_fee,fees_amount  from recuringreceipt  where student_id in( select student_id from student_record where student_class='I' and Seq_Student_id='A'  and student_admissiondate between '"+GenUtil.str2MMDDYYYY(TxtFrom.Text.ToString())+"' and '"+GenUtil.str2MMDDYYYY(TxtTo.Text.ToString())+"')";
							SqlDtr=obj.GetRecordSet(strSelect);
							string sid="";
							int k=0;
							while(SqlDtr.Read())
							{
								sid=SqlDtr.GetValue(0).ToString();
								if(k==0)
								{
									f=true;
									%>
						</TABLE>
							<table id="Table5" cellSpacing="1" cellPadding="1" width="100%" borderColorLight="#663300"	border="5">
								<TR bgColor="#663300">
									<td align="center"><b><font color="#ffffff">Student Id</font></b></td>
									<td align="center"><b><font color="#ffffff">Duration</font></b></td>
									<td align="center"><b><font color="#ffffff">Tution</font></b></td>
									<td align="center"><b><font color="#ffffff">Late</font></b></td>
									<td align="center"><b><font color="#ffffff">Admis</font></b></td>
									<td align="center"><b><font color="#ffffff">Security</font></b></td>
									<td align="center"><b><font color="#ffffff">Annual</font></b></td>
									<td align="center"><b><font color="#ffffff">Devel</font></b></td>
									<td align="center"><b><font color="#ffffff">Diary</font></b></td>
									<td align="center"><b><font color="#ffffff">Fees Amount</font></b></td>
							<%}
							%>
							<TR class="DataGridItem">
								<td align="center"><%=sid.ToString()%></td>
								<td align="center"><%=SqlDtr.GetValue(1).ToString()%></td>
								<td align="center"><%=SqlDtr.GetValue(2).ToString()%></td>
								<td align="center"><%=SqlDtr.GetValue(3).ToString()%></td>
								<td align="center"><%=SqlDtr.GetValue(4).ToString()%></td>
								<td align="center"><%=SqlDtr.GetValue(5).ToString()%></td>
								<td align="center"><%=SqlDtr.GetValue(6).ToString()%></td>
								<td align="center"><%=SqlDtr.GetValue(7).ToString()%></td>
								<td align="center"><%=SqlDtr.GetValue(8).ToString()%></td>
								<td align="center"><%=SqlDtr.GetValue(9).ToString()%></td>
								<%
								k++;
							}
						}		
					}
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog(" Form :FeesSearch.aspx,Method  HtmlPart,  Exception: "+ex.Message+" , Userid :  "+ Session["password"]   );		
				}	
				%>
					</TR>
					<tr>
						<td align="center" colSpan="2">Remark For Less Amount</td>
						<td colSpan="2"><asp:textbox id="remark" BorderStyle="Groove" Runat="server" Width="100%" Font-Size="8pt"></asp:textbox><asp:comparevalidator id="Comparevalidator2" Runat="server" Operator="DataTypeCheck" ErrorMessage="Enter A String"
								ControlToValidate="remark" Display="Dynamic" Type="String">*</asp:comparevalidator><input 
								type=hidden value=<%=gTotal.ToString()%> name=tempamount></td>
							<td align="center"><asp:textbox id="amount" onblur="Amount();" style="TEXT-ALIGN: center" BorderStyle="Groove" Runat="server"
							Width="100%" Font-Size="8pt"></asp:textbox><asp:comparevalidator id="Comparevalidator1" Runat="server" Operator="DataTypeCheck" ErrorMessage="Enter in Numeric Format"
							ControlToValidate="amount" Display="Dynamic" Type="Integer">*</asp:comparevalidator></td>
					</tr>
					<%
					if(f==true)
					{
						%>
						<tr bgColor="#663300">
							<td align="right" colSpan="9"><b><font color="#ffffff">Grand Total &nbsp;&nbsp;&nbsp;&nbsp;</font></b></td>
							<td align="center"><asp:textbox id=gamount style="TEXT-ALIGN: center" BorderStyle="Groove" Runat="server" Width="100%" Font-Size="8pt" value="<%=gTotal.ToString()%>"></asp:textbox></td>
						</tr>
						<%
					}
					%>
					</table>
					<TABLE cellSpacing="1" cellPadding="1" width="100%" borderColorLight="#663300" border="5">
						<TR bgColor="#663300">
							<TH>
								<font color="white">Last Qtr Due</font></TH>
							<TH>
								<font color="white">
								<asp:textbox id="txtRemothers" BorderStyle="Groove" Runat="server" Width="100%"></asp:textbox></font></TH><asp:comparevalidator id="Comparevalidator3" Runat="server" Operator="DataTypeCheck" ErrorMessage="Enter A String"
								ControlToValidate="txtRemothers" Display="Dynamic" Type="String">*</asp:comparevalidator>
							<TH>
								<font color="white">Current Qtr Due</font></TH>
							<TH>
								<font color="white">Total Due</font></TH>
							<tr>
								<td align="center"><asp:textbox id="txtLastQtrDue" style="TEXT-ALIGN: right" BorderStyle="Groove" Runat="server"
									Width="100%" ReadOnly></asp:textbox></td>
								<td align="center"><asp:textbox id="txtOthers" onblur="Reconcilation();" style="TEXT-ALIGN: right" BorderStyle="Groove"
									Runat="server" Width="100%"></asp:textbox><asp:comparevalidator id="Comparevalidator4" Runat="server" Operator="DataTypeCheck" ErrorMessage="Enter A String"
									ControlToValidate="txtOthers" Display="Dynamic" Type="Integer">*</asp:comparevalidator></td>
								<td align="center"><asp:textbox id="txtCurrQtrDue" style="TEXT-ALIGN: right" BorderStyle="Groove" Runat="server"
									Width="100%" ReadOnly></asp:textbox></td>
								<td align="center"><asp:textbox id="txtTotalDue" style="TEXT-ALIGN: right" BorderStyle="Groove" Runat="server" Width="100%"
									ReadOnly></asp:textbox></td>
							<TR bgColor="#663300">
								<TH>
									<font color="white">Previous<br>
												Advance</font></TH>
								<TH>
									<font color="white">Advance Collect<br>
										For Next Qtr</font></TH>
								<TH>
									<font color="white">Collection in<br>
									Current Qtr</font></TH>
								<TH>
									<font color="white">Due For The Qtr</font></TH></TR>
								<tr>
								<td align="center"><asp:textbox id="txtPrevAdv" style="TEXT-ALIGN: right" BorderStyle="Groove" Runat="server" Width="100%"
									ReadOnly></asp:textbox></td>
								<td align="center"><asp:textbox id="txtAdvColNextQtr" style="TEXT-ALIGN: right" BorderStyle="Groove" Runat="server"
									Width="100%" ReadOnly></asp:textbox></td>
								<td align="center"><asp:textbox id="txtColCurrQtr" style="TEXT-ALIGN: right" BorderStyle="Groove" Runat="server"
										Width="100%" ReadOnly></asp:textbox></td>
								<td align="center"><asp:textbox id="txtDueQtr" style="TEXT-ALIGN: right" BorderStyle="Groove" Runat="server" Width="100%"
									ReadOnly></asp:textbox></td>
							</tr></TD></tr> 
							<!--<td colSpan=7>Remark For Less Amount&nbsp;<asp:textbox id="Textbox1" BorderStyle="Groove" Runat="server" Width="83%" Font-Size=8pt></asp:textbox> 
							</tr>--></TABLE></TD></TR></TBODY></TABLE><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
							name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0" width="174" scrolling="no"
							height="189"></iframe>
						<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
					</body>
			</HTML>
