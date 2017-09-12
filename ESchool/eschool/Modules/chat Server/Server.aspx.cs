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
using eschool.Classes;
using RMG;


namespace eschool.Modules.chat_Server
{
	/// <summary>
	/// Summary description for Server1.
	/// </summary>
	public class Server1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox lblName;
		protected System.Web.UI.WebControls.Label lblSub;
		protected System.Web.UI.WebControls.LinkButton lblogout;
		protected System.Web.UI.WebControls.TextBox listChatwin;
		protected System.Web.UI.WebControls.ListBox LisLogin;
		protected System.Web.UI.WebControls.TextBox txtmessagwin;
		protected System.Web.UI.WebControls.Button btnSend;
		SqlConnection cn;
		SqlCommand cmd;
		SqlDataReader dtr;
		string teach_id="";
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempPath;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempext;
		protected System.Web.UI.HtmlControls.HtmlInputText Selectedvalue;
		string pass;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values and also fill some 
		/// additional information and also check accessing priviledges for perticular user.
		///  this method use to save the record in session table only those person which are login.
		///  All the login user show in listbox. message Attech with user id save in cach object.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
            listChatwin.Attributes.Add("readonly", "readonly");

            try
			{
				pass=(Session["password"].ToString());
			}
			catch(Exception ex)
			{
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : Server.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				cn=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				cn.Open();
				try
				{
					string namepass=Session["password"].ToString().Trim()+":"+Session["userpass"].ToString().Trim();
					string Logname=Session["User_Name"].ToString().Trim();
					string str="";
					str="Select count(*) from session where session_id='"+namepass+"'";
					cmd=new SqlCommand(str,cn);
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
					cmd=new SqlCommand(str,cn);
					cmd.ExecuteNonQuery();
					dtr.Close();
					cmd.Dispose();

				}
				catch(Exception ex)
				{
					//CreateLogFiles.ErrorLog ("Form: Server.aspx.cs, Method: FillId. Exception: " + ex.Message + " User: " + Session["password"].ToString() );
				}

				try
				{
				
					string str="";
					string loginname=Session["password"].ToString().Trim();
					string passward=Session["userpass"].ToString().Trim();
					str="select Session_name from Session ";
					cmd=new SqlCommand(str,cn);
					dtr=cmd.ExecuteReader();
					LisLogin.Items.Clear();
					while(dtr.Read())
					{
						LisLogin.Items.Add(dtr.GetValue(0).ToString());
					}
					dtr.Close();
					cmd.Dispose();
										
					if(Selectedvalue.Value!="" && Selectedvalue.Value!=null)
					{
						LisLogin.SelectedValue=Selectedvalue.Value;
					}
					else
					{
						LisLogin.SelectedValue=Session["User_Name"].ToString().Trim();
					}
					
				}
				catch(Exception ex)
				{
					//CreateLogFiles.ErrorLog ("Form: Server.aspx.cs, Method: FillId. Exception: " + ex.Message + " User: " + Session["password"].ToString() );
				}

				try
				{

					if(Cache["teachmess"].ToString()!="" && Cache["teachmess"].ToString()!=null)
					{
						string emessag=Cache["teachmess"].ToString();
						string[] select=emessag.Split(new char[]{'-'},emessag.Length);
						string nameid=select[0].ToString();
						string sname=Session["User_Name"].ToString().Trim();
						if(nameid.ToString().Trim()==Session["User_Name"].ToString().Trim())
						{
							listChatwin.Text+=select[1].Trim().ToString()+ "\r\n";
						}
						Cache["teachmess"]="";
					}
				}
				catch(Exception ex)
				{
				
				}
				try
				{
					lblName.Text=Session["User_Name"].ToString().Trim();
					lblSub.Text=Session["Login_By"].ToString().Trim();
					btnSend.Enabled=false;

				}
				catch(Exception ex)
				{
					//
				}
				//Response.Write("<meta http-equiv=\"Refresh\"content=\"1\"src=\"http:\\localhost\\eschool\\Modules\\chat Server\\Chat_Room.aspx\">");

						
				if(! IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="10";
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
				
					#endregion
				
				}
				CreateLogFiles.ErrorLog (" Form: Server.aspx.cs, Method: Page_Load User: " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog (" Form: Server.aspx.cs, Method: Page_Load  Exception: " + ex.Message + " User: " + pass );
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
			this.lblogout.Click += new System.EventHandler(this.lblogout_Click);
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	
		/// <summary>
		/// This Method use to send Message one user to another user.
		/// </summary>
		private void btnSend_Click(object sender, System.EventArgs e)
		{
			try
			{
				string s=LisLogin.SelectedValue.ToString();
				Session["Selctname"]=s;
				listChatwin.Text+=lblName.Text + " : " +txtmessagwin.Text.ToString ()+ "\r\n" ;
				Cache["teachmess"]=Session["Selctname"]+" - "+lblName.Text + " : " +txtmessagwin.Text.ToString ()+ "\r\n";
				txtmessagwin.Text="";
				CreateLogFiles.ErrorLog(" Form : Server.aspx,Method  btnLogin_Click,  Userid :  "+ lblName.Text.ToString()   );						
		    }
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Server.aspx,Method  btnLogin_Click,  Exception :  "+ ex.Message.ToString()   );						
			}
			
		}

		/// <summary>
		/// this Method use to logout the user. and also delete record from session table and also save the message. 
		/// </summary>
		private void lblogout_Click(object sender, System.EventArgs e)
		{
			string Name_Id=Session["password"].ToString().Trim()+":"+Session["userpass"].ToString().Trim();
			string Date_Time=DateTime.Now.ToString();
			string Message=listChatwin.Text;
			Message=Message.Replace("\r\n",",");
			try
			{
				if(Message!="" && Message!=null)
				{
					cmd=new SqlCommand("insert into Chat_messaging( Name_ID,Description,Date_Time) values('"+Name_Id+"','"+Message+"','"+Date_Time+"')",cn);
					cmd.ExecuteNonQuery();
					cmd.Dispose();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Server.aspx.cs, Method: FillId. Exception: " + ex.Message + " User: " + pass );
			}
			try
			{
				teach_id= Session["password"].ToString().Trim()+":"+Session["userpass"].ToString().Trim();
				cmd=new SqlCommand("Delete from session where session_id='"+teach_id+"'",cn);
				cmd.ExecuteNonQuery();
				cmd.Dispose();
				Response.Redirect("~/LoginHome/Menu.aspx",false);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Server.aspx.cs, Method: FillId. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// This method use to attechment of a document file. but now this not in use.
		/// not in use.
		/// </summary>
		private void btndownload_Click(object sender, System.EventArgs e)
		{
			try
			{
				string filepath=Session["Path"].ToString().Trim();
				filepath=filepath.Substring(filepath.LastIndexOf('\\')+1).ToString();
				if(Session["Path"].ToString().Trim()!=null && Session["Exte"].ToString().Trim()!=null)
				{
					if(Session["Exte"].ToString().Trim()==".txt")
					{
						Response.ContentType="application/NotePad";
						Response.AddHeader("content-disposition","attechment; filename="+filepath.ToString()+".txt");
					}
					else
					{
						Response.ContentType="application/ms-Word";
						Response.AddHeader("content-disposition","attechment; filename="+filepath.ToString()+".doc");
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
