gx.evt.autoSkip=!1;gx.define("wwshoppingcart",!1,function(){var n,t;this.ServerClass="wwshoppingcart";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwshoppingcart.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV15ADVANCED_LABEL_TEMPLATE=gx.fn.getControlValue("vADVANCED_LABEL_TEMPLATE");this.AV15ADVANCED_LABEL_TEMPLATE=gx.fn.getControlValue("vADVANCED_LABEL_TEMPLATE")};this.Validv_Shoppingcartdate=function(){return this.validCliEvt("Validv_Shoppingcartdate",0,function(){try{var n=gx.util.balloon.getNew("vSHOPPINGCARTDATE");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV11ShoppingCartDate)===0||new gx.date.gxdate(this.AV11ShoppingCartDate).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Field Shopping Cart Date is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Shoppingcartdatedelivery=function(){return this.validCliEvt("Validv_Shoppingcartdatedelivery",0,function(){try{var n=gx.util.balloon.getNew("vSHOPPINGCARTDATEDELIVERY");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV12ShoppingCartDateDelivery)===0||new gx.date.gxdate(this.AV12ShoppingCartDateDelivery).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Field Shopping Cart Date Delivery is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Shoppingcartid=function(){var n=gx.fn.currentGridRowImpl(39);return this.validCliEvt("Valid_Shoppingcartid",39,function(){try{if(gx.fn.currentGridRowImpl(39)===0)return!0;var n=gx.util.balloon.getNew("SHOPPINGCARTID",gx.fn.currentGridRowImpl(39));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Shoppingcartdate=function(){var n=gx.fn.currentGridRowImpl(39);return this.validCliEvt("Valid_Shoppingcartdate",39,function(){try{if(gx.fn.currentGridRowImpl(39)===0)return!0;var n=gx.util.balloon.getNew("SHOPPINGCARTDATE",gx.fn.currentGridRowImpl(39));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Customerid=function(){var n=gx.fn.currentGridRowImpl(39);return this.validCliEvt("Valid_Customerid",39,function(){try{if(gx.fn.currentGridRowImpl(39)===0)return!0;var n=gx.util.balloon.getNew("CUSTOMERID",gx.fn.currentGridRowImpl(39));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Countryid=function(){var n=gx.fn.currentGridRowImpl(39);return this.validCliEvt("Valid_Countryid",39,function(){try{if(gx.fn.currentGridRowImpl(39)===0)return!0;var n=gx.util.balloon.getNew("COUNTRYID",gx.fn.currentGridRowImpl(39));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e110d1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("FILTERSCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("FILTERSCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("GRIDCELL","Class","WWGridCell"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","HideFiltersButton"),gx.fn.setCtrlProperty("BTNTOGGLE","Caption","Hide Filters"),gx.fn.setCtrlProperty("BTNTOGGLE","Tooltiptext","Hide Filters")):(gx.fn.setCtrlProperty("FILTERSCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("GRIDCELL","Class","WWGridCellExpanded"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","ShowFiltersButton"),gx.fn.setCtrlProperty("BTNTOGGLE","Caption","Show Filters"),gx.fn.setCtrlProperty("BTNTOGGLE","Tooltiptext","Show Filters")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("FILTERSCONTAINER","Class")',ctrl:"FILTERSCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("GRIDCELL","Class")',ctrl:"GRIDCELL",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Caption"},{ctrl:"BTNTOGGLE",prop:"Tooltiptext"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e120d1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("SHOPPINGCARTDATEDELIVERYFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?gx.fn.setCtrlProperty("SHOPPINGCARTDATEDELIVERYFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"):gx.fn.setCtrlProperty("SHOPPINGCARTDATEDELIVERYFILTERCONTAINER","Class","AdvancedContainerItem"),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("SHOPPINGCARTDATEDELIVERYFILTERCONTAINER","Class")',ctrl:"SHOPPINGCARTDATEDELIVERYFILTERCONTAINER",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e130d2_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e170d2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e180d2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,37,38,40,41,42,43,44,45,46,47,48,49,50,51];this.GXLastCtrlId=51;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",39,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"wwshoppingcart",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.GridContainer;t.addSingleLineEdit(11,40,"SHOPPINGCARTID","Cart Id","","ShoppingCartId","int",0,"px",4,4,"right",null,[],11,"ShoppingCartId",!1,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(28,41,"SHOPPINGCARTDATE","Date","","ShoppingCartDate","date",0,"px",8,8,"right",null,[],28,"ShoppingCartDate",!0,0,!1,!1,"DescriptionAttribute",1,"WWColumn");t.addSingleLineEdit(32,42,"SHOPPINGCARTDATEDELIVERY","Delivery Date","","ShoppingCartDateDelivery","date",0,"px",8,8,"right",null,[],32,"ShoppingCartDateDelivery",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(6,43,"CUSTOMERID","Customer Id","","CustomerId","int",0,"px",4,4,"right",null,[],6,"CustomerId",!1,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(15,44,"CUSTOMERNAME","Customer","","CustomerName","char",0,"px",20,20,"left",null,[],15,"CustomerName",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(3,45,"COUNTRYID","Country Id","","CountryId","int",0,"px",4,4,"right",null,[],3,"CountryId",!1,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(4,46,"COUNTRYNAME","Country","","CountryName","char",0,"px",20,20,"left",null,[],4,"CountryName",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(16,47,"CUSTOMERADDRESS","Address","","CustomerAddress","svchar",0,"px",1024,80,"left",null,[],16,"CustomerAddress",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(18,48,"CUSTOMERPHONE","Phone","","CustomerPhone","char",0,"px",20,20,"left",null,[],18,"CustomerPhone",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(29,49,"SHOPPINGCARTFINALPRICE","Cart Total","","ShoppingCartFinalPrice","decimal",0,"px",12,12,"right",null,[],29,"ShoppingCartFinalPrice",!0,2,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit("Update",50,"vUPDATE","","","Update","char",0,"px",20,20,"left",null,[],"Update","Update",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");t.addSingleLineEdit("Delete",51,"vDELETE","","","Delete","char",0,"px",20,20,"left",null,[],"Delete","Delete",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");this.GridContainer.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLETOP",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"BTNTOGGLE",grid:0,evt:"e110d1_client"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"TITLETEXT",format:0,grid:0,ctrltype:"textblock"};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"BTNINSERT",grid:0,evt:"e130d2_client"};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Shoppingcartdate,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vSHOPPINGCARTDATE",fmt:0,gxz:"ZV11ShoppingCartDate",gxold:"OV11ShoppingCartDate",gxvar:"AV11ShoppingCartDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[18],ip:[18],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11ShoppingCartDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV11ShoppingCartDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vSHOPPINGCARTDATE",gx.O.AV11ShoppingCartDate,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11ShoppingCartDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vSHOPPINGCARTDATE")},nac:gx.falseFn};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"FILTERSCONTAINER",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"SHOPPINGCARTDATEDELIVERYFILTERCONTAINER",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"LBLSHOPPINGCARTDATEDELIVERYFILTER",format:1,grid:0,evt:"e120d1_client",ctrltype:"textblock"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Shoppingcartdatedelivery,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vSHOPPINGCARTDATEDELIVERY",fmt:0,gxz:"ZV12ShoppingCartDateDelivery",gxold:"OV12ShoppingCartDateDelivery",gxvar:"AV12ShoppingCartDateDelivery",dp:{f:-1,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[31],ip:[31],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12ShoppingCartDateDelivery=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV12ShoppingCartDateDelivery=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vSHOPPINGCARTDATEDELIVERY",gx.O.AV12ShoppingCartDateDelivery,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV12ShoppingCartDateDelivery=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vSHOPPINGCARTDATEDELIVERY")},nac:gx.falseFn};n[32]={id:32,fld:"GRIDCELL",grid:0};n[33]={id:33,fld:"GRIDTABLE",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[40]={id:40,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:39,gxgrid:this.GridContainer,fnc:this.Valid_Shoppingcartid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SHOPPINGCARTID",fmt:0,gxz:"Z11ShoppingCartId",gxold:"O11ShoppingCartId",gxvar:"A11ShoppingCartId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A11ShoppingCartId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z11ShoppingCartId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("SHOPPINGCARTID",n||gx.fn.currentGridRowImpl(39),gx.O.A11ShoppingCartId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A11ShoppingCartId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("SHOPPINGCARTID",n||gx.fn.currentGridRowImpl(39),",")},nac:gx.falseFn};n[41]={id:41,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:39,gxgrid:this.GridContainer,fnc:this.Valid_Shoppingcartdate,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SHOPPINGCARTDATE",fmt:0,gxz:"Z28ShoppingCartDate",gxold:"O28ShoppingCartDate",gxvar:"A28ShoppingCartDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A28ShoppingCartDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z28ShoppingCartDate=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("SHOPPINGCARTDATE",n||gx.fn.currentGridRowImpl(39),gx.O.A28ShoppingCartDate,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A28ShoppingCartDate=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("SHOPPINGCARTDATE",n||gx.fn.currentGridRowImpl(39))},nac:gx.falseFn};n[42]={id:42,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:39,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SHOPPINGCARTDATEDELIVERY",fmt:0,gxz:"Z32ShoppingCartDateDelivery",gxold:"O32ShoppingCartDateDelivery",gxvar:"A32ShoppingCartDateDelivery",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A32ShoppingCartDateDelivery=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z32ShoppingCartDateDelivery=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("SHOPPINGCARTDATEDELIVERY",n||gx.fn.currentGridRowImpl(39),gx.O.A32ShoppingCartDateDelivery,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A32ShoppingCartDateDelivery=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("SHOPPINGCARTDATEDELIVERY",n||gx.fn.currentGridRowImpl(39))},nac:gx.falseFn};n[43]={id:43,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:39,gxgrid:this.GridContainer,fnc:this.Valid_Customerid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUSTOMERID",fmt:0,gxz:"Z6CustomerId",gxold:"O6CustomerId",gxvar:"A6CustomerId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A6CustomerId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z6CustomerId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("CUSTOMERID",n||gx.fn.currentGridRowImpl(39),gx.O.A6CustomerId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A6CustomerId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("CUSTOMERID",n||gx.fn.currentGridRowImpl(39),",")},nac:gx.falseFn};n[44]={id:44,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:39,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUSTOMERNAME",fmt:0,gxz:"Z15CustomerName",gxold:"O15CustomerName",gxvar:"A15CustomerName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A15CustomerName=n)},v2z:function(n){n!==undefined&&(gx.O.Z15CustomerName=n)},v2c:function(n){gx.fn.setGridControlValue("CUSTOMERNAME",n||gx.fn.currentGridRowImpl(39),gx.O.A15CustomerName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A15CustomerName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("CUSTOMERNAME",n||gx.fn.currentGridRowImpl(39))},nac:gx.falseFn};n[45]={id:45,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:39,gxgrid:this.GridContainer,fnc:this.Valid_Countryid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COUNTRYID",fmt:0,gxz:"Z3CountryId",gxold:"O3CountryId",gxvar:"A3CountryId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A3CountryId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z3CountryId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("COUNTRYID",n||gx.fn.currentGridRowImpl(39),gx.O.A3CountryId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A3CountryId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("COUNTRYID",n||gx.fn.currentGridRowImpl(39),",")},nac:gx.falseFn};n[46]={id:46,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:39,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COUNTRYNAME",fmt:0,gxz:"Z4CountryName",gxold:"O4CountryName",gxvar:"A4CountryName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A4CountryName=n)},v2z:function(n){n!==undefined&&(gx.O.Z4CountryName=n)},v2c:function(n){gx.fn.setGridControlValue("COUNTRYNAME",n||gx.fn.currentGridRowImpl(39),gx.O.A4CountryName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A4CountryName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("COUNTRYNAME",n||gx.fn.currentGridRowImpl(39))},nac:gx.falseFn};n[47]={id:47,lvl:2,type:"svchar",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:39,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUSTOMERADDRESS",fmt:0,gxz:"Z16CustomerAddress",gxold:"O16CustomerAddress",gxvar:"A16CustomerAddress",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A16CustomerAddress=n)},v2z:function(n){n!==undefined&&(gx.O.Z16CustomerAddress=n)},v2c:function(n){gx.fn.setGridControlValue("CUSTOMERADDRESS",n||gx.fn.currentGridRowImpl(39),gx.O.A16CustomerAddress,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A16CustomerAddress=this.val(n))},val:function(n){return gx.fn.getGridControlValue("CUSTOMERADDRESS",n||gx.fn.currentGridRowImpl(39))},nac:gx.falseFn};n[48]={id:48,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:39,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUSTOMERPHONE",fmt:0,gxz:"Z18CustomerPhone",gxold:"O18CustomerPhone",gxvar:"A18CustomerPhone",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"tel",v2v:function(n){n!==undefined&&(gx.O.A18CustomerPhone=n)},v2z:function(n){n!==undefined&&(gx.O.Z18CustomerPhone=n)},v2c:function(n){gx.fn.setGridControlValue("CUSTOMERPHONE",n||gx.fn.currentGridRowImpl(39),gx.O.A18CustomerPhone,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A18CustomerPhone=this.val(n))},val:function(n){return gx.fn.getGridControlValue("CUSTOMERPHONE",n||gx.fn.currentGridRowImpl(39))},nac:gx.falseFn};n[49]={id:49,lvl:2,type:"decimal",len:10,dec:2,sign:!1,pic:"$ ZZZZZZ9.99",ro:1,isacc:0,grid:39,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SHOPPINGCARTFINALPRICE",fmt:0,gxz:"Z29ShoppingCartFinalPrice",gxold:"O29ShoppingCartFinalPrice",gxvar:"A29ShoppingCartFinalPrice",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A29ShoppingCartFinalPrice=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z29ShoppingCartFinalPrice=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("SHOPPINGCARTFINALPRICE",n||gx.fn.currentGridRowImpl(39),gx.O.A29ShoppingCartFinalPrice,2,".")},c2v:function(n){this.val(n)!==undefined&&(gx.O.A29ShoppingCartFinalPrice=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("SHOPPINGCARTFINALPRICE",n||gx.fn.currentGridRowImpl(39),",",".")},nac:gx.falseFn};n[50]={id:50,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:39,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",fmt:0,gxz:"ZV13Update",gxold:"OV13Update",gxvar:"AV13Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV13Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13Update=n)},v2c:function(n){gx.fn.setGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(39),gx.O.AV13Update,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(39))},nac:gx.falseFn};n[51]={id:51,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:39,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",fmt:0,gxz:"ZV14Delete",gxold:"OV14Delete",gxvar:"AV14Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV14Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(39),gx.O.AV14Delete,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV14Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(39))},nac:gx.falseFn};this.AV11ShoppingCartDate=gx.date.nullDate();this.ZV11ShoppingCartDate=gx.date.nullDate();this.OV11ShoppingCartDate=gx.date.nullDate();this.AV12ShoppingCartDateDelivery=gx.date.nullDate();this.ZV12ShoppingCartDateDelivery=gx.date.nullDate();this.OV12ShoppingCartDateDelivery=gx.date.nullDate();this.Z11ShoppingCartId=0;this.O11ShoppingCartId=0;this.Z28ShoppingCartDate=gx.date.nullDate();this.O28ShoppingCartDate=gx.date.nullDate();this.Z32ShoppingCartDateDelivery=gx.date.nullDate();this.O32ShoppingCartDateDelivery=gx.date.nullDate();this.Z6CustomerId=0;this.O6CustomerId=0;this.Z15CustomerName="";this.O15CustomerName="";this.Z3CountryId=0;this.O3CountryId=0;this.Z4CountryName="";this.O4CountryName="";this.Z16CustomerAddress="";this.O16CustomerAddress="";this.Z18CustomerPhone="";this.O18CustomerPhone="";this.Z29ShoppingCartFinalPrice=0;this.O29ShoppingCartFinalPrice=0;this.ZV13Update="";this.OV13Update="";this.ZV14Delete="";this.OV14Delete="";this.AV11ShoppingCartDate=gx.date.nullDate();this.AV12ShoppingCartDateDelivery=gx.date.nullDate();this.A11ShoppingCartId=0;this.A28ShoppingCartDate=gx.date.nullDate();this.A32ShoppingCartDateDelivery=gx.date.nullDate();this.A6CustomerId=0;this.A15CustomerName="";this.A3CountryId=0;this.A4CountryName="";this.A16CustomerAddress="";this.A18CustomerPhone="";this.A29ShoppingCartFinalPrice=0;this.AV13Update="";this.AV14Delete="";this.AV15ADVANCED_LABEL_TEMPLATE="";this.Events={e130d2_client:["'DOINSERT'",!0],e170d2_client:["ENTER",!0],e180d2_client:["CANCEL",!0],e110d1_client:["'TOGGLE'",!1],e120d1_client:["LBLSHOPPINGCARTDATEDELIVERYFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11ShoppingCartDate",fld:"vSHOPPINGCARTDATE",pic:""},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"AV12ShoppingCartDateDelivery",fld:"vSHOPPINGCARTDATEDELIVERY",pic:""},{av:"AV15ADVANCED_LABEL_TEMPLATE",fld:"vADVANCED_LABEL_TEMPLATE",pic:"",hsh:!0}],[{av:'gx.fn.getCtrlProperty("LBLSHOPPINGCARTDATEDELIVERYFILTER","Caption")',ctrl:"LBLSHOPPINGCARTDATEDELIVERYFILTER",prop:"Caption"}]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("FILTERSCONTAINER","Class")',ctrl:"FILTERSCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("FILTERSCONTAINER","Class")',ctrl:"FILTERSCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("GRIDCELL","Class")',ctrl:"GRIDCELL",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Caption"},{ctrl:"BTNTOGGLE",prop:"Tooltiptext"}]];this.EvtParms["LBLSHOPPINGCARTDATEDELIVERYFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("SHOPPINGCARTDATEDELIVERYFILTERCONTAINER","Class")',ctrl:"SHOPPINGCARTDATEDELIVERYFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("SHOPPINGCARTDATEDELIVERYFILTERCONTAINER","Class")',ctrl:"SHOPPINGCARTDATEDELIVERYFILTERCONTAINER",prop:"Class"}]];this.EvtParms["GRID.LOAD"]=[[{av:"A11ShoppingCartId",fld:"SHOPPINGCARTID",pic:"ZZZ9",hsh:!0}],[{av:'gx.fn.getCtrlProperty("vUPDATE","Link")',ctrl:"vUPDATE",prop:"Link"},{av:'gx.fn.getCtrlProperty("vDELETE","Link")',ctrl:"vDELETE",prop:"Link"},{av:'gx.fn.getCtrlProperty("SHOPPINGCARTDATE","Link")',ctrl:"SHOPPINGCARTDATE",prop:"Link"}]];this.EvtParms["'DOINSERT'"]=[[{av:"A11ShoppingCartId",fld:"SHOPPINGCARTID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11ShoppingCartDate",fld:"vSHOPPINGCARTDATE",pic:""},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"AV12ShoppingCartDateDelivery",fld:"vSHOPPINGCARTDATEDELIVERY",pic:""},{av:"AV15ADVANCED_LABEL_TEMPLATE",fld:"vADVANCED_LABEL_TEMPLATE",pic:"",hsh:!0}],[{av:'gx.fn.getCtrlProperty("LBLSHOPPINGCARTDATEDELIVERYFILTER","Caption")',ctrl:"LBLSHOPPINGCARTDATEDELIVERYFILTER",prop:"Caption"}]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11ShoppingCartDate",fld:"vSHOPPINGCARTDATE",pic:""},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"AV12ShoppingCartDateDelivery",fld:"vSHOPPINGCARTDATEDELIVERY",pic:""},{av:"AV15ADVANCED_LABEL_TEMPLATE",fld:"vADVANCED_LABEL_TEMPLATE",pic:"",hsh:!0}],[{av:'gx.fn.getCtrlProperty("LBLSHOPPINGCARTDATEDELIVERYFILTER","Caption")',ctrl:"LBLSHOPPINGCARTDATEDELIVERYFILTER",prop:"Caption"}]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11ShoppingCartDate",fld:"vSHOPPINGCARTDATE",pic:""},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"AV12ShoppingCartDateDelivery",fld:"vSHOPPINGCARTDATEDELIVERY",pic:""},{av:"AV15ADVANCED_LABEL_TEMPLATE",fld:"vADVANCED_LABEL_TEMPLATE",pic:"",hsh:!0}],[{av:'gx.fn.getCtrlProperty("LBLSHOPPINGCARTDATEDELIVERYFILTER","Caption")',ctrl:"LBLSHOPPINGCARTDATEDELIVERYFILTER",prop:"Caption"}]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11ShoppingCartDate",fld:"vSHOPPINGCARTDATE",pic:""},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"AV12ShoppingCartDateDelivery",fld:"vSHOPPINGCARTDATEDELIVERY",pic:""},{av:"AV15ADVANCED_LABEL_TEMPLATE",fld:"vADVANCED_LABEL_TEMPLATE",pic:"",hsh:!0}],[{av:'gx.fn.getCtrlProperty("LBLSHOPPINGCARTDATEDELIVERYFILTER","Caption")',ctrl:"LBLSHOPPINGCARTDATEDELIVERYFILTER",prop:"Caption"}]];this.EvtParms.VALIDV_SHOPPINGCARTDATE=[[],[]];this.EvtParms.VALIDV_SHOPPINGCARTDATEDELIVERY=[[],[]];this.EvtParms.VALID_SHOPPINGCARTID=[[],[]];this.EvtParms.VALID_SHOPPINGCARTDATE=[[],[]];this.EvtParms.VALID_CUSTOMERID=[[],[]];this.EvtParms.VALID_COUNTRYID=[[],[]];this.setVCMap("AV15ADVANCED_LABEL_TEMPLATE","vADVANCED_LABEL_TEMPLATE",0,"char",20,0);this.setVCMap("AV15ADVANCED_LABEL_TEMPLATE","vADVANCED_LABEL_TEMPLATE",0,"char",20,0);this.setVCMap("AV15ADVANCED_LABEL_TEMPLATE","vADVANCED_LABEL_TEMPLATE",0,"char",20,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});t.addRefreshingVar(this.GXValidFnc[18]);t.addRefreshingVar(this.GXValidFnc[31]);t.addRefreshingVar({rfrVar:"AV15ADVANCED_LABEL_TEMPLATE"});t.addRefreshingVar({rfrVar:"AV13Update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingVar({rfrVar:"AV14Delete",rfrProp:"Value",gxAttId:"Delete"});t.addRefreshingParm(this.GXValidFnc[18]);t.addRefreshingParm(this.GXValidFnc[31]);t.addRefreshingParm({rfrVar:"AV15ADVANCED_LABEL_TEMPLATE"});t.addRefreshingParm({rfrVar:"AV13Update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingParm({rfrVar:"AV14Delete",rfrProp:"Value",gxAttId:"Delete"});this.Initialize()});gx.wi(function(){gx.createParentObj(this.wwshoppingcart)})