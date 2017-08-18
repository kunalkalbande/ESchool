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
using System.Data.SqlClient;
using RMG;
using eschool.Classes;
using System.Net ;
using System.Net.Sockets ;
using System.IO ;
using System.Text ;

namespace eschool.Modules.StudentFees
{
	/// <summary>
	/// Summary description for FeesReceipt1.
	/// </summary>
	public class FeesReceipt : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox DropRecuID;
		protected System.Web.UI.WebControls.TextBox TxtFromdate;
		protected System.Web.UI.WebControls.TextBox Txttodate;
		protected System.Web.UI.WebControls.Button btnExcel;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Panel panfees;
		protected System.Web.UI.HtmlControls.HtmlButton Search;
		protected System.Web.UI.HtmlControls.HtmlButton BtnPrint;
		protected System.Web.UI.WebControls.TextBox Txtsname;
		protected System.Web.UI.WebControls.Label labname;

		public int i=1;
		string pass;
		double tution=0,security=0,diary=0,activity=0,admission=0,annual=0,envp=0,computer=0,science=0,games=0,late=0,house=0,reg=0,trans=0;
		protected System.Web.UI.WebControls.RequiredFieldValidator valid1;
		protected System.Web.UI.WebControls.ValidationSummary summry1;
		
		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for perticular user
		///</summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
            Txtsname.Attributes.Add("readonly", "readonly");

