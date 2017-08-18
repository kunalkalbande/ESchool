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

namespace eschool.Forms
{
	/// <summary>
	/// Summary description for StudentRegistration.
	/// </summary>
	public class Form1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator5;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator2;
		protected System.Web.UI.WebControls.Button BtnReset;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.ValidationSummary vsRegistration;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.DropDownList Dropclass;
		protected System.Web.UI.WebControls.DropDownList dropStream;
		protected System.Web.UI.WebControls.TextBox txtFirstName;
		protected System.Web.UI.WebControls.RegularExpressionValidator revFirstName;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox txtDob;
		protected System.Web.UI.HtmlControls.HtmlInputText txtState;
		protected System.Web.UI.HtmlControls.HtmlInputText txtCity;
		protected System.Web.UI.HtmlControls.HtmlInputText txtState1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtCity1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtName;
		protected System.Web.UI.HtmlControls.HtmlInputText tempCash;
		SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
		SqlCommand scom;
		protected System.Web.UI.WebControls.TextBox txtid;
		protected System.Web.UI.HtmlControls.HtmlInputText txtCountry;
		SqlDataReader sdtr;
		static string Status="Pending"; 
		static ArrayList LedgerID= new ArrayList();
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator1;
		protected System.Web.UI.WebControls.Label lblStudentID;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.HtmlControls.HtmlInputText txtCountry1;
		protected System.Web.UI.WebControls.DropDownList Dropaddstatus;
		protected System.Web.UI.WebControls.TextBox TxtFathernm;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator revFatherName;
		protected System.Web.UI.WebControls.TextBox TxtMothernm;
		protected System.Web.UI.WebControls.RegularExpressionValidator revMotherName;
		protected System.Web.UI.WebControls.DropDownList DropCategory;
		protected System.Web.UI.WebControls.DropDownList DropGender;
		protected System.Web.UI.WebControls.TextBox TextPerAdd;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvPAddress;
		protected System.Web.UI.WebControls.DropDownList DropCity1;
		protected System.Web.UI.WebControls.DropDownList dropState;
		protected System.Web.UI.WebControls.DropDownList dropCountry;
		protected System.Web.UI.WebControls.TextBox TxtPhNo;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.DropDownList Droptimehour;
		protected System.Web.UI.WebControls.DropDownList droptimeminit;
		protected System.Web.UI.WebControls.DropDownList Dropam;
		protected System.Web.UI.WebControls.TextBox txtRegFee;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator4;
		protected System.Web.UI.WebControls.Button btnprint;
		protected System.Web.UI.WebControls.TextBox DropStudentID;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator6;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator2;
		protected System.Web.UI.WebControls.CompareValidator compvalid1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularValidator2;
		protected System.Web.UI.WebControls.Button btnsaveonly;
		static string seq_student_id="";
		string pass;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values and also fill some 
		/// additional information and also check accessing priviledges for perticular user.
		/// also Generated Next LedgerID.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
            txtDob.Attributes.Add("readonly", "readonly");
            txtDate.Attributes.Add("readonly", "readonly");
            try
			{
				pass=(Session["password"].ToString ());
				CreateLogFiles.ErrorLog ("Form : Student_Registarion.aspx.cs, Method: Page_Load.  User: " + pass );
			}  
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form : Student_Registration.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				return;
			}
			try
			{
				scon.Open();
				//string pass;
				//pass=(Session["password"].ToString());
				btnprint.Visible=false;
				if(!Page.IsPostBack)
				{
					txtDob.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					txtDate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					GetNextStudentRecordID();
					DropStudentID.Visible=false;

					#region Fill Local Country DropDown
					scom=new SqlCommand("Select distinct Country from Country order by Country asc",scon);
					sdtr=scom.ExecuteReader();
					dropCountry.Items.Clear();
					dropCountry.Items.Add("---Select---");
					
					while(sdtr.Read())
					{
						dropCountry.Items.Add(sdtr.GetString(0));
						
					}
					sdtr.Close();
					scom=new SqlCommand("Select distinct state from Country order by state asc",scon);
					sdtr=scom.ExecuteReader();
					dropState.Items.Clear();
					dropState.Items.Add ("---Select---");
					
					while(sdtr.Read())
					{
						dropState.Items .Add (sdtr.GetString (0));
						
					}
					sdtr.Close ();
					scom=new SqlCommand("Select distinct City from Country order by City asc",scon);
					sdtr=scom.ExecuteReader();
					
					DropCity1.Items.Clear();
					DropCity1.Items.Add ("---Select---");
					while(sdtr.Read())
					{
						
						DropCity1.Items.Add (sdtr.GetString (0));
					}
					
					sdtr.Close ();
					#endregion

					# region Class Fill in Combo
				      
					scom=new SqlCommand("Select distinct Class_name,Class_id from Class order by Class_id",scon);
					sdtr=scom.ExecuteReader();
					while(sdtr.Read())
					{
						Dropclass.Items.Add(sdtr.GetValue(0).ToString());
					}
					sdtr.Close();
					
					# endregion

					#region Fill Text
		
					scom=new SqlCommand("Select Country,State,City from Country order by Country,State,City",scon);
					sdtr= scom.ExecuteReader();
					while(sdtr.Read())
					{
						txtName.Value=txtName.Value+sdtr.GetString(0).ToString().Trim()+ ":" +sdtr.GetString(1).ToString().Trim()+ ":" +sdtr.GetString(2).ToString().Trim()+ ",";
					}
					sdtr.Close();
					#endregion
				}
				CreateLogFiles.ErrorLog ("Form: StudentRegistration.aspx.cs, Method: Page_Load.  User: " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: StudentRegistration.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				//Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				//return;
			}

			try
			{
				if(! IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="4";
					string SubModule="1";
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
					if(Add_Flag=="False")
					{
						btnSave.Enabled=false;
					}
				
					#endregion
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: StudentRegistration.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
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
			this.DropStudentID.TextChanged += new System.EventHandler(this.DropStudentID_TextChanged);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.Dropclass.SelectedIndexChanged += new System.EventHandler(this.Dropclass_SelectedIndexChanged);
			this.txtDate.TextChanged += new System.EventHandler(this.txtDate_TextChanged);
			this.btnsaveonly.Click += new System.EventHandler(this.btnsaveonly_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
			this.ID = "Form1";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this method use to convert date DDMMYYYY to MM/DD/YYYY
		/// </summary>
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
	
		/// <summary>
		/// This method use to Get next id from student_Registration table.
		/// </summary>
		public void GetNextStudentID()
		{
			SchoolClass.SchoolMgs obj=new SchoolClass.SchoolMgs();
			SqlDataReader SqlDtr1;
			string sql1;
			try
			{
				string class1 = Dropclass.SelectedItem.Value.ToString();
				sql1="select max(student_ID)+1 from Student_Registration where student_class='"+class1+"'";
				SqlDtr1 =obj.GetRecordSet(sql1);
				while(SqlDtr1.Read())
				{
					txtid.Text=SqlDtr1.GetSqlValue(0).ToString ();
					if (txtid.Text=="Null" ||txtid.Text=="")
						txtid.Text ="5862";
				}		
				SqlDtr1.Close();
			}
			catch(Exception ex)
			{
				
				CreateLogFiles.ErrorLog ("Form: StudentRegistration.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + Session["password"].ToString() );
			} 	
			
		}
	
		/// <summary>
		/// this method use to Clear page.
		/// </summary>
		public void Clear()
		{		
			txtFirstName.Text="";
			txtDob.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			txtDate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			TxtFathernm.Text="";
			TxtMothernm.Text="";
			DropCity1 .SelectedIndex =0;
			dropState .SelectedIndex =0;
			dropCountry .SelectedIndex =0;
			Dropclass.SelectedIndex=0;
			dropStream.SelectedIndex=0;
			txtRegFee.Text ="";
			DropGender .SelectedIndex=0;
			TextPerAdd.Text="";
			TxtPhNo.Text="";
			DropCategory .SelectedIndex=0;
			droptimeminit .SelectedIndex =0;
			Droptimehour .SelectedIndex =0;
			Dropam .SelectedIndex =0;
		}
		
		/// <summary>
		/// this method use to Reset page.
		/// </summary>
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			try
			{
				lblStudentID.Visible=true;
				DropStudentID.Visible=false;
				btnEdit.Visible=true;
				btnsaveonly.Text="Save";
				Clear();
				CreateLogFiles.ErrorLog ("Form: StudentRegistration.aspx.cs, Method: btnReset_Click.  User: " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: StudentRegistration.aspx.cs, Method: btnReset_Click. Exception: " + ex.Message + " User: " + pass );
			}
			
		}
		
		/// <summary>
		/// This method use to save the information in to student_Registration and also insert some data in to recuringreceipt table.
		/// this method use 'ProInsertStudentRegInfo' procedure.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{		
			try
			{
				SchoolClass.SchoolMgs obj1=new SchoolClass.SchoolMgs();
				SqlDataReader SqlDtr;
				string sql;
				string sRegId = "";
				string sAddDate="";
				string sStudName="";
				string smessage="";
				DateTime dt=System.DateTime.Now;
				DateTime dt1=dt.Add(System.TimeSpan.FromDays(30));
				DateTime doa=Convert.ToDateTime(DateTime.Now.ToShortDateString().ToString());
				DateTime dob=System.Convert.ToDateTime(ToMMddYYYY(txtDob.Text));
				System.TimeSpan minTime=doa.Subtract(dt);
				int iTotal=minTime.Days;
				System.TimeSpan maxTime=dt1.Subtract(doa);
				int iDayDiff=maxTime.Days;
				string phone = TxtPhNo.Text.ToString ();
				if(lblStudentID.Visible==true)
				{
					sql="select Student_PHNo,Student_fname from student_Registration where student_fname='"+txtFirstName.Text +"' and student_phno='" + phone + "'";
					SqlDtr =obj1.GetRecordSet(sql);
					if(SqlDtr.HasRows )
					{
						MessageBox.Show ("Record already exists");
						Clear();
						return;
					} 
					SqlDtr.Close ();
				}
				else
				{
					
				}
				System.TimeSpan diff=doa.Subtract(dob);
				int idays=diff.Days;
				if(idays>=1460)
				{
					SchoolClass.regis obj=new SchoolClass.regis();
					if(txtFirstName.Text=="")
						obj.Student_FName="";
					else
						obj.Student_FName=txtFirstName.Text.Trim();
					if(TxtFathernm.Text=="" || TxtFathernm==null)
						obj.Student_FatherName="";
					else
						obj.Student_FatherName=TxtFathernm.Text.Trim();  
					if(TxtMothernm.Text=="" || TxtMothernm==null)
						obj.Student_MotherName="";
					else
						obj.Student_MotherName=TxtMothernm.Text.Trim();
					if(Dropclass.SelectedIndex==0)
						obj.Student_Class="";
					else
						obj.Student_Class =Dropclass.SelectedItem.Value.ToString().Trim();
						obj.Student_Stream=dropStream .SelectedItem.Value.ToString().Trim();
					obj.Student_AdmissionDate=Convert.ToDateTime(GenUtil.str2MMDDYYYY(DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year));
					obj.Student_Birthdate=dob;
					if(DropGender .SelectedIndex==0)
						obj.Student_Gender="";
					else
						obj.Student_Gender=DropGender.SelectedItem.Value.ToString().Trim();
    				if(TextPerAdd.Text=="")
						obj.Student_PAddress="";
					else
						obj.Student_PAddress =TextPerAdd .Text.Trim();
					
					if(dropState.SelectedIndex==0)
						obj.Student_PState="";
					else
						obj.Student_PState=dropState.SelectedItem.Value.ToString().Trim();
							
					if(dropCountry.SelectedIndex==0)
						obj.Student_PCountry="";
					else
						obj.Student_PCountry=dropCountry.SelectedItem.Value.ToString().Trim();					
					if(DropCity1.SelectedIndex ==0 )
						obj.Student_PCity="";
					else
						obj.Student_PCity=DropCity1.SelectedItem.Value.ToString().Trim();
					
					if(TxtPhNo.Text=="")
						obj.Student_PHNo="";
					else
						obj.Student_PHNo=TxtPhNo .Text.Trim();
					
					if(DropCategory .SelectedIndex==0)
						obj.Student_Category="";
					else
						obj.Student_Category =DropCategory.SelectedItem.Value.Trim().ToString(); 
					
					obj.Admission_Status="Pending";
					obj.RegFee=double.Parse(txtRegFee.Text);
					obj.TestDate=GenUtil.str2MMDDYYYY(txtDate.Text);
					obj.TestTime=Droptimehour.SelectedItem.Text+":"+droptimeminit.SelectedItem.Text+" "+Dropam.SelectedItem.Text;
					string d3 =DateTime .Now .Day +"/"+DateTime .Now.Month+"/"+DateTime .Now .Year ;  
					DateTime d1 = Convert.ToDateTime(ToMMddYYYY(txtDate.Text.Trim().ToString()));
					DateTime d2 = Convert.ToDateTime(ToMMddYYYY(d3.Trim().ToString()));
					if(lblStudentID.Visible==true)
					{
						
					}
					if(lblStudentID.Visible==true)
					{
						obj.Student_ID1=int.Parse(lblStudentID.Text);
						obj.InsertstudentReg();
						sRegId = Dropclass.SelectedItem.Value.ToString() +"-"+lblStudentID.Text;
						sAddDate=DateTime.Now.ToShortDateString().ToString();
						sStudName=txtFirstName.Text.Trim();
						smessage="Student Registered!" + " " +"your Registration ID is- " + " " + sRegId + " " + "& Admission Date is- " + " " + sAddDate;
						GetRegistrationFee();
						obj.Receipt_No=FeeID;
						obj.InsertRegFee();
					}
					else
					{
						obj.Student_ID1=int.Parse(DropStudentID.Text);
						obj.InsertstudentReg();
						sRegId = Dropclass.SelectedItem.Value.ToString() +"-"+DropStudentID.Text;
						sAddDate=DateTime.Now.ToShortDateString().ToString();
						sStudName=txtFirstName.Text.Trim();
						smessage="Student Update!" + " " +"your Registration ID is- " + " " + sRegId + " " + "& Admission Date is- " + " " + sAddDate;
						obj.Receipt_No=FeeID;
						obj.UpdateRegFee();
					}
					MackingReport();
					DropStudentID.Visible=false;
					lblStudentID.Visible=true;
					btnsaveonly.Text="Save";
					# region message 
					btnEdit.Visible=true;
					MessageBox.Show(smessage);
					CreateLogFiles.ErrorLog ("Form: StudentRegistration.aspx.cs, Method: btnSave_Click. New Student " + sStudName + " with ID " + sRegId + " saved. User: " + Session["password"].ToString() );
						
					# endregion
					Clear();
					GetNextStudentRecordID();
				}
				else
				{
					MessageBox.Show("Your age must be greater than or equal to 4 years");
				}
				Status="Pending";
				CreateLogFiles.ErrorLog ("Form: StudentRegistration.aspx.cs, Method: btnSave_Click.  User: " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: StudentRegistration.aspx.cs, Method: btnSave_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}
	
		/// <summary>
		/// This method call Getnextfeeid() function.
		/// </summary>
		public void GetRegistrationFee()
		{
			GetNextFeeID();
		}

		/// <summary>
		/// This method use to Get Next Id of student_registration table.
		/// </summary>
		public void GetNextStudentRecordID()
		{
			try
			{
				scom=new SqlCommand("Select max(Student_ID)+1 from Student_Registration",scon);
				sdtr=scom.ExecuteReader();
				while(sdtr.Read())
				{
					lblStudentID.Text = sdtr.GetSqlValue(0).ToString ();
					if (lblStudentID.Text=="Null" || lblStudentID.Text=="")
						lblStudentID.Text="1";
				}		
				sdtr.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: StudentRegistration.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// This method use to Get Next Id of recuringreceipt table.
		/// </summary>
		string FeeID=""; 
		public void GetNextFeeID()
		{
			scom=new SqlCommand("Select max(RecuringID)+1 from RecuringReceipt",scon);
			sdtr=scom.ExecuteReader();
			while(sdtr.Read())
			{
				FeeID = sdtr.GetSqlValue(0).ToString ();
				if (FeeID=="Null" || FeeID=="")
					FeeID="1";
			}		
			sdtr.Close();
		}

		/// <summary>
		/// this method use to create connection between remote device.
		/// </summary>
		private void BtnPhoto_Click(object sender, System.EventArgs e)
		{
			
			byte[] bytes = new byte[1024];
			Status ="OK";
			Socket sender1;
				/// Connect to a remote device.
			try 
			{
				/// Establish the remote endpoint for the socket.
				/// The name of the
				/// remote device is "host.contoso.com".
				/// Console.WriteLine("Testing WebCAMService...");
				/// Console.WriteLine("Establishing connection with WebCAMService...");
				IPHostEntry ipHostInfo = Dns.Resolve("127.0.0.1");
				IPAddress ipAddress = ipHostInfo.AddressList[0];
				IPEndPoint remoteEP = new IPEndPoint(ipAddress,63000);
				/// Create a TCP/IP  socket.
				sender1 = new Socket(AddressFamily.InterNetwork, 
					SocketType.Stream, ProtocolType.Tcp );
				/// MessageBox.Show ("Object Created");
				/// Connect the socket to the remote endpoint. Catch any errors.
				try 
				{
					sender1.Connect(remoteEP);
					/// MessageBox.Show ("Connection established with WebCAMService @ {0}" + sender1.RemoteEndPoint.ToString());
					/// Encode the data string into a byte array.
					byte[] msg = Encoding.ASCII.GetBytes(seq_student_id + ".<EOF>");
					/// MessageBox.Show ("Byte array created");
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// MessageBox.Show ("Data send");
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					/// MessageBox.Show ("\nWebCAMService Server Echo = {0}" + Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
				}
				catch (ArgumentNullException ane) 
				{
					CreateLogFiles.ErrorLog ("Form: StudentRegistration.aspx.cs, Method: BtnPhoto_Click. Exception: " + ane.Message + " User: " + pass );
				}
				catch (SocketException se)
				{
					/// No connection could be made because the target machine actively refused it
					CreateLogFiles.ErrorLog ("Form: StudentRegistration.aspx.cs, Method: BtnPhoto_Click. Exception: " + se.Message + " User: " + pass );
				} 
				catch (Exception ex)
				{
					CreateLogFiles.ErrorLog ("Form: StudentRegistration.aspx.cs, Method: BtnPhoto_Click. Exception: " + ex.Message + " User: " + pass );
				}
			} 
			catch (Exception ex1)
			{
				CreateLogFiles.ErrorLog ("Form: StudentRegistration.aspx.cs, Method: BtnPhoto_Click. Exception: " + ex1.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// This method use to generate next id. 
		/// </summary>
		private void Dropclass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SchoolClass.regis obj=new SchoolClass.regis();
			GetNextStudentID();
			seq_student_id = Dropclass.SelectedItem.Value.ToString() +"-"+txtid.Text.ToString().Trim();
		}

		private void DropCity_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		private void DropCity1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		/// <summary>
		/// this method use to show page as edit mode.
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			try
			{
				DropStudentID.Visible=true;
				lblStudentID.Visible=false;
				btnEdit.Visible=false;
				DropStudentID.Text="";
				btnsaveonly.Text="Update";
				
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form: StudentRegistration.aspx, Method: btnEdit. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// This method use to Fetch data from student_registration table
		/// </summary>
		private void DropStudentID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			scom=new SqlCommand("Select * from Student_Registration where Student_ID="+DropStudentID.Text+"",scon);
			sdtr=scom.ExecuteReader();
			while(sdtr.Read())
			{
				Dropclass.SelectedIndex=Dropclass.Items.IndexOf(Dropclass.Items.FindByValue(sdtr["Student_Class"].ToString()));
				dropStream.SelectedIndex=dropStream.Items.IndexOf(dropStream.Items.FindByValue(sdtr["Student_Stream"].ToString()));
				txtFirstName.Text=sdtr["Student_FName"].ToString();
				txtDob.Text=GenUtil.str2DDMMYYYY(GenUtil.trimDate(sdtr["Student_Birthdate"].ToString()));
				TxtFathernm.Text=sdtr["Student_FatherName"].ToString();
				TxtMothernm.Text=sdtr["Student_MotherName"].ToString();
				DropCategory.SelectedIndex=DropCategory.Items.IndexOf(DropCategory.Items.FindByValue(sdtr["Student_Category"].ToString()));
				DropGender.SelectedIndex=DropGender.Items.IndexOf(DropGender.Items.FindByValue(sdtr["Student_Gender"].ToString().Trim()));
				TextPerAdd.Text=sdtr["Student_Address"].ToString();
				DropCity1.SelectedIndex=DropCity1.Items.IndexOf(DropCity1.Items.FindByValue(sdtr["Student_City"].ToString()));
				dropState.SelectedIndex=dropState.Items.IndexOf(dropState.Items.FindByValue(sdtr["Student_PState"].ToString()));
				dropCountry.SelectedIndex=dropCountry.Items.IndexOf(dropCountry.Items.FindByValue(sdtr["Student_PCountry"].ToString()));
				txtDate .Text=GenUtil.str2DDMMYYYY(GenUtil.trimDate(sdtr["testdate"].ToString()));
				TxtPhNo.Text=sdtr["Student_PHNo"].ToString();
				txtRegFee.Text=sdtr["regfee"].ToString();
				
			}
			sdtr.Close();
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
					//byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\StudentRegistration.txt<EOF>");
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eschoolprintservice\StudentRegistration.txt<EOF>");
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
					Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog(" Form :StudentRegistration.aspx,Method  Print_Click, StudentRegistration Printed, Userid :  "+ pass);
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form :StudentRegistration.aspx,Method  Print_Click, Exception"+ ane.Message+",  StudentRegistration Printed, Userid :  "+ pass);
				} 
    			catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form :StudentRegistration.aspx,Method  Print_Click, Exception"+ se.Message+",  StudentRegistration Printed, Userid :  "+ pass);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form :StudentRegistration.aspx,Method  Print_Click, Exception"+ es.Message+",  StudentRegistration Printed, Userid :  "+ pass);
				}
			} 
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :StudentRegistration.aspx,Method  Print_Click,Esception:"+ex.Message +", StudentRegistration Printed, Userid :  "+ pass);
			}
		}

		/// <summary>
		/// this Method for print the fees receipt in particular format.
		/// </summary>
		private void btnprint_Click(object sender, System.EventArgs e)
		{
			try
			{
				string home_drive = Environment.SystemDirectory ;
				string info = "",info1 = "",info2 = "",info3 = "";
				home_drive = home_drive.Substring (0,2);
				//string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\StudentRegistration.txt";
				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eschoolprintservice\StudentRegistration.txt";
				StreamWriter sw = new StreamWriter(path); 
				sw.Write((char)27);
				sw.Write((char)64);
				/// ESC P 80 50 Select 10 cpi 
				sw.Write((char)27);
				sw.Write((char)67); 
				sw.Write((char)0);										///added by vishnu
				sw.Write((char)4);										///added by vishnu
				sw.Write((char)27);										///added on 03/10
				sw.Write((char)107);									///added on 03/10
				sw.Write((char)1);										///added on 03/10
				sw.WriteLine();
				sw.WriteLine();
				sw.Write((char)27); 
				sw.Write((char)51); 
				sw.Write((char)25);
				sw.WriteLine();
				info="{0,-6:S} {1,-15:S} {2,-8:S} {3,-14:S} {4,-4:S}";
				info1="{0,-6:S}  {1,-22:S} {2,-5:S} ";	
				info2 =" {0,-10:S} {1,-60:S}";					
				info3=" {0,-10:S} {1,-60:S}";
				if(lblStudentID.Visible==true)
					sw.WriteLine (info,"","Reg. No : ",lblStudentID.Text,FeeID,DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year);
				else
					sw.WriteLine (info,"","Reg. No : ",DropStudentID.Text,"","");
				sw.WriteLine (info1,"",txtFirstName.Text,Dropclass.SelectedItem.Text);
				sw.WriteLine();
				sw.WriteLine (info2,"",TxtFathernm .Text);
				sw.WriteLine();
				sw.WriteLine(info3,"","Registration Fee : ",txtRegFee.Text);
				sw.WriteLine (info3,"","Test Date        : ",txtDate.Text);
				sw.WriteLine(info3,"","Test Time        : ",Droptimehour.SelectedItem.Text+":"+droptimeminit.SelectedItem.Text+" "+Dropam.SelectedItem.Text);
				sw.Close(); 
				Print();
				CreateLogFiles.ErrorLog(" Form :StudentRegistration.aspx,Method  BtnPrint_Click, Userid :  "+ pass   );		
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :StudentRegistration.aspx,Method  BtnPrint_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this Method for print the fees receipt in particular format.
		/// </summary>
		public void MackingReport()
		{
			try
			{
				string home_drive = Environment.SystemDirectory ;
				string info = "",info1 = "",info2 = "",info3 = "";
				home_drive = home_drive.Substring (0,2);
				//string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\StudentRegistration.txt";
				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eschoolprintservice\StudentRegistration.txt";
				StreamWriter sw = new StreamWriter(path); 
				sw.Write((char)27);
				sw.Write((char)64);
				sw.Write((char)27);
				sw.Write((char)67); 
				sw.Write((char)0);												///added by vishnu
				sw.Write((char)4);												///added by vishnu
				sw.Write((char)27);												///added on 05/10
				sw.Write((char)107);											///added on 05/10
				sw.Write((char)1);												///added on 05/10
				sw.WriteLine();
				sw.WriteLine();
			    ///  25/180 of an Inch  : 27 51 25
				sw.Write((char)27); 
				sw.Write((char)51); 
				sw.Write((char)25);
				sw.WriteLine();
				info="{0,-6:S} {1,-10:S} {2,-13:S} {3,-15:S} {4,-10:S}";
				info1="{0,-6:S} {1,-27:S} {2,-5:S} ";
				info2 =" {0,-11:S} {1,-60:S}";
				info3=" {0,-11:S} {1,-18:S} {2,-60:S}";
				sw.WriteLine();
				if(lblStudentID.Visible==true)
					sw.WriteLine (info,"","Reg. No : ",lblStudentID.Text,FeeID,DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year);
				else
				{
					InventoryClass obj = new InventoryClass();
					SqlDataReader rdr;
					string ad_date="",Rec_ID="";;
					rdr = obj.GetRecordSet("select Student_AdmissionDate from student_registration where student_ID='"+DropStudentID.Text+"'");
					if(rdr.Read())
						ad_date=rdr.GetValue(0).ToString();
					rdr.Close();
					rdr = obj.GetRecordSet("select RecuringID from recuringreceipt where regID='"+DropStudentID.Text+"'");
					if(rdr.Read())
						Rec_ID=rdr.GetValue(0).ToString();
					rdr.Close();
					
					sw.WriteLine (info,"","Reg. No : ",DropStudentID.Text,Rec_ID,GenUtil.str2DDMMYYYY(GenUtil.trimDate(ad_date)));
				}
				sw.WriteLine();
				sw.WriteLine (info1,"",txtFirstName.Text,Dropclass.SelectedItem.Text);
				sw.WriteLine();
				sw.WriteLine (info2,"",TxtFathernm .Text);
				sw.WriteLine();
				sw.WriteLine();
				sw.WriteLine();
				sw.WriteLine(info3,"","Registration Fee : ",txtRegFee.Text);
				sw.WriteLine();
				sw.WriteLine (info3,"","Test Date        : ",txtDate.Text);
				sw.WriteLine();
				sw.WriteLine(info3,"","Test Time        : ",Droptimehour.SelectedItem.Text+":"+droptimeminit.SelectedItem.Text+" "+Dropam.SelectedItem.Text);
				sw.WriteLine();
				sw.WriteLine();
				sw.WriteLine(info2,"",txtRegFee.Text);
				sw.WriteLine();
				sw.WriteLine(info2,"",GenUtil.ConvertNoToWord(txtRegFee.Text));
				sw.Close(); 
				Print();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :StudentRegistration.aspx,Method  BtnPrint_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		private void txtDate_TextChanged(object sender, System.EventArgs e)
		{
			
		}

		/// <summary>
		/// This method use to Fetch data from student_registration table
		/// </summary>
		private void DropStudentID_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(DropStudentID.Text!="")
				{
					scom=new SqlCommand("Select * from Student_Registration where Student_ID="+DropStudentID.Text+"",scon);
					sdtr=scom.ExecuteReader();
					if(sdtr.HasRows)
					{
						while(sdtr.Read())
						{
							Dropclass.SelectedIndex=Dropclass.Items.IndexOf(Dropclass.Items.FindByValue(sdtr["Student_Class"].ToString()));
							dropStream.SelectedIndex=dropStream.Items.IndexOf(dropStream.Items.FindByValue(sdtr["Student_Stream"].ToString()));
							txtFirstName.Text=sdtr["Student_FName"].ToString();
							txtDob.Text=GenUtil.str2DDMMYYYY(GenUtil.trimDate(sdtr["Student_Birthdate"].ToString()));
							TxtFathernm.Text=sdtr["Student_FatherName"].ToString();
							TxtMothernm.Text=sdtr["Student_MotherName"].ToString();
							DropCategory.SelectedIndex=DropCategory.Items.IndexOf(DropCategory.Items.FindByValue(sdtr["Student_Category"].ToString()));
							DropGender.SelectedIndex=DropGender.Items.IndexOf(DropGender.Items.FindByValue(sdtr["Student_Gender"].ToString().Trim()));
							TextPerAdd.Text=sdtr["Student_Address"].ToString();
							DropCity1.SelectedIndex=DropCity1.Items.IndexOf(DropCity1.Items.FindByValue(sdtr["Student_City"].ToString()));
							dropState.SelectedIndex=dropState.Items.IndexOf(dropState.Items.FindByValue(sdtr["Student_PState"].ToString()));
							dropCountry.SelectedIndex=dropCountry.Items.IndexOf(dropCountry.Items.FindByValue(sdtr["Student_PCountry"].ToString()));
							txtDate .Text=GenUtil.str2DDMMYYYY(GenUtil.trimDate(sdtr["testdate"].ToString()));
							TxtPhNo.Text=sdtr["Student_PHNo"].ToString();
							txtRegFee.Text=sdtr["regfee"].ToString();
							string s=sdtr["testtime"].ToString();
							string[] ss=s.Split(new char[] {':'},s.Length);
							string[] sss=ss[1].Split(new char[] {' '},ss[1].Length);
							Droptimehour.SelectedIndex=Droptimehour.Items.IndexOf(Droptimehour.Items.FindByValue(ss[0]));
							droptimeminit.SelectedIndex=droptimeminit.Items.IndexOf(droptimeminit.Items.FindByValue(sss[0]));
							Dropam.SelectedIndex=Dropam.Items.IndexOf(Dropam.Items.FindByValue(sss[1]));
						}
					}
					else
					{
						MessageBox.Show("Invalid Student ID");
						Clear();
					}
					sdtr.Close();

					LedgerID.Clear();
                    InventoryClass obj=new InventoryClass();
					string str2="select ledger_id from accountsledgertable where particulars='Registration("+DropStudentID.Text+")'";
					sdtr=obj.GetRecordSet(str2);
					while(sdtr.Read())
					{
						LedgerID.Add(sdtr.GetValue(0));
					}	
					sdtr.Close();
				}
				else
				{
					MessageBox.Show("Please Enter The Student ID");
					
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: StudentRegistration.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
			}
		
		}

		/// <summary>
		/// This method use to save ragistration in to student_registration table and recuringreceipt table also.first check the age of student
		/// age should be more then 4 years. and record insert in AccountsLedgertable with the help of AccountledgerUpdate() function. 
		/// and with help of AccountledgerUpdate() function update closing balance of cash account.
		/// </summary>
		private void btnsaveonly_Click(object sender, System.EventArgs e)
		{
			try
			{
				string cash_id="";
				SqlDataReader sdtr2=null;
				InventoryClass obj2=new InventoryClass();
				string str2="select ledger_id from ledger_master where sub_grp_id =(select sub_grp_id from ledger_master_sub_grp where sub_grp_name like 'Cash in hand')";
				sdtr2=obj2.GetRecordSet(str2);
				while(sdtr2.Read())
				{
					cash_id=sdtr2.GetValue(0).ToString();
					tempCash.Value=sdtr2.GetValue(0).ToString();
				}
				sdtr2.Close();
				if(cash_id=="")
				{
					MessageBox.Show("Please First Create CashA/C");
				}
				else
				{
					SchoolClass.SchoolMgs obj1=new SchoolClass.SchoolMgs();
					SqlDataReader SqlDtr;
					string sql;
					string sRegId = "";
					string sAddDate="";
					string sStudName="";
					string smessage="";
					DateTime dt=System.DateTime.Now;
					DateTime dt1=dt.Add(System.TimeSpan.FromDays(30));
					DateTime doa=Convert.ToDateTime(DateTime.Now.ToShortDateString().ToString());
					DateTime dob=System.Convert.ToDateTime(ToMMddYYYY(txtDob.Text));
					System.TimeSpan minTime=doa.Subtract(dt);
					int iTotal=minTime.Days;
					System.TimeSpan maxTime=dt1.Subtract(doa);
					int iDayDiff=maxTime.Days;
					string phone = TxtPhNo.Text.ToString ();
					if(lblStudentID.Visible==true)
					{
						sql="select Student_PHNo,Student_fname from student_Registration where student_fname='"+txtFirstName.Text +"' and student_phno='" + phone + "'";
						SqlDtr =obj1.GetRecordSet(sql);
						if(SqlDtr.HasRows)
						{
							MessageBox.Show ("Record Already Exists");
							Clear();
							return;
						} 
						SqlDtr.Close ();
					}
					else
					{
					
					}
					System.TimeSpan diff=doa.Subtract(dob);
					int idays=diff.Days;
					if(idays>=1460)
					{
						SchoolClass.regis obj=new SchoolClass.regis();
						if(txtFirstName.Text=="")
							obj.Student_FName="";
						else
							obj.Student_FName=txtFirstName.Text.Trim();
						if(TxtFathernm.Text=="" || TxtFathernm==null)
							obj.Student_FatherName="";
						else
							obj.Student_FatherName=TxtFathernm.Text.Trim();  
						if(TxtMothernm.Text=="" || TxtMothernm==null)
							obj.Student_MotherName="";
						else
							obj.Student_MotherName=TxtMothernm.Text.Trim();
						if(Dropclass.SelectedIndex==0)
							obj.Student_Class="";
						else
							obj.Student_Class =Dropclass.SelectedItem.Value.ToString().Trim();
						///16.10.08if(dropStream.SelectedIndex==0)
						///obj.Student_Stream="";
						///else
						obj.Student_Stream=dropStream .SelectedItem.Value.ToString().Trim();
					
						obj.Student_AdmissionDate=Convert.ToDateTime(GenUtil.str2MMDDYYYY(DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year));
						obj.Student_Birthdate=dob;
						//11.02.09if(DropGender .SelectedIndex==0)
						//11.02.09	obj.Student_Gender="";
						//11.02.09else
							obj.Student_Gender=DropGender.SelectedItem.Value.ToString().Trim();
						if(TextPerAdd.Text=="")
							obj.Student_PAddress="";
						else
							obj.Student_PAddress =TextPerAdd .Text.Trim();
					
						if(dropState.SelectedIndex==0)
							obj.Student_PState="";
						else
							obj.Student_PState=dropState.SelectedItem.Value.ToString().Trim();
							
						if(dropCountry.SelectedIndex==0)
							obj.Student_PCountry="";
						else
							obj.Student_PCountry=dropCountry.SelectedItem.Value.ToString().Trim();					
						if(DropCity1.SelectedIndex ==0 )
							obj.Student_PCity="";
						else
							obj.Student_PCity=DropCity1.SelectedItem.Value.ToString().Trim();
					
						if(TxtPhNo.Text=="")
							obj.Student_PHNo="";
						else
							obj.Student_PHNo=TxtPhNo .Text.Trim();
					
						//11.02.09 if(DropCategory .SelectedIndex==0)
						//11.02.09	obj.Student_Category="";
						//11.02.09 else
							obj.Student_Category =DropCategory.SelectedItem.Value.Trim().ToString(); 
					
						obj.Admission_Status="Pending";
						obj.RegFee=double.Parse(txtRegFee.Text);
						obj.TestDate=GenUtil.str2MMDDYYYY(txtDate.Text);
						obj.TestTime=Droptimehour.SelectedItem.Text+":"+droptimeminit.SelectedItem.Text+" "+Dropam.SelectedItem.Text;
						string d3 =DateTime .Now .Day +"/"+DateTime .Now.Month+"/"+DateTime .Now .Year ;  
						DateTime d1 = Convert.ToDateTime(ToMMddYYYY(txtDate.Text.Trim().ToString()));
						DateTime d2 = Convert.ToDateTime(ToMMddYYYY(d3.Trim().ToString()));
									
						if(lblStudentID.Visible==true)
						{
							obj.Student_ID1=int.Parse(lblStudentID.Text);
							obj.InsertstudentReg();
							sRegId = Dropclass.SelectedItem.Value.ToString() +"-"+lblStudentID.Text;
							sAddDate=DateTime.Now.ToShortDateString().ToString();
							sStudName=txtFirstName.Text.Trim();
							//smessage="Student Registered!" + " " +"your Registration ID is- " + " " + sRegId + " " + "& Admission Date is- " + " " + sAddDate;
							smessage="Student Registered!" + " " +"your Registration ID is- " + " " + sRegId + " " + "& Registration Date is- " + " " + sAddDate;
							GetRegistrationFee();
							obj.Receipt_No=FeeID;
							obj.InsertRegFee();
						}
						else
						{
							obj.Student_ID1=int.Parse(DropStudentID.Text);
							obj.InsertstudentReg();
							sRegId = Dropclass.SelectedItem.Value.ToString() +"-"+DropStudentID.Text;
							sAddDate=DateTime.Now.ToShortDateString().ToString();
							sStudName=txtFirstName.Text.Trim();
							smessage="Student Update!" + " " +"your Registration ID is- " + " " + sRegId + " " + "& Admission Date is- " + " " + sAddDate;
							obj.Receipt_No=FeeID;
							obj.UpdateRegFee();
						}
						insertaccountledger();
						AccountledgerUpdate();
						DropStudentID.Visible=false;
						lblStudentID.Visible=true;
						btnEdit.Visible=true;
						btnsaveonly.Text="Save";
						MessageBox.Show(smessage);
						CreateLogFiles.ErrorLog ("Form: StudentRegistration.aspx.cs, Method: btnSave_Click. New Student " + sStudName + " with ID " + sRegId + " saved. User: " + pass );
						Clear();
						GetNextStudentRecordID();
					}
					else
					{
						MessageBox.Show("Your age must be greater than or equal to 4 years");
					}
					Status="Pending";
					CreateLogFiles.ErrorLog ("Form: StudentRegistration.aspx.cs, Method: btnSave_Click.  User: " + pass );
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: StudentRegistration.aspx.cs, Method: btnSave_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// this function use to update closing balance of AccountsLedgerTable from the selected date.
		/// </summary>
		public void AccountledgerUpdate()
		{
			SqlDataReader rdr=null;
			SqlCommand cmd;
			InventoryClass obj =new InventoryClass();
			SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			double Bal=0;
			string BalType="",str="";
			int i=0;
			//*************************
			//string[] CheckDate = Invoice_Date.Split(new char[] {' '},Invoice_Date.Length);
			//if(DateTime.Compare(System.Convert.ToDateTime(CheckDate[0].ToString()),System.Convert.ToDateTime(GenUtil.str2MMDDYYYY(TxtcurDate.Text)))>0)
			//	Invoice_Date=GenUtil.str2MMDDYYYY(TxtcurDate.Text);
			string Invoice_Date=GenUtil.str2MMDDYYYY(DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year);
			for(int k=0;k<LedgerID.Count;k++)
			{
				rdr = obj.GetRecordSet("select top 1 Entry_Date from AccountsLedgerTable where Ledger_ID='"+LedgerID[k].ToString()+"' and Entry_Date<='"+Invoice_Date+"' order by entry_date desc");
				if(rdr.Read())
					str="select * from AccountsLedgerTable where Ledger_ID='"+LedgerID[k].ToString()+"' and Entry_Date>='"+rdr.GetValue(0).ToString()+"' order by entry_date";
				else
					str="select * from AccountsLedgerTable where Ledger_ID='"+LedgerID[k].ToString()+"' order by entry_date";
				rdr.Close();
				//*************************
				//string str="select * from AccountsLedgerTable where Ledger_ID='"+LedgerID+"' order by entry_date";
				rdr=obj.GetRecordSet(str);
				Bal=0;
				BalType="";
				i=0;
				while(rdr.Read())
				{
					if(i==0)
					{
						BalType=rdr["Bal_Type"].ToString();
						Bal=double.Parse(rdr["Balance"].ToString());
						i++;
					}
					else
					{
						if(double.Parse(rdr["Credit_Amount"].ToString())!=0)
						{
							if(BalType=="Cr")
							{
								string ss=rdr["Credit_Amount"].ToString();
								Bal+=double.Parse(rdr["Credit_Amount"].ToString());
								BalType="Cr";
							}
							else
							{
								string ss=rdr["Credit_Amount"].ToString();
								Bal-=double.Parse(rdr["Credit_Amount"].ToString());
								if(Bal<0)
								{
									Bal=double.Parse(Bal.ToString().Substring(1));
									BalType="Cr";
								}
								else
									BalType="Dr";
							}
						}
						else if(double.Parse(rdr["Debit_Amount"].ToString())!=0)
						{
							if(BalType=="Dr")
							{
								string ss=rdr["Debit_Amount"].ToString();
								Bal+=double.Parse(rdr["Debit_Amount"].ToString());
							}
							else
							{
								string ss=rdr["Debit_Amount"].ToString();
								Bal-=double.Parse(rdr["Debit_Amount"].ToString());
								if(Bal<0)
								{
									Bal=double.Parse(Bal.ToString().Substring(1));
									BalType="Dr";
								}
								else
									BalType="Cr";
							}
						}
						Con.Open();
						string str11="update AccountsLedgerTable set Balance='"+Bal.ToString()+"',Bal_Type='"+BalType+"' where Ledger_ID='"+rdr["Ledger_ID"].ToString()+"' and Particulars='"+rdr["Particulars"].ToString()+"'";
						cmd = new SqlCommand("update AccountsLedgerTable set Balance='"+Bal.ToString()+"',Bal_Type='"+BalType+"' where Ledger_ID='"+rdr["Ledger_ID"].ToString()+"' and Particulars='"+rdr["Particulars"].ToString()+"'",Con);
						cmd.ExecuteNonQuery();
						cmd.Dispose();
						Con.Close();
					}		
				}
				rdr.Close();
			}
		}

		/// <summary>
		/// this function use to insert data into AccountLedgerTable with help of 'ProInsertAccountsLedger' procedure.but time of updation before the insert data
		/// in to this table delete the particular record from this table.
		/// </summary>
		public void insertaccountledger()
		{
			if(lblStudentID.Visible==false)
			{
				string str="delete from accountsledgertable where Particulars='Registration("+DropStudentID.Text.ToString()+")'";
				scom=new SqlCommand(str,scon);
				scom.ExecuteNonQuery();
				scom.Dispose();
			}
			scom=new SqlCommand("ProInsertAccountsLedger",scon);
			scom.CommandType=CommandType.StoredProcedure;
			scom.Parameters.Add("@Ledger_Id",Convert.ToInt32(tempCash.Value));
			if(lblStudentID.Visible==true)
			{
				scom.Parameters.Add("@Particulars","Registration("+lblStudentID.Text.ToString()+")");
			}
			else
			{
				scom.Parameters.Add("@Particulars","Registration("+DropStudentID.Text.ToString()+")");
			}
			scom.Parameters.Add("@Debit_Amount",txtRegFee.Text.Trim());
			scom.Parameters.Add("@Credit_Amount","0");
			scom.Parameters.Add("@type","Dr");
			scom.Parameters.Add("@Invoice_Date",System.Convert.ToDateTime(GenUtil.str2DDMMYYYY(+DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year+" "+DateTime.Now.TimeOfDay.ToString())));
			scom.ExecuteNonQuery();
			scom.Dispose();
		}

	}
}