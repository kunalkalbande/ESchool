	
	//this function use to search word as same as textbox value
	var z=0
	function search1(t,tempst)
	{
	    //document.Form1.DropCustName.style.visibility="visible"
	    var val=new Array()
		var count=0
		var z=0    
		t.length=1
		var items=new Array()
		var name=tempst.value
		items=name.split(",")
		var count=items.length
		t.length=count-1		
		for(var j=0;j<count-1;j++)
		{
		    t.options[j].text=items[j]
		}
	}
	
	//this function use to Select particular word
	function select(t,text)
	{
		text.value=t.options[t.selectedIndex].text
		t.style.visibility="hidden";
		t.style.height=0
	}
	
	function MouseMove(t)
	{
		//t.selectedIndex = 0
		//var j=t.selectedIndex
		//alert(j)
	}
	
	//this function use to Select any word by enter key
	function Selectbyenter(t,e,text,temp)
	{
		if(text.value!="" && t.style.visibility!="hidden")
		{
			if(window.event) 
			{
				var	key = e.keyCode;
				if(key==13)
				{
					var j=t.selectedIndex
					text.value=t.options[j].text
					t.style.visibility="hidden"
					t.style.height=0
					if(t.name=="DropCustName")
					{
						getBalanceontext(document.Form1.text1,document.Form1.lblPlace,document.Form1.lblDueDate,document.Form1.lblCurrBalance,document.Form1.lblCreditLimit,document.Form1.TxtCrLimit,document.Form1.txtVehicleNo,document.Form1.DropUnderSalesMan)
					}
					if(text.value!="" && text.value!="Type")
						temp.focus();
					else
						text.focus();
				}
				/*if(key==18)
				{
					var j=t.selectedIndex
					document.Form1.text1.value=t.options[j].text
					document.Form1.DropCustName.style.visibility="hidden"
					document.Form1.DropCustName.style.height=0
				}*/
			}
		}
	}
	
	//this function use to select from listbox when key down arrow key
	function arrowkeydown(t,e,Drop,tempst)
	{
		if(window.event) 
		{
			var	key = e.keyCode;
			if(key==40)
			{
				if(Drop.length!=0)
				{
					if(t.value=="")
						search1(Drop,tempst)
					Drop.style.visibility="visible"
					Drop.style.height=120
					Drop.focus();
					var j=Drop.selectedIndex
					t.value=Drop.options[j].text
					if(Drop.name=="DropCustName")
						getBalanceontext(document.Form1.text1,document.Form1.lblPlace,document.Form1.lblDueDate,document.Form1.lblCurrBalance,document.Form1.lblCreditLimit,document.Form1.TxtCrLimit,document.Form1.txtVehicleNo,document.Form1.DropUnderSalesMan)
				}
			}
			if(key==8)
			{
				if(t.value=="Selec" || t.value=="Typ")
					t.value="";
			}
	    }
	    
	}
	
	//this function use to Hide the listbox
	function HideList(t,text)
	{
		//alert("TEST"+t.focus())
		var j=t.selectedIndex
		text.value=t.options[j].text
		t.style.visibility="hidden"
		t.style.height=0
	}
	
	//this function use to open the listbox
	function OpenList(t)
	{
		//alert(t.onfocus)
		//alert(t.onFocus())
		if(t.length!=0)
		{
			t.style.visibility="visible"
			t.style.height=120
		}
	}
	
	//this function use to get focus
	function ScrollList(t)
	{
		alert("scroll")
		t.focus()
	}
	
	//this function use to Select by arrow key
	function arrowkeyselect(t,e,v,text)
	//function arrowkeyselect(t,e)
	{
		
		if(window.event) 
		{
			var	key = e.keyCode;
			//alert("k:"+key)
			if(key==40)
			{
				var j=t.selectedIndex
				text.value=t.options[j].text
			}
			if(key ==38)
			{
				var j=t.selectedIndex
				text.value=t.options[j].text
			}
			else
			{
				var j=t.selectedIndex
				text.value=t.options[j].text
			}
			if(text.value!="Type" && text.value!="Select")
			{
				if(key==9||key==13)
					v.focus()
			}
	    }
	}
	
	//this function use to Select by mouse button
	function mousekeyselect(t)
	{
		var j=t.selectedIndex
		document.Form1.text1.value=t.options[j].text
	}
		
	//this function use to Dropdown show
	function dropshow(t)
	{
		if(t.style.visibility=="hidden")
		{
			if(t.length!=0)
			{
				t.style.visibility="visible"
				t.style.height=120
				t.selectedIndex=0
			}
		}
		else
		{
			t.style.visibility="hidden"
		    t.style.height=0
		}
	}
	function Test()
	{
		alert("")
	}
	/*function funclose(t,v)
	{
				var j=t.selectedIndex
				document.Form1.text1.value=t.options[j].text
				//document.Form1.DropCustName.style.visibility="hidden"
				//v.focus()
				
	}*/
	
	
	/*function setvalue()
	{
		if(klm==0)
		{
			document.Form1.text1.value=""
			klm++
			//alert(klm)
		}
	}*/
	
	//this function use to Check value equel or not
	function search3(text,t,v1)
	{
		//document.Form1.DropCustName.style.visibility="visible";
        //var j=v1
		//var j=document.Form1.texthidden.value
		
		var val=new Array()
		var count=0
		var z=0		     
		
		//t.length=1
		
		var items=new Array()
		//var name=v1
		val=v1.split(",");
		/*
		items=name.split(",")
		var count=items.length
		
		for(var i=0;i<count-1;i++)
		{
			val[i]=items[i]
		}*/
		
		//val.sort()
				  
        var v=text.value
                 		 
		//if(v!="")
		//**if(v != "" && v != "All" && v != "Select" && v != "Type")
		//**{
			var val1=text.value
			var al=new Array();
			var c=0;
			var k=0
			var flag=false
			
			for(var i=0;i<val.length;i++)
			{
				var v1=val[i]
				val1=val1.toUpperCase()
				v1=v1.toUpperCase()
				if(val1.indexOf("(")>=0)
				{
					if(val1.indexOf(")")>=0)
					{
						if(v1.search(val1)==0)
						{
							al[c]=val[i]
							c++;
							k=i;
							flag=true;
							break;
						}
						else
						{
							//break; //added 24/05
							flag=false
						}
					}
				}
				else
				{
					if(v1.search(val1)==0)
					{
						al[c]=val[i]
						c++;
						k=i;
						flag=true;
						break;
					}
					else
					{
						//break; //added 24/05
						flag=false
					}
				}
			}
			
			if(flag==true)
			{
				if(t.length!=0)
				{
					t.style.visibility="visible";
					t.style.height=120
				}
			}
			else
			{
							
				t.style.visibility="hidden";
				t.style.height=0
			}
			
			for(i=k+1;i<val.length;i++)
			{
				al[c]=val[i]
				c++;
			}
			
			
			t.length=c
			for(var i=0;i<c;i++)
			{
				//t.add(new Option)
				t.options[i].text=al[i]				
			}
			
			//t.pageY+=(-20);
			//t.style.pixelTop+=(-100);
			//t.visLevel-=2
			//alert("t.visLevel"+t.visLevel);
			//alert("h"+t.offsetWidth)
			//alert("h"+t.offsetHeight)
			//alert("p"+t.offsetParent)
			
			//v2.z-index=0
			//t.z-index=2
			//alert("Layer"+getlayer(t.rc[0]))
			//document.Form1.DropCustName.style.visibility="hidden";
			//document.Form1.DropCustName.style.zIndex="100"
			//document.Form1.DropCustName.style.visibility="visible";
			t.selectedIndex=0
			
		/*}
		else
		{
		   t.style.visibility="hidden";
		   t.style.height=0
		   
		}*/	
		
    }