# region Using Directives...
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
using eschool.SchoolClass;
using System.Data.SqlClient;
using RMG;
using System.Text;
using eschool.Classes;
using MySecurity;

# endregion

namespace eschool.LoginHome
{
	/// <summary>
	/// Summary description for Login.
	/// </summary>
	public class Login : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropUser;
		protected System.Web.UI.WebControls.TextBox TxtUserName;
		protected System.Web.UI.WebControls.TextBox TxtPassword;
		protected System.Web.UI.WebControls.TextBox txt1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.RequiredFieldValidator TxtReqUserName;
		protected System.Web.UI.WebControls.RequiredFieldValidator TxtReqPassword;
		protected System.Web.UI.WebControls.ValidationSummary vsLogin;
		protected System.Web.UI.WebControls.CompareValidator cvSelect;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.CompareValidator Valicomp;
		protected System.Web.UI.WebControls.RequiredFieldValidator ValiReq;
		protected System.Web.UI.WebControls.RequiredFieldValidator ValiReq1;
		protected System.Web.UI.WebControls.ValidationSummary Summary1;
		protected System.Web.UI.WebControls.Button btnLogin;
	
		/// <summary>
		/// Page Load...
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			string check = "";
			/// check string gets the value from the check() method present in Security.dll;
			///** if syssts = 0 for Trial Peried and syssts = 1 for Activated and syssts=2 for Expired. in the systbl table.
			///** if syssts =2 then error occured "PROBLEM ENCOUNTERED AT THE SERVER SIDE PLEASE CONTACT bbnisys Technologies Pvt. Ltd."
			///** Solution :- insert the values (syssts=0, syssta =FromDate, sysend = ToDate and sysabbr = D) in the table systbl. 
			check = MySecurity.MySecurity.check();  
			/// If the return value is false then the activation period expired and redirect to the error.aspx
			if(check.Equals("false" ))
			{
				Response.Redirect(".\\error.aspx",false);
				return;
			}
			/// If the return value is Service then the Print_WindowsService is stopped and redirect to the Service.aspx
			if(check.Equals("Service"))
			{
				Response.Redirect(".\\Service.aspx",false);
				return;
			}
			/// If the return value is starts with P then dispaly the activation period. 
			if(!check.Equals(""))
			{
				if(!check.Equals("true") && check.StartsWith("P") )
				{
					lblMessage.Text = check.Substring(1).ToUpper()+" Left For Activation".ToUpper();
				}
			}
			Session.Clear();
			if(! IsPostBack)
			{
				txtDate.Text=System.DateTime.Now.Day+"/"+System.DateTime.Now.Month+"/"+System.DateTime.Now.Year;
				Response.Expires=System.DateTime.Now.Minute-1;
				Session["view"]=true;
				SchoolClass.SchoolMgs obj=new SchoolClass.SchoolMgs();
				SqlDataReader SqlDtr;
				string sql;
				sql="select Role_Name from Roles";
				SqlDtr=obj.GetRecordSet(sql);
				DropUser.Items.Add("---Select---");
				while(SqlDtr.Read())
				{
					DropUser.Items.Add(SqlDtr.GetValue(0).ToString()); 
				}
				SqlDtr.Close();
				
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
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		# region Clear Function...
		public void clear()
		{
			TxtUserName .Text="";
			TxtPassword .Text="";
            DropUser.SelectedIndex=0;
		
		}
		# endregion
		
		
		/// <summary>
		///add this function to check the blank textbox or not
		/// </summary>
		public bool checkValidity()
		{
			string err_msg = "";
			bool f = true;
			if(DropUser.SelectedItem.Text.Equals("---Select---")) 
			{
				err_msg = "_Please select User Type\n";
				f = false;
			}

			if(TxtUserName.Text.Trim().Equals(""))
			{
				err_msg = err_msg+"_Please enter Login Name\n";
				f =false;
			}

			if(TxtPassword.Text.Trim().Equals(""))
			{
				err_msg = err_msg + "_Please enter Password";
				f = false;
			}

			if(f == false)
			{
				MessageBox.Show(err_msg);
			}
				return f;

		}

		private void btnLogin_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(!checkValidity())
				{
					return;
				}
				SqlConnection con;
				SqlCommand cmdselect,cmd;
				SqlDataReader dtrdrive,dtr;
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				string sLoginName=TxtUserName.Text.Trim();
				string sPassword=TxtPassword.Text.Trim();
				string sUserType=DropUser.SelectedItem.Text.ToString().Trim();
				string LoginDate=txtDate.Text.Trim();
				//cmdselect = new SqlCommand("Select LoginName,Password,Role_Name From User_Master where LoginName='" + sLoginName + "'", con );
				cmdselect = new SqlCommand("Select LoginName,Password,Role_Name,UserFName,UserMName,UserLName From User_Master where LoginName='" + sLoginName + "'", con );
				dtrdrive = cmdselect.ExecuteReader();
				string sLoginConfirm="";
				string sPasswordConfirm="";
				string sRoleConfirm="";
				if(dtrdrive.HasRows )
				{
					while(dtrdrive.Read())
					{
						sLoginConfirm=Convert.ToString(dtrdrive.GetString(0).ToString().Trim());
						Session["password"]=sLoginName; 
						sPasswordConfirm=Convert.ToString(dtrdrive.GetString(1).ToString().Trim());
						sRoleConfirm=Convert.ToString(dtrdrive.GetString(2).ToString().Trim());
						Session["User_Type"]=sLoginName; 
						Session["Login_By"]=sRoleConfirm;
						Session["Login_Date"]=LoginDate;
						Session["User_Name"]=Convert.ToString(dtrdrive.GetString(3).ToString().Trim()+" "+Convert.ToString(dtrdrive.GetString(4).ToString().Trim())+" "+Convert.ToString(dtrdrive.GetString(5).ToString().Trim()));
					}
				}
				else
				{
					MessageBox.Show ("Invalid User Login");
					TxtUserName.Text="";
					return;
				}

				dtrdrive.Close();
				//cmdselect.Dispose();
				# region Valid User
						
				if(sUserType==sRoleConfirm)
				{
					if(sPassword==sPasswordConfirm)
					{
						string[,] Privileges=new string[200,6];

						#region Get The User Permission
					
							SchoolClass.SchoolMgs obj=new SchoolClass.SchoolMgs();
							SqlDataReader SqlDtr;
							string sql="select Module_id,SubModule_id,View_flg,Add_flg,Edit_flg,Delete_flg from Privileges where LoginName='"+ sLoginName +"'";
							SqlDtr=obj.GetRecordSet(sql);
						
							for(int i=0;SqlDtr.Read();i++)
							{
								for(int j=0;j<6;j++)	
								{
									Privileges[i,j]=SqlDtr.GetValue(j).ToString(); 
								}
							}
							SqlDtr.Close();
							Session["Privileges"]=Privileges;
							Session["password"]=sLoginName; 
							Session["userpass"]=sPassword; 
							//Response.Redirect ("Modules/Form/Menu.aspx",false);
							Response.Redirect ("Menu.aspx",false);
							#endregion

						//------mantain Session Table for ecoaching-----
                        string namepass=Session["password"].ToString().Trim()+":"+Session["userpass"].ToString().Trim();
						string Logname=Session["User_Name"].ToString().Trim();
						string str="";
						//MessageBox.Show(namepass+":"+Logname);
					/* str="Select count(*) from session where session_id='"+namepass+"'";
						cmd=new SqlCommand(str,con);
						int count1=0;
						dtr=cmd.ExecuteReader();
						if(dtr.Read())
						{
							count1=Convert.ToInt32(dtr.GetValue(0));
						}
						cmd.Dispose();
						dtr.Close();
						if(count1>0)
						{
							str="update session set expire=1 where session_id='"+namepass+"'";
						}
						else
						{
							str="insert into session (session_id,session_name,expire) values('"+namepass+"','"+Logname+"',1)";
						}
						cmd=new SqlCommand(str,con);
						cmd.ExecuteNonQuery();
						dtr.Close();
						cmd.Dispose();*/
						//----------------------------------------------
					}

					# region invalid Password
					else
					{
						MessageBox.Show("Invalid Password");
						TxtPassword.Text="";
						//Name :-Mahesh & Bhalchand, modified code :- 07/08/2006(dd/mm/yyyy), 
						//Changes :- add return 
						return;
					}
					# endregion
				}

				# endregion
				
				///Changes :- add region Invalid User Name
				# region invalid User Type
				else
				{
					MessageBox.Show("Invalid User Type");
					DropUser.SelectedIndex=0;
					//Name :-Mahesh & Bhalchand, modified code :- 07/08/2006(dd/mm/yyyy)
					return;
				}
				MySecurity.MySecurity.contactServer("[CD]"+convertDate(txtDate.Text));
				# endregion

				CreateLogFiles.ErrorLog(" Form : Login.aspx,Method  btnLogin_Click,  Userid :  "+ Session["password"].ToString()   );				
			}
					
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Login.aspx,Method  btnLogin_Click,  Exception: "+ex.Message+" , Userid :  "+ Session["password"].ToString()   );		
			}
		}

		
		/// /// <summary>
		/// this method returns the date in mm/dd/yyyy from dd/mm/yyyy string.
		/// </summary>
		public string convertDate(string strDate)
		{
			string[] strArr = strDate.Split(new char[] {'/'} , strDate.Length);
			return strArr[1]+"-"+strArr[0]+"-"+strArr[2];
		}
		
	}
}
