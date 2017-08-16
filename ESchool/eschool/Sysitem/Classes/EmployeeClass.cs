/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.

*/

using System;
using System.Data ;
using System.Data.SqlClient ;
using System.Web;
using eschool.Classes;


namespace eschool.Classes
{
	/// <summary>
	/// Summary description for Employee.
	/// </summary>
	public class EmployeeClass
	{
		SqlConnection SqlCon;
		SqlCommand SqlCmd;
		SqlDataReader SqlDtRed;
		SqlDataAdapter SqlDtAdp;
		DataSet DS;

		#region Vars & Prop
		string _Emp_ID;
		int _Emp_ID1;

		string _Emp_Name; 
		string _Desig;
		string _Address;
		string _City;
		string _State;
		string _Country;
		string _Phone;
		string _Mobile;
		string _EMail;
		string _Salary;
		string _OT_Comp;
		string _Shift_ID;
		string _Att_Date;
		string _Status;
		string _OT_Date;
		string _OT_From;
		string _OT_To;
		string _Leave_ID;
		string _Date_From;
		string _Date_To;
		string _Dr_License_No;
	    string _Dr_LIC_No;
		string _Dr_License_validity;
	    string _Dr_LIC_validity;
		string _Vehicle_NO;
		
		DateTime _Date_From1;
		DateTime _Date_To1;

		public DateTime Date_From1
		{
			get
			{
				return _Date_From1;
			}
			set
			{
				_Date_From1=value;
			}
		}
		public DateTime Date_To1
		{
			get
			{
				return _Date_To1;
			}
			set
			{
				_Date_To1=value;
			}
		}

		string _Reason;
		string _Shift_Date;
		string _Shift_Name;
		string _isSanction;
		string _Role_ID;
		string _Role_Name;
		string _Description;
		string _User_ID;
		string _Login_Name;
		string _Password;
		string _User_Name;
		string _Module_ID;
		string _SubModule_ID;
		string _View_Flag;
		string _Add_Flag;
		string _Edit_Flag;
		string _Del_Flag;
		string _BalType;
		string _OpBalance;
		string _Class_Name;
		string _Stream;
		string _assignsubject;
		int _clwsid;
		string _Edit;
		string _sub1;
		string _sub2;
		string _sub3;
		string _sub4;
		string _sub5;
		string _sub6;
		string _sub7;
		string _sub8;
		string _sub9;
		string _sub10;
		string _sub11;
		string _sub12;
		string _sub13;
		string _sub14;
		string _sub15;
		string _sub16;
		string _sub17;
		string _sub18;
		string _sub19;
		string _sub20;

		public string sub1
		{
			get
			{
				return _sub1;
			}
			set
			{
				_sub1=value;
			}
		}
		public string sub2
		{
			get
			{
				return _sub2;
			}
			set
			{
				_sub2=value;
			}
		}
		public string sub3
		{
			get
			{
				return _sub3;
			}
			set
			{
				_sub3=value;
			}
		}
		public string sub4
		{
			get
			{
				return _sub4;
			}
			set
			{
				_sub4=value;
			}
		}
		public string sub5
		{
			get
			{
				return _sub5;
			}
			set
			{
				_sub5=value;
			}
		}
		public string sub6
		{
			get
			{
				return _sub6;
			}
			set
			{
				_sub6=value;
			}
		}
		public string sub7
		{
			get
			{
				return _sub7;
			}
			set
			{
				_sub7=value;
			}
		}
		public string sub8
		{
			get
			{
				return _sub8;
			}
			set
			{
				_sub8=value;
			}
		}
		public string sub9
		{
			get
			{
				return _sub9;
			}
			set
			{
				_sub9=value;
			}
		}
		public string sub10
		{
			get
			{
				return _sub10;
			}
			set
			{
				_sub10=value;
			}
		}
		public string sub11
		{
			get
			{
				return _sub11;
			}
			set
			{
				_sub11=value;
			}
		}
		public string sub12
		{
			get
			{
				return _sub12;
			}
			set
			{
				_sub12=value;
			}
		}
		public string sub13
		{
			get
			{
				return _sub13;
			}
			set
			{
				_sub13=value;
			}
		}
		public string sub14
		{
			get
			{
				return _sub14;
			}
			set
			{
				_sub14=value;
			}
		}
		public string sub15
		{
			get
			{
				return _sub15;
			}
			set
			{
				_sub15=value;
			}
		}
		public string sub16
		{
			get
			{
				return _sub16;
			}
			set
			{
				_sub16=value;
			}
		}
		public string sub17
		{
			get
			{
				return _sub17;
			}
			set
			{
				_sub17=value;
			}
		}
		public string sub18
		{
			get
			{
				return _sub18;
			}
			set
			{
				_sub18=value;
			}
		}
		public string sub19
		{
			get
			{
				return _sub19;
			}
			set
			{
				_sub19=value;
			}
		}
		public string sub20
		{
			get
			{
				return _sub20;
			}
			set
			{
				_sub20=value;
			}
		}
		public int clwsid
		{
			get
			{
				return _clwsid;
			}
			set
			{
				_clwsid=value;
			}
		}
		public string Edit
		{
			get
			{
				return _Edit;
			}
			set
			{
				_Edit=value;
			}
		}
		public string assignsubject
		{
			get
			{
				return _assignsubject;
			}
			set
			{
				_assignsubject=value;
			}
		}
		public string Stream
		{
			get
			{
				return _Stream;
			}
			set
			{
				_Stream=value;
			}
		}
		public int Emp_ID1
		{
			get
			{
				return _Emp_ID1;
			}
			set
			{
				_Emp_ID1=value;
			}
		}
	
