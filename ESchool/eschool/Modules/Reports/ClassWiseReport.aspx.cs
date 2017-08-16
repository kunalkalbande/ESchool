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
using System.Collections.Specialized;


namespace eschool.Reports
{
	/// <summary>
	/// Summary description for ClassWiseReport.
	/// </summary>
	public class ClassWiseReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.DropDownList DropClass;
		protected System.Web.UI.WebControls.DropDownList DropSec;
		protected System.Web.UI.WebControls.Button Btnexcel;
		protected System.Web.UI.WebControls.Button Button2;
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
			}
			catch(Exception ex)
			{
				//Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog ("Form: ClassWiseTimeTableReport.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				if(! IsPostBack)
				{
					SqlDataReader sdtr=null;
					InventoryClass obj=new InventoryClass();
					string sql="select class_name from class order by class_id";
					sdtr=obj.GetRecordSet(sql);
					while(sdtr.Read())
					{
						DropClass.Items.Add(sdtr.GetValue(0).ToString().Trim());
					}
					sdtr.Close();
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="11";
					string SubModule="37";
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
				CreateLogFiles.ErrorLog (" Form : ClassWiseTimeTableReport.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Btnexcel.Click += new System.EventHandler(this.Btnexcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DropClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// this method use to create Report in text format data fetch from teachertimetable. 
		/// </summary>
		private void Button2_Click(object sender, System.EventArgs e)
		{
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2);
			string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\ClassWiseTimeTable.txt";
			InventoryClass obj=new InventoryClass();
			InventoryClass obj2=new InventoryClass();
			SqlDataReader sql,dr;
			StreamWriter sw=new StreamWriter(path);
			string cls="";
			if(DropClass.SelectedIndex!=0)
			{
				/*if(DropClass.SelectedItem.Text=="I")
					cls="1";
				else if(DropClass.SelectedItem.Text=="II")
					cls="2";
				else if(DropClass.SelectedItem.Text=="III")
					cls="3";
				else if(DropClass.SelectedItem.Text=="IV")
					cls="4";
				else if(DropClass.SelectedItem.Text=="V")
					cls="5";
				else if(DropClass.SelectedItem.Text=="VI")
					cls="6";
				else if(DropClass.SelectedItem.Text=="VII")
					cls="7";
				else if(DropClass.SelectedItem.Text=="VIII")
					cls="8";
				else if(DropClass.SelectedItem.Text=="IX")
					cls="9";
				else if(DropClass.SelectedItem.Text=="X")
					cls="10";
				else if(DropClass.SelectedItem.Text=="XI")
					cls="11";
				else if(DropClass.SelectedItem.Text=="XII")
					cls="12";*/

				if(DropClass.SelectedItem.Text=="Nursery")
					cls="1";
				else if(DropClass.SelectedItem.Text=="LKG")
					cls="2";
				else if(DropClass.SelectedItem.Text=="UKG")
					cls="3";
				else if(DropClass.SelectedItem.Text=="I")
					cls="4";
				else if(DropClass.SelectedItem.Text=="II")
					cls="5";
				else if(DropClass.SelectedItem.Text=="III")
					cls="6";
				else if(DropClass.SelectedItem.Text=="IV")
					cls="7";
				else if(DropClass.SelectedItem.Text=="V")
					cls="8";
				else if(DropClass.SelectedItem.Text=="VI")
					cls="9";
				else if(DropClass.SelectedItem.Text=="VII")
					cls="10";
				else if(DropClass.SelectedItem.Text=="VIII")
					cls="11";
				else if(DropClass.SelectedItem.Text=="IX")
					cls="12";
				else if(DropClass.SelectedItem.Text=="X")
					cls="13";
				else if(DropClass.SelectedItem.Text=="XI")
					cls="14";
				else if(DropClass.SelectedItem.Text=="XII")
					cls="15";
			}
			string[] Mon=new string[48]; 
			string[] tcode=new string[48]; 
			string str1="",period="";
			string str="select * from teachertimetable";
			sql=obj.GetRecordSet(str);
			if(sql.Read())
			{
				for(int j=2;j<sql.FieldCount-2;j++)
				{
					str1="select "+sql.GetName(j).ToString()+",shortname from teachertimetable where "+sql.GetName(j).ToString()+" like '"+cls+DropSec.SelectedItem.Text+"%'";
					dr=obj2.GetRecordSet(str1);
					while(dr.Read())
					{
						period=dr.GetValue(0).ToString();
						if(period.IndexOf("A")>0)
						{
							Mon[j-2]=period.Substring(period.IndexOf("A")+1,period.Length-period.IndexOf("A")-1);
							tcode[j-2]=dr.GetValue(1).ToString();
						}
						else if(period.IndexOf("B")>0)
						{
							Mon[j-2]=period.Substring(period.IndexOf("B")+1,period.Length-period.IndexOf("B")-1);
							tcode[j-2]=dr.GetValue(1).ToString();
						}
						else if(period.IndexOf("C")>0)
						{
							Mon[j-2]=period.Substring(period.IndexOf("C")+1,period.Length-period.IndexOf("C")-1);
							tcode[j-2]=dr.GetValue(1).ToString();
						}
						else if(period.IndexOf("D")>0)
						{
							Mon[j-2]=period.Substring(period.IndexOf("D")+1,period.Length-period.IndexOf("D")-1);
							tcode[j-2]=dr.GetValue(1).ToString();
						}
						else
						{
							Mon[j-2]=period;
							tcode[j-2]=dr.GetValue(1).ToString();
						}
										
					}
					dr.Close();
				}
				
			}
			sql.Close();
			sw.Write((char)27);
			sw.Write((char)67);
			sw.Write((char)0);
			sw.Write((char)12);
			sw.Write((char)27);
			sw.Write((char)78);
			sw.Write((char)5);
			sw.Write((char)27);
			sw.Write((char)15);
			string info="",info1="";;
			sw.WriteLine("                                          -------------------------");
			sw.WriteLine("		                           Class Wise Time Table") ;
			sw.WriteLine("                                          -------------------------");
			info1 = "                 {0,-12:S}{1,-13:S}                 {2,20:S}   {3,-20:S}";
			sw.WriteLine(info1,"Class:",DropClass.SelectedItem.Text,"Section:",DropSec.SelectedItem.Text);
			sw.WriteLine("+---------+---------------+---------------+---------------+---------------+---------------+---------------+---------------+-------------+");
			sw.WriteLine("| D / P   |      I        |      II       |      III      |      IV       |        V      |       VI      |      VII      |      VIII   |");
			sw.WriteLine("+---------+---------------+---------------+---------------+---------------+---------------+---------------+---------------+-------------+");
			//             123456789 123456789012345 123456789012345 123456789012345 123456789012345 123456789012345 123456789012345 123456789012345 1234567890123
			info = " {0,-9:S} {1,-15:S} {2,-15:S} {3,-15:S} {4,-15:S} {5,-15:S} {6,-15:S} {7,-15:S} {8,-13:S}";
			sw.WriteLine(info,"Monday",tcode[0]+" "+Mon[0],tcode[1]+" "+Mon[1],tcode[2]+" "+Mon[2],tcode[3]+" "+Mon[3],tcode[4]+" "+Mon[4],tcode[5]+" "+Mon[5],tcode[6]+" "+Mon[6],tcode[7]+" "+Mon[7]);
			sw.WriteLine(info,"Tuesday",tcode[8]+" "+Mon[8],tcode[9]+" "+Mon[9],tcode[10]+" "+Mon[10],tcode[11]+" "+Mon[11],tcode[12]+" "+Mon[12],tcode[13]+" "+Mon[13],tcode[14]+" "+Mon[14],tcode[15]+" "+Mon[15]);
			sw.WriteLine(info,"Wednesday",tcode[16]+" "+Mon[16],tcode[17]+" "+Mon[17],tcode[18]+" "+Mon[18],tcode[19]+" "+Mon[19],tcode[20]+" "+Mon[20],tcode[21]+" "+Mon[21],tcode[22]+" "+Mon[22],tcode[23]+" "+Mon[23]);
			sw.WriteLine(info,"ThursDay",tcode[24]+" "+Mon[24],tcode[25]+" "+Mon[25],tcode[26]+" "+Mon[26],tcode[27]+" "+Mon[27],tcode[28]+" "+Mon[28],tcode[29]+" "+Mon[29],tcode[30]+" "+Mon[30],tcode[31]+" "+Mon[31]);
			sw.WriteLine(info,"Friday",tcode[32]+" "+Mon[32],tcode[33]+" "+Mon[33],tcode[34]+" "+Mon[34],tcode[35]+" "+Mon[35],tcode[36]+" "+Mon[36],tcode[37]+" "+Mon[37],tcode[38]+" "+Mon[38],tcode[39]+" "+Mon[39]);
			sw.WriteLine(info,"Satday",tcode[40]+" "+Mon[40],tcode[41]+" "+Mon[41],tcode[42]+" "+Mon[42],tcode[43]+" "+Mon[43],tcode[44]+" "+Mon[44],tcode[45]+" "+Mon[45],tcode[46]+" "+Mon[46],tcode[47]+" "+Mon[47]);
			sw.WriteLine("+---------+--------------+---------------+---------------+---------------+---------------+---------------+---------------+---------------+");
			sw.Close(); 
			Print();
		}

		/// <summary>
		/// this Method use to create connection between remot device.
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
					///CreateLogFiles.ErrorLog("Form:VehicleLogReport.aspx,Method:Print"+uid);
					Console.WriteLine("Socket connected to {0}",
					sender1.RemoteEndPoint.ToString());
    				/// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2);
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\ClassWiseTimeTable.txt<EOF>");
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
					CreateLogFiles.ErrorLog(" Form : ClassWiseReport.aspx,Method  Print,  Exception: "+ane.Message+" , Userid :  "+ pass );	 
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form : ClassWiseReport.aspx,Method  Print,  Exception: "+se.Message+" , Userid :  "+ pass   );
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form : ClassWiseReport.aspx,Method  Print,  Exception: "+es.Message+" , Userid :  "+ pass   );					
				}						
			} 			
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : ClassWiseReport.aspx,Method  Print,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// this method use to call ConvertIntoExcel().
		/// </summary>
		private void Btnexcel_Click(object sender, System.EventArgs e)
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
		/// this method use to create Report in excel format data fetch from teachertimetable.
		/// </summary>
		public void ConvertIntoExcel()
		{
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2);
			string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
			Directory.CreateDirectory(strExcelPath);
			string path = home_drive+@"\eSchool_ExcelFile\ClassWiseTimeTable.xls";
			//string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\ClassWiseTimeTable.txt";
			InventoryClass obj=new InventoryClass();
			InventoryClass obj2=new InventoryClass();
			SqlDataReader sql,dr;
			StreamWriter sw=new StreamWriter(path);
			string cls="";
			if(DropClass.SelectedIndex!=0)
			{
				/*if(DropClass.SelectedItem.Text=="I")
					cls="1";
				else if(DropClass.SelectedItem.Text=="II")
					cls="2";
				else if(DropClass.SelectedItem.Text=="III")
					cls="3";
				else if(DropClass.SelectedItem.Text=="IV")
					cls="4";
				else if(DropClass.SelectedItem.Text=="V")
					cls="5";
				else if(DropClass.SelectedItem.Text=="VI")
					cls="6";
				else if(DropClass.SelectedItem.Text=="VII")
					cls="7";
				else if(DropClass.SelectedItem.Text=="VIII")
					cls="8";
				else if(DropClass.SelectedItem.Text=="IX")
					cls="9";
				else if(DropClass.SelectedItem.Text=="X")
					cls="10";
				else if(DropClass.SelectedItem.Text=="XI")
					cls="11";
				else if(DropClass.SelectedItem.Text=="XII")
					cls="12";*/

				if(DropClass.SelectedItem.Text=="Nursery")
					cls="1";
				else if(DropClass.SelectedItem.Text=="LKG")
					cls="2";
				else if(DropClass.SelectedItem.Text=="UKG")
					cls="3";
				else if(DropClass.SelectedItem.Text=="I")
					cls="4";
				else if(DropClass.SelectedItem.Text=="II")
					cls="5";
				else if(DropClass.SelectedItem.Text=="III")
					cls="6";
				else if(DropClass.SelectedItem.Text=="IV")
					cls="7";
				else if(DropClass.SelectedItem.Text=="V")
					cls="8";
				else if(DropClass.SelectedItem.Text=="VI")
					cls="9";
				else if(DropClass.SelectedItem.Text=="VII")
					cls="10";
				else if(DropClass.SelectedItem.Text=="VIII")
					cls="11";
				else if(DropClass.SelectedItem.Text=="IX")
					cls="12";
				else if(DropClass.SelectedItem.Text=="X")
					cls="13";
				else if(DropClass.SelectedItem.Text=="XI")
					cls="14";
				else if(DropClass.SelectedItem.Text=="XII")
					cls="15";
			}
			string[] Mon=new string[48]; 
			string[] tcode=new string[48]; 
			string str1="",period="";
			string str="select * from teachertimetable";
			sql=obj.GetRecordSet(str);
			if(sql.Read())
			{
				for(int j=2;j<sql.FieldCount-2;j++)
				{
					str1="select "+sql.GetName(j).ToString()+",shortname from teachertimetable where "+sql.GetName(j).ToString()+" like '"+cls+DropSec.SelectedItem.Text+"%'";
					dr=obj2.GetRecordSet(str1);
					while(dr.Read())
					{
						period=dr.GetValue(0).ToString();
						if(period.IndexOf("A")>0)
						{
							Mon[j-2]=period.Substring(period.IndexOf("A")+1,period.Length-period.IndexOf("A")-1);
							tcode[j-2]=dr.GetValue(1).ToString();
						}
						else if(period.IndexOf("B")>0)
						{
							Mon[j-2]=period.Substring(period.IndexOf("B")+1,period.Length-period.IndexOf("B")-1);
							tcode[j-2]=dr.GetValue(1).ToString();
						}
						else if(period.IndexOf("C")>0)
						{
							Mon[j-2]=period.Substring(period.IndexOf("C")+1,period.Length-period.IndexOf("C")-1);
							tcode[j-2]=dr.GetValue(1).ToString();
						}
						else if(period.IndexOf("D")>0)
						{
							Mon[j-2]=period.Substring(period.IndexOf("D")+1,period.Length-period.IndexOf("D")-1);
							tcode[j-2]=dr.GetValue(1).ToString();
						}
						else
						{
							Mon[j-2]=period;
							tcode[j-2]=dr.GetValue(1).ToString();
						}
										
					}
					dr.Close();
				}
				
			}
			sql.Close();
			
			string info="",info1="";;
			sw.WriteLine("                                          -------------------------");
			sw.WriteLine("		                           Class Wise Time Table") ;
			sw.WriteLine("                                          -------------------------");
			info1 = "                 {0,-12:S}{1,-13:S}                 {2,20:S}   {3,-20:S}";
			sw.WriteLine(info1,"Class:",DropClass.SelectedItem.Text,"Section:",DropSec.SelectedItem.Text);
			//sw.WriteLine("+---------+---------------+---------------+---------------+---------------+---------------+---------------+---------------+-------------+");
			sw.WriteLine("\t D / P \t   I      \t    II     \t    III    \t     IV     \t      V     \t      VI     \t     VII     \t     VIII   ");
			//sw.WriteLine("+---------+---------------+---------------+---------------+---------------+---------------+---------------+---------------+-------------+");
			//             123456789 123456789012345 123456789012345 123456789012345 123456789012345 123456789012345 123456789012345 123456789012345 1234567890123
			info = " {0,-9:S} {1,-15:S} {2,-15:S} {3,-15:S} {4,-15:S} {5,-15:S} {6,-15:S} {7,-15:S} {8,-13:S}";
			sw.WriteLine("Monday"+"\t"+tcode[0]+" "+Mon[0]+"\t"+tcode[1]+" "+Mon[1]+"\t"+tcode[2]+" "+Mon[2]+"\t"+tcode[3]+" "+Mon[3]+"\t"+tcode[4]+" "+Mon[4]+"\t"+tcode[5]+" "+Mon[5]+"\t"+tcode[6]+" "+Mon[6]+"\t"+tcode[7]+" "+Mon[7]);
			sw.WriteLine("Tuesday"+"\t"+tcode[8]+" "+Mon[8]+"\t"+tcode[9]+" "+Mon[9]+"\t"+tcode[10]+" "+Mon[10]+"\t"+tcode[11]+" "+Mon[11]+"\t"+tcode[12]+" "+Mon[12]+"\t"+tcode[13]+" "+Mon[13]+"\t"+tcode[14]+" "+Mon[14]+"\t"+tcode[15]+" "+Mon[15]);
			sw.WriteLine("Wednesday"+"\t"+tcode[16]+" "+Mon[16]+"\t"+tcode[17]+" "+Mon[17]+"\t"+tcode[18]+" "+Mon[18]+"\t"+tcode[19]+" "+Mon[19]+"\t"+tcode[20]+" "+Mon[20]+"\t"+tcode[21]+" "+Mon[21]+"\t"+tcode[22]+" "+Mon[22]+"\t"+tcode[23]+" "+Mon[23]);
			sw.WriteLine("ThursDay"+"\t"+tcode[24]+" "+Mon[24]+"\t"+tcode[25]+" "+Mon[25]+"\t"+tcode[26]+" "+Mon[26]+"\t"+tcode[27]+" "+Mon[27]+"\t"+tcode[28]+" "+Mon[28]+"\t"+tcode[29]+" "+Mon[29]+"\t"+tcode[30]+" "+Mon[30]+"\t"+tcode[31]+" "+Mon[31]);
			sw.WriteLine("Friday"+"\t"+tcode[32]+" "+Mon[32]+"\t"+tcode[33]+" "+Mon[33]+"\t"+tcode[34]+" "+Mon[34]+"\t"+tcode[35]+" "+Mon[35]+"\t"+tcode[36]+" "+Mon[36]+"\t"+tcode[37]+" "+Mon[37]+"\t"+tcode[38]+" "+Mon[38]+"\t"+tcode[39]+" "+Mon[39]);
			sw.WriteLine("Satday"+"\t"+tcode[40]+" "+Mon[40]+"\t"+tcode[41]+" "+Mon[41]+"\t"+tcode[42]+" "+Mon[42]+"\t"+tcode[43]+" "+Mon[43]+"\t"+tcode[44]+" "+Mon[44]+"\t"+tcode[45]+" "+Mon[45]+"\t"+tcode[46]+" "+Mon[46]+"\t"+tcode[47]+" "+Mon[47]);
			//sw.WriteLine("+---------+--------------+---------------+---------------+---------------+---------------+---------------+---------------+---------------+");
			sw.Close(); 
		}
	
	}


}
