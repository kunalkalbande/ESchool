<!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->

<%@ Page CodeBehind="Addtadance_Register.aspx.cs" Language="c#" AutoEventWireup="false" Inherits="eschool.Modules.Form.Addtadance_Register" %>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="eschool.Classes"%>
<%@ Import namespace="DBOperations"%>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Import namespace="RMG"%>
<HTML>
	<HEAD>
	<script language=JavaScript>
	//This Method use to save dropdown value in Hidden textbox .
	<%int t=0;%>
	    function Check(t,temp)
        {
	        var index=t.selectedIndex;
	        var tempvalue=t.options[index].text;
	        temp.value=tempvalue;
	        
        }
        
     </script>
		<title>eSchool : Employee_Attandance</title>
		
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href=../../HeaderFooter/shareables/Style/Styles.css type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
	
		<form name="f1" id="f1" method="post" runat=server>
		
		<uc1:Header id="Header1" runat="server"></uc1:Header>
			<table width=778 height=250 align=center>
				
				<tr>
					<td align=center><b>EMPLOYEE ATTENDANCE</b>
						<TABLE id="tablepassword" borderColorLight="#663300" border="5" align="center">
							<asp:Panel Runat=server ID=panEmp >
							<tr>
							<td colspan=4>Attendance Date &nbsp;&nbsp;<asp:DropDownList Runat=server ID="DropEmp" Width=90 AutoPostBack=True><asp:ListItem Value="Select">Select</asp:ListItem></asp:DropDownList>
							<asp:CompareValidator ID=cv1 Runat=server ControlToValidate="DropEmp" ErrorMessage="Please Select The Date" ValueToCompare="Select" Operator=NotEqual>*</asp:CompareValidator>
							</td>
							</tr>
							</asp:Panel>
							
							<tr height=20>
								<td width=60 align="center" bgcolor="#663300"><font color=#ffffff><b>Emp ID</b></font></td>
								<td width=200 align="center" bgcolor="#663300"><font color=#ffffff><b>Name</b></font></td>
								<td width=150 align="center" bgcolor="#663300"><font color=#ffffff><b>Designation</b></font></td>
								<td width=50 align="center" bgcolor="#663300"><font color=#ffffff><b>Status</b></font></td>
							</tr>
							<%
							    EmployeeClass obj=new EmployeeClass(); 
								SqlDataReader SqlDtr;
								string sql;
							 	Row_No=0;
								int i=0;
								 string str1;
								 str1=obj.date();
																 
							if(panEmp.Visible==false)
							{
							//try{
								  sql="select staff_information.staff_id,staff_information.staff_name,staff_information.staff_type from staff_information where Staff_ID!=all(select distinct Staff_Attandance.Staff_id from Staff_Attandance where attendance_Date ='"+GenUtil.str2MMDDYYYY(str1)+"') and Staff_id!=all (select  staff_id from staff_leave where  getdate() between Staff_leavefromdt and DATEADD(day, 1, Staff_leavefromto) and  adjustment=1)"; 
								 SqlDtr=obj.GetRecordSet(sql);
								
								 while(SqlDtr.Read())
								 {
							%>
							<tr>
								<td>&nbsp;<%=SqlDtr.GetValue(0).ToString()%><input type=hidden name=lblEmpID<%=Row_No%> value="<%=SqlDtr.GetValue(0).ToString()%>"></td>
								<td>&nbsp;<%=SqlDtr.GetValue(1).ToString()%><input type=hidden name=lblEmpName<%=Row_No%> value="<%=SqlDtr.GetValue(1).ToString()%>"></td>
								<td>&nbsp;<%=SqlDtr.GetValue(2).ToString()%><input type=hidden name=lblDesig<%=Row_No%> value="<%=SqlDtr.GetValue(2).ToString()%>"></td>
								<td><select type=select-one onchange="Check(this,document.f1.Txt_Row<%=Row_No%>)" name=chk<%=Row_No%>><option value="Yes">Yes</option>
								<option value="No">No</option>
								<option value="Ist Half">Ist Half</option>
								<option value="IInd Half">IInd Half</option>
								<option value="HoliDay">HoliDay</option></select>
								<input type=hidden name=Txt_Row<%=Row_No%> value="Yes"></td>
							</tr>
							<%	Row_No++;
								}
								SqlDtr.Close();
							//}
							//catch(Exception ex)
							//{
							//CreateLogFiles.ErrorLog("Form:Attendance_Register.aspx.cs,Method:page_load() EXCEPTION: "+ ex.Message+" userid :"+ Session["User_Name"].ToString());
							//}
							%>
							
							<input type=hidden name=lblTotal_Row value=<%=Row_No%>>
							<%
							//MessageBox.Show("Testdd:"+Request.Params.Get("lblTotal_Row"));
							//MessageBox.Show("Test:"+Row_No);
							}
							else if(DropEmp.SelectedIndex!=0)
							{
									//string str="Select a.Emp_ID,e.Emp_Name,e.Designation,a.Status from Attandance_Register a,Employee e where Att_date='"+DropEmp.SelectedItem.Text+"' and a.Emp_ID=e.Emp_ID";
									string str="Select a.staff_id,e.staff_name,e.Staff_type,a.attandance_Status,a.half_day from staff_Attandance a,Staff_information e where Attendance_date='"+GenUtil.str2MMDDYYYY(DropEmp.SelectedItem.Text)+"' and a.staff_ID=e.staff_ID";
									SqlDtr = obj.GetRecordSet(str);
									i=0;
									while(SqlDtr.Read())
										{
											%>
											<tr>
											<td>&nbsp;<%=SqlDtr["staff_ID"].ToString()%><input type=hidden name=lblEmpID<%=i%> value=<%=SqlDtr["staff_ID"].ToString()%>></td>
											<td>&nbsp;<%=SqlDtr["staff_Name"].ToString()%></td>
											<td>&nbsp;<%=SqlDtr["staff_type"].ToString()%></td>
											<%if(double.Parse(SqlDtr["attandance_Status"].ToString())==0 && double.Parse(SqlDtr["half_day"].ToString())==0)
												 {
												 %>
													<td align=center><select type=select-one onchange="Check(this,document.f1.Txt_Row<%=i%>)" name=chk<%=i%>>
													<option value="No">No</option>
													<option value="Yes">Yes</option>
													<option value="Ist Half">Ist Half</option>
													<option value="IInd Half">IInd Half</option>
													<option value="HoliDay">HoliDay</option>
													<input type=hidden name=Txt_Row<%=i%> value="No"></select>
													</td>
												<%
												}
												else if(double.Parse(SqlDtr["attandance_Status"].ToString())==0.5 && double.Parse(SqlDtr["half_day"].ToString())==1)
												{
												 %>
													<td align=center><select type=select-one onchange="Check(this,document.f1.Txt_Row<%=i%>)" name=chk<%=i%>>
													<option value="Ist Half">Ist Half</option>
													<option value="No">No</option>
													<option value="Yes">Yes</option>
													<option value="IInd Half">IInd Half</option>
													<option value="HoliDay">HoliDay</option>
													<input  type=hidden name=Txt_Row<%=i%> value="Ist Half"></select>
													</td>
												<%
												}
												else if(double.Parse(SqlDtr["attandance_Status"].ToString())==0.5 && double.Parse(SqlDtr["half_day"].ToString())==2)
												{
												%>
													<td align=center><select type=select-one onchange="Check(this,document.f1.Txt_Row<%=i%>)" name=chk<%=i%>>
													<option value="IInd Half">IInd Half</option>
													<option value="No">No</option>
													<option value="Yes">Yes</option>
													<option value="Ist Half">Ist Half</option>
													<option value="HoliDay">HoliDay</option>
													<input  type=hidden name=Txt_Row<%=i%> value="IInd Half"></select>
													</td>
							                    <%
							                    }
												else if(double.Parse(SqlDtr["attandance_Status"].ToString())==1 && double.Parse(SqlDtr["half_day"].ToString())==3)
												{												
												%>
													<td align=center><select type=select-one onchange="Check(this,document.f1.Txt_Row<%=i%>)" name=chk<%=i%>>
													<option value="Yes">Yes</option>
													<option value="No">No</option>
													<option value="Ist Half">Ist Half</option>
													<option value="IInd Half">IInd Half</option>
													<option value="HoliDay">HoliDay</option>
													<input  type=hidden name=Txt_Row<%=i%> value="Yes"></select>
													</td>
												<%
												}
												else if(double.Parse(SqlDtr["attandance_Status"].ToString())==1 && double.Parse(SqlDtr["half_day"].ToString())==0)
												{
												%>
													<td align=center><select type=select-one onchange="Check(this,document.f1.Txt_Row<%=i%>)" name=chk<%=i%>>
													<option value="HoliDay">HoliDay</option>
													<option value="No">No</option>
													<option value="Yes">Yes</option>
													<option value="Ist Half">Ist Half</option>
													<option value="IInd Half">IInd Half</option>
													<input  type=hidden name=Txt_Row<%=i%> value="HoliDay"></select>
													</td>
													</tr>
												<%
												}
												i++;
											}
											%>
											<input type=hidden name=lblTotal_Row value=<%=i%>>
											<%
									}
								%>
							<tr><td colspan=3 bgcolor="#663300"><input type=hidden name=CountEdit value=<%=i%>></td><td  align=right bgcolor="#663300"><font color=#ffffff><b>&nbsp;&nbsp;HoliDay&nbsp;&nbsp;</b></font><input onclick="holiday(this);" type=checkbox>&nbsp;&nbsp;&nbsp;&nbsp;</td></tr>
							
							<TR>
					         <td align=center colspan=4><asp:Button ID=Btnsave Text=Submit Runat=server OnClick="attan" CssClass="formbuttonstyle"></asp:Button>&nbsp;&nbsp;&nbsp;<asp:Button ID="btnEdit" Text=Edit Runat=server OnClick="View" CssClass="formbuttonstyle"></asp:Button></td>
				            </TR>
						</table>
					</td>
				</tr>
				
				<tr><td><asp:ValidationSummary ID=vs1 Runat=server ShowMessageBox=True ShowSummary=False></asp:ValidationSummary></td></tr>
			</table><uc1:Footer id="Footer1" runat="server"></uc1:Footer>
		</form>
	</body>
