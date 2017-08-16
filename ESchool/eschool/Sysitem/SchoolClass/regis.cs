/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
*/

using System;
using System .Data.SqlClient;
using System.Data;


namespace eschool.SchoolClass
{
	/// <summary>
	/// Summary description for regis.
	/// </summary>
	public class regis
	{
		SqlConnection sqcon;
		SqlCommand sqcomm;
		
		#region var & prop
	
		
		//string s;
		string _Student_ID;
		string _Receipt_No;
		int _Student_ID1;
		string _seq_student_id;
        string _Student_FName;
		string _Student_MName;
		string _Student_LName;
		string _Student_FatherName;
		string _Student_MotherName;
		string _Student_FatherMobileno;
		string _Student_MotherMobileno;
		string _Student_FatherOccp;
		string _Student_MotherOccp;
		float _Student_FatherAnnualIncome;
		float _Student_MotherAnnualIncome;
		string _Staff_ID;
		int _Reg_Id;
		string _Student_FatherEmailID;
		string _Student_MotherEmailID;
		string _Student_Class;
		string _Student_Stream;
		DateTime _Student_AdmissionDate;
		DateTime _Student_Birthdate;
		string _Student_Gender;
		string _Student_LAddress;
		string _Student_LCity;
		string _Student_LState;
		string _Student_LCountry;
		string _Student_PCountry;
		int _Student_LPincode;
		string _Student_PAddress;
		string _Student_PCity;
		string _Student_PState;
		int _Student_PPincode;
		string _Student_EmailID;
		string _Student_PHNo;
		string _Student_MONo;
		string _Student_Category;
		string _Admission_Status;
		string _Service_Hostal;
		string _Service_Lab;
		string _Service_Library;
		string _Service_Bus;
		string _TestDate;
		string _TestTime;
		double _RegFee;
		string _House;
		string _sCategory;
		string _Rank;
		string _BG;
		string _RouteName;
		string _RouteNo;
		string _Computer;
		//int _Staff_ID;
		//*****Gyanandra***********
		string _Father_Name;
		string _Employee_ID;
		string _Professional_Qualification;
		string _Sex;
		string _Maritial_Status;
		//int _Permanent_Accountno;
		long _Permanent_Accountno;//added by vishnu 31/10
		string _EPF_Accountno;     // Add By Vikas sharma 2.11.07
		//long _EPF_Accountno;


		string _Date_of_joining;
		string _Age;
		bool _groupd;
		//****************
		
		string _Staff_Type;
		string _Staff_Name;
		string _Staff_PerAddress;
		string _Suspendid;
		string _Staff_PerCity;
		string _Staff_PerState;
		string _Staff_PerCountry;
		int _Staff_PerPincode;
		string _Staff_LocalAddress;
		string _Staff_LocalCity;
		string _Staff_LocalState;
		string _Staff_LocalCountry;
		int _Staff_LocalPincode;
		string _Staff_EmailID;
		string _Phone_No;
		string _Mobile_No;
		string _Subject_Take;
		string _Staff_education;
		int _Staff_exp;
		bool _teaching;
		bool _nonteaching;
		bool _activity;

		string _photo;
		string _driver_lic_no;
		string	_validity;
		string _lic_policy_no;
		string	_lic_validity;
		int	_vehicle_id;
		string _dob_validity;
		string _NatureApp;
		string _studentphoto;
		
		//*****************gyanandra***********23.04.07

		string _Card_NO;
		string _No_Of_Card;
		string _Validity_Of_Card;
		string _CandidateID;
		string _Date_Of_CardGen;
		string _Name_Of_Librarian;
		string _Remark;
		string _Design;
		string _memberID;
		string _sclass;
		string _year;
		



		public string Year
		{
			get
			{
				return _year;
			}
			set
			{
				_year=value;
			}
		}
		public string sclass
		{
			get
			{
				return _sclass;
			}
			set
			{
				_sclass=value;
			}
		}
		public string memberID
		{
			get
			{
				return _memberID;
			}
			set
			{
				_memberID=value;
			}
		}
		
		
		
		
		public string Computer
		{
			get
			{
				return _Computer;
			}
			set
			{
				_Computer=value;
			}
		}
		
		public string Card_NO
		{
			get
			{
				return _Card_NO;
			}
			set
			{
				_Card_NO=value;
			}
		}

		public string Design
		{
			get
			{
				return _Design;
			}
			set
			{
				_Design=value;
			}
		}
		
		public string No_Of_Card
		{
			get
			{
				return _No_Of_Card;
			}
			set
			{
				_No_Of_Card=value;
			}
		}
		
		public string Validity_Of_Card
		{
			get
			{
				return _Validity_Of_Card;
			}
			set
			{
				_Validity_Of_Card=value;
			}
		}

		public string CandidateID
		{
			get
			{
				return _CandidateID;
			}
			set
			{
				_CandidateID=value;
			}
		}

		public string Date_Of_CardGen
		{
			get
			{
				return _Date_Of_CardGen;
			}
			set
			{
				_Date_Of_CardGen=value;
			}
		}

		public string Name_Of_Librarian
		{
			get
			{
				return _Name_Of_Librarian;
			}
			set
			{
				_Name_Of_Librarian=value;
			}
		}