		public string Del_Flag
		{
			get
			{
				return _Del_Flag;
			}
			set
			{
				_Del_Flag=value;
			}
		}
		public string Edit_Flag
		{
			get
			{
				return _Edit_Flag;
			}
			set
			{
				_Edit_Flag=value;
			}
		}
		public string Add_Flag
		{
			get
			{
				return _Add_Flag;
			}
			set
			{
				_Add_Flag=value;
			}
		}
		public string View_Flag
		{
			get
			{
				return _View_Flag;
			}
			set
			{
				_View_Flag=value;
			}
		}
		public string SubModule_ID
		{
			get
			{
				return _SubModule_ID;
			}
			set
			{
				_SubModule_ID=value;
			}
		}
		public string Module_ID
		{
			get
			{
				return _Module_ID;
			}
			set
			{
				_Module_ID=value;
			}
		}
		public string User_Name
		{
			get
			{
				return _User_Name;
			}
			set
			{
				_User_Name=value;
			}
		}
		public string Password
		{
			get
			{
				return _Password;
			}
			set
			{
				_Password=value;
			}
		}
		public string Login_Name
		{
			get
			{
				return _Login_Name;
			}
			set
			{
				_Login_Name=value;
			}
		}
		public string User_ID
		{
			get
			{
				return _User_ID;
			}
			set
			{
				_User_ID=value;
			}
		}
		public string Description
		{
			get
			{
				return _Description;
			}
			set
			{
				_Description=value;
			}
		}
		public string Role_Name
		{
			get
			{
				return _Role_Name;
			}
			set
			{
				_Role_Name=value;
			}
		}
		public string Role_ID
		{
			get
			{
				return _Role_ID;
			}
			set
			{
				_Role_ID=value;
			}
		}		
		public string isSanction
		{
			get
			{
				return _isSanction;
			}
			set
			{
				_isSanction=value;
			}
		}
		public string Emp_ID
		{
			get
			{
				return _Emp_ID;
			}
			set
			{
				_Emp_ID=value;
			}
		}
		public string Emp_Name
		{
			get
			{
				return _Emp_Name;
			}
			set
			{
				_Emp_Name=value;
			}
		}
		public string Designation
		{
			get
			{
				return _Desig;
			}
			set
			{
				_Desig=value;
			}
		}
		public string Address
		{
			get
			{
				return _Address;
			}
			set
			{
				_Address=value;
			}
		}
		public string City
		{
			get
			{
				return _City;
			}
			set
			{
				_City=value;
			}
		}
		public string State
		{
			get
			{
				return _State;
			}
			set
			{
				_State=value;
			}
		}
		public string Country
		{
			get
			{
				return _Country;
			}
			set
			{
				_Country=value;
			}
		}
		public string Phone
		{
			get
			{
				return _Phone;
			}
			set
			{
				_Phone=value;
			}
		}
		public string Mobile
		{
			get
			{
				return _Mobile;
			}
			set
			{
				_Mobile=value;
			}
		}
		public string EMail
		{
			get
			{
				return  _EMail;
			}
			set
			{
				 _EMail=value;
			}
		}
		public string Salary
		{
			get
			{
				return  _Salary;
			}
			set
			{
				_Salary=value;
			}
		}
		public string OT_Compensation
		{
			get
			{
				return  _OT_Comp;
			}
			set
			{
				_OT_Comp=value;
			}
		}
		public string Dr_License_No
		{
			get
			{
				return _Dr_License_No;
			}
			set
			{
				_Dr_License_No = value;
			}
		}
		