            try
			{
				pass=(Session["password"].ToString());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : FeesReceipt.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+pass   );		
				//Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				return; 
			}
			try
			{
				if(!Page .IsPostBack)
				{
					TxtFromdate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					Txttodate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
				}
				if(! IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="11";
					string SubModule="8";
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
				CreateLogFiles.ErrorLog(" Form : FeesReceipt.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
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
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Search.ServerClick += new System.EventHandler(this.Search_ServerClick);
			this.BtnPrint.ServerClick += new System.EventHandler(this.BtnPrint_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// Method for returning the student name by passing the student id.
		/// not in use.
		/// </summary>
		public string ShowStudentID(string seq_studentid)
		{
			string student_id="";
			try
			{
				SqlConnection con3;
				SqlCommand cmdselect3;
				SqlDataReader dtredit3;
				con3=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con3.Open ();
				cmdselect3 = new SqlCommand( "Select Student_ID From Student_record where seq_student_id='"+seq_studentid+"'", con3 );
				dtredit3 = cmdselect3.ExecuteReader();
				while (dtredit3.Read()) 
				{
					student_id = dtredit3.GetValue(0).ToString();
				}
				//
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : FeesReceipt.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
			return student_id;
		}
		/// <summary>
		/// Method for viewing the report on the datagrid.
		/// </summary>
		private void Search_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				SqlConnection conNorthwind;
				string  strSelect="";
				SqlCommand cmdSelect;
				conNorthwind = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);	
				
				strSelect = "select SR.Student_FName from Student_Record SR, recuringreceipt SL  where SR.student_ID ='"+DropRecuID.Text+"' and SL.student_ID ='"+DropRecuID.Text+"' and feesubdt between'"+GenUtil.str2MMDDYYYY(TxtFromdate.Text.ToString())+"'and'"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"'";
				conNorthwind.Open();
				cmdSelect = new SqlCommand(strSelect,conNorthwind );
				SqlDataReader sdr=cmdSelect.ExecuteReader();
				if(sdr.Read())
				{
					Txtsname.Text=sdr.GetString(0);
				}
				sdr.Close();
				
				strSelect = "select SR.Student_FName, SR.Student_Class,SL.fees_type,SL.fees_Amount,SL.payMode,case when (sl.draftno<>'' OR sl.draftno<>NULL) then sl.draftno else sl.chno end chno,SL.chBank,sl.chdate,sl.recuringID,sr.seq_student_id,sl.feesubdt,sl.period,sl.periodto,sl.amountdue,sl.remarks,sl.feesubdt,sl.latefee,sl.tution_fee,sl.computer_fee,sl.science_fee,sl.game_fee,sl.transport_fee,sl.securityfee,sl.Regfee,sl.diary_fee,sl.admission_fee,sl.annual_fee,sl.envp_fee,sl.activity_fee,sl.hostel_fee from Student_Record SR, recuringreceipt SL  where SR.student_ID ='"+DropRecuID.Text+"' and SL.student_ID ='"+DropRecuID.Text+"' and feesubdt between'"+GenUtil.str2MMDDYYYY(TxtFromdate.Text.ToString())+"'and'"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"'";
				
				cmdSelect = new SqlCommand(strSelect,conNorthwind );
				DataGrid1.DataSource = cmdSelect.ExecuteReader();
				DataGrid1.DataBind ();
				if(DataGrid1.Items.Count==0)
				{
					MessageBox.Show("No such record found");
					DataGrid1.Visible=false;
					DropRecuID.Text="";
					Txtsname.Text="";
					panfees.Visible=false;
					labname.Visible=false;
					Txtsname.Visible=false;
				}
				else
				{
					DataGrid1.Visible=true;
					panfees.Visible=true;
					labname.Visible=true;
					Txtsname.Visible=true;
					
				}

					
				
				CreateLogFiles.ErrorLog(" Form : FeesReceipt.aspx,Method  Search_ServerClick,  FeesReceipt Report Viewed forStudentID :"+DropRecuID.Text+",Userid :  "+ Session["Password"].ToString()   );		
			
				

			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : FeesReceipt.aspx,Method  Search_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ Session["Password"].ToString()   );		
			 
			}
		}

		/// <summary>
		/// Method for returning the student name by passing the student id.
		/// this method not in use.
		/// </summary>
		public void DataGrid1_ItemDataBound (object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			string Pay_mode= e.Item.Cells[6].Text.ToString();
			if(Pay_mode.Trim().Equals("Cheque") || Pay_mode.Trim().Equals("Card"))
			{
				SqlConnection con ;	 
				SqlCommand cmd;
				SqlDataReader dr;
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				string str="select Cheque_Date,Card_Date from StudentPaidFees where Student_ID=@Student_ID";
				cmd=new SqlCommand(str,con);
				
				cmd.Parameters.Add("@Student_ID",DropRecuID.Text.Trim());
				dr=cmd.ExecuteReader();
				string s1="";
				string s2="";
				while(dr.Read())
				{
					s1=GenUtil.trimDate(GenUtil.str2DDMMYYYY(dr.GetValue(0).ToString()));
					s2=GenUtil.trimDate(GenUtil.str2DDMMYYYY(dr.GetValue(1).ToString()));
				}
				if(s1.Trim().Equals("1/1/1900"))
					e.Item.Cells[8].Text="";
				else
					e.Item.Cells[8].Text=s1;
				if(s2.Trim().Equals("1/1/1900"))
					e.Item.Cells[11].Text="";
				else
					e.Item.Cells[11].Text=s2;
				dr.Close();
				
			}
			if((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem ) || (e.Item.ItemType == ListItemType.SelectedItem)  )
			{
				tution+=double.Parse(e.Item.Cells[5].Text);
				security+=double.Parse(e.Item.Cells[6].Text);
				diary+=double.Parse(e.Item.Cells[7].Text);
				activity+=double.Parse(e.Item.Cells[8].Text);
				admission+=double.Parse(e.Item.Cells[9].Text);
				annual+=double.Parse(e.Item.Cells[10].Text);
				envp+=double.Parse(e.Item.Cells[11].Text);
				computer+=double.Parse(e.Item.Cells[12].Text);
				science+=double.Parse(e.Item.Cells[13].Text);
				games+=double.Parse(e.Item.Cells[14].Text);
				late+=double.Parse(e.Item.Cells[15].Text);
				house+=double.Parse(e.Item.Cells[16].Text);
				reg+=double.Parse(e.Item.Cells[17].Text);
				trans+=double.Parse(e.Item.Cells[18].Text);

			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[5].Text=tution.ToString();
				e.Item.Cells[6].Text=security.ToString();
				e.Item.Cells[7].Text=diary.ToString();
				e.Item.Cells[8].Text=activity.ToString();
				e.Item.Cells[9].Text=admission.ToString();
				e.Item.Cells[10].Text=annual.ToString();
				e.Item.Cells[11].Text=envp.ToString();
				e.Item.Cells[12].Text=computer.ToString();
				e.Item.Cells[13].Text=science.ToString();
				e.Item.Cells[14].Text=games.ToString();
				e.Item.Cells[15].Text=late.ToString();
				e.Item.Cells[16].Text=house.ToString();
				e.Item.Cells[17].Text=reg.ToString();
				e.Item.Cells[18].Text=trans.ToString();
				
			}
		}
		/// <summary>
		/// this method use to generate Report in to text formate. data fetch from recuringreceipt table. Print Button.
		/// </summary>
		private void BtnPrint_ServerClick(object sender, System.EventArgs e)
		{
			try
			{ 
				string Total="";
				string home_drive = Environment.SystemDirectory ;
				string info = "";
				home_drive = home_drive.Substring (0,2);
				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\FeesReceiptReport.txt";
				StreamWriter sw = new StreamWriter(path); 
				SqlConnection conNorthwind;
				string  strSelect="";
				SqlCommand cmdSelect;
				SqlDataReader SqlDtr =null;
				conNorthwind = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				strSelect = "select SR.Student_FName, SR.Student_Class,SL.fees_type,SL.fees_Amount,SL.payMode,case when (sl.draftno<>'' OR sl.draftno<>NULL) then sl.draftno else sl.chno end chno,SL.chBank,sl.chdate,sl.recuringID,sr.seq_student_id,sl.feesubdt,sl.period,sl.periodto,sl.amountdue,sl.remarks,sl.feesubdt,sl.latefee,sl.tution_fee,sl.computer_fee,sl.science_fee,sl.game_fee,sl.transport_fee,sl.securityfee,sl.Regfee,sl.diary_fee,sl.admission_fee,sl.annual_fee,sl.envp_fee,sl.activity_fee,sl.hostel_fee from Student_Record SR, recuringreceipt SL  where SR.student_ID ='"+DropRecuID.Text+"' and SL.student_ID ='"+DropRecuID.Text+"' and feesubdt between'"+GenUtil.str2MMDDYYYY(TxtFromdate.Text.ToString())+"'and'"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"'";
				conNorthwind.Open();
				cmdSelect = new SqlCommand( strSelect, conNorthwind );
				sw.Write((char)27);
				sw.Write((char)67);
				sw.Write((char)0);
				sw.Write((char)12);
				sw.Write((char)27);
				sw.Write((char)78);
				sw.Write((char)5);
				sw.Write((char)27);
				sw.Write((char)15);
				string des="+---+---+---+-----+----------+----+----+----+----+----+----+----+----+----+----+----+----+----+-----+-------+-------+-----------+";
				//sw.WriteLine(GenUtil.GetCenterAddr("NO.1 Air Force School",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("FEES RECEIPT REPORT Of "+Txtsname.Text+"-"+DropRecuID.Text,des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Date From "+TxtFromdate.Text+" Date To "+Txttodate.Text,des.Length));
				sw.WriteLine("+---+---+---+-----+----------+----+----+----+----+----+----+----+----+----+----+----+----+----+-----+-------+-------+-----------+");
				sw.WriteLine("|SNo|Cls|Sec|RecNo|Rec Date  |Tutn|Secu|Diar|Actv|Admi|Annu|Envp|Comp|Scie|Game|Late|Hous|Reg |Trans|Amount |Cheq.No|ChequeDate |");
				sw.WriteLine("+---+---+---+-----+----------+----+----+----+----+----+----+----+----+----+----+----+----+----+-----+-------+-------+-----------+");
				//             123 123 123 12345 1234567890 1234 1234 1234 1234 1234 1234 1234 1234 1234 1234 1234 1234 1234 12345 1234567 1234567 12345678901
				info =" {0,-3:S} {1,-3:S} {2,3:S} {3,-5:S} {4,-10:S} {5,4:F} {6,4:S} {7,4:S} {8,4:S} {9,4:S} {10,4:S} {11,4:S} {12,4:S} {13,4:S} {14,4:S} {15,4:S} {16,4:S} {17,4:S} {18,5:S} {19,7:S} {20,-7:S} {21,-11:S}";
				SqlDtr = cmdSelect.ExecuteReader();
				if(SqlDtr.HasRows)
				{
					while(SqlDtr.Read())
					{
						sw.WriteLine(info,i.ToString(),
							//SqlDtr["student_class"].ToString().Trim (),
							GenUtil.TrimLength(SqlDtr["student_class"].ToString().Trim (),3),
							SqlDtr["Seq_student_id"].ToString().Trim (),
							SqlDtr["Recuringid"].ToString().Trim (),
							GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["feeSubdt"].ToString().Trim())),
							SqlDtr["Tution_fee"].ToString(),
							SqlDtr["Securityfee"].ToString(),
							SqlDtr["Diary_fee"].ToString(),
							SqlDtr["activity_fee"].ToString(),
							SqlDtr["Admission_fee"].ToString(),
							SqlDtr["Annual_fee"].ToString(),
							SqlDtr["Envp_fee"].ToString(),
							SqlDtr["Computer_fee"].ToString(),
							SqlDtr["science_fee"].ToString(),
							SqlDtr["Game_fee"].ToString(),
							SqlDtr["Latefee"].ToString(),
							SqlDtr["Hostel_fee"].ToString(),
							SqlDtr["Regfee"].ToString(),
							SqlDtr["Transport_fee"].ToString(),
							SqlDtr["Fees_Amount"].ToString(),
							SqlDtr["chno"].ToString().Trim (),
							GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["chdate"].ToString().Trim ()))
							);
						i++;
						tution+=double.Parse(SqlDtr["Tution_fee"].ToString());
						security+=double.Parse(SqlDtr["Securityfee"].ToString());
						diary+=double.Parse(SqlDtr["Diary_fee"].ToString());
						activity+=double.Parse(SqlDtr["activity_fee"].ToString());
						admission+=double.Parse(SqlDtr["Admission_fee"].ToString());
						annual+=double.Parse(SqlDtr["Annual_fee"].ToString());
						envp+=double.Parse(SqlDtr["Envp_fee"].ToString());
						computer+=double.Parse(SqlDtr["Computer_fee"].ToString());
						science+=double.Parse(SqlDtr["science_fee"].ToString());
						games+=double.Parse(SqlDtr["Game_fee"].ToString());
						late+=double.Parse(SqlDtr["Latefee"].ToString());
						house+=double.Parse(SqlDtr["Hostel_fee"].ToString());
						reg+=double.Parse(SqlDtr["Regfee"].ToString());
						trans+=double.Parse(SqlDtr["Transport_fee"].ToString());
						
					}		
					SqlDtr.Close();
					sw.WriteLine("+---+---+---+-----+----------+----+----+----+----+----+----+----+----+----+----+----+----+----+-----+-------+-------+-----------+");
					sw.WriteLine(info,"","","","","Total",tution.ToString(),security.ToString(),diary.ToString(),activity.ToString(),admission.ToString(),annual.ToString(),envp.ToString(),computer.ToString(),science.ToString(),games.ToString(),late.ToString(),house.ToString(),reg.ToString(),trans.ToString(),Cache["Amount"].ToString(),"","");
					sw.WriteLine("+---+---+---+-----+----------+----+----+----+----+----+----+----+----+----+----+----+----+----+-----+-------+-------+-----------+");
					sw.Close(); 
					Print();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :FeesReceipt.aspx,Method  BtnPrint_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}
		/// <summary>
		/// Method for getting only date part of the string.
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
		/// Method for seding the text file to the printer and issue the command to printer to print the report.
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\FeesReceiptReport.txt<EOF>");
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog(" Form :FeesReceipt.aspx,Method  BtnPrint_Click,  Fees Receipt Report Printed, Userid :  "+ pass);
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form :FeesReceipt.aspx,Method  BtnPrint_Click, Exception"+ ane.Message+",  Fees Receipt Report Printed, Userid :  "+ pass);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form :FeesReceipt.aspx,Method  BtnPrint_Click, Exception"+ se.Message+",  Fees Receipt Report Printed, Userid :  "+ pass);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form :FeesReceipt.aspx,Method  BtnPrint_Click, Exception"+ es.Message+",  Fees Receipt Report Printed, Userid :  "+ pass);
				}
		
			} 
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :FeesReceipt.aspx,Method  BtnPrint_Click, Exception: "+ex.Message+", Fees Receipt Report Printed, Userid :  "+ pass);
								
			}

		}
		/// <summary>
		/// this method use to Get Total of passed Amount
		/// </summary>
		double TotAmt=0;
		public string TotalAmt(string amt)
		{
			TotAmt+=double.Parse(amt);
			Cache["Amount"]=TotAmt.ToString();
			return GenUtil.strNumericFormat(amt);
		}
		/// <summary>
		/// this method use to call ConvertIntoExcel().
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				ConvertIntoExcel();
				MessageBox.Show("Successfully Convert File into Excel Format");
				CreateLogFiles.ErrorLog("Form:FeesReceipt.aspx,Method: btnExcel_Click, Fees Receipt Report Convert Into Excel Format ,  userid  "+pass);
			}
			catch(Exception ex)
			{
				MessageBox.Show("First Close The Open Excel File");
				CreateLogFiles.ErrorLog("Form:FeesReceipt.aspx,Method:btnExcel_Click   Fees Receipt Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+pass);
			}
		}
		/// <summary>
		/// this method use to generate Report in to excel formate. data fetch from recuringreceipt table. Print Button.
		/// </summary>
		public void ConvertIntoExcel()
		{
			try
			{
				int i=1;
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
				Directory.CreateDirectory(strExcelPath);
				string path = home_drive+@"\eSchool_ExcelFile\FeesReceiptReport.xls";
				StreamWriter sw = new StreamWriter(path);
				SqlConnection conNorthwind;
				string  strSelect="";
				SqlCommand cmdSelect;
				SqlDataReader SqlDtr =null;
				conNorthwind = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				
				strSelect = "select SR.Student_FName, SR.Student_Class,SL.fees_type,SL.fees_Amount,SL.payMode,case when (sl.draftno<>'' OR sl.draftno<>NULL) then sl.draftno else sl.chno end chno,SL.chBank,sl.chdate,sl.recuringID,sr.seq_student_id,sl.feesubdt,sl.period,sl.periodto,sl.amountdue,sl.remarks,sl.feesubdt,sl.latefee,sl.tution_fee,sl.computer_fee,sl.science_fee,sl.game_fee,sl.transport_fee,sl.securityfee,sl.Regfee,sl.diary_fee,sl.admission_fee,sl.annual_fee,sl.envp_fee,sl.activity_fee,sl.hostel_fee from Student_Record SR, recuringreceipt SL  where SR.student_ID ='"+DropRecuID.Text+"' and SL.student_ID ='"+DropRecuID.Text+"' and feesubdt between'"+GenUtil.str2MMDDYYYY(TxtFromdate.Text.ToString())+"'and'"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"'";
				conNorthwind.Open();
				cmdSelect = new SqlCommand( strSelect, conNorthwind );

				
				string des="+---+---+---+-----+----------+----+----+----+----+----+----+----+----+----+----+----+----+----+-----+-------+-------+-----------+";
				//sw.WriteLine(GenUtil.GetCenterAddr("NO.1 Air Force School",des.Length));
				
				sw.WriteLine(GenUtil.GetCenterAddr("FEES RECEIPT REPORT Of "+Txtsname.Text+"-"+DropRecuID.Text,des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Date From "+TxtFromdate.Text+" Date To "+Txttodate.Text,des.Length));
				sw.WriteLine("SNo\tCls\tSec\tRecNo\tRec Date\tTutn\tSecu\tDiar\tActv\tAdmi\tAnnu\tEnvp\tComp\tScie\tGame\tLate\tHous\tReg\tTrans\tAmount\tChequeNo\tCheque Date");
				SqlDtr = cmdSelect.ExecuteReader();
				if(SqlDtr.HasRows)
				{
					while(SqlDtr.Read())
					{
						sw.WriteLine(i.ToString()+"\t"+
							
							SqlDtr["student_class"].ToString().Trim ()+"\t"+
							SqlDtr["Seq_student_id"].ToString().Trim ()+"\t"+
							SqlDtr["Recuringid"].ToString().Trim ()+"\t"+
							GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["feeSubdt"].ToString().Trim()))+"\t"+
							SqlDtr["Tution_fee"].ToString()+"\t"+
							SqlDtr["Securityfee"].ToString()+"\t"+
							SqlDtr["Diary_fee"].ToString()+"\t"+
							SqlDtr["activity_fee"].ToString()+"\t"+
							SqlDtr["Admission_fee"].ToString()+"\t"+
							SqlDtr["Annual_fee"].ToString()+"\t"+
							SqlDtr["Envp_fee"].ToString()+"\t"+
							SqlDtr["Computer_fee"].ToString()+"\t"+
							SqlDtr["science_fee"].ToString()+"\t"+
							SqlDtr["Game_fee"].ToString()+"\t"+
							SqlDtr["Latefee"].ToString()+"\t"+
							SqlDtr["Hostel_fee"].ToString()+"\t"+
							SqlDtr["Regfee"].ToString()+"\t"+
							SqlDtr["Transport_fee"].ToString()+"\t"+
							SqlDtr["Fees_Amount"].ToString()+"\t"+
							SqlDtr["chno"].ToString().Trim ()+"\t"+
							GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["chdate"].ToString().Trim ()))
							);
						i++;
						tution+=double.Parse(SqlDtr["Tution_fee"].ToString());
						security+=double.Parse(SqlDtr["Securityfee"].ToString());
						diary+=double.Parse(SqlDtr["Diary_fee"].ToString());
						activity+=double.Parse(SqlDtr["activity_fee"].ToString());
						admission+=double.Parse(SqlDtr["Admission_fee"].ToString());
						annual+=double.Parse(SqlDtr["Annual_fee"].ToString());
						envp+=double.Parse(SqlDtr["Envp_fee"].ToString());
						computer+=double.Parse(SqlDtr["Computer_fee"].ToString());
						science+=double.Parse(SqlDtr["science_fee"].ToString());
						games+=double.Parse(SqlDtr["Game_fee"].ToString());
						late+=double.Parse(SqlDtr["Latefee"].ToString());
						house+=double.Parse(SqlDtr["Hostel_fee"].ToString());
						reg+=double.Parse(SqlDtr["Regfee"].ToString());
						trans+=double.Parse(SqlDtr["Transport_fee"].ToString());
					}
					
					SqlDtr.Close();
					sw.WriteLine("\t\t\t\tTotal\t"+tution.ToString()+"\t"+security.ToString()+"\t"+diary.ToString()+"\t"+activity.ToString()+"\t"+admission.ToString()+"\t"+annual.ToString()+"\t"+envp.ToString()+"\t"+computer.ToString()+"\t"+science.ToString()+"\t"+games.ToString()+"\t"+late.ToString()+"\t"+house.ToString()+"\t"+reg.ToString()+"\t"+trans.ToString()+"\t"+Cache["Amount"].ToString());
				}
				sw.Close(); 
				CreateLogFiles.ErrorLog(" Form :FeesReceipt.aspx,Method ConvertIntoExcel, DailyFeeReport View , Userid :  "+ pass   );
				
			}
			catch(Exception ex)
			{
				
				CreateLogFiles.ErrorLog(" Form : FeesReceipt.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}
	}
}
