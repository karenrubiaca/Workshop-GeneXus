gx.evt.autoSkip=!1;gx.define("gx0010",!1,function(){var n,t;this.ServerClass="gx0010";this.PackageName="GeneXus.Programs";this.ServerFullClass="gx0010.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV8pCategoryId=gx.fn.getIntegerValue("vPCATEGORYID",",")};this.e130p1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e110p1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("CATEGORYIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("CATEGORYIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCCATEGORYID","Visible",!0)):(gx.fn.setCtrlProperty("CATEGORYIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCCATEGORYID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("CATEGORYIDFILTERCONTAINER","Class")',ctrl:"CATEGORYIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCCATEGORYID","Visible")',ctrl:"vCCATEGORYID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e120p1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("CATEGORYNAMEFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("CATEGORYNAMEFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCCATEGORYNAME","Visible",!0)):(gx.fn.setCtrlProperty("CATEGORYNAMEFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCCATEGORYNAME","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("CATEGORYNAMEFILTERCONTAINER","Class")',ctrl:"CATEGORYNAMEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCCATEGORYNAME","Visible")',ctrl:"vCCATEGORYNAME",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e160p2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e170p1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,35,36,37,38,39,40];this.GXLastCtrlId=40;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",34,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx0010",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",35,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(1,36,"CATEGORYID","Id","","CategoryId","int",0,"px",4,4,"right",null,[],1,"CategoryId",!0,0,!1,!1,"Attribute",1,"WWColumn");t.addSingleLineEdit(2,37,"CATEGORYNAME","Name","","CategoryName","char",0,"px",20,20,"left",null,[],2,"CategoryName",!0,0,!1,!1,"DescriptionAttribute",1,"WWColumn");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"CATEGORYIDFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLCATEGORYIDFILTER",format:1,grid:0,evt:"e110p1_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCCATEGORYID",fmt:0,gxz:"ZV6cCategoryId",gxold:"OV6cCategoryId",gxvar:"AV6cCategoryId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cCategoryId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cCategoryId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCCATEGORYID",gx.O.AV6cCategoryId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cCategoryId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCCATEGORYID",",")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"CATEGORYNAMEFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLCATEGORYNAMEFILTER",format:1,grid:0,evt:"e120p1_client",ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCCATEGORYNAME",fmt:0,gxz:"ZV7cCategoryName",gxold:"OV7cCategoryName",gxvar:"AV7cCategoryName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7cCategoryName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7cCategoryName=n)},v2c:function(){gx.fn.setControlValue("vCCATEGORYNAME",gx.O.AV7cCategoryName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7cCategoryName=this.val())},val:function(){return gx.fn.getControlValue("vCCATEGORYNAME")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"GRIDTABLE",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"BTNTOGGLE",grid:0,evt:"e130p1_client"};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[35]={id:35,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:34,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",fmt:0,gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(34),gx.O.AV5LinkSelection,gx.O.AV12Linkselection_GXI)},c2v:function(n){gx.O.AV12Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(34))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(34))},gxvar_GXI:"AV12Linkselection_GXI",nac:gx.falseFn};n[36]={id:36,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:34,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CATEGORYID",fmt:0,gxz:"Z1CategoryId",gxold:"O1CategoryId",gxvar:"A1CategoryId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A1CategoryId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1CategoryId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("CATEGORYID",n||gx.fn.currentGridRowImpl(34),gx.O.A1CategoryId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A1CategoryId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("CATEGORYID",n||gx.fn.currentGridRowImpl(34),",")},nac:gx.falseFn};n[37]={id:37,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:34,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CATEGORYNAME",fmt:0,gxz:"Z2CategoryName",gxold:"O2CategoryName",gxvar:"A2CategoryName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A2CategoryName=n)},v2z:function(n){n!==undefined&&(gx.O.Z2CategoryName=n)},v2c:function(n){gx.fn.setGridControlValue("CATEGORYNAME",n||gx.fn.currentGridRowImpl(34),gx.O.A2CategoryName,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2CategoryName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("CATEGORYNAME",n||gx.fn.currentGridRowImpl(34))},nac:gx.falseFn};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"BTN_CANCEL",grid:0,evt:"e170p1_client"};this.AV6cCategoryId=0;this.ZV6cCategoryId=0;this.OV6cCategoryId=0;this.AV7cCategoryName="";this.ZV7cCategoryName="";this.OV7cCategoryName="";this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z1CategoryId=0;this.O1CategoryId=0;this.Z2CategoryName="";this.O2CategoryName="";this.AV6cCategoryId=0;this.AV7cCategoryName="";this.AV8pCategoryId=0;this.AV5LinkSelection="";this.A1CategoryId=0;this.A2CategoryName="";this.Events={e160p2_client:["ENTER",!0],e170p1_client:["CANCEL",!0],e130p1_client:["'TOGGLE'",!1],e110p1_client:["LBLCATEGORYIDFILTER.CLICK",!1],e120p1_client:["LBLCATEGORYNAMEFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cCategoryId",fld:"vCCATEGORYID",pic:"ZZZ9"},{av:"AV7cCategoryName",fld:"vCCATEGORYNAME",pic:""}],[]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLCATEGORYIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("CATEGORYIDFILTERCONTAINER","Class")',ctrl:"CATEGORYIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("CATEGORYIDFILTERCONTAINER","Class")',ctrl:"CATEGORYIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCCATEGORYID","Visible")',ctrl:"vCCATEGORYID",prop:"Visible"}]];this.EvtParms["LBLCATEGORYNAMEFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("CATEGORYNAMEFILTERCONTAINER","Class")',ctrl:"CATEGORYNAMEFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("CATEGORYNAMEFILTERCONTAINER","Class")',ctrl:"CATEGORYNAMEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCCATEGORYNAME","Visible")',ctrl:"vCCATEGORYNAME",prop:"Visible"}]];this.EvtParms.ENTER=[[{av:"A1CategoryId",fld:"CATEGORYID",pic:"ZZZ9",hsh:!0}],[{av:"AV8pCategoryId",fld:"vPCATEGORYID",pic:"ZZZ9"}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cCategoryId",fld:"vCCATEGORYID",pic:"ZZZ9"},{av:"AV7cCategoryName",fld:"vCCATEGORYNAME",pic:""}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cCategoryId",fld:"vCCATEGORYID",pic:"ZZZ9"},{av:"AV7cCategoryName",fld:"vCCATEGORYNAME",pic:""}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cCategoryId",fld:"vCCATEGORYID",pic:"ZZZ9"},{av:"AV7cCategoryName",fld:"vCCATEGORYNAME",pic:""}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cCategoryId",fld:"vCCATEGORYID",pic:"ZZZ9"},{av:"AV7cCategoryName",fld:"vCCATEGORYNAME",pic:""}],[]];this.setVCMap("AV8pCategoryId","vPCATEGORYID",0,"int",4,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gx0010)})