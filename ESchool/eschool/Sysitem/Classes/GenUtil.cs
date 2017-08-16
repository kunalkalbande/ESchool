/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
*/
using System;
using System.Data;
using System.Data.SqlClient;
using RMG;

namespace eschool.Classes
{
	/// <summary>
	/// Summary description for GenUtil.
	/// </summary>
	public class GenUtil
	{
		public GenUtil()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// Method to force 2 Digits of precission for numeric values
		/// </summary>
		public static string strNumericFormat(string str)
		{
			int pos = -1;
			pos = str.IndexOf(".");

			if(pos != -1)
			{
				string s = str.Substring(pos);
				if(s.Length > 2)
				{
					if(s.Length != 3)
						str = System.Convert.ToString(System.Math.Round(System.Convert.ToDouble(str),2));   
                      
					if(str.IndexOf(".") == -1)
						str = str+".00";

					if(str.Substring(pos).Length  == 2)
						str = str+"0";
				                   
				}
				else
				{

					str = str + "0";
				}
			}
			else

			{
				if(!str.Trim().Equals(""))  
				str = str+".00";
			}
			return str;
		}

		//Name :-Mahesh & Bhalchand, Modify date :-07/08/2006(dd/mm/yyyy).
		//changes :- Add this function.
		
		/// <summary>
		/// This method is used to separate time from date and returns only date in mm/dd/yyyy
		/// </summary>
		public static string trimDate(string strDate)
		{
			
			int pos = strDate.IndexOf(" ");

			if(pos != -1)
			{
				strDate = strDate.Substring(0,pos);
			}
			else
			{
						
			}
			return strDate;
		}
		/// <summary>
		/// This method is used to Convert in to monthname
		/// </summary>
		public static string ConvertMonthName(string strDate)
		{
			string[] dt=strDate.Split(new char[] {'/'},strDate.Length);
			string Mon="";
			if(dt[1]=="1" || dt[1]=="01")
				Mon="January";
			else if(dt[1]=="2" || dt[1]=="02")
				Mon="February";
			else if(dt[1]=="3" || dt[1]=="03")
				Mon="March";
			else if(dt[1]=="4" || dt[1]=="04")
				Mon="April";
			else if(dt[1]=="5" || dt[1]=="05")
				Mon="May";
			else if(dt[1]=="6" || dt[1]=="06")
				Mon="June";
			else if(dt[1]=="7" || dt[1]=="07")
				Mon="July";
			else if(dt[1]=="8" || dt[1]=="08")
				Mon="August";
			else if(dt[1]=="9" || dt[1]=="09")
				Mon="September";
			else if(dt[1]=="10")
				Mon="October";
			else if(dt[1]=="11")
				Mon="November";
			else if(dt[1]=="12")
				Mon="December";
		return Mon+" "+dt[2];
		}
		
		/// <summary>
		/// function to convert DDMMYY to MM/DD/YYYY
		/// </summary>
		public static DateTime ToMMddYYYY(string str)
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

		/// <summary>
		/// Return Date in DD/MM/YYYY for Display and Print Input is MM/DD/YYYY
		/// </summary>
		public static string str2DDMMYYYY(string  str)
		{
			if(!str.Trim().Equals(""))  
			{
				string[] strTokens = str.Split(new char[] {'/'},str.Length);
				return strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
			}
			else
			return "";
		}

	
		/// <summary>
		/// Return Date in MM/DD/YYYY for Display and Print, Input is DD/MM/YYYY
		/// </summary>
		public static string str2MMDDYYYY(string  str)
		{
			if(!str.Trim().Equals(""))  
			{
				string[] strTokens = str.Split(new char[] {'/'},str.Length);
				return strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
			}
			else
				return "";
		
		}
	
		/// <summary>
		/// This function to trim the spaces according to length. 
		/// </summary>
		public static string TrimLength(string str,int len)
		{
			if(str.Length > len)
			{
				str = str.Substring(0,len); 
			}
			return str;
		}

		/// <summary>
		/// This function use to GetCenter of string. 
		///e.g. the string is "eschool" then return  
		///and this value return in string
		/// </summary>
		public static string GetCenterAddr(string Addr,int Len)
		{
			int address=Addr.Length;
			int ss=0;
			string sp="";
			if(Len > Addr.Length)
				ss=(Len-address)/2;
			else
				ss=0;
			for(int i=0;i<ss;i++)
			{
				sp=sp+" ";
			}
			return sp+Addr;
		}
		/// <summary>
		/// This function use to AddColumnNames as per as student class and stream basis and 
		///return the concatenate string
		/// </summary>
		public static string AddColumnNames(string cls,string stream)
		{
			InventoryClass obj1=new InventoryClass();
			InventoryClass obj2=new InventoryClass();
			SqlDataReader SqlDtr;
			//string str1="select subject_name from subject where subject_id in (select subject_id from classwisesubjects where class_id='"+cls+"' and stream='"+stream+"') order by subject_name";
			//string str1="select subject_name from subject where subject_id in (select subject_id from classwisesubjects where class_id='"+cls+"' and stream='"+stream+"') order by subject_name";04.09.08
			  string str1="select subject_name from subject where subject_id in (select subject_id from classwisesubjects where class_id='"+cls+"' and stream='"+stream+"') and status=1 order by subject_name";
			SqlDtr=obj1.GetRecordSet(str1);
			string col="";
			string name="";
			while(SqlDtr.Read())
			{
				name=SqlDtr.GetValue(0).ToString().Trim();
				if(name.IndexOf(" ")>0)
					name=name.Replace(" ","_");
				if(name.IndexOf("&")>0)
					name=name.Replace("&","and");
				if(name.Equals("COMPUTER"))
					name=name + "_tot";
				if(name.Equals("PHYSICS"))
					name=name + "_tot";
				if(name.Equals("BIOLOGY"))
					name=name+ "_tot";
				if(name.Equals("CHEMISTRY"))
					name=name+ "_tot" ;
				col=col+name;
				col=col+",";
					
			}	
			SqlDtr.Close();
			if(col!="")
				col=col.Substring(0,col.Length-1);
			return col;
		}