</HTML>

<script language=C# runat=server >


    ///<Summary>
    /// this method used to save and Update the attendance of employee.
    ///</Summary>
    public void attan(Object sender, EventArgs e)
    {

        SqlConnection con1;
        con1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
        con1.Open ();
        string msg="";
        string strInsert1="";

        //if(panEmp.Visible==false)
        //	{
        int Total_Rows=System.Convert.ToInt32(Request.Params.Get("lblTotal_Row"));
        for(int i=0;i<Total_Rows;i++)
        {
            if(Request.Params.Get("Txt_Row"+i)!=null && Request.Params.Get("Txt_Row"+i)!="")
            {
                string st=Request.Params.Get("lblEmpID"+i);
                //string dt1=System.DateTime.Now.ToShortDateString();
                string dt1 = DateTime.Now.ToString("dd'/'MM'/'yyyy");
                
                SqlCommand cmdInsert1;
                try
                {
                    string strcheck1="select count(*) from Staff_Attandance where Staff_ID='"+st.ToString()+"' and Attendance_Date='"+GenUtil.str2MMDDYYYY(dt1)+"'";
                    //string strcheck1="select count(*) from Staff_Attandance where Staff_ID='"+st.ToString()+"' and Attendance_Date='"+DropEmp.SelectedItem.Text+"'";
                    SqlCommand cmdcheck1=new SqlCommand(strcheck1,con1);
                    SqlDataReader dtr=cmdcheck1.ExecuteReader();
                    int icount=0;
                    while(dtr.Read())
                    {
                        icount=Convert.ToInt32(dtr.GetValue(0));
                    }
                    dtr.Close();
                    if(icount>0)
                    {
                        strInsert1 ="update staff_attandance set Half_Day=@half_day, Attandance_Status=@Attandance_Status where Staff_ID=@Staff_ID and Attendance_Date='"+dt1+"'";
                        msg="Updated";
                    }
                    else
                    {
                        strInsert1 = "Insert Staff_Attandance(Staff_ID,Attandance_Status,Attendance_Date,Half_Day)values (@Staff_ID,@Attandance_Status,@Attendance_Date,@half_day)";
                        msg="Saved";
                    }
                    cmdInsert1=new SqlCommand (strInsert1,con1);
                    //if(Dropempid.SelectedIndex==0)
                    //cmdInsert1.Parameters .Add ("@Staff_ID","");
                    //else
                    cmdInsert1.Parameters .Add ("@Staff_ID",Request.Params.Get("lblEmpID"+i));
                    cmdInsert1.Parameters .Add ("@Attendance_Date",GenUtil.str2MMDDYYYY(dt1).ToString());
                    if(Request.Params.Get("Txt_Row"+i)=="Yes")
                    {
                        cmdInsert1.Parameters .Add ("@Attandance_Status","1");
                        cmdInsert1.Parameters .Add ("@half_day",Convert.ToInt16(3));
                    }
                    else if(Request.Params.Get("Txt_Row"+i) =="HoliDay")
                    {
                        cmdInsert1.Parameters .Add ("@Attandance_Status","1");
                        cmdInsert1.Parameters .Add ("@half_day",Convert.ToInt16(0));
                    }
                    else if(Request.Params.Get("Txt_Row"+i)=="No")
                    {
                        cmdInsert1.Parameters .Add ("@Attandance_Status","0");
                        cmdInsert1.Parameters .Add ("@half_day",Convert.ToInt16(0));
                    }
                    else if(Request.Params.Get("Txt_Row"+i)=="Ist Half")
                    {
                        cmdInsert1.Parameters .Add ("@Attandance_Status","0.5");
                        cmdInsert1.Parameters .Add ("@half_day",Convert.ToInt16(1));
                    }
                    else if(Request.Params.Get("Txt_Row"+i)=="IInd Half")
                    {
                        cmdInsert1.Parameters .Add ("@Attandance_Status","0.5");
                        cmdInsert1.Parameters .Add ("@half_day",Convert.ToInt16(2));
                    }
                    cmdInsert1.ExecuteNonQuery();
                    //CreateLogFiles.ErrorLog ("Form: Attendance.aspx.cs, Method: btnSave_Click. Attendance for the employee ID: " + Dropempid.SelectedItem.Text.ToString() + " is saved. User: " + pass );
                }
                catch(Exception ex)
                {
                    CreateLogFiles.ErrorLog ("Form: Attendance.aspx.cs, Method: btnSave_Click. Exception: " + ex.Message + " User: " + Session["password"] );
                }
            }
        }
        // }
        panEmp.Visible=false;
        DropEmp.SelectedIndex=0;
        MessageBox.Show("Attendance Successfully "+msg);
        con1.Close ();
    }

    /// <Summary>
    /// This Method use to view the save Attendance. this method fetch data from Staff_Attendance.
    /// <Summary>
    public void View(Object sender, EventArgs e)
    {
        try
        {
            panEmp.Visible=true;
            EmployeeClass obj=new EmployeeClass();
            SqlDataReader SqlDtr;
            string sql;
            sql="select distinct Attendance_Date from Staff_Attandance";
            SqlDtr=obj.GetRecordSet(sql);
            DropEmp.Items.Clear();
            DropEmp.Items.Add("Select");
            while(SqlDtr.Read())
            {
                // string b=SqlDtr["Attendance_Date"].ToString();
                // b=b.Substring(0,9);
                // string[] bb=b.Split(new char[] (""),b.Lenth);
                DropEmp.Items.Add(GenUtil.trimDate(SqlDtr["Attendance_Date"].ToString()));
                //DropEmp.Items.Add(b);
            }
            SqlDtr.Close();
        }
        catch(Exception ex)
        {
            CreateLogFiles.ErrorLog("Form:Attendance_Register.aspx.cs,Method:attan(). EXCEPTION: "+ ex.Message+" userid :"+ Session["password"]);
        }
    }

    /// <Summary>
    /// This method get date as a string and return MMDDYYYY format.
    /// </Summary>
    public DateTime ToMMddYYYY(string str)
    {
        int dd,mm,yy;
        string [] strarr = new string[3];
        strarr=str.Split(new char[]{'/'},str.Length);
        dd=Int32.Parse(strarr[0]);
        mm=Int32.Parse(strarr[1]);
        yy=Int32.Parse(strarr[2]);
        DateTime dt=new DateTime(yy,mm,dd);
        return(dt);
    }
</script>
<script language =javascript>
// This Method use to for holiday attendance. if we check holiday checkbox then all dropdown show value acording to holiday status.
 function holiday(t)
        {
             var Totemp=document.f1.lblTotal_Row.value;
            // alert("Test 21:"+Totemp)
            if(t.checked==true)
            {
             <%
             int j=0;      
             //MessageBox.Show("R"+Row_No);    
             for(j=0;j<Row_No;j++)
             {
             %>
				<%
				//MessageBox.Show("j:"+j);%>
                document.f1.chk<%=j%>.selectedIndex=4;
                document.f1.Txt_Row<%=j%>.value="HoliDay";
                // alert(Totemp)
             <%
             }
             %>
             }
             else
             {
			<%
              for(j=0;j<Row_No;j++)
             {
             %>
				<%
				//MessageBox.Show("j:"+j);%>
                document.f1.chk<%=j%>.selectedIndex=0;
                document.f1.Txt_Row<%=j%>.value="Yes";
                // alert(Totemp)
             <%
             }
             %>
             }

         }
   </script>