		public string Dr_LIC_No
		{
			get
			{
				return _Dr_LIC_No;
			}
			set
			{
				_Dr_LIC_No = value;
			}
		}

		public string Dr_License_validity
		{
			get
			{
				return _Dr_License_validity;
			}
			set
			{
				_Dr_License_validity = value;
			}
		}
		public string Dr_LIC_validity
		{
			get
			{
				return _Dr_LIC_validity;
			}
			set
			{
				_Dr_LIC_validity = value;
			}
		}
		public string OpBalance
		{
			get
			{
				return _OpBalance;
			}
			set
			{
				_OpBalance = value;
			}
		}
		public string BalType
		{
			get
			{
				return _BalType;
			}
			set
			{
				_BalType = value;
			}
		}
		public string Vehicle_NO
		{
			get
			{
				return _Vehicle_NO;
			}
			set
			{
				_Vehicle_NO = value;
			}
		}

		
		public string Shift_ID
		{
			get
			{
				return  _Shift_ID;
			}
			set
			{
				_Shift_ID=value;
			}
		}
		public string  Att_Date
		{
			get
			{
				return  _Att_Date;
			}
			set
			{
				_Att_Date=value;
			}
		}
		public string  Status
		{
			get
			{
				return  _Status;
			}
			set
			{
				_Status=value;
			}
		}
		public string OT_Date
		{
			get
			{
				return _OT_Date;
			}
			set
			{
				_OT_Date=value;
			}
		}
		
		public string OT_From
		{
			get
			{
				return _OT_From;
			}
			set
			{
				_OT_From=value;
			}
		}
		
		public string OT_To
		{
			get
			{
				return _OT_To;
			}
			set
			{
				_OT_To=value;
			}
		}
		public string Leave_ID
		{
			get
			{
				return _Leave_ID;
			}
			set
			{
				_Leave_ID=value;
			}
		}
		public string Date_From
		{
			get
			{
				return _Date_From;
			}
			set
			{
				_Date_From=value;
			}
		}
		public string Date_To
		{
			get
			{
				return _Date_To;
			}
			set
			{
				_Date_To=value;
			}
		}
		public string Reason
		{
			get
			{
				return _Reason;
			}
			set
			{
				_Reason=value;
			}
		}
		public string Class_Name
		{
			get
			{
				return _Class_Name ;
			}
			set
			{
				_Class_Name =value;
			}
		}
		public string Shift_Date
		{
			get
			{
				return _Shift_Date ;
			}
			set
			{
				_Shift_Date =value;
			}
		}
		public string Shift_Name
		{
			get
			{
				return _Shift_Name ;
			}
			set
			{
				_Shift_Name =value;
			}
		}
		#endregion

		#region 
		/// <summary>
		/// Constructor & Destructor .. opens the connection to the database server.
		/// </summary>
		public EmployeeClass()
		{
			SqlCon =new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			SqlCon.Open();
		}
		~EmployeeClass()
		{

		}
		#endregion

		/// <summary>
		/// Method returns the SqlDataReader Object by executing the passing query. 
		/// </summary>
		public SqlDataReader GetRecordSet(string sql)
		{
			SqlCmd=new SqlCommand (sql,SqlCon );
			SqlDtRed  = SqlCmd.ExecuteReader();
			return SqlDtRed;
		}


