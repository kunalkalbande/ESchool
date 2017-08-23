<%@ Page language="c#" Codebehind="Completesalarydata.aspx.cs" AutoEventWireup="false" Inherits="eschool.Reports.Completesalarydata" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Import namespace="RMG"%>
<%@ Import namespace="eschool.Classes"%>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="System.Web.SessionState"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>eSchool : Complete Salary Report</title>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content=JavaScript name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema><LINK href="../../HeaderFooter/shareables/Style/Styles.css" type=text/css rel=stylesheet >
<script language=javascript>

		// first this method show a input box and read some value from this box. and check if it is 1 then generate and show new salary report.
		// and if 2 then show another input box. if enter any employee id then show these employee,s salary of a particular month. other wise show all record.
		function check()
        { 
             document.salarysheet.hidden1.value=""
             document.salarysheet.hidden2.value=""
             var index=document.salarysheet.Dropmonth.selectedIndex
             var index1=document.salarysheet.Dropyear.selectedIndex
             if(index==0||index1==0)
             {
				alert("Please Select Month and Year");
				return;
			 }
             var v=prompt("Enter 1 for New and 2 for Existing","1");
             if(v==1)
             {
                document.salarysheet.hidden1.value=v
             }
             else if(v==2)
             {
                document.salarysheet.hidden1.value=v                  
                var v1=prompt("Enter Staff ID","ALL");
                if(v1!=null)
                  document.salarysheet.hidden2.value=v1.toUpperCase()
             }
             else
             {
                alert("Please select only 1 or 2")
                return
             }
       }
		</script>
