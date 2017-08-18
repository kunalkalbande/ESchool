/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
*/
# region Directives...
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data .SqlClient;
using System.IO;
using System.Drawing.Imaging ;
using RMG;
using System.Text;
using eschool.Classes ;
using System.Net.Sockets;
using System.Net;
# endregion

namespace eschool.StudentFees
{
	/// <summary>
	/// Summary description for PaySlip.
	/// </summary>
	public class PaySlip : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txthra;
		protected System.Web.UI.WebControls.TextBox txtpf;
		protected System.Web.UI.WebControls.TextBox txtta;
		protected System.Web.UI.WebControls.TextBox txttax;
		protected System.Web.UI.WebControls.TextBox txtda;
		protected System.Web.UI.WebControls.TextBox txtothertax;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.ValidationSummary svPaySlip;
		protected System.Web.UI.WebControls.DropDownList dropEmpName;
		protected System.Web.UI.WebControls.TextBox txtEmpID;
		protected System.Web.UI.WebControls.TextBox txtcca;
		protected System.Web.UI.WebControls.TextBox txtMedical;
		protected System.Web.UI.WebControls.TextBox txtbenefits;
		protected System.Web.UI.WebControls.TextBox txtAllowances;
		protected System.Web.UI.WebControls.TextBox txtincrement;
		protected System.Web.UI.WebControls.TextBox txtGross;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.TextBox txtdesig;
		protected System.Web.UI.WebControls.TextBox txtdoj;
		protected System.Web.UI.WebControls.TextBox txtBasic;
		protected System.Web.UI.WebControls.TextBox txtsec;
		protected System.Web.UI.WebControls.TextBox txtlwp;
		protected System.Web.UI.WebControls.TextBox txtpenDeduction;
		protected System.Web.UI.WebControls.TextBox txtDeduction;
		//protected System.Web.UI.WebControls.TextBox txtmedical;
		protected System.Web.UI.WebControls.TextBox txtperacno;
		protected System.Web.UI.WebControls.TextBox txtepfacno;
		protected System.Web.UI.WebControls.Button btnprint;
		protected System.Web.UI.WebControls.TextBox txtArrears;
		protected System.Web.UI.WebControls.TextBox txtNetSalary;
		string pass;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values and also fill some 
		/// additional information and also check accessing priviledges for perticular user.
		/// also Generated Next LedgerID.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				pass=(Session["password"].ToString());
				CreateLogFiles.ErrorLog (" Form : PaySlip.aspx.cs, Method: Page_load, User: " + pass );
			}
			catch(Exception ex)
			{
				//Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : PaySlip.aspx.cs, Method: Page_load, Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				//string pass;
				//pass=(Session["password"].ToString ());
				btnEdit.Visible=false;
				if(!Page.IsPostBack)
				{
					txtAllowances.Enabled=false;
					txtBasic.Enabled=false;
					txtbenefits.Enabled=false;
					txtcca.Enabled=false;
					txtda.Enabled=false;
					txtDeduction.Enabled=false;
					txtEmpID.Enabled=false;
					txtGross.Enabled=false;
					txthra.Enabled=false;
					txtincrement.Enabled=false;
					txtMedical.Enabled=false;
					txtNetSalary.Enabled=false;
					txtothertax.Enabled=false;
					txtpf.Enabled=false;
					txtta.Enabled=false;
					txttax.Enabled=false;
					# region Adding the staff_id to the dropdownbox.
					SqlConnection con;
					SqlCommand cmdselect;
					SqlDataReader dtrall;
					con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con.Open ();
					cmdselect = new SqlCommand( "Select Staff_id  From Staff_Information order by Staff_id", con );
					dtrall = cmdselect.ExecuteReader();
					while(dtrall.Read())
					{
						dropEmpName.Items.Add(dtrall.GetValue(0).ToString());
					}
					dtrall.Close();
					
					# endregion
				}
				if(!IsPostBack)
				{
                    txtdesig.Attributes.Add("readonly", "readonly");
                    txtdoj.Attributes.Add("readonly", "readonly");
                    txtperacno.Attributes.Add("readonly", "readonly");
                    txtepfacno.Attributes.Add("readonly", "readonly");
                    txtpenDeduction.Attributes.Add("readonly", "readonly");
                    txtsec.Attributes.Add("readonly", "readonly");
                    txtlwp.Attributes.Add("readonly", "readonly");

                    txtAllowances.Attributes.Add("readonly", "readonly");
                    txtGross.Attributes.Add("readonly", "readonly");
                    txtNetSalary.Attributes.Add("readonly", "readonly");

                    #region Check Privileges
                    int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="7";
					string SubModule="4";
					string[,] Priv=(string[,]) Session["Privileges"];
					for(i=0;i<Priv.GetLength(0);i++)
					{
						if(Priv[i,0]== Module &&  Priv[i,1]==SubModule)
						{						
							View_flag=Priv[i,2];
							Add_Flag=Priv[i,3];
							Edit_Flag=Priv[i,4];
							Del_Flag=Priv[i,5];
							break;
						}
					}	
					if(Add_Flag=="False"&&Edit_Flag=="False"&&Del_Flag=="False"&&View_flag=="False")
					{
						Response.Redirect("/eschool/AccessDeny.aspx",false);
					}
				
					#endregion
				}
				CreateLogFiles.ErrorLog(" Form : payslip.aspx,Method  Page_Load, Userid :  "+ pass   );	
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : payslip.aspx,Method  Page_Load,  Exception: "+ex.Message+" , Userid :  "+ pass   );	
				//Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				//return;
			}	
		}
		

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.dropEmpName.SelectedIndexChanged += new System.EventHandler(this.dropEmpName_SelectedIndexChanged);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		/// <summary>
		/// Method for getting the pay slip information to the controls on the forms for editing.
		/// </summary>
		private void dropEmpName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string aa=dropEmpName.SelectedItem.Value .ToString ();  
			clear ();
			dropEmpName.SelectedIndex =dropEmpName.Items.IndexOf (dropEmpName.Items .FindByValue (aa));  
			try
			{
				SqlConnection con3;
				SqlCommand cmdselect3;
				SqlDataReader dtredit3;
				con3=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con3.Open ();
				cmdselect3 = new SqlCommand( "Select a.Staff_name,b.Basic_salary,b.allowances_hra,b.allowances_ta,b.allowances_da,b.allowances_cca,b.allowances_medical,b.allowances_benefits,b.allowances_total,b.Deduction_pf,b.Deduction_tax,b.Deduction_other,b.Deduction_total,b.Increment,b.G_total,b.Net_Sal,b.fromdt,b.todt,a.Staff_Type,a.doj,a.per_acno,a.epf_acno,b.security,b.pendedu ,b.lwp,b.arrears From staff_information a, Allowancesdeduction b where a.Staff_id=b.staff_id and b.staff_id='" + aa + "'", con3 );
				cmdselect3.Parameters .Add ("@Staff_Name",dropEmpName.SelectedItem.Text.ToString ());
				dtredit3 = cmdselect3.ExecuteReader();
				if(dtredit3.HasRows )
				{
					while (dtredit3.Read())
					{
						txtEmpID.Text=dtredit3.GetValue(0).ToString();
						txtBasic.Text=dtredit3.GetValue(1).ToString();
						txtda.Text=dtredit3.GetValue (4).ToString();
						string cal=dtredit3.GetValue (9).ToString();
						double tot=0;
						if(txtda.Text!="" || txtBasic.Text!="")
							tot=((double.Parse(txtBasic.Text)+double.Parse(txtda.Text))*double.Parse(cal))/100;
						txtpf.Text=System.Convert.ToString(tot.ToString());
						txthra.Text=dtredit3.GetValue(2).ToString();
						txtta.Text=dtredit3.GetValue (3).ToString();
						txtcca.Text=dtredit3.GetValue (5).ToString();
						txtMedical.Text=dtredit3.GetValue (6).ToString();
						txtbenefits.Text=dtredit3.GetValue (7).ToString();
						txtAllowances.Text=dtredit3.GetValue (8).ToString();
						txtArrears.Text=dtredit3.GetValue (25).ToString();
						txttax.Text=dtredit3.GetValue (10).ToString();
						txtothertax.Text=dtredit3.GetValue (11).ToString();
						txtDeduction.Text=dtredit3.GetValue (12).ToString();
						txtincrement.Text=dtredit3.GetValue (13).ToString();
						txtGross.Text=dtredit3.GetValue (14).ToString();
						txtNetSalary.Text=dtredit3.GetValue(15).ToString();
						txtdesig .Text =dtredit3.GetValue (18).ToString ();
						txtdoj .Text =dtredit3.GetValue (19).ToString ();
						txtdoj.Text =GenUtil.str2DDMMYYYY(GenUtil.trimDate(dtredit3.GetValue (19).ToString ()));
						txtperacno .Text =dtredit3.GetValue (20).ToString ();
						txtepfacno.Text =dtredit3.GetValue (21).ToString ();
						txtpenDeduction .Text =dtredit3.GetValue (22).ToString ();	
						txtsec.Text =dtredit3.GetValue (23).ToString ();
						//30.03.09 txtlwp.Text =dtredit3.GetValue (24).ToString ();
						txtlwp.Text="0";
					}
				}
				else
				{
					MessageBox.Show ("First fill salary details in Personal-->Staff Salary");
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : payslip.aspx,Method  Dropdownlist1_SelectedIndexChanged,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}	
		}

		/// <summary>
		/// this method use to Clear form.
		/// </summary>
		public void clear()
		{
			txtdesig .Text ="";
			txtperacno.Text ="";
			txtepfacno.Text ="";
			txtpenDeduction.Text ="";
			txtsec.Text ="";
			txtlwp.Text ="";
			txtAllowances.Text="";
			txtDeduction.Text="";
			txtGross.Text="";
			txtBasic.Text="";
			txtEmpID.Text="";
			txtta.Text="";
			txtda.Text="";
			txtcca.Text="";
			txtbenefits.Text="";
			txtpf.Text="";
			txtArrears.Text="";
			txttax.Text="";
			txtothertax.Text="";
			txtincrement.Text="";
			txtNetSalary.Text="";
			txthra.Text="";
			txtMedical.Text="";
			dropEmpName.SelectedIndex=0;
		}

		/// <summary>
		/// this method use to Update the Record in to Allowancesdeduction table.
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(btnEdit.Text=="Edit")
				{
					if(dropEmpName.SelectedIndex==0)
					{
						MessageBox.Show("You must select the Employee ID");
					}
					enable ();
					btnEdit.Text="Update";
				}
				else if(btnEdit.Text=="Update")
				{
					if(dropEmpName.SelectedIndex==0)
					{
						MessageBox.Show("You must select the Employee ID");
					}
					else
					{
						int iBasic=Convert.ToInt32(txtBasic.Text.ToString().Trim());
						int iHra=Convert.ToInt32(txthra.Text.ToString().Trim());
						int iTa=Convert.ToInt32(txtta.Text.ToString().Trim());
						int iDa=Convert.ToInt32(txtda.Text.ToString().Trim());
						int iCca=Convert.ToInt32(txtcca.Text.ToString().Trim());
						int iMedical=Convert.ToInt32(txtMedical.Text.ToString().Trim());
						int iBenifits=Convert.ToInt32(txtbenefits.Text.ToString().Trim());
						int iIncrements=Convert.ToInt32(txtincrement.Text.ToString().Trim());
						int iPf=Convert.ToInt32(txtpf.Text.ToString().Trim());
						int iTax=Convert.ToInt32(txttax.Text.ToString().Trim());
						int iOtherTax=Convert.ToInt32(txtothertax.Text.ToString().Trim());
						int isec=Convert.ToInt32(txtsec.Text.Trim().ToString());
						int ipenDeduction=Convert.ToInt32(txtpenDeduction.Text.Trim().ToString());
						int ilwp=Convert.ToInt32(txtlwp.Text.Trim().ToString());
						int iAllowances=iHra+iTa+iDa+iCca+iMedical+iBenifits;
						int iGross=iBasic+iAllowances+iIncrements-ilwp;
						int iDeduction=iPf+iTax+iOtherTax+isec+ipenDeduction;
						int iNetSal=iGross-iDeduction;
						SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
						scon.Open();
						SqlCommand scom=new SqlCommand("Update Allowancesdeduction set Basic_salary="+iBasic+",allowances_hra="+iHra+",allowances_ta="+iTa+",allowances_da="+iDa+",allowances_cca="+iCca+",allowances_medical="+iMedical+",allowances_benefits="+iBenifits+",allowances_total="+iAllowances+",Deduction_pf="+iPf+",Deduction_tax="+iTax+",Deduction_other="+iOtherTax+",Deduction_total="+iDeduction+",Increment="+iIncrements+",G_total="+iGross+",Net_Sal="+iNetSal+",fromdt='',todt='' where Staff_id='"+ dropEmpName.SelectedItem.Value.ToString ()  +"'",scon); 
						scom.ExecuteNonQuery();
						MessageBox.Show("Salary successfully updated");
						CreateLogFiles.ErrorLog(" Form : payslip.aspx,Method  btnEdit_Click,   payslip updated for Staff_Name : " + txtEmpID.Text  + " , Userid :  "+ pass   );		
						clear();
						btnEdit.Text="Edit";
						disable ();
					}
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :payslip.aspx,Method  btnEdit_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}	
		}
		
		/// <summary>
		/// this method not in use.
		/// </summary>	
		private void enable()
		{
			txtBasic.Enabled=true;
			txtbenefits.Enabled=true;
			txtcca.Enabled=true;
			txtda.Enabled=true;
			txthra.Enabled=true;
			txtincrement.Enabled=true;
			txtMedical.Enabled=true;
			txtothertax.Enabled=true;
			txtpf.Enabled=true;
			txtta.Enabled=true;
			txttax.Enabled=true;
		}

		/// <summary>
		/// this method not in use.
		/// </summary>	
		private void disable()
		{
			txtBasic.Enabled=false;
			txtbenefits.Enabled=false;
			txtcca.Enabled=false;
			txtda.Enabled=false;
			txthra.Enabled=false;
			txtincrement.Enabled=false;
			txtMedical.Enabled=false;
			txtothertax.Enabled=false;
			txtpf.Enabled=false;
			txtta.Enabled=false;
			txttax.Enabled=false;
		}

		/// <summary>
		/// Method for sending the text file to the printer
		/// </summary>	
		public void Print()
		{
			byte[] bytes = new byte[1024];
			/// Connect to a remote device.
			try 
			{
				/// Establish the remote endpoint for the socket.
				/// The name of the
				/// remote device is "host.contoso.com".
				IPHostEntry ipHostInfo = Dns.Resolve("127.0.0.1");
				IPAddress ipAddress = ipHostInfo.AddressList[0];
				IPEndPoint remoteEP = new IPEndPoint(ipAddress,63000);
				/// Create a TCP/IP  socket.
				Socket sender1 = new Socket(AddressFamily.InterNetwork, 
					SocketType.Stream, ProtocolType.Tcp );
				/// Connect the socket to the remote endpoint. Catch any errors.
				try 
				{
					sender1.Connect(remoteEP);
					Console.WriteLine("Socket connected to {0}",
						sender1.RemoteEndPoint.ToString());
					/// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2);
					//byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\PaySlip.txt<EOF>");
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eschoolprintservice\PaySlip.txt<EOF>");
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog(" Form :PaySlip.aspx,Method  Print_Click, PaySlip Printed, Userid :  "+ pass);
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form :PaySlip.aspx,Method  Print_Click, Exception"+ ane.Message+",  PaySlip Printed, Userid :  "+ pass);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form :PaySlip.aspx,Method  Print_Click, Exception"+ se.Message+",  PaySlip Printed, Userid :  "+ pass);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form :PaySlip.aspx,Method  Print_Click, Exception"+ es.Message+",  PaySlip Printed, Userid :  "+ pass);
				}
			} 
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :PaySlip.aspx,Method  Print_Click,Esception:"+ex.Message +", PaySlip Printed, Userid :  "+ pass);
			}
		}

		/// <summary>
		/// this method use to print pay slip.
		/// </summary>
		private void btnprint_Click(object sender, System.EventArgs e)
		{
			try
			{
				string home_drive = Environment.SystemDirectory ;
				string info = "",info1="";
				home_drive = home_drive.Substring (0,2);
				string des="|--------------------------------------------------------------------------------|";
				//string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\PaySlip.txt";
				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eschoolprintservice\PaySlip.txt";
				StreamWriter sw = new StreamWriter(path); 
				info =" {0,-15:S} {1,-2:S} {2,-30:S} {3,-15:S} {4,-2:S} {5,-30:S}"; //{2,-5:S} {3,-8:S} {4,-6:S} {5,-8:S} {6,10:F}";
				info1=" {0,-12:S} {1,-48:S} {2,-1:S} {3,-48:S}";
				sw.WriteLine(GenUtil.GetCenterAddr("PAY SLIP",des.Length));
				sw.WriteLine("|--------------------------------------------------------------------------------|");
				sw.WriteLine (info,"Employee ID",":",dropEmpName .SelectedItem .Text, "Designation",":",txtdesig .Text);
				sw.WriteLine();
				sw.WriteLine (info,"Employee Name",":",txtEmpID .Text, "Date of Joinong",":",txtdoj .Text);
				sw.WriteLine();
				sw.WriteLine (info,"Permanent AC/NO",":",txtperacno  .Text , "EPF AC/NO",":",txtepfacno .Text);
				sw.WriteLine();
				sw.WriteLine (info,"Basic Salary",":",txtBasic.Text,"","","" );
				sw.WriteLine("|--------------------------------------------------------------------------------|");
				sw.WriteLine (info1,"","   Allowances" ,"","   Deduction ");
				sw.WriteLine("|--------------------------------------------------------------------------------|");
				sw.WriteLine (info,"H.R.A",":",txthra.Text, "E.P,F.",":",txtpf .Text);
				sw.WriteLine();
				sw.WriteLine (info,"T.A",":",txtta.Text, "Profess.    Tax",":",txttax .Text);
				sw.WriteLine();
				sw.WriteLine (info,"D.A",":",txtda.Text, "Loan",":",txtothertax.Text);
				sw.WriteLine();
				sw.WriteLine (info,"C.C.A",":",txtcca.Text, "Penel Deduction",":",txtpenDeduction .Text);
				sw.WriteLine();
				sw.WriteLine (info,"Medical",":",txtMedical.Text , "Security",":",txtsec.Text);
				sw.WriteLine();
				sw.WriteLine (info,"Benifits",":",txtbenefits .Text, "L.W.P.         ",":",txtlwp .Text);
				sw.WriteLine("|--------------------------------------------------------------------------------|");
				sw.WriteLine (info,"Total Allow.   ",":",txtAllowances.Text, "Total Deduction",":",txttax .Text);
				sw.WriteLine("|--------------------------------------------------------------------------------|");
				sw.WriteLine();
				sw.WriteLine (info,"Increment",":",txtincrement.Text,"","","");
				sw.WriteLine();
				sw.WriteLine (info,"Gross",":",txtGross.Text, "Net Salary",":",txtNetSalary .Text);
				sw.WriteLine();
				sw.WriteLine("|--------------------------------------------------------------------------------|");
				sw.Close(); 
				Print();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :PaySlip.aspx,Method  BtnPrint_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

	}
	
}