		/// <summary>
		/// Method execute the insert, update or delete query;
		/// </summary>
		public void ExecRecord(string Sql)
		{
			SqlCmd=new SqlCommand(Sql,SqlCon);
			SqlCmd.ExecuteNonQuery();
		}


		/// <summary>
		/// this method use to returns the current date.		
		/// </summary>
		public  string  date()
		{
			String dt = DateTime.Now.ToString();
			int pos = dt.IndexOf(" ");
			String strDate;
			strDate = dt.Substring(0, pos);            

			if (strDate.StartsWith("0"))
			{
				strDate = strDate.Substring(1);
			}
            
			return strDate;

			}

		/// <summary>
		/// method returns the SqlDataReader for containing next employee ID
		/// </summary>
		public SqlDataReader GetNextEmployeeID()
		{
			SqlCmd=new SqlCommand ("select max(Emp_ID)+1 from Employee",SqlCon );
			SqlDtRed  = SqlCmd.ExecuteReader();
			return SqlDtRed;
		
		}

		/// <summary>
		/// method returns the SqlDataReader for containing next shift ID
		/// </summary>
		public SqlDataReader GetNextShiftID()
		{
			SqlCmd=new SqlCommand ("select max(Shift_ID)+1 from Shift",SqlCon );
			SqlDtRed  = SqlCmd.ExecuteReader();
			return SqlDtRed;
		}


		/// <summary>
		/// method returns the SqlDataReader for containing  employee ID
		/// </summary>
		public SqlDataReader GetEmployeeID()
		{
			SqlCmd=new SqlCommand ("select Emp_ID from Employee",SqlCon );
			SqlDtRed  = SqlCmd.ExecuteReader();
			return SqlDtRed;
		
		}

