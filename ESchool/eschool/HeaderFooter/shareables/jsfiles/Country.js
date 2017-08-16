/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.

*/
	//this function use to get item unit
	function getitemunit(t,DropUnit)
	{
		var mainarr = new Array()
		var typeindex = t.selectedIndex
		var typetext  = t.options[typeindex].text
		var hidtext = document.Form1.Txtitemcat.value
		mainarr = hidtext.split(",")
		var catgarr = new Array()
		DropUnit.value=""
		var k=0
		var unitarr = new Array()
		for(var i=0;i<(mainarr.length - 1);i++)
		{
			catgarr = mainarr[i].split(":")
			for(var j=0;j<catgarr.length;j++)
				{ 
					if(catgarr[j]==typetext)
					{ 
						DropUnit.value=catgarr[1]
						break
					}   
				}    
		}
	}
	
	//this function use to get Logistic Information 
	function getLogisticInfo(t,txtRouteNo)         
	{
		var mainarr = new Array()
		var typeindex = t.selectedIndex
		var typetext  = t.options[typeindex].text
		var hidetext =document.Form1.tempRouteNo.value
		mainarr = hidetext.split(",")
		var cityarr = new Array()
		txtRouteNo.value=""
		for(var i=0;i<(mainarr.length - 1);i++)
		{
			cityarr = mainarr[i].split(":")
			//alert(cityarr[0])
			for(var j=0;j<cityarr.length;j++ )
			{
				if(cityarr[j]==typetext)
				{ 
					txtRouteNo.value=cityarr[0]
					break
				}
			}
		}
	}		
	//this function use to get Auto select state and country acording to city
	function getBeatInfo(t,state,country)
	{
		var mainarr = new Array()
		var typeindex = t.selectedIndex
		var typetext  = t.options[typeindex].text
		//alert(typetext)
		var hidtext  = document.Form1.txtName.value
		//alert(hidtext)
		mainarr = hidtext.split(",")
		//alert(mainarr[2])
		var cityarr = new Array()
		country.value=""
		state.value=""
		var k=0
		var statearr = new Array()
		var countryarr = new Array()
		for(var i=0;i<(mainarr.length - 1);i++)
		{
			cityarr = mainarr[i].split(":")
			//alert(cityarr)
			for(var j=0;j<cityarr.length;j++ )
			{ 
				if(cityarr[j]==typetext)
				{ 
					state.value=cityarr[1]
					country.value=cityarr[0]         
					break
				}   
			}    
		}
	} 
 
	//this function use to Send text information
	function SendText()
	{ 
		var state 
		var varr = new Array()
		var country = document.Form1.DropCountry.value
		var hidarr  = document.Form1.txtName.value
		varr = hidarr.split(",")
		var sarr = new Array()
		var statearr = new Array()
		var status="n"
		var k=0
		var r =0;
		document.Form1.DropState.length=1
		document.Form1.DropCity.length=1
		for(var i=0;i<(varr.length-1);i++)
		{    
			sarr = varr[i].split(":")
			if(state==sarr[1])
				status="y"
			else
			{
				state=sarr[1]
				status="n"
			}
			for(var j=0;j<sarr.length;j++ )
			{  
				if(sarr[j]==country)
				{
					if(status!="y")
					{ 
						statearr[k]=sarr[1]
           				k++;
					}
				} 
			}
		}
		for(n=0;n<statearr.length;n++)
		{
	        document.Form1.DropState.add(new Option)  
			document.Form1.DropState.options[n+1].text=statearr[n]
		}
	}
	
	//this function use to Send City
	function SendCity()
	{ 
	   document.Form1.DropCity.length=1
		var index = document.Form1.DropState.selectedIndex
		var States = document.Form1.DropState.options[index].text
		document.Form1.txtState.value=States
		var cityarr = new Array()
		var Ctarr = new Array()
		var k=0
		var Cityarray = new Array()
		var hiddenarr  = document.Form1.txtName.value
		cityarr = hiddenarr.split(",")
		for(var i=0;i<(cityarr.length-1);i++)
		{
			Ctarr = cityarr[i].split(":")
			for(var j=0;j<Ctarr.length;j++ )
			{  
				if(Ctarr[j]==States)
				{
					Cityarray[k]=Ctarr[j+1]
					k++;
				} 
			}
		}
		for(n=0;n<Cityarray.length;n++)
		{
	        document.Form1.DropCity.add(new Option)  
			document.Form1.DropCity.options[n+1].text=Cityarray[n]
		}
	}

	//this function use to Send City
	function SendCity3()
	{ 
		document.Form1.DropPerCity.length=1
		var index = document.Form1.DropPerState.selectedIndex
	    var States = document.Form1.DropPerState.options[index].text
		document.Form1.txtState.value=States
		var cityarr = new Array()
		var Ctarr = new Array()
		var k=0
		var Cityarray = new Array()
		var hiddenarr  = document.Form1.txtName.value
		cityarr = hiddenarr.split(",")
		for(var i=0;i<(cityarr.length-1);i++)
		{
			Ctarr = cityarr[i].split(":")
			for(var j=0;j<Ctarr.length;j++ )
			{  
				if(Ctarr[j]==States)
				{
					Cityarray[k]=Ctarr[j+1]
					k++;
				} 
			}
	}
    for(n=0;n<Cityarray.length;n++)
    {
        document.Form1.DropPerCity.add(new Option)  
        document.Form1.DropPerCity.options[n+1].text=Cityarray[n]
	}
  }
  
   //this function use to Select City
   function SelectCity()
	{
	    var index = document.Form1.DropCity.selectedIndex
		var City = document.Form1.DropCity.options[index].text
		document.Form1.txtCity.value=City
	}
	
	//this function use to send Text information
	function SendText1()
	{ 
	  var state 
		var varr = new Array()
		var country = document.Form1.DropCountry1.value
		var hidarr  = document.Form1.txtName.value
		varr = hidarr.split(",")
		var sarr = new Array()
		var statearr = new Array()
		var status="n"
		var k=0
		var r =0;
		document.Form1.DropState1.length=1
		document.Form1.DropCity1.length=1
		for(var i=0;i<(varr.length-1);i++)
		{
			sarr = varr[i].split(":")
			if(state==sarr[1])
				status="y"
			else	
			{
				state=sarr[1]
				status="n"
			}
			for(var j=0;j<sarr.length;j++ )
			{  
		      if(sarr[j]==country)
			  {
				if(status!="y")
				{ 
					statearr[k]=sarr[1]
           			k++;
				}
			  } 
			}
		}
		for(n=0;n<statearr.length;n++)
		{
	        document.Form1.DropState1.add(new Option)  
			document.Form1.DropState1.options[n+1].text=statearr[n]
		}
	}
	
	//this function use to Send City
	function SendCity1()
	{ 
		document.Form1.DropCity1.length=1
		var index = document.Form1.DropState1.selectedIndex
		var States = document.Form1.DropState1.options[index].text
		document.Form1.txtState1.value=States
		var cityarr = new Array()
		var Ctarr = new Array()
		var k=0
		var Cityarray = new Array()
		var hiddenarr  = document.Form1.txtName.value
		cityarr = hiddenarr.split(",")
		for(var i=0;i<(cityarr.length-1);i++)
		{
			Ctarr = cityarr[i].split(":")
			for(var j=0;j<Ctarr.length;j++ )
			{  
				if(Ctarr[j]==States)
				{
					Cityarray[k]=Ctarr[j+1]
					k++;
				} 
			}
		}
		for(n=0;n<Cityarray.length;n++)
		{
	        document.Form1.DropCity1.add(new Option)  
			document.Form1.DropCity1.options[n+1].text=Cityarray[n]
		}
	}
 
	//this function use to get item unit
	function SelectCity1()
	{
		var index = document.Form1.DropCity1.selectedIndex
		var City = document.Form1.DropCity1.options[index].text
		document.Form1.txtCity1.value=City
	}
	//this function use to end text
	function SendText2()
	{ 
	  var state 
		var varr = new Array()
		var country = document.Form2.DropCountry1.value
		var hidarr  = document.Form2.txtName.value
		varr = hidarr.split(",")
		var sarr = new Array()
		var statearr = new Array()
		var status="n"
		var k=0
		var r =0;
		document.Form2.DropState1.length=1
		document.Form2.DropCity1.length=1
		for(var i=0;i<(varr.length-1);i++)
		{
		    sarr = varr[i].split(":")
			if(state==sarr[1])
				status="y"
			else
			{
				state=sarr[1]
				status="n"
			}
			for(var j=0;j<sarr.length;j++ )
			{  
		      if(sarr[j]==country)
			  {
				if(status!="y")
				{ 
					statearr[k]=sarr[1]
           			k++;
				}
			  } 
			}
		}
	     for(n=0;n<statearr.length;n++)
		{
	        document.Form2.DropState1.add(new Option)  
			document.Form2.DropState1.options[n+1].text=statearr[n]
		}
	 }
	 //this function use to send city
	function SendCity2()
	{ 
		document.Form2.DropCity1.length=1
		var index = document.Form2.DropState1.selectedIndex
		var States = document.Form2.DropState1.options[index].text
		document.Form2.txtState1.value=States
		var cityarr = new Array()
		var Ctarr = new Array()
		var k=0
		var Cityarray = new Array()
		var hiddenarr  = document.Form2.txtName.value
		cityarr = hiddenarr.split(",")
		for(var i=0;i<(cityarr.length-1);i++)
		{
			Ctarr = cityarr[i].split(":")
			for(var j=0;j<Ctarr.length;j++ )
			{  
				if(Ctarr[j]==States)
				{
					Cityarray[k]=Ctarr[j+1]
					k++;
				} 
			}	
		}
		for(n=0;n<Cityarray.length;n++)
		{
	        document.Form2.DropCity1.add(new Option)  
			document.Form2.DropCity1.options[n+1].text=Cityarray[n]
		}
	}
	//this function use to Select city
	function SelectCity2()
	{
		var index = document.Form2.DropCity1.selectedIndex
		var City = document.Form2.DropCity1.options[index].text
		document.Form2.txtCity1.value=City
	}