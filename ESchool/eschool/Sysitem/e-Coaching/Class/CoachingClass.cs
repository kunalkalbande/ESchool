/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
*/

using System;
using System.Data.SqlClient;
using System .Data;

namespace eschool.e_Coaching.Class
{
	/// <summary>
	/// Summary description for CoachingClass.
	/// </summary>
	public class CoachingClass

	{

		
		SqlConnection sqcon;
		SqlCommand sqcomm;
		SqlDataReader sqred;
		SqlDataAdapter sqdr;
		DataSet ds;

		# region var & prop
			
		string _Registrationid;
		string _FullName;
		string _Qualification;
		string _Subject;
		string _EmailID;
		string  _Date_OF_Birth;
		string _FatherName;
		string _Gender;
		string _LAddress;
		string _LCity;
		string _LPincode;
		string _LState;
		string _PAddress;
		string _PCity;
		string _PPincode;
		string _PState;
		string _Coah_Day;
		string _Coah_Time;
		//string _Teacherid;

		string _TeacherID;
		string _TeacherName;
		string _LoginName;
		string _Password;
		string _PhoneNO;
		string _PhoneNo;
		string _Experience;
		string _Country;
		string _MobileNo;
		string _PCountry;
		public string PhoneNo
		{
			get
			{
				return _PhoneNo;
			}
			set
			{
				_PhoneNo=value;
			}
		}	
		public string PCountry
		{
			get
			{
				return _PCountry;
			}
			set
			{
				_PCountry=value;
			}
		}

