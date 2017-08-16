
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
using System.Data ;

namespace eschool.LibraryClass
{
	/// <summary>
	/// Summary description for NewUserClass.
	/// </summary>
	public class NewUserClass
	{
		SqlConnection sqcon;
		SqlCommand sqcom;
		//SqlCommand sqcomm;

		#region vars & Prop
		string _Users_Name;
		string _Users_Password;
		string _UserName;
		string _First_Name;
		string _Middle_Name;
		string _Last_Name;
		string _Per_Address;
		string _Local_Address;
		string _City;
		string _PinCode; 
		string _Phone_Number;
		string _EMail_ID;
		string _Date_OF_Birth;
		string _Age;
		string _Gender;
		string _Father_Name;
		string _Mother_Name;
		string _marital_Status;
 
		public string UserName
		{
			get
			{
				return _UserName;
			}
			set
			{
				_UserName=value;
			}
		}

		public string Users_Name
		{
			get
			{
				return _Users_Name;
			}
			set
			{
				_Users_Name=value;
			}
		}
		
		

		public string Users_Password
		{
			get
			{
				return _Users_Password;
			}
			set
			{
				_Users_Password=value;
			}
		}
		
		public string First_Name
		{
			get
			{
				return _First_Name;
			}
			set
			{
				_First_Name=value;
			}
		}
		public string Middle_Name
		{
			get
			{
				return _Middle_Name;
			}
			set
			{
				_Middle_Name=value;
			}
		}
		public string Last_Name
		{
			get
			{
				return _Last_Name;
			}
			set
			{
				_Last_Name=value;
			}
		}
		public string Per_Address
		{
			get
			{
				return _Per_Address;
			}
			set
			{
				_Per_Address=value;
			}
		}
		public string Local_Address
		{
			get
			{
				return _Local_Address;
			}
			set
			{
				_Local_Address=value;
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

		public string PinCode
		{
			get
			{
				return _PinCode;
			}
			set
			{
				_PinCode=value;
			}
		}

		public string Phone_Number
		{
			get
			{
				return _Phone_Number;
			}
			set
			{
				_Phone_Number=value;
			}
		}
		public string EMail_ID
		{
			get
			{
				return _EMail_ID;
			}
			set
			{
				_EMail_ID=value;
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
		

		public string Age
		{
			get
			{
				return _Age;
			}
			set
			{
				_Age=value;
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
		public string Father_Name
		{
			get
			{
				return _Father_Name;
			}
			set
			{
				_Father_Name=value;
			}
		}

		public string Mother_Name
		{
			get
			{
				return _Mother_Name;
			}
			set
			{
				_Mother_Name=value;
			}
		}

		public string marital_Status
		{
			get
			{
				return _marital_Status;
			}
			set
			{
				_marital_Status=value;
			}
		}
		#endregion

		/// <summary>
		/// this method use to create connection between database.
		/// </summary>
		public NewUserClass()
		{
			sqcon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			sqcon.Open();
		}

		/// <summary>
		/// this method use to Insert User information with help of 'proInsertUser' procedure.
		/// </summary>
		public void InsertUser()
		{ 
		
			sqcom=new SqlCommand("proInsertUser",sqcon);
			sqcom.CommandType =CommandType .StoredProcedure ;
			sqcom.Parameters .Add("@Users_Name",Users_Name);
			sqcom.Parameters .Add("@Users_Password",Users_Password);
			sqcom.ExecuteNonQuery();

		}

		/// <summary>
		/// this method use to Delete User.
		/// </summary>
		public void DeleteUser()
		{ 
			sqcom=new SqlCommand("profordel",sqcon);
			sqcom.CommandType =CommandType .StoredProcedure ;
			sqcom.Parameters .Add("@Users_Name",Users_Name);
			sqcom.ExecuteNonQuery();
		}

		// 
		/// <summary>
		/// this method use to Delete Student User
		/// </summary>
		public void DeleteStudentUser()
		{ 
			sqcom=new SqlCommand("proforstudentdel",sqcon);
			sqcom.CommandType =CommandType .StoredProcedure ;
			sqcom.Parameters .Add("@UserName",UserName);
			sqcom.ExecuteNonQuery();

		}
			
		/// <summary>
		/// this method use to Delete Indivisible User.
		/// </summary>
		public void DeleteIndivisibleUser()
		{ 
			sqcom=new SqlCommand("proforIndividel",sqcon);
			sqcom.CommandType =CommandType .StoredProcedure ;
			sqcom.Parameters .Add("@Users_Name",Users_Name);
			sqcom.ExecuteNonQuery();
		}

		/// <summary>
		/// this method use to Delete Driver User
		/// </summary>
		public void DeleteDriverUser()
		{ 
			sqcom=new SqlCommand("proforDriver",sqcon);
			sqcom.CommandType =CommandType .StoredProcedure ;
			sqcom.Parameters .Add("@Users_Name",Users_Name);
			sqcom.ExecuteNonQuery();

		}

		/// <summary>
		/// this method use to Delete Employee User	
		/// </summary>
		public void DeleteEmployeeUser()
		{ 
			sqcom=new SqlCommand("proforEmployee",sqcon);
			sqcom.CommandType =CommandType .StoredProcedure ;
			sqcom.Parameters .Add("@Users_Name",Users_Name);
			sqcom.ExecuteNonQuery();
		}

		/// <summary>
		/// this method use to Delete Other User				
		/// </summary>
		public void DeleteOtherUser()
		{ 
			sqcom=new SqlCommand("proforOther",sqcon);
			sqcom.CommandType =CommandType .StoredProcedure ;
			sqcom.Parameters .Add("@Users_Name",Users_Name);
			sqcom.ExecuteNonQuery();

		}
		
	}
}