		/// <summary>
		/// This function use to AddColumnNames. 
		/// </summary>
		public static string AddColumnNames1(string cls,string stream)
		{
			InventoryClass obj1=new InventoryClass();
			InventoryClass obj2=new InventoryClass();
			SqlDataReader SqlDtr;
			string str1="select subject_name from subject where subject_id in (select subject_id from classwisesubjects where class_id='"+cls+"' and stream='"+stream+"') order by subject_name";
			SqlDtr=obj1.GetRecordSet(str1);
			string col="";
			string name="";
			while(SqlDtr.Read())
			{
				name=SqlDtr.GetValue(0).ToString().Trim();
				if(name.IndexOf(" ")>0)
					name=name.Replace(" ","_");
				if(name.IndexOf("&")>0)
					name=name.Replace("&","and");
				if(cls=="3" || cls=="4" || cls=="5" || cls=="6" || cls=="7" || cls=="8" || cls=="9" || cls=="10")
				{
					if(name.Equals("COMPUTER"))
						name=name + "_tot";
					if(name.Equals("PHYSICS"))
						name=name + "_tot";
					if(name.Equals("BIOLOGY"))
						name=name + "_tot";
					if(name.Equals("CHEMISTRY"))
						name=name + "_tot" ;
				}
				else
				{
					if(name.Equals("COMPUTER"))
						name=name + "_th, " +name + "_pr, " + name +  "_tot";
					if(name.Equals("PHYSICS"))
						name=name + "_th, " + name + "_pr, "+ name+ "_tot";
					if(name.Equals("BIOLOGY"))
						name=name+"_th, " + name + "_pr, "+name+ "_tot";
					if(name.Equals("CHEMISTRY"))
						name=name+"_th, " + name + "_pr, "+ name + "_tot" ;
				}
				
				col=col+name;
				col=col+",";
					
			}	
			SqlDtr.Close();
			if(col!="")
				col=col.Substring(0,col.Length-1);
			return col;
		}

		/// <summary>
		/// This function use to AddColumnNames. 
		/// </summary>
		public static string AddColumnNames2(string cls,string stream)
		{
			InventoryClass obj1=new InventoryClass();
			InventoryClass obj2=new InventoryClass();
			SqlDataReader SqlDtr;
			string str1="select subject_name from subject where subject_id in (select subject_id from classwisesubjects where class_id='"+cls+"' and stream='"+stream+"') order by subject_name";
			SqlDtr=obj1.GetRecordSet(str1);
			string col="";
			string name="";
			while(SqlDtr.Read())
			{
				name=SqlDtr.GetValue(0).ToString().Trim();
				if(name.IndexOf(" ")>0)
					name=name.Replace(" ","_");
				if(name.IndexOf("&")>0)
					name=name.Replace("&","and");
				
				if(name.Equals("ENGLISH"))
				{
					name=name.Replace("ENGLISH","Eng_Read,Eng_Writing,Eng_Con,Eng_Spelling,Eng_Compre");
				}
				else if(name.Equals("COMPUTER"))
				{
					name=name.Replace("COMPUTER","Computer_tot");
				}
				else if(name.Equals("HINDI"))
				{
					name=name.Replace("HINDI","Hindi_Read,Hindi_Writing,Hindi_Con,Hindi_spelling,Hindi_Com");
				}
				else if(name.Equals("MATHEMATICS"))
				{
					name=name.Replace("MATHEMATICS","Math_FNumber,Math_BConcept,Math_Computation");
				}
				else if(name.Equals("EVS"))
				{
					name=name.Replace("EVS","evs_observation,evs_Identification,Evs_know");
				}
				col=col+name;
				col=col+",";
			}	
			SqlDtr.Close();
			if(col!="")
				col=col.Substring(0,col.Length-1);
			return col;
		}

