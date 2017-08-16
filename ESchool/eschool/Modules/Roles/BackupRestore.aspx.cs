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
using System.IO;
using System.Text; 
using eschool.Classes;  
using RMG;
using System.Net;
using System.Net.Sockets;
using System.Data.SqlClient;
namespace Eschool
{
	/// <summary>
	/// Summary description for Backup_Restore.
	/// </summary>
	public class BackupRestore : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnBackup;
		protected System.Web.UI.WebControls.Button btnRestore;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempPath;
		string pass="";
		static int Flag=0;

		/// <summary>
		/// This method is used for setting the Session variable for userId
		/// and also check accessing priviledges for perticular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				pass=(Session["password"].ToString ());
			}
			catch(Exception ex)
			{
				//Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog(" Form : Backup_Restore.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+pass);		
				return;
			}
			if(! IsPostBack)
			{
				Flag=0;
				btnRestore.Enabled=false;
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="1";
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
			this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
			this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	
		/// <summary>
		/// This method is used to take backup in .bak format and stored in C:\ePetroBackup\Son location by sql query.
		/// </summary>
		private void btnBackup_Click(object sender, System.EventArgs e)
		{
			try
			{
					
				SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				string main_drive = Environment.SystemDirectory;
				string drive = main_drive.Substring(0,2);
				string strGrandFather  = drive+"\\eSchoolBackup\\GrandFather\\";
				string strFather       = drive+"\\eSchoolBackup\\Father\\";
				string strSon          = drive+"\\eSchoolBackup\\Son\\";
				string strDataBase = "bbnschool.bak";
				bool blnGrandFather=false, blnFather=false, blnSon=false;
				int Count=0;
				Directory.CreateDirectory(strGrandFather);
				Directory.CreateDirectory(strFather);
				Directory.CreateDirectory(strSon);
				if (File.Exists(strGrandFather + strDataBase)) 
					blnGrandFather = true;
				if (File.Exists(strFather + strDataBase)) 
					blnFather = true;
				if (File.Exists(strSon + strDataBase)) 
					blnSon = true;

				/// Start Backing...
				if (blnGrandFather == true && blnFather == true && blnSon == true)
				{
					/// Father ---> GrandFather
					File.Copy(strFather + strDataBase, strGrandFather + strDataBase, true);
					/// Son ---> Father
					File.Copy(strSon + strDataBase, strFather + strDataBase, true);
					/// MS-SQL ---> Son
				}
				else
				{
					con.Open();
					SqlCommand cmd = new SqlCommand("BACKUP DATABASE [bbnschool] TO  DISK = N'C:\\eSchoolBackup\\Son\\bbnschool.bak' WITH NOFORMAT, INIT,  NAME = N'bbnschool-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10",con);
					cmd.ExecuteNonQuery();
					cmd.Dispose();
					con.Close();
					System.Threading.Thread.Sleep(1000 * 5);
					Count=1;
					///MS-SQL ---> GrandFather
					File.Copy(strSon + strDataBase, strGrandFather + strDataBase, true);
					///MS-SQL ---> Father
					File.Copy(strSon + strDataBase, strFather + strDataBase, true);
					///MS-SQL ---> Son
				}
				
				if(Count==0)
				{
					con.Open();
					SqlCommand cmd = new SqlCommand("BACKUP DATABASE [bbnschool] TO  DISK = N'C:\\eSchoolBackup\\Son\\eSchool.bak' WITH NOFORMAT, INIT,  NAME = N'bbnschool-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10",con);
					cmd.ExecuteNonQuery();
					cmd.Dispose();
					con.Close();
					System.Threading.Thread.Sleep(1000 * 5);
				}
				MessageBox.Show("Backup Successfully Completed");
				
				CreateLogFiles.ErrorLog(" Form : BackupRestore.aspx,Method : btnBackup_Click : userid  "+pass );		
			}
			catch(Exception ex)
			{
				//CreateLogFiles.ErrorLog("Form:BackupRestore.aspx,Method:btnBackup_Click   EXCEPTION:  "+ex.Message+" userid  "+uid  );  
				CreateLogFiles.ErrorLog(" Form : BackupRestore.aspx,Method : btnBackup_Click   EXCEPTION:  "+ex.Message+" userid  "+pass );
			}
		}
		
		
		/// <summary>
		/// This Function Used to Establish the Connection With Server
		/// this method not use.
		/// </summary>
		public  string contactServer(string key)
		{
			/// Data buffer for incoming data.
			byte[] bytes = new byte[1024];
			string strID = "";
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
				Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );

				/// Connect the socket to the remote endpoint. Catch any errors.
				try 
				{
					sender.Connect(remoteEP);
					/// Encode the data string into a byte array.
					byte[] msg = Encoding.ASCII.GetBytes(key + "<EOF>");
					/// Send the data through the socket.
					int bytesSent = sender.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender.Receive(bytes);
					///Console.WriteLine("\nEpetroPrintServices Server Echo = {0}", Encoding.ASCII.GetString(bytes,0,bytesRec));
					strID = Encoding.ASCII.GetString(bytes,0,bytesRec);
					/// Release the socket.
					sender.Shutdown(SocketShutdown.Both);
					sender.Close();					    
					return strID;
				}
				catch (ArgumentNullException ane) 
				{
					string str = ane.Message;         // To avoid Warnings
					CreateLogFiles.ErrorLog("Form:BackupRestore.aspx,Method:contactServer()   EXCEPTION:  "+ane.Message+" userid  "+pass  );    
					
				}
				catch (SocketException se)
				{
					string str = se.Message;          /// To avoid Warnings
					CreateLogFiles.ErrorLog("Form:BackupRestore.aspx,Method:contactServer()   EXCEPTION:  "+se.Message+" userid  "+pass  );    
								
				} 
				catch (Exception e)
				{
					string str = e.Message;           /// To avoid Warnings
					CreateLogFiles.ErrorLog("Form:BackupRestore.aspx,Method:contactServer()   EXCEPTION:  "+e.Message+" userid  "+pass  );      
				}

			} 
			catch (Exception e)
			{
				string str = e.Message;               /// To avoid Warnings
				CreateLogFiles.ErrorLog("Form:BackupRestore.aspx,Method:contactServer()   EXCEPTION:  "+e.Message+" userid  "+pass  );    
			}

			return "";
		}

		/// <summary>
		/// This method is used to restore the backup data in database by sql query and take backup file
		/// from custom location.
		/// </summary>
		private void btnRestore_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(tempPath.Value!="")
				{
					string FilePath=tempPath.Value;
					FilePath+=".bak";
					SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["Master"]);
					con.Open();
					SqlCommand cmd = new SqlCommand("Alter DATABASE bbnschool SET SINGLE_USER WITH ROLLBACK IMMEDIATE",con);
					cmd.ExecuteNonQuery();
					cmd.Dispose();
					con.Close();
					con.Open();
					cmd = new SqlCommand("RESTORE DATABASE [bbnschool] FROM  DISK = '"+FilePath+"' WITH  FILE = 1,REPLACE",con);
					cmd.ExecuteNonQuery();
					cmd.Dispose();
					con.Close();
					con.Open();
					cmd = new SqlCommand("Alter DATABASE bbnschool SET MULTI_USER",con);
					cmd.ExecuteNonQuery();
					System.Threading.Thread.Sleep(1000 * 30);
					MessageBox.Show("Restore Successfully Completed");
					cmd.Dispose();
					con.Close();
					Flag=1;
				}
				else
				{
					MessageBox.Show("Please Select The '.bak' File");
				}
				CreateLogFiles.ErrorLog(" Form : BackupRestore.aspx,Method : btnRestore_Click : userid  "+pass  );		
			}
			catch(Exception ex)
			{
				//CreateLogFiles.ErrorLog("Form:BackupRestore.aspx,Method:btnRestore_Click   EXCEPTION:  "+ex.Message+" userid  "+uid  );  
				CreateLogFiles.ErrorLog(" Form : BackupRestore.aspx,Method : btnRestore_Click   EXCEPTION:  "+ex.Message+" userid  "+pass  );
			}
		
		}

	}
}
