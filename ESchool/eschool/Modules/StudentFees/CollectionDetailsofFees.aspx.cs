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

namespace eschool.StudentFees
{
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
	using System.Data.SqlClient;
	using RMG;
	using eschool.Classes;
	using System.IO ;
	using System.Text;
	using System.Net ;
	using System.Net.Sockets;
	# endregion
	/// <summary>
	/// Summary description for CollectionDetailsofFees.
	/// </summary>
	public class CollectionDetailsofFees : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList DropClass;
		protected System.Web.UI.WebControls.DropDownList DropSec;
		protected System.Web.UI.WebControls.TextBox Txtfromdate;
		protected System.Web.UI.WebControls.TextBox Txttodate;
		protected System.Web.UI.HtmlControls.HtmlButton Search;
		protected System.Web.UI.HtmlControls.HtmlButton print;

		public string rank="";
		public string routename="";
		
		public string routeid="";
		public int count=0;
		public string stream="";

	    
		public string category="";
		public string section="";
		public string classid="";
		public string sname="";
		public double Total=0;
		public double Caution=0;
		public double TempCaution=0;
		public string student_id="";
		public double gTotal=0;

		public string[] feetype={"TUTION_FEE","COMPUTER_FEE","SCIENCE_FEE","GAMES_FEE","HOSTEL_FEE","DIARY_FEE","ANNUAL_FEE","ENVP_FEE","ADMISSION_FEE","CAUTION_FEE"};

