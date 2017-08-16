/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.

*/
	var f1=false
	var f2=false
	var f3=false
	var f4=false
	var f5=false
	var f6=false
	var f7=false
	var f8=false
	var f9=false
	var f10=false
	var f11=false
	var f12=false
	
	//this function use to adjust fees ammount
	function AdjustAmount(t)         // add by vikas sharma date on 29.02.08
    {       
		var cur=t.value
        var lastanl=document.RecuringFeesReceipt.Tempanual.value;
        var lastdf=document.RecuringFeesReceipt.Tempdiary.value;
        var lastef=document.RecuringFeesReceipt.TempDevlop.value;
        var lastTuti=document.RecuringFeesReceipt.TempTuti.value;
        var lastCompu=document.RecuringFeesReceipt.TempCompu.value;
        var lastHouse=document.RecuringFeesReceipt.TempHouse.value;
        var lastScie=document.RecuringFeesReceipt.TempScie.value;
        var lastActi=document.RecuringFeesReceipt.TempActi.value;
        var lastTrans=document.RecuringFeesReceipt.TempTrans.value;
        var lastGemes=document.RecuringFeesReceipt.TempGemes.value;
        var lastAdmiss=document.RecuringFeesReceipt.TempAdmiss.value;
        // var lastlf=document.RecuringFeesReceipt.txtlf.value;
        // alert(last+" : "+cur)
		if(t==document.RecuringFeesReceipt.txtanf)
        {                     
			if(t.value !="" && document.RecuringFeesReceipt.TxtAmount.value!="" && f1==false)
			{
				document.RecuringFeesReceipt.TxtAmount.value=document.RecuringFeesReceipt.TxtAmount.value-parseFloat(lastanl)+parseFloat(cur);
				document.RecuringFeesReceipt.txtamt.value=document.RecuringFeesReceipt.TxtAmount.value
				f1=true
            }
            else if(f1==true)
            {
				alert("If you want to change Please Refresh the Form")
		    }
			//else 
			//	{
			//		document.RecuringFeesReceipt.TxtAmount.value=document.RecuringFeesReceipt.TxtAmount.value-parseFloat(lastanl);
            //   }
       }
       else if(t==document.RecuringFeesReceipt.txtdf)
       {
			if(t.value!="" && document.RecuringFeesReceipt.TxtAmount.value!="" && f2==false )
			{
				document.RecuringFeesReceipt.TxtAmount.value=document.RecuringFeesReceipt.TxtAmount.value-parseFloat(lastdf)+parseFloat(cur);
				document.RecuringFeesReceipt.txtamt.value=document.RecuringFeesReceipt.TxtAmount.value
				f2=true
            }
            else if(f2==true)
            {
				alert("If you want to change Please Refresh the Form")
			}
		}
        else if(t==document.RecuringFeesReceipt.txtef)
        {
            if(t.value!="" && document.RecuringFeesReceipt.TxtAmount.value!="" && f3==false)
			{
				document.RecuringFeesReceipt.TxtAmount.value=document.RecuringFeesReceipt.TxtAmount.value-parseFloat(lastef)+parseFloat(cur);
				document.RecuringFeesReceipt.txtamt.value=document.RecuringFeesReceipt.TxtAmount.value
				f3=true
            }
			else if(f3==true)
            {
				alert("If you want to change Please Refresh the Form")
		    }
        }
        else if(t==document.RecuringFeesReceipt.txtlf)
        {
             if(t.value!="" && document.RecuringFeesReceipt.TxtAmount.value!="" && f4==false)
		     {
				document.RecuringFeesReceipt.TxtAmount.value=parseFloat(document.RecuringFeesReceipt.TxtAmount.value)+parseFloat(cur);
				document.RecuringFeesReceipt.txtamt.value=document.RecuringFeesReceipt.TxtAmount.value
				f4=true
             }
			 else if(f4==true)
             {
				alert("If you want to change Please Refresh the Form")
			 }
        }
        else if(t==document.RecuringFeesReceipt.txttf)
        {
             if(t.value!="" && document.RecuringFeesReceipt.TxtAmount.value!="" && f5==false)
		     {
				document.RecuringFeesReceipt.TxtAmount.value=parseFloat(document.RecuringFeesReceipt.TxtAmount.value)-parseFloat(lastTuti)+parseFloat(cur);
				document.RecuringFeesReceipt.txtamt.value=document.RecuringFeesReceipt.TxtAmount.value
				f5=true
             }
			 else if(f5==true)
             {
				alert("If you want to change Please Refresh the Form")
			 }
        }
        else if(t==document.RecuringFeesReceipt.txtcf)
        {
             if(t.value!="" && document.RecuringFeesReceipt.TxtAmount.value!="" && f6==false)
		  	 {
				document.RecuringFeesReceipt.TxtAmount.value=parseFloat(document.RecuringFeesReceipt.TxtAmount.value)-parseFloat(lastCompu)+parseFloat(cur);
				document.RecuringFeesReceipt.txtamt.value=document.RecuringFeesReceipt.TxtAmount.value
				f6=true
             }
			 else if(f6==true)
             {
				alert("If you want to change Please Refresh the Form")
			 }
        }
        else if(t==document.RecuringFeesReceipt.txtsf)
        {
             if(t.value!="" && document.RecuringFeesReceipt.TxtAmount.value!="" && f7==false)
		  	 {
				document.RecuringFeesReceipt.TxtAmount.value=parseFloat(document.RecuringFeesReceipt.TxtAmount.value)-parseFloat(lastScie)+parseFloat(cur);
				document.RecuringFeesReceipt.txtamt.value=document.RecuringFeesReceipt.TxtAmount.value
				f7=true
             }
			 else if(f7==true)
             {
				alert("If you want to change Please Refresh the Form")
			 }
        }
        else if(t==document.RecuringFeesReceipt.txtaf)
        {
            if(t.value!="" && document.RecuringFeesReceipt.TxtAmount.value!="" && f8==false)
		    {
				document.RecuringFeesReceipt.TxtAmount.value=parseFloat(document.RecuringFeesReceipt.TxtAmount.value)-parseFloat(lastActi)+parseFloat(cur);
				document.RecuringFeesReceipt.txtamt.value=document.RecuringFeesReceipt.TxtAmount.value
				f8=true
            }
			else if(f8==true)
            {
			    alert("If you want to change Please Refresh the Form")
			}
        }
        else if(t==document.RecuringFeesReceipt.txtgf)
        {
            if(t.value!="" && document.RecuringFeesReceipt.TxtAmount.value!="" && f9==false)
			{
				document.RecuringFeesReceipt.TxtAmount.value=parseFloat(document.RecuringFeesReceipt.TxtAmount.value)-parseFloat(lastGemes)+parseFloat(cur);
				document.RecuringFeesReceipt.txtamt.value=document.RecuringFeesReceipt.TxtAmount.value
				f9=true
            }
			else if(f9==true)
            {
				alert("If you want to change Please Refresh the Form")
		    }
                 }
                  else if(t==document.RecuringFeesReceipt.txttrf)
                 {
                        if(t.value!="" && document.RecuringFeesReceipt.TxtAmount.value!="" && f10==false)
							{
								document.RecuringFeesReceipt.TxtAmount.value=parseFloat(document.RecuringFeesReceipt.TxtAmount.value)-parseFloat(lastTrans)+parseFloat(cur);
								document.RecuringFeesReceipt.txtamt.value=document.RecuringFeesReceipt.TxtAmount.value
								f10=true
                            }
						else if(f10==true)
                           {
								alert("If you want to change Please Refresh the Form")
						   }
                 }
                  else if(t==document.RecuringFeesReceipt.txtadf)
                 {
                        if(t.value!="" && document.RecuringFeesReceipt.TxtAmount.value!="" && f11==false)
							{
								document.RecuringFeesReceipt.TxtAmount.value=parseFloat(document.RecuringFeesReceipt.TxtAmount.value)-parseFloat(lastAdmiss)+parseFloat(cur);
								document.RecuringFeesReceipt.txtamt.value=document.RecuringFeesReceipt.TxtAmount.value
								f11=true
                            }
						else if(f11==true)
                           {
								alert("If you want to change Please Refresh the Form")
						   }
                 }
                 else if(t==document.RecuringFeesReceipt.txthf)
                 {
                        if(t.value!="" && document.RecuringFeesReceipt.TxtAmount.value!="" && f12==false)
							{
								document.RecuringFeesReceipt.TxtAmount.value=parseFloat(document.RecuringFeesReceipt.TxtAmount.value)-parseFloat(lastHouse)+parseFloat(cur);
								document.RecuringFeesReceipt.txtamt.value=document.RecuringFeesReceipt.TxtAmount.value
								f12=true
                            }
						else if(f12==true)
                           {
								alert("If you want to change Please Refresh the Form")
						   }
                 }
          
	      }
	       
			//this function use to adjust fees ammount
		    function validate1()
			{ 
				alert("Test")
				/*var f=0;
				var frm=document.Tc;
				var index = frm.Dropclass.selectedIndex;
				var Dropclass = frm.Dropclass.options[index].text;
				if(Dropclass=="Select")
				{
				//if(frm.e_name.value!=first_name)
				//{
				f=1;
				alert("Please Select");
				//frm.e_name.focus();
				//exit(1);
				return
				}*/
			}
	
			//this function use to get only number
			function GetOnlyNumbers(obj, e, AllowNegative, AllowDecimal)
			{
				var key;
				var isCtrl = false;
				var keychar;
				var reg;
				if(window.event) 
				{
					key = e.keyCode;
					isCtrl = window.event.ctrlKey
					//alert(isCtrl);
				}
				else if(e.which)
				{
					key = e.which;
					alert(key)
					isCtrl = e.ctrlKey;
				}
				//	if (isNaN(key)) return true;
				keychar = String.fromCharCode(key);
				//  alert(keychar)
				if(keychar == '-' && obj.value.length < 0)
				return false;
				// 	check for backspace or delete, or if Ctrl was pressed
				if (key == 8 || isCtrl)
				{
					return true;
				}
				reg = /\d/;
				var AllowNegNums = AllowNegative ? keychar == '-' && obj.value.indexOf('-') == -1 : false;
				var AllowDecNums = AllowDecimal ? keychar == '.' && obj.value.indexOf('.') == -1 : false;	
				return AllowNegNums || AllowDecNums || reg.test(keychar);
			}

			// this function use to get number and char both
			function GetAnyNumber(obj, e)
			{
				var key;
				var isCtrl = false;
				var keychar;
				var reg;
				if(window.event) 
				{
					key = e.keyCode;
					isCtrl = window.event.ctrlKey
				}
				keychar = String.fromCharCode(key);
				if(keychar>='A'&&keychar<='Z')
					return true;
				else if(keychar>='a'&&keychar<='z')
					return true;
				else if(keychar==' ')
					return true
				else if(keychar=='(')
					return true
				else if(keychar==')')
					return true
				else if(keychar>='0' && keychar<='9')
					return true
				else if(keychar=='@' || keychar=='-' || keychar=='_' || keychar=='.' || keychar=='&' || keychar=='%')
					return true
				else if (key == 8 || isCtrl)
					return true;
				else
					return false;
			}
			
			// this function use to only chars
			function GetOnlyChars(obj, e)
			{
				var key;
				var isCtrl = false;
				var keychar;
				if(window.event) 
				{
					key = e.keyCode;
					isCtrl = window.event.ctrlKey
				}
				keychar = String.fromCharCode(key);
				if(keychar>='A'&&keychar<='Z')
					return true;
				else if(keychar>='a'&&keychar<='z')
					return true;
				else if(keychar==' ')
					return true
				else if (key == 8 || isCtrl)
					return true;
				else
					return false;
			}

			function Check1(txtCity)
			{
				alert("hello1");
				return false;
			}
			
			// this function use to Get only number and capital A is also allow
			function GetOnlyNumbersWithA(obj, e, AllowNegative, AllowDecimal,AllowToA)
			{
				var key;
				var isCtrl = false;
				var keychar;
				var reg;
				if(window.event) 
				{
					key = e.keyCode;
					isCtrl = window.event.ctrlKey
				}
				else if(e.which) 
				{
					key = e.which;
					isCtrl = e.ctrlKey;
				}
				//	if (isNaN(key)) return true;
				keychar = String.fromCharCode(key);
				if(keychar=='-'&&obj.value.length>0)
					return false;
				// 	check for backspace or delete, or if Ctrl was pressed

				if (key == 8 || isCtrl)
				{
					return true;
				}
				reg = /\d/;
				var AllowNegNums = AllowNegative ? keychar == '-' && obj.value.indexOf('-') == -1 : false;
				var AllowDecNums = AllowDecimal ? keychar == '.' && obj.value.indexOf('.') == -1 : false;	
				var AllowToAChar = AllowToA ? keychar == 'A' && obj.value.indexOf('A') == -1 : false;	
				return AllowNegNums || AllowDecNums || AllowToAChar || reg.test(keychar);
			}

			// this function use to get only number and allow only 'All'
			function GetOnlyAllorNo(obj, e)
			{
				//alert("Enter")
				var key;
				var isCtrl = false;
				var keychar;
				if(window.event)
				{
					key = e.keyCode;
					isCtrl = window.event.ctrlKey
				}
				keychar = String.fromCharCode(key);
				if(keychar=='a'&&obj.value.length<=0)
					return true;
				else if(keychar=='l'&&obj.value.length>0 && (obj.value=='a' || obj.value=='al'))
					return true;
				else if(keychar>='0' && keychar <='9' && (obj.value!='a'&&obj.value!='al'&&obj.value!='all'))
					return true;
				else if (key == 8 || isCtrl)
					return true;
				else
					return false;
			}

			// this function use to Check date format
			function checkDate()
			{
				var index=document.RecuringFeesReceipt.all.dropmop.selectedIndex;
				var mmode=document.RecuringFeesReceipt.all.dropmop.options[index].value
				var date="";
				//alert(index)
				//alert(mmode)
				//if(index>0)
				if(index>=0)
				{
					if(mmode=="By Draft")
						date=document.RecuringFeesReceipt.txtdraftDate.value;
					else if(mmode=="By Cheque")
						date=document.RecuringFeesReceipt.txtchDate.value;
					alert(date.indexOf('/'))
					alert(date.lastIndexOf('/'))
					if(date.indexOf('/')>0)
					{
						if(date.lastIndexOf('/')<=date.indexOf('/'))
						{
							alert("Date is invalid formate");
							if(mmode=="By Draft")
								document.RecuringFeesReceipt.txtdraftDate.value="";
							else if(mmode=="By Cheque")
			        			document.RecuringFeesReceipt.txtchDate.value="";
						}
					}
					else
					{
						alert("Date is invalid formate");
						if(mmode=="By Draft")
							document.RecuringFeesReceipt.txtdraftDate.value="";
						else if(mmode=="By Cheque")
				        	document.RecuringFeesReceipt.txtchDate.value="";
					}
					var  d=date.split('/');
					if((d[2]%4==0 && d[2]%100)||d[2]%400==0)
					{
						if(d[1]>13)
						{
							alert("Invalid Month");
							if(mmode=="By Draft")
								document.RecuringFeesReceipt.txtdraftDate.value="";
							else if(mmode=="By Cheque")
			        			document.RecuringFeesReceipt.txtchDate.value="";
							return;
						}
						if(d[1]==1||d[1]==3||d[1]==5||d[1]==7||d[1]==8||d[1]==10||d[1]==12)
						{
							if(d[0]>31)
							{
								alert("Invalid date");
								if(mmode=="By Draft")
									document.RecuringFeesReceipt.txtdraftDate.value="";
								else if(mmode=="By Cheque")
			        				document.RecuringFeesReceipt.txtchDate.value="";
							}	
						}
						else if(d[1]==2)
						{
							if(d[0]>29)
							{
								alert("Invalid date");
								if(mmode=="By Draft")
									document.RecuringFeesReceipt.txtdraftDate.value="";
								else if(mmode=="By Cheque")
			        				document.RecuringFeesReceipt.txtchDate.value="";
							  }
						}
						else if(d[1]==4||d[1]==6||d[1]==9||d[1]==11)
						{
							if(d[0]>30)
							{
								alert("Invalid date");
								if(mmode=="By Draft")
									document.RecuringFeesReceipt.txtdraftDate.value="";
								else if(mmode=="By Cheque")
			        				document.RecuringFeesReceipt.txtchDate.value="";
							}	
						}	
					}
					else
					{
						if(d[1]>=13)
						{
							alert("Invalid Month");
							if(mmode=="By Draft")
								document.RecuringFeesReceipt.txtdraftDate.value="";
							else if(mmode=="By Cheque")
			        			document.RecuringFeesReceipt.txtchDate.value="";
			        		return;
						}
			  			if(d[1]==1||d[1]==3||d[1]==5||d[1]==7||d[1]==8||d[1]==10||d[1]==12)
						{
							if(d[0]>31)
							{
								alert("Invalid date");
								if(mmode=="By Draft")
									document.RecuringFeesReceipt.txtdraftDate.value="";
								else if(mmode=="By Cheque")
			        				document.RecuringFeesReceipt.txtchDate.value="";
							}	
						}
						else if(d[1]==2)
						{
							if(d[0]>28)
							{
								alert("Invalid date");
								if(mmode=="By Draft")
									document.RecuringFeesReceipt.txtdraftDate.value="";
								else if(mmode=="By Cheque")
			        				document.RecuringFeesReceipt.txtchDate.value="";
							}
						}
						else if(d[1]==4||d[1]==6||d[1]==9||d[1]==11)
						{
							if(d[0]>30)
							{
								alert("Invalid date");
								if(mmode=="By Draft")
									document.RecuringFeesReceipt.txtdraftDate.value="";
								else if(mmode=="By Cheque")
			        				document.RecuringFeesReceipt.txtchDate.value="";
							}	
						}
					}		 
				}
			}
