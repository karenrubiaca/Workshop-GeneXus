using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class product : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetNextPar( );
         gxfirstwebparm_bkp = gxfirstwebparm;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A9ProductCountryId = (short)(NumberUtil.Val( GetPar( "ProductCountryId"), "."));
            AssignAttri("", false, "A9ProductCountryId", StringUtil.LTrimStr( (decimal)(A9ProductCountryId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A9ProductCountryId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A5SellerId = (short)(NumberUtil.Val( GetPar( "SellerId"), "."));
            AssignAttri("", false, "A5SellerId", StringUtil.LTrimStr( (decimal)(A5SellerId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A5SellerId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A3CountryId = (short)(NumberUtil.Val( GetPar( "CountryId"), "."));
            AssignAttri("", false, "A3CountryId", StringUtil.LTrimStr( (decimal)(A3CountryId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A3CountryId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A1CategoryId = (short)(NumberUtil.Val( GetPar( "CategoryId"), "."));
            AssignAttri("", false, "A1CategoryId", StringUtil.LTrimStr( (decimal)(A1CategoryId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A1CategoryId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp;
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_11-163677", 0) ;
            }
            Form.Meta.addItem("description", "Product", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public product( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public product( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdmasterpage", "GeneXus.Programs.rwdmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "WWAdvancedContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "TableTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Product", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "FormContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 ToolbarCellClass", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 4, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0050.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRODUCTID"+"'), id:'"+"PRODUCTID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCellAdvanced", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A7ProductId), 4, 0, ".", "")), StringUtil.LTrim( ((edtProductId_Enabled!=0) ? context.localUtil.Format( (decimal)(A7ProductId), "ZZZ9") : context.localUtil.Format( (decimal)(A7ProductId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductName_Internalname, StringUtil.RTrim( A8ProductName), StringUtil.RTrim( context.localUtil.Format( A8ProductName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductDescription_Internalname, "Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductDescription_Internalname, StringUtil.RTrim( A21ProductDescription), StringUtil.RTrim( context.localUtil.Format( A21ProductDescription, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductDescription_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductDescription_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductPrice_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductPrice_Internalname, "Price", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A22ProductPrice, 12, 2, ".", "")), StringUtil.LTrim( ((edtProductPrice_Enabled!=0) ? context.localUtil.Format( A22ProductPrice, "$ ZZZZZZ9.99") : context.localUtil.Format( A22ProductPrice, "$ ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductPrice_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductPrice_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgProductPhoto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Photo", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A23ProductPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A23ProductPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProductPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A23ProductPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A23ProductPhoto)) ? A40000ProductPhoto_GXI : context.PathToRelativeUrl( A23ProductPhoto));
         GxWebStd.gx_bitmap( context, imgProductPhoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgProductPhoto_Enabled, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", "", "", 0, A23ProductPhoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Product.htm");
         AssignProp("", false, imgProductPhoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProductPhoto)) ? A40000ProductPhoto_GXI : context.PathToRelativeUrl( A23ProductPhoto)), true);
         AssignProp("", false, imgProductPhoto_Internalname, "IsBlob", StringUtil.BoolToStr( A23ProductPhoto_IsBlob), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductCountryId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductCountryId_Internalname, "Country Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductCountryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9ProductCountryId), 4, 0, ".", "")), StringUtil.LTrim( ((edtProductCountryId_Enabled!=0) ? context.localUtil.Format( (decimal)(A9ProductCountryId), "ZZZ9") : context.localUtil.Format( (decimal)(A9ProductCountryId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductCountryId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductCountryId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Product.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_9_Internalname, sImgUrl, imgprompt_9_Link, "", "", context.GetTheme( ), imgprompt_9_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductCountryName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductCountryName_Internalname, "Country Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProductCountryName_Internalname, StringUtil.RTrim( A33ProductCountryName), StringUtil.RTrim( context.localUtil.Format( A33ProductCountryName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductCountryName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductCountryName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSellerId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSellerId_Internalname, "Seller Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSellerId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A5SellerId), 4, 0, ".", "")), StringUtil.LTrim( ((edtSellerId_Enabled!=0) ? context.localUtil.Format( (decimal)(A5SellerId), "ZZZ9") : context.localUtil.Format( (decimal)(A5SellerId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSellerId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSellerId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Product.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSellerName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSellerName_Internalname, "Seller Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtSellerName_Internalname, StringUtil.RTrim( A13SellerName), StringUtil.RTrim( context.localUtil.Format( A13SellerName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSellerName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSellerName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgSellerPhoto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Seller Photo", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         ClassString = "ImageAttribute";
         StyleString = "";
         A14SellerPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A14SellerPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001SellerPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A14SellerPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A14SellerPhoto)) ? A40001SellerPhoto_GXI : context.PathToRelativeUrl( A14SellerPhoto));
         GxWebStd.gx_bitmap( context, imgSellerPhoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgSellerPhoto_Enabled, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 0, A14SellerPhoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Product.htm");
         AssignProp("", false, imgSellerPhoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A14SellerPhoto)) ? A40001SellerPhoto_GXI : context.PathToRelativeUrl( A14SellerPhoto)), true);
         AssignProp("", false, imgSellerPhoto_Internalname, "IsBlob", StringUtil.BoolToStr( A14SellerPhoto_IsBlob), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCategoryId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCategoryId_Internalname, "Category Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCategoryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CategoryId), 4, 0, ".", "")), StringUtil.LTrim( ((edtCategoryId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1CategoryId), "ZZZ9") : context.localUtil.Format( (decimal)(A1CategoryId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCategoryId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCategoryId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Product.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_1_Internalname, sImgUrl, imgprompt_1_Link, "", "", context.GetTheme( ), imgprompt_1_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCategoryName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCategoryName_Internalname, "Category Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCategoryName_Internalname, StringUtil.RTrim( A2CategoryName), StringUtil.RTrim( context.localUtil.Format( A2CategoryName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCategoryName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCategoryName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCountryId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCountryId_Internalname, "Country Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCountryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A3CountryId), 4, 0, ".", "")), StringUtil.LTrim( ((edtCountryId_Enabled!=0) ? context.localUtil.Format( (decimal)(A3CountryId), "ZZZ9") : context.localUtil.Format( (decimal)(A3CountryId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCountryId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCountryId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCountryName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCountryName_Internalname, "Country Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCountryName_Internalname, StringUtil.RTrim( A4CountryName), StringUtil.RTrim( context.localUtil.Format( A4CountryName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCountryName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCountryName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z7ProductId = (short)(context.localUtil.CToN( cgiGet( "Z7ProductId"), ".", ","));
            Z8ProductName = cgiGet( "Z8ProductName");
            Z21ProductDescription = cgiGet( "Z21ProductDescription");
            Z22ProductPrice = context.localUtil.CToN( cgiGet( "Z22ProductPrice"), ".", ",");
            Z5SellerId = (short)(context.localUtil.CToN( cgiGet( "Z5SellerId"), ".", ","));
            Z1CategoryId = (short)(context.localUtil.CToN( cgiGet( "Z1CategoryId"), ".", ","));
            Z9ProductCountryId = (short)(context.localUtil.CToN( cgiGet( "Z9ProductCountryId"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A40000ProductPhoto_GXI = cgiGet( "PRODUCTPHOTO_GXI");
            A40001SellerPhoto_GXI = cgiGet( "SELLERPHOTO_GXI");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODUCTID");
               AnyError = 1;
               GX_FocusControl = edtProductId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A7ProductId = 0;
               AssignAttri("", false, "A7ProductId", StringUtil.LTrimStr( (decimal)(A7ProductId), 4, 0));
            }
            else
            {
               A7ProductId = (short)(context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ","));
               AssignAttri("", false, "A7ProductId", StringUtil.LTrimStr( (decimal)(A7ProductId), 4, 0));
            }
            A8ProductName = cgiGet( edtProductName_Internalname);
            AssignAttri("", false, "A8ProductName", A8ProductName);
            A21ProductDescription = cgiGet( edtProductDescription_Internalname);
            AssignAttri("", false, "A21ProductDescription", A21ProductDescription);
            if ( ( ( context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ".", ",") > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODUCTPRICE");
               AnyError = 1;
               GX_FocusControl = edtProductPrice_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A22ProductPrice = 0;
               AssignAttri("", false, "A22ProductPrice", StringUtil.LTrimStr( A22ProductPrice, 10, 2));
            }
            else
            {
               A22ProductPrice = context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ".", ",");
               AssignAttri("", false, "A22ProductPrice", StringUtil.LTrimStr( A22ProductPrice, 10, 2));
            }
            A23ProductPhoto = cgiGet( imgProductPhoto_Internalname);
            AssignAttri("", false, "A23ProductPhoto", A23ProductPhoto);
            if ( ( ( context.localUtil.CToN( cgiGet( edtProductCountryId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductCountryId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODUCTCOUNTRYID");
               AnyError = 1;
               GX_FocusControl = edtProductCountryId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A9ProductCountryId = 0;
               AssignAttri("", false, "A9ProductCountryId", StringUtil.LTrimStr( (decimal)(A9ProductCountryId), 4, 0));
            }
            else
            {
               A9ProductCountryId = (short)(context.localUtil.CToN( cgiGet( edtProductCountryId_Internalname), ".", ","));
               AssignAttri("", false, "A9ProductCountryId", StringUtil.LTrimStr( (decimal)(A9ProductCountryId), 4, 0));
            }
            A33ProductCountryName = cgiGet( edtProductCountryName_Internalname);
            AssignAttri("", false, "A33ProductCountryName", A33ProductCountryName);
            if ( ( ( context.localUtil.CToN( cgiGet( edtSellerId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSellerId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SELLERID");
               AnyError = 1;
               GX_FocusControl = edtSellerId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A5SellerId = 0;
               AssignAttri("", false, "A5SellerId", StringUtil.LTrimStr( (decimal)(A5SellerId), 4, 0));
            }
            else
            {
               A5SellerId = (short)(context.localUtil.CToN( cgiGet( edtSellerId_Internalname), ".", ","));
               AssignAttri("", false, "A5SellerId", StringUtil.LTrimStr( (decimal)(A5SellerId), 4, 0));
            }
            A13SellerName = cgiGet( edtSellerName_Internalname);
            AssignAttri("", false, "A13SellerName", A13SellerName);
            A14SellerPhoto = cgiGet( imgSellerPhoto_Internalname);
            AssignAttri("", false, "A14SellerPhoto", A14SellerPhoto);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCategoryId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCategoryId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CATEGORYID");
               AnyError = 1;
               GX_FocusControl = edtCategoryId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1CategoryId = 0;
               AssignAttri("", false, "A1CategoryId", StringUtil.LTrimStr( (decimal)(A1CategoryId), 4, 0));
            }
            else
            {
               A1CategoryId = (short)(context.localUtil.CToN( cgiGet( edtCategoryId_Internalname), ".", ","));
               AssignAttri("", false, "A1CategoryId", StringUtil.LTrimStr( (decimal)(A1CategoryId), 4, 0));
            }
            A2CategoryName = cgiGet( edtCategoryName_Internalname);
            AssignAttri("", false, "A2CategoryName", A2CategoryName);
            A3CountryId = (short)(context.localUtil.CToN( cgiGet( edtCountryId_Internalname), ".", ","));
            AssignAttri("", false, "A3CountryId", StringUtil.LTrimStr( (decimal)(A3CountryId), 4, 0));
            A4CountryName = cgiGet( edtCountryName_Internalname);
            AssignAttri("", false, "A4CountryName", A4CountryName);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            getMultimediaValue(imgProductPhoto_Internalname, ref  A23ProductPhoto, ref  A40000ProductPhoto_GXI);
            getMultimediaValue(imgSellerPhoto_Internalname, ref  A14SellerPhoto, ref  A40001SellerPhoto_GXI);
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A7ProductId = (short)(NumberUtil.Val( GetPar( "ProductId"), "."));
               AssignAttri("", false, "A7ProductId", StringUtil.LTrimStr( (decimal)(A7ProductId), 4, 0));
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
                        }
                     }
                     else
                     {
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll045( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes045( ) ;
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void ResetCaption040( )
      {
      }

      protected void ZM045( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z8ProductName = T00043_A8ProductName[0];
               Z21ProductDescription = T00043_A21ProductDescription[0];
               Z22ProductPrice = T00043_A22ProductPrice[0];
               Z5SellerId = T00043_A5SellerId[0];
               Z1CategoryId = T00043_A1CategoryId[0];
               Z9ProductCountryId = T00043_A9ProductCountryId[0];
            }
            else
            {
               Z8ProductName = A8ProductName;
               Z21ProductDescription = A21ProductDescription;
               Z22ProductPrice = A22ProductPrice;
               Z5SellerId = A5SellerId;
               Z1CategoryId = A1CategoryId;
               Z9ProductCountryId = A9ProductCountryId;
            }
         }
         if ( GX_JID == -3 )
         {
            Z7ProductId = A7ProductId;
            Z8ProductName = A8ProductName;
            Z21ProductDescription = A21ProductDescription;
            Z22ProductPrice = A22ProductPrice;
            Z23ProductPhoto = A23ProductPhoto;
            Z40000ProductPhoto_GXI = A40000ProductPhoto_GXI;
            Z5SellerId = A5SellerId;
            Z1CategoryId = A1CategoryId;
            Z9ProductCountryId = A9ProductCountryId;
            Z33ProductCountryName = A33ProductCountryName;
            Z13SellerName = A13SellerName;
            Z14SellerPhoto = A14SellerPhoto;
            Z40001SellerPhoto_GXI = A40001SellerPhoto_GXI;
            Z3CountryId = A3CountryId;
            Z4CountryName = A4CountryName;
            Z2CategoryName = A2CategoryName;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_9_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRODUCTCOUNTRYID"+"'), id:'"+"PRODUCTCOUNTRYID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_5_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"SELLERID"+"'), id:'"+"SELLERID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_1_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CATEGORYID"+"'), id:'"+"CATEGORYID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load045( )
      {
         /* Using cursor T00048 */
         pr_default.execute(6, new Object[] {A7ProductId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound5 = 1;
            A8ProductName = T00048_A8ProductName[0];
            AssignAttri("", false, "A8ProductName", A8ProductName);
            A21ProductDescription = T00048_A21ProductDescription[0];
            AssignAttri("", false, "A21ProductDescription", A21ProductDescription);
            A22ProductPrice = T00048_A22ProductPrice[0];
            AssignAttri("", false, "A22ProductPrice", StringUtil.LTrimStr( A22ProductPrice, 10, 2));
            A40000ProductPhoto_GXI = T00048_A40000ProductPhoto_GXI[0];
            AssignProp("", false, imgProductPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProductPhoto)) ? A40000ProductPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A23ProductPhoto))), true);
            AssignProp("", false, imgProductPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A23ProductPhoto), true);
            A33ProductCountryName = T00048_A33ProductCountryName[0];
            AssignAttri("", false, "A33ProductCountryName", A33ProductCountryName);
            A13SellerName = T00048_A13SellerName[0];
            AssignAttri("", false, "A13SellerName", A13SellerName);
            A40001SellerPhoto_GXI = T00048_A40001SellerPhoto_GXI[0];
            AssignProp("", false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14SellerPhoto)) ? A40001SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A14SellerPhoto))), true);
            AssignProp("", false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A14SellerPhoto), true);
            A2CategoryName = T00048_A2CategoryName[0];
            AssignAttri("", false, "A2CategoryName", A2CategoryName);
            A4CountryName = T00048_A4CountryName[0];
            AssignAttri("", false, "A4CountryName", A4CountryName);
            A5SellerId = T00048_A5SellerId[0];
            AssignAttri("", false, "A5SellerId", StringUtil.LTrimStr( (decimal)(A5SellerId), 4, 0));
            A1CategoryId = T00048_A1CategoryId[0];
            AssignAttri("", false, "A1CategoryId", StringUtil.LTrimStr( (decimal)(A1CategoryId), 4, 0));
            A9ProductCountryId = T00048_A9ProductCountryId[0];
            AssignAttri("", false, "A9ProductCountryId", StringUtil.LTrimStr( (decimal)(A9ProductCountryId), 4, 0));
            A3CountryId = T00048_A3CountryId[0];
            AssignAttri("", false, "A3CountryId", StringUtil.LTrimStr( (decimal)(A3CountryId), 4, 0));
            A23ProductPhoto = T00048_A23ProductPhoto[0];
            AssignAttri("", false, "A23ProductPhoto", A23ProductPhoto);
            AssignProp("", false, imgProductPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProductPhoto)) ? A40000ProductPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A23ProductPhoto))), true);
            AssignProp("", false, imgProductPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A23ProductPhoto), true);
            A14SellerPhoto = T00048_A14SellerPhoto[0];
            AssignAttri("", false, "A14SellerPhoto", A14SellerPhoto);
            AssignProp("", false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14SellerPhoto)) ? A40001SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A14SellerPhoto))), true);
            AssignProp("", false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A14SellerPhoto), true);
            ZM045( -3) ;
         }
         pr_default.close(6);
         OnLoadActions045( ) ;
      }

      protected void OnLoadActions045( )
      {
      }

      protected void CheckExtendedTable045( )
      {
         nIsDirty_5 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00049 */
         pr_default.execute(7, new Object[] {A8ProductName, A7ProductId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Product Name"}), 1, "PRODUCTNAME");
            AnyError = 1;
            GX_FocusControl = edtProductName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(7);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A8ProductName)) )
         {
            GX_msglist.addItem("The name cannot be empty", 1, "PRODUCTNAME");
            AnyError = 1;
            GX_FocusControl = edtProductName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (Convert.ToDecimal(0)==A22ProductPrice) )
         {
            GX_msglist.addItem("The price cannot be empty", 1, "PRODUCTPRICE");
            AnyError = 1;
            GX_FocusControl = edtProductPrice_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00046 */
         pr_default.execute(4, new Object[] {A9ProductCountryId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Product Country'.", "ForeignKeyNotFound", 1, "PRODUCTCOUNTRYID");
            AnyError = 1;
            GX_FocusControl = edtProductCountryId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A33ProductCountryName = T00046_A33ProductCountryName[0];
         AssignAttri("", false, "A33ProductCountryName", A33ProductCountryName);
         pr_default.close(4);
         /* Using cursor T00044 */
         pr_default.execute(2, new Object[] {A5SellerId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Seller'.", "ForeignKeyNotFound", 1, "SELLERID");
            AnyError = 1;
            GX_FocusControl = edtSellerId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A13SellerName = T00044_A13SellerName[0];
         AssignAttri("", false, "A13SellerName", A13SellerName);
         A40001SellerPhoto_GXI = T00044_A40001SellerPhoto_GXI[0];
         AssignProp("", false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14SellerPhoto)) ? A40001SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A14SellerPhoto))), true);
         AssignProp("", false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A14SellerPhoto), true);
         A3CountryId = T00044_A3CountryId[0];
         AssignAttri("", false, "A3CountryId", StringUtil.LTrimStr( (decimal)(A3CountryId), 4, 0));
         A14SellerPhoto = T00044_A14SellerPhoto[0];
         AssignAttri("", false, "A14SellerPhoto", A14SellerPhoto);
         AssignProp("", false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14SellerPhoto)) ? A40001SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A14SellerPhoto))), true);
         AssignProp("", false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A14SellerPhoto), true);
         pr_default.close(2);
         /* Using cursor T00047 */
         pr_default.execute(5, new Object[] {A3CountryId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No matching 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
         }
         A4CountryName = T00047_A4CountryName[0];
         AssignAttri("", false, "A4CountryName", A4CountryName);
         pr_default.close(5);
         /* Using cursor T00045 */
         pr_default.execute(3, new Object[] {A1CategoryId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No matching 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
            AnyError = 1;
            GX_FocusControl = edtCategoryId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2CategoryName = T00045_A2CategoryName[0];
         AssignAttri("", false, "A2CategoryName", A2CategoryName);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors045( )
      {
         pr_default.close(4);
         pr_default.close(2);
         pr_default.close(5);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_7( short A9ProductCountryId )
      {
         /* Using cursor T000410 */
         pr_default.execute(8, new Object[] {A9ProductCountryId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No matching 'Product Country'.", "ForeignKeyNotFound", 1, "PRODUCTCOUNTRYID");
            AnyError = 1;
            GX_FocusControl = edtProductCountryId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A33ProductCountryName = T000410_A33ProductCountryName[0];
         AssignAttri("", false, "A33ProductCountryName", A33ProductCountryName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A33ProductCountryName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_5( short A5SellerId )
      {
         /* Using cursor T000411 */
         pr_default.execute(9, new Object[] {A5SellerId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No matching 'Seller'.", "ForeignKeyNotFound", 1, "SELLERID");
            AnyError = 1;
            GX_FocusControl = edtSellerId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A13SellerName = T000411_A13SellerName[0];
         AssignAttri("", false, "A13SellerName", A13SellerName);
         A40001SellerPhoto_GXI = T000411_A40001SellerPhoto_GXI[0];
         AssignProp("", false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14SellerPhoto)) ? A40001SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A14SellerPhoto))), true);
         AssignProp("", false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A14SellerPhoto), true);
         A3CountryId = T000411_A3CountryId[0];
         AssignAttri("", false, "A3CountryId", StringUtil.LTrimStr( (decimal)(A3CountryId), 4, 0));
         A14SellerPhoto = T000411_A14SellerPhoto[0];
         AssignAttri("", false, "A14SellerPhoto", A14SellerPhoto);
         AssignProp("", false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14SellerPhoto)) ? A40001SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A14SellerPhoto))), true);
         AssignProp("", false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A14SellerPhoto), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A13SellerName))+"\""+","+"\""+GXUtil.EncodeJSConstant( A14SellerPhoto)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40001SellerPhoto_GXI)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A3CountryId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_8( short A3CountryId )
      {
         /* Using cursor T000412 */
         pr_default.execute(10, new Object[] {A3CountryId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No matching 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
         }
         A4CountryName = T000412_A4CountryName[0];
         AssignAttri("", false, "A4CountryName", A4CountryName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A4CountryName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_6( short A1CategoryId )
      {
         /* Using cursor T000413 */
         pr_default.execute(11, new Object[] {A1CategoryId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No matching 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
            AnyError = 1;
            GX_FocusControl = edtCategoryId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2CategoryName = T000413_A2CategoryName[0];
         AssignAttri("", false, "A2CategoryName", A2CategoryName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A2CategoryName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void GetKey045( )
      {
         /* Using cursor T000414 */
         pr_default.execute(12, new Object[] {A7ProductId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(12);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00043 */
         pr_default.execute(1, new Object[] {A7ProductId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM045( 3) ;
            RcdFound5 = 1;
            A7ProductId = T00043_A7ProductId[0];
            AssignAttri("", false, "A7ProductId", StringUtil.LTrimStr( (decimal)(A7ProductId), 4, 0));
            A8ProductName = T00043_A8ProductName[0];
            AssignAttri("", false, "A8ProductName", A8ProductName);
            A21ProductDescription = T00043_A21ProductDescription[0];
            AssignAttri("", false, "A21ProductDescription", A21ProductDescription);
            A22ProductPrice = T00043_A22ProductPrice[0];
            AssignAttri("", false, "A22ProductPrice", StringUtil.LTrimStr( A22ProductPrice, 10, 2));
            A40000ProductPhoto_GXI = T00043_A40000ProductPhoto_GXI[0];
            AssignProp("", false, imgProductPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProductPhoto)) ? A40000ProductPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A23ProductPhoto))), true);
            AssignProp("", false, imgProductPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A23ProductPhoto), true);
            A5SellerId = T00043_A5SellerId[0];
            AssignAttri("", false, "A5SellerId", StringUtil.LTrimStr( (decimal)(A5SellerId), 4, 0));
            A1CategoryId = T00043_A1CategoryId[0];
            AssignAttri("", false, "A1CategoryId", StringUtil.LTrimStr( (decimal)(A1CategoryId), 4, 0));
            A9ProductCountryId = T00043_A9ProductCountryId[0];
            AssignAttri("", false, "A9ProductCountryId", StringUtil.LTrimStr( (decimal)(A9ProductCountryId), 4, 0));
            A23ProductPhoto = T00043_A23ProductPhoto[0];
            AssignAttri("", false, "A23ProductPhoto", A23ProductPhoto);
            AssignProp("", false, imgProductPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProductPhoto)) ? A40000ProductPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A23ProductPhoto))), true);
            AssignProp("", false, imgProductPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A23ProductPhoto), true);
            Z7ProductId = A7ProductId;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load045( ) ;
            if ( AnyError == 1 )
            {
               RcdFound5 = 0;
               InitializeNonKey045( ) ;
            }
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey045( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey045( ) ;
         if ( RcdFound5 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound5 = 0;
         /* Using cursor T000415 */
         pr_default.execute(13, new Object[] {A7ProductId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( T000415_A7ProductId[0] < A7ProductId ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( T000415_A7ProductId[0] > A7ProductId ) ) )
            {
               A7ProductId = T000415_A7ProductId[0];
               AssignAttri("", false, "A7ProductId", StringUtil.LTrimStr( (decimal)(A7ProductId), 4, 0));
               RcdFound5 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void move_previous( )
      {
         RcdFound5 = 0;
         /* Using cursor T000416 */
         pr_default.execute(14, new Object[] {A7ProductId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( T000416_A7ProductId[0] > A7ProductId ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( T000416_A7ProductId[0] < A7ProductId ) ) )
            {
               A7ProductId = T000416_A7ProductId[0];
               AssignAttri("", false, "A7ProductId", StringUtil.LTrimStr( (decimal)(A7ProductId), 4, 0));
               RcdFound5 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey045( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert045( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound5 == 1 )
            {
               if ( A7ProductId != Z7ProductId )
               {
                  A7ProductId = Z7ProductId;
                  AssignAttri("", false, "A7ProductId", StringUtil.LTrimStr( (decimal)(A7ProductId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PRODUCTID");
                  AnyError = 1;
                  GX_FocusControl = edtProductId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProductId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update045( ) ;
                  GX_FocusControl = edtProductId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A7ProductId != Z7ProductId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtProductId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert045( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PRODUCTID");
                     AnyError = 1;
                     GX_FocusControl = edtProductId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtProductId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert045( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( A7ProductId != Z7ProductId )
         {
            A7ProductId = Z7ProductId;
            AssignAttri("", false, "A7ProductId", StringUtil.LTrimStr( (decimal)(A7ProductId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PRODUCTID");
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseOpenCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PRODUCTID");
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtProductName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart045( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProductName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd045( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProductName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProductName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart045( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound5 != 0 )
            {
               ScanNext045( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProductName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd045( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency045( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00042 */
            pr_default.execute(0, new Object[] {A7ProductId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Product"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z8ProductName, T00042_A8ProductName[0]) != 0 ) || ( StringUtil.StrCmp(Z21ProductDescription, T00042_A21ProductDescription[0]) != 0 ) || ( Z22ProductPrice != T00042_A22ProductPrice[0] ) || ( Z5SellerId != T00042_A5SellerId[0] ) || ( Z1CategoryId != T00042_A1CategoryId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z9ProductCountryId != T00042_A9ProductCountryId[0] ) )
            {
               if ( StringUtil.StrCmp(Z8ProductName, T00042_A8ProductName[0]) != 0 )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductName");
                  GXUtil.WriteLogRaw("Old: ",Z8ProductName);
                  GXUtil.WriteLogRaw("Current: ",T00042_A8ProductName[0]);
               }
               if ( StringUtil.StrCmp(Z21ProductDescription, T00042_A21ProductDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductDescription");
                  GXUtil.WriteLogRaw("Old: ",Z21ProductDescription);
                  GXUtil.WriteLogRaw("Current: ",T00042_A21ProductDescription[0]);
               }
               if ( Z22ProductPrice != T00042_A22ProductPrice[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductPrice");
                  GXUtil.WriteLogRaw("Old: ",Z22ProductPrice);
                  GXUtil.WriteLogRaw("Current: ",T00042_A22ProductPrice[0]);
               }
               if ( Z5SellerId != T00042_A5SellerId[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"SellerId");
                  GXUtil.WriteLogRaw("Old: ",Z5SellerId);
                  GXUtil.WriteLogRaw("Current: ",T00042_A5SellerId[0]);
               }
               if ( Z1CategoryId != T00042_A1CategoryId[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"CategoryId");
                  GXUtil.WriteLogRaw("Old: ",Z1CategoryId);
                  GXUtil.WriteLogRaw("Current: ",T00042_A1CategoryId[0]);
               }
               if ( Z9ProductCountryId != T00042_A9ProductCountryId[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductCountryId");
                  GXUtil.WriteLogRaw("Old: ",Z9ProductCountryId);
                  GXUtil.WriteLogRaw("Current: ",T00042_A9ProductCountryId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Product"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert045( )
      {
         BeforeValidate045( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable045( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM045( 0) ;
            CheckOptimisticConcurrency045( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm045( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert045( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000417 */
                     pr_default.execute(15, new Object[] {A8ProductName, A21ProductDescription, A22ProductPrice, A23ProductPhoto, A40000ProductPhoto_GXI, A5SellerId, A1CategoryId, A9ProductCountryId});
                     A7ProductId = T000417_A7ProductId[0];
                     AssignAttri("", false, "A7ProductId", StringUtil.LTrimStr( (decimal)(A7ProductId), 4, 0));
                     pr_default.close(15);
                     dsDefault.SmartCacheProvider.SetUpdated("Product");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption040( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load045( ) ;
            }
            EndLevel045( ) ;
         }
         CloseExtendedTableCursors045( ) ;
      }

      protected void Update045( )
      {
         BeforeValidate045( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable045( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency045( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm045( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate045( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000418 */
                     pr_default.execute(16, new Object[] {A8ProductName, A21ProductDescription, A22ProductPrice, A5SellerId, A1CategoryId, A9ProductCountryId, A7ProductId});
                     pr_default.close(16);
                     dsDefault.SmartCacheProvider.SetUpdated("Product");
                     if ( (pr_default.getStatus(16) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Product"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate045( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption040( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel045( ) ;
         }
         CloseExtendedTableCursors045( ) ;
      }

      protected void DeferredUpdate045( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000419 */
            pr_default.execute(17, new Object[] {A23ProductPhoto, A40000ProductPhoto_GXI, A7ProductId});
            pr_default.close(17);
            dsDefault.SmartCacheProvider.SetUpdated("Product");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate045( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency045( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls045( ) ;
            AfterConfirm045( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete045( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000420 */
                  pr_default.execute(18, new Object[] {A7ProductId});
                  pr_default.close(18);
                  dsDefault.SmartCacheProvider.SetUpdated("Product");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound5 == 0 )
                        {
                           InitAll045( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption040( ) ;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel045( ) ;
         Gx_mode = sMode5;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls045( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000421 */
            pr_default.execute(19, new Object[] {A9ProductCountryId});
            A33ProductCountryName = T000421_A33ProductCountryName[0];
            AssignAttri("", false, "A33ProductCountryName", A33ProductCountryName);
            pr_default.close(19);
            /* Using cursor T000422 */
            pr_default.execute(20, new Object[] {A5SellerId});
            A13SellerName = T000422_A13SellerName[0];
            AssignAttri("", false, "A13SellerName", A13SellerName);
            A40001SellerPhoto_GXI = T000422_A40001SellerPhoto_GXI[0];
            AssignProp("", false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14SellerPhoto)) ? A40001SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A14SellerPhoto))), true);
            AssignProp("", false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A14SellerPhoto), true);
            A3CountryId = T000422_A3CountryId[0];
            AssignAttri("", false, "A3CountryId", StringUtil.LTrimStr( (decimal)(A3CountryId), 4, 0));
            A14SellerPhoto = T000422_A14SellerPhoto[0];
            AssignAttri("", false, "A14SellerPhoto", A14SellerPhoto);
            AssignProp("", false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14SellerPhoto)) ? A40001SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A14SellerPhoto))), true);
            AssignProp("", false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A14SellerPhoto), true);
            pr_default.close(20);
            /* Using cursor T000423 */
            pr_default.execute(21, new Object[] {A3CountryId});
            A4CountryName = T000423_A4CountryName[0];
            AssignAttri("", false, "A4CountryName", A4CountryName);
            pr_default.close(21);
            /* Using cursor T000424 */
            pr_default.execute(22, new Object[] {A1CategoryId});
            A2CategoryName = T000424_A2CategoryName[0];
            AssignAttri("", false, "A2CategoryName", A2CategoryName);
            pr_default.close(22);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000425 */
            pr_default.execute(23, new Object[] {A7ProductId});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Product"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor T000426 */
            pr_default.execute(24, new Object[] {A7ProductId});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Product"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
         }
      }

      protected void EndLevel045( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete045( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(20);
            pr_default.close(22);
            pr_default.close(19);
            pr_default.close(21);
            context.CommitDataStores("product",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues040( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(20);
            pr_default.close(22);
            pr_default.close(19);
            pr_default.close(21);
            context.RollbackDataStores("product",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart045( )
      {
         /* Using cursor T000427 */
         pr_default.execute(25);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound5 = 1;
            A7ProductId = T000427_A7ProductId[0];
            AssignAttri("", false, "A7ProductId", StringUtil.LTrimStr( (decimal)(A7ProductId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext045( )
      {
         /* Scan next routine */
         pr_default.readNext(25);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound5 = 1;
            A7ProductId = T000427_A7ProductId[0];
            AssignAttri("", false, "A7ProductId", StringUtil.LTrimStr( (decimal)(A7ProductId), 4, 0));
         }
      }

      protected void ScanEnd045( )
      {
         pr_default.close(25);
      }

      protected void AfterConfirm045( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert045( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate045( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete045( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete045( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate045( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes045( )
      {
         edtProductId_Enabled = 0;
         AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), true);
         edtProductName_Enabled = 0;
         AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), true);
         edtProductDescription_Enabled = 0;
         AssignProp("", false, edtProductDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductDescription_Enabled), 5, 0), true);
         edtProductPrice_Enabled = 0;
         AssignProp("", false, edtProductPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductPrice_Enabled), 5, 0), true);
         imgProductPhoto_Enabled = 0;
         AssignProp("", false, imgProductPhoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProductPhoto_Enabled), 5, 0), true);
         edtProductCountryId_Enabled = 0;
         AssignProp("", false, edtProductCountryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductCountryId_Enabled), 5, 0), true);
         edtProductCountryName_Enabled = 0;
         AssignProp("", false, edtProductCountryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductCountryName_Enabled), 5, 0), true);
         edtSellerId_Enabled = 0;
         AssignProp("", false, edtSellerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSellerId_Enabled), 5, 0), true);
         edtSellerName_Enabled = 0;
         AssignProp("", false, edtSellerName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSellerName_Enabled), 5, 0), true);
         imgSellerPhoto_Enabled = 0;
         AssignProp("", false, imgSellerPhoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgSellerPhoto_Enabled), 5, 0), true);
         edtCategoryId_Enabled = 0;
         AssignProp("", false, edtCategoryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryId_Enabled), 5, 0), true);
         edtCategoryName_Enabled = 0;
         AssignProp("", false, edtCategoryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryName_Enabled), 5, 0), true);
         edtCountryId_Enabled = 0;
         AssignProp("", false, edtCountryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryId_Enabled), 5, 0), true);
         edtCountryName_Enabled = 0;
         AssignProp("", false, edtCountryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryName_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes045( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues040( )
      {
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 64220), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 64220), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 64220), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("product.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z7ProductId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7ProductId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z8ProductName", StringUtil.RTrim( Z8ProductName));
         GxWebStd.gx_hidden_field( context, "Z21ProductDescription", StringUtil.RTrim( Z21ProductDescription));
         GxWebStd.gx_hidden_field( context, "Z22ProductPrice", StringUtil.LTrim( StringUtil.NToC( Z22ProductPrice, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z5SellerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z5SellerId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1CategoryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1CategoryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z9ProductCountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9ProductCountryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "PRODUCTPHOTO_GXI", A40000ProductPhoto_GXI);
         GxWebStd.gx_hidden_field( context, "SELLERPHOTO_GXI", A40001SellerPhoto_GXI);
         GXCCtlgxBlob = "PRODUCTPHOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A23ProductPhoto);
         GXCCtlgxBlob = "SELLERPHOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A14SellerPhoto);
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("product.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Product" ;
      }

      public override string GetPgmdesc( )
      {
         return "Product" ;
      }

      protected void InitializeNonKey045( )
      {
         A8ProductName = "";
         AssignAttri("", false, "A8ProductName", A8ProductName);
         A21ProductDescription = "";
         AssignAttri("", false, "A21ProductDescription", A21ProductDescription);
         A22ProductPrice = 0;
         AssignAttri("", false, "A22ProductPrice", StringUtil.LTrimStr( A22ProductPrice, 10, 2));
         A23ProductPhoto = "";
         AssignAttri("", false, "A23ProductPhoto", A23ProductPhoto);
         AssignProp("", false, imgProductPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProductPhoto)) ? A40000ProductPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A23ProductPhoto))), true);
         AssignProp("", false, imgProductPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A23ProductPhoto), true);
         A40000ProductPhoto_GXI = "";
         AssignProp("", false, imgProductPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProductPhoto)) ? A40000ProductPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A23ProductPhoto))), true);
         AssignProp("", false, imgProductPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A23ProductPhoto), true);
         A9ProductCountryId = 0;
         AssignAttri("", false, "A9ProductCountryId", StringUtil.LTrimStr( (decimal)(A9ProductCountryId), 4, 0));
         A33ProductCountryName = "";
         AssignAttri("", false, "A33ProductCountryName", A33ProductCountryName);
         A5SellerId = 0;
         AssignAttri("", false, "A5SellerId", StringUtil.LTrimStr( (decimal)(A5SellerId), 4, 0));
         A13SellerName = "";
         AssignAttri("", false, "A13SellerName", A13SellerName);
         A14SellerPhoto = "";
         AssignAttri("", false, "A14SellerPhoto", A14SellerPhoto);
         AssignProp("", false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14SellerPhoto)) ? A40001SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A14SellerPhoto))), true);
         AssignProp("", false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A14SellerPhoto), true);
         A40001SellerPhoto_GXI = "";
         AssignProp("", false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14SellerPhoto)) ? A40001SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A14SellerPhoto))), true);
         AssignProp("", false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A14SellerPhoto), true);
         A1CategoryId = 0;
         AssignAttri("", false, "A1CategoryId", StringUtil.LTrimStr( (decimal)(A1CategoryId), 4, 0));
         A2CategoryName = "";
         AssignAttri("", false, "A2CategoryName", A2CategoryName);
         A3CountryId = 0;
         AssignAttri("", false, "A3CountryId", StringUtil.LTrimStr( (decimal)(A3CountryId), 4, 0));
         A4CountryName = "";
         AssignAttri("", false, "A4CountryName", A4CountryName);
         Z8ProductName = "";
         Z21ProductDescription = "";
         Z22ProductPrice = 0;
         Z5SellerId = 0;
         Z1CategoryId = 0;
         Z9ProductCountryId = 0;
      }

      protected void InitAll045( )
      {
         A7ProductId = 0;
         AssignAttri("", false, "A7ProductId", StringUtil.LTrimStr( (decimal)(A7ProductId), 4, 0));
         InitializeNonKey045( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20221113048125", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("product.js", "?20221113048125", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtProductId_Internalname = "PRODUCTID";
         edtProductName_Internalname = "PRODUCTNAME";
         edtProductDescription_Internalname = "PRODUCTDESCRIPTION";
         edtProductPrice_Internalname = "PRODUCTPRICE";
         imgProductPhoto_Internalname = "PRODUCTPHOTO";
         edtProductCountryId_Internalname = "PRODUCTCOUNTRYID";
         edtProductCountryName_Internalname = "PRODUCTCOUNTRYNAME";
         edtSellerId_Internalname = "SELLERID";
         edtSellerName_Internalname = "SELLERNAME";
         imgSellerPhoto_Internalname = "SELLERPHOTO";
         edtCategoryId_Internalname = "CATEGORYID";
         edtCategoryName_Internalname = "CATEGORYNAME";
         edtCountryId_Internalname = "COUNTRYID";
         edtCountryName_Internalname = "COUNTRYNAME";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_9_Internalname = "PROMPT_9";
         imgprompt_5_Internalname = "PROMPT_5";
         imgprompt_1_Internalname = "PROMPT_1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Product";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCountryName_Jsonclick = "";
         edtCountryName_Enabled = 0;
         edtCountryId_Jsonclick = "";
         edtCountryId_Enabled = 0;
         edtCategoryName_Jsonclick = "";
         edtCategoryName_Enabled = 0;
         imgprompt_1_Visible = 1;
         imgprompt_1_Link = "";
         edtCategoryId_Jsonclick = "";
         edtCategoryId_Enabled = 1;
         imgSellerPhoto_Enabled = 0;
         edtSellerName_Jsonclick = "";
         edtSellerName_Enabled = 0;
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         edtSellerId_Jsonclick = "";
         edtSellerId_Enabled = 1;
         edtProductCountryName_Jsonclick = "";
         edtProductCountryName_Enabled = 0;
         imgprompt_9_Visible = 1;
         imgprompt_9_Link = "";
         edtProductCountryId_Jsonclick = "";
         edtProductCountryId_Enabled = 1;
         imgProductPhoto_Enabled = 1;
         edtProductPrice_Jsonclick = "";
         edtProductPrice_Enabled = 1;
         edtProductDescription_Jsonclick = "";
         edtProductDescription_Enabled = 1;
         edtProductName_Jsonclick = "";
         edtProductName_Enabled = 1;
         edtProductId_Jsonclick = "";
         edtProductId_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtProductName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Productid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A8ProductName", StringUtil.RTrim( A8ProductName));
         AssignAttri("", false, "A21ProductDescription", StringUtil.RTrim( A21ProductDescription));
         AssignAttri("", false, "A22ProductPrice", StringUtil.LTrim( StringUtil.NToC( A22ProductPrice, 10, 2, ".", "")));
         AssignAttri("", false, "A23ProductPhoto", context.PathToRelativeUrl( A23ProductPhoto));
         GXCCtlgxBlob = "PRODUCTPHOTO" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A23ProductPhoto));
         AssignAttri("", false, "A40000ProductPhoto_GXI", A40000ProductPhoto_GXI);
         AssignAttri("", false, "A9ProductCountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9ProductCountryId), 4, 0, ".", "")));
         AssignAttri("", false, "A5SellerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A5SellerId), 4, 0, ".", "")));
         AssignAttri("", false, "A1CategoryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CategoryId), 4, 0, ".", "")));
         AssignAttri("", false, "A33ProductCountryName", StringUtil.RTrim( A33ProductCountryName));
         AssignAttri("", false, "A13SellerName", StringUtil.RTrim( A13SellerName));
         AssignAttri("", false, "A14SellerPhoto", context.PathToRelativeUrl( A14SellerPhoto));
         GXCCtlgxBlob = "SELLERPHOTO" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A14SellerPhoto));
         AssignAttri("", false, "A40001SellerPhoto_GXI", A40001SellerPhoto_GXI);
         AssignAttri("", false, "A3CountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A3CountryId), 4, 0, ".", "")));
         AssignAttri("", false, "A4CountryName", StringUtil.RTrim( A4CountryName));
         AssignAttri("", false, "A2CategoryName", StringUtil.RTrim( A2CategoryName));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z7ProductId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7ProductId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z8ProductName", StringUtil.RTrim( Z8ProductName));
         GxWebStd.gx_hidden_field( context, "Z21ProductDescription", StringUtil.RTrim( Z21ProductDescription));
         GxWebStd.gx_hidden_field( context, "Z22ProductPrice", StringUtil.LTrim( StringUtil.NToC( Z22ProductPrice, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z23ProductPhoto", context.PathToRelativeUrl( Z23ProductPhoto));
         GxWebStd.gx_hidden_field( context, "Z40000ProductPhoto_GXI", Z40000ProductPhoto_GXI);
         GxWebStd.gx_hidden_field( context, "Z9ProductCountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9ProductCountryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z5SellerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z5SellerId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1CategoryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1CategoryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z33ProductCountryName", StringUtil.RTrim( Z33ProductCountryName));
         GxWebStd.gx_hidden_field( context, "Z13SellerName", StringUtil.RTrim( Z13SellerName));
         GxWebStd.gx_hidden_field( context, "Z14SellerPhoto", context.PathToRelativeUrl( Z14SellerPhoto));
         GxWebStd.gx_hidden_field( context, "Z40001SellerPhoto_GXI", Z40001SellerPhoto_GXI);
         GxWebStd.gx_hidden_field( context, "Z3CountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z3CountryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z4CountryName", StringUtil.RTrim( Z4CountryName));
         GxWebStd.gx_hidden_field( context, "Z2CategoryName", StringUtil.RTrim( Z2CategoryName));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Productname( )
      {
         /* Using cursor T000428 */
         pr_default.execute(26, new Object[] {A8ProductName, A7ProductId});
         if ( (pr_default.getStatus(26) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Product Name"}), 1, "PRODUCTNAME");
            AnyError = 1;
            GX_FocusControl = edtProductName_Internalname;
         }
         pr_default.close(26);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A8ProductName)) )
         {
            GX_msglist.addItem("The name cannot be empty", 1, "PRODUCTNAME");
            AnyError = 1;
            GX_FocusControl = edtProductName_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Productcountryid( )
      {
         /* Using cursor T000421 */
         pr_default.execute(19, new Object[] {A9ProductCountryId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No matching 'Product Country'.", "ForeignKeyNotFound", 1, "PRODUCTCOUNTRYID");
            AnyError = 1;
            GX_FocusControl = edtProductCountryId_Internalname;
         }
         A33ProductCountryName = T000421_A33ProductCountryName[0];
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A33ProductCountryName", StringUtil.RTrim( A33ProductCountryName));
      }

      public void Valid_Sellerid( )
      {
         /* Using cursor T000422 */
         pr_default.execute(20, new Object[] {A5SellerId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No matching 'Seller'.", "ForeignKeyNotFound", 1, "SELLERID");
            AnyError = 1;
            GX_FocusControl = edtSellerId_Internalname;
         }
         A13SellerName = T000422_A13SellerName[0];
         A40001SellerPhoto_GXI = T000422_A40001SellerPhoto_GXI[0];
         A3CountryId = T000422_A3CountryId[0];
         A14SellerPhoto = T000422_A14SellerPhoto[0];
         pr_default.close(20);
         /* Using cursor T000423 */
         pr_default.execute(21, new Object[] {A3CountryId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No matching 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
         }
         A4CountryName = T000423_A4CountryName[0];
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A13SellerName", StringUtil.RTrim( A13SellerName));
         AssignAttri("", false, "A14SellerPhoto", context.PathToRelativeUrl( A14SellerPhoto));
         GXCCtlgxBlob = "SELLERPHOTO" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A14SellerPhoto));
         AssignAttri("", false, "A40001SellerPhoto_GXI", A40001SellerPhoto_GXI);
         AssignAttri("", false, "A3CountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A3CountryId), 4, 0, ".", "")));
         AssignAttri("", false, "A4CountryName", StringUtil.RTrim( A4CountryName));
      }

      public void Valid_Categoryid( )
      {
         /* Using cursor T000424 */
         pr_default.execute(22, new Object[] {A1CategoryId});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No matching 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
            AnyError = 1;
            GX_FocusControl = edtCategoryId_Internalname;
         }
         A2CategoryName = T000424_A2CategoryName[0];
         pr_default.close(22);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2CategoryName", StringUtil.RTrim( A2CategoryName));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTID","{handler:'Valid_Productid',iparms:[{av:'A7ProductId',fld:'PRODUCTID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PRODUCTID",",oparms:[{av:'A8ProductName',fld:'PRODUCTNAME',pic:''},{av:'A21ProductDescription',fld:'PRODUCTDESCRIPTION',pic:''},{av:'A22ProductPrice',fld:'PRODUCTPRICE',pic:'$ ZZZZZZ9.99'},{av:'A23ProductPhoto',fld:'PRODUCTPHOTO',pic:''},{av:'A40000ProductPhoto_GXI',fld:'PRODUCTPHOTO_GXI',pic:''},{av:'A9ProductCountryId',fld:'PRODUCTCOUNTRYID',pic:'ZZZ9'},{av:'A5SellerId',fld:'SELLERID',pic:'ZZZ9'},{av:'A1CategoryId',fld:'CATEGORYID',pic:'ZZZ9'},{av:'A33ProductCountryName',fld:'PRODUCTCOUNTRYNAME',pic:''},{av:'A13SellerName',fld:'SELLERNAME',pic:''},{av:'A14SellerPhoto',fld:'SELLERPHOTO',pic:''},{av:'A40001SellerPhoto_GXI',fld:'SELLERPHOTO_GXI',pic:''},{av:'A3CountryId',fld:'COUNTRYID',pic:'ZZZ9'},{av:'A4CountryName',fld:'COUNTRYNAME',pic:''},{av:'A2CategoryName',fld:'CATEGORYNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z7ProductId'},{av:'Z8ProductName'},{av:'Z21ProductDescription'},{av:'Z22ProductPrice'},{av:'Z23ProductPhoto'},{av:'Z40000ProductPhoto_GXI'},{av:'Z9ProductCountryId'},{av:'Z5SellerId'},{av:'Z1CategoryId'},{av:'Z33ProductCountryName'},{av:'Z13SellerName'},{av:'Z14SellerPhoto'},{av:'Z40001SellerPhoto_GXI'},{av:'Z3CountryId'},{av:'Z4CountryName'},{av:'Z2CategoryName'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_PRODUCTNAME","{handler:'Valid_Productname',iparms:[{av:'A8ProductName',fld:'PRODUCTNAME',pic:''},{av:'A7ProductId',fld:'PRODUCTID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_PRODUCTNAME",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTPRICE","{handler:'Valid_Productprice',iparms:[]");
         setEventMetadata("VALID_PRODUCTPRICE",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTCOUNTRYID","{handler:'Valid_Productcountryid',iparms:[{av:'A9ProductCountryId',fld:'PRODUCTCOUNTRYID',pic:'ZZZ9'},{av:'A33ProductCountryName',fld:'PRODUCTCOUNTRYNAME',pic:''}]");
         setEventMetadata("VALID_PRODUCTCOUNTRYID",",oparms:[{av:'A33ProductCountryName',fld:'PRODUCTCOUNTRYNAME',pic:''}]}");
         setEventMetadata("VALID_SELLERID","{handler:'Valid_Sellerid',iparms:[{av:'A5SellerId',fld:'SELLERID',pic:'ZZZ9'},{av:'A3CountryId',fld:'COUNTRYID',pic:'ZZZ9'},{av:'A13SellerName',fld:'SELLERNAME',pic:''},{av:'A14SellerPhoto',fld:'SELLERPHOTO',pic:''},{av:'A40001SellerPhoto_GXI',fld:'SELLERPHOTO_GXI',pic:''},{av:'A4CountryName',fld:'COUNTRYNAME',pic:''}]");
         setEventMetadata("VALID_SELLERID",",oparms:[{av:'A13SellerName',fld:'SELLERNAME',pic:''},{av:'A14SellerPhoto',fld:'SELLERPHOTO',pic:''},{av:'A40001SellerPhoto_GXI',fld:'SELLERPHOTO_GXI',pic:''},{av:'A3CountryId',fld:'COUNTRYID',pic:'ZZZ9'},{av:'A4CountryName',fld:'COUNTRYNAME',pic:''}]}");
         setEventMetadata("VALID_CATEGORYID","{handler:'Valid_Categoryid',iparms:[{av:'A1CategoryId',fld:'CATEGORYID',pic:'ZZZ9'},{av:'A2CategoryName',fld:'CATEGORYNAME',pic:''}]");
         setEventMetadata("VALID_CATEGORYID",",oparms:[{av:'A2CategoryName',fld:'CATEGORYNAME',pic:''}]}");
         setEventMetadata("VALID_COUNTRYID","{handler:'Valid_Countryid',iparms:[]");
         setEventMetadata("VALID_COUNTRYID",",oparms:[]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
         pr_default.close(20);
         pr_default.close(22);
         pr_default.close(19);
         pr_default.close(21);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z8ProductName = "";
         Z21ProductDescription = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A8ProductName = "";
         A21ProductDescription = "";
         A23ProductPhoto = "";
         A40000ProductPhoto_GXI = "";
         sImgUrl = "";
         A33ProductCountryName = "";
         A13SellerName = "";
         A14SellerPhoto = "";
         A40001SellerPhoto_GXI = "";
         A2CategoryName = "";
         A4CountryName = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z23ProductPhoto = "";
         Z40000ProductPhoto_GXI = "";
         Z33ProductCountryName = "";
         Z13SellerName = "";
         Z14SellerPhoto = "";
         Z40001SellerPhoto_GXI = "";
         Z4CountryName = "";
         Z2CategoryName = "";
         T00048_A7ProductId = new short[1] ;
         T00048_A8ProductName = new string[] {""} ;
         T00048_A21ProductDescription = new string[] {""} ;
         T00048_A22ProductPrice = new decimal[1] ;
         T00048_A40000ProductPhoto_GXI = new string[] {""} ;
         T00048_A33ProductCountryName = new string[] {""} ;
         T00048_A13SellerName = new string[] {""} ;
         T00048_A40001SellerPhoto_GXI = new string[] {""} ;
         T00048_A2CategoryName = new string[] {""} ;
         T00048_A4CountryName = new string[] {""} ;
         T00048_A5SellerId = new short[1] ;
         T00048_A1CategoryId = new short[1] ;
         T00048_A9ProductCountryId = new short[1] ;
         T00048_A3CountryId = new short[1] ;
         T00048_A23ProductPhoto = new string[] {""} ;
         T00048_A14SellerPhoto = new string[] {""} ;
         T00049_A8ProductName = new string[] {""} ;
         T00046_A33ProductCountryName = new string[] {""} ;
         T00044_A13SellerName = new string[] {""} ;
         T00044_A40001SellerPhoto_GXI = new string[] {""} ;
         T00044_A3CountryId = new short[1] ;
         T00044_A14SellerPhoto = new string[] {""} ;
         T00047_A4CountryName = new string[] {""} ;
         T00045_A2CategoryName = new string[] {""} ;
         T000410_A33ProductCountryName = new string[] {""} ;
         T000411_A13SellerName = new string[] {""} ;
         T000411_A40001SellerPhoto_GXI = new string[] {""} ;
         T000411_A3CountryId = new short[1] ;
         T000411_A14SellerPhoto = new string[] {""} ;
         T000412_A4CountryName = new string[] {""} ;
         T000413_A2CategoryName = new string[] {""} ;
         T000414_A7ProductId = new short[1] ;
         T00043_A7ProductId = new short[1] ;
         T00043_A8ProductName = new string[] {""} ;
         T00043_A21ProductDescription = new string[] {""} ;
         T00043_A22ProductPrice = new decimal[1] ;
         T00043_A40000ProductPhoto_GXI = new string[] {""} ;
         T00043_A5SellerId = new short[1] ;
         T00043_A1CategoryId = new short[1] ;
         T00043_A9ProductCountryId = new short[1] ;
         T00043_A23ProductPhoto = new string[] {""} ;
         sMode5 = "";
         T000415_A7ProductId = new short[1] ;
         T000416_A7ProductId = new short[1] ;
         T00042_A7ProductId = new short[1] ;
         T00042_A8ProductName = new string[] {""} ;
         T00042_A21ProductDescription = new string[] {""} ;
         T00042_A22ProductPrice = new decimal[1] ;
         T00042_A40000ProductPhoto_GXI = new string[] {""} ;
         T00042_A5SellerId = new short[1] ;
         T00042_A1CategoryId = new short[1] ;
         T00042_A9ProductCountryId = new short[1] ;
         T00042_A23ProductPhoto = new string[] {""} ;
         T000417_A7ProductId = new short[1] ;
         T000421_A33ProductCountryName = new string[] {""} ;
         T000422_A13SellerName = new string[] {""} ;
         T000422_A40001SellerPhoto_GXI = new string[] {""} ;
         T000422_A3CountryId = new short[1] ;
         T000422_A14SellerPhoto = new string[] {""} ;
         T000423_A4CountryName = new string[] {""} ;
         T000424_A2CategoryName = new string[] {""} ;
         T000425_A11ShoppingCartId = new short[1] ;
         T000425_A7ProductId = new short[1] ;
         T000426_A10PromotionId = new short[1] ;
         T000426_A7ProductId = new short[1] ;
         T000427_A7ProductId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         ZZ8ProductName = "";
         ZZ21ProductDescription = "";
         ZZ23ProductPhoto = "";
         ZZ40000ProductPhoto_GXI = "";
         ZZ33ProductCountryName = "";
         ZZ13SellerName = "";
         ZZ14SellerPhoto = "";
         ZZ40001SellerPhoto_GXI = "";
         ZZ4CountryName = "";
         ZZ2CategoryName = "";
         T000428_A8ProductName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.product__default(),
            new Object[][] {
                new Object[] {
               T00042_A7ProductId, T00042_A8ProductName, T00042_A21ProductDescription, T00042_A22ProductPrice, T00042_A40000ProductPhoto_GXI, T00042_A5SellerId, T00042_A1CategoryId, T00042_A9ProductCountryId, T00042_A23ProductPhoto
               }
               , new Object[] {
               T00043_A7ProductId, T00043_A8ProductName, T00043_A21ProductDescription, T00043_A22ProductPrice, T00043_A40000ProductPhoto_GXI, T00043_A5SellerId, T00043_A1CategoryId, T00043_A9ProductCountryId, T00043_A23ProductPhoto
               }
               , new Object[] {
               T00044_A13SellerName, T00044_A40001SellerPhoto_GXI, T00044_A3CountryId, T00044_A14SellerPhoto
               }
               , new Object[] {
               T00045_A2CategoryName
               }
               , new Object[] {
               T00046_A33ProductCountryName
               }
               , new Object[] {
               T00047_A4CountryName
               }
               , new Object[] {
               T00048_A7ProductId, T00048_A8ProductName, T00048_A21ProductDescription, T00048_A22ProductPrice, T00048_A40000ProductPhoto_GXI, T00048_A33ProductCountryName, T00048_A13SellerName, T00048_A40001SellerPhoto_GXI, T00048_A2CategoryName, T00048_A4CountryName,
               T00048_A5SellerId, T00048_A1CategoryId, T00048_A9ProductCountryId, T00048_A3CountryId, T00048_A23ProductPhoto, T00048_A14SellerPhoto
               }
               , new Object[] {
               T00049_A8ProductName
               }
               , new Object[] {
               T000410_A33ProductCountryName
               }
               , new Object[] {
               T000411_A13SellerName, T000411_A40001SellerPhoto_GXI, T000411_A3CountryId, T000411_A14SellerPhoto
               }
               , new Object[] {
               T000412_A4CountryName
               }
               , new Object[] {
               T000413_A2CategoryName
               }
               , new Object[] {
               T000414_A7ProductId
               }
               , new Object[] {
               T000415_A7ProductId
               }
               , new Object[] {
               T000416_A7ProductId
               }
               , new Object[] {
               T000417_A7ProductId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000421_A33ProductCountryName
               }
               , new Object[] {
               T000422_A13SellerName, T000422_A40001SellerPhoto_GXI, T000422_A3CountryId, T000422_A14SellerPhoto
               }
               , new Object[] {
               T000423_A4CountryName
               }
               , new Object[] {
               T000424_A2CategoryName
               }
               , new Object[] {
               T000425_A11ShoppingCartId, T000425_A7ProductId
               }
               , new Object[] {
               T000426_A10PromotionId, T000426_A7ProductId
               }
               , new Object[] {
               T000427_A7ProductId
               }
               , new Object[] {
               T000428_A8ProductName
               }
            }
         );
      }

      private short Z7ProductId ;
      private short Z5SellerId ;
      private short Z1CategoryId ;
      private short Z9ProductCountryId ;
      private short GxWebError ;
      private short A9ProductCountryId ;
      private short A5SellerId ;
      private short A3CountryId ;
      private short A1CategoryId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A7ProductId ;
      private short GX_JID ;
      private short Z3CountryId ;
      private short RcdFound5 ;
      private short nIsDirty_5 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ7ProductId ;
      private short ZZ9ProductCountryId ;
      private short ZZ5SellerId ;
      private short ZZ1CategoryId ;
      private short ZZ3CountryId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtProductId_Enabled ;
      private int edtProductName_Enabled ;
      private int edtProductDescription_Enabled ;
      private int edtProductPrice_Enabled ;
      private int imgProductPhoto_Enabled ;
      private int edtProductCountryId_Enabled ;
      private int imgprompt_9_Visible ;
      private int edtProductCountryName_Enabled ;
      private int edtSellerId_Enabled ;
      private int imgprompt_5_Visible ;
      private int edtSellerName_Enabled ;
      private int imgSellerPhoto_Enabled ;
      private int edtCategoryId_Enabled ;
      private int imgprompt_1_Visible ;
      private int edtCategoryName_Enabled ;
      private int edtCountryId_Enabled ;
      private int edtCountryName_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private decimal Z22ProductPrice ;
      private decimal A22ProductPrice ;
      private decimal ZZ22ProductPrice ;
      private string sPrefix ;
      private string Z8ProductName ;
      private string Z21ProductDescription ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProductId_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtProductId_Jsonclick ;
      private string edtProductName_Internalname ;
      private string A8ProductName ;
      private string edtProductName_Jsonclick ;
      private string edtProductDescription_Internalname ;
      private string A21ProductDescription ;
      private string edtProductDescription_Jsonclick ;
      private string edtProductPrice_Internalname ;
      private string edtProductPrice_Jsonclick ;
      private string imgProductPhoto_Internalname ;
      private string sImgUrl ;
      private string edtProductCountryId_Internalname ;
      private string edtProductCountryId_Jsonclick ;
      private string imgprompt_9_Internalname ;
      private string imgprompt_9_Link ;
      private string edtProductCountryName_Internalname ;
      private string A33ProductCountryName ;
      private string edtProductCountryName_Jsonclick ;
      private string edtSellerId_Internalname ;
      private string edtSellerId_Jsonclick ;
      private string imgprompt_5_Internalname ;
      private string imgprompt_5_Link ;
      private string edtSellerName_Internalname ;
      private string A13SellerName ;
      private string edtSellerName_Jsonclick ;
      private string imgSellerPhoto_Internalname ;
      private string edtCategoryId_Internalname ;
      private string edtCategoryId_Jsonclick ;
      private string imgprompt_1_Internalname ;
      private string imgprompt_1_Link ;
      private string edtCategoryName_Internalname ;
      private string A2CategoryName ;
      private string edtCategoryName_Jsonclick ;
      private string edtCountryId_Internalname ;
      private string edtCountryId_Jsonclick ;
      private string edtCountryName_Internalname ;
      private string A4CountryName ;
      private string edtCountryName_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z33ProductCountryName ;
      private string Z13SellerName ;
      private string Z4CountryName ;
      private string Z2CategoryName ;
      private string sMode5 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string ZZ8ProductName ;
      private string ZZ21ProductDescription ;
      private string ZZ33ProductCountryName ;
      private string ZZ13SellerName ;
      private string ZZ4CountryName ;
      private string ZZ2CategoryName ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A23ProductPhoto_IsBlob ;
      private bool A14SellerPhoto_IsBlob ;
      private bool Gx_longc ;
      private string A40000ProductPhoto_GXI ;
      private string A40001SellerPhoto_GXI ;
      private string Z40000ProductPhoto_GXI ;
      private string Z40001SellerPhoto_GXI ;
      private string ZZ40000ProductPhoto_GXI ;
      private string ZZ40001SellerPhoto_GXI ;
      private string A23ProductPhoto ;
      private string A14SellerPhoto ;
      private string Z23ProductPhoto ;
      private string Z14SellerPhoto ;
      private string ZZ23ProductPhoto ;
      private string ZZ14SellerPhoto ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00048_A7ProductId ;
      private string[] T00048_A8ProductName ;
      private string[] T00048_A21ProductDescription ;
      private decimal[] T00048_A22ProductPrice ;
      private string[] T00048_A40000ProductPhoto_GXI ;
      private string[] T00048_A33ProductCountryName ;
      private string[] T00048_A13SellerName ;
      private string[] T00048_A40001SellerPhoto_GXI ;
      private string[] T00048_A2CategoryName ;
      private string[] T00048_A4CountryName ;
      private short[] T00048_A5SellerId ;
      private short[] T00048_A1CategoryId ;
      private short[] T00048_A9ProductCountryId ;
      private short[] T00048_A3CountryId ;
      private string[] T00048_A23ProductPhoto ;
      private string[] T00048_A14SellerPhoto ;
      private string[] T00049_A8ProductName ;
      private string[] T00046_A33ProductCountryName ;
      private string[] T00044_A13SellerName ;
      private string[] T00044_A40001SellerPhoto_GXI ;
      private short[] T00044_A3CountryId ;
      private string[] T00044_A14SellerPhoto ;
      private string[] T00047_A4CountryName ;
      private string[] T00045_A2CategoryName ;
      private string[] T000410_A33ProductCountryName ;
      private string[] T000411_A13SellerName ;
      private string[] T000411_A40001SellerPhoto_GXI ;
      private short[] T000411_A3CountryId ;
      private string[] T000411_A14SellerPhoto ;
      private string[] T000412_A4CountryName ;
      private string[] T000413_A2CategoryName ;
      private short[] T000414_A7ProductId ;
      private short[] T00043_A7ProductId ;
      private string[] T00043_A8ProductName ;
      private string[] T00043_A21ProductDescription ;
      private decimal[] T00043_A22ProductPrice ;
      private string[] T00043_A40000ProductPhoto_GXI ;
      private short[] T00043_A5SellerId ;
      private short[] T00043_A1CategoryId ;
      private short[] T00043_A9ProductCountryId ;
      private string[] T00043_A23ProductPhoto ;
      private short[] T000415_A7ProductId ;
      private short[] T000416_A7ProductId ;
      private short[] T00042_A7ProductId ;
      private string[] T00042_A8ProductName ;
      private string[] T00042_A21ProductDescription ;
      private decimal[] T00042_A22ProductPrice ;
      private string[] T00042_A40000ProductPhoto_GXI ;
      private short[] T00042_A5SellerId ;
      private short[] T00042_A1CategoryId ;
      private short[] T00042_A9ProductCountryId ;
      private string[] T00042_A23ProductPhoto ;
      private short[] T000417_A7ProductId ;
      private string[] T000421_A33ProductCountryName ;
      private string[] T000422_A13SellerName ;
      private string[] T000422_A40001SellerPhoto_GXI ;
      private short[] T000422_A3CountryId ;
      private string[] T000422_A14SellerPhoto ;
      private string[] T000423_A4CountryName ;
      private string[] T000424_A2CategoryName ;
      private short[] T000425_A11ShoppingCartId ;
      private short[] T000425_A7ProductId ;
      private short[] T000426_A10PromotionId ;
      private short[] T000426_A7ProductId ;
      private short[] T000427_A7ProductId ;
      private string[] T000428_A8ProductName ;
      private GXWebForm Form ;
   }

   public class product__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00048;
          prmT00048 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00049;
          prmT00049 = new Object[] {
          new ParDef("@ProductName",GXType.NChar,20,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00046;
          prmT00046 = new Object[] {
          new ParDef("@ProductCountryId",GXType.Int16,4,0)
          };
          Object[] prmT00044;
          prmT00044 = new Object[] {
          new ParDef("@SellerId",GXType.Int16,4,0)
          };
          Object[] prmT00047;
          prmT00047 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT00045;
          prmT00045 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmT000410;
          prmT000410 = new Object[] {
          new ParDef("@ProductCountryId",GXType.Int16,4,0)
          };
          Object[] prmT000411;
          prmT000411 = new Object[] {
          new ParDef("@SellerId",GXType.Int16,4,0)
          };
          Object[] prmT000412;
          prmT000412 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT000413;
          prmT000413 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmT000414;
          prmT000414 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00043;
          prmT00043 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000415;
          prmT000415 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000416;
          prmT000416 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00042;
          prmT00042 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000417;
          prmT000417 = new Object[] {
          new ParDef("@ProductName",GXType.NChar,20,0) ,
          new ParDef("@ProductDescription",GXType.NChar,50,0) ,
          new ParDef("@ProductPrice",GXType.Decimal,10,2) ,
          new ParDef("@ProductPhoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@ProductPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=3, Tbl="Product", Fld="ProductPhoto"} ,
          new ParDef("@SellerId",GXType.Int16,4,0) ,
          new ParDef("@CategoryId",GXType.Int16,4,0) ,
          new ParDef("@ProductCountryId",GXType.Int16,4,0)
          };
          Object[] prmT000418;
          prmT000418 = new Object[] {
          new ParDef("@ProductName",GXType.NChar,20,0) ,
          new ParDef("@ProductDescription",GXType.NChar,50,0) ,
          new ParDef("@ProductPrice",GXType.Decimal,10,2) ,
          new ParDef("@SellerId",GXType.Int16,4,0) ,
          new ParDef("@CategoryId",GXType.Int16,4,0) ,
          new ParDef("@ProductCountryId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000419;
          prmT000419 = new Object[] {
          new ParDef("@ProductPhoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@ProductPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Product", Fld="ProductPhoto"} ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000420;
          prmT000420 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000425;
          prmT000425 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000426;
          prmT000426 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000427;
          prmT000427 = new Object[] {
          };
          Object[] prmT000428;
          prmT000428 = new Object[] {
          new ParDef("@ProductName",GXType.NChar,20,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000421;
          prmT000421 = new Object[] {
          new ParDef("@ProductCountryId",GXType.Int16,4,0)
          };
          Object[] prmT000422;
          prmT000422 = new Object[] {
          new ParDef("@SellerId",GXType.Int16,4,0)
          };
          Object[] prmT000423;
          prmT000423 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT000424;
          prmT000424 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00042", "SELECT [ProductId], [ProductName], [ProductDescription], [ProductPrice], [ProductPhoto_GXI], [SellerId], [CategoryId], [ProductCountryId] AS ProductCountryId, [ProductPhoto] FROM [Product] WITH (UPDLOCK) WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00042,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00043", "SELECT [ProductId], [ProductName], [ProductDescription], [ProductPrice], [ProductPhoto_GXI], [SellerId], [CategoryId], [ProductCountryId] AS ProductCountryId, [ProductPhoto] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00043,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00044", "SELECT [SellerName], [SellerPhoto_GXI], [CountryId], [SellerPhoto] FROM [Seller] WHERE [SellerId] = @SellerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00044,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00045", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00045,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00046", "SELECT [CountryName] AS ProductCountryName FROM [Country] WHERE [CountryId] = @ProductCountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00046,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00047", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00047,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00048", "SELECT TM1.[ProductId], TM1.[ProductName], TM1.[ProductDescription], TM1.[ProductPrice], TM1.[ProductPhoto_GXI], T2.[CountryName] AS ProductCountryName, T3.[SellerName], T3.[SellerPhoto_GXI], T5.[CategoryName], T4.[CountryName], TM1.[SellerId], TM1.[CategoryId], TM1.[ProductCountryId] AS ProductCountryId, T3.[CountryId], TM1.[ProductPhoto], T3.[SellerPhoto] FROM (((([Product] TM1 INNER JOIN [Country] T2 ON T2.[CountryId] = TM1.[ProductCountryId]) INNER JOIN [Seller] T3 ON T3.[SellerId] = TM1.[SellerId]) INNER JOIN [Country] T4 ON T4.[CountryId] = T3.[CountryId]) INNER JOIN [Category] T5 ON T5.[CategoryId] = TM1.[CategoryId]) WHERE TM1.[ProductId] = @ProductId ORDER BY TM1.[ProductId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00048,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00049", "SELECT [ProductName] FROM [Product] WHERE ([ProductName] = @ProductName) AND (Not ( [ProductId] = @ProductId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT00049,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000410", "SELECT [CountryName] AS ProductCountryName FROM [Country] WHERE [CountryId] = @ProductCountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000410,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000411", "SELECT [SellerName], [SellerPhoto_GXI], [CountryId], [SellerPhoto] FROM [Seller] WHERE [SellerId] = @SellerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000411,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000412", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000412,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000413", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000413,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000414", "SELECT [ProductId] FROM [Product] WHERE [ProductId] = @ProductId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000414,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000415", "SELECT TOP 1 [ProductId] FROM [Product] WHERE ( [ProductId] > @ProductId) ORDER BY [ProductId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000415,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000416", "SELECT TOP 1 [ProductId] FROM [Product] WHERE ( [ProductId] < @ProductId) ORDER BY [ProductId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000416,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000417", "INSERT INTO [Product]([ProductName], [ProductDescription], [ProductPrice], [ProductPhoto], [ProductPhoto_GXI], [SellerId], [CategoryId], [ProductCountryId]) VALUES(@ProductName, @ProductDescription, @ProductPrice, @ProductPhoto, @ProductPhoto_GXI, @SellerId, @CategoryId, @ProductCountryId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000417,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000418", "UPDATE [Product] SET [ProductName]=@ProductName, [ProductDescription]=@ProductDescription, [ProductPrice]=@ProductPrice, [SellerId]=@SellerId, [CategoryId]=@CategoryId, [ProductCountryId]=@ProductCountryId  WHERE [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmT000418)
             ,new CursorDef("T000419", "UPDATE [Product] SET [ProductPhoto]=@ProductPhoto, [ProductPhoto_GXI]=@ProductPhoto_GXI  WHERE [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmT000419)
             ,new CursorDef("T000420", "DELETE FROM [Product]  WHERE [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmT000420)
             ,new CursorDef("T000421", "SELECT [CountryName] AS ProductCountryName FROM [Country] WHERE [CountryId] = @ProductCountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000421,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000422", "SELECT [SellerName], [SellerPhoto_GXI], [CountryId], [SellerPhoto] FROM [Seller] WHERE [SellerId] = @SellerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000422,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000423", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000423,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000424", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000424,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000425", "SELECT TOP 1 [ShoppingCartId], [ProductId] FROM [ShoppingCartProduct] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000425,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000426", "SELECT TOP 1 [PromotionId], [ProductId] FROM [PromotionProduct] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000426,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000427", "SELECT [ProductId] FROM [Product] ORDER BY [ProductId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000427,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000428", "SELECT [ProductName] FROM [Product] WHERE ([ProductName] = @ProductName) AND (Not ( [ProductId] = @ProductId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000428,1, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(5));
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(5));
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(2));
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getMultimediaUri(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((short[]) buf[12])[0] = rslt.getShort(13);
                ((short[]) buf[13])[0] = rslt.getShort(14);
                ((string[]) buf[14])[0] = rslt.getMultimediaFile(15, rslt.getVarchar(5));
                ((string[]) buf[15])[0] = rslt.getMultimediaFile(16, rslt.getVarchar(8));
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(2));
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(2));
                return;
             case 21 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 22 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 24 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 25 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 26 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
       }
    }

 }

}