		public string Remark
		{
			get
			{
				return _Remark;
			}
			set
			{
				_Remark=value;
			}
		}
		
		

		//***********************end*******************
		
		
		//*********Gyanandra************
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
		
		public string Employee_ID
		{
			get
			{
				return _Employee_ID;
			}
			set
			{
				_Employee_ID=value;
			}
		}
		public string studentphoto
		{
			get
			{
				return _studentphoto;
			}
			set
			{
				_studentphoto=value;
			}
		}

		public string Professional_Qualification
		{
			get
			{
				return _Professional_Qualification;
			}
			set
			{
				_Professional_Qualification=value;
			}
		}
  
		public string Sex
		{
			get
			{
				return _Sex;
			}
			set
			{
				_Sex=value;
			}
		}

		public string Maritial_Status
		{
			get
			{
				return _Maritial_Status;
			}
			set
			{
                _Maritial_Status=value;
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


		public long Permanent_Accountno
		{
			get
			{
				return _Permanent_Accountno;
			}
			set
			{
				_Permanent_Accountno=value;
			}
		}

		public string EPF_Accountno 
		{
			get
			{
				return _EPF_Accountno;

			}
			set
			{
				_EPF_Accountno=value;
			}
		}

		public string Date_of_joining
		{
			get
			{
				return _Date_of_joining;
			}
			set
			{
				_Date_of_joining=value;
			}
		}

		public bool groupd
		{
			get
			{
				return _groupd;
			}
			set
			{
				_groupd=value;
			}
		}
		//***********End****************
		public int vehicle_id
		{
			get
			{
				return _vehicle_id;
			}
			set
			{
				_vehicle_id=value;
			}
		}
		public string NatureApp
		{
			get
			{
				return _NatureApp;
			}
			set
			{
				_NatureApp=value;
			}
		}

		public string lic_validity
		{
			get
			{
				return _lic_validity;
			}
			set
			{
				_lic_validity=value;
			}
		}

		public string dob_validity
		{
			get
			{
				return _dob_validity;
			}
			set
			{
				_dob_validity=value;
			}
		}

		public string lic_policy_no
		{
			get
			{
				return _lic_policy_no;
			}
			set
			{
				_lic_policy_no=value;
			}
		}

		public string driver_lic_no
		{
			get
			{
				return _driver_lic_no;
			}
			set
			{
				_driver_lic_no=value;
			}
		}

		public string validity
		{
			get
			{
				return _validity;
			}
			set
			{
				_validity=value;
			}

		}

		public string Staff_ID
		{
			get
			{
				return _Staff_ID;
			}
			set
			{
				_Staff_ID=value;
			}

		}

		public string Staff_Type
		{
			get
			{
				return _Staff_Type;
			}
			set
			{
				_Staff_Type=value;
			}

		}
		
		public string seq_student_id
		{
			get
			{
				return _seq_student_id;
			}
			set
			{
				_seq_student_id=value;
			}

		}

		public string Staff_Name
		{
			get
			{
				return _Staff_Name;
			}
			set
			{
				_Staff_Name=value;
			}

		}

		
		public string photo
		{
			get
			{
				return _photo;
			}
			set
			{
				_photo=value;
			}

		}


		public string Staff_PerAddress
		{
			get
			{
				return _Staff_PerAddress;
			}
			set
			{
				_Staff_PerAddress=value;
			}

		}
		public string Staff_PerCity
		{
			get
			{
				return _Staff_PerCity;
			}
			set
			{
				_Staff_PerCity=value;
			}

		}
		public string Staff_PerState
		{
			get
			{
				return _Staff_PerState;
			}
			set
			{
				_Staff_PerState=value;
			}

		}

		public string Staff_PerCountry
		{
			get
			{
				return _Staff_PerCountry;
			}
			set
			{
				_Staff_PerCountry=value;
			}

		}

		public string Student_PCountry
		{
			get
			{
				return _Student_PCountry;
			}
			set
			{
				_Student_PCountry=value;
			}

		}

		public int Staff_PerPincode
		{
			get
			{
				return _Staff_PerPincode;
			}
			set
			{
				_Staff_PerPincode=value;
			}

		}
		public string Staff_LocalAddress
		{
			get
			{
				return _Staff_LocalAddress;
			}
			set
			{
				_Staff_LocalAddress=value;
			}

		}
		public string Staff_LocalCity
		{
			get
			{
				return _Staff_LocalCity;
			}
			set
			{
				_Staff_LocalCity=value;
			}

		}
		public string Staff_LocalState
		{
			get
			{
				return _Staff_LocalState;
			}
			set
			{
				_Staff_LocalState=value;
			}

		}
		public string Staff_LocalCountry
		{
			get
			{
				return _Staff_LocalCountry;
			}
			set
			{
				_Staff_LocalCountry=value;
			}

		}
		public int Staff_LocalPincode
		{
			get
			{
				return _Staff_LocalPincode;
			}
			set
			{
				_Staff_LocalPincode=value;
			}

		}
		public string Staff_EmailID
		{
			get
			{
				return _Staff_EmailID;
			}
			set
			{
				_Staff_EmailID=value;
			}

		}


		public string Phone_No
		{
			get
			{
				return _Phone_No;
			}
			set
			{
				_Phone_No=value;
			}

		}

		
		public string Mobile_No
		{
			get
			{
				return _Mobile_No;
			}
			set
			{
				_Mobile_No=value;
			}

		}

		public string Subject_Take
		{
			get
			{
				return _Subject_Take;
			}
			set
			{
				_Subject_Take=value;
			}

		}
		
		public string Staff_education
		{
			get
			{
				return _Staff_education;
			}
			set
			{
				_Staff_education=value;
			}

		}

		
		public int Staff_exp
		{
			get
			{
				return _Staff_exp;
			}
			set
			{
				_Staff_exp=value;
			}

		}

		public bool teaching
		{
			get
			{
				return _teaching;
			}
			set
			{
				_teaching=value;
			}

		}

		public bool nonteaching
		{
			get
			{
				return _nonteaching;
			}
			set
			{
				_nonteaching=value;
			}

		}
		public bool activity
		{
			get
			{
				return _activity;
			}
			set
			{
				_activity=value;
			}

		}
		
		public string Suspendid
		{
			get
			{
				return _Suspendid;
			}
			set
			{
				_Suspendid=value;
			}

		}
		


		public string Student_ID
		{
			get
			{
				return _Student_ID;
			}
			set
			{
				_Student_ID=value;
			}

		}
		public int Student_ID1
		{
			get
			{
				return _Student_ID1;
			}
			set
			{
				_Student_ID1=value;
			}

		}
		public string Receipt_No
		{
			get
			{
				return _Receipt_No;
			}
			set
			{
				_Receipt_No=value;
			}
		}
		
		public string Student_FName
		{
			get
			{
				return _Student_FName;
			}
			set
			{
				_Student_FName=value;
			}

		}
		public string Student_MName
		{
			get
			{
				return _Student_MName;
			}
			set
			{
				_Student_MName=value;
			}


		}
		
		public string Student_LName
		{
			get
			{
				return _Student_LName;
			}
			set
			{
				_Student_LName=value;
			}

		}
		
		public string Student_FatherName
		{
			get
			{
				return _Student_FatherName;
			}
			set
			{
				_Student_FatherName=value;
			}

		}
		
		public string Student_MotherName
		{
			get
			{
				return _Student_MotherName;
			}
			set
			{
				_Student_MotherName=value;
			}

		}
		
		public string Student_FatherMobileno
		{
			get
			{
				return _Student_FatherMobileno;
			}
			set
			{
				_Student_FatherMobileno=value;
			}

		}
		
		public string Student_MotherMobileno
		{
			get
			{
				return _Student_MotherMobileno;
			}
			set
			{
				_Student_MotherMobileno=value;
			}


		}
		
		public string Student_FatherOccp
		{
			get
			{
				return _Student_FatherOccp;
			}
			set
			{
				_Student_FatherOccp=value;
			}

		}
		
		public string Student_MotherOccp
		{
			get
			{
				return _Student_MotherOccp;
			}
			set
			{
				_Student_MotherOccp=value;
			}

		}
		
		public float Student_FatherAnnualIncome
		{
			get
			{
				return _Student_FatherAnnualIncome;
			}
			set
			{
				_Student_FatherAnnualIncome=value;
			}


		}
		
		public float Student_MotherAnnualIncome
		{
			get
			{
				return _Student_MotherAnnualIncome;
			}
			set
			{
				_Student_MotherAnnualIncome=value;
			}

		}
		
		public string Student_FatherEmailID
		{
			get
			{
				return _Student_FatherEmailID;
			}
			set
			{
				_Student_FatherEmailID=value;
			}

		}
		
		public string Student_MotherEmailID
		{
			get
			{
				return _Student_MotherEmailID;
			}
			set
			{
				_Student_MotherEmailID=value;
			}

		}
		
		public string Student_Class
		{
			get
			{
				return _Student_Class;
			}
			set
			{
				_Student_Class=value;
			}

		}
		
		public string Student_Stream
		{
			get
			{
				return _Student_Stream;
			}
			set
			{
				_Student_Stream=value;
			}

		}
		
		public DateTime Student_AdmissionDate
		{
			get
			{
				return _Student_AdmissionDate;
			}
			set
			{
				_Student_AdmissionDate=value;
			}
        }
		
		public DateTime Student_Birthdate
		{
			get
			{
				return _Student_Birthdate;
			}
			set
			{
				_Student_Birthdate=value;
			}

		}
		
		public string Student_Gender
		{
			get
			{
				return _Student_Gender;
			}
			set
			{
				_Student_Gender=value;
			}

		}

//		public string Student_LAdderss
//		{
//			get
//			{
//				return _Student_LAdderss;
//			}
//			set
//			{
//				_Student_LAdderss=value;
//			}
//
//		}

		public int Reg_Id
		{
			get
			{
				return _Reg_Id;
			}
			set
			{
				_Reg_Id=value;
			}
		}

		public string Student_LCity
		{
			get
			{
				return _Student_LCity;
			}
			set
			{
				_Student_LCity=value;
			}
		}

		public string Student_LState
		{
			get
			{
				return _Student_LState;
			}
			set
			{
				_Student_LState=value;
			}

		}

		public string Admission_Status
		{
			get
			{
				return _Admission_Status;
			}
			set
			{
				_Admission_Status=value;
			}

		}
		public double RegFee
		{
			get
			{
				return _RegFee;
			}
			set
			{
				_RegFee=value;
			}

		}
		public string TestTime
		{
			get
			{
				return _TestTime;
			}
			set
			{
				_TestTime=value;
			}

		}
		public string TestDate
		{
			get
			{
				return _TestDate;
			}
			set
			{
				_TestDate=value;
			}

		}
	
		public string Student_LCountry
		{
			get
			{
				return _Student_LCountry;
			}
			set
			{
				_Student_LCountry=value;
			}

		}


		public int Student_LPincode
		{
			get
			{
				return _Student_LPincode;
			}
			set
			{
				_Student_LPincode=value;
			}

		}


		public string Student_PAddress
		{
			get
			{
				return _Student_PAddress;
			}
			set
			{
				_Student_PAddress=value;
			}

		}

		public string Student_LAddress
		{
			get
			{
				return _Student_LAddress;
			}
			set
			{
				_Student_LAddress=value;
			}

		}


		public string Student_PCity
		{
			get
			{
				return _Student_PCity;
			}
			set
			{
				_Student_PCity=value;
			}

		}


		public string Student_PState
		{
			get
			{
				return _Student_PState;
			}
			set
			{
				_Student_PState=value;
			}

		}

		public int Student_PPincode
		{
			get
			{
				return _Student_PPincode;
			}
			set
			{
				_Student_PPincode=value;
			}

		}
		public string Student_EmailID
		{
			get
			{
				return _Student_EmailID;
			}
			set
			{
				_Student_EmailID=value;
			}

		}

		public string Student_PHNo
		{
			get
			{
				return _Student_PHNo;
			}
			set
			{
				_Student_PHNo=value;
			}

		}

		public string Student_MONo
		{
			get
			{
				return _Student_MONo;
			}
			set
			{
				_Student_MONo=value;
			}

		}

		public string Student_Category
		{
			get
			{
				return _Student_Category;
			}
			set
			{
				_Student_Category=value;
			}

		}
		public string Service_Hostal
		{
			get
			{
				return _Service_Hostal;
			}
			set
			{
				_Service_Hostal=value;
			}

		}
		public string Service_Lab
		{
			get
			{
				return _Service_Lab;
			}
			set
			{
				_Service_Lab=value;
			}

		}
		public string Service_Library
		{
			get
			{
				return _Service_Library;
			}
			set
			{
				_Service_Library=value;
			}

		}
		public string Service_Bus
		{
			get
			{
				return _Service_Bus;
			}
			set
			{
				_Service_Bus=value;
			}
		}
		public string House
		{
			get
			{
				return _House;
			}
			set
			{
				_House=value;
			}
		}
		public string BG
		{
			get
			{
				return _BG;
			}
			set
			{
				_BG=value;
			}
		}
		public string RouteName
		{
			get
			{
				return _RouteName;
			}
			set
			{
				_RouteName=value;
			}
		}
		public string RouteNo
		{
			get
			{
				return _RouteNo;
			}
			set
			{
				_RouteNo=value;
			}
		}
		public string sCategory
		{
			get
			{
				return _sCategory;
			}
			set
			{
				_sCategory=value;
			}
		}
		public string Rank
		{
			get
			{
				return _Rank;
			}
			set
			{
				_Rank=value;
			}
		}

		
		#endregion

		/// <summary>
		/// Making Connection
		/// </summary>
		public regis()
		{
			
			sqcon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			sqcon.Open();
		}

		/// <summary>
		/// this method use to Insert Staff Information 
		/// </summary>
		public void insertStaffInformation()
		{
			sqcomm=new SqlCommand("ProInsertStaffInfo",sqcon);
			sqcomm.CommandType =CommandType  .StoredProcedure;
			sqcomm.Parameters.Add("@Staff_ID",Staff_ID );
			sqcomm.Parameters.Add("@Staff_Type",Staff_Type );
			sqcomm.Parameters .Add("@Staff_Name",Staff_Name );
			sqcomm.Parameters.Add("@Staff_PerAddress",Staff_PerAddress );
			sqcomm.Parameters.Add("@Staff_PerCity",Staff_PerCity );
			sqcomm.Parameters.Add("@Staff_PerState",Staff_PerState);
			sqcomm.Parameters.Add("@Staff_PerCountry",Staff_PerCountry);
			sqcomm.Parameters.Add("@Staff_PerPincode",Staff_PerPincode );
			sqcomm.Parameters.Add("@Staff_LocalAddress",Staff_LocalAddress );
     		sqcomm.Parameters.Add("@Staff_LocalCity",Staff_LocalCity );
			sqcomm.Parameters.Add("@Staff_LocalCountry",Staff_LocalCountry );
			sqcomm.Parameters.Add("@Staff_LocalState",Staff_LocalState );
			sqcomm.Parameters.Add("@Staff_LocalPincode",Staff_LocalPincode );
			sqcomm.Parameters.Add("@Staff_EmailID",Staff_EmailID);
			sqcomm.Parameters.Add("@Phone_No",Phone_No );
			sqcomm.Parameters.Add("@Mobile_No",Mobile_No );
			sqcomm.Parameters.Add("@Subject_Take",Subject_Take );
			sqcomm.Parameters.Add("@Staff_education",Staff_education);
			sqcomm.Parameters.Add("@Staff_exp",Staff_exp );
			sqcomm.Parameters.Add("@teaching",teaching);
			sqcomm.Parameters.Add("@nonteaching",nonteaching);
			sqcomm.Parameters.Add("@activity",activity);
			sqcomm.Parameters.Add ("@driver_lic_no",driver_lic_no);
			sqcomm.Parameters.Add ("@validity",validity);
			sqcomm.Parameters.Add ("@lic_policy_no",lic_policy_no);
			sqcomm.Parameters.Add ("@lic_validity",lic_validity);
			sqcomm.Parameters.Add ("@vehicle_id",vehicle_id);
			//**************gyanandra, 10.04.007****************
			sqcomm.Parameters.Add("@Father_Name",Father_Name);
			sqcomm.Parameters.Add("@Professional_qualification",Professional_Qualification );
			sqcomm.Parameters.Add("@Sex",Sex );
			sqcomm.Parameters.Add("@Maritial_Status",Maritial_Status);
			sqcomm.Parameters.Add("@Age",Age);
			sqcomm.Parameters.Add("@Permanent_Accountno",Permanent_Accountno);
			sqcomm.Parameters.Add("@EPF_Accountno",EPF_Accountno);
			sqcomm.Parameters.Add("@Date_of_joining",Date_of_joining);
			sqcomm.Parameters.Add("@groupd",groupd);
			sqcomm.Parameters.Add("@NatureApp",NatureApp);
			sqcomm.Parameters.Add("@studentphoto",studentphoto);
			//sqcomm.Parameters.Add("@Ledger_name",Staff_Name);
			//sqcomm.Parameters.Add("@Opbalance","0");
			//sqcomm.Parameters.Add("@BalType","Dr");
			//*************End*********************
			sqcomm.ExecuteNonQuery();
	 }
		
		/// <summary>
		/// this method use to Insert Student Information.
		/// </summary>
		public void InsertstudentReg()
		{ 
			sqcomm=new SqlCommand("ProInsertStudentRegInfo",sqcon);
			sqcomm.CommandType =CommandType.StoredProcedure;
			sqcomm.Parameters .Add("@Student_ID1",Student_ID1 );
			//sqcomm.Parameters .Add("@seq_Student_ID",seq_student_id );
			sqcomm.Parameters .Add("@Student_FName",Student_FName );
			//sqcomm.Parameters.Add("@Student_MName",Student_MName );
			//sqcomm.Parameters .Add("@Student_LName",Student_LName );
			sqcomm.Parameters .Add("@Student_FatherName",Student_FatherName);
			sqcomm.Parameters .Add("@Student_MotherName",Student_MotherName );
			//sqcomm.Parameters .Add("@Student_FatherMobileno",Student_FatherMobileno );
			//sqcomm.Parameters .Add("@Student_MotherMobileno",Student_MotherMobileno);
			//sqcomm.Parameters .Add("@Student_FatherOccp",Student_FatherOccp);
			//sqcomm.Parameters .Add("@Student_MotherOccp",Student_MotherOccp);
			//sqcomm.Parameters .Add("@Student_FatherAnnualIncome",Student_FatherAnnualIncome);
			//sqcomm.Parameters .Add("@Student_MotherAnnualIncome",Student_MotherAnnualIncome );
			//sqcomm.Parameters.Add("@Student_FatherEmailID",Student_FatherEmailID);
			//sqcomm.Parameters .Add("@Student_MotherEmailID",Student_MotherEmailID);
			sqcomm.Parameters .Add("@Student_Class",Student_Class);
			sqcomm.Parameters .Add("@Student_Stream",Student_Stream);
			sqcomm.Parameters .Add("@Student_AdmissionDate",Student_AdmissionDate);
			sqcomm.Parameters .Add("@Student_Birthdate",Student_Birthdate );
			sqcomm.Parameters.Add("@Student_Gender",Student_Gender);
			//sqcomm.Parameters .Add("@Student_LAdderss",Student_LAddress);
			//sqcomm.Parameters .Add("@Student_LCity",Student_LCity);
			//sqcomm.Parameters .Add("@Student_LState",Student_LState);
			//sqcomm.Parameters .Add("@Student_LPincode",Student_LPincode);
			sqcomm.Parameters .Add("@Student_PAddress",Student_PAddress );
			sqcomm.Parameters.Add("@Student_PCity",Student_PCity);
			sqcomm.Parameters .Add("@Student_PState",Student_PState);
			//sqcomm.Parameters .Add("@Student_PPincode",Student_PPincode);
			//sqcomm.Parameters .Add("@Student_EmailID",Student_EmailID);
			sqcomm.Parameters .Add("@Student_PHNo",Student_PHNo);
			//sqcomm.Parameters .Add("@Student_MONo",Student_MONo);
			sqcomm.Parameters .Add("@Student_Category",Student_Category );
			sqcomm.Parameters.Add("@Admission_Status",Admission_Status);
			//sqcomm.Parameters .Add("@Service_Hostal",Service_Hostal);
//			sqcomm.Parameters .Add("@Service_Lab",Service_Lab);
//			sqcomm.Parameters .Add("@Service_Library",Service_Library);
//			sqcomm.Parameters .Add("@Service_Bus",Service_Bus);
//			sqcomm.Parameters.Add("@Student_LCountry",Student_LCountry);
			sqcomm.Parameters.Add("@Student_PCountry",Student_PCountry);
			sqcomm.Parameters.Add("@RegFee",RegFee);
			sqcomm.Parameters.Add("@TestTime",TestTime);
			sqcomm.Parameters.Add("@TestDate",TestDate);
			sqcomm.ExecuteNonQuery();
          
		}

//		//For Insert Student Information.
//		public void Insertstudent()
//		{ 
//			sqcomm=new SqlCommand("ProInsertStudentInfo",sqcon);
//			sqcomm.CommandType =CommandType.StoredProcedure;
//			sqcomm.Parameters .Add("@Student_ID",Student_ID );
//			sqcomm.Parameters .Add("@seq_Student_ID",seq_student_id );
//			sqcomm.Parameters .Add("@Student_FName",Student_FName );
//			//sqcomm.Parameters.Add("@Student_MName",Student_MName );
//			//sqcomm.Parameters .Add("@Student_LName",Student_LName );
//			sqcomm.Parameters .Add("@Student_FatherName",Student_FatherName);
//			sqcomm.Parameters .Add("@Student_MotherName",Student_MotherName );
//			sqcomm.Parameters .Add("@Student_FatherMobileno",Student_FatherMobileno );
//			sqcomm.Parameters .Add("@Student_MotherMobileno",Student_MotherMobileno);
//			sqcomm.Parameters .Add("@Student_FatherOccp",Student_FatherOccp);
//			sqcomm.Parameters .Add("@Student_MotherOccp",Student_MotherOccp);
//			sqcomm.Parameters .Add("@Student_FatherAnnualIncome",Student_FatherAnnualIncome);
//			sqcomm.Parameters .Add("@Student_MotherAnnualIncome",Student_MotherAnnualIncome );
//			sqcomm.Parameters.Add("@Student_FatherEmailID",Student_FatherEmailID);
//			//sqcomm.Parameters .Add("@Student_MotherEmailID",Student_MotherEmailID);
//			sqcomm.Parameters .Add("@Student_Class",Student_Class);
//			sqcomm.Parameters .Add("@Student_Stream",Student_Stream);
//			sqcomm.Parameters .Add("@Student_AdmissionDate",Student_AdmissionDate);
//			sqcomm.Parameters .Add("@Student_Birthdate",Student_Birthdate );
//			sqcomm.Parameters.Add("@Student_Gender",Student_Gender);
//			sqcomm.Parameters .Add("@Student_LAdderss",Student_LAddress);
//			sqcomm.Parameters .Add("@Student_LCity",Student_LCity);
//			sqcomm.Parameters .Add("@Student_LState",Student_LState);
//			sqcomm.Parameters .Add("@Student_LPincode",Student_LPincode);
//			sqcomm.Parameters .Add("@Student_PAddress",Student_PAddress );
//			sqcomm.Parameters.Add("@Student_PCity",Student_PCity);
//			sqcomm.Parameters .Add("@Student_PState",Student_PState);
//			sqcomm.Parameters .Add("@Student_PPincode",Student_PPincode);
//			sqcomm.Parameters .Add("@Student_EmailID",Student_EmailID);
//			sqcomm.Parameters .Add("@Student_PHNo",Student_PHNo);
//			sqcomm.Parameters .Add("@Student_MONo",Student_MONo);
//			sqcomm.Parameters .Add("@Student_Category",Student_Category );
//			sqcomm.Parameters.Add("@Admission_Status",Admission_Status);
//			sqcomm.Parameters .Add("@Service_Hostal",Service_Hostal);
//			sqcomm.Parameters .Add("@Service_Lab",Service_Lab);
//			sqcomm.Parameters .Add("@Service_Library",Service_Library);
//			sqcomm.Parameters .Add("@Service_Bus",Service_Bus);
//			sqcomm.Parameters.Add("@Student_LCountry",Student_LCountry);
//			sqcomm.Parameters.Add("@Student_PCountry",Student_PCountry);
//			sqcomm.ExecuteNonQuery();
//          
//		}

		/// <summary>
		/// this method use to Update Student Information.
		/// </summary>
		public void Updatestudent()
		{ 
			sqcomm=new SqlCommand("ProUpdateStudentInfo",sqcon);
			sqcomm.CommandType =CommandType.StoredProcedure;
			sqcomm.Parameters .Add("@Student_ID",Student_ID );
			sqcomm.Parameters .Add("@seq_Student_ID",seq_student_id );
			sqcomm.Parameters .Add("@Student_FName",Student_FName );
			//sqcomm.Parameters.Add("@Student_MName",Student_MName );
			//sqcomm.Parameters .Add("@Student_LName",Student_LName );
			sqcomm.Parameters .Add("@StudentPhoto",studentphoto);
			sqcomm.Parameters .Add("@Student_FatherName",Student_FatherName);
			sqcomm.Parameters .Add("@Student_MotherName",Student_MotherName );
			sqcomm.Parameters .Add("@Student_FatherMobileno",Student_FatherMobileno );
			sqcomm.Parameters .Add("@Student_MotherMobileno",Student_MotherMobileno);
			sqcomm.Parameters .Add("@Student_FatherOccp",Student_FatherOccp);
			sqcomm.Parameters .Add("@Student_MotherOccp",Student_MotherOccp);
			sqcomm.Parameters .Add("@Student_FatherAnnualIncome",Student_FatherAnnualIncome);
			sqcomm.Parameters .Add("@Student_MotherAnnualIncome",Student_MotherAnnualIncome );
			sqcomm.Parameters.Add("@Student_FatherEmailID",Student_FatherEmailID);
			sqcomm.Parameters .Add("@Student_MotherEmailID",Student_MotherEmailID);
			sqcomm.Parameters .Add("@Student_Class",Student_Class);
			sqcomm.Parameters .Add("@Student_Stream",Student_Stream);
			sqcomm.Parameters .Add("@Student_AdmissionDate",Student_AdmissionDate);
			sqcomm.Parameters .Add("@Student_Birthdate",Student_Birthdate );
			sqcomm.Parameters.Add("@Student_Gender",Student_Gender);
			sqcomm.Parameters .Add("@Student_LAdderss",Student_LAddress);
			sqcomm.Parameters .Add("@Student_LCity",Student_LCity);
			sqcomm.Parameters .Add("@Student_LState",Student_LState);
			sqcomm.Parameters .Add("@Student_LPincode",Student_LPincode);
			sqcomm.Parameters .Add("@Student_PAddress",Student_PAddress );
			sqcomm.Parameters.Add("@Student_PCity",Student_PCity);
			sqcomm.Parameters .Add("@Student_PState",Student_PState);
			sqcomm.Parameters .Add("@Student_PPincode",Student_PPincode);
			sqcomm.Parameters .Add("@Student_EmailID",Student_EmailID);
			sqcomm.Parameters .Add("@Student_PHNo",Student_PHNo);
			sqcomm.Parameters .Add("@Student_MONo",Student_MONo);
			sqcomm.Parameters .Add("@Student_Category",Student_Category );
			sqcomm.Parameters.Add("@Admission_Status",Admission_Status);
			sqcomm.Parameters .Add("@Service_Hostal",Service_Hostal);
			//sqcomm.Parameters .Add("@Service_Lab",Service_Lab);
			//sqcomm.Parameters .Add("@Service_Library",Service_Library);
			sqcomm.Parameters .Add("@Service_Bus",Service_Bus);
			sqcomm.Parameters.Add("@Student_LCountry",Student_LCountry);
			sqcomm.Parameters.Add("@Student_PCountry",Student_PCountry);
			sqcomm.Parameters.Add("@House",House);
			sqcomm.Parameters.Add("@sCategory",sCategory);
			sqcomm.Parameters.Add("@Rank",Rank);
			sqcomm.Parameters.Add("@BG",BG);
			sqcomm.Parameters.Add("@RouteName",RouteName);
			sqcomm.Parameters.Add("@RouteNo",RouteNo);
			sqcomm.Parameters.Add("@Computer",Computer);//added by vishnu 24/09
            sqcomm.ExecuteNonQuery();
          
		}

		/// <summary>
		/// this method use to Update Student Information.
		/// </summary>
		public void Insertstudent()
		{ 
			sqcomm=new SqlCommand("ProInsertStudentInfo",sqcon);
			sqcomm.CommandType =CommandType.StoredProcedure;
			sqcomm.Parameters .Add("@Student_ID",Student_ID );
			sqcomm.Parameters .Add("@seq_Student_ID",seq_student_id );
			sqcomm.Parameters .Add("@Student_FName",Student_FName );
			//sqcomm.Parameters.Add("@Student_MName",Student_MName );
			//sqcomm.Parameters .Add("@Student_LName",Student_LName );
			sqcomm.Parameters .Add("@StudentPhoto",studentphoto);
			sqcomm.Parameters .Add("@Student_FatherName",Student_FatherName);
			sqcomm.Parameters .Add("@Student_MotherName",Student_MotherName );
			sqcomm.Parameters .Add("@Student_FatherMobileno",Student_FatherMobileno );
			sqcomm.Parameters .Add("@Student_MotherMobileno",Student_MotherMobileno);
			sqcomm.Parameters .Add("@Student_FatherOccp",Student_FatherOccp);
			sqcomm.Parameters .Add("@Student_MotherOccp",Student_MotherOccp);
			sqcomm.Parameters .Add("@Student_FatherAnnualIncome",Student_FatherAnnualIncome);
			sqcomm.Parameters .Add("@Student_MotherAnnualIncome",Student_MotherAnnualIncome );
			sqcomm.Parameters.Add("@Student_FatherEmailID",Student_FatherEmailID);
			sqcomm.Parameters .Add("@Student_MotherEmailID",Student_MotherEmailID);
			sqcomm.Parameters .Add("@Student_Class",Student_Class);
			sqcomm.Parameters .Add("@Student_Stream",Student_Stream);
			sqcomm.Parameters .Add("@Student_AdmissionDate",Student_AdmissionDate);
			sqcomm.Parameters .Add("@Student_Birthdate",Student_Birthdate );
			sqcomm.Parameters.Add("@Student_Gender",Student_Gender);
			sqcomm.Parameters .Add("@Student_LAdderss",Student_LAddress);
			sqcomm.Parameters .Add("@Student_LCity",Student_LCity);
			sqcomm.Parameters .Add("@Student_LState",Student_LState);
			sqcomm.Parameters .Add("@Student_LPincode",Student_LPincode);
			sqcomm.Parameters .Add("@Student_PAddress",Student_PAddress );
			sqcomm.Parameters.Add("@Student_PCity",Student_PCity);
			sqcomm.Parameters .Add("@Student_PState",Student_PState);
			sqcomm.Parameters .Add("@Student_PPincode",Student_PPincode);
			sqcomm.Parameters .Add("@Student_EmailID",Student_EmailID);
			sqcomm.Parameters .Add("@Student_PHNo",Student_PHNo);
			sqcomm.Parameters .Add("@Student_MONo",Student_MONo);
			sqcomm.Parameters .Add("@Student_Category",Student_Category );
			sqcomm.Parameters.Add("@Admission_Status",Admission_Status);
			sqcomm.Parameters .Add("@Service_Hostal",Service_Hostal);
			//sqcomm.Parameters .Add("@Service_Lab",Service_Lab);
			//sqcomm.Parameters .Add("@Service_Library",Service_Library);
			sqcomm.Parameters .Add("@Service_Bus",Service_Bus);
			sqcomm.Parameters.Add("@Student_LCountry",Student_LCountry);
			sqcomm.Parameters.Add("@Student_PCountry",Student_PCountry);
			sqcomm.Parameters.Add("@House",House);
			sqcomm.Parameters.Add("@sCategory",sCategory);
			sqcomm.Parameters.Add("@Rank",Rank);
			sqcomm.Parameters.Add("@BG",BG);
			sqcomm.Parameters.Add("@RouteName",RouteName);
			sqcomm.Parameters.Add("@RouteNo",RouteNo);
			sqcomm.Parameters.Add("@Computer",Computer);          //added by vishnu 24/09
			sqcomm.Parameters.Add("@year",Year);                  //add by vikas sharma date on 18.03.08
			sqcomm.Parameters.Add("@Reg_Id",Reg_Id);              //add by vikas sharma date on 04.04.09
			sqcomm.ExecuteNonQuery();
          
		}

		//*******************gyanandra************23.04.07
		/// <summary>
		/// this method use to insert card information.
		/// </summary>
		public void InsCardInformation()
		{
		
			sqcomm=new SqlCommand("proCardGeneration",sqcon);
			sqcomm.CommandType=CommandType .StoredProcedure;
			//sqcomm.Parameters .Add ("@CandidateID",CandidateID);
			
			sqcomm.Parameters .Add ("@memberID",memberID );
			sqcomm.Parameters.Add ("@Card_No",Card_NO);
			sqcomm.Parameters .Add ("@No_Of_Card",No_Of_Card);
			sqcomm.Parameters .Add ("@Validity_Of_Card",Validity_Of_Card);
			sqcomm.Parameters .Add("@Date_Of_CardGen",Date_Of_CardGen);
			sqcomm.Parameters .Add ("@Name_Of_Librarian",Name_Of_Librarian);
			sqcomm.Parameters .Add ("@Remark",Remark);
			sqcomm.Parameters .Add ("@Design",Design);
			sqcomm.Parameters.Add ("@class",Student_Class);
			//sqcomm.Parameters .Add ("@No_Of_Card",No_Of_Card);
			//sqcomm.Parameters .Add ("@Name_Of_Librarian",Name_Of_Librarian);
			sqcomm.ExecuteNonQuery();
		}
		//***********************end***********************
		/// <summary>
        /// this method use to insert Registration fees.
		/// </summary>
		public void InsertRegFee()
		{ 				
			sqcomm=new SqlCommand("ProInsertRegFee",sqcon);
			sqcomm.CommandType = CommandType.StoredProcedure;
			sqcomm.Parameters .Add("@Receipt_ID",Receipt_No);
			sqcomm.Parameters .Add("@RegID",Student_ID1);
			sqcomm.Parameters .Add("@RegFee",RegFee);
			sqcomm.ExecuteNonQuery();
		}

		/// <summary>
		/// this method use to update Registration fees.
		/// </summary>
		public void UpdateRegFee()
		{ 				
			sqcomm=new SqlCommand("ProUpdateRegFee",sqcon);
			sqcomm.CommandType = CommandType.StoredProcedure;
			sqcomm.Parameters .Add("@RegID",Student_ID1);
			sqcomm.Parameters .Add("@RegFee",RegFee);
			sqcomm.ExecuteNonQuery();
		}
	}
}