		/// <summary>
		/// Method calls procedure prodeleteEmployee to delete the employee
		/// </summary>
		public void deleteEmployee()
		{
			SqlCmd=new SqlCommand("proDeleteEmployee",SqlCon);
			SqlCmd.CommandType=CommandType.StoredProcedure;
			SqlCmd.Parameters.Add("@Emp_ID",Emp_ID);
			SqlCmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Method calls procedure proEmployeeEntry to insert the employee
		/// </summary>
		public void InsertEmployee()
		 { 				
			SqlCmd=new SqlCommand("ProEmployeeEntry",SqlCon );
			SqlCmd.CommandType=CommandType.StoredProcedure;
			SqlCmd.Parameters .Add("@Emp_ID",Emp_ID );
			SqlCmd.Parameters .Add("@Emp_Name",Emp_Name );
			SqlCmd.Parameters .Add("@Desig",Designation  );
			SqlCmd.Parameters .Add("@Address",Address );
			SqlCmd.Parameters .Add("@City",City);
			SqlCmd.Parameters .Add("@State",State );
			SqlCmd.Parameters .Add("@Country",Country );
			SqlCmd.Parameters .Add("@Phone",Phone);
			SqlCmd.Parameters .Add("@Mobile",Mobile);
			SqlCmd.Parameters .Add("@EMail",EMail);
			SqlCmd.Parameters .Add("@Salary",Salary);
			SqlCmd.Parameters .Add("@OT_Comp",OT_Compensation );
			SqlCmd.Parameters .Add("@driver_lic_no",Dr_License_No  );
			SqlCmd.Parameters .Add("@validity",Dr_License_validity  );
			SqlCmd.Parameters .Add("@lic_policy_no",Dr_LIC_No );
			SqlCmd.Parameters .Add("@lic_validity",Dr_LIC_validity );
			SqlCmd.Parameters .Add("@vehicle_id",Vehicle_NO);
			SqlCmd.Parameters .Add("@OpBalance",OpBalance);
			SqlCmd.Parameters .Add("@BalType",BalType);
			SqlCmd.ExecuteNonQuery();

		 }

		/// <summary>
		/// Method calls procedure proEmployeeUpdate to Update the employee
		/// </summary>
		public void UpdateEmployee()
		{ 				
			SqlCmd=new SqlCommand("ProEmployeeUpdate",SqlCon );
			SqlCmd.CommandType=CommandType.StoredProcedure;
			SqlCmd.Parameters .Add( "@Emp_ID",Emp_ID );
			SqlCmd.Parameters .Add("@Emp_Name",Emp_Name );
			SqlCmd.Parameters .Add("@Desig",Designation  );
			SqlCmd.Parameters .Add("@Address",Address );
			SqlCmd.Parameters .Add("@City",City);
			SqlCmd.Parameters .Add("@State",State );
			SqlCmd.Parameters .Add("@Country",Country );
			SqlCmd.Parameters .Add("@Phone",Phone);
			SqlCmd.Parameters .Add("@Mobile",Mobile);
			SqlCmd.Parameters .Add("@EMail",EMail);
			SqlCmd.Parameters .Add("@Salary",Salary);
			SqlCmd.Parameters .Add("@OT_Comp",OT_Compensation );
			SqlCmd.Parameters .Add("@driver_lic_no",Dr_License_No  );
			SqlCmd.Parameters .Add("@validity",Dr_License_validity  );
			SqlCmd.Parameters .Add("@lic_policy_no",Dr_LIC_No );
			SqlCmd.Parameters .Add("@lic_validity",Dr_LIC_validity );
			SqlCmd.Parameters .Add("@vehicle_id",Vehicle_NO);
			SqlCmd.Parameters .Add("@OpBalance",OpBalance);
			SqlCmd.Parameters .Add("@BalType",BalType);
			SqlCmd.ExecuteNonQuery();

		}
		
		/// <summary>
		/// Returns the Employee detailsfor passing id, name and designation
		/// </summary>
		public SqlDataReader EmployeeList(string ID, string name, string desig)
		{
			#region Query
			string sql;
			int wherestatus=0;
			sql="select * from Employee";

			if(ID!="")
			{
				sql=sql+" where Emp_ID=" + ID;
				wherestatus=1;
			}
			if(name!="")
			{
				if (wherestatus==0)
				{
					sql=sql+" where Emp_Name like('%" + name +"%')";
					wherestatus=1;
				}
				else
				{
					sql=sql+" and Emp_Name like('%" + name +"%')";
				}
			}
			if(desig!="")
			{
				if (wherestatus==0)
				{
					sql=sql+" where Designation='" + desig +"'";
					wherestatus=1;
				}
				else
				{
					sql=sql+" and Designation='" + desig +"'";
				}
			}

			#endregion

			SqlCmd=new SqlCommand (sql,SqlCon );
			SqlDtRed  = SqlCmd.ExecuteReader();
			return SqlDtRed;			
		}


		/// <summary>
		/// returns the employee information for passing id , name and designation.
		/// </summary>
		public DataSet ShowEmployeeInfo(string ID, string name, string desig)
		{			
			#region Query
			string sql;
			int wherestatus=0;
			sql="select * from Employee";

			if(ID!="")
			{
				sql=sql+" where Emp_ID like('" + ID +"%')";
				wherestatus=1;
			}
			if(name!="" && desig=="")
			{  
			
				
				if (wherestatus==0)
				{
					sql=sql+" where  Emp_Name like('"+name+"%')";
				}
				else if(wherestatus==0)
				{
					
					sql=sql+" where Emp_Name like('%" + name +"%')";
					wherestatus=1;
				}
				else if(wherestatus==0)
				{
					sql=sql+" where Emp_Name like('%" + name +"')";
					wherestatus=1;
				}
				
			}
			if(desig!="" && name=="" )
			{
				
				if (wherestatus==0)
				{
					sql=sql+" where Designation like('" + desig +"%')";
					wherestatus=1;
				}
				else if(wherestatus==0)
				{
					sql=sql+" where Designation like('%" + desig +"')";
					wherestatus=1;
				}
				else if(wherestatus==0)
				{
					sql=sql+" where Designation like('%" + desig +"%')";
					wherestatus=1;
				}

			}


			if(name!="" && desig!="" )
			 {
				
				if (wherestatus==0)
				{
					sql=sql+" where Designation like('" + desig +"%') and  Emp_Name like('" + name +"%')";
					wherestatus=1;
				}
				else if(wherestatus==0)
				{
					sql=sql+" where Designation like('%" + desig +"') and  Emp_Name like('%" + name +"')";
					wherestatus=1;
				}
				else if(wherestatus==0)
				{
					sql=sql+" where Designation like('%" + desig +"%') and  Emp_Name like('%" + name +"%')";
					wherestatus=1;
				}

			}
			#endregion

			SqlDtAdp = new SqlDataAdapter(sql,SqlCon );
			DS = new DataSet();			 
			SqlDtAdp.Fill(DS);
			return DS;		
		}

		/// <summary>
		/// Method calls procedure proEmpAttendanceEntry to insert  employee attendance
		/// </summary>
		public void InsertEmployeeAttandance()
		{
			SqlCmd=new SqlCommand("ProEmpAttadanceEntry",SqlCon);
			SqlCmd.CommandType =CommandType.StoredProcedure;
			SqlCmd.Parameters.Add("@Att_Date",Att_Date.ToString());
			SqlCmd.Parameters.Add("@Emp_ID",Emp_ID.ToString());
			SqlCmd.Parameters.Add("@Status",Status.ToString() );
			SqlCmd.ExecuteNonQuery();			
		}

		/// <summary>
		/// Method calls procedure proInsertOverTimeRegister to insert the Overtime Details.
		/// </summary>
		public void InsertOverTimeRegister()
		{ 
			SqlCmd=new SqlCommand("proInsertOverTimeRegister",SqlCon);
			SqlCmd.CommandType=CommandType.StoredProcedure;
			SqlCmd.Parameters.Add("@Emp_ID",Emp_ID);
			SqlCmd.Parameters.Add("@OT_Date",OT_Date );
			SqlCmd.Parameters.Add("@OT_From",OT_From );
			SqlCmd.Parameters.Add("@OT_To",OT_To );
			SqlCmd.ExecuteNonQuery();          
		}

		/// <summary>
		/// Method calls procedure proLeaveEntry to insert the Leave _details
		/// </summary>
		public void InsertLeave()
		{ 				
			SqlCmd=new SqlCommand("ProLeaveEntry",SqlCon );
			SqlCmd.CommandType=CommandType.StoredProcedure;
			SqlCmd.Parameters.Add("@Emp_Name",Emp_Name);
			SqlCmd.Parameters.Add("@DateFrom",Date_From );
			SqlCmd.Parameters.Add("@DateTo",Date_To );
			SqlCmd.Parameters.Add("@Reason",Reason);
			SqlCmd.ExecuteNonQuery();

		}
		
		/// <summary>
		/// Method calls procedure ProLeaveUpdate to update the leave details
		/// </summary>
		public void UpdateLeave()
		{ 	
				SqlCmd=new SqlCommand("ProLeaveUpdate",SqlCon );
				SqlCmd.CommandType=CommandType.StoredProcedure;
				SqlCmd.Parameters.Add("@Emp_Name",Emp_Name);
				SqlCmd.Parameters.Add("@DateFrom",Date_From );
				SqlCmd.Parameters.Add("@DateTo",Date_To );
				SqlCmd.Parameters.Add("@Reason",Reason);
				SqlCmd.Parameters.Add("@isSanction",isSanction);
				SqlCmd.ExecuteNonQuery();
			
		}


		/// <summary>
		/// Method calls procedure proShiftAssignmentEntry to insert the Shift Assignment Entry.
		/// </summary>
		public void InsertSubjectAssignment()
		{ 				
			SqlCmd=new SqlCommand("proSubjectAssignmentEntry",SqlCon );
			SqlCmd.CommandType=CommandType.StoredProcedure;
			SqlCmd.Parameters .Add("@Class_Name",Class_Name);
			SqlCmd.Parameters .Add("@Stream",Stream);
			SqlCmd.Parameters .Add("@clwsid",clwsid);
			SqlCmd.Parameters .Add("@Edit",Edit);
			SqlCmd.Parameters .Add("@assignsubject",assignsubject);
			SqlCmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Method calls procedure proShiftAssignmentEntry to update the Shift Assignment Entry.
		/// </summary>
		public void UpdateSubjectAssignment()
		{ 				
			SqlCmd=new SqlCommand("proSubjectAssignmentUpdate",SqlCon );
			SqlCmd.CommandType=CommandType.StoredProcedure;
			SqlCmd.Parameters .Add("@Class_Name",Class_Name);
			SqlCmd.Parameters .Add("@Stream",Stream);
			SqlCmd.Parameters .Add("@clwsid",clwsid);
			SqlCmd.Parameters .Add("@assignsubject",assignsubject);
			SqlCmd.ExecuteNonQuery();

		}
	
		/// <summary>
		/// Method calls procedure proRolesEntry to insert the Roles details
		/// </summary>
		public void InsertRoles()
		{ 				
			SqlCmd=new SqlCommand("ProRolesEntry",SqlCon );
			SqlCmd.CommandType=CommandType.StoredProcedure;
			SqlCmd.Parameters .Add("@Role_ID",Role_ID.Length>0?Int32.Parse(Role_ID):0);
			SqlCmd.Parameters .Add("@Role_Name",Role_Name  );
			SqlCmd.Parameters .Add("@Description",Description);
			SqlCmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Method calls procedure UpdateRoles to insert the Roles Details
		/// </summary>
		public void UpdateRoles()
		{ 				
			SqlCmd=new SqlCommand("ProRolesUpdate",SqlCon );
			SqlCmd.CommandType=CommandType.StoredProcedure;
			SqlCmd.Parameters .Add("@Role_ID",Role_ID.Length>0?Int32.Parse(Role_ID):0);
			SqlCmd.Parameters .Add("@Role_Name",Role_Name);
			SqlCmd.Parameters .Add("@Description",Description);
			SqlCmd.ExecuteNonQuery();
		}
		
		/// <summary>
		/// Method calls procedure proPrivilegesEntry to insert the privileges of the user
		/// </summary>
		public void InsertPriveleges()
		{ 				
			SqlCmd=new SqlCommand("ProPrivilegesEntry",SqlCon );
			SqlCmd.CommandType=CommandType.StoredProcedure;
			SqlCmd.Parameters .Add("@Login_Name",Login_Name);
			SqlCmd.Parameters .Add("@Module_ID",Module_ID.Length>0?Int32.Parse(Module_ID):0);
			SqlCmd.Parameters .Add("@SubModule_ID",SubModule_ID.Length>0?Int32.Parse(SubModule_ID):0);
			SqlCmd.Parameters .Add("@View_Flag",View_Flag);
			SqlCmd.Parameters .Add("@Add_Flag",Add_Flag);
			SqlCmd.Parameters .Add("@Edit_Flag",Edit_Flag);
			SqlCmd.Parameters .Add("@Del_Flag",Del_Flag);
			SqlCmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Method calls procedure proUserMasterEntry to insert the User Details
		/// </summary>
		public void InsertUserMaster()
		{ 				
			SqlCmd=new SqlCommand("ProUserMasterEntry",SqlCon );
			SqlCmd.CommandType=CommandType.StoredProcedure;
			SqlCmd.Parameters .Add("@User_ID",User_ID.Length>0?Int32.Parse(User_ID):0);
			SqlCmd.Parameters .Add("@Login_Name",Login_Name);
			SqlCmd.Parameters .Add("@Password",Password);
			SqlCmd.Parameters .Add("@User_Name",User_Name);
			SqlCmd.Parameters .Add("@Role_Name",Role_Name);
			SqlCmd.ExecuteNonQuery();
			SqlCon.Close();
		}

		/// <summary>
		/// Method calls procedure proUserMasterUpdate to update the user details
		/// </summary>
		public void UpdateUserMaster()
		{ 				
			SqlCmd=new SqlCommand("ProUserMasterUpdate",SqlCon );
			SqlCmd.CommandType=CommandType.StoredProcedure;
			SqlCmd.Parameters .Add("@User_ID",User_ID.Length>0?Int32.Parse(User_ID):0);
			SqlCmd.Parameters .Add("@Login_Name",Login_Name  );
			SqlCmd.Parameters .Add("@Password",Password);
			SqlCmd.Parameters .Add("@User_Name",User_Name);
			SqlCmd.Parameters .Add("@Role_Name",Role_Name);
			SqlCmd.ExecuteNonQuery();
			SqlCon.Close();
		}
	}
}