</HEAD>
<body>
<form id=salarysheet method=post runat="server"><uc1:header id=Header1 runat="server"></uc1:header>
<table height=250 width=778 align=center>
  <tr>
    <td><INPUT type=hidden name=hidden1 style="VISIBILITY: hidden; WIDTH: 1px; HEIGHT: 1px"><INPUT type=hidden name=hidden2 style="VISIBILITY: hidden; WIDTH: 1px; HEIGHT: 1px"></TD></TR>
  <tr>
    <td align=center><b>COMPLETE SALARY REPORT</B> 
		<TABLE id=Table1 cellSpacing=1 cellPadding=1 borderColorLight=#663300 border=5>
			<TR>
				<td align=center colSpan=3>Month&nbsp;&nbsp;&nbsp;&nbsp; <asp:dropdownlist id=Dropmonth Runat="server" CssClass="ComboBox">
										<asp:ListItem Value="Select">Select</asp:ListItem>
										<asp:ListItem Value="January">January</asp:ListItem>
										<asp:ListItem Value="February">February</asp:ListItem>
										<asp:ListItem Value="March">March</asp:ListItem>
										<asp:ListItem Value="April">April</asp:ListItem>
										<asp:ListItem Value="May">May</asp:ListItem>
										<asp:ListItem Value="June">June</asp:ListItem>
										<asp:ListItem Value="July">July</asp:ListItem>
										<asp:ListItem Value="August">August</asp:ListItem>
										<asp:ListItem Value="September">September</asp:ListItem>
										<asp:ListItem Value="October">October</asp:ListItem>
										<asp:ListItem Value="November">November</asp:ListItem>
										<asp:ListItem Value="December">December</asp:ListItem>
									</asp:dropdownlist></TD>
									 <td align=center colSpan=2>Year&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:dropdownlist id=Dropyear Runat="server" CssClass="ComboBox">
										<asp:ListItem Value="Select">Select</asp:ListItem>
										<asp:ListItem Value="2007">2007</asp:ListItem>
										<asp:ListItem Value="2008">2008</asp:ListItem>
										<asp:ListItem Value="2009">2009</asp:ListItem>
										<asp:ListItem Value="2010">2010</asp:ListItem>
										<asp:ListItem Value="2011">2011</asp:ListItem>
										<asp:ListItem Value="2012">2012</asp:ListItem>
										<asp:ListItem Value="2013">2013</asp:ListItem>
										<asp:ListItem Value="2014">2014</asp:ListItem>
										<asp:ListItem Value="2015">2015</asp:ListItem>
										<asp:ListItem Value="2016">2016</asp:ListItem>
										<asp:ListItem Value="2017">2017</asp:ListItem>
										<asp:ListItem Value="2018">2018</asp:ListItem>
									</asp:dropdownlist></TD>
          <TD align=center colSpan=16><BUTTON class=FormButtonStyle id=Search style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 100px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1" accessKey=S onclick=check(); type=button runat="server"><IMG id=txtsearch height=7 src="../../HeaderFooter/images/search.gif" width=16><U>S</U>earch</BUTTON>
          &nbsp;<BUTTON class=FormButtonStyle id=Button1 style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1" accessKey=S onclick=check(); type=button runat="server">Print</BUTTON>
         &nbsp;<BUTTON class=FormButtonStyle id=BtnPrint style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1" accessKey=S onclick=check(); type=button runat="server">Excel</BUTTON> 
		 &nbsp;<asp:button id=BtnSave BorderColor="Black" Width=85 Height=21 Runat="server" CssClass="FormButtonStyle" CausesValidation="False"  Text="Save"></asp:button></TD></TR>
							<%
							
					//if(Convert.ToInt32(hidden1.Value)==1)
					//MessageBox.Show("hidden1.:"+Request.Params.Get("hidden1"));
					if(Request.Params.Get("hidden1")!=null&&Request.Params.Get("hidden1")!="")
					if(Convert.ToInt32(Request.Params.Get("hidden1"))==1)
					   {	
					     try
			                {
							%>
							<asp:panel id=Panlsal1 Runat="server" 
        Visible="false">
        <TR bgColor=#663300>
          <TD><B><FONT color=#ffffff>SNo</FONT></B></TD>
          <TD><B><FONT color=#ffffff>Employee_Name</FONT></B></TD>
          <TD><B><FONT color=#ffffff>Desi</FONT></B></TD>
          <TD><B><FONT color=#ffffff>D.O.J</FONT></B></TD>
          <TD><B><FONT color=#ffffff>Bas_Salary</FONT></B></TD>
          <TD><B><FONT color=#ffffff>DA</FONT></B></TD>
          <TD><B><FONT color=#ffffff>HRA</FONT></B></TD>
          <TD><B><FONT color=#ffffff>TA</FONT></B></TD>
          <TD><B><FONT color=#ffffff>CCA</FONT></B></TD>
          <TD><B><FONT color=#ffffff>Arrear</FONT></B></TD>
          <TD><B><FONT color=#ffffff>Sp.Al.</FONT></B></TD>
          <TD><B><FONT color=#ffffff>Gross_Salary</FONT></B></TD>
          <TD><B><FONT color=#ffffff>EPF</FONT></B></TD>
          <TD><B><FONT color=#ffffff>Loan</FONT></B></TD>
          <TD><B><FONT color=#ffffff>Penal</FONT></B></TD>
          <TD><B><FONT color=#ffffff>P.Tax</FONT></B></TD>
          <TD><B><FONT color=#ffffff>Benefits</FONT></B></TD>
          <TD><B><FONT color=#ffffff>Security</FONT></B></TD>
          <TD><B><FONT color=#ffffff>T.Dedu.</FONT></B></TD>
          <TD><B><FONT color=#ffffff>Incre</FONT></B></TD>
          <TD><B><FONT color=#ffffff>Net_Salary</FONT></B></TD></TR><%		
								   
								int day=DateTime.DaysInMonth(int.Parse(Dropyear.SelectedItem.Text),Dropmonth.SelectedIndex);
								string fromdate=Dropmonth.SelectedIndex+"/1/"+Dropyear.SelectedItem.Text;
								string todate=Dropmonth.SelectedIndex+"/"+day+"/"+Dropyear.SelectedItem.Text;
				         			   
								double Lwp=0,Da_Rs=0,Tot_Atta=0,Gros_Sal=0,Tot_Dedu=0,Net_Sal=0,epf_Amo=0,Bas_sal=0,Basic_sal=0,Da=0,Ta=0,Hra=0,Arears=0,Cca=0,Spe_All=0,Incre=0,Allow=0,deduc=0,Epf=0,Panl=0,Loan=0,P_tex=0,Benefit=0,Security=0;
								int i=1,j=0;
                    
                				SqlConnection con3;
								SqlCommand cmdInsert1;
								string strInsert="",strInsert1="";
								SqlDataReader dr1=null,dr=null;
								con3=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
								con3.Open ();
								//strInsert1="select sum(attandance_status)  from staff_attandance where (attandance_status=0.5 or attandance_status=1) and staff_id='1'";
								strInsert1="select staff_id,sum(attandance_status)  from staff_attandance where (attandance_status=0.5 or attandance_status=1)  and datename(month,attendance_date)='"+Dropmonth.SelectedItem.Text+"' and datename(year,attendance_date)='"+Dropyear.SelectedItem.Text+"' group by staff_id";
								cmdInsert1=new SqlCommand (strInsert1,con3);
								dr1=cmdInsert1.ExecuteReader();
								while(dr1.Read())
									{
										Tot_Atta=Convert.ToDouble(dr1.GetValue(1));
					        	        InventoryClass obj=new InventoryClass();
										SqlDataReader SqlDtr=null;
										strInsert="Select Days from staff_leave where staff_id="+dr1.GetValue(0)+" and  Leave_Type='LWP' and cast(floor(cast(cast(Staff_leavefromdt as datetime) as float)) as datetime)>='"+fromdate+"' and cast(floor(cast(cast( Staff_leavefromto as datetime) as float)) as datetime)<='"+todate+"'";
										//strInsert ="Select adjustment staff_id="+dr1.GetValue(0)+"  and cast(floor(cast(cast(Allow.fromdt as datetime) as float)) as datetime)<='"+fromdate+"' and cast(floor(cast(cast(Allow.todt as datetime) as float)) as datetime)>='"+todate+"'";
										SqlDtr=obj.GetRecordSet(strInsert);
										if(SqlDtr.Read())
											{    
												if(SqlDtr["Days"]!="" && SqlDtr["Days"]!=null)
													{
														Lwp=Convert.ToDouble(SqlDtr["Days"]);
													}
												else
													{
														Lwp=0;
													}
													//MessageBox.Show(Lwp.ToString());
													//return;
											}
										else
											{
												Lwp=0;
										    }
							            SqlDtr.Close();
                                        //strInsert ="select si.Staff_ID, si.Staff_Name, si.doj,si.Staff_Type,Allow.basic_Salary,Allow.arrears,Allow.allowances_Medical,Allow.allowances_hra,Allow.allowances_ta,Allow.allowances_da,Allow.allowances_cca,Allow.allowances_benefits,Allow.Deduction_pf,Allow.Deduction_tax,Allow.Deduction_other,Allow.pendedu,Allow.lwp,Allow.security,Allow.Increment,Allow.G_total,Allow.fromdt,Allow.todt,(Allow.basic_Salary+Allow.allowances_hra+Allow.allowances_ta+Allow.allowances_da+Allow.allowances_cca+Allow.allowances_benefits+Allow.Increment) total from staff_information si ,allowancesdeduction Allow where si.staff_id=Allow.staff_id and cast(floor(cast(cast(Allow.fromdt as datetime) as float)) as datetime)<='"+fromdate+"' and cast(floor(cast(cast(Allow.todt as datetime) as float)) as datetime)>='"+todate+"'";
							            strInsert ="select si.Staff_ID, si.Staff_Name, si.doj,si.Staff_Type,Allow.basic_Salary,Allow.allowances_benefits,Allow.arrears,Allow.allowances_Medical,Allow.allowances_hra,Allow.allowances_ta,Allow.allowances_da,Allow.allowances_cca,Allow.Deduction_pf,Allow.Deduction_tax,Allow.Deduction_other,Allow.pendedu,Allow.lwp,Allow.security,Allow.Increment,Allow.G_total,Allow.fromdt,Allow.todt,(Allow.basic_Salary+Allow.allowances_hra+Allow.allowances_ta+Allow.allowances_da+Allow.allowances_cca) total from staff_information si ,allowancesdeduction Allow where si.staff_id=Allow.staff_id and si.staff_id="+dr1.GetValue(0)+"  and cast(floor(cast(cast(Allow.fromdt as datetime) as float)) as datetime)<='"+fromdate+"' and cast(floor(cast(cast(Allow.todt as datetime) as float)) as datetime)>='"+todate+"'";
                                        SqlDtr=obj.GetRecordSet(strInsert);
							            while(SqlDtr.Read())
					                        {
					                             Basic_sal=Convert.ToDouble(SqlDtr["basic_Salary"]);
						                         Bas_sal=Convert.ToDouble(SqlDtr["basic_Salary"]);
						                         if(Lwp>0)
						                          {
													  Tot_Atta=Tot_Atta-Lwp;
						                          }
												  Bas_sal=(Bas_sal*Tot_Atta)/day;
												  Da=Convert.ToDouble(SqlDtr["allowances_da"]);
												  Da_Rs=( Bas_sal*Da)/100;
												  Ta=Convert.ToDouble(SqlDtr["allowances_ta"]);
												  Hra=Convert.ToDouble(SqlDtr["allowances_hra"]);
												  Arears=Convert.ToDouble(SqlDtr["arrears"]);
												  Cca=Convert.ToDouble(SqlDtr["allowances_cca"]);
												Spe_All=Convert.ToDouble(SqlDtr["allowances_Medical"]);
												Incre=Convert.ToDouble(SqlDtr["Increment"]);
												Epf=Convert.ToDouble(SqlDtr["Deduction_pf"]);
												Panl=Convert.ToDouble(SqlDtr["pendedu"]);
												Loan=Convert.ToDouble(SqlDtr["Deduction_other"]);
												P_tex=Convert.ToDouble(SqlDtr["Deduction_tax"]);
												Benefit=Convert.ToDouble(SqlDtr["allowances_benefits"]);
												Security=Convert.ToDouble(SqlDtr["security"]);
												Gros_Sal=Bas_sal+Da_Rs;
												if(Basic_sal>=6500)
												{
													epf_Amo=(Gros_Sal*Epf)/100;
												}
												else
												{
													epf_Amo=0;
												}
												Gros_Sal=Gros_Sal+Ta+Hra+Cca+Spe_All+Arears;
												// 22.09.08 Tot_Dedu=epf_Amo+Panl+Loan+P_tex+Benefit;
												Tot_Dedu=epf_Amo+Panl+Loan+P_tex+Benefit+Security;
												Net_Sal=(Gros_Sal+Incre)-Tot_Dedu;
						
									            %>
        <TR>
          <TD align=center><%=i.ToString()%></TD>
          <TD align=left><%=SqlDtr["Staff_Name"].ToString()%></TD>
          <TD align=left><%=SqlDtr["Staff_Type"].ToString()%></TD>
          <TD align=right><%=GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["doj"].ToString()))%></TD>
          <TD align=right><%=Math.Round(Bas_sal).ToString()%></TD>
          <TD align=right><%=Math.Round(Da_Rs).ToString()%></TD>
          <TD align=right><%=Hra.ToString()%></TD>
          <TD align=right><%=Ta.ToString()%></TD>
          <TD align=right><%=Cca.ToString()%></TD>
          <TD align=right><%=Arears.ToString()%></TD>
          <TD align=right><%=Spe_All.ToString()%></TD>
          <TD align=right><%=Math.Round(Gros_Sal).ToString()%></TD>
          <TD align=right><%=Math.Round(epf_Amo).ToString()%></TD>
          <TD align=right><%=Loan.ToString()%></TD>
          <TD align=right><%=Panl.ToString()%></TD>
          <TD align=right><%=P_tex.ToString()%></TD>
          <TD align=right><%=Benefit.ToString()%></TD>
          <TD align=right><%=Security.ToString()%></TD>
          <TD align=right><%=Math.Round(Tot_Dedu).ToString()%></TD>
          <TD align=right><%=Incre.ToString()%></TD>
          <TD align=right><%=Math.Round(Net_Sal).ToString()%></TD></TR><%
						    						i++;
											}
											SqlDtr.Close();
										}
										dr1.Close();
										con3.Close();
										%>
        <TR bgColor=#663300>
          <TD align=center colSpan=4><B><FONT color=#ffffff>Grand 
            Total</FONT></B></TD>
          <TD align=right><B><FONT color=#ffffff><%=Math.Round(gBas_sal).ToString()%></FONT></B></TD>
          <TD align=right><B><FONT color=#ffffff><%=Math.Round(gDa_Rs).ToString()%></FONT></B></TD>
          <TD align=right><B><FONT 
            color=#ffffff><%=gHra.ToString()%></FONT></B></TD>
          <TD align=right><B><FONT 
          color=#ffffff><%=gTa.ToString()%></FONT></B></TD>
          <TD align=right><B><FONT 
            color=#ffffff><%=gCca.ToString()%></FONT></B></TD>
          <TD align=right><B><FONT 
            color=#ffffff><%=gArears.ToString()%></FONT></B></TD>
          <TD align=right><B><FONT 
            color=#ffffff><%=gSpe_All.ToString()%></FONT></B></TD>
          <TD align=right><B><FONT color=#ffffff><%=Math.Round(gGros_Sal).ToString()%></FONT></B></TD>
          <TD align=right><B><FONT color=#ffffff><%=Math.Round(gEpf).ToString()%></FONT></B></TD>
          <TD align=right><B><FONT 
            color=#ffffff><%=gLoan.ToString()%></FONT></B></TD>
          <TD align=right><B><FONT 
            color=#ffffff><%=gPanl.ToString()%></FONT></B></TD>
          <TD align=right><B><FONT 
            color=#ffffff><%=gP_tex.ToString()%></FONT></B></TD>
          <TD align=right><B><FONT 
            color=#ffffff><%=gBenefit.ToString()%></FONT></B></TD>
          <TD align=right><B><FONT 
            color=#ffffff><%=gSecurity.ToString()%></FONT></B></TD>
          <TD align=right><B><FONT color=#ffffff><%=Math.Round(gTot_Dedu).ToString()%></FONT></B></TD>
          <TD align=right><B><FONT 
            color=#ffffff><%=gIncre.ToString()%></FONT></B></TD>
          <TD align=right><B><FONT color=#ffffff><%=Math.Round(gNet_Sal).ToString()%></FONT></B></TD></TR></asp:panel>
							<%		
								
					           CreateLogFiles.ErrorLog(" Form : Complitesalarydata.aspx,Method  Search_ServerClick, Complite Salary Report Viewed , Userid :  "+ Session["password"]   );		
					        }	
				            catch(Exception ex)
			                {
				               CreateLogFiles.ErrorLog(" Form : CompleteSalary_Report.aspx,Method  Search_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ Session["password"]  );		
				 
			                }
			                   
			              }
			              else if(Convert.ToInt32(Request.Params.Get("hidden1"))==2)
				             {
				               %>
							<asp:panel id=panlsal2 Runat="server" 
        Visible="False">
        <TR align=center bgColor=#663300>
          <TD align=center colSpan=4><B><FONT color=#ffffff>Name</FONT></B></TD>
          <TD align=center colSpan=3><B><FONT color=#ffffff>Basic Salary</FONT></B></TD>
          <TD align=center colSpan=3><B><FONT color=#ffffff>&nbsp;&nbsp;&nbsp;&nbsp;DA&nbsp;&nbsp;&nbsp;&nbsp;</FONT></B></TD>
          <TD align=center colSpan=3><B><FONT color=#ffffff>&nbsp;&nbsp;&nbsp;&nbsp;TA&nbsp;&nbsp;&nbsp;&nbsp;</FONT></B></TD>
          <TD align=center colSpan=3><B><FONT color=#ffffff>&nbsp;&nbsp;&nbsp;&nbsp;EPF&nbsp;&nbsp;&nbsp;&nbsp;</FONT></B></TD>
          <TD align=center colSpan=3><B><FONT color=#ffffff>Gross Salary</FONT></B></TD></TR><%
                  
                          try 
                           {
                            SqlConnection con4;
					        SqlCommand cmdInsert2;
					        SqlDataReader dr2=null;
					        con4=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					        con4.Open ();
					        
					        string strInsert2="";
					        //MessageBox.Show("Request2"+Request.Params.Get("hidden2"));
							if(Request.Params.Get("hidden2")!=null&&Request.Params.Get("hidden2")!=""&&Request.Params.Get("hidden2")!="ALL")
							{
									//strInsert2="Select * from Staff_Salary where Emp_ID="+Request.Params.Get("hidden2")+" and dateof like '%"+Dropyear.SelectedItem.Text+"'";
									  strInsert2="Select si.staff_name,ss.emp_id,ss.Bas_sal,ss.da,ss.ta,ss.epf,ss.net_sal from Staff_Salary ss,staff_information si where si.staff_id=ss.emp_id and Emp_ID="+Request.Params.Get("hidden2")+" and dateof like '%"+Dropyear.SelectedItem.Text+"'";
							}
							else
							{
								    //strInsert2="Select * from Staff_Salary where dateof like '%"+Dropyear.SelectedItem.Text+"'";
								    strInsert2="Select si.staff_name,ss.emp_id,ss.Bas_sal,ss.da,ss.ta,ss.epf,ss.net_sal from Staff_Salary ss,staff_information si where  si.staff_id=ss.emp_id and dateof like '%"+Dropyear.SelectedItem.Text+"'";
							}
						    string s="";
			    		    cmdInsert2=new SqlCommand (strInsert2,con4);
				    	    dr2=cmdInsert2.ExecuteReader();
					        while(dr2.Read())
					           {
					                    %> <tr><%
					                     if(s=="")
					                     { 
					                        %>
											
												<TD align=left colSpan=4 >&nbsp;<%=dr2["Staff_name"].ToString()%></TD><%   s=dr2["Staff_name"].ToString();
										 }
										 else if(s==dr2["Staff_name"].ToString())
										 {
												%>
												
											    <TD align=center colSpan=4>""</TD><%
										 }
										 else
										 {
												 %>
												<TD align=left colSpan=4>&nbsp;<%=dr2["Staff_name"].ToString()%></TD><% s=dr2["Staff_name"].ToString();
		   				                 }
										%>
										<TD align=right colSpan=3><%=Math.Round(Convert.ToDouble(dr2["Bas_Sal"])).ToString()%></TD>
										<TD align=right colSpan=3><%=Math.Round(Convert.ToDouble(dr2["DA"])).ToString()%></TD>
										<TD align=right colSpan=3><%=Math.Round(Convert.ToDouble(dr2["TA"])).ToString()%></TD>
										<TD align=right colSpan=3><%=Math.Round(Convert.ToDouble(dr2["EPF"])).ToString()%></TD>
										<TD align=right colSpan=3><%=Math.Round(Convert.ToDouble(dr2["Net_Sal"])).ToString()%></TD></TR><%
								}
					           %>
								<TR align=center bgColor=#663300>
									    <TD align=center colSpan=4><B><FONT color=#ffffff>Grand Total</FONT></B></TD>
										<TD align=right colSpan=3><B><FONT color=#ffffff><%=Math.Round(pBas_Salary).ToString()%></FONT></B></TD>
										<TD align=right colSpan=3><B><FONT color=#ffffff><%=Math.Round(pDA).ToString()%></FONT></B></TD>
										<TD align=right colSpan=3><B><FONT color=#ffffff><%=Math.Round(pTA).ToString()%></FONT></B></TD>
										<TD align=right colSpan=3><B><FONT color=#ffffff><%=Math.Round(pEPF).ToString()%></FONT></B></TD>
										<TD align=right colSpan=3><B><FONT color=#ffffff><%=Math.Round(pNet_Salary).ToString()%></FONT></B></TD></TR><%
					          
			              }
			              catch(Exception ex)
			              {
				             CreateLogFiles.ErrorLog(" Form : CompleteSalary_Report.aspx,Method  Search_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ Session["password"]   );		
				          }
				         %></asp:panel>
							<%
			         }
			         else
			         {
						return;
			         }
			       %>
						</TABLE></TD></TR>
  <tr>
    <td colSpan=3><asp:validationsummary id=vsStaffSalary runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD></TR></TABLE>
		<!--PopCalendar(tag name and id must match) Tags should sit at the page bottom --><iframe 
id=gToday:contrast:agenda.js 
style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px" 
name=gToday:contrast:agenda.js src="../../HeaderFooter/shareables/Style/ipopeng.htm" 
frameBorder=0 width=174 scrolling=no height=189>
		</IFRAME><uc1:footer id=Footer1 runat="server"></uc1:footer></FORM>
	</body>
</HTML>