		public string MobileNo
		{
			get
			{
				return _MobileNo;
			}
			set
			{
				_MobileNo=value;
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
		public string TeacherID
		{
			get
			{
				return _TeacherID;
			}
			set
			{
				_TeacherID=value;
			}
		}		
		public string TeacherName
		{
			get
			{
				return _TeacherName;
			}
			set
			{
				_TeacherName=value;
			}
		}
		
		/*public string Teacherid
		{
			get
			{
				return _Teacherid;
			}
			set
			{
				_Teacherid=value;
			}
		}*/

		public string Subject
		{
			get
			{
				return _Subject;
			}
			set
			{
				_Subject=value;
			}
		}		
		public string PhoneNO
		{
			get
			{
				return _PhoneNO;
			}
			set
			{
				_PhoneNO=value;
			}
		}		
		public string  LoginName
		{
			get
			{
				return _LoginName;
			}
			set
			{
				_LoginName=value;
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
		public string Experience
		{
			get
			{
				return _Experience;
			}
			set
			{
				_Experience=value;
			}
		}		


		public string Registrationid
		{
			get
			{
				return _Registrationid;
			}
			set
			{
				_Registrationid=value;
			}
		}		
		public string FullName
		{
			get
			{
				return _FullName;
			}
			set
			{
				_FullName=value;
			}
		}		
			
		public string Qualification
		{
			get
			{
				return _Qualification;
			}
			set
			{
				_Qualification=value;
			}
		}		
			
		//		public string Subject
		//		{
		//			get
		//			{
		//				return _Subject;
		//			}
		//			set
		//			{
		//				_Subject=value;
		//			}
		//		}		
			
		public string EmailID
		{
			get
			{
				return _EmailID;
			}
			set
			{
				_EmailID=value;
			}
		}		
			
		public string Date_OF_Birth
		{
			get
			{
				return _Date_OF_Birth;
			}
			set
			{
				_Date_OF_Birth=value;
			}
		}		
			
		public string FatherName
		{
			get
			{
				return _FatherName;
			}
			set
			{
				_FatherName=value;
			}
		}		
		public string Gender
		{
			get
			{
				return _Gender;
			}
			set
			{
				_Gender=value;
			}
		}		
		public string LAddress
		{
			get
			{
				return _LAddress;
			}
			set
			{
				_LAddress=value;
			}
		}		
		public string LCity
		{
			get
			{
				return _LCity;
			}
			set
			{
				_LCity=value;
			}
		}		
		public string LPincode
		{
			get
			{
				return _LPincode;
			}
			set
			{
				_LPincode=value;
			}
		}		
		public string LState
		{
			get
			{
				return _LState;
			}
			set
			{
				_LState=value;
			}
		}		
		public string PAddress
		{
			get
			{
				return _PAddress;
			}
			set
			{
				_PAddress=value;
			}
		}		

		public string PCity
		{
			get
			{
				return _PCity;
			}
			set
			{
				_PCity=value;
			}
		}	
		public string PPincode
		{
			get
			{
				return _PPincode;
			}
			set
			{
				_PPincode=value;
			}
		}	
		public string PState
		{
			get
			{
				return _PState;
			}
			set
			{
				_PState=value;
			}
		}	
		public string Coah_Day
		{
			get
			{
				return _Coah_Day;
			}
			set
			{
				_Coah_Day=value;
			}
		}	
		public string Coah_Time
		{
			get
			{
				return _Coah_Time;
			}
			set
			{
				_Coah_Time=value;
			}
		}	
		
		#endregion

		/// <summary>
		/// this method use to create connection between database.
		/// </summary>
		public void connection()
		{
			sqcon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			sqcon.Open();
		}

		/// <summary>
		/// this method use to Insert New Member with the help of 'ProInsertRegistration' proedure.
		/// </summary>
		public void InsertNewMember()
		{ 
			connection();
			sqcomm=new SqlCommand("ProInsertRegistration",sqcon);
			sqcomm.CommandType =CommandType.StoredProcedure;
			sqcomm.Parameters.Add("@Registrationid",Registrationid );
			sqcomm.Parameters.Add("@FullName",FullName);
			sqcomm.Parameters.Add("@Qualification",Qualification);
			sqcomm.Parameters.Add("@Subject",Subject );
			sqcomm.Parameters.Add("@Date_OF_Birth",Date_OF_Birth );
			sqcomm.Parameters.Add("@FatherName",FatherName);
			sqcomm.Parameters.Add("@Gender",Gender);
			sqcomm.Parameters.Add("@EmailID",EmailID);
			sqcomm.Parameters.Add("@LAddress ",LAddress );
			sqcomm.Parameters.Add("@LCity",LCity);
			sqcomm.Parameters.Add("@LPincode",LPincode );
			sqcomm.Parameters.Add("@LState",LState);
			sqcomm.Parameters.Add("@PAddress",PAddress);
			sqcomm.Parameters.Add("@PCity",PCity);
			sqcomm.Parameters.Add("@PPincode",PPincode);
			sqcomm.Parameters.Add("@PState",PState);
			sqcomm.Parameters.Add("@Coah_Day",Coah_Day);
			sqcomm.Parameters.Add("@Coah_Time",Coah_Time);
			sqcomm.Parameters .Add("@Country",Country);
			sqcomm.ExecuteNonQuery();
		}
 
		/// <summary>
		/// this method use to Insert New Registration.and use 'proinsertregistrationstudent' procedure.
		/// </summary>
		public void InsertNewRegistraion()
		{ 
			connection();
			sqcomm=new SqlCommand("proinsertregistrationstudent",sqcon);
			sqcomm.CommandType =CommandType.StoredProcedure;
			sqcomm.Parameters.Add("@Registrationid",Registrationid);
			sqcomm.Parameters.Add("@FullName",FullName );
			sqcomm.Parameters.Add("@Qualification",Qualification );
			sqcomm.Parameters.Add("@Subject",Subject );
			sqcomm.Parameters.Add("@EmailID",EmailID );
			sqcomm.Parameters.Add("@Date_OF_Birth",Date_OF_Birth );
			sqcomm.Parameters.Add("@FatherName",FatherName );
			sqcomm.Parameters.Add("@Gender",Gender );
			sqcomm.Parameters.Add("@LAddress",LAddress );
			sqcomm.Parameters.Add("@LCity",LCity );
			sqcomm.Parameters.Add("@LPincode",LPincode );
			sqcomm.Parameters.Add("@LState",LState );
			sqcomm.Parameters.Add("@PAddress",PAddress );
			sqcomm.Parameters.Add("@Pcity",PCity );
			sqcomm.Parameters.Add("@PPincode",PPincode );
			sqcomm.Parameters.Add("@PState",PState );
			sqcomm.Parameters.Add("@Coah_Day",Coah_Day );
			sqcomm.Parameters.Add("@Coah_Time",Coah_Time );
			sqcomm.Parameters.Add("@Country",Country );
			sqcomm.Parameters.Add("@PCountry",PCountry );
			sqcomm.Parameters.Add("@PhoneNo",PhoneNo );
			sqcomm.Parameters.Add("@MobileNo",MobileNo );
			sqcomm.ExecuteNonQuery();
		}

		/// <summary>
		/// this method use to Insert Teacher Information.with help of 'ProInserteteacher' procedure.
		/// </summary>
		public void InsertTeacherInfo()
		{ 
			connection();
			sqcomm=new SqlCommand("ProInserteteacher",sqcon);
			sqcomm.CommandType =CommandType.StoredProcedure;
			sqcomm.Parameters.Add("@Teacherid",TeacherID); 
			sqcomm.Parameters.Add("@LoginName",LoginName);
			sqcomm.Parameters.Add("@Password",Password);
			sqcomm.Parameters.Add("@TeacherName",TeacherName);
			sqcomm.Parameters.Add("@Subject",Subject);
			sqcomm.Parameters.Add("@PhoneNO",PhoneNO );
			sqcomm.Parameters.Add("@Experience",Experience );
			sqcomm.ExecuteNonQuery();
		}

		/// <summary>
		/// this method use to Get StudentID from E_Registration table.
		/// </summary>
		public SqlDataReader getStudentID()
		{
			connection(); 
			sqcomm=new SqlCommand ("select max(RegistrationID)+1 from E_Registration",sqcon);
			sqred=sqcomm.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to Get TeacherID from E_Teacher.
		/// </summary>
		public SqlDataReader getteacherID()
		{
			connection(); 
			sqcomm=new SqlCommand ("select max(TeacherID)+1 from E_Teacher",sqcon);
			sqred=sqcomm.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// Show RegistrationIDInCombo Box from E_Registration table.
		/// </summary>
		public SqlDataReader showRegistrationIDInCombo()
		{
			connection(); 
			sqcomm=new SqlCommand ("select RegistrationID from E_Registration",sqcon);
			sqred=sqcomm.ExecuteReader();
			return sqred;
			
		}

		/// <summary>
		/// Show TeacherName In Combo Box
		/// </summary>
		public SqlDataReader  showTeacherNameInCombo()
		{
			connection(); 
			sqcomm=new SqlCommand ("select TeacherID from E_Teacher where subject=@subject",sqcon);
			sqcomm.Parameters .Add ("@subject",Subject);
			sqred=sqcomm.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// Show Registration Information of e-coaching.
		/// </summary>
		public SqlDataReader  ShowRegisInfo()
		{
			connection(); 
			sqcomm=new SqlCommand ("proshowinfo",sqcon);
			sqcomm.CommandType=CommandType .StoredProcedure;
			sqcomm.Parameters .Add ("@Registrationid",Registrationid);
			sqred=sqcomm.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// Show Teacher Subject Information.
		/// </summary>
		public SqlDataReader  ShowTeachsubjectInfo()
		{
			connection(); 
			sqcomm=new SqlCommand ("proshowSubjectinfo",sqcon);
			sqcomm.CommandType=CommandType .StoredProcedure;
			sqcomm.Parameters .Add ("@TeacherID",TeacherID);
			sqred=sqcomm.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// Show Member Registration  Information
		/// </summary>
		public DataSet ShowMemberRegistrationInfo()
		{
			connection();
			sqdr=new SqlDataAdapter("proshowRegistrationInfo",sqcon);
			ds=new DataSet();
			sqdr.Fill(ds);
			sqcon.Close();
			sqcon.Dispose();
			return ds;
		}

		/// <summary>
		/// Show Teacher  Information in data Grid.
		/// </summary>
		public DataSet ShowETeacher()
		{
			connection();
			sqdr=new SqlDataAdapter("showEteacherInfo",sqcon);
			ds=new DataSet();
			sqdr.Fill(ds);
			sqcon.Close();
			sqcon.Dispose();
			return ds;
		}

	}
}
