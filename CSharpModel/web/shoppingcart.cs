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
   public class shoppingcart : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         gxfirstwebparm = GetFirstPar( "Mode");
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
         {
            A11ShoppingCartId = (short)(NumberUtil.Val( GetPar( "ShoppingCartId"), "."));
            AssignAttri("", false, "A11ShoppingCartId", StringUtil.LTrimStr( (decimal)(A11ShoppingCartId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_17( A11ShoppingCartId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A6CustomerId = (short)(NumberUtil.Val( GetPar( "CustomerId"), "."));
            AssignAttri("", false, "A6CustomerId", StringUtil.LTrimStr( (decimal)(A6CustomerId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A6CustomerId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A3CountryId = (short)(NumberUtil.Val( GetPar( "CountryId"), "."));
            AssignAttri("", false, "A3CountryId", StringUtil.LTrimStr( (decimal)(A3CountryId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A3CountryId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A7ProductId = (short)(NumberUtil.Val( GetPar( "ProductId"), "."));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A7ProductId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
         {
            A1CategoryId = (short)(NumberUtil.Val( GetPar( "CategoryId"), "."));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_20( A1CategoryId) ;
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
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridshoppingcart_product") == 0 )
         {
            gxnrGridshoppingcart_product_newrow_invoke( ) ;
            return  ;
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
         if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV9ShoppingCartId = (short)(NumberUtil.Val( GetPar( "ShoppingCartId"), "."));
               AssignAttri("", false, "AV9ShoppingCartId", StringUtil.LTrimStr( (decimal)(AV9ShoppingCartId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vSHOPPINGCARTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9ShoppingCartId), "ZZZ9"), context));
            }
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
            Form.Meta.addItem("description", "Shopping Cart", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtShoppingCartDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridshoppingcart_product_newrow_invoke( )
      {
         nRC_GXsfl_83 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_83"), "."));
         nGXsfl_83_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_83_idx"), "."));
         sGXsfl_83_idx = GetPar( "sGXsfl_83_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridshoppingcart_product_newrow( ) ;
         /* End function gxnrGridshoppingcart_product_newrow_invoke */
      }

      public shoppingcart( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public shoppingcart( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_ShoppingCartId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV9ShoppingCartId = aP1_ShoppingCartId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Shopping Cart", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_ShoppingCart.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_ShoppingCart.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtShoppingCartId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtShoppingCartId_Internalname, "Cart Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtShoppingCartId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A11ShoppingCartId), 4, 0, ".", "")), StringUtil.LTrim( ((edtShoppingCartId_Enabled!=0) ? context.localUtil.Format( (decimal)(A11ShoppingCartId), "ZZZ9") : context.localUtil.Format( (decimal)(A11ShoppingCartId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtShoppingCartId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtShoppingCartId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtShoppingCartDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtShoppingCartDate_Internalname, "Cart Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtShoppingCartDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtShoppingCartDate_Internalname, context.localUtil.Format(A28ShoppingCartDate, "99/99/99"), context.localUtil.Format( A28ShoppingCartDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtShoppingCartDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtShoppingCartDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ShoppingCart.htm");
         GxWebStd.gx_bitmap( context, edtShoppingCartDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtShoppingCartDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ShoppingCart.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtShoppingCartDateDelivery_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtShoppingCartDateDelivery_Internalname, "Date Delivery", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtShoppingCartDateDelivery_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtShoppingCartDateDelivery_Internalname, context.localUtil.Format(A32ShoppingCartDateDelivery, "99/99/99"), context.localUtil.Format( A32ShoppingCartDateDelivery, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtShoppingCartDateDelivery_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtShoppingCartDateDelivery_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ShoppingCart.htm");
         GxWebStd.gx_bitmap( context, edtShoppingCartDateDelivery_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtShoppingCartDateDelivery_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ShoppingCart.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCustomerId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCustomerId_Internalname, "Customer Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCustomerId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A6CustomerId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A6CustomerId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCustomerId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_ShoppingCart.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_6_Internalname, sImgUrl, imgprompt_6_Link, "", "", context.GetTheme( ), imgprompt_6_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCustomerName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCustomerName_Internalname, "Customer Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCustomerName_Internalname, StringUtil.RTrim( A15CustomerName), StringUtil.RTrim( context.localUtil.Format( A15CustomerName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCustomerName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_ShoppingCart.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCountryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A3CountryId), 4, 0, ".", "")), StringUtil.LTrim( ((edtCountryId_Enabled!=0) ? context.localUtil.Format( (decimal)(A3CountryId), "ZZZ9") : context.localUtil.Format( (decimal)(A3CountryId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCountryId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCountryId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_ShoppingCart.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCountryName_Internalname, StringUtil.RTrim( A4CountryName), StringUtil.RTrim( context.localUtil.Format( A4CountryName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCountryName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCountryName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCustomerAddress_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCustomerAddress_Internalname, "Customer Address", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtCustomerAddress_Internalname, A16CustomerAddress, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A16CustomerAddress), "", 0, 1, edtCustomerAddress_Enabled, 0, 80, "chr", 10, "row", 1, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCustomerPhone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCustomerPhone_Internalname, "Customer Phone", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A18CustomerPhone);
         }
         GxWebStd.gx_single_line_edit( context, edtCustomerPhone_Internalname, StringUtil.RTrim( A18CustomerPhone), StringUtil.RTrim( context.localUtil.Format( A18CustomerPhone, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtCustomerPhone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCustomerPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Phone", "left", true, "", "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divProducttable_Internalname, 1, 0, "px", 0, "px", "LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitleproduct_Internalname, "Product", "", "", lblTitleproduct_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridshoppingcart_product( ) ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtShoppingCartFinalPrice_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtShoppingCartFinalPrice_Internalname, "Final Price", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtShoppingCartFinalPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A29ShoppingCartFinalPrice, 12, 2, ".", "")), StringUtil.LTrim( ((edtShoppingCartFinalPrice_Enabled!=0) ? context.localUtil.Format( A29ShoppingCartFinalPrice, "$ ZZZZZZ9.99") : context.localUtil.Format( A29ShoppingCartFinalPrice, "$ ZZZZZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtShoppingCartFinalPrice_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtShoppingCartFinalPrice_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ShoppingCart.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridshoppingcart_product( )
      {
         /*  Grid Control  */
         StartGridControl83( ) ;
         nGXsfl_83_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount9 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_9 = 1;
               ScanStart059( ) ;
               while ( RcdFound9 != 0 )
               {
                  init_level_properties9( ) ;
                  getByPrimaryKey059( ) ;
                  AddRow059( ) ;
                  ScanNext059( ) ;
               }
               ScanEnd059( ) ;
               nBlankRcdCount9 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B29ShoppingCartFinalPrice = A29ShoppingCartFinalPrice;
            n29ShoppingCartFinalPrice = false;
            AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
            standaloneNotModal059( ) ;
            standaloneModal059( ) ;
            sMode9 = Gx_mode;
            while ( nGXsfl_83_idx < nRC_GXsfl_83 )
            {
               bGXsfl_83_Refreshing = true;
               ReadRow059( ) ;
               edtProductId_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTID_"+sGXsfl_83_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtProductName_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTNAME_"+sGXsfl_83_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtProductPrice_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTPRICE_"+sGXsfl_83_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtProductPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductPrice_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtQtyProduct_Enabled = (int)(context.localUtil.CToN( cgiGet( "QTYPRODUCT_"+sGXsfl_83_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtQtyProduct_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtQtyProduct_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtTotalProduct_Enabled = (int)(context.localUtil.CToN( cgiGet( "TOTALPRODUCT_"+sGXsfl_83_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtTotalProduct_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotalProduct_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtCategoryId_Enabled = (int)(context.localUtil.CToN( cgiGet( "CATEGORYID_"+sGXsfl_83_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCategoryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtCategoryName_Enabled = (int)(context.localUtil.CToN( cgiGet( "CATEGORYNAME_"+sGXsfl_83_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCategoryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryName_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               imgprompt_6_Link = cgiGet( "PROMPT_7_"+sGXsfl_83_idx+"Link");
               if ( ( nRcdExists_9 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal059( ) ;
               }
               SendRow059( ) ;
               bGXsfl_83_Refreshing = false;
            }
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A29ShoppingCartFinalPrice = B29ShoppingCartFinalPrice;
            n29ShoppingCartFinalPrice = false;
            AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount9 = 5;
            nRcdExists_9 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart059( ) ;
               while ( RcdFound9 != 0 )
               {
                  sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_839( ) ;
                  init_level_properties9( ) ;
                  standaloneNotModal059( ) ;
                  getByPrimaryKey059( ) ;
                  standaloneModal059( ) ;
                  AddRow059( ) ;
                  ScanNext059( ) ;
               }
               ScanEnd059( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode9 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx+1), 4, 0), 4, "0");
            SubsflControlProps_839( ) ;
            InitAll059( ) ;
            init_level_properties9( ) ;
            B29ShoppingCartFinalPrice = A29ShoppingCartFinalPrice;
            n29ShoppingCartFinalPrice = false;
            AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
            nRcdExists_9 = 0;
            nIsMod_9 = 0;
            nRcdDeleted_9 = 0;
            nBlankRcdCount9 = (short)(nBlankRcdUsr9+nBlankRcdCount9);
            fRowAdded = 0;
            while ( nBlankRcdCount9 > 0 )
            {
               standaloneNotModal059( ) ;
               standaloneModal059( ) ;
               AddRow059( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtProductId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount9 = (short)(nBlankRcdCount9-1);
            }
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A29ShoppingCartFinalPrice = B29ShoppingCartFinalPrice;
            n29ShoppingCartFinalPrice = false;
            AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridshoppingcart_productContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridshoppingcart_product", Gridshoppingcart_productContainer, subGridshoppingcart_product_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridshoppingcart_productContainerData", Gridshoppingcart_productContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridshoppingcart_productContainerData"+"V", Gridshoppingcart_productContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridshoppingcart_productContainerData"+"V"+"\" value='"+Gridshoppingcart_productContainer.GridValuesHidden()+"'/>") ;
         }
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
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11052 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z11ShoppingCartId = (short)(context.localUtil.CToN( cgiGet( "Z11ShoppingCartId"), ".", ","));
               Z28ShoppingCartDate = context.localUtil.CToD( cgiGet( "Z28ShoppingCartDate"), 0);
               Z6CustomerId = (short)(context.localUtil.CToN( cgiGet( "Z6CustomerId"), ".", ","));
               O29ShoppingCartFinalPrice = context.localUtil.CToN( cgiGet( "O29ShoppingCartFinalPrice"), ".", ",");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_83 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_83"), ".", ","));
               N6CustomerId = (short)(context.localUtil.CToN( cgiGet( "N6CustomerId"), ".", ","));
               AV9ShoppingCartId = (short)(context.localUtil.CToN( cgiGet( "vSHOPPINGCARTID"), ".", ","));
               AV7Insert_CustomerId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_CUSTOMERID"), ".", ","));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
               AV14Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A11ShoppingCartId = (short)(context.localUtil.CToN( cgiGet( edtShoppingCartId_Internalname), ".", ","));
               AssignAttri("", false, "A11ShoppingCartId", StringUtil.LTrimStr( (decimal)(A11ShoppingCartId), 4, 0));
               if ( context.localUtil.VCDate( cgiGet( edtShoppingCartDate_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Shopping Cart Date"}), 1, "SHOPPINGCARTDATE");
                  AnyError = 1;
                  GX_FocusControl = edtShoppingCartDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A28ShoppingCartDate = DateTime.MinValue;
                  AssignAttri("", false, "A28ShoppingCartDate", context.localUtil.Format(A28ShoppingCartDate, "99/99/99"));
               }
               else
               {
                  A28ShoppingCartDate = context.localUtil.CToD( cgiGet( edtShoppingCartDate_Internalname), 1);
                  AssignAttri("", false, "A28ShoppingCartDate", context.localUtil.Format(A28ShoppingCartDate, "99/99/99"));
               }
               A32ShoppingCartDateDelivery = context.localUtil.CToD( cgiGet( edtShoppingCartDateDelivery_Internalname), 1);
               AssignAttri("", false, "A32ShoppingCartDateDelivery", context.localUtil.Format(A32ShoppingCartDateDelivery, "99/99/99"));
               if ( ( ( context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CUSTOMERID");
                  AnyError = 1;
                  GX_FocusControl = edtCustomerId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A6CustomerId = 0;
                  AssignAttri("", false, "A6CustomerId", StringUtil.LTrimStr( (decimal)(A6CustomerId), 4, 0));
               }
               else
               {
                  A6CustomerId = (short)(context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), ".", ","));
                  AssignAttri("", false, "A6CustomerId", StringUtil.LTrimStr( (decimal)(A6CustomerId), 4, 0));
               }
               A15CustomerName = cgiGet( edtCustomerName_Internalname);
               AssignAttri("", false, "A15CustomerName", A15CustomerName);
               A3CountryId = (short)(context.localUtil.CToN( cgiGet( edtCountryId_Internalname), ".", ","));
               AssignAttri("", false, "A3CountryId", StringUtil.LTrimStr( (decimal)(A3CountryId), 4, 0));
               A4CountryName = cgiGet( edtCountryName_Internalname);
               AssignAttri("", false, "A4CountryName", A4CountryName);
               A16CustomerAddress = cgiGet( edtCustomerAddress_Internalname);
               AssignAttri("", false, "A16CustomerAddress", A16CustomerAddress);
               A18CustomerPhone = cgiGet( edtCustomerPhone_Internalname);
               AssignAttri("", false, "A18CustomerPhone", A18CustomerPhone);
               A29ShoppingCartFinalPrice = context.localUtil.CToN( cgiGet( edtShoppingCartFinalPrice_Internalname), ".", ",");
               n29ShoppingCartFinalPrice = false;
               AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ShoppingCart");
               A11ShoppingCartId = (short)(context.localUtil.CToN( cgiGet( edtShoppingCartId_Internalname), ".", ","));
               AssignAttri("", false, "A11ShoppingCartId", StringUtil.LTrimStr( (decimal)(A11ShoppingCartId), 4, 0));
               forbiddenHiddens.Add("ShoppingCartId", context.localUtil.Format( (decimal)(A11ShoppingCartId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A11ShoppingCartId != Z11ShoppingCartId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("shoppingcart:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusDescription = 403.ToString();
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A11ShoppingCartId = (short)(NumberUtil.Val( GetPar( "ShoppingCartId"), "."));
                  AssignAttri("", false, "A11ShoppingCartId", StringUtil.LTrimStr( (decimal)(A11ShoppingCartId), 4, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode8 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode8;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound8 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_050( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SHOPPINGCARTID");
                        AnyError = 1;
                        GX_FocusControl = edtShoppingCartId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11052 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12052 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
            /* Execute user event: After Trn */
            E12052 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll058( ) ;
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
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtn_delete_Visible = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtn_enter_Visible = 0;
               AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
            }
            DisableAttributes058( ) ;
         }
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

      protected void CONFIRM_050( )
      {
         BeforeValidate058( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls058( ) ;
            }
            else
            {
               CheckExtendedTable058( ) ;
               CloseExtendedTableCursors058( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode8 = Gx_mode;
            CONFIRM_059( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode8;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_059( )
      {
         s29ShoppingCartFinalPrice = O29ShoppingCartFinalPrice;
         n29ShoppingCartFinalPrice = false;
         AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
         nGXsfl_83_idx = 0;
         while ( nGXsfl_83_idx < nRC_GXsfl_83 )
         {
            ReadRow059( ) ;
            if ( ( nRcdExists_9 != 0 ) || ( nIsMod_9 != 0 ) )
            {
               GetKey059( ) ;
               if ( ( nRcdExists_9 == 0 ) && ( nRcdDeleted_9 == 0 ) )
               {
                  if ( RcdFound9 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate059( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable059( ) ;
                        CloseExtendedTableCursors059( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O29ShoppingCartFinalPrice = A29ShoppingCartFinalPrice;
                        n29ShoppingCartFinalPrice = false;
                        AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
                     }
                  }
                  else
                  {
                     GXCCtl = "PRODUCTID_" + sGXsfl_83_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtProductId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound9 != 0 )
                  {
                     if ( nRcdDeleted_9 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey059( ) ;
                        Load059( ) ;
                        BeforeValidate059( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls059( ) ;
                           O29ShoppingCartFinalPrice = A29ShoppingCartFinalPrice;
                           n29ShoppingCartFinalPrice = false;
                           AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
                        }
                     }
                     else
                     {
                        if ( nIsMod_9 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate059( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable059( ) ;
                              CloseExtendedTableCursors059( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O29ShoppingCartFinalPrice = A29ShoppingCartFinalPrice;
                              n29ShoppingCartFinalPrice = false;
                              AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_9 == 0 )
                     {
                        GXCCtl = "PRODUCTID_" + sGXsfl_83_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProductId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProductId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A7ProductId), 4, 0, ".", ""))) ;
            ChangePostValue( edtProductName_Internalname, StringUtil.RTrim( A8ProductName)) ;
            ChangePostValue( edtProductPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A22ProductPrice, 12, 2, ".", ""))) ;
            ChangePostValue( edtQtyProduct_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A31QtyProduct), 4, 0, ".", ""))) ;
            ChangePostValue( edtTotalProduct_Internalname, StringUtil.LTrim( StringUtil.NToC( A30TotalProduct, 12, 2, ".", ""))) ;
            ChangePostValue( edtCategoryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CategoryId), 4, 0, ".", ""))) ;
            ChangePostValue( edtCategoryName_Internalname, StringUtil.RTrim( A2CategoryName)) ;
            ChangePostValue( "ZT_"+"Z7ProductId_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7ProductId), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z31QtyProduct_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z31QtyProduct), 4, 0, ".", ""))) ;
            ChangePostValue( "T30TotalProduct_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( O30TotalProduct, 10, 2, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_9_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_9), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_9_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_9), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_9_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_9), 4, 0, ".", ""))) ;
            if ( nIsMod_9 != 0 )
            {
               ChangePostValue( "PRODUCTID_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTNAME_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTPRICE_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductPrice_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "QTYPRODUCT_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtQtyProduct_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "TOTALPRODUCT_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTotalProduct_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CATEGORYID_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoryId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CATEGORYNAME_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoryName_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O29ShoppingCartFinalPrice = s29ShoppingCartFinalPrice;
         n29ShoppingCartFinalPrice = false;
         AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption050( )
      {
      }

      protected void E11052( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV14Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV14Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV10TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         AV7Insert_CustomerId = 0;
         AssignAttri("", false, "AV7Insert_CustomerId", StringUtil.LTrimStr( (decimal)(AV7Insert_CustomerId), 4, 0));
         if ( ( StringUtil.StrCmp(AV10TrnContext.gxTpr_Transactionname, AV14Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV15GXV1 = 1;
            AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
            while ( AV15GXV1 <= AV10TrnContext.gxTpr_Attributes.Count )
            {
               AV11TrnContextAtt = ((SdtTransactionContext_Attribute)AV10TrnContext.gxTpr_Attributes.Item(AV15GXV1));
               if ( StringUtil.StrCmp(AV11TrnContextAtt.gxTpr_Attributename, "CustomerId") == 0 )
               {
                  AV7Insert_CustomerId = (short)(NumberUtil.Val( AV11TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV7Insert_CustomerId", StringUtil.LTrimStr( (decimal)(AV7Insert_CustomerId), 4, 0));
               }
               AV15GXV1 = (int)(AV15GXV1+1);
               AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            bttBtn_enter_Caption = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Caption", bttBtn_enter_Caption, true);
            bttBtn_enter_Tooltiptext = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Tooltiptext", bttBtn_enter_Tooltiptext, true);
         }
      }

      protected void E12052( )
      {
         /* After Trn Routine */
         returnInSub = false;
         context.PopUp(formatLink("shoppingcartdetail.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A11ShoppingCartId,4,0))}, new string[] {"ShoppingCartId"}) , new Object[] {"A11ShoppingCartId"});
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV10TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwshoppingcart.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void ZM058( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z28ShoppingCartDate = T00057_A28ShoppingCartDate[0];
               Z6CustomerId = T00057_A6CustomerId[0];
            }
            else
            {
               Z28ShoppingCartDate = A28ShoppingCartDate;
               Z6CustomerId = A6CustomerId;
            }
         }
         if ( GX_JID == -14 )
         {
            Z11ShoppingCartId = A11ShoppingCartId;
            Z28ShoppingCartDate = A28ShoppingCartDate;
            Z6CustomerId = A6CustomerId;
            Z29ShoppingCartFinalPrice = A29ShoppingCartFinalPrice;
            Z15CustomerName = A15CustomerName;
            Z16CustomerAddress = A16CustomerAddress;
            Z18CustomerPhone = A18CustomerPhone;
            Z3CountryId = A3CountryId;
            Z4CountryName = A4CountryName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtShoppingCartId_Enabled = 0;
         AssignProp("", false, edtShoppingCartId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtShoppingCartId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_6_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CUSTOMERID"+"'), id:'"+"CUSTOMERID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtShoppingCartId_Enabled = 0;
         AssignProp("", false, edtShoppingCartId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtShoppingCartId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV9ShoppingCartId) )
         {
            A11ShoppingCartId = AV9ShoppingCartId;
            AssignAttri("", false, "A11ShoppingCartId", StringUtil.LTrimStr( (decimal)(A11ShoppingCartId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV7Insert_CustomerId) )
         {
            edtCustomerId_Enabled = 0;
            AssignProp("", false, edtCustomerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerId_Enabled), 5, 0), true);
         }
         else
         {
            edtCustomerId_Enabled = 1;
            AssignProp("", false, edtCustomerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV7Insert_CustomerId) )
         {
            A6CustomerId = AV7Insert_CustomerId;
            AssignAttri("", false, "A6CustomerId", StringUtil.LTrimStr( (decimal)(A6CustomerId), 4, 0));
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
         if ( IsIns( )  && (DateTime.MinValue==A28ShoppingCartDate) && ( Gx_BScreen == 0 ) )
         {
            A28ShoppingCartDate = DateTimeUtil.Today( context);
            AssignAttri("", false, "A28ShoppingCartDate", context.localUtil.Format(A28ShoppingCartDate, "99/99/99"));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000511 */
            pr_default.execute(8, new Object[] {A11ShoppingCartId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               A29ShoppingCartFinalPrice = T000511_A29ShoppingCartFinalPrice[0];
               n29ShoppingCartFinalPrice = T000511_n29ShoppingCartFinalPrice[0];
               AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
            }
            else
            {
               A29ShoppingCartFinalPrice = 0;
               n29ShoppingCartFinalPrice = false;
               AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
            }
            O29ShoppingCartFinalPrice = A29ShoppingCartFinalPrice;
            n29ShoppingCartFinalPrice = false;
            AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
            pr_default.close(8);
            AV14Pgmname = "ShoppingCart";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
            /* Using cursor T00058 */
            pr_default.execute(6, new Object[] {A6CustomerId});
            A15CustomerName = T00058_A15CustomerName[0];
            AssignAttri("", false, "A15CustomerName", A15CustomerName);
            A16CustomerAddress = T00058_A16CustomerAddress[0];
            AssignAttri("", false, "A16CustomerAddress", A16CustomerAddress);
            A18CustomerPhone = T00058_A18CustomerPhone[0];
            AssignAttri("", false, "A18CustomerPhone", A18CustomerPhone);
            A3CountryId = T00058_A3CountryId[0];
            AssignAttri("", false, "A3CountryId", StringUtil.LTrimStr( (decimal)(A3CountryId), 4, 0));
            pr_default.close(6);
            /* Using cursor T00059 */
            pr_default.execute(7, new Object[] {A3CountryId});
            A4CountryName = T00059_A4CountryName[0];
            AssignAttri("", false, "A4CountryName", A4CountryName);
            pr_default.close(7);
            A32ShoppingCartDateDelivery = DateTimeUtil.DAdd(A28ShoppingCartDate,+((int)(5)));
            AssignAttri("", false, "A32ShoppingCartDateDelivery", context.localUtil.Format(A32ShoppingCartDateDelivery, "99/99/99"));
         }
      }

      protected void Load058( )
      {
         /* Using cursor T000513 */
         pr_default.execute(9, new Object[] {A11ShoppingCartId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound8 = 1;
            A28ShoppingCartDate = T000513_A28ShoppingCartDate[0];
            AssignAttri("", false, "A28ShoppingCartDate", context.localUtil.Format(A28ShoppingCartDate, "99/99/99"));
            A15CustomerName = T000513_A15CustomerName[0];
            AssignAttri("", false, "A15CustomerName", A15CustomerName);
            A4CountryName = T000513_A4CountryName[0];
            AssignAttri("", false, "A4CountryName", A4CountryName);
            A16CustomerAddress = T000513_A16CustomerAddress[0];
            AssignAttri("", false, "A16CustomerAddress", A16CustomerAddress);
            A18CustomerPhone = T000513_A18CustomerPhone[0];
            AssignAttri("", false, "A18CustomerPhone", A18CustomerPhone);
            A6CustomerId = T000513_A6CustomerId[0];
            AssignAttri("", false, "A6CustomerId", StringUtil.LTrimStr( (decimal)(A6CustomerId), 4, 0));
            A3CountryId = T000513_A3CountryId[0];
            AssignAttri("", false, "A3CountryId", StringUtil.LTrimStr( (decimal)(A3CountryId), 4, 0));
            A29ShoppingCartFinalPrice = T000513_A29ShoppingCartFinalPrice[0];
            n29ShoppingCartFinalPrice = T000513_n29ShoppingCartFinalPrice[0];
            AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
            ZM058( -14) ;
         }
         pr_default.close(9);
         OnLoadActions058( ) ;
      }

      protected void OnLoadActions058( )
      {
         O29ShoppingCartFinalPrice = A29ShoppingCartFinalPrice;
         n29ShoppingCartFinalPrice = false;
         AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
         AV14Pgmname = "ShoppingCart";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         A32ShoppingCartDateDelivery = DateTimeUtil.DAdd(A28ShoppingCartDate,+((int)(5)));
         AssignAttri("", false, "A32ShoppingCartDateDelivery", context.localUtil.Format(A32ShoppingCartDateDelivery, "99/99/99"));
      }

      protected void CheckExtendedTable058( )
      {
         nIsDirty_8 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV14Pgmname = "ShoppingCart";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         /* Using cursor T000511 */
         pr_default.execute(8, new Object[] {A11ShoppingCartId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A29ShoppingCartFinalPrice = T000511_A29ShoppingCartFinalPrice[0];
            n29ShoppingCartFinalPrice = T000511_n29ShoppingCartFinalPrice[0];
            AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
         }
         else
         {
            nIsDirty_8 = 1;
            A29ShoppingCartFinalPrice = 0;
            n29ShoppingCartFinalPrice = false;
            AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
         }
         pr_default.close(8);
         if ( ! ( (DateTime.MinValue==A28ShoppingCartDate) || ( DateTimeUtil.ResetTime ( A28ShoppingCartDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Shopping Cart Date is out of range", "OutOfRange", 1, "SHOPPINGCARTDATE");
            AnyError = 1;
            GX_FocusControl = edtShoppingCartDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         nIsDirty_8 = 1;
         A32ShoppingCartDateDelivery = DateTimeUtil.DAdd(A28ShoppingCartDate,+((int)(5)));
         AssignAttri("", false, "A32ShoppingCartDateDelivery", context.localUtil.Format(A32ShoppingCartDateDelivery, "99/99/99"));
         /* Using cursor T00058 */
         pr_default.execute(6, new Object[] {A6CustomerId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No matching 'Customer'.", "ForeignKeyNotFound", 1, "CUSTOMERID");
            AnyError = 1;
            GX_FocusControl = edtCustomerId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A15CustomerName = T00058_A15CustomerName[0];
         AssignAttri("", false, "A15CustomerName", A15CustomerName);
         A16CustomerAddress = T00058_A16CustomerAddress[0];
         AssignAttri("", false, "A16CustomerAddress", A16CustomerAddress);
         A18CustomerPhone = T00058_A18CustomerPhone[0];
         AssignAttri("", false, "A18CustomerPhone", A18CustomerPhone);
         A3CountryId = T00058_A3CountryId[0];
         AssignAttri("", false, "A3CountryId", StringUtil.LTrimStr( (decimal)(A3CountryId), 4, 0));
         pr_default.close(6);
         /* Using cursor T00059 */
         pr_default.execute(7, new Object[] {A3CountryId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No matching 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
         }
         A4CountryName = T00059_A4CountryName[0];
         AssignAttri("", false, "A4CountryName", A4CountryName);
         pr_default.close(7);
      }

      protected void CloseExtendedTableCursors058( )
      {
         pr_default.close(8);
         pr_default.close(6);
         pr_default.close(7);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_17( short A11ShoppingCartId )
      {
         /* Using cursor T000515 */
         pr_default.execute(10, new Object[] {A11ShoppingCartId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A29ShoppingCartFinalPrice = T000515_A29ShoppingCartFinalPrice[0];
            n29ShoppingCartFinalPrice = T000515_n29ShoppingCartFinalPrice[0];
            AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
         }
         else
         {
            A29ShoppingCartFinalPrice = 0;
            n29ShoppingCartFinalPrice = false;
            AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A29ShoppingCartFinalPrice, 10, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_15( short A6CustomerId )
      {
         /* Using cursor T000516 */
         pr_default.execute(11, new Object[] {A6CustomerId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No matching 'Customer'.", "ForeignKeyNotFound", 1, "CUSTOMERID");
            AnyError = 1;
            GX_FocusControl = edtCustomerId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A15CustomerName = T000516_A15CustomerName[0];
         AssignAttri("", false, "A15CustomerName", A15CustomerName);
         A16CustomerAddress = T000516_A16CustomerAddress[0];
         AssignAttri("", false, "A16CustomerAddress", A16CustomerAddress);
         A18CustomerPhone = T000516_A18CustomerPhone[0];
         AssignAttri("", false, "A18CustomerPhone", A18CustomerPhone);
         A3CountryId = T000516_A3CountryId[0];
         AssignAttri("", false, "A3CountryId", StringUtil.LTrimStr( (decimal)(A3CountryId), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A15CustomerName))+"\""+","+"\""+GXUtil.EncodeJSConstant( A16CustomerAddress)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A18CustomerPhone))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A3CountryId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_16( short A3CountryId )
      {
         /* Using cursor T000517 */
         pr_default.execute(12, new Object[] {A3CountryId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No matching 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
         }
         A4CountryName = T000517_A4CountryName[0];
         AssignAttri("", false, "A4CountryName", A4CountryName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A4CountryName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void GetKey058( )
      {
         /* Using cursor T000518 */
         pr_default.execute(13, new Object[] {A11ShoppingCartId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00057 */
         pr_default.execute(5, new Object[] {A11ShoppingCartId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM058( 14) ;
            RcdFound8 = 1;
            A11ShoppingCartId = T00057_A11ShoppingCartId[0];
            AssignAttri("", false, "A11ShoppingCartId", StringUtil.LTrimStr( (decimal)(A11ShoppingCartId), 4, 0));
            A28ShoppingCartDate = T00057_A28ShoppingCartDate[0];
            AssignAttri("", false, "A28ShoppingCartDate", context.localUtil.Format(A28ShoppingCartDate, "99/99/99"));
            A6CustomerId = T00057_A6CustomerId[0];
            AssignAttri("", false, "A6CustomerId", StringUtil.LTrimStr( (decimal)(A6CustomerId), 4, 0));
            Z11ShoppingCartId = A11ShoppingCartId;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load058( ) ;
            if ( AnyError == 1 )
            {
               RcdFound8 = 0;
               InitializeNonKey058( ) ;
            }
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey058( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey058( ) ;
         if ( RcdFound8 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound8 = 0;
         /* Using cursor T000519 */
         pr_default.execute(14, new Object[] {A11ShoppingCartId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( T000519_A11ShoppingCartId[0] < A11ShoppingCartId ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( T000519_A11ShoppingCartId[0] > A11ShoppingCartId ) ) )
            {
               A11ShoppingCartId = T000519_A11ShoppingCartId[0];
               AssignAttri("", false, "A11ShoppingCartId", StringUtil.LTrimStr( (decimal)(A11ShoppingCartId), 4, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void move_previous( )
      {
         RcdFound8 = 0;
         /* Using cursor T000520 */
         pr_default.execute(15, new Object[] {A11ShoppingCartId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            while ( (pr_default.getStatus(15) != 101) && ( ( T000520_A11ShoppingCartId[0] > A11ShoppingCartId ) ) )
            {
               pr_default.readNext(15);
            }
            if ( (pr_default.getStatus(15) != 101) && ( ( T000520_A11ShoppingCartId[0] < A11ShoppingCartId ) ) )
            {
               A11ShoppingCartId = T000520_A11ShoppingCartId[0];
               AssignAttri("", false, "A11ShoppingCartId", StringUtil.LTrimStr( (decimal)(A11ShoppingCartId), 4, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(15);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey058( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A29ShoppingCartFinalPrice = O29ShoppingCartFinalPrice;
            n29ShoppingCartFinalPrice = false;
            AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
            GX_FocusControl = edtShoppingCartDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert058( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound8 == 1 )
            {
               if ( A11ShoppingCartId != Z11ShoppingCartId )
               {
                  A11ShoppingCartId = Z11ShoppingCartId;
                  AssignAttri("", false, "A11ShoppingCartId", StringUtil.LTrimStr( (decimal)(A11ShoppingCartId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SHOPPINGCARTID");
                  AnyError = 1;
                  GX_FocusControl = edtShoppingCartId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A29ShoppingCartFinalPrice = O29ShoppingCartFinalPrice;
                  n29ShoppingCartFinalPrice = false;
                  AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtShoppingCartDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A29ShoppingCartFinalPrice = O29ShoppingCartFinalPrice;
                  n29ShoppingCartFinalPrice = false;
                  AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
                  Update058( ) ;
                  GX_FocusControl = edtShoppingCartDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A11ShoppingCartId != Z11ShoppingCartId )
               {
                  /* Insert record */
                  A29ShoppingCartFinalPrice = O29ShoppingCartFinalPrice;
                  n29ShoppingCartFinalPrice = false;
                  AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
                  GX_FocusControl = edtShoppingCartDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert058( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SHOPPINGCARTID");
                     AnyError = 1;
                     GX_FocusControl = edtShoppingCartId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A29ShoppingCartFinalPrice = O29ShoppingCartFinalPrice;
                     n29ShoppingCartFinalPrice = false;
                     AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
                     GX_FocusControl = edtShoppingCartDate_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert058( ) ;
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
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A11ShoppingCartId != Z11ShoppingCartId )
         {
            A11ShoppingCartId = Z11ShoppingCartId;
            AssignAttri("", false, "A11ShoppingCartId", StringUtil.LTrimStr( (decimal)(A11ShoppingCartId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SHOPPINGCARTID");
            AnyError = 1;
            GX_FocusControl = edtShoppingCartId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A29ShoppingCartFinalPrice = O29ShoppingCartFinalPrice;
            n29ShoppingCartFinalPrice = false;
            AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtShoppingCartDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency058( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00056 */
            pr_default.execute(4, new Object[] {A11ShoppingCartId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ShoppingCart"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) || ( DateTimeUtil.ResetTime ( Z28ShoppingCartDate ) != DateTimeUtil.ResetTime ( T00056_A28ShoppingCartDate[0] ) ) || ( Z6CustomerId != T00056_A6CustomerId[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z28ShoppingCartDate ) != DateTimeUtil.ResetTime ( T00056_A28ShoppingCartDate[0] ) )
               {
                  GXUtil.WriteLog("shoppingcart:[seudo value changed for attri]"+"ShoppingCartDate");
                  GXUtil.WriteLogRaw("Old: ",Z28ShoppingCartDate);
                  GXUtil.WriteLogRaw("Current: ",T00056_A28ShoppingCartDate[0]);
               }
               if ( Z6CustomerId != T00056_A6CustomerId[0] )
               {
                  GXUtil.WriteLog("shoppingcart:[seudo value changed for attri]"+"CustomerId");
                  GXUtil.WriteLogRaw("Old: ",Z6CustomerId);
                  GXUtil.WriteLogRaw("Current: ",T00056_A6CustomerId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ShoppingCart"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert058( )
      {
         BeforeValidate058( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable058( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM058( 0) ;
            CheckOptimisticConcurrency058( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm058( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert058( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000521 */
                     pr_default.execute(16, new Object[] {A28ShoppingCartDate, A6CustomerId});
                     A11ShoppingCartId = T000521_A11ShoppingCartId[0];
                     AssignAttri("", false, "A11ShoppingCartId", StringUtil.LTrimStr( (decimal)(A11ShoppingCartId), 4, 0));
                     pr_default.close(16);
                     dsDefault.SmartCacheProvider.SetUpdated("ShoppingCart");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel058( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption050( ) ;
                           }
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
               Load058( ) ;
            }
            EndLevel058( ) ;
         }
         CloseExtendedTableCursors058( ) ;
      }

      protected void Update058( )
      {
         BeforeValidate058( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable058( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency058( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm058( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate058( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000522 */
                     pr_default.execute(17, new Object[] {A28ShoppingCartDate, A6CustomerId, A11ShoppingCartId});
                     pr_default.close(17);
                     dsDefault.SmartCacheProvider.SetUpdated("ShoppingCart");
                     if ( (pr_default.getStatus(17) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ShoppingCart"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate058( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel058( ) ;
                           if ( AnyError == 0 )
                           {
                              if ( IsUpd( ) || IsDlt( ) )
                              {
                                 if ( AnyError == 0 )
                                 {
                                    context.nUserReturn = 1;
                                 }
                              }
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
            }
            EndLevel058( ) ;
         }
         CloseExtendedTableCursors058( ) ;
      }

      protected void DeferredUpdate058( )
      {
      }

      protected void delete( )
      {
         BeforeValidate058( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency058( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls058( ) ;
            AfterConfirm058( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete058( ) ;
               if ( AnyError == 0 )
               {
                  A29ShoppingCartFinalPrice = O29ShoppingCartFinalPrice;
                  n29ShoppingCartFinalPrice = false;
                  AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
                  ScanStart059( ) ;
                  while ( RcdFound9 != 0 )
                  {
                     getByPrimaryKey059( ) ;
                     Delete059( ) ;
                     ScanNext059( ) ;
                     O29ShoppingCartFinalPrice = A29ShoppingCartFinalPrice;
                     n29ShoppingCartFinalPrice = false;
                     AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
                  }
                  ScanEnd059( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000523 */
                     pr_default.execute(18, new Object[] {A11ShoppingCartId});
                     pr_default.close(18);
                     dsDefault.SmartCacheProvider.SetUpdated("ShoppingCart");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
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
            }
         }
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel058( ) ;
         Gx_mode = sMode8;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls058( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV14Pgmname = "ShoppingCart";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
            /* Using cursor T000525 */
            pr_default.execute(19, new Object[] {A11ShoppingCartId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               A29ShoppingCartFinalPrice = T000525_A29ShoppingCartFinalPrice[0];
               n29ShoppingCartFinalPrice = T000525_n29ShoppingCartFinalPrice[0];
               AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
            }
            else
            {
               A29ShoppingCartFinalPrice = 0;
               n29ShoppingCartFinalPrice = false;
               AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
            }
            pr_default.close(19);
            A32ShoppingCartDateDelivery = DateTimeUtil.DAdd(A28ShoppingCartDate,+((int)(5)));
            AssignAttri("", false, "A32ShoppingCartDateDelivery", context.localUtil.Format(A32ShoppingCartDateDelivery, "99/99/99"));
            /* Using cursor T000526 */
            pr_default.execute(20, new Object[] {A6CustomerId});
            A15CustomerName = T000526_A15CustomerName[0];
            AssignAttri("", false, "A15CustomerName", A15CustomerName);
            A16CustomerAddress = T000526_A16CustomerAddress[0];
            AssignAttri("", false, "A16CustomerAddress", A16CustomerAddress);
            A18CustomerPhone = T000526_A18CustomerPhone[0];
            AssignAttri("", false, "A18CustomerPhone", A18CustomerPhone);
            A3CountryId = T000526_A3CountryId[0];
            AssignAttri("", false, "A3CountryId", StringUtil.LTrimStr( (decimal)(A3CountryId), 4, 0));
            pr_default.close(20);
            /* Using cursor T000527 */
            pr_default.execute(21, new Object[] {A3CountryId});
            A4CountryName = T000527_A4CountryName[0];
            AssignAttri("", false, "A4CountryName", A4CountryName);
            pr_default.close(21);
         }
      }

      protected void ProcessNestedLevel059( )
      {
         s29ShoppingCartFinalPrice = O29ShoppingCartFinalPrice;
         n29ShoppingCartFinalPrice = false;
         AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
         nGXsfl_83_idx = 0;
         while ( nGXsfl_83_idx < nRC_GXsfl_83 )
         {
            ReadRow059( ) ;
            if ( ( nRcdExists_9 != 0 ) || ( nIsMod_9 != 0 ) )
            {
               standaloneNotModal059( ) ;
               GetKey059( ) ;
               if ( ( nRcdExists_9 == 0 ) && ( nRcdDeleted_9 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert059( ) ;
               }
               else
               {
                  if ( RcdFound9 != 0 )
                  {
                     if ( ( nRcdDeleted_9 != 0 ) && ( nRcdExists_9 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete059( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_9 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update059( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_9 == 0 )
                     {
                        GXCCtl = "PRODUCTID_" + sGXsfl_83_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProductId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O29ShoppingCartFinalPrice = A29ShoppingCartFinalPrice;
               n29ShoppingCartFinalPrice = false;
               AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
            }
            ChangePostValue( edtProductId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A7ProductId), 4, 0, ".", ""))) ;
            ChangePostValue( edtProductName_Internalname, StringUtil.RTrim( A8ProductName)) ;
            ChangePostValue( edtProductPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A22ProductPrice, 12, 2, ".", ""))) ;
            ChangePostValue( edtQtyProduct_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A31QtyProduct), 4, 0, ".", ""))) ;
            ChangePostValue( edtTotalProduct_Internalname, StringUtil.LTrim( StringUtil.NToC( A30TotalProduct, 12, 2, ".", ""))) ;
            ChangePostValue( edtCategoryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CategoryId), 4, 0, ".", ""))) ;
            ChangePostValue( edtCategoryName_Internalname, StringUtil.RTrim( A2CategoryName)) ;
            ChangePostValue( "ZT_"+"Z7ProductId_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7ProductId), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z31QtyProduct_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z31QtyProduct), 4, 0, ".", ""))) ;
            ChangePostValue( "T30TotalProduct_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( O30TotalProduct, 10, 2, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_9_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_9), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_9_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_9), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_9_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_9), 4, 0, ".", ""))) ;
            if ( nIsMod_9 != 0 )
            {
               ChangePostValue( "PRODUCTID_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTNAME_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTPRICE_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductPrice_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "QTYPRODUCT_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtQtyProduct_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "TOTALPRODUCT_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTotalProduct_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CATEGORYID_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoryId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CATEGORYNAME_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoryName_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll059( ) ;
         if ( AnyError != 0 )
         {
            O29ShoppingCartFinalPrice = s29ShoppingCartFinalPrice;
            n29ShoppingCartFinalPrice = false;
            AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
         }
         nRcdExists_9 = 0;
         nIsMod_9 = 0;
         nRcdDeleted_9 = 0;
      }

      protected void ProcessLevel058( )
      {
         /* Save parent mode. */
         sMode8 = Gx_mode;
         ProcessNestedLevel059( ) ;
         if ( AnyError != 0 )
         {
            O29ShoppingCartFinalPrice = s29ShoppingCartFinalPrice;
            n29ShoppingCartFinalPrice = false;
            AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
         }
         /* Restore parent mode. */
         Gx_mode = sMode8;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel058( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete058( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(19);
            pr_default.close(2);
            pr_default.close(3);
            context.CommitDataStores("shoppingcart",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues050( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(19);
            pr_default.close(2);
            pr_default.close(3);
            context.RollbackDataStores("shoppingcart",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart058( )
      {
         /* Scan By routine */
         /* Using cursor T000528 */
         pr_default.execute(22);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound8 = 1;
            A11ShoppingCartId = T000528_A11ShoppingCartId[0];
            AssignAttri("", false, "A11ShoppingCartId", StringUtil.LTrimStr( (decimal)(A11ShoppingCartId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext058( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound8 = 1;
            A11ShoppingCartId = T000528_A11ShoppingCartId[0];
            AssignAttri("", false, "A11ShoppingCartId", StringUtil.LTrimStr( (decimal)(A11ShoppingCartId), 4, 0));
         }
      }

      protected void ScanEnd058( )
      {
         pr_default.close(22);
      }

      protected void AfterConfirm058( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert058( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate058( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete058( )
      {
         /* Before Delete Rules */
         if ( DateTimeUtil.ResetTime ( A28ShoppingCartDate ) == DateTimeUtil.ResetTime ( DateTimeUtil.Today( context) ) )
         {
            GX_msglist.addItem("You cannot delete today's cart", 1, "SHOPPINGCARTDATE");
            AnyError = 1;
            GX_FocusControl = edtShoppingCartDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void BeforeComplete058( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate058( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes058( )
      {
         edtShoppingCartId_Enabled = 0;
         AssignProp("", false, edtShoppingCartId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtShoppingCartId_Enabled), 5, 0), true);
         edtShoppingCartDate_Enabled = 0;
         AssignProp("", false, edtShoppingCartDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtShoppingCartDate_Enabled), 5, 0), true);
         edtShoppingCartDateDelivery_Enabled = 0;
         AssignProp("", false, edtShoppingCartDateDelivery_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtShoppingCartDateDelivery_Enabled), 5, 0), true);
         edtCustomerId_Enabled = 0;
         AssignProp("", false, edtCustomerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerId_Enabled), 5, 0), true);
         edtCustomerName_Enabled = 0;
         AssignProp("", false, edtCustomerName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerName_Enabled), 5, 0), true);
         edtCountryId_Enabled = 0;
         AssignProp("", false, edtCountryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryId_Enabled), 5, 0), true);
         edtCountryName_Enabled = 0;
         AssignProp("", false, edtCountryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryName_Enabled), 5, 0), true);
         edtCustomerAddress_Enabled = 0;
         AssignProp("", false, edtCustomerAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerAddress_Enabled), 5, 0), true);
         edtCustomerPhone_Enabled = 0;
         AssignProp("", false, edtCustomerPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerPhone_Enabled), 5, 0), true);
         edtShoppingCartFinalPrice_Enabled = 0;
         AssignProp("", false, edtShoppingCartFinalPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtShoppingCartFinalPrice_Enabled), 5, 0), true);
      }

      protected void ZM059( short GX_JID )
      {
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z31QtyProduct = T00053_A31QtyProduct[0];
            }
            else
            {
               Z31QtyProduct = A31QtyProduct;
            }
         }
         if ( GX_JID == -18 )
         {
            Z11ShoppingCartId = A11ShoppingCartId;
            Z31QtyProduct = A31QtyProduct;
            Z7ProductId = A7ProductId;
            Z8ProductName = A8ProductName;
            Z22ProductPrice = A22ProductPrice;
            Z1CategoryId = A1CategoryId;
            Z2CategoryName = A2CategoryName;
         }
      }

      protected void standaloneNotModal059( )
      {
      }

      protected void standaloneModal059( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtProductId_Enabled = 0;
            AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         }
         else
         {
            edtProductId_Enabled = 1;
            AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         }
      }

      protected void Load059( )
      {
         /* Using cursor T000529 */
         pr_default.execute(23, new Object[] {A11ShoppingCartId, A7ProductId});
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound9 = 1;
            A8ProductName = T000529_A8ProductName[0];
            A22ProductPrice = T000529_A22ProductPrice[0];
            A31QtyProduct = T000529_A31QtyProduct[0];
            A2CategoryName = T000529_A2CategoryName[0];
            A1CategoryId = T000529_A1CategoryId[0];
            ZM059( -18) ;
         }
         pr_default.close(23);
         OnLoadActions059( ) ;
      }

      protected void OnLoadActions059( )
      {
         if ( StringUtil.StrCmp(A2CategoryName, "Joyería") == 0 )
         {
            A30TotalProduct = (decimal)(A31QtyProduct*A22ProductPrice*(1+5/ (decimal)(100)));
         }
         else
         {
            if ( StringUtil.StrCmp(A2CategoryName, "Entretenimiento") == 0 )
            {
               A30TotalProduct = (decimal)(A31QtyProduct*A22ProductPrice*(1-10/ (decimal)(100)));
            }
            else
            {
               A30TotalProduct = (decimal)(A31QtyProduct*A22ProductPrice);
            }
         }
         O30TotalProduct = A30TotalProduct;
         if ( IsIns( )  )
         {
            A29ShoppingCartFinalPrice = (decimal)(O29ShoppingCartFinalPrice+A30TotalProduct);
            n29ShoppingCartFinalPrice = false;
            AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
         }
         else
         {
            if ( IsUpd( )  )
            {
               A29ShoppingCartFinalPrice = (decimal)(O29ShoppingCartFinalPrice+A30TotalProduct-O30TotalProduct);
               n29ShoppingCartFinalPrice = false;
               AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A29ShoppingCartFinalPrice = (decimal)(O29ShoppingCartFinalPrice-O30TotalProduct);
                  n29ShoppingCartFinalPrice = false;
                  AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
               }
            }
         }
      }

      protected void CheckExtendedTable059( )
      {
         nIsDirty_9 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal059( ) ;
         /* Using cursor T00054 */
         pr_default.execute(2, new Object[] {A7ProductId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_83_idx;
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A8ProductName = T00054_A8ProductName[0];
         A22ProductPrice = T00054_A22ProductPrice[0];
         A1CategoryId = T00054_A1CategoryId[0];
         pr_default.close(2);
         /* Using cursor T00055 */
         pr_default.execute(3, new Object[] {A1CategoryId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GXCCtl = "CATEGORYID_" + sGXsfl_83_idx;
            GX_msglist.addItem("No matching 'Category'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
         }
         A2CategoryName = T00055_A2CategoryName[0];
         pr_default.close(3);
         if ( StringUtil.StrCmp(A2CategoryName, "Joyería") == 0 )
         {
            nIsDirty_9 = 1;
            A30TotalProduct = (decimal)(A31QtyProduct*A22ProductPrice*(1+5/ (decimal)(100)));
         }
         else
         {
            if ( StringUtil.StrCmp(A2CategoryName, "Entretenimiento") == 0 )
            {
               nIsDirty_9 = 1;
               A30TotalProduct = (decimal)(A31QtyProduct*A22ProductPrice*(1-10/ (decimal)(100)));
            }
            else
            {
               nIsDirty_9 = 1;
               A30TotalProduct = (decimal)(A31QtyProduct*A22ProductPrice);
            }
         }
         if ( IsIns( )  )
         {
            nIsDirty_9 = 1;
            A29ShoppingCartFinalPrice = (decimal)(O29ShoppingCartFinalPrice+A30TotalProduct);
            n29ShoppingCartFinalPrice = false;
            AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
         }
         else
         {
            if ( IsUpd( )  )
            {
               nIsDirty_9 = 1;
               A29ShoppingCartFinalPrice = (decimal)(O29ShoppingCartFinalPrice+A30TotalProduct-O30TotalProduct);
               n29ShoppingCartFinalPrice = false;
               AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  nIsDirty_9 = 1;
                  A29ShoppingCartFinalPrice = (decimal)(O29ShoppingCartFinalPrice-O30TotalProduct);
                  n29ShoppingCartFinalPrice = false;
                  AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
               }
            }
         }
      }

      protected void CloseExtendedTableCursors059( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable059( )
      {
      }

      protected void gxLoad_19( short A7ProductId )
      {
         /* Using cursor T000530 */
         pr_default.execute(24, new Object[] {A7ProductId});
         if ( (pr_default.getStatus(24) == 101) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_83_idx;
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A8ProductName = T000530_A8ProductName[0];
         A22ProductPrice = T000530_A22ProductPrice[0];
         A1CategoryId = T000530_A1CategoryId[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A8ProductName))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A22ProductPrice, 10, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CategoryId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(24) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(24);
      }

      protected void gxLoad_20( short A1CategoryId )
      {
         /* Using cursor T000531 */
         pr_default.execute(25, new Object[] {A1CategoryId});
         if ( (pr_default.getStatus(25) == 101) )
         {
            GXCCtl = "CATEGORYID_" + sGXsfl_83_idx;
            GX_msglist.addItem("No matching 'Category'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
         }
         A2CategoryName = T000531_A2CategoryName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A2CategoryName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(25) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(25);
      }

      protected void GetKey059( )
      {
         /* Using cursor T000532 */
         pr_default.execute(26, new Object[] {A11ShoppingCartId, A7ProductId});
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(26);
      }

      protected void getByPrimaryKey059( )
      {
         /* Using cursor T00053 */
         pr_default.execute(1, new Object[] {A11ShoppingCartId, A7ProductId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM059( 18) ;
            RcdFound9 = 1;
            InitializeNonKey059( ) ;
            A31QtyProduct = T00053_A31QtyProduct[0];
            A7ProductId = T00053_A7ProductId[0];
            Z11ShoppingCartId = A11ShoppingCartId;
            Z7ProductId = A7ProductId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load059( ) ;
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey059( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal059( ) ;
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes059( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency059( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00052 */
            pr_default.execute(0, new Object[] {A11ShoppingCartId, A7ProductId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ShoppingCartProduct"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z31QtyProduct != T00052_A31QtyProduct[0] ) )
            {
               if ( Z31QtyProduct != T00052_A31QtyProduct[0] )
               {
                  GXUtil.WriteLog("shoppingcart:[seudo value changed for attri]"+"QtyProduct");
                  GXUtil.WriteLogRaw("Old: ",Z31QtyProduct);
                  GXUtil.WriteLogRaw("Current: ",T00052_A31QtyProduct[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ShoppingCartProduct"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert059( )
      {
         BeforeValidate059( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable059( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM059( 0) ;
            CheckOptimisticConcurrency059( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm059( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert059( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000533 */
                     pr_default.execute(27, new Object[] {A11ShoppingCartId, A31QtyProduct, A7ProductId});
                     pr_default.close(27);
                     dsDefault.SmartCacheProvider.SetUpdated("ShoppingCartProduct");
                     if ( (pr_default.getStatus(27) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
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
               Load059( ) ;
            }
            EndLevel059( ) ;
         }
         CloseExtendedTableCursors059( ) ;
      }

      protected void Update059( )
      {
         BeforeValidate059( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable059( ) ;
         }
         if ( ( nIsMod_9 != 0 ) || ( nIsDirty_9 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency059( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm059( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate059( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000534 */
                        pr_default.execute(28, new Object[] {A31QtyProduct, A11ShoppingCartId, A7ProductId});
                        pr_default.close(28);
                        dsDefault.SmartCacheProvider.SetUpdated("ShoppingCartProduct");
                        if ( (pr_default.getStatus(28) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ShoppingCartProduct"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate059( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey059( ) ;
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
               EndLevel059( ) ;
            }
         }
         CloseExtendedTableCursors059( ) ;
      }

      protected void DeferredUpdate059( )
      {
      }

      protected void Delete059( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate059( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency059( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls059( ) ;
            AfterConfirm059( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete059( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000535 */
                  pr_default.execute(29, new Object[] {A11ShoppingCartId, A7ProductId});
                  pr_default.close(29);
                  dsDefault.SmartCacheProvider.SetUpdated("ShoppingCartProduct");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel059( ) ;
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls059( )
      {
         standaloneModal059( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000536 */
            pr_default.execute(30, new Object[] {A7ProductId});
            A8ProductName = T000536_A8ProductName[0];
            A22ProductPrice = T000536_A22ProductPrice[0];
            A1CategoryId = T000536_A1CategoryId[0];
            pr_default.close(30);
            /* Using cursor T000537 */
            pr_default.execute(31, new Object[] {A1CategoryId});
            A2CategoryName = T000537_A2CategoryName[0];
            pr_default.close(31);
            if ( StringUtil.StrCmp(A2CategoryName, "Joyería") == 0 )
            {
               A30TotalProduct = (decimal)(A31QtyProduct*A22ProductPrice*(1+5/ (decimal)(100)));
            }
            else
            {
               if ( StringUtil.StrCmp(A2CategoryName, "Entretenimiento") == 0 )
               {
                  A30TotalProduct = (decimal)(A31QtyProduct*A22ProductPrice*(1-10/ (decimal)(100)));
               }
               else
               {
                  A30TotalProduct = (decimal)(A31QtyProduct*A22ProductPrice);
               }
            }
            if ( IsIns( )  )
            {
               A29ShoppingCartFinalPrice = (decimal)(O29ShoppingCartFinalPrice+A30TotalProduct);
               n29ShoppingCartFinalPrice = false;
               AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A29ShoppingCartFinalPrice = (decimal)(O29ShoppingCartFinalPrice+A30TotalProduct-O30TotalProduct);
                  n29ShoppingCartFinalPrice = false;
                  AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A29ShoppingCartFinalPrice = (decimal)(O29ShoppingCartFinalPrice-O30TotalProduct);
                     n29ShoppingCartFinalPrice = false;
                     AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
                  }
               }
            }
         }
      }

      protected void EndLevel059( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart059( )
      {
         /* Scan By routine */
         /* Using cursor T000538 */
         pr_default.execute(32, new Object[] {A11ShoppingCartId});
         RcdFound9 = 0;
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound9 = 1;
            A7ProductId = T000538_A7ProductId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext059( )
      {
         /* Scan next routine */
         pr_default.readNext(32);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound9 = 1;
            A7ProductId = T000538_A7ProductId[0];
         }
      }

      protected void ScanEnd059( )
      {
         pr_default.close(32);
      }

      protected void AfterConfirm059( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert059( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate059( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete059( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete059( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate059( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes059( )
      {
         edtProductId_Enabled = 0;
         AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtProductName_Enabled = 0;
         AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtProductPrice_Enabled = 0;
         AssignProp("", false, edtProductPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductPrice_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtQtyProduct_Enabled = 0;
         AssignProp("", false, edtQtyProduct_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtQtyProduct_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtTotalProduct_Enabled = 0;
         AssignProp("", false, edtTotalProduct_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotalProduct_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtCategoryId_Enabled = 0;
         AssignProp("", false, edtCategoryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtCategoryName_Enabled = 0;
         AssignProp("", false, edtCategoryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryName_Enabled), 5, 0), !bGXsfl_83_Refreshing);
      }

      protected void send_integrity_lvl_hashes059( )
      {
      }

      protected void send_integrity_lvl_hashes058( )
      {
      }

      protected void SubsflControlProps_839( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_83_idx;
         imgprompt_7_Internalname = "PROMPT_7_"+sGXsfl_83_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_83_idx;
         edtProductPrice_Internalname = "PRODUCTPRICE_"+sGXsfl_83_idx;
         edtQtyProduct_Internalname = "QTYPRODUCT_"+sGXsfl_83_idx;
         edtTotalProduct_Internalname = "TOTALPRODUCT_"+sGXsfl_83_idx;
         edtCategoryId_Internalname = "CATEGORYID_"+sGXsfl_83_idx;
         edtCategoryName_Internalname = "CATEGORYNAME_"+sGXsfl_83_idx;
      }

      protected void SubsflControlProps_fel_839( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_83_fel_idx;
         imgprompt_7_Internalname = "PROMPT_7_"+sGXsfl_83_fel_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_83_fel_idx;
         edtProductPrice_Internalname = "PRODUCTPRICE_"+sGXsfl_83_fel_idx;
         edtQtyProduct_Internalname = "QTYPRODUCT_"+sGXsfl_83_fel_idx;
         edtTotalProduct_Internalname = "TOTALPRODUCT_"+sGXsfl_83_fel_idx;
         edtCategoryId_Internalname = "CATEGORYID_"+sGXsfl_83_fel_idx;
         edtCategoryName_Internalname = "CATEGORYNAME_"+sGXsfl_83_fel_idx;
      }

      protected void AddRow059( )
      {
         nGXsfl_83_idx = (int)(nGXsfl_83_idx+1);
         sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
         SubsflControlProps_839( ) ;
         SendRow059( ) ;
      }

      protected void SendRow059( )
      {
         Gridshoppingcart_productRow = GXWebRow.GetNew(context);
         if ( subGridshoppingcart_product_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridshoppingcart_product_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridshoppingcart_product_Class, "") != 0 )
            {
               subGridshoppingcart_product_Linesclass = subGridshoppingcart_product_Class+"Odd";
            }
         }
         else if ( subGridshoppingcart_product_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridshoppingcart_product_Backstyle = 0;
            subGridshoppingcart_product_Backcolor = subGridshoppingcart_product_Allbackcolor;
            if ( StringUtil.StrCmp(subGridshoppingcart_product_Class, "") != 0 )
            {
               subGridshoppingcart_product_Linesclass = subGridshoppingcart_product_Class+"Uniform";
            }
         }
         else if ( subGridshoppingcart_product_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridshoppingcart_product_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridshoppingcart_product_Class, "") != 0 )
            {
               subGridshoppingcart_product_Linesclass = subGridshoppingcart_product_Class+"Odd";
            }
            subGridshoppingcart_product_Backcolor = (int)(0x0);
         }
         else if ( subGridshoppingcart_product_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridshoppingcart_product_Backstyle = 1;
            if ( ((int)((nGXsfl_83_idx) % (2))) == 0 )
            {
               subGridshoppingcart_product_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridshoppingcart_product_Class, "") != 0 )
               {
                  subGridshoppingcart_product_Linesclass = subGridshoppingcart_product_Class+"Even";
               }
            }
            else
            {
               subGridshoppingcart_product_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridshoppingcart_product_Class, "") != 0 )
               {
                  subGridshoppingcart_product_Linesclass = subGridshoppingcart_product_Class+"Odd";
               }
            }
         }
         imgprompt_7_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0050.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRODUCTID_"+sGXsfl_83_idx+"'), id:'"+"PRODUCTID_"+sGXsfl_83_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_9_"+sGXsfl_83_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_9_" + sGXsfl_83_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_83_idx + "',83)\"";
         ROClassString = "Attribute";
         Gridshoppingcart_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A7ProductId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A7ProductId), "ZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,84);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)83,(short)1,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         Gridshoppingcart_productRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_7_Internalname,(string)sImgUrl,(string)imgprompt_7_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_7_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridshoppingcart_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductName_Internalname,StringUtil.RTrim( A8ProductName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)83,(short)1,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridshoppingcart_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A22ProductPrice, 12, 2, ".", "")),StringUtil.LTrim( ((edtProductPrice_Enabled!=0) ? context.localUtil.Format( A22ProductPrice, "$ ZZZZZZ9.99") : context.localUtil.Format( A22ProductPrice, "$ ZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductPrice_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)83,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_9_" + sGXsfl_83_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_83_idx + "',83)\"";
         ROClassString = "Attribute";
         Gridshoppingcart_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtQtyProduct_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A31QtyProduct), 4, 0, ".", "")),StringUtil.LTrim( ((edtQtyProduct_Enabled!=0) ? context.localUtil.Format( (decimal)(A31QtyProduct), "ZZZ9") : context.localUtil.Format( (decimal)(A31QtyProduct), "ZZZ9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,87);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtQtyProduct_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtQtyProduct_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)83,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridshoppingcart_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTotalProduct_Internalname,StringUtil.LTrim( StringUtil.NToC( A30TotalProduct, 12, 2, ".", "")),StringUtil.LTrim( ((edtTotalProduct_Enabled!=0) ? context.localUtil.Format( A30TotalProduct, "$ ZZZZZZ9.99") : context.localUtil.Format( A30TotalProduct, "$ ZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTotalProduct_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtTotalProduct_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)83,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridshoppingcart_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCategoryId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CategoryId), 4, 0, ".", "")),StringUtil.LTrim( ((edtCategoryId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1CategoryId), "ZZZ9") : context.localUtil.Format( (decimal)(A1CategoryId), "ZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCategoryId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCategoryId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)83,(short)1,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridshoppingcart_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCategoryName_Internalname,StringUtil.RTrim( A2CategoryName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCategoryName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCategoryName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)83,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridshoppingcart_productRow);
         send_integrity_lvl_hashes059( ) ;
         GXCCtl = "Z7ProductId_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7ProductId), 4, 0, ".", "")));
         GXCCtl = "Z31QtyProduct_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z31QtyProduct), 4, 0, ".", "")));
         GXCCtl = "O30TotalProduct_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( O30TotalProduct, 10, 2, ".", "")));
         GXCCtl = "nRcdDeleted_9_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_9), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_9_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_9), 4, 0, ".", "")));
         GXCCtl = "nIsMod_9_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_9), 4, 0, ".", "")));
         GXCCtl = "vMODE_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_83_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV10TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV10TrnContext);
         }
         GXCCtl = "vSHOPPINGCARTID_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9ShoppingCartId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTID_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTNAME_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTPRICE_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductPrice_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "QTYPRODUCT_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtQtyProduct_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TOTALPRODUCT_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTotalProduct_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CATEGORYID_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoryId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CATEGORYNAME_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoryName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_7_"+sGXsfl_83_idx+"Link", StringUtil.RTrim( imgprompt_7_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridshoppingcart_productContainer.AddRow(Gridshoppingcart_productRow);
      }

      protected void ReadRow059( )
      {
         nGXsfl_83_idx = (int)(nGXsfl_83_idx+1);
         sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
         SubsflControlProps_839( ) ;
         edtProductId_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTID_"+sGXsfl_83_idx+"Enabled"), ".", ","));
         edtProductName_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTNAME_"+sGXsfl_83_idx+"Enabled"), ".", ","));
         edtProductPrice_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTPRICE_"+sGXsfl_83_idx+"Enabled"), ".", ","));
         edtQtyProduct_Enabled = (int)(context.localUtil.CToN( cgiGet( "QTYPRODUCT_"+sGXsfl_83_idx+"Enabled"), ".", ","));
         edtTotalProduct_Enabled = (int)(context.localUtil.CToN( cgiGet( "TOTALPRODUCT_"+sGXsfl_83_idx+"Enabled"), ".", ","));
         edtCategoryId_Enabled = (int)(context.localUtil.CToN( cgiGet( "CATEGORYID_"+sGXsfl_83_idx+"Enabled"), ".", ","));
         edtCategoryName_Enabled = (int)(context.localUtil.CToN( cgiGet( "CATEGORYNAME_"+sGXsfl_83_idx+"Enabled"), ".", ","));
         imgprompt_6_Link = cgiGet( "PROMPT_7_"+sGXsfl_83_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_83_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            wbErr = true;
            A7ProductId = 0;
         }
         else
         {
            A7ProductId = (short)(context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ","));
         }
         A8ProductName = cgiGet( edtProductName_Internalname);
         A22ProductPrice = context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ".", ",");
         if ( ( ( context.localUtil.CToN( cgiGet( edtQtyProduct_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtQtyProduct_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "QTYPRODUCT_" + sGXsfl_83_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtQtyProduct_Internalname;
            wbErr = true;
            A31QtyProduct = 0;
         }
         else
         {
            A31QtyProduct = (short)(context.localUtil.CToN( cgiGet( edtQtyProduct_Internalname), ".", ","));
         }
         A30TotalProduct = context.localUtil.CToN( cgiGet( edtTotalProduct_Internalname), ".", ",");
         A1CategoryId = (short)(context.localUtil.CToN( cgiGet( edtCategoryId_Internalname), ".", ","));
         A2CategoryName = cgiGet( edtCategoryName_Internalname);
         GXCCtl = "Z7ProductId_" + sGXsfl_83_idx;
         Z7ProductId = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "Z31QtyProduct_" + sGXsfl_83_idx;
         Z31QtyProduct = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "O30TotalProduct_" + sGXsfl_83_idx;
         O30TotalProduct = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         GXCCtl = "nRcdDeleted_9_" + sGXsfl_83_idx;
         nRcdDeleted_9 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_9_" + sGXsfl_83_idx;
         nRcdExists_9 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nIsMod_9_" + sGXsfl_83_idx;
         nIsMod_9 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
      }

      protected void assign_properties_default( )
      {
         defedtProductId_Enabled = edtProductId_Enabled;
      }

      protected void ConfirmValues050( )
      {
         nGXsfl_83_idx = 0;
         sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
         SubsflControlProps_839( ) ;
         while ( nGXsfl_83_idx < nRC_GXsfl_83 )
         {
            nGXsfl_83_idx = (int)(nGXsfl_83_idx+1);
            sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
            SubsflControlProps_839( ) ;
            ChangePostValue( "Z7ProductId_"+sGXsfl_83_idx, cgiGet( "ZT_"+"Z7ProductId_"+sGXsfl_83_idx)) ;
            DeletePostValue( "ZT_"+"Z7ProductId_"+sGXsfl_83_idx) ;
            ChangePostValue( "Z31QtyProduct_"+sGXsfl_83_idx, cgiGet( "ZT_"+"Z31QtyProduct_"+sGXsfl_83_idx)) ;
            DeletePostValue( "ZT_"+"Z31QtyProduct_"+sGXsfl_83_idx) ;
         }
         ChangePostValue( "O30TotalProduct", cgiGet( "T30TotalProduct")) ;
         DeletePostValue( "T30TotalProduct") ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 64220), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 64220), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 64220), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("shoppingcart.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV9ShoppingCartId,4,0))}, new string[] {"Gx_mode","ShoppingCartId"}) +"\">") ;
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"ShoppingCart");
         forbiddenHiddens.Add("ShoppingCartId", context.localUtil.Format( (decimal)(A11ShoppingCartId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("shoppingcart:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z11ShoppingCartId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z11ShoppingCartId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z28ShoppingCartDate", context.localUtil.DToC( Z28ShoppingCartDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z6CustomerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z6CustomerId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "O29ShoppingCartFinalPrice", StringUtil.LTrim( StringUtil.NToC( O29ShoppingCartFinalPrice, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_83", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_83_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N6CustomerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A6CustomerId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV10TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV10TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV10TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vSHOPPINGCARTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9ShoppingCartId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSHOPPINGCARTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9ShoppingCartId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_CUSTOMERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7Insert_CustomerId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV14Pgmname));
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
         return formatLink("shoppingcart.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV9ShoppingCartId,4,0))}, new string[] {"Gx_mode","ShoppingCartId"})  ;
      }

      public override string GetPgmname( )
      {
         return "ShoppingCart" ;
      }

      public override string GetPgmdesc( )
      {
         return "Shopping Cart" ;
      }

      protected void InitializeNonKey058( )
      {
         A6CustomerId = 0;
         AssignAttri("", false, "A6CustomerId", StringUtil.LTrimStr( (decimal)(A6CustomerId), 4, 0));
         A32ShoppingCartDateDelivery = DateTime.MinValue;
         AssignAttri("", false, "A32ShoppingCartDateDelivery", context.localUtil.Format(A32ShoppingCartDateDelivery, "99/99/99"));
         A15CustomerName = "";
         AssignAttri("", false, "A15CustomerName", A15CustomerName);
         A3CountryId = 0;
         AssignAttri("", false, "A3CountryId", StringUtil.LTrimStr( (decimal)(A3CountryId), 4, 0));
         A4CountryName = "";
         AssignAttri("", false, "A4CountryName", A4CountryName);
         A16CustomerAddress = "";
         AssignAttri("", false, "A16CustomerAddress", A16CustomerAddress);
         A18CustomerPhone = "";
         AssignAttri("", false, "A18CustomerPhone", A18CustomerPhone);
         A29ShoppingCartFinalPrice = 0;
         n29ShoppingCartFinalPrice = false;
         AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
         A28ShoppingCartDate = DateTimeUtil.Today( context);
         AssignAttri("", false, "A28ShoppingCartDate", context.localUtil.Format(A28ShoppingCartDate, "99/99/99"));
         O29ShoppingCartFinalPrice = A29ShoppingCartFinalPrice;
         n29ShoppingCartFinalPrice = false;
         AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrimStr( A29ShoppingCartFinalPrice, 10, 2));
         Z28ShoppingCartDate = DateTime.MinValue;
         Z6CustomerId = 0;
      }

      protected void InitAll058( )
      {
         A11ShoppingCartId = 0;
         AssignAttri("", false, "A11ShoppingCartId", StringUtil.LTrimStr( (decimal)(A11ShoppingCartId), 4, 0));
         InitializeNonKey058( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A28ShoppingCartDate = i28ShoppingCartDate;
         AssignAttri("", false, "A28ShoppingCartDate", context.localUtil.Format(A28ShoppingCartDate, "99/99/99"));
      }

      protected void InitializeNonKey059( )
      {
         A30TotalProduct = 0;
         A8ProductName = "";
         A22ProductPrice = 0;
         A31QtyProduct = 0;
         A1CategoryId = 0;
         A2CategoryName = "";
         O30TotalProduct = A30TotalProduct;
         Z31QtyProduct = 0;
      }

      protected void InitAll059( )
      {
         A7ProductId = 0;
         InitializeNonKey059( ) ;
      }

      protected void StandaloneModalInsert059( )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202211130482287", true, true);
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
         context.AddJavascriptSource("shoppingcart.js", "?202211130482288", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties9( )
      {
         edtProductId_Enabled = defedtProductId_Enabled;
         AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
      }

      protected void StartGridControl83( )
      {
         Gridshoppingcart_productContainer.AddObjectProperty("GridName", "Gridshoppingcart_product");
         Gridshoppingcart_productContainer.AddObjectProperty("Header", subGridshoppingcart_product_Header);
         Gridshoppingcart_productContainer.AddObjectProperty("Class", "Grid");
         Gridshoppingcart_productContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridshoppingcart_productContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridshoppingcart_productContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridshoppingcart_product_Backcolorstyle), 1, 0, ".", "")));
         Gridshoppingcart_productContainer.AddObjectProperty("CmpContext", "");
         Gridshoppingcart_productContainer.AddObjectProperty("InMasterPage", "false");
         Gridshoppingcart_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridshoppingcart_productColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7ProductId), 4, 0, ".", "")));
         Gridshoppingcart_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", "")));
         Gridshoppingcart_productContainer.AddColumnProperties(Gridshoppingcart_productColumn);
         Gridshoppingcart_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridshoppingcart_productContainer.AddColumnProperties(Gridshoppingcart_productColumn);
         Gridshoppingcart_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridshoppingcart_productColumn.AddObjectProperty("Value", StringUtil.RTrim( A8ProductName));
         Gridshoppingcart_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", "")));
         Gridshoppingcart_productContainer.AddColumnProperties(Gridshoppingcart_productColumn);
         Gridshoppingcart_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridshoppingcart_productColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A22ProductPrice, 12, 2, ".", "")));
         Gridshoppingcart_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductPrice_Enabled), 5, 0, ".", "")));
         Gridshoppingcart_productContainer.AddColumnProperties(Gridshoppingcart_productColumn);
         Gridshoppingcart_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridshoppingcart_productColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A31QtyProduct), 4, 0, ".", "")));
         Gridshoppingcart_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtQtyProduct_Enabled), 5, 0, ".", "")));
         Gridshoppingcart_productContainer.AddColumnProperties(Gridshoppingcart_productColumn);
         Gridshoppingcart_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridshoppingcart_productColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A30TotalProduct, 12, 2, ".", "")));
         Gridshoppingcart_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTotalProduct_Enabled), 5, 0, ".", "")));
         Gridshoppingcart_productContainer.AddColumnProperties(Gridshoppingcart_productColumn);
         Gridshoppingcart_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridshoppingcart_productColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CategoryId), 4, 0, ".", "")));
         Gridshoppingcart_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoryId_Enabled), 5, 0, ".", "")));
         Gridshoppingcart_productContainer.AddColumnProperties(Gridshoppingcart_productColumn);
         Gridshoppingcart_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridshoppingcart_productColumn.AddObjectProperty("Value", StringUtil.RTrim( A2CategoryName));
         Gridshoppingcart_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoryName_Enabled), 5, 0, ".", "")));
         Gridshoppingcart_productContainer.AddColumnProperties(Gridshoppingcart_productColumn);
         Gridshoppingcart_productContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridshoppingcart_product_Selectedindex), 4, 0, ".", "")));
         Gridshoppingcart_productContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridshoppingcart_product_Allowselection), 1, 0, ".", "")));
         Gridshoppingcart_productContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridshoppingcart_product_Selectioncolor), 9, 0, ".", "")));
         Gridshoppingcart_productContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridshoppingcart_product_Allowhovering), 1, 0, ".", "")));
         Gridshoppingcart_productContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridshoppingcart_product_Hoveringcolor), 9, 0, ".", "")));
         Gridshoppingcart_productContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridshoppingcart_product_Allowcollapsing), 1, 0, ".", "")));
         Gridshoppingcart_productContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridshoppingcart_product_Collapsed), 1, 0, ".", "")));
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
         edtShoppingCartId_Internalname = "SHOPPINGCARTID";
         edtShoppingCartDate_Internalname = "SHOPPINGCARTDATE";
         edtShoppingCartDateDelivery_Internalname = "SHOPPINGCARTDATEDELIVERY";
         edtCustomerId_Internalname = "CUSTOMERID";
         edtCustomerName_Internalname = "CUSTOMERNAME";
         edtCountryId_Internalname = "COUNTRYID";
         edtCountryName_Internalname = "COUNTRYNAME";
         edtCustomerAddress_Internalname = "CUSTOMERADDRESS";
         edtCustomerPhone_Internalname = "CUSTOMERPHONE";
         lblTitleproduct_Internalname = "TITLEPRODUCT";
         edtProductId_Internalname = "PRODUCTID";
         edtProductName_Internalname = "PRODUCTNAME";
         edtProductPrice_Internalname = "PRODUCTPRICE";
         edtQtyProduct_Internalname = "QTYPRODUCT";
         edtTotalProduct_Internalname = "TOTALPRODUCT";
         edtCategoryId_Internalname = "CATEGORYID";
         edtCategoryName_Internalname = "CATEGORYNAME";
         divProducttable_Internalname = "PRODUCTTABLE";
         edtShoppingCartFinalPrice_Internalname = "SHOPPINGCARTFINALPRICE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_6_Internalname = "PROMPT_6";
         imgprompt_7_Internalname = "PROMPT_7";
         subGridshoppingcart_product_Internalname = "GRIDSHOPPINGCART_PRODUCT";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridshoppingcart_product_Allowcollapsing = 0;
         subGridshoppingcart_product_Allowselection = 0;
         subGridshoppingcart_product_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Shopping Cart";
         edtCategoryName_Jsonclick = "";
         edtCategoryId_Jsonclick = "";
         edtTotalProduct_Jsonclick = "";
         edtQtyProduct_Jsonclick = "";
         edtProductPrice_Jsonclick = "";
         edtProductName_Jsonclick = "";
         imgprompt_7_Visible = 1;
         imgprompt_7_Link = "";
         imgprompt_6_Visible = 1;
         edtProductId_Jsonclick = "";
         subGridshoppingcart_product_Class = "Grid";
         subGridshoppingcart_product_Backcolorstyle = 0;
         edtCategoryName_Enabled = 0;
         edtCategoryId_Enabled = 0;
         edtTotalProduct_Enabled = 0;
         edtQtyProduct_Enabled = 1;
         edtProductPrice_Enabled = 0;
         edtProductName_Enabled = 0;
         edtProductId_Enabled = 1;
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtShoppingCartFinalPrice_Jsonclick = "";
         edtShoppingCartFinalPrice_Enabled = 0;
         edtCustomerPhone_Jsonclick = "";
         edtCustomerPhone_Enabled = 0;
         edtCustomerAddress_Enabled = 0;
         edtCountryName_Jsonclick = "";
         edtCountryName_Enabled = 0;
         edtCountryId_Jsonclick = "";
         edtCountryId_Enabled = 0;
         edtCustomerName_Jsonclick = "";
         edtCustomerName_Enabled = 0;
         imgprompt_6_Visible = 1;
         imgprompt_6_Link = "";
         edtCustomerId_Jsonclick = "";
         edtCustomerId_Enabled = 1;
         edtShoppingCartDateDelivery_Jsonclick = "";
         edtShoppingCartDateDelivery_Enabled = 0;
         edtShoppingCartDate_Jsonclick = "";
         edtShoppingCartDate_Enabled = 1;
         edtShoppingCartId_Jsonclick = "";
         edtShoppingCartId_Enabled = 0;
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

      protected void gxnrGridshoppingcart_product_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_839( ) ;
         while ( nGXsfl_83_idx <= nRC_GXsfl_83 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal059( ) ;
            standaloneModal059( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow059( ) ;
            nGXsfl_83_idx = (int)(nGXsfl_83_idx+1);
            sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
            SubsflControlProps_839( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridshoppingcart_productContainer)) ;
         /* End function gxnrGridshoppingcart_product_newrow */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
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

      public void Valid_Shoppingcartid( )
      {
         n29ShoppingCartFinalPrice = false;
         /* Using cursor T000525 */
         pr_default.execute(19, new Object[] {A11ShoppingCartId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            A29ShoppingCartFinalPrice = T000525_A29ShoppingCartFinalPrice[0];
            n29ShoppingCartFinalPrice = T000525_n29ShoppingCartFinalPrice[0];
         }
         else
         {
            A29ShoppingCartFinalPrice = 0;
            n29ShoppingCartFinalPrice = false;
         }
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A29ShoppingCartFinalPrice", StringUtil.LTrim( StringUtil.NToC( A29ShoppingCartFinalPrice, 10, 2, ".", "")));
      }

      public void Valid_Customerid( )
      {
         /* Using cursor T000526 */
         pr_default.execute(20, new Object[] {A6CustomerId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No matching 'Customer'.", "ForeignKeyNotFound", 1, "CUSTOMERID");
            AnyError = 1;
            GX_FocusControl = edtCustomerId_Internalname;
         }
         A15CustomerName = T000526_A15CustomerName[0];
         A16CustomerAddress = T000526_A16CustomerAddress[0];
         A18CustomerPhone = T000526_A18CustomerPhone[0];
         A3CountryId = T000526_A3CountryId[0];
         pr_default.close(20);
         /* Using cursor T000527 */
         pr_default.execute(21, new Object[] {A3CountryId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No matching 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
         }
         A4CountryName = T000527_A4CountryName[0];
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A15CustomerName", StringUtil.RTrim( A15CustomerName));
         AssignAttri("", false, "A16CustomerAddress", A16CustomerAddress);
         AssignAttri("", false, "A18CustomerPhone", StringUtil.RTrim( A18CustomerPhone));
         AssignAttri("", false, "A3CountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A3CountryId), 4, 0, ".", "")));
         AssignAttri("", false, "A4CountryName", StringUtil.RTrim( A4CountryName));
      }

      public void Valid_Productid( )
      {
         /* Using cursor T000536 */
         pr_default.execute(30, new Object[] {A7ProductId});
         if ( (pr_default.getStatus(30) == 101) )
         {
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, "PRODUCTID");
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
         }
         A8ProductName = T000536_A8ProductName[0];
         A22ProductPrice = T000536_A22ProductPrice[0];
         A1CategoryId = T000536_A1CategoryId[0];
         pr_default.close(30);
         /* Using cursor T000537 */
         pr_default.execute(31, new Object[] {A1CategoryId});
         if ( (pr_default.getStatus(31) == 101) )
         {
            GX_msglist.addItem("No matching 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
            AnyError = 1;
         }
         A2CategoryName = T000537_A2CategoryName[0];
         pr_default.close(31);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A8ProductName", StringUtil.RTrim( A8ProductName));
         AssignAttri("", false, "A22ProductPrice", StringUtil.LTrim( StringUtil.NToC( A22ProductPrice, 10, 2, ".", "")));
         AssignAttri("", false, "A1CategoryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CategoryId), 4, 0, ".", "")));
         AssignAttri("", false, "A2CategoryName", StringUtil.RTrim( A2CategoryName));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9ShoppingCartId',fld:'vSHOPPINGCARTID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV9ShoppingCartId',fld:'vSHOPPINGCARTID',pic:'ZZZ9',hsh:true},{av:'A11ShoppingCartId',fld:'SHOPPINGCARTID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12052',iparms:[{av:'A11ShoppingCartId',fld:'SHOPPINGCARTID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A11ShoppingCartId',fld:'SHOPPINGCARTID',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_SHOPPINGCARTID","{handler:'Valid_Shoppingcartid',iparms:[{av:'A11ShoppingCartId',fld:'SHOPPINGCARTID',pic:'ZZZ9'},{av:'A29ShoppingCartFinalPrice',fld:'SHOPPINGCARTFINALPRICE',pic:'$ ZZZZZZ9.99'}]");
         setEventMetadata("VALID_SHOPPINGCARTID",",oparms:[{av:'A29ShoppingCartFinalPrice',fld:'SHOPPINGCARTFINALPRICE',pic:'$ ZZZZZZ9.99'}]}");
         setEventMetadata("VALID_SHOPPINGCARTDATE","{handler:'Valid_Shoppingcartdate',iparms:[]");
         setEventMetadata("VALID_SHOPPINGCARTDATE",",oparms:[]}");
         setEventMetadata("VALID_CUSTOMERID","{handler:'Valid_Customerid',iparms:[{av:'A6CustomerId',fld:'CUSTOMERID',pic:'ZZZ9'},{av:'A3CountryId',fld:'COUNTRYID',pic:'ZZZ9'},{av:'A15CustomerName',fld:'CUSTOMERNAME',pic:''},{av:'A16CustomerAddress',fld:'CUSTOMERADDRESS',pic:''},{av:'A18CustomerPhone',fld:'CUSTOMERPHONE',pic:''},{av:'A4CountryName',fld:'COUNTRYNAME',pic:''}]");
         setEventMetadata("VALID_CUSTOMERID",",oparms:[{av:'A15CustomerName',fld:'CUSTOMERNAME',pic:''},{av:'A16CustomerAddress',fld:'CUSTOMERADDRESS',pic:''},{av:'A18CustomerPhone',fld:'CUSTOMERPHONE',pic:''},{av:'A3CountryId',fld:'COUNTRYID',pic:'ZZZ9'},{av:'A4CountryName',fld:'COUNTRYNAME',pic:''}]}");
         setEventMetadata("VALID_COUNTRYID","{handler:'Valid_Countryid',iparms:[]");
         setEventMetadata("VALID_COUNTRYID",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTID","{handler:'Valid_Productid',iparms:[{av:'A7ProductId',fld:'PRODUCTID',pic:'ZZZ9'},{av:'A1CategoryId',fld:'CATEGORYID',pic:'ZZZ9'},{av:'A8ProductName',fld:'PRODUCTNAME',pic:''},{av:'A22ProductPrice',fld:'PRODUCTPRICE',pic:'$ ZZZZZZ9.99'},{av:'A2CategoryName',fld:'CATEGORYNAME',pic:''}]");
         setEventMetadata("VALID_PRODUCTID",",oparms:[{av:'A8ProductName',fld:'PRODUCTNAME',pic:''},{av:'A22ProductPrice',fld:'PRODUCTPRICE',pic:'$ ZZZZZZ9.99'},{av:'A1CategoryId',fld:'CATEGORYID',pic:'ZZZ9'},{av:'A2CategoryName',fld:'CATEGORYNAME',pic:''}]}");
         setEventMetadata("VALID_PRODUCTPRICE","{handler:'Valid_Productprice',iparms:[]");
         setEventMetadata("VALID_PRODUCTPRICE",",oparms:[]}");
         setEventMetadata("VALID_QTYPRODUCT","{handler:'Valid_Qtyproduct',iparms:[]");
         setEventMetadata("VALID_QTYPRODUCT",",oparms:[]}");
         setEventMetadata("VALID_TOTALPRODUCT","{handler:'Valid_Totalproduct',iparms:[]");
         setEventMetadata("VALID_TOTALPRODUCT",",oparms:[]}");
         setEventMetadata("VALID_CATEGORYID","{handler:'Valid_Categoryid',iparms:[]");
         setEventMetadata("VALID_CATEGORYID",",oparms:[]}");
         setEventMetadata("VALID_CATEGORYNAME","{handler:'Valid_Categoryname',iparms:[]");
         setEventMetadata("VALID_CATEGORYNAME",",oparms:[]}");
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
         pr_default.close(30);
         pr_default.close(31);
         pr_default.close(5);
         pr_default.close(20);
         pr_default.close(21);
         pr_default.close(19);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z28ShoppingCartDate = DateTime.MinValue;
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
         A28ShoppingCartDate = DateTime.MinValue;
         A32ShoppingCartDateDelivery = DateTime.MinValue;
         sImgUrl = "";
         A15CustomerName = "";
         A4CountryName = "";
         A16CustomerAddress = "";
         gxphoneLink = "";
         A18CustomerPhone = "";
         lblTitleproduct_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridshoppingcart_productContainer = new GXWebGrid( context);
         sMode9 = "";
         sStyleString = "";
         AV14Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode8 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A8ProductName = "";
         A2CategoryName = "";
         AV10TrnContext = new SdtTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV11TrnContextAtt = new SdtTransactionContext_Attribute(context);
         Z15CustomerName = "";
         Z16CustomerAddress = "";
         Z18CustomerPhone = "";
         Z4CountryName = "";
         T000511_A29ShoppingCartFinalPrice = new decimal[1] ;
         T000511_n29ShoppingCartFinalPrice = new bool[] {false} ;
         T00058_A15CustomerName = new string[] {""} ;
         T00058_A16CustomerAddress = new string[] {""} ;
         T00058_A18CustomerPhone = new string[] {""} ;
         T00058_A3CountryId = new short[1] ;
         T00059_A4CountryName = new string[] {""} ;
         T000513_A11ShoppingCartId = new short[1] ;
         T000513_A28ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         T000513_A15CustomerName = new string[] {""} ;
         T000513_A4CountryName = new string[] {""} ;
         T000513_A16CustomerAddress = new string[] {""} ;
         T000513_A18CustomerPhone = new string[] {""} ;
         T000513_A6CustomerId = new short[1] ;
         T000513_A3CountryId = new short[1] ;
         T000513_A29ShoppingCartFinalPrice = new decimal[1] ;
         T000513_n29ShoppingCartFinalPrice = new bool[] {false} ;
         T000515_A29ShoppingCartFinalPrice = new decimal[1] ;
         T000515_n29ShoppingCartFinalPrice = new bool[] {false} ;
         T000516_A15CustomerName = new string[] {""} ;
         T000516_A16CustomerAddress = new string[] {""} ;
         T000516_A18CustomerPhone = new string[] {""} ;
         T000516_A3CountryId = new short[1] ;
         T000517_A4CountryName = new string[] {""} ;
         T000518_A11ShoppingCartId = new short[1] ;
         T00057_A11ShoppingCartId = new short[1] ;
         T00057_A28ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         T00057_A6CustomerId = new short[1] ;
         T000519_A11ShoppingCartId = new short[1] ;
         T000520_A11ShoppingCartId = new short[1] ;
         T00056_A11ShoppingCartId = new short[1] ;
         T00056_A28ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         T00056_A6CustomerId = new short[1] ;
         T000521_A11ShoppingCartId = new short[1] ;
         T000525_A29ShoppingCartFinalPrice = new decimal[1] ;
         T000525_n29ShoppingCartFinalPrice = new bool[] {false} ;
         T000526_A15CustomerName = new string[] {""} ;
         T000526_A16CustomerAddress = new string[] {""} ;
         T000526_A18CustomerPhone = new string[] {""} ;
         T000526_A3CountryId = new short[1] ;
         T000527_A4CountryName = new string[] {""} ;
         T000528_A11ShoppingCartId = new short[1] ;
         Z8ProductName = "";
         Z2CategoryName = "";
         T000529_A11ShoppingCartId = new short[1] ;
         T000529_A8ProductName = new string[] {""} ;
         T000529_A22ProductPrice = new decimal[1] ;
         T000529_A31QtyProduct = new short[1] ;
         T000529_A2CategoryName = new string[] {""} ;
         T000529_A7ProductId = new short[1] ;
         T000529_A1CategoryId = new short[1] ;
         T00054_A8ProductName = new string[] {""} ;
         T00054_A22ProductPrice = new decimal[1] ;
         T00054_A1CategoryId = new short[1] ;
         T00055_A2CategoryName = new string[] {""} ;
         T000530_A8ProductName = new string[] {""} ;
         T000530_A22ProductPrice = new decimal[1] ;
         T000530_A1CategoryId = new short[1] ;
         T000531_A2CategoryName = new string[] {""} ;
         T000532_A11ShoppingCartId = new short[1] ;
         T000532_A7ProductId = new short[1] ;
         T00053_A11ShoppingCartId = new short[1] ;
         T00053_A31QtyProduct = new short[1] ;
         T00053_A7ProductId = new short[1] ;
         T00052_A11ShoppingCartId = new short[1] ;
         T00052_A31QtyProduct = new short[1] ;
         T00052_A7ProductId = new short[1] ;
         T000536_A8ProductName = new string[] {""} ;
         T000536_A22ProductPrice = new decimal[1] ;
         T000536_A1CategoryId = new short[1] ;
         T000537_A2CategoryName = new string[] {""} ;
         T000538_A11ShoppingCartId = new short[1] ;
         T000538_A7ProductId = new short[1] ;
         Gridshoppingcart_productRow = new GXWebRow();
         subGridshoppingcart_product_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i28ShoppingCartDate = DateTime.MinValue;
         Gridshoppingcart_productColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.shoppingcart__default(),
            new Object[][] {
                new Object[] {
               T00052_A11ShoppingCartId, T00052_A31QtyProduct, T00052_A7ProductId
               }
               , new Object[] {
               T00053_A11ShoppingCartId, T00053_A31QtyProduct, T00053_A7ProductId
               }
               , new Object[] {
               T00054_A8ProductName, T00054_A22ProductPrice, T00054_A1CategoryId
               }
               , new Object[] {
               T00055_A2CategoryName
               }
               , new Object[] {
               T00056_A11ShoppingCartId, T00056_A28ShoppingCartDate, T00056_A6CustomerId
               }
               , new Object[] {
               T00057_A11ShoppingCartId, T00057_A28ShoppingCartDate, T00057_A6CustomerId
               }
               , new Object[] {
               T00058_A15CustomerName, T00058_A16CustomerAddress, T00058_A18CustomerPhone, T00058_A3CountryId
               }
               , new Object[] {
               T00059_A4CountryName
               }
               , new Object[] {
               T000511_A29ShoppingCartFinalPrice, T000511_n29ShoppingCartFinalPrice
               }
               , new Object[] {
               T000513_A11ShoppingCartId, T000513_A28ShoppingCartDate, T000513_A15CustomerName, T000513_A4CountryName, T000513_A16CustomerAddress, T000513_A18CustomerPhone, T000513_A6CustomerId, T000513_A3CountryId, T000513_A29ShoppingCartFinalPrice, T000513_n29ShoppingCartFinalPrice
               }
               , new Object[] {
               T000515_A29ShoppingCartFinalPrice, T000515_n29ShoppingCartFinalPrice
               }
               , new Object[] {
               T000516_A15CustomerName, T000516_A16CustomerAddress, T000516_A18CustomerPhone, T000516_A3CountryId
               }
               , new Object[] {
               T000517_A4CountryName
               }
               , new Object[] {
               T000518_A11ShoppingCartId
               }
               , new Object[] {
               T000519_A11ShoppingCartId
               }
               , new Object[] {
               T000520_A11ShoppingCartId
               }
               , new Object[] {
               T000521_A11ShoppingCartId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000525_A29ShoppingCartFinalPrice, T000525_n29ShoppingCartFinalPrice
               }
               , new Object[] {
               T000526_A15CustomerName, T000526_A16CustomerAddress, T000526_A18CustomerPhone, T000526_A3CountryId
               }
               , new Object[] {
               T000527_A4CountryName
               }
               , new Object[] {
               T000528_A11ShoppingCartId
               }
               , new Object[] {
               T000529_A11ShoppingCartId, T000529_A8ProductName, T000529_A22ProductPrice, T000529_A31QtyProduct, T000529_A2CategoryName, T000529_A7ProductId, T000529_A1CategoryId
               }
               , new Object[] {
               T000530_A8ProductName, T000530_A22ProductPrice, T000530_A1CategoryId
               }
               , new Object[] {
               T000531_A2CategoryName
               }
               , new Object[] {
               T000532_A11ShoppingCartId, T000532_A7ProductId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000536_A8ProductName, T000536_A22ProductPrice, T000536_A1CategoryId
               }
               , new Object[] {
               T000537_A2CategoryName
               }
               , new Object[] {
               T000538_A11ShoppingCartId, T000538_A7ProductId
               }
            }
         );
         AV14Pgmname = "ShoppingCart";
         Z28ShoppingCartDate = DateTimeUtil.Today( context);
         A28ShoppingCartDate = DateTimeUtil.Today( context);
         i28ShoppingCartDate = DateTimeUtil.Today( context);
      }

      private short nIsMod_9 ;
      private short wcpOAV9ShoppingCartId ;
      private short Z11ShoppingCartId ;
      private short Z6CustomerId ;
      private short N6CustomerId ;
      private short Z7ProductId ;
      private short Z31QtyProduct ;
      private short nRcdDeleted_9 ;
      private short nRcdExists_9 ;
      private short GxWebError ;
      private short A11ShoppingCartId ;
      private short A6CustomerId ;
      private short A3CountryId ;
      private short A7ProductId ;
      private short A1CategoryId ;
      private short AV9ShoppingCartId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nBlankRcdCount9 ;
      private short RcdFound9 ;
      private short nBlankRcdUsr9 ;
      private short AV7Insert_CustomerId ;
      private short Gx_BScreen ;
      private short RcdFound8 ;
      private short A31QtyProduct ;
      private short GX_JID ;
      private short Z3CountryId ;
      private short nIsDirty_8 ;
      private short Z1CategoryId ;
      private short nIsDirty_9 ;
      private short subGridshoppingcart_product_Backcolorstyle ;
      private short subGridshoppingcart_product_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridshoppingcart_product_Allowselection ;
      private short subGridshoppingcart_product_Allowhovering ;
      private short subGridshoppingcart_product_Allowcollapsing ;
      private short subGridshoppingcart_product_Collapsed ;
      private int nRC_GXsfl_83 ;
      private int nGXsfl_83_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtShoppingCartId_Enabled ;
      private int edtShoppingCartDate_Enabled ;
      private int edtShoppingCartDateDelivery_Enabled ;
      private int edtCustomerId_Enabled ;
      private int imgprompt_6_Visible ;
      private int edtCustomerName_Enabled ;
      private int edtCountryId_Enabled ;
      private int edtCountryName_Enabled ;
      private int edtCustomerAddress_Enabled ;
      private int edtCustomerPhone_Enabled ;
      private int edtShoppingCartFinalPrice_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtProductId_Enabled ;
      private int edtProductName_Enabled ;
      private int edtProductPrice_Enabled ;
      private int edtQtyProduct_Enabled ;
      private int edtTotalProduct_Enabled ;
      private int edtCategoryId_Enabled ;
      private int edtCategoryName_Enabled ;
      private int fRowAdded ;
      private int AV15GXV1 ;
      private int subGridshoppingcart_product_Backcolor ;
      private int subGridshoppingcart_product_Allbackcolor ;
      private int imgprompt_7_Visible ;
      private int defedtProductId_Enabled ;
      private int idxLst ;
      private int subGridshoppingcart_product_Selectedindex ;
      private int subGridshoppingcart_product_Selectioncolor ;
      private int subGridshoppingcart_product_Hoveringcolor ;
      private long GRIDSHOPPINGCART_PRODUCT_nFirstRecordOnPage ;
      private decimal O29ShoppingCartFinalPrice ;
      private decimal O30TotalProduct ;
      private decimal A29ShoppingCartFinalPrice ;
      private decimal B29ShoppingCartFinalPrice ;
      private decimal s29ShoppingCartFinalPrice ;
      private decimal A22ProductPrice ;
      private decimal A30TotalProduct ;
      private decimal T30TotalProduct ;
      private decimal Z29ShoppingCartFinalPrice ;
      private decimal Z22ProductPrice ;
      private string sPrefix ;
      private string sGXsfl_83_idx="0001" ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtShoppingCartDate_Internalname ;
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
      private string edtShoppingCartId_Internalname ;
      private string edtShoppingCartId_Jsonclick ;
      private string edtShoppingCartDate_Jsonclick ;
      private string edtShoppingCartDateDelivery_Internalname ;
      private string edtShoppingCartDateDelivery_Jsonclick ;
      private string edtCustomerId_Internalname ;
      private string edtCustomerId_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_6_Internalname ;
      private string imgprompt_6_Link ;
      private string edtCustomerName_Internalname ;
      private string A15CustomerName ;
      private string edtCustomerName_Jsonclick ;
      private string edtCountryId_Internalname ;
      private string edtCountryId_Jsonclick ;
      private string edtCountryName_Internalname ;
      private string A4CountryName ;
      private string edtCountryName_Jsonclick ;
      private string edtCustomerAddress_Internalname ;
      private string edtCustomerPhone_Internalname ;
      private string gxphoneLink ;
      private string A18CustomerPhone ;
      private string edtCustomerPhone_Jsonclick ;
      private string divProducttable_Internalname ;
      private string lblTitleproduct_Internalname ;
      private string lblTitleproduct_Jsonclick ;
      private string edtShoppingCartFinalPrice_Internalname ;
      private string edtShoppingCartFinalPrice_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode9 ;
      private string edtProductId_Internalname ;
      private string edtProductName_Internalname ;
      private string edtProductPrice_Internalname ;
      private string edtQtyProduct_Internalname ;
      private string edtTotalProduct_Internalname ;
      private string edtCategoryId_Internalname ;
      private string edtCategoryName_Internalname ;
      private string sStyleString ;
      private string subGridshoppingcart_product_Internalname ;
      private string AV14Pgmname ;
      private string hsh ;
      private string sMode8 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string A8ProductName ;
      private string A2CategoryName ;
      private string Z15CustomerName ;
      private string Z18CustomerPhone ;
      private string Z4CountryName ;
      private string Z8ProductName ;
      private string Z2CategoryName ;
      private string imgprompt_7_Internalname ;
      private string sGXsfl_83_fel_idx="0001" ;
      private string subGridshoppingcart_product_Class ;
      private string subGridshoppingcart_product_Linesclass ;
      private string imgprompt_7_Link ;
      private string ROClassString ;
      private string edtProductId_Jsonclick ;
      private string edtProductName_Jsonclick ;
      private string edtProductPrice_Jsonclick ;
      private string edtQtyProduct_Jsonclick ;
      private string edtTotalProduct_Jsonclick ;
      private string edtCategoryId_Jsonclick ;
      private string edtCategoryName_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridshoppingcart_product_Header ;
      private DateTime Z28ShoppingCartDate ;
      private DateTime A28ShoppingCartDate ;
      private DateTime A32ShoppingCartDateDelivery ;
      private DateTime i28ShoppingCartDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n29ShoppingCartFinalPrice ;
      private bool bGXsfl_83_Refreshing=false ;
      private bool returnInSub ;
      private string A16CustomerAddress ;
      private string Z16CustomerAddress ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridshoppingcart_productContainer ;
      private GXWebRow Gridshoppingcart_productRow ;
      private GXWebColumn Gridshoppingcart_productColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] T000511_A29ShoppingCartFinalPrice ;
      private bool[] T000511_n29ShoppingCartFinalPrice ;
      private string[] T00058_A15CustomerName ;
      private string[] T00058_A16CustomerAddress ;
      private string[] T00058_A18CustomerPhone ;
      private short[] T00058_A3CountryId ;
      private string[] T00059_A4CountryName ;
      private short[] T000513_A11ShoppingCartId ;
      private DateTime[] T000513_A28ShoppingCartDate ;
      private string[] T000513_A15CustomerName ;
      private string[] T000513_A4CountryName ;
      private string[] T000513_A16CustomerAddress ;
      private string[] T000513_A18CustomerPhone ;
      private short[] T000513_A6CustomerId ;
      private short[] T000513_A3CountryId ;
      private decimal[] T000513_A29ShoppingCartFinalPrice ;
      private bool[] T000513_n29ShoppingCartFinalPrice ;
      private decimal[] T000515_A29ShoppingCartFinalPrice ;
      private bool[] T000515_n29ShoppingCartFinalPrice ;
      private string[] T000516_A15CustomerName ;
      private string[] T000516_A16CustomerAddress ;
      private string[] T000516_A18CustomerPhone ;
      private short[] T000516_A3CountryId ;
      private string[] T000517_A4CountryName ;
      private short[] T000518_A11ShoppingCartId ;
      private short[] T00057_A11ShoppingCartId ;
      private DateTime[] T00057_A28ShoppingCartDate ;
      private short[] T00057_A6CustomerId ;
      private short[] T000519_A11ShoppingCartId ;
      private short[] T000520_A11ShoppingCartId ;
      private short[] T00056_A11ShoppingCartId ;
      private DateTime[] T00056_A28ShoppingCartDate ;
      private short[] T00056_A6CustomerId ;
      private short[] T000521_A11ShoppingCartId ;
      private decimal[] T000525_A29ShoppingCartFinalPrice ;
      private bool[] T000525_n29ShoppingCartFinalPrice ;
      private string[] T000526_A15CustomerName ;
      private string[] T000526_A16CustomerAddress ;
      private string[] T000526_A18CustomerPhone ;
      private short[] T000526_A3CountryId ;
      private string[] T000527_A4CountryName ;
      private short[] T000528_A11ShoppingCartId ;
      private short[] T000529_A11ShoppingCartId ;
      private string[] T000529_A8ProductName ;
      private decimal[] T000529_A22ProductPrice ;
      private short[] T000529_A31QtyProduct ;
      private string[] T000529_A2CategoryName ;
      private short[] T000529_A7ProductId ;
      private short[] T000529_A1CategoryId ;
      private string[] T00054_A8ProductName ;
      private decimal[] T00054_A22ProductPrice ;
      private short[] T00054_A1CategoryId ;
      private string[] T00055_A2CategoryName ;
      private string[] T000530_A8ProductName ;
      private decimal[] T000530_A22ProductPrice ;
      private short[] T000530_A1CategoryId ;
      private string[] T000531_A2CategoryName ;
      private short[] T000532_A11ShoppingCartId ;
      private short[] T000532_A7ProductId ;
      private short[] T00053_A11ShoppingCartId ;
      private short[] T00053_A31QtyProduct ;
      private short[] T00053_A7ProductId ;
      private short[] T00052_A11ShoppingCartId ;
      private short[] T00052_A31QtyProduct ;
      private short[] T00052_A7ProductId ;
      private string[] T000536_A8ProductName ;
      private decimal[] T000536_A22ProductPrice ;
      private short[] T000536_A1CategoryId ;
      private string[] T000537_A2CategoryName ;
      private short[] T000538_A11ShoppingCartId ;
      private short[] T000538_A7ProductId ;
      private GXWebForm Form ;
      private SdtTransactionContext AV10TrnContext ;
      private SdtTransactionContext_Attribute AV11TrnContextAtt ;
   }

   public class shoppingcart__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[16])
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
         ,new UpdateCursor(def[27])
         ,new UpdateCursor(def[28])
         ,new UpdateCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new ForEachCursor(def[31])
         ,new ForEachCursor(def[32])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000513;
          prmT000513 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT000511;
          prmT000511 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT00058;
          prmT00058 = new Object[] {
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmT00059;
          prmT00059 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT000515;
          prmT000515 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT000516;
          prmT000516 = new Object[] {
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmT000517;
          prmT000517 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT000518;
          prmT000518 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT00057;
          prmT00057 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT000519;
          prmT000519 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT000520;
          prmT000520 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT00056;
          prmT00056 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT000521;
          prmT000521 = new Object[] {
          new ParDef("@ShoppingCartDate",GXType.Date,8,0) ,
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmT000522;
          prmT000522 = new Object[] {
          new ParDef("@ShoppingCartDate",GXType.Date,8,0) ,
          new ParDef("@CustomerId",GXType.Int16,4,0) ,
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT000523;
          prmT000523 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT000528;
          prmT000528 = new Object[] {
          };
          Object[] prmT000529;
          prmT000529 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00054;
          prmT00054 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00055;
          prmT00055 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmT000530;
          prmT000530 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000531;
          prmT000531 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmT000532;
          prmT000532 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00053;
          prmT00053 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00052;
          prmT00052 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000533;
          prmT000533 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@QtyProduct",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000534;
          prmT000534 = new Object[] {
          new ParDef("@QtyProduct",GXType.Int16,4,0) ,
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000535;
          prmT000535 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000538;
          prmT000538 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT000525;
          prmT000525 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT000526;
          prmT000526 = new Object[] {
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmT000527;
          prmT000527 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT000536;
          prmT000536 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000537;
          prmT000537 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00052", "SELECT [ShoppingCartId], [QtyProduct], [ProductId] FROM [ShoppingCartProduct] WITH (UPDLOCK) WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00052,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00053", "SELECT [ShoppingCartId], [QtyProduct], [ProductId] FROM [ShoppingCartProduct] WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00053,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00054", "SELECT [ProductName], [ProductPrice], [CategoryId] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00054,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00055", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00055,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00056", "SELECT [ShoppingCartId], [ShoppingCartDate], [CustomerId] FROM [ShoppingCart] WITH (UPDLOCK) WHERE [ShoppingCartId] = @ShoppingCartId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00056,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00057", "SELECT [ShoppingCartId], [ShoppingCartDate], [CustomerId] FROM [ShoppingCart] WHERE [ShoppingCartId] = @ShoppingCartId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00057,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00058", "SELECT [CustomerName], [CustomerAddress], [CustomerPhone], [CountryId] FROM [Customer] WHERE [CustomerId] = @CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00058,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00059", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00059,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000511", "SELECT COALESCE( T1.[ShoppingCartFinalPrice], 0) AS ShoppingCartFinalPrice FROM (SELECT SUM(CASE  WHEN T4.[CategoryName] = 'Joyería' THEN T2.[QtyProduct] * CAST(T3.[ProductPrice] AS decimal( 20, 10)) * CAST(( 1 + CAST(5 AS decimal( 13, 10)) / 100) AS decimal( 22, 10)) WHEN T4.[CategoryName] = 'Entretenimiento' THEN T2.[QtyProduct] * CAST(T3.[ProductPrice] AS decimal( 20, 10)) * CAST(( 1 - CAST(10 AS decimal( 13, 10)) / 100) AS decimal( 22, 10)) ELSE T2.[QtyProduct] * CAST(T3.[ProductPrice] AS decimal( 20, 10)) END) AS ShoppingCartFinalPrice, T2.[ShoppingCartId] FROM (([ShoppingCartProduct] T2 WITH (UPDLOCK) INNER JOIN [Product] T3 ON T3.[ProductId] = T2.[ProductId]) INNER JOIN [Category] T4 ON T4.[CategoryId] = T3.[CategoryId]) GROUP BY T2.[ShoppingCartId] ) T1 WHERE T1.[ShoppingCartId] = @ShoppingCartId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000511,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000513", "SELECT TM1.[ShoppingCartId], TM1.[ShoppingCartDate], T3.[CustomerName], T4.[CountryName], T3.[CustomerAddress], T3.[CustomerPhone], TM1.[CustomerId], T3.[CountryId], COALESCE( T2.[ShoppingCartFinalPrice], 0) AS ShoppingCartFinalPrice FROM ((([ShoppingCart] TM1 LEFT JOIN (SELECT SUM(CASE  WHEN T7.[CategoryName] = 'Joyería' THEN T5.[QtyProduct] * CAST(T6.[ProductPrice] AS decimal( 20, 10)) * CAST(( 1 + CAST(5 AS decimal( 13, 10)) / 100) AS decimal( 22, 10)) WHEN T7.[CategoryName] = 'Entretenimiento' THEN T5.[QtyProduct] * CAST(T6.[ProductPrice] AS decimal( 20, 10)) * CAST(( 1 - CAST(10 AS decimal( 13, 10)) / 100) AS decimal( 22, 10)) ELSE T5.[QtyProduct] * CAST(T6.[ProductPrice] AS decimal( 20, 10)) END) AS ShoppingCartFinalPrice, T5.[ShoppingCartId] FROM (([ShoppingCartProduct] T5 INNER JOIN [Product] T6 ON T6.[ProductId] = T5.[ProductId]) INNER JOIN [Category] T7 ON T7.[CategoryId] = T6.[CategoryId]) GROUP BY T5.[ShoppingCartId] ) T2 ON T2.[ShoppingCartId] = TM1.[ShoppingCartId]) INNER JOIN [Customer] T3 ON T3.[CustomerId] = TM1.[CustomerId]) INNER JOIN [Country] T4 ON T4.[CountryId] = T3.[CountryId]) WHERE TM1.[ShoppingCartId] = @ShoppingCartId ORDER BY TM1.[ShoppingCartId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000513,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000515", "SELECT COALESCE( T1.[ShoppingCartFinalPrice], 0) AS ShoppingCartFinalPrice FROM (SELECT SUM(CASE  WHEN T4.[CategoryName] = 'Joyería' THEN T2.[QtyProduct] * CAST(T3.[ProductPrice] AS decimal( 20, 10)) * CAST(( 1 + CAST(5 AS decimal( 13, 10)) / 100) AS decimal( 22, 10)) WHEN T4.[CategoryName] = 'Entretenimiento' THEN T2.[QtyProduct] * CAST(T3.[ProductPrice] AS decimal( 20, 10)) * CAST(( 1 - CAST(10 AS decimal( 13, 10)) / 100) AS decimal( 22, 10)) ELSE T2.[QtyProduct] * CAST(T3.[ProductPrice] AS decimal( 20, 10)) END) AS ShoppingCartFinalPrice, T2.[ShoppingCartId] FROM (([ShoppingCartProduct] T2 WITH (UPDLOCK) INNER JOIN [Product] T3 ON T3.[ProductId] = T2.[ProductId]) INNER JOIN [Category] T4 ON T4.[CategoryId] = T3.[CategoryId]) GROUP BY T2.[ShoppingCartId] ) T1 WHERE T1.[ShoppingCartId] = @ShoppingCartId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000515,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000516", "SELECT [CustomerName], [CustomerAddress], [CustomerPhone], [CountryId] FROM [Customer] WHERE [CustomerId] = @CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000516,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000517", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000517,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000518", "SELECT [ShoppingCartId] FROM [ShoppingCart] WHERE [ShoppingCartId] = @ShoppingCartId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000518,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000519", "SELECT TOP 1 [ShoppingCartId] FROM [ShoppingCart] WHERE ( [ShoppingCartId] > @ShoppingCartId) ORDER BY [ShoppingCartId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000519,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000520", "SELECT TOP 1 [ShoppingCartId] FROM [ShoppingCart] WHERE ( [ShoppingCartId] < @ShoppingCartId) ORDER BY [ShoppingCartId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000520,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000521", "INSERT INTO [ShoppingCart]([ShoppingCartDate], [CustomerId]) VALUES(@ShoppingCartDate, @CustomerId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000521,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000522", "UPDATE [ShoppingCart] SET [ShoppingCartDate]=@ShoppingCartDate, [CustomerId]=@CustomerId  WHERE [ShoppingCartId] = @ShoppingCartId", GxErrorMask.GX_NOMASK,prmT000522)
             ,new CursorDef("T000523", "DELETE FROM [ShoppingCart]  WHERE [ShoppingCartId] = @ShoppingCartId", GxErrorMask.GX_NOMASK,prmT000523)
             ,new CursorDef("T000525", "SELECT COALESCE( T1.[ShoppingCartFinalPrice], 0) AS ShoppingCartFinalPrice FROM (SELECT SUM(CASE  WHEN T4.[CategoryName] = 'Joyería' THEN T2.[QtyProduct] * CAST(T3.[ProductPrice] AS decimal( 20, 10)) * CAST(( 1 + CAST(5 AS decimal( 13, 10)) / 100) AS decimal( 22, 10)) WHEN T4.[CategoryName] = 'Entretenimiento' THEN T2.[QtyProduct] * CAST(T3.[ProductPrice] AS decimal( 20, 10)) * CAST(( 1 - CAST(10 AS decimal( 13, 10)) / 100) AS decimal( 22, 10)) ELSE T2.[QtyProduct] * CAST(T3.[ProductPrice] AS decimal( 20, 10)) END) AS ShoppingCartFinalPrice, T2.[ShoppingCartId] FROM (([ShoppingCartProduct] T2 WITH (UPDLOCK) INNER JOIN [Product] T3 ON T3.[ProductId] = T2.[ProductId]) INNER JOIN [Category] T4 ON T4.[CategoryId] = T3.[CategoryId]) GROUP BY T2.[ShoppingCartId] ) T1 WHERE T1.[ShoppingCartId] = @ShoppingCartId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000525,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000526", "SELECT [CustomerName], [CustomerAddress], [CustomerPhone], [CountryId] FROM [Customer] WHERE [CustomerId] = @CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000526,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000527", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000527,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000528", "SELECT [ShoppingCartId] FROM [ShoppingCart] ORDER BY [ShoppingCartId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000528,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000529", "SELECT T1.[ShoppingCartId], T2.[ProductName], T2.[ProductPrice], T1.[QtyProduct], T3.[CategoryName], T1.[ProductId], T2.[CategoryId] FROM (([ShoppingCartProduct] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) INNER JOIN [Category] T3 ON T3.[CategoryId] = T2.[CategoryId]) WHERE T1.[ShoppingCartId] = @ShoppingCartId and T1.[ProductId] = @ProductId ORDER BY T1.[ShoppingCartId], T1.[ProductId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000529,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000530", "SELECT [ProductName], [ProductPrice], [CategoryId] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000530,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000531", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000531,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000532", "SELECT [ShoppingCartId], [ProductId] FROM [ShoppingCartProduct] WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000532,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000533", "INSERT INTO [ShoppingCartProduct]([ShoppingCartId], [QtyProduct], [ProductId]) VALUES(@ShoppingCartId, @QtyProduct, @ProductId)", GxErrorMask.GX_NOMASK,prmT000533)
             ,new CursorDef("T000534", "UPDATE [ShoppingCartProduct] SET [QtyProduct]=@QtyProduct  WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmT000534)
             ,new CursorDef("T000535", "DELETE FROM [ShoppingCartProduct]  WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmT000535)
             ,new CursorDef("T000536", "SELECT [ProductName], [ProductPrice], [CategoryId] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000536,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000537", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000537,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000538", "SELECT [ShoppingCartId], [ProductId] FROM [ShoppingCartProduct] WHERE [ShoppingCartId] = @ShoppingCartId ORDER BY [ShoppingCartId], [ProductId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000538,11, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 8 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                return;
             case 10 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
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
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 19 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 21 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 22 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
             case 24 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 25 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 26 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
       getresults30( cursor, rslt, buf) ;
    }

    public void getresults30( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 30 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 31 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 32 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
