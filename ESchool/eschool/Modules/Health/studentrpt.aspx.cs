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
using System.Data .SqlClient ;
using RMG;
using eschool.Classes;
using System.IO;
using System.Text;  
using System.Net;
using System.Net.Sockets;
# endregion

namespace eschool.Health
{
	/// <summary>
	/// Summary description for studentrpt.
	/// </summary>
	public class studentrpt : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList Dropstudentid;
		protected System.Web.UI.WebControls.TextBox txtstudentname;
		protected System.Web.UI.WebControls.Button BtnPrint;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DataGrid dgrdhealth;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlButton btnExcel;
		protected System.Web.UI.HtmlControls.HtmlButton Search;
		protected System.Web.UI.WebControls.Panel panal1;
		string pass;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values and also fill some 
		/// additional information and also check accessing priviledges for perticular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				pass=(Session["password"].ToString());
				CreateLogFiles.ErrorLog (" Form : StudentCheckup_Report.aspx.cs, Method : Page_Load. User: " + pass );
			}
			catch(Exception ex)
			{
				//Response.Redirect(@"../HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : Studentcheckup_Report.aspx.cs, Method : Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				//string pass;
				//pass=(Session["password"].ToString());
				if(!Page.IsPostBack)
				{
					SqlConnection con;
					SqlCommand  cmdselect;
					SqlDataReader dtrclass;
					con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con.Open ();
					cmdselect = new SqlCommand( "Select Student_id  From studenthealth order by student_id", con );
					dtrclass = cmdselect.ExecuteReader();
					//16.02.09 Dropstudentid.Items.Add("---Select---");
					Dropstudentid.Items.Add("All");
					while(dtrclass.Read())
					{
						Dropstudentid.Items.Add(dtrclass.GetValue(0).ToString().Trim());
					}
					dtrclass.Close();
					con.Close ();

				}
            
				if(! IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="11";
					string SubModule="17";
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
					if(View_flag=="False")
					{
						Response.Redirect("/eschool/AccessDeny.aspx",false);
					}
					#endregion
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :studentrpt.aspx ,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}		
		}

		/// <summary>
		/// this Method to save the student id in a variable and return.
		/// </summary>
		public string ShowStudentID(string seq_studentid)
		{
			SqlConnection con3;
			SqlCommand cmdselect3;
			SqlDataReader dtredit3;
			con3=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			con3.Open ();
			string student_id="";
			cmdselect3 = new SqlCommand( "Select Student_fname From Student_record where student_id='"+Dropstudentid.SelectedItem.Text +"'", con3 );
			dtredit3 = cmdselect3.ExecuteReader();
			while (dtredit3.Read()) 
			{
				student_id = dtredit3.GetValue(0).ToString();
			}
			return student_id;
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
			this.Dropstudentid.SelectedIndexChanged += new System.EventHandler(this.Dropstudentid_SelectedIndexChanged);
			this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
			this.Search.ServerClick += new System.EventHandler(this.Search_ServerClick);
			this.btnExcel.ServerClick += new System.EventHandler(this.btnExcel_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this Method use to show the report on the datagrid. data fetch from studenthealth table.
		/// </summary>
		private void Search_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				//if(Dropstudentid.SelectedIndex==0)
				//{
				//	MessageBox.Show("Please select student id");
				//	dgrdhealth.Visible=false;
				//}
				//else
				{
					SqlConnection con1 ;
					string strInsert1;
					SqlCommand cmdInsert1;
					con1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con1.Open ();
					if(Dropstudentid.SelectedIndex!=0)
					{
						strInsert1 ="Select *  From studenthealth where Student_ID =@Student_ID";
					}
					else
					{
						strInsert1 ="Select *  From studenthealth ";
					}
					cmdInsert1=new SqlCommand (strInsert1,con1);
					if(Dropstudentid.SelectedIndex!=0)
						cmdInsert1.Parameters .Add("@Student_ID",Dropstudentid.SelectedItem .Text); 

					dgrdhealth.DataSource =cmdInsert1.ExecuteReader();
					dgrdhealth.DataBind ();
					if(dgrdhealth.Items.Count==0)
					{
						MessageBox.Show("No such record found");
						dgrdhealth.Visible=false;
						panal1.Visible=false;
					}
					else
					{
						dgrdhealth.Visible=true;
						panal1.Visible=true;
					}
					con1.Close();   
				
					CreateLogFiles.ErrorLog(" Form :studentrpt.aspx ,Method : Serch_ServerClicka,Report viewed for StudentID:"+Dropstudentid.SelectedItem .Text .ToString ()+" , Userid :  "+ pass   );		
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :studentrpt.aspx ,Method : Serch_ServerClicka,Exception: "+ex.Message+" , Userid :  "+ pass   );		
				 
			}
		}

		/// <summary>
		/// Method used to return the students first name after passing studentid to it.
		/// </summary>
		public string	fname(string studentid)
		{
			SqlConnection con ;
			SqlCommand cmd;
			SqlDataReader dr;
			con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			con.Open ();
			string str="select Student_Fname from student_Record where student_Id='"+studentid+"'";
			cmd=new SqlCommand(str,con);
			string fname="";
			dr=cmd.ExecuteReader();
			while(dr.Read())
			{
				fname=dr.GetValue(0).ToString();
			}
			dr.Close();
			return fname;
		}

		/// <summary>
		/// this Method to save the student id in a variable and return.
		/// </summary>
		private void Dropstudentid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*SqlConnection con44;
			SqlCommand cmdselect44;
			SqlDataReader dtrdrive44;
			try
			{
				con44=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con44.Open ();
				cmdselect44 = new SqlCommand( "Select Student_FName From Student_Record where Student_ID=@Student_ID", con44 );
				cmdselect44.Parameters .Add ("@Student_ID",Dropstudentid.SelectedItem .Text);
				dtrdrive44 = cmdselect44.ExecuteReader();
				while (dtrdrive44.Read()) 
				{
					txtstudentname.Text=dtrdrive44.GetString(0);
				}
				dtrdrive44.Close();
				con44.Close ();
				dgrdhealth.DataSource=null;
				dgrdhealth.DataBind();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :studentrpt.aspx ,Method : Dropstudentid_SelectedIndexChanged,Exception: "+ex.Message+" , Userid :  "+ pass   );		
				 
			}*/
		}

		/// <summary>
		/// this Method use to writing the report into the text format and call method for print that file.
		/// </summary>
		private void BtnPrint_Click(object sender, System.EventArgs e)
		{
			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);
				string info = "";
				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\StudentHealth_Report.txt";
				StreamWriter sw = new StreamWriter(path); 
				SqlConnection conNorthwind;
				string  strSelect;
				SqlCommand cmdSelect;
				SqlDataReader SqlDtr = null;
				conNorthwind =new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				if(Dropstudentid.SelectedIndex!=0)
					strSelect = "Select Student_Id,Ears, Noise, hands ,Legs,Teeth, Bp , Heartbeat, Skin , Mental,chdate   From studenthealth where Student_ID =@Student_ID";
				else
					strSelect = "Select Student_Id,Ears, Noise, hands ,Legs,Teeth, Bp , Heartbeat, Skin , Mental,chdate   From studenthealth";
				conNorthwind.Open();
				cmdSelect = new SqlCommand( strSelect, conNorthwind );
				//cmdSelect.Parameters.Add("@Student_ID",ShowStudentID(Dropstudentid.SelectedItem .Text .ToString () )); 
				cmdSelect.Parameters.Add("@Student_ID",Dropstudentid.SelectedItem .Text .ToString () ); 
				sw.WriteLine("				   ==========================") ;
				sw.WriteLine("		                      STUDENT HEALTH REPORT") ;
				sw.WriteLine("                                   ==========================") ;
				sw.WriteLine("") ;
				//sw.WriteLine("+---------------+--------------------+--------------------+--------------------+--------------------+--------------------+--------------------+--------------------+--------------------+--------------------+----------+") ;
				//sw.WriteLine("|  First Name   |	Ear          |		Noise     |	   Hand	       |	Leg	    |	    Teeth        |       BP           |       Heart        |	     Skin       |	Mental       |   Date   |") ;
				//sw.WriteLine("+---------------+--------------------+--------------------+--------------------+--------------------+--------------------+--------------------+--------------------+--------------------+--------------------+----------+") ;
				//info = " {0,-15:S} {1,-20:S} {2,-20:S} {3,-20:S} {4,-20:S} {5,-20:S} {6,-20:S} {7,-20:S} {8,-20:S} {9,-20:S} {10,-10:S}";

				//sw.WriteLine("+--------------------+-------+-------+------+-------+-------+-------+-------+-------+-------+-----------+") ;
				//sw.WriteLine("|     First Name     |  Ear  | Noise | Hand | Leg   | Teeth |  BP   | Heart | Skin  |Mental |   Date    |") ;
				//sw.WriteLine("+--------------------+-------+-------+------+-------+-------+-------+-------+-------+-------+-----------+") ;
				//info = " {0,-20:S} {1,-7:S} {2,-7:S} {3,-7:S} {4,-7:S} {5,-7:S} {6,-7:S} {7,-7:S} {8,-7:S} {9,-7:S} {10,-10:S}";

				sw.WriteLine("+--------------------+-----------+-----------+-----------+-----------+-----------+-----------+-----------+-----------+-----------+-----------+") ;
				sw.WriteLine("|     First Name     |    Ear    |   Noise   |   Hand    |    Leg    |   Teeth   |     BP    |   Heart   |  Skin     |  Mental   |   Date    |") ;
				sw.WriteLine("+--------------------+-----------+-----------+-----------+-----------+-----------+-----------+-----------+-----------+-----------+-----------+") ;
				info = " {0,-20:S} {1,-11:S} {2,-11:S} {3,-11:S} {4,-11:S} {5,-11:S} {6,-11:S} {7,-11:S} {8,-11:S} {9,-11:S} {10,-10:S}";

				SqlDtr = cmdSelect.ExecuteReader();
				if(SqlDtr.HasRows)
				{
					while(SqlDtr.Read())
					{
						string studentname=fname(SqlDtr.GetValue(0).ToString());
						sw.WriteLine(info,studentname,
							SqlDtr.GetValue(1).ToString(),
							SqlDtr.GetValue(2).ToString(),
							SqlDtr.GetValue(3).ToString(),
							SqlDtr.GetValue(4).ToString(),
							SqlDtr.GetValue(5).ToString(),
							SqlDtr.GetValue(6).ToString(),
							SqlDtr.GetValue(7).ToString(),
							SqlDtr.GetValue(8).ToString(),
							SqlDtr.GetValue(9).ToString(),
							GenUtil.str2MMDDYYYY(trimDate(SqlDtr.GetValue(10).ToString()))) ;
					}
				}
				SqlDtr.Close();
				sw.WriteLine("+--------------------+-----------+-----------+-----------+-----------+-----------+-----------+-----------+-----------+-----------+-----------+") ;
				sw.Close(); 
				Print();
				CreateLogFiles.ErrorLog(" Form : studentrpt.aspx,Method  Button1_Click,Student Health Report View , Userid :  "+ pass   );
			}
			catch(Exception ex)
			{
				//Response.Write(ex.ToString());
				CreateLogFiles.ErrorLog(" Form : studentrpt.aspx,Method  Button1_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}
		}

		/// <summary>
		/// Thie Method use to craete the connection between remote device.
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\StudentHealth_Report.txt<EOF>");
					//													\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\StudentHealth_Report.txt
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form : studentrpt.aspx,Method  Button1_Click,  Exception: "+ane.Message+" , Userid :  "+ pass   );
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form : studentrpt.aspx,Method  Button1_Click,  Exception: "+se.Message+" , Userid :  "+ pass   );
					 
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					 
				}						
			} 
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : studentrpt.aspx,Method  Print,  Exception: "+ex.Message+" , Userid :  "+ pass   );	
			}
		}

		/// <summary>
		/// this Method use to trim time from datetime string and return only date.
		/// </summary>
		public string trimDate(string date)
		{
			int pos = date.IndexOf(" ");
			if(pos > -1)
			{
				date = date.Substring(0,pos); 
			}
			return date;

		}

		/// <summary>
		/// this method use to create Report in to xls format. 
		/// </summary>
		private void btnExcel_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				ConvertIntoExcel();
				MessageBox.Show("Successfully Convert File into Excel Format");
				CreateLogFiles.ErrorLog("Form:AdvanceFeesReport.aspx,Method: btnExcel_Click, Advance Fees Report Convert Into Excel Format ,  userid  "+pass);
			}
			catch(Exception ex)
			{
				MessageBox.Show("First Close The Open Excel File");
				CreateLogFiles.ErrorLog("Form:AdvanceFeesReport.aspx,Method:btnExcel_Click   Advance Fees Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+pass);
			}
		}

		/// <summary>
		/// this Method use to writing the report into the xls format and save in to eschool_excelfile on c drive.
		/// </summary>
		public void ConvertIntoExcel()
		{

			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2);
			string info = "";
			string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
			Directory.CreateDirectory(strExcelPath);
			string path = home_drive+@"\eSchool_ExcelFile\StudentHealthReport1.xls";
			//string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\StudentHealthReport1.txt";
			StreamWriter sw = new StreamWriter(path); 
			SqlConnection conNorthwind;
			string  strSelect;
			SqlCommand cmdSelect;
			SqlDataReader SqlDtr = null;
			conNorthwind =new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			if(Dropstudentid.SelectedIndex!=0)
				strSelect = "Select Student_Id,Ears, Noise, hands ,Legs,Teeth, Bp , Heartbeat, Skin , Mental,chdate   From studenthealth where Student_ID =@Student_ID";
			else
				strSelect = "Select Student_Id,Ears, Noise, hands ,Legs,Teeth, Bp , Heartbeat, Skin , Mental,chdate   From studenthealth ";
			conNorthwind.Open();
			cmdSelect = new SqlCommand( strSelect, conNorthwind );
			cmdSelect.Parameters.Add("@Student_ID",Dropstudentid.SelectedItem .Text .ToString () ); 
			sw.WriteLine("				   ==========================") ;
			sw.WriteLine("		                      STUDENT HEALTH REPORT") ;
			sw.WriteLine("                 ==========================") ;
			sw.WriteLine("") ;
			//sw.WriteLine("+--------------------+-------+-------+------+-------+-------+-------+-------+-------+-------+-----------+") ;
			sw.WriteLine("First Name\tEar\tNoise\tHand\tLeg\tTeeth\tBP\tHeart\tSkin\tMental\tDate") ;
			//sw.WriteLine("+--------------------+-------+-------+------+-------+-------+-------+-------+-------+-------+-----------+") ;
			info = " {0,-20:S} {1,-7:S} {2,-7:S} {3,-7:S} {4,-7:S} {5,-7:S} {6,-7:S} {7,-7:S} {8,-7:S} {9,-7:S} {10,-10:S}";

			SqlDtr = cmdSelect.ExecuteReader();
			if(SqlDtr.HasRows)
			{
				while(SqlDtr.Read())
				{
					string studentname=fname(SqlDtr.GetValue(0).ToString());
					sw.WriteLine(studentname+"\t"+
						SqlDtr.GetValue(1).ToString()+"\t"+
						SqlDtr.GetValue(2).ToString()+"\t"+
						SqlDtr.GetValue(3).ToString()+"\t"+
						SqlDtr.GetValue(4).ToString()+"\t"+
						SqlDtr.GetValue(5).ToString()+"\t"+
						SqlDtr.GetValue(6).ToString()+"\t"+
						SqlDtr.GetValue(7).ToString()+"\t"+
						SqlDtr.GetValue(8).ToString()+"\t"+
						SqlDtr.GetValue(9).ToString()+"\t"+
						GenUtil.str2MMDDYYYY(trimDate(SqlDtr.GetValue(10).ToString())));
				}
			}
			SqlDtr.Close();
			sw.Close(); 
			CreateLogFiles.ErrorLog(" Form : studentrpt.aspx,Method  BtnExcel_Click,Student Health Report View , Userid :  "+ pass   );
		}

	}
}
