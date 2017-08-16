<%@ Page language="c#" Codebehind="StudentRegStatus.aspx.cs" AutoEventWireup="false" Inherits="eschool.Form.StudentRegStatus" %>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="DBOperations"%>
<%@ Import namespace="eschool.Classes"%>
<%@ Import namespace="RMG"%>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>

	<HEAD>
		<title>eSchool : Student Registration Status</title>
<script language=javascript>
	//this method use to clear the admission status.
	function CheckClear(t,t1)
	{
		if(t.checked)
			t1.value="Cleared"
		else
			t1.value="Pending"
	}
	
	//this method use to Peding the admission status.
	function CheckPending(t,t1)
	{
		if(t.checked)
			t1.value="Pending"
		else
			t1.value="Pending"
	}
	
	//this method use to Cancel the admission status.
	function CheckCancel(t,t1)
	{
		if(t.checked)
			t1.value="Cancel"
		else
			t1.value="Pending"
	}
</script>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<LINK rel="stylesheet" type="text/css" href="../../HeaderFooter/shareables/Style/Styles.css">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
		<uc1:Header id="Header1" runat="server"></uc1:Header>
			<% 
				DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"],true);
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr,rdr=null;
				string sql;
				int Prod_No=0,Group=1;
				sql="select Student_ID,Student_FName,Student_Class from Student_Registration where admission_Status='Pending' order by Student_FName";
				SqlDtr=obj.GetRecordSet(sql);
				//while(SqlDtr.Read())
				//{
					//dbobj.SelectQuery("select top 1 Pur_Rate, Sal_Rate from Price_Updation where Prod_ID=(select Prod_ID from Products where Prod_Name='"+ SqlDtr.GetValue(1).ToString() +"' and Category='"+ SqlDtr.GetValue(0).ToString() +"' and Pack_Type='"+SqlDtr.GetValue(2).ToString()+"') order by Eff_Date desc",ref rdr);
			%>
			<table width="778" height="250" align="center">
				
				<tr>
					<td height="180" align="center"><b>STUDENT REGISTRATION STATUS</b>
						<table align="center" borderColorLight="#663300" border="5">
							<tr bgcolor=#663300>
								<td rowspan=2 valign=middle><b><font color=#ffffff>Registration ID</font></b>
									</td>
								<td rowspan=2  align=center valign=bottom><b><font color=#ffffff>Student Name</font></b>
									</td>
								<td rowspan=2  align=center valign=bottom><b><font color=#ffffff>Class</font></b>
									</td>
								<td colspan=3 align=center><b><font color=#ffffff>Status</font></b></td>
								<tr bgcolor=#663300>
								<td align=center><b><font color=#ffffff>Cleared</font></b></td>
								<td align=center><b><font color=#ffffff>Pending</font></b></td>
								<td align=center><b><font color=#ffffff>Cancel</font></b></td>
								</tr>
							</tr>
							<% while(SqlDtr.Read())
								   {
								%>
							<tr>
								<!--td>Define Item Style</td-->
								<td align=center><%=SqlDtr.GetValue(0).ToString()%><input type=hidden id=RegID<%=Prod_No%> value="<%=SqlDtr.GetValue(0).ToString()%>" name=RegID<%=Prod_No%>></td>
								<td width=150><%=SqlDtr.GetValue(1).ToString()%></td>
								<td align=center><%=SqlDtr.GetValue(2).ToString()%></td>
								<td align=center><input type=hidden name=lblclear<%=Prod_No%>><input type=radio id=rbtnclear<%=Prod_No%> name=rbtn<%=Prod_No%> onblur="CheckClear(this,document.Form1.lblclear<%=Prod_No%>)"></td>
								<td align=center><input type=hidden name=lblpending<%=Prod_No%>><input type=radio id=rbtnpending<%=Prod_No%> name=rbtn<%=Prod_No%> checked=true onblur="CheckPending(this,document.Form1.lblpending<%=Prod_No%>)"></td>
								<td align=center><input type=hidden name=lblcancel<%=Prod_No%>><input type=radio id=rbtncancel<%=Prod_No%> name=rbtn<%=Prod_No%> onblur="CheckCancel(this,document.Form1.lblcancel<%=Prod_No%>)"></td>
								
							</tr>
							<%Prod_No++;
							}
							SqlDtr.Close();
							%>
							<tr>
							<td><input type=hidden name=Total_Prod value=<%=Prod_No%>></td>
							</tr>
							<tr>
							<td colspan=6 align=center><asp:Button ID=btnSubmit Runat=server Text="Submit" Width=70 CssClass=formbuttonstyle OnClick="update"></asp:Button></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<uc1:Footer id="Footer1" runat="server"></uc1:Footer>
		</form>
	</body>
</HTML>
<script language=C# runat =server >
/// <Summary>
/// This method use to update the admission status in to Student_Registration table.this method use UpdateRegStatus() function.
/// </Summary>
public void update(Object sender, EventArgs e )
		{  
		 try
		 {
			SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			InventoryClass obj=new InventoryClass(); 
			SqlDataReader SqlDtr;
			SqlCommand SqlCmd;
			int Total_Product=0;
			string prod_cat="",sql;
			int flag = 0;
			 int x=0;
			SqlCon.Open();
			Total_Product=System.Convert.ToInt32(Request.Params.Get("Total_Prod"));
			
			for(int i=0;i<Total_Product;i++)
			{ 
				//if(Request.Params.Get("rbtnclear"+i)!=null)
				//{ 
					//obj.Eff_Date=DateTime.Now.Date.ToShortDateString();
					//obj.Product_Name=Request.Params.Get("lblProd_Name"+i); 
					//obj.Package_Type=Request.Params.Get("lblPack_Type"+i); 
					//prod_cat = Request.Params.Get("lblCat"+i);
					//obj.Pur_Rate=Request.Params.Get("txtPurRate"+i); 
					//obj.Sal_Rate=Request.Params.Get("txtSaleRate"+i); 
					//obj.InsertPriceUpdation(); 		
					//Request.Params.Get("rbtnclear"+i);
					
					if(Request.Params.Get("lblclear"+i)=="Cleared")
						obj.Status="Cleared";
					else if(Request.Params.Get("lblpending"+i)=="Pending")
						obj.Status="Pending";
					else if(Request.Params.Get("lblcancel"+i)=="Cancel")
						obj.Status="Cancel";
					else
						obj.Status="Pending";
					//if(Request.Params.Get("rbtncancel"+i)!=null)
					//	obj.Status="Cancel";
					//else
					//	obj.Status="Pending";
					obj.RegID=Request.Params.Get("RegID"+i);
					obj.UpdateRegStatus();
					//CreateLogFiles.ErrorLog("Form:StudentRegStatus.aspx,Method:update().   Student Registration Updated " +Request.Params.Get("lblProd_Name"+i)+" User_ID: "+Session["User_Name"].ToString());
			
			
				//}
			}
			MessageBox.Show("Student Registration Status Updated");
			//sql="delete from student_registration where admission_status='Cancel'";
			//SqlCmd=new SqlCommand (sql,SqlCon);
			//SqlCmd.ExecuteNonQuery();
			SqlCon.Close();
		 }
		 catch(Exception ex)
		 {
		   MessageBox.Show(ex.Message);
		   CreateLogFiles.ErrorLog("Form:StudentRegStatus.aspx,Method:update().   EXCEPTION " +ex.Message +"  User_ID : "+ Session["User_Name"].ToString());
		 }
			
		}
</script>