		/// <summary>
		/// This method use to convert number in word. 
		/// </summary>
		public static string ConvertNoToWord(string number)
		{
			string[] num=new string[2];
			int count=0,div=0;
			if(number.IndexOf(".")>0)
			{
				num=number.Split(new char[] {'.'},number.Length);
				div=System.Convert.ToInt32(num[0]);
			}
			else
				div=System.Convert.ToInt32(number);
				
			int[] arr1=new int[12];
			int[] arr2=new int[12];
	        
			String[] digit1={"ZERO","ONE","TWO","THREE","FOUR","FIVE","SIX","SEVEN","EIGHT","NINE","TEN","ELEVAN","TWELVE","THRTEEN","FOURTEEN","FIFTEEN","SIXTEEN","SEVENTEEN","EIGHTEEN","NINETEEN","TWENTY","THIRTY","FOURTY","FIFTY","SIXTY","SEVENTY","EIGHTY","NINTY"};
			String[] digit2 ={"","hundred","thousand","lakh","crore"};   
			String[] array=new String[20];
			while(div>0)
			{
				arr1[count]=div%10;
				div=div/10;
				count++;
			}
		
			if(count>=10)
			{
				MessageBox.Show("Please Enter Nine Digit Number");
			}
			if(count==0)
			{
				array[0]="ZERO";
			}
			div=System.Convert.ToInt32(num[0]);
			for(int i=count-1;i>=0;--i)
			{
				if(i==1||i==4||i==6||i==8)
				{
					arr2[i]=arr1[i]*10;
				}
				else
				{
					arr2[i]=arr1[i];
				}
			}
			for(int i=count-1,j=0;i>=0;++j,--i)
			{
				if(i==8&&arr2[i]!=0)
				{
					int dig=arr2[i];
			  
					if(dig>=20&&arr2[i-1]==0)
					{
						array[j]=digit1[dig/10+18];
						array[j+1]=digit2[4];
						--i;
						++j;
					}
					else if(dig>=20&&arr2[i-1]!=0)
					{
						array[j]=digit1[dig/10+18];
					}
					else if(dig>9)
					{
						dig=arr2[i]+arr2[i-1];
						array[j]=digit1[dig];
						array[j+1]=digit2[4];
						--i;
						++j;
					}
				}
				else if(i==7)
				{
					if(arr2[i]!=0)
					{
						int dig=arr2[i];
						array[j]=digit1[dig];
						array[j+1]=digit2[4];
						++j;
					}
				}
				else if(i==6&&arr2[i]!=0)
				{
					int dig=arr2[i];
			  
					if(dig>=20&&arr2[i-1]==0)
					{
						array[j]=digit1[dig/10+18];
						array[j+1]=digit2[3];
						--i;
						++j;
					}
					else if(dig>=20&&arr2[i-1]!=0)
					{
						dig=arr2[i];
						array[j]=digit1[dig/10+18];
					}
					else if(dig>9)
					{
						dig=arr2[i]+arr2[i-1];
						array[j]=digit1[dig];
						array[j+1]=digit2[3];
						--i;
						++j;
					}
			  		 
				}
				else if(i==5)
				{
					if(arr2[i]!=0)
					{
						int dig=arr2[i];
						array[j]=digit1[dig];
						array[j+1]=digit2[3];
						++j;
					}
				}
				else if(i==4&&arr2[i]!=0)
				{
					int dig=arr2[i];
			  
					if(dig>=20&&arr2[i-1]==0)
					{
						array[j]=digit1[dig/10+18];
						array[j+1]=digit2[2];
						--i;
						++j;
					}
					else if(dig>=20&&arr2[i-1]!=0)
					{
						dig=arr2[i];
						array[j]=digit1[dig/10+18];
					}
					else if(dig>9)
					{
						dig=arr2[i]+arr2[i-1];
						array[j]=digit1[dig];
						array[j+1]=digit2[2];
						--i;
						++j;
					}
			  
				}

				else if(i==3)
				{
					if(arr2[i]!=0)
					{			
						int dig=arr2[i]; 
						array[j]=digit1[dig];
						array[j+1]=digit2[2];
						++j;
					}
			
				}
				else if(i==2)
				{
					if(arr2[i]!=0)
					{
						int dig=arr2[i];
						array[j]=digit1[dig];
						array[j+1]=digit2[1];
						++j;
					}
			 			  
				}
				else if(i==1)
				{
					int dig=arr2[i];
					if(dig>=20&&arr2[i]!=0&&arr2[i-1]==0)
					{
						dig=arr2[i];
						array[j]=digit1[dig/10+18];
						--i;
					}
					else if(dig>=20&&arr2[i-1]!=0)
					{
						dig=arr2[i];
						array[j]=digit1[dig/10+18];
					}
					else if(dig>9)
					{
						dig=arr2[i]+arr2[i-1];
						array[j]=digit1[dig];
						--i;
					}
			  
				}
				else if(i==0)
				{
					int dig=arr2[i];
					if(arr2[i]!=0)
					{
						array[j]=digit1[dig];
					}
				}
			}    
			string no="";
			for(int i=0;i<array.Length;i++)
			{
				if(array[i]!=null)

					no=no+StringUtil.FirstCharUpper(array[i])+" ";
			}
			return (no);
		}
	}

}
