gx.evt.autoSkip=!1;gx.define("gx0020",!1,function(){var n,t;this.ServerClass="gx0020";this.PackageName="GeneXus.Programs";this.ServerFullClass="gx0020.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV8pCountryId=gx.fn.getIntegerValue("vPCOUNTRYID",",")};this.e130q1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e110q1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("COUNTRYIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("COUNTRYIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCCOUNTRYID","Visible",!0)):(gx.fn.setCtrlProperty("COUNTRYIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCCOUNTRYID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("COUNTRYIDFILTERCONTAINER","Class")',ctrl:"COUNTRYIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCCOUNTRYID","Visible")',ctrl:"vCCOUNTRYID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e120q1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("COUNTRYNAMEFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("COUNTRYNAMEFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCCOUNTRYNAME","Visible",!0)):(gx.fn.setCtrlProperty("COUNTRYNAMEFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCCOUNTRYNAME","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("COUNTRYNAMEFILTERCONTAINER","Class")',ctrl:"COUNTRYNAMEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCCOUNTRYNAME","Visible")',ctrl:"vCCOUNTRYNAME",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e160q2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e170q1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,35,36,37,38,39,40,41];this.GXLastCtrlId=41;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",34,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx0020",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",35,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(3,36,"COUNTRYID","Id","","CountryId","int",0,"px",4,4,"right",null,[],3,"CountryId",!0,0,!1,!1,"Attribute",1,"WWColumn");t.addSingleLineEdit(4,37,"COUNTRYNAME","Name","","CountryName","char",0,"px",20,20,"left",null,[],4,"CountryName",!0,0,!1,!1,"DescriptionAttribute",1,"WWColumn");t.addBitmap(12,"COUNTRYFLAG",38,0,"px",17,"px",null,"","Flag","ImageAttribute","WWColumn OptionalColumn");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"COUNTRYIDFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLCOUNTRYIDFILTER",format:1,grid:0,evt:"e110q1_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCCOUNTRYID",fmt:0,gxz:"ZV6cCountryId",gxold:"OV6cCountryId",gxvar:"AV6cCountryId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cCountryId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cCountryId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCCOUNTRYID",gx.O.AV6cCountryId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cCountryId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCCOUNTRYID",",")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"COUNTRYNAMEFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLCOUNTRYNAMEFILTER",format:1,grid:0,evt:"e120q1_client",ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCCOUNTRYNAME",fmt:0,gxz:"ZV7cCountryName",gxold:"OV7cCountryName",gxvar:"AV7cCountryName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7cCountryName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7cCountryName=n)},v2c:function(){gx.fn.setControlValue("vCCOUNTRYNAME",gx.O.AV7cCountryName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7cCountryName=this.val())},val:function(){return gx.fn.getControlValue("vCCOUNTRYNAME")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"GRIDTABLE",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"BTNTOGGLE",grid:0,evt:"e130q1_client"};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[35]={id:35,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:34,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",fmt:0,gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(34),gx.O.AV5LinkSelection,gx.O.AV12Linkselection_GXI)},c2v:function(n){gx.O.AV12Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(34))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(34))},gxvar_GXI:"AV12Linkselection_GXI",nac:gx.falseFn};n[36]={id:36,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:34,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COUNTRYID",fmt:0,gxz:"Z3CountryId",gxold:"O3CountryId",gxvar:"A3CountryId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A3CountryId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z3CountryId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("COUNTRYID",n||gx.fn.currentGridRowImpl(34),gx.O.A3CountryId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A3CountryId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("COUNTRYID",n||gx.fn.currentGridRowImpl(34),",")},nac:gx.falseFn};n[37]={id:37,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:34,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COUNTRYNAME",fmt:0,gxz:"Z4CountryName",gxold:"O4CountryName",gxvar:"A4CountryName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A4CountryName=n)},v2z:function(n){n!==undefined&&(gx.O.Z4CountryName=n)},v2c:function(n){gx.fn.setGridControlValue("COUNTRYNAME",n||gx.fn.currentGridRowImpl(34),gx.O.A4CountryName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A4CountryName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("COUNTRYNAME",n||gx.fn.currentGridRowImpl(34))},nac:gx.falseFn};n[38]={id:38,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:34,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COUNTRYFLAG",fmt:0,gxz:"Z12CountryFlag",gxold:"O12CountryFlag",gxvar:"A12CountryFlag",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A12CountryFlag=n)},v2z:function(n){n!==undefined&&(gx.O.Z12CountryFlag=n)},v2c:function(n){gx.fn.setGridMultimediaValue("COUNTRYFLAG",n||gx.fn.currentGridRowImpl(34),gx.O.A12CountryFlag,gx.O.A40000CountryFlag_GXI)},c2v:function(n){gx.O.A40000CountryFlag_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.A12CountryFlag=this.val(n))},val:function(n){return gx.fn.getGridControlValue("COUNTRYFLAG",n||gx.fn.currentGridRowImpl(34))},val_GXI:function(n){return gx.fn.getGridControlValue("COUNTRYFLAG_GXI",n||gx.fn.currentGridRowImpl(34))},gxvar_GXI:"A40000CountryFlag_GXI",nac:gx.falseFn};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"BTN_CANCEL",grid:0,evt:"e170q1_client"};this.AV6cCountryId=0;this.ZV6cCountryId=0;this.OV6cCountryId=0;this.AV7cCountryName="";this.ZV7cCountryName="";this.OV7cCountryName="";this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z3CountryId=0;this.O3CountryId=0;this.Z4CountryName="";this.O4CountryName="";this.Z12CountryFlag="";this.O12CountryFlag="";this.AV6cCountryId=0;this.AV7cCountryName="";this.A40000CountryFlag_GXI="";this.AV8pCountryId=0;this.AV5LinkSelection="";this.A3CountryId=0;this.A4CountryName="";this.A12CountryFlag="";this.Events={e160q2_client:["ENTER",!0],e170q1_client:["CANCEL",!0],e130q1_client:["'TOGGLE'",!1],e110q1_client:["LBLCOUNTRYIDFILTER.CLICK",!1],e120q1_client:["LBLCOUNTRYNAMEFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cCountryId",fld:"vCCOUNTRYID",pic:"ZZZ9"},{av:"AV7cCountryName",fld:"vCCOUNTRYNAME",pic:""}],[]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLCOUNTRYIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("COUNTRYIDFILTERCONTAINER","Class")',ctrl:"COUNTRYIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("COUNTRYIDFILTERCONTAINER","Class")',ctrl:"COUNTRYIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCCOUNTRYID","Visible")',ctrl:"vCCOUNTRYID",prop:"Visible"}]];this.EvtParms["LBLCOUNTRYNAMEFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("COUNTRYNAMEFILTERCONTAINER","Class")',ctrl:"COUNTRYNAMEFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("COUNTRYNAMEFILTERCONTAINER","Class")',ctrl:"COUNTRYNAMEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCCOUNTRYNAME","Visible")',ctrl:"vCCOUNTRYNAME",prop:"Visible"}]];this.EvtParms.ENTER=[[{av:"A3CountryId",fld:"COUNTRYID",pic:"ZZZ9",hsh:!0}],[{av:"AV8pCountryId",fld:"vPCOUNTRYID",pic:"ZZZ9"}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cCountryId",fld:"vCCOUNTRYID",pic:"ZZZ9"},{av:"AV7cCountryName",fld:"vCCOUNTRYNAME",pic:""}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cCountryId",fld:"vCCOUNTRYID",pic:"ZZZ9"},{av:"AV7cCountryName",fld:"vCCOUNTRYNAME",pic:""}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cCountryId",fld:"vCCOUNTRYID",pic:"ZZZ9"},{av:"AV7cCountryName",fld:"vCCOUNTRYNAME",pic:""}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cCountryId",fld:"vCCOUNTRYID",pic:"ZZZ9"},{av:"AV7cCountryName",fld:"vCCOUNTRYNAME",pic:""}],[]];this.setVCMap("AV8pCountryId","vPCOUNTRYID",0,"int",4,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gx0020)})