		public string recdate="";
		protected System.Web.UI.HtmlControls.HtmlButton Exel;
		string pass;
		public double feeamount=0;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{

				
				pass=(Session["password"].ToString ());
				if(!Page .IsPostBack)
				{
                	
					//Add the student id into the dropdownbox.
					Txtfromdate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					Txttodate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					
					InventoryClass obj=new InventoryClass();
					SqlDataReader sdred=null;
					string str="select distinct student_class from student_record sr,recuringreceipt rr where rr.student_id=sr.student_id";
					sdred=obj.GetRecordSet(str);
					DropClass.Items.Clear();
					DropClass.Items.Add("Select");
					//DropClass.Items.Add("All");
					
					while(sdred.Read())
					{
						DropClass.Items .Add (sdred.GetValue(0).ToString());
					}		
					sdred.Close();
				}
			 
				if(!IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="7";
					string SubModule="21";
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
				CreateLogFiles.ErrorLog(" Form :CollectionDetailsofFee.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			    
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
			this.Search.ServerClick += new System.EventHandler(this.Search_ServerClick);
			this.print.ServerClick += new System.EventHandler(this.print_ServerClick);
			this.Exel.ServerClick += new System.EventHandler(this.Exel_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region DateConversion Function 

		//function to convert DDMMYY to MM/DD/YYYY
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
		#endregion


		private void Search_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				
				gTotal=0;
				InventoryClass obj=new InventoryClass();
				InventoryClass obj1=new InventoryClass();
				SqlDataReader SqlDtr=null,rdr;
				string  strSelect="";
				if(DropClass.SelectedIndex!=0||DropSec.SelectedIndex!=0)
				{
					if(!Txtfromdate.Text.Equals("")&&!Txttodate.Text.Equals(""))
					{
						
						//strSelect ="select rank,count(rank),student_stream from student_record where student_class='"+DropClass.SelectedItem.Text+"' and Seq_Student_id='"+DropSec.SelectedItem.Text+"' group by rank,student_stream";
						
						for(int i=0;i<feetype.Length-2;i++)
						{
							strSelect="select rank,count(rank),student_stream from student_record where student_class='"+DropClass.SelectedItem.Text+"' and Seq_Student_id='"+DropSec.SelectedItem.Text+"' group by rank,student_stream";
							SqlDtr=obj.GetRecordSet(strSelect);
							while(SqlDtr.Read())
							{
								rank=SqlDtr.GetString(0).ToString().Trim();
								count=System.Convert.ToInt32(SqlDtr.GetValue(1).ToString().Trim());
								stream=SqlDtr.GetString(2).ToString().Trim();
								feeamount= feesdecisionmonthly(rank,stream,"tution_fee");
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
								//								MessageBox.Show("FeeType:"+feetype[i]);
								//								MessageBox.Show("Count:"+count);
								//								MessageBox.Show("Feeamount:"+feeamount);
								//								MessageBox.Show("Total:"+Total);
								//recid=SqlDtr.GetValue(0).ToString().Trim();
								//gCount=gCount+count;
								gTotal=gTotal+Total;
							}
							SqlDtr.Close();
						}
						//strSelect="select (select route_name from route r where r.route_id= s.routeno),  s.routeno,count(s.routeno) from student_record s where s.student_class='"+DropClass.SelectedItem.Text+"' and s.Seq_Student_id='"+DropSec.SelectedItem.Text+"' and s.service_bus='Yes' group by s.routeno";
						//SqlDtr=obj.GetRecordSet(strSelect);

						for(int i=feetype.Length-2;i<feetype.Length;i++)
						{
							//strSelect="select rank,count(rank),student_stream from student_record where student_class='"+DropClass.SelectedItem.Text+"' and Seq_Student_id='"+DropSec.SelectedItem.Text+"' group by rank,student_stream";
							strSelect="select rank,count(rank),student_stream from student_record where student_class='"+DropClass.SelectedItem.Text+"' and Seq_Student_id='"+DropSec.SelectedItem.Text+"'  and student_id not in (select student_id from recuringreceipt) group by rank,student_stream";
							SqlDtr=obj.GetRecordSet(strSelect);
							while(SqlDtr.Read())
							{
								rank=SqlDtr.GetString(0).ToString().Trim();
								count=System.Convert.ToInt32(SqlDtr.GetValue(1).ToString().Trim());
								stream=SqlDtr.GetString(2).ToString().Trim();
								feeamount= feesdecisionmonthly(rank,stream,"tution_fee");
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
								//								MessageBox.Show("FeeType:"+feetype[i]);
								//								MessageBox.Show("Count:"+count);
								//								MessageBox.Show("Feeamount:"+feeamount);
								//								MessageBox.Show("Total:"+Total);
								//recid=SqlDtr.GetValue(0).ToString().Trim();
								//gCount=gCount+count;
								gTotal=gTotal+Total;

							}
							SqlDtr.Close();
						}
						strSelect="select (select trfee from route r where r.route_id= s.routeno),  s.routeno,count(s.routeno) from student_record s where s.student_class='"+DropClass.SelectedItem.Text+"' and s.Seq_Student_id='"+DropSec.SelectedItem.Text+"' and s.service_bus='Yes' group by s.routeno";
						SqlDtr=obj.GetRecordSet(strSelect);
					
						while(SqlDtr.Read())
						{
							//routename=SqlDtr.GetString(0).ToString().Trim();
							routename=SqlDtr.GetValue(0).ToString().Trim();
						    routeid=SqlDtr.GetValue(1).ToString().Trim();
							count=System.Convert.ToInt32(SqlDtr.GetValue(2).ToString().Trim());
							feeamount=feesdecisionmonthly(routeid);
							Total=count*feeamount;
							gTotal=gTotal+Total;
						}
						SqlDtr.Close();
					}
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :CollectionDetailsofFee.aspx,Method  Search_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				return;
			}	

		}



		# region PrintPre...
		private void BtnPrint_Click(object sender, System.EventArgs e)
		{
			try
			{
				Response .Redirect("../PrintPreview/feesduerptPrint.aspx");
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :CollectionDetailsofFees.aspx,Method BtnPrint_Click,  Exception: "+ex.Message+" , Userid :  "+ Session["Password"].ToString()   );		
				 
			}	
		}
		# endregion
		//Method for writing the report into the text file and call method to print the report.
		private void print_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				gTotal=0;
				string home_drive = Environment.SystemDirectory ;
				string info = "";
				home_drive = home_drive.Substring (0,2);
		
				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\CollectionFeeReport1.txt";
				StreamWriter sw = new StreamWriter(path); 
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr=null;
				string  strSelect="";
				if(DropClass.SelectedIndex!=0||DropSec.SelectedIndex!=0)
				{
					if(!Txtfromdate.Text.Equals("")&&!Txttodate.Text.Equals(""))
					{
						
						sw.Write((char)27);//added by vishnu
						sw.Write((char)67);//added by vishnu
						sw.Write((char)0);//added by vishnu
						sw.Write((char)12);//added by vishnu

						sw.Write((char)27);//added by vishnu
						sw.Write((char)78);//added by vishnu
						sw.Write((char)5);//added by vishnu

						//
						//						sw.Write((char)27);//added by vishnu
						//						sw.Write((char)78);//added by vishnu
						//						sw.Write((char)25);//added by vishnu

						sw.Write((char)27);//added by vishnu
						sw.Write((char)15);
				
						string des="|---------------+-----------+-------------+-------------+------------|";
						sw.WriteLine(GenUtil.GetCenterAddr("No.1 Air Force School",des.Length));
						sw.WriteLine(GenUtil.GetCenterAddr("COLLECTION DETAILS OF FEES",des.Length));
						sw.WriteLine(GenUtil.GetCenterAddr("------------------------------------------------------------------",des.Length));
						sw.WriteLine(GenUtil.GetCenterAddr("CLASS WISE QUARTERLY FEES FOR THE MONTH   "+ Txtfromdate.Text.Trim() + " TO "+Txttodate.Text.Trim(),des.Length));
						sw.WriteLine(GenUtil.GetCenterAddr("CLASS "+ DropClass.SelectedItem.Text.Trim()+" "+DropSec.SelectedItem.Text.Trim(),des.Length));
						sw.WriteLine(GenUtil.GetCenterAddr("------------------------------------------------------------------",des.Length));
						//info = " {0,-5:S} {1,-6:S} {2,-5:S} {3,-15:S} {4,-5:S} {5,-4:S} {6,-5:S} {7,-5:S} {8,-5:S} {9,-4:S} {10,-5:S} {11,-5:S} {12,-4:S} {13,-5:S} {14,-5:S} {15,-5:S} {16,-5:S} {17,-5:S} {18,-6:S}";
					
						info = " {0,-15:S}    {1,-11:S} {2,10:S} {3,13:S} {4,12:S}";
						string info1=" {0,-26:S}     {1,10:S} {2,13:S} {3,12:S}" ;
						string info2=" Grand Total                                             {0,12:S}" ;
						sw.WriteLine("|---------------+-----------+-------------+-------------+------------|");
						sw.WriteLine("| RANK          | STREAM    | FEE RATE    | STRENGTH    | AMOUNT     ");
						sw.WriteLine("|---------------+-----------+-------------+-------------+------------|");
						//123456789012345 12345678901 1234567890123 1234567890123 123456789012 
						//				string duration="",mon="";
						//				mon=GenUtil.ConvertMonthName(Txtfromdate.Text.ToString());
						//				if(mon.Length>=3)
						//					mon=mon.Substring(0,3);
						//				duration=mon + "-";
						//				mon=GenUtil.ConvertMonthName(Txttodate.Text.ToString());
						//				if(mon.Length>=3)
						//					mon=mon.Substring(0,3);
						//				duration=duration+mon;
						for(int i=0;i<feetype.Length-2;i++)
						{
							strSelect="select rank,count(rank),student_stream from student_record where student_class='"+DropClass.SelectedItem.Text+"' and Seq_Student_id='"+DropSec.SelectedItem.Text+"' group by rank,student_stream";
							SqlDtr=obj.GetRecordSet(strSelect);
							
							sw.Write((char)27);//added by vishnu
							sw.Write((char)45);//added by vishnu
							sw.Write((char)1);//added by vishnu

							sw.WriteLine(feetype[i]);

							sw.Write((char)27);//added by vishnu
							sw.Write((char)45);//added by vishnu
							sw.Write((char)0);//added by vishnu

							if(SqlDtr.HasRows)
							{
								while(SqlDtr.Read())
								{
									rank=SqlDtr.GetString(0).ToString().Trim();
									count=System.Convert.ToInt32(SqlDtr.GetValue(1).ToString().Trim());
									stream=SqlDtr.GetString(2).ToString().Trim();
									feeamount= feesdecisionmonthly(rank,stream,feetype[i]);
									Total=count*feeamount;
									gTotal=gTotal+Total;
									sw.WriteLine(info,rank.ToString(),stream.ToString(),feeamount.ToString(),count.ToString(),Total.ToString());
								}
							}
							SqlDtr.Close();
						}
						for(int i=feetype.Length-2;i<feetype.Length;i++)
						{
							//strSelect="select rank,count(rank),student_stream from student_record where student_class='"+DropClass.SelectedItem.Text+"' and Seq_Student_id='"+DropSec.SelectedItem.Text+"' group by rank,student_stream";
							strSelect="select rank,count(rank),student_stream from student_record where student_class='"+DropClass.SelectedItem.Text+"' and Seq_Student_id='"+DropSec.SelectedItem.Text+"'  and student_id not in (select student_id from recuringreceipt) group by rank,student_stream";
							SqlDtr=obj.GetRecordSet(strSelect);
							
							sw.Write((char)27);//added by vishnu
							sw.Write((char)45);//added by vishnu
							sw.Write((char)1);//added by vishnu

							sw.WriteLine(feetype[i]);

							sw.Write((char)27);//added by vishnu
							sw.Write((char)45);//added by vishnu
							sw.Write((char)0);//added by vishnu

							if(SqlDtr.HasRows)
							{
								while(SqlDtr.Read())
								{
									rank=SqlDtr.GetString(0).ToString().Trim();
									count=System.Convert.ToInt32(SqlDtr.GetValue(1).ToString().Trim());
									stream=SqlDtr.GetString(2).ToString().Trim();
									feeamount= feesdecisionmonthly(rank,stream,feetype[i]);
									Total=count*feeamount;
									gTotal=gTotal+Total;
									sw.WriteLine(info,rank.ToString(),stream.ToString(),feeamount.ToString(),count.ToString(),Total.ToString());
								}
							}
							SqlDtr.Close();
						}
				
								
						strSelect="select (select route_name from route r where r.route_id= s.routeno),  s.routeno,count(s.routeno) from student_record s where s.student_class='"+DropClass.SelectedItem.Text+"' and s.Seq_Student_id='"+DropSec.SelectedItem.Text+"' and s.service_bus='Yes' group by s.routeno";
						SqlDtr=obj.GetRecordSet(strSelect);

						sw.Write((char)27);//added by vishnu
						sw.Write((char)45);//added by vishnu
						sw.Write((char)1);//added by vishnu

						sw.WriteLine("TRANSPORT FEE");
						sw.Write((char)27);//added by vishnu
						sw.Write((char)45);//added by vishnu
						sw.Write((char)0);//added by vishnu


						while(SqlDtr.Read())
						{
							//routename=SqlDtr.GetString(0).ToString().Trim();
							
							routename=SqlDtr.GetValue(0).ToString().Trim();
							routeid=SqlDtr.GetValue(1).ToString().Trim();
							count=System.Convert.ToInt32(SqlDtr.GetValue(2).ToString().Trim());
							feeamount=feesdecisionmonthly(routeid);
							Total=count*feeamount;
							gTotal=gTotal+Total;
							sw.WriteLine(info1,routename.ToString(),feeamount.ToString(),count.ToString(),Total.ToString());
						}
						SqlDtr.Close();

						sw.WriteLine("|---------------+-----------+-------------+-------------+------------|");
						//				string info1="Grand Total                                            {0,5:S} {1,5:S} {2,5:S} {3,4:S} {4,5:S} {5,5:S} {6,4:S} {7,5:S} {8,5:S} {9,5:S} {10,5:S} {11,5:S} {12,5:S} {13,6:S}";
						//				sw.WriteLine(info1,gtutionfee.ToString(),gcomputerfee.ToString(),ghousefee.ToString(),ggamefee.ToString(),gsciencefee.ToString(),
						//					gregistraionfee.ToString(),glatefee.ToString(),gadmissionfee.ToString(),gtransportfee.ToString(),gdevelopmentfee.ToString(),
						//					gdairyfee.ToString(),gannualfee.ToString(),gsecurity.ToString(),gtotal.ToString());
						//				sw.WriteLine("----+-----+--------+-----+------------+----+-+--------+-----+-----+-----+----+-----+-----+----+-----+-----+-----+-----+-----+-----+------");
						//				//sw.WriteLine("+----+------+--------+-----+---------------+---+---+--------+-----+-----+-----+----+-----+-----+----+-----+-----+-----+-----+-----+-----+------+");
						//				//sw.WriteLine("+-----+------+-----+---------------+-----+----+-----+-----+-----+----+-----+-----+----+-----+-----+-----+-----+-----+-----+------+");
						sw.WriteLine(info2,gTotal.ToString());
						sw.WriteLine("|---------------+-----------+-------------+-------------+------------|");
						sw.Close();
						Print();
					}
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :CollectionDetailsofFees.aspx,Method  BtnPrint_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}
		

		public void ConvertIntoExcel()
		{
			try
			{
				int j=1;
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
				Directory.CreateDirectory(strExcelPath);
				string path = home_drive+@"\eSchool_ExcelFile\CollectionFeesReport.xls";
				StreamWriter sw = new StreamWriter(path);
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr;
				string  strSelect="";
				if(DropClass.SelectedIndex!=0||DropSec.SelectedIndex!=0)
				{
					if(!Txtfromdate.Text.Equals("")&&!Txttodate.Text.Equals(""))
					{
									
						string des="|---------------+-----------+-------------+-------------+------------|";
						sw.WriteLine(GenUtil.GetCenterAddr("\t\tNo.1 Air Force School",des.Length));
						sw.WriteLine(GenUtil.GetCenterAddr("\t\tCOLLECTION DETAILS OF FEES",des.Length));
						//sw.WriteLine(GenUtil.GetCenterAddr("------------------------------------------------------------------",des.Length));
						sw.WriteLine(GenUtil.GetCenterAddr("CLASS WISE QUARTERLY FEES FOR THE MONTH   "+ Txtfromdate.Text.Trim() + " TO "+Txttodate.Text.Trim(),des.Length));
						sw.WriteLine(GenUtil.GetCenterAddr("\t\tCLASS "+ DropClass.SelectedItem.Text.Trim()+" "+DropSec.SelectedItem.Text.Trim(),des.Length));
						
						sw.WriteLine("S.No\tRANK          \t STREAM    \t FEE RATE    \t STRENGTH    \t AMOUNT     ");
						for(int i=0;i<feetype.Length-2;i++)
						{
							strSelect="select rank,count(rank),student_stream from student_record where student_class='"+DropClass.SelectedItem.Text+"' and Seq_Student_id='"+DropSec.SelectedItem.Text+"' group by rank,student_stream";
							SqlDtr=obj.GetRecordSet(strSelect);
							
							sw.WriteLine("\t\t\t"+feetype[i]);

							if(SqlDtr.HasRows)
							{
								while(SqlDtr.Read())
								{
									rank=SqlDtr.GetString(0).ToString().Trim();
									count=System.Convert.ToInt32(SqlDtr.GetValue(1).ToString().Trim());
									stream=SqlDtr.GetString(2).ToString().Trim();
									feeamount= feesdecisionmonthly(rank,stream,feetype[i]);
									Total=count*feeamount;
									gTotal=gTotal+Total;
									//sw.WriteLine(info,rank.ToString(),stream.ToString(),feeamount.ToString(),count.ToString(),Total.ToString());
									sw.WriteLine(j.ToString()+"\t"+rank.ToString()+"\t"+stream.ToString()+"\t"+feeamount.ToString()+"\t"+count.ToString()+"\t"+Total.ToString());
									j++;
								}
							}
							SqlDtr.Close();
						}
						for(int i=feetype.Length-2;i<feetype.Length;i++)
						{
							//strSelect="select rank,count(rank),student_stream from student_record where student_class='"+DropClass.SelectedItem.Text+"' and Seq_Student_id='"+DropSec.SelectedItem.Text+"' group by rank,student_stream";
							strSelect="select rank,count(rank),student_stream from student_record where student_class='"+DropClass.SelectedItem.Text+"' and Seq_Student_id='"+DropSec.SelectedItem.Text+"'  and student_id not in (select student_id from recuringreceipt) group by rank,student_stream";
							SqlDtr=obj.GetRecordSet(strSelect);
													
							sw.WriteLine("\t\t\t"+feetype[i]);
							
							if(SqlDtr.HasRows)
							{
								while(SqlDtr.Read())
								{
									rank=SqlDtr.GetString(0).ToString().Trim();
									count=System.Convert.ToInt32(SqlDtr.GetValue(1).ToString().Trim());
									stream=SqlDtr.GetString(2).ToString().Trim();
									feeamount= feesdecisionmonthly(rank,stream,feetype[i]);
									Total=count*feeamount;
									gTotal=gTotal+Total;
									//sw.WriteLine(info,rank.ToString(),stream.ToString(),feeamount.ToString(),count.ToString(),Total.ToString());
									sw.WriteLine(j.ToString()+"\t"+rank.ToString()+"\t"+stream.ToString()+"\t"+feeamount.ToString()+"\t"+count.ToString()+"\t"+Total.ToString());
									j++;
								}
							}
							SqlDtr.Close();
						}
				
								
						strSelect="select (select route_name from route r where r.route_id= s.routeno),  s.routeno,count(s.routeno) from student_record s where s.student_class='"+DropClass.SelectedItem.Text+"' and s.Seq_Student_id='"+DropSec.SelectedItem.Text+"' and s.service_bus='Yes' group by s.routeno";
						SqlDtr=obj.GetRecordSet(strSelect);

						sw.WriteLine("\t\t\tTRANSPORT FEE");
						while(SqlDtr.Read())
						{
							//routename=SqlDtr.GetString(0).ToString().Trim();
							
							routename=SqlDtr.GetValue(0).ToString().Trim();
							routeid=SqlDtr.GetValue(1).ToString().Trim();
							count=System.Convert.ToInt32(SqlDtr.GetValue(2).ToString().Trim());
							feeamount=feesdecisionmonthly(routeid);
							Total=count*feeamount;
							gTotal=gTotal+Total;
							sw.WriteLine(j.ToString()+"\t"+rank.ToString()+"\t"+stream.ToString()+"\t"+feeamount.ToString()+"\t"+count.ToString()+"\t"+Total.ToString());
							j++;
							//sw.WriteLine(info1,routename.ToString(),feeamount.ToString(),count.ToString(),Total.ToString());
						}
						SqlDtr.Close();
						sw.WriteLine("Gross Total\t\t\t\t\t"+gTotal.ToString());
						sw.Close();
						Print();
					}
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :CollectionDetailsofFees.aspx,Method  ConvertIntoExcel,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

  
		//Method for sending the text file to the printer
		public void Print()
		{
			
	
			byte[] bytes = new byte[1024];

			// Connect to a remote device.
			try 
			{
				
				
				// Establish the remote endpoint for the socket.
				// The name of the
				// remote device is "host.contoso.com".
				IPHostEntry ipHostInfo = Dns.Resolve("127.0.0.1");
				IPAddress ipAddress = ipHostInfo.AddressList[0];
				IPEndPoint remoteEP = new IPEndPoint(ipAddress,63000);

				// Create a TCP/IP  socket.
				Socket sender1 = new Socket(AddressFamily.InterNetwork, 
					SocketType.Stream, ProtocolType.Tcp );

				// Connect the socket to the remote endpoint. Catch any errors.
				try 
				{
					sender1.Connect(remoteEP);
   					 
					Console.WriteLine("Socket connected to {0}",
						sender1.RemoteEndPoint.ToString());

					// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2);
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\CollectionFeeReport1.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
 
					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));

					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog(" Form :CollectionDetailsofFees.aspx,Method  Print_Click, Collection Details of Fees Report Printed, Userid :  "+ pass);
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form :CollectionDetailsofFees.aspx,Method  Print_Click, Exception"+ ane.Message+", Collection Details of Fees Report  Printed, Userid :  "+ pass);
				} 
     
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form :CollectionDetailsofFees.aspx,Method  Print_Click, Exception"+ se.Message+",  Collection Details of Fees Report Printed, Userid :  "+ pass);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form :CollectionDetailsofFees.aspx,Method  Print_Click, Exception"+ es.Message+",  Collection Details of Fees Report Printed, Userid :  "+ pass);
				}
			} 
			
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :CollectionDetailsofFees.aspx,Method  Print_Click,Esception:"+ex.Message +", Collection Details of Fees Report Printed, Userid :  "+ pass);
			}

		}


		//		public  double feesdecisionmonthly(string rank,string stream,string fees_type)//added by vishnu
		//		{
		//			category="";
		//			//stream="";
		//
		//			double feeamount=0;
		//			try
		//			{
		//				InventoryClass obj=new InventoryClass();
		//				InventoryClass obj1=new InventoryClass();
		//				SqlDataReader SqlDtr=null,rdr=null;
		//				string str="",str1="";
		//				string startfrom=""; 
		//				string endto="";
		//				if(!rank.Equals(""))
		//				{
		//					startfrom=GenUtil.ConvertMonthName(Txtfromdate.Text);
		//					startfrom=startfrom.Substring(0,startfrom.Trim().Length-4).Trim();
		//					endto=GenUtil.ConvertMonthName(Txttodate.Text);
		//					endto=endto.Substring(0,endto.Trim().Length-4).Trim();
		//					System.TimeSpan diff=ToMMddYYYY(Txttodate.Text).Subtract(ToMMddYYYY(Txtfromdate.Text));
		//					int idays=diff.Days;
		//					int month=(idays+1)/30;
		//					string duration =startfrom+"-"+endto;
		//		
		//					//str="select * from feesdecision where class_id=(select class_id from class where class_name='"+classid+"') and Student_Stream='"+stream+"' and feemode='Monthly' and srank='"+rank+"' and fromdate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
		//					str="select * from feesdecision where class_id=(select class_id from class where class_name='"+DropClass.SelectedItem.Text+"') and Student_Stream='"+stream+"' and feemode='Monthly' and srank='"+rank+"' and fromdate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
		//					SqlDtr=obj.GetRecordSet(str);
		//					if(SqlDtr.Read())
		//					{
		//						str1="select * from feesdecision where class_id=(select class_id from class where class_name='"+DropClass.SelectedItem.Text+"') and Student_Stream='"+stream+"' and feemode='One Time' and srank='"+rank+"' and fromdate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
		//						rdr=obj1.GetRecordSet(str1);
		//						if(rdr.Read())
		//						{
		//							feeamount=double.Parse(rdr[fees_type].ToString());
		//							if(feeamount!=0)
		//							{
		//								rdr.Close();
		//								SqlDtr.Close();
		//								return feeamount;
		//							}
		//						}
		//						else
		//						{
		//							MessageBox.Show("Please enter one time fees in Fees Decision table");
		//							return 0;
		//						}
		//						rdr.Close();
		//												
		//						if(startfrom.Equals("April"))
		//						{
		//							//str="select * from feesdecision where class_id=(select class_id from class where class_name='"+classid+"') and Student_Stream='"+stream+"' and feemode='Yearly' and srank='"+rank+"'"; //added by vi
		//							//str="select * from feesdecision where class_id=(select class_id from class where class_name='"+classid+"') and Student_Stream='"+stream+"' and feemode='Yearly' and srank='"+rank+"' and fromdate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
		//							str="select * from feesdecision where class_id=(select class_id from class where class_name='"+DropClass.SelectedItem.Text+"') and Student_Stream='"+stream+"' and feemode='Yearly' and srank='"+rank+"' and fromdate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
		//							rdr=obj1.GetRecordSet(str);
		//							if(rdr.Read())
		//							{
		//								feeamount=double.Parse(rdr[fees_type].ToString());
		//								if(feeamount!=0)
		//								{
		//									rdr.Close();
		//									SqlDtr.Close();
		//									return feeamount;
		//								}
		//							}
		//							else
		//							{
		//								MessageBox.Show("Please enter the yearly fees in Fees Decision table");
		//								//return;
		//								rdr.Close();
		//								SqlDtr.Close();
		//								return 0;
		//							}
		//							rdr.Close();
		//						}
		//						if(month>=0)
		//						{
		//							feeamount=month*double.Parse(SqlDtr[fees_type].ToString());
		//							SqlDtr.Close();	
		//							rdr.Close();	
		//							return feeamount;	
		//						}
		//					}
		//				}
		//			}
		//			catch(Exception ex)
		//			{
		//				MessageBox.Show("Some Database problem");
		//				CreateLogFiles.ErrorLog(" Form : RecuringFeesReceipt.aspx,Method  btnSave_Click,  Exception: "+ex.Message+" , Userid :  "+ Session["password"].ToString()   );		
		//				//return ;
		//				return 0;
		//			}
		//			return feeamount;
		//		}
		public  double feesdecisionmonthly(string rank,string stream,string fees_type)//added by vishnu
		{
			category="";
			//stream="";

			double feeamount=0;
			try
			{
				InventoryClass obj=new InventoryClass();
				InventoryClass obj1=new InventoryClass();
				SqlDataReader SqlDtr=null,rdr=null;
				string str="",str1="";
				string startfrom=""; 
				string endto="";
				if(!rank.Equals(""))
				{
					startfrom=GenUtil.ConvertMonthName(Txtfromdate.Text);
					startfrom=startfrom.Substring(0,startfrom.Trim().Length-4).Trim();
					endto=GenUtil.ConvertMonthName(Txttodate.Text);
					endto=endto.Substring(0,endto.Trim().Length-4).Trim();
					System.TimeSpan diff=ToMMddYYYY(Txttodate.Text).Subtract(ToMMddYYYY(Txtfromdate.Text));
					int idays=diff.Days;
					int month=(idays+1)/30;
					string duration =startfrom+"-"+endto;
		
					
					str="select * from feesdecision where class_id=(select class_id from class where class_name='"+DropClass.SelectedItem.Text+"') and Student_Stream='"+stream+"' and feemode='Monthly' and srank='"+rank+"' and fromdate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
					SqlDtr=obj.GetRecordSet(str);
					if(SqlDtr.Read())
					{
						str1="select * from feesdecision where class_id=(select class_id from class where class_name='"+DropClass.SelectedItem.Text+"') and Student_Stream='"+stream+"' and feemode='One Time' and srank='"+rank+"' and fromdate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
						rdr=obj1.GetRecordSet(str1);
						if(rdr.Read())
						{
							feeamount=double.Parse(rdr[fees_type].ToString());
							if(feeamount!=0)
							{
								rdr.Close();
								SqlDtr.Close();
								return feeamount;
							}
						}
						else
						{
							MessageBox.Show("Please enter one time fees in Fees Decision table");
							return 0;
						}
						rdr.Close();
												
						if(startfrom.Equals("April"))
						{
							//str="select * from feesdecision where class_id=(select class_id from class where class_name='"+classid+"') and Student_Stream='"+stream+"' and feemode='Yearly' and srank='"+rank+"'"; //added by vi
							//str="select * from feesdecision where class_id=(select class_id from class where class_name='"+classid+"') and Student_Stream='"+stream+"' and feemode='Yearly' and srank='"+rank+"' and fromdate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
							str="select * from feesdecision where class_id=(select class_id from class where class_name='"+DropClass.SelectedItem.Text+"') and Student_Stream='"+stream+"' and feemode='Yearly' and srank='"+rank+"' and fromdate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
							rdr=obj1.GetRecordSet(str);
							if(rdr.Read())
							{
								feeamount=double.Parse(rdr[fees_type].ToString());
								if(feeamount!=0)
								{
									rdr.Close();
									SqlDtr.Close();
									return feeamount;
								}
							}
							else
							{
								MessageBox.Show("Please enter the yearly fees in Fees Decision table");
								//return;
								rdr.Close();
								SqlDtr.Close();
								return 0;
							}
							rdr.Close();
						}
						if(month>=0)
						{
							feeamount=month*double.Parse(SqlDtr[fees_type].ToString());
							SqlDtr.Close();	
							rdr.Close();	
							return feeamount;	
						}
					}
					
					
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Some Database problem");
				CreateLogFiles.ErrorLog(" Form : CollectionDetailsoffee.aspx,Method  feesdecisionmonthly,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				//return ;
				return 0;
			}
			return feeamount;
		}

		private void Exel_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				ConvertIntoExcel();
				MessageBox.Show("Successfully Convert File into Excel Format");
				CreateLogFiles.ErrorLog("Form:CollectionDetailsoffee.aspx,Method: btnExcel_Click, Collection Details of Fee Report Convert Into Excel Format ,  userid  "+pass);
			}
			catch(Exception ex)
			{
				MessageBox.Show("First Close The Open Excel File");
				CreateLogFiles.ErrorLog("Form:CollectionDetailsoffee.aspx,Method:btnExcel_Click   Collection Details of Fee Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+pass);
			}
		}
		
		

		public  double feesdecisionmonthly(string rootid)//added by vishnu
		{
			category="";
			double feeamount=0;
			
			try
			{
				InventoryClass obj=new InventoryClass();
				InventoryClass obj1=new InventoryClass();
				SqlDataReader rdr=null;
				string str1="";
				string startfrom=""; 
				string endto="";
				
				if(!rank.Equals(""))
				{
					startfrom=GenUtil.ConvertMonthName(Txtfromdate.Text);
					startfrom=startfrom.Substring(0,startfrom.Trim().Length-4).Trim();
					endto=GenUtil.ConvertMonthName(Txttodate.Text);
					endto=endto.Substring(0,endto.Trim().Length-4).Trim();
					System.TimeSpan diff=ToMMddYYYY(Txttodate.Text).Subtract(ToMMddYYYY(Txtfromdate.Text));
					int idays=diff.Days;
					int month=(idays+1)/30;
					string duration =startfrom+"-"+endto;
					if(month>=0)
					{
						if(!startfrom.Equals("")&&!endto.Equals(""))
						{
							//if(startfrom.Equals("April") && endto.Equals("June")&&(DropClass.SelectedItem.Text.Trim().Equals("XI")))
							if(startfrom.Equals("April") &&(DropClass.SelectedItem.Text.Trim().Equals("XI")))
							{
								//str1="select trfee from route where route_id=(select routeno from student_record where student_id='"+student_id+"' and service_bus='Yes')";
								str1="select trfee from route where route_id="+rootid+" and fromdate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
								rdr=obj1.GetRecordSet(str1);
								if(rdr.Read())
								{
									feeamount=(month-3)*double.Parse(rdr["trfee"].ToString());
								}
								else
								{
									feeamount=0;
								}
								rdr.Close();
							}
								//else if(startfrom.Equals("April") && endto.Equals("June") )
							else if(startfrom.Equals("April"))
							{
								//str1="select trfee from route where route_id=(select routeno from student_record where student_id='"+student_id+"' and service_bus='Yes')";
								//str1="select trfee from route where route_id=(select routeno from student_record where student_id='"+student_id+"' and service_bus='Yes') and fromdate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
								str1="select trfee from route where route_id="+rootid+" and fromdate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
								rdr=obj1.GetRecordSet(str1);
								if(rdr.Read())
								{
									feeamount=(month-1)*double.Parse(rdr["trfee"].ToString());
								}
								else
								{
									feeamount=0;
								}
								rdr.Close();
							}
							else
							{
								//str1="select trfee from route where route_id=(select routeno from student_record where student_id='"+student_id+"' and service_bus='Yes')";
										
								//str1="select trfee from route where route_id=(select routeno from student_record where student_id='"+student_id+"' and service_bus='Yes') and fromdate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
								str1="select trfee from route where route_id="+rootid+" and fromdate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";

								rdr=obj1.GetRecordSet(str1);
								if(rdr.Read())
								{
									feeamount=month*double.Parse(rdr["trfee"].ToString());
								}
								else
								{
									feeamount=0;
								}
								rdr.Close();
							}
						}
						else
						{
							feeamount=0;
						}
								
						return feeamount;
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Some Database problem");
				CreateLogFiles.ErrorLog(" Form : RecuringFeesReceipt.aspx,Method  btnSave_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				return 0;
			}
			return feeamount;
		}
	}
}
