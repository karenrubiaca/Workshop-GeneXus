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
   public class promotion : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A7ProductId = (short)(NumberUtil.Val( GetPar( "ProductId"), "."));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A7ProductId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridpromotion_product") == 0 )
         {
            gxnrGridpromotion_product_newrow_invoke( ) ;
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
            Form.Meta.addItem("description", "Promotion", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPromotionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridpromotion_product_newrow_invoke( )
      {
         nRC_GXsfl_63 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_63"), "."));
         nGXsfl_63_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_63_idx"), "."));
         sGXsfl_63_idx = GetPar( "sGXsfl_63_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridpromotion_product_newrow( ) ;
         /* End function gxnrGridpromotion_product_newrow_invoke */
      }

      public promotion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public promotion( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Promotion", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Promotion.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 4, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0060.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PROMOTIONID"+"'), id:'"+"PROMOTIONID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Promotion.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPromotionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPromotionId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPromotionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A10PromotionId), 4, 0, ".", "")), StringUtil.LTrim( ((edtPromotionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A10PromotionId), "ZZZ9") : context.localUtil.Format( (decimal)(A10PromotionId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromotionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPromotionId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPromotionDescrption_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPromotionDescrption_Internalname, "Descrption", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPromotionDescrption_Internalname, StringUtil.RTrim( A24PromotionDescrption), StringUtil.RTrim( context.localUtil.Format( A24PromotionDescrption, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromotionDescrption_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPromotionDescrption_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgPromotionPhoto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Photo", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A25PromotionPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A25PromotionPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000PromotionPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A25PromotionPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A25PromotionPhoto)) ? A40000PromotionPhoto_GXI : context.PathToRelativeUrl( A25PromotionPhoto));
         GxWebStd.gx_bitmap( context, imgPromotionPhoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgPromotionPhoto_Enabled, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", "", "", 0, A25PromotionPhoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Promotion.htm");
         AssignProp("", false, imgPromotionPhoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A25PromotionPhoto)) ? A40000PromotionPhoto_GXI : context.PathToRelativeUrl( A25PromotionPhoto)), true);
         AssignProp("", false, imgPromotionPhoto_Internalname, "IsBlob", StringUtil.BoolToStr( A25PromotionPhoto_IsBlob), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPromotionDateStart_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPromotionDateStart_Internalname, "Date Start", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPromotionDateStart_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPromotionDateStart_Internalname, context.localUtil.Format(A26PromotionDateStart, "99/99/99"), context.localUtil.Format( A26PromotionDateStart, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromotionDateStart_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPromotionDateStart_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Promotion.htm");
         GxWebStd.gx_bitmap( context, edtPromotionDateStart_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPromotionDateStart_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Promotion.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPromotionDateFinish_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPromotionDateFinish_Internalname, "Date Finish", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPromotionDateFinish_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPromotionDateFinish_Internalname, context.localUtil.Format(A27PromotionDateFinish, "99/99/99"), context.localUtil.Format( A27PromotionDateFinish, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromotionDateFinish_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPromotionDateFinish_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Promotion.htm");
         GxWebStd.gx_bitmap( context, edtPromotionDateFinish_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPromotionDateFinish_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Promotion.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         GxWebStd.gx_label_ctrl( context, lblTitleproduct_Internalname, "Product", "", "", lblTitleproduct_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridpromotion_product( ) ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridpromotion_product( )
      {
         /*  Grid Control  */
         StartGridControl63( ) ;
         nGXsfl_63_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount7 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_7 = 1;
               ScanStart077( ) ;
               while ( RcdFound7 != 0 )
               {
                  init_level_properties7( ) ;
                  getByPrimaryKey077( ) ;
                  AddRow077( ) ;
                  ScanNext077( ) ;
               }
               ScanEnd077( ) ;
               nBlankRcdCount7 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal077( ) ;
            standaloneModal077( ) ;
            sMode7 = Gx_mode;
            while ( nGXsfl_63_idx < nRC_GXsfl_63 )
            {
               bGXsfl_63_Refreshing = true;
               ReadRow077( ) ;
               edtProductId_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTID_"+sGXsfl_63_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
               edtProductName_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTNAME_"+sGXsfl_63_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), !bGXsfl_63_Refreshing);
               edtProductPrice_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTPRICE_"+sGXsfl_63_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtProductPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductPrice_Enabled), 5, 0), !bGXsfl_63_Refreshing);
               imgprompt_7_Link = cgiGet( "PROMPT_7_"+sGXsfl_63_idx+"Link");
               if ( ( nRcdExists_7 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal077( ) ;
               }
               SendRow077( ) ;
               bGXsfl_63_Refreshing = false;
            }
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount7 = 5;
            nRcdExists_7 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart077( ) ;
               while ( RcdFound7 != 0 )
               {
                  sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_637( ) ;
                  init_level_properties7( ) ;
                  standaloneNotModal077( ) ;
                  getByPrimaryKey077( ) ;
                  standaloneModal077( ) ;
                  AddRow077( ) ;
                  ScanNext077( ) ;
               }
               ScanEnd077( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode7 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx+1), 4, 0), 4, "0");
         SubsflControlProps_637( ) ;
         InitAll077( ) ;
         init_level_properties7( ) ;
         nRcdExists_7 = 0;
         nIsMod_7 = 0;
         nRcdDeleted_7 = 0;
         nBlankRcdCount7 = (short)(nBlankRcdUsr7+nBlankRcdCount7);
         fRowAdded = 0;
         while ( nBlankRcdCount7 > 0 )
         {
            standaloneNotModal077( ) ;
            standaloneModal077( ) ;
            AddRow077( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtProductId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount7 = (short)(nBlankRcdCount7-1);
         }
         Gx_mode = sMode7;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridpromotion_productContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridpromotion_product", Gridpromotion_productContainer, subGridpromotion_product_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridpromotion_productContainerData", Gridpromotion_productContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridpromotion_productContainerData"+"V", Gridpromotion_productContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridpromotion_productContainerData"+"V"+"\" value='"+Gridpromotion_productContainer.GridValuesHidden()+"'/>") ;
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
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z10PromotionId = (short)(context.localUtil.CToN( cgiGet( "Z10PromotionId"), ".", ","));
            Z24PromotionDescrption = cgiGet( "Z24PromotionDescrption");
            Z26PromotionDateStart = context.localUtil.CToD( cgiGet( "Z26PromotionDateStart"), 0);
            Z27PromotionDateFinish = context.localUtil.CToD( cgiGet( "Z27PromotionDateFinish"), 0);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_63 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_63"), ".", ","));
            A40000PromotionPhoto_GXI = cgiGet( "PROMOTIONPHOTO_GXI");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtPromotionId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPromotionId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROMOTIONID");
               AnyError = 1;
               GX_FocusControl = edtPromotionId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A10PromotionId = 0;
               AssignAttri("", false, "A10PromotionId", StringUtil.LTrimStr( (decimal)(A10PromotionId), 4, 0));
            }
            else
            {
               A10PromotionId = (short)(context.localUtil.CToN( cgiGet( edtPromotionId_Internalname), ".", ","));
               AssignAttri("", false, "A10PromotionId", StringUtil.LTrimStr( (decimal)(A10PromotionId), 4, 0));
            }
            A24PromotionDescrption = cgiGet( edtPromotionDescrption_Internalname);
            AssignAttri("", false, "A24PromotionDescrption", A24PromotionDescrption);
            A25PromotionPhoto = cgiGet( imgPromotionPhoto_Internalname);
            AssignAttri("", false, "A25PromotionPhoto", A25PromotionPhoto);
            if ( context.localUtil.VCDate( cgiGet( edtPromotionDateStart_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Promotion Date Start"}), 1, "PROMOTIONDATESTART");
               AnyError = 1;
               GX_FocusControl = edtPromotionDateStart_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A26PromotionDateStart = DateTime.MinValue;
               AssignAttri("", false, "A26PromotionDateStart", context.localUtil.Format(A26PromotionDateStart, "99/99/99"));
            }
            else
            {
               A26PromotionDateStart = context.localUtil.CToD( cgiGet( edtPromotionDateStart_Internalname), 1);
               AssignAttri("", false, "A26PromotionDateStart", context.localUtil.Format(A26PromotionDateStart, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtPromotionDateFinish_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Promotion Date Finish"}), 1, "PROMOTIONDATEFINISH");
               AnyError = 1;
               GX_FocusControl = edtPromotionDateFinish_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A27PromotionDateFinish = DateTime.MinValue;
               AssignAttri("", false, "A27PromotionDateFinish", context.localUtil.Format(A27PromotionDateFinish, "99/99/99"));
            }
            else
            {
               A27PromotionDateFinish = context.localUtil.CToD( cgiGet( edtPromotionDateFinish_Internalname), 1);
               AssignAttri("", false, "A27PromotionDateFinish", context.localUtil.Format(A27PromotionDateFinish, "99/99/99"));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            getMultimediaValue(imgPromotionPhoto_Internalname, ref  A25PromotionPhoto, ref  A40000PromotionPhoto_GXI);
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
               A10PromotionId = (short)(NumberUtil.Val( GetPar( "PromotionId"), "."));
               AssignAttri("", false, "A10PromotionId", StringUtil.LTrimStr( (decimal)(A10PromotionId), 4, 0));
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
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll076( ) ;
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
         DisableAttributes076( ) ;
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

      protected void CONFIRM_077( )
      {
         nGXsfl_63_idx = 0;
         while ( nGXsfl_63_idx < nRC_GXsfl_63 )
         {
            ReadRow077( ) ;
            if ( ( nRcdExists_7 != 0 ) || ( nIsMod_7 != 0 ) )
            {
               GetKey077( ) ;
               if ( ( nRcdExists_7 == 0 ) && ( nRcdDeleted_7 == 0 ) )
               {
                  if ( RcdFound7 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate077( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable077( ) ;
                        CloseExtendedTableCursors077( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "PRODUCTID_" + sGXsfl_63_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtProductId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound7 != 0 )
                  {
                     if ( nRcdDeleted_7 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey077( ) ;
                        Load077( ) ;
                        BeforeValidate077( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls077( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_7 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate077( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable077( ) ;
                              CloseExtendedTableCursors077( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_7 == 0 )
                     {
                        GXCCtl = "PRODUCTID_" + sGXsfl_63_idx;
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
            ChangePostValue( "ZT_"+"Z7ProductId_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7ProductId), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_7_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_7), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_7_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_7), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_7_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_7), 4, 0, ".", ""))) ;
            if ( nIsMod_7 != 0 )
            {
               ChangePostValue( "PRODUCTID_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTNAME_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTPRICE_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductPrice_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption070( )
      {
      }

      protected void ZM076( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z24PromotionDescrption = T00076_A24PromotionDescrption[0];
               Z26PromotionDateStart = T00076_A26PromotionDateStart[0];
               Z27PromotionDateFinish = T00076_A27PromotionDateFinish[0];
            }
            else
            {
               Z24PromotionDescrption = A24PromotionDescrption;
               Z26PromotionDateStart = A26PromotionDateStart;
               Z27PromotionDateFinish = A27PromotionDateFinish;
            }
         }
         if ( GX_JID == -4 )
         {
            Z10PromotionId = A10PromotionId;
            Z24PromotionDescrption = A24PromotionDescrption;
            Z25PromotionPhoto = A25PromotionPhoto;
            Z40000PromotionPhoto_GXI = A40000PromotionPhoto_GXI;
            Z26PromotionDateStart = A26PromotionDateStart;
            Z27PromotionDateFinish = A27PromotionDateFinish;
         }
      }

      protected void standaloneNotModal( )
      {
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

      protected void Load076( )
      {
         /* Using cursor T00077 */
         pr_default.execute(5, new Object[] {A10PromotionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound6 = 1;
            A24PromotionDescrption = T00077_A24PromotionDescrption[0];
            AssignAttri("", false, "A24PromotionDescrption", A24PromotionDescrption);
            A40000PromotionPhoto_GXI = T00077_A40000PromotionPhoto_GXI[0];
            AssignProp("", false, imgPromotionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A25PromotionPhoto)) ? A40000PromotionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A25PromotionPhoto))), true);
            AssignProp("", false, imgPromotionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A25PromotionPhoto), true);
            A26PromotionDateStart = T00077_A26PromotionDateStart[0];
            AssignAttri("", false, "A26PromotionDateStart", context.localUtil.Format(A26PromotionDateStart, "99/99/99"));
            A27PromotionDateFinish = T00077_A27PromotionDateFinish[0];
            AssignAttri("", false, "A27PromotionDateFinish", context.localUtil.Format(A27PromotionDateFinish, "99/99/99"));
            A25PromotionPhoto = T00077_A25PromotionPhoto[0];
            AssignAttri("", false, "A25PromotionPhoto", A25PromotionPhoto);
            AssignProp("", false, imgPromotionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A25PromotionPhoto)) ? A40000PromotionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A25PromotionPhoto))), true);
            AssignProp("", false, imgPromotionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A25PromotionPhoto), true);
            ZM076( -4) ;
         }
         pr_default.close(5);
         OnLoadActions076( ) ;
      }

      protected void OnLoadActions076( )
      {
      }

      protected void CheckExtendedTable076( )
      {
         nIsDirty_6 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A26PromotionDateStart) || ( DateTimeUtil.ResetTime ( A26PromotionDateStart ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Promotion Date Start is out of range", "OutOfRange", 1, "PROMOTIONDATESTART");
            AnyError = 1;
            GX_FocusControl = edtPromotionDateStart_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( DateTimeUtil.ResetTime ( A26PromotionDateStart ) > DateTimeUtil.ResetTime ( A27PromotionDateFinish ) )
         {
            GX_msglist.addItem("The dateStart cannot be higher than datefinish", 1, "PROMOTIONDATESTART");
            AnyError = 1;
            GX_FocusControl = edtPromotionDateStart_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A27PromotionDateFinish) || ( DateTimeUtil.ResetTime ( A27PromotionDateFinish ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Promotion Date Finish is out of range", "OutOfRange", 1, "PROMOTIONDATEFINISH");
            AnyError = 1;
            GX_FocusControl = edtPromotionDateFinish_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors076( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey076( )
      {
         /* Using cursor T00078 */
         pr_default.execute(6, new Object[] {A10PromotionId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00076 */
         pr_default.execute(4, new Object[] {A10PromotionId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM076( 4) ;
            RcdFound6 = 1;
            A10PromotionId = T00076_A10PromotionId[0];
            AssignAttri("", false, "A10PromotionId", StringUtil.LTrimStr( (decimal)(A10PromotionId), 4, 0));
            A24PromotionDescrption = T00076_A24PromotionDescrption[0];
            AssignAttri("", false, "A24PromotionDescrption", A24PromotionDescrption);
            A40000PromotionPhoto_GXI = T00076_A40000PromotionPhoto_GXI[0];
            AssignProp("", false, imgPromotionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A25PromotionPhoto)) ? A40000PromotionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A25PromotionPhoto))), true);
            AssignProp("", false, imgPromotionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A25PromotionPhoto), true);
            A26PromotionDateStart = T00076_A26PromotionDateStart[0];
            AssignAttri("", false, "A26PromotionDateStart", context.localUtil.Format(A26PromotionDateStart, "99/99/99"));
            A27PromotionDateFinish = T00076_A27PromotionDateFinish[0];
            AssignAttri("", false, "A27PromotionDateFinish", context.localUtil.Format(A27PromotionDateFinish, "99/99/99"));
            A25PromotionPhoto = T00076_A25PromotionPhoto[0];
            AssignAttri("", false, "A25PromotionPhoto", A25PromotionPhoto);
            AssignProp("", false, imgPromotionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A25PromotionPhoto)) ? A40000PromotionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A25PromotionPhoto))), true);
            AssignProp("", false, imgPromotionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A25PromotionPhoto), true);
            Z10PromotionId = A10PromotionId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load076( ) ;
            if ( AnyError == 1 )
            {
               RcdFound6 = 0;
               InitializeNonKey076( ) ;
            }
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey076( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey076( ) ;
         if ( RcdFound6 == 0 )
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
         RcdFound6 = 0;
         /* Using cursor T00079 */
         pr_default.execute(7, new Object[] {A10PromotionId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00079_A10PromotionId[0] < A10PromotionId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00079_A10PromotionId[0] > A10PromotionId ) ) )
            {
               A10PromotionId = T00079_A10PromotionId[0];
               AssignAttri("", false, "A10PromotionId", StringUtil.LTrimStr( (decimal)(A10PromotionId), 4, 0));
               RcdFound6 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound6 = 0;
         /* Using cursor T000710 */
         pr_default.execute(8, new Object[] {A10PromotionId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000710_A10PromotionId[0] > A10PromotionId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000710_A10PromotionId[0] < A10PromotionId ) ) )
            {
               A10PromotionId = T000710_A10PromotionId[0];
               AssignAttri("", false, "A10PromotionId", StringUtil.LTrimStr( (decimal)(A10PromotionId), 4, 0));
               RcdFound6 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey076( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPromotionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert076( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound6 == 1 )
            {
               if ( A10PromotionId != Z10PromotionId )
               {
                  A10PromotionId = Z10PromotionId;
                  AssignAttri("", false, "A10PromotionId", StringUtil.LTrimStr( (decimal)(A10PromotionId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROMOTIONID");
                  AnyError = 1;
                  GX_FocusControl = edtPromotionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPromotionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update076( ) ;
                  GX_FocusControl = edtPromotionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A10PromotionId != Z10PromotionId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPromotionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert076( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROMOTIONID");
                     AnyError = 1;
                     GX_FocusControl = edtPromotionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtPromotionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert076( ) ;
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
         if ( A10PromotionId != Z10PromotionId )
         {
            A10PromotionId = Z10PromotionId;
            AssignAttri("", false, "A10PromotionId", StringUtil.LTrimStr( (decimal)(A10PromotionId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROMOTIONID");
            AnyError = 1;
            GX_FocusControl = edtPromotionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPromotionId_Internalname;
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
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PROMOTIONID");
            AnyError = 1;
            GX_FocusControl = edtPromotionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtPromotionDescrption_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart076( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPromotionDescrption_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd076( ) ;
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
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPromotionDescrption_Internalname;
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
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPromotionDescrption_Internalname;
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
         ScanStart076( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound6 != 0 )
            {
               ScanNext076( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPromotionDescrption_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd076( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency076( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00075 */
            pr_default.execute(3, new Object[] {A10PromotionId});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Promotion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z24PromotionDescrption, T00075_A24PromotionDescrption[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z26PromotionDateStart ) != DateTimeUtil.ResetTime ( T00075_A26PromotionDateStart[0] ) ) || ( DateTimeUtil.ResetTime ( Z27PromotionDateFinish ) != DateTimeUtil.ResetTime ( T00075_A27PromotionDateFinish[0] ) ) )
            {
               if ( StringUtil.StrCmp(Z24PromotionDescrption, T00075_A24PromotionDescrption[0]) != 0 )
               {
                  GXUtil.WriteLog("promotion:[seudo value changed for attri]"+"PromotionDescrption");
                  GXUtil.WriteLogRaw("Old: ",Z24PromotionDescrption);
                  GXUtil.WriteLogRaw("Current: ",T00075_A24PromotionDescrption[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z26PromotionDateStart ) != DateTimeUtil.ResetTime ( T00075_A26PromotionDateStart[0] ) )
               {
                  GXUtil.WriteLog("promotion:[seudo value changed for attri]"+"PromotionDateStart");
                  GXUtil.WriteLogRaw("Old: ",Z26PromotionDateStart);
                  GXUtil.WriteLogRaw("Current: ",T00075_A26PromotionDateStart[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z27PromotionDateFinish ) != DateTimeUtil.ResetTime ( T00075_A27PromotionDateFinish[0] ) )
               {
                  GXUtil.WriteLog("promotion:[seudo value changed for attri]"+"PromotionDateFinish");
                  GXUtil.WriteLogRaw("Old: ",Z27PromotionDateFinish);
                  GXUtil.WriteLogRaw("Current: ",T00075_A27PromotionDateFinish[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Promotion"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert076( )
      {
         BeforeValidate076( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable076( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM076( 0) ;
            CheckOptimisticConcurrency076( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm076( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert076( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000711 */
                     pr_default.execute(9, new Object[] {A24PromotionDescrption, A25PromotionPhoto, A40000PromotionPhoto_GXI, A26PromotionDateStart, A27PromotionDateFinish});
                     A10PromotionId = T000711_A10PromotionId[0];
                     AssignAttri("", false, "A10PromotionId", StringUtil.LTrimStr( (decimal)(A10PromotionId), 4, 0));
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("Promotion");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel076( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption070( ) ;
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
               Load076( ) ;
            }
            EndLevel076( ) ;
         }
         CloseExtendedTableCursors076( ) ;
      }

      protected void Update076( )
      {
         BeforeValidate076( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable076( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency076( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm076( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate076( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000712 */
                     pr_default.execute(10, new Object[] {A24PromotionDescrption, A26PromotionDateStart, A27PromotionDateFinish, A10PromotionId});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("Promotion");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Promotion"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate076( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel076( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption070( ) ;
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
            EndLevel076( ) ;
         }
         CloseExtendedTableCursors076( ) ;
      }

      protected void DeferredUpdate076( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000713 */
            pr_default.execute(11, new Object[] {A25PromotionPhoto, A40000PromotionPhoto_GXI, A10PromotionId});
            pr_default.close(11);
            dsDefault.SmartCacheProvider.SetUpdated("Promotion");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate076( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency076( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls076( ) ;
            AfterConfirm076( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete076( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart077( ) ;
                  while ( RcdFound7 != 0 )
                  {
                     getByPrimaryKey077( ) ;
                     Delete077( ) ;
                     ScanNext077( ) ;
                  }
                  ScanEnd077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000714 */
                     pr_default.execute(12, new Object[] {A10PromotionId});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("Promotion");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound6 == 0 )
                           {
                              InitAll076( ) ;
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
                           ResetCaption070( ) ;
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
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel076( ) ;
         Gx_mode = sMode6;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls076( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void ProcessNestedLevel077( )
      {
         nGXsfl_63_idx = 0;
         while ( nGXsfl_63_idx < nRC_GXsfl_63 )
         {
            ReadRow077( ) ;
            if ( ( nRcdExists_7 != 0 ) || ( nIsMod_7 != 0 ) )
            {
               standaloneNotModal077( ) ;
               GetKey077( ) ;
               if ( ( nRcdExists_7 == 0 ) && ( nRcdDeleted_7 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert077( ) ;
               }
               else
               {
                  if ( RcdFound7 != 0 )
                  {
                     if ( ( nRcdDeleted_7 != 0 ) && ( nRcdExists_7 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete077( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_7 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update077( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_7 == 0 )
                     {
                        GXCCtl = "PRODUCTID_" + sGXsfl_63_idx;
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
            ChangePostValue( "ZT_"+"Z7ProductId_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7ProductId), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_7_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_7), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_7_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_7), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_7_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_7), 4, 0, ".", ""))) ;
            if ( nIsMod_7 != 0 )
            {
               ChangePostValue( "PRODUCTID_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTNAME_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTPRICE_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductPrice_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll077( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_7 = 0;
         nIsMod_7 = 0;
         nRcdDeleted_7 = 0;
      }

      protected void ProcessLevel076( )
      {
         /* Save parent mode. */
         sMode6 = Gx_mode;
         ProcessNestedLevel077( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode6;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel076( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete076( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.CommitDataStores("promotion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues070( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.RollbackDataStores("promotion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart076( )
      {
         /* Using cursor T000715 */
         pr_default.execute(13);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound6 = 1;
            A10PromotionId = T000715_A10PromotionId[0];
            AssignAttri("", false, "A10PromotionId", StringUtil.LTrimStr( (decimal)(A10PromotionId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext076( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound6 = 1;
            A10PromotionId = T000715_A10PromotionId[0];
            AssignAttri("", false, "A10PromotionId", StringUtil.LTrimStr( (decimal)(A10PromotionId), 4, 0));
         }
      }

      protected void ScanEnd076( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm076( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert076( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate076( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete076( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete076( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate076( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes076( )
      {
         edtPromotionId_Enabled = 0;
         AssignProp("", false, edtPromotionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromotionId_Enabled), 5, 0), true);
         edtPromotionDescrption_Enabled = 0;
         AssignProp("", false, edtPromotionDescrption_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromotionDescrption_Enabled), 5, 0), true);
         imgPromotionPhoto_Enabled = 0;
         AssignProp("", false, imgPromotionPhoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgPromotionPhoto_Enabled), 5, 0), true);
         edtPromotionDateStart_Enabled = 0;
         AssignProp("", false, edtPromotionDateStart_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromotionDateStart_Enabled), 5, 0), true);
         edtPromotionDateFinish_Enabled = 0;
         AssignProp("", false, edtPromotionDateFinish_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromotionDateFinish_Enabled), 5, 0), true);
      }

      protected void ZM077( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -5 )
         {
            Z10PromotionId = A10PromotionId;
            Z7ProductId = A7ProductId;
            Z8ProductName = A8ProductName;
            Z22ProductPrice = A22ProductPrice;
         }
      }

      protected void standaloneNotModal077( )
      {
      }

      protected void standaloneModal077( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtProductId_Enabled = 0;
            AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         }
         else
         {
            edtProductId_Enabled = 1;
            AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         }
      }

      protected void Load077( )
      {
         /* Using cursor T000716 */
         pr_default.execute(14, new Object[] {A10PromotionId, A7ProductId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound7 = 1;
            A8ProductName = T000716_A8ProductName[0];
            A22ProductPrice = T000716_A22ProductPrice[0];
            ZM077( -5) ;
         }
         pr_default.close(14);
         OnLoadActions077( ) ;
      }

      protected void OnLoadActions077( )
      {
      }

      protected void CheckExtendedTable077( )
      {
         nIsDirty_7 = 0;
         Gx_BScreen = 1;
         standaloneModal077( ) ;
         /* Using cursor T00074 */
         pr_default.execute(2, new Object[] {A7ProductId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_63_idx;
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A8ProductName = T00074_A8ProductName[0];
         A22ProductPrice = T00074_A22ProductPrice[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors077( )
      {
         pr_default.close(2);
      }

      protected void enableDisable077( )
      {
      }

      protected void gxLoad_6( short A7ProductId )
      {
         /* Using cursor T000717 */
         pr_default.execute(15, new Object[] {A7ProductId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_63_idx;
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A8ProductName = T000717_A8ProductName[0];
         A22ProductPrice = T000717_A22ProductPrice[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A8ProductName))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A22ProductPrice, 10, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(15) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(15);
      }

      protected void GetKey077( )
      {
         /* Using cursor T000718 */
         pr_default.execute(16, new Object[] {A10PromotionId, A7ProductId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(16);
      }

      protected void getByPrimaryKey077( )
      {
         /* Using cursor T00073 */
         pr_default.execute(1, new Object[] {A10PromotionId, A7ProductId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM077( 5) ;
            RcdFound7 = 1;
            InitializeNonKey077( ) ;
            A7ProductId = T00073_A7ProductId[0];
            Z10PromotionId = A10PromotionId;
            Z7ProductId = A7ProductId;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal077( ) ;
            Load077( ) ;
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey077( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal077( ) ;
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes077( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency077( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00072 */
            pr_default.execute(0, new Object[] {A10PromotionId, A7ProductId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PromotionProduct"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PromotionProduct"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert077( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM077( 0) ;
            CheckOptimisticConcurrency077( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm077( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000719 */
                     pr_default.execute(17, new Object[] {A10PromotionId, A7ProductId});
                     pr_default.close(17);
                     dsDefault.SmartCacheProvider.SetUpdated("PromotionProduct");
                     if ( (pr_default.getStatus(17) == 1) )
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
               Load077( ) ;
            }
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void Update077( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( ( nIsMod_7 != 0 ) || ( nIsDirty_7 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency077( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm077( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate077( ) ;
                     if ( AnyError == 0 )
                     {
                        /* No attributes to update on table [PromotionProduct] */
                        DeferredUpdate077( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey077( ) ;
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
               EndLevel077( ) ;
            }
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void DeferredUpdate077( )
      {
      }

      protected void Delete077( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency077( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls077( ) ;
            AfterConfirm077( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete077( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000720 */
                  pr_default.execute(18, new Object[] {A10PromotionId, A7ProductId});
                  pr_default.close(18);
                  dsDefault.SmartCacheProvider.SetUpdated("PromotionProduct");
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
         sMode7 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel077( ) ;
         Gx_mode = sMode7;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls077( )
      {
         standaloneModal077( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000721 */
            pr_default.execute(19, new Object[] {A7ProductId});
            A8ProductName = T000721_A8ProductName[0];
            A22ProductPrice = T000721_A22ProductPrice[0];
            pr_default.close(19);
         }
      }

      protected void EndLevel077( )
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

      public void ScanStart077( )
      {
         /* Scan By routine */
         /* Using cursor T000722 */
         pr_default.execute(20, new Object[] {A10PromotionId});
         RcdFound7 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound7 = 1;
            A7ProductId = T000722_A7ProductId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext077( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound7 = 1;
            A7ProductId = T000722_A7ProductId[0];
         }
      }

      protected void ScanEnd077( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm077( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert077( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate077( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete077( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete077( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate077( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes077( )
      {
         edtProductId_Enabled = 0;
         AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         edtProductName_Enabled = 0;
         AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         edtProductPrice_Enabled = 0;
         AssignProp("", false, edtProductPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductPrice_Enabled), 5, 0), !bGXsfl_63_Refreshing);
      }

      protected void send_integrity_lvl_hashes077( )
      {
      }

      protected void send_integrity_lvl_hashes076( )
      {
      }

      protected void SubsflControlProps_637( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_63_idx;
         imgprompt_7_Internalname = "PROMPT_7_"+sGXsfl_63_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_63_idx;
         edtProductPrice_Internalname = "PRODUCTPRICE_"+sGXsfl_63_idx;
      }

      protected void SubsflControlProps_fel_637( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_63_fel_idx;
         imgprompt_7_Internalname = "PROMPT_7_"+sGXsfl_63_fel_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_63_fel_idx;
         edtProductPrice_Internalname = "PRODUCTPRICE_"+sGXsfl_63_fel_idx;
      }

      protected void AddRow077( )
      {
         nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
         SubsflControlProps_637( ) ;
         SendRow077( ) ;
      }

      protected void SendRow077( )
      {
         Gridpromotion_productRow = GXWebRow.GetNew(context);
         if ( subGridpromotion_product_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridpromotion_product_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridpromotion_product_Class, "") != 0 )
            {
               subGridpromotion_product_Linesclass = subGridpromotion_product_Class+"Odd";
            }
         }
         else if ( subGridpromotion_product_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridpromotion_product_Backstyle = 0;
            subGridpromotion_product_Backcolor = subGridpromotion_product_Allbackcolor;
            if ( StringUtil.StrCmp(subGridpromotion_product_Class, "") != 0 )
            {
               subGridpromotion_product_Linesclass = subGridpromotion_product_Class+"Uniform";
            }
         }
         else if ( subGridpromotion_product_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridpromotion_product_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridpromotion_product_Class, "") != 0 )
            {
               subGridpromotion_product_Linesclass = subGridpromotion_product_Class+"Odd";
            }
            subGridpromotion_product_Backcolor = (int)(0x0);
         }
         else if ( subGridpromotion_product_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridpromotion_product_Backstyle = 1;
            if ( ((int)((nGXsfl_63_idx) % (2))) == 0 )
            {
               subGridpromotion_product_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridpromotion_product_Class, "") != 0 )
               {
                  subGridpromotion_product_Linesclass = subGridpromotion_product_Class+"Even";
               }
            }
            else
            {
               subGridpromotion_product_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridpromotion_product_Class, "") != 0 )
               {
                  subGridpromotion_product_Linesclass = subGridpromotion_product_Class+"Odd";
               }
            }
         }
         imgprompt_7_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0050.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRODUCTID_"+sGXsfl_63_idx+"'), id:'"+"PRODUCTID_"+sGXsfl_63_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_7_"+sGXsfl_63_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_7_" + sGXsfl_63_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_63_idx + "',63)\"";
         ROClassString = "Attribute";
         Gridpromotion_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A7ProductId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A7ProductId), "ZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,64);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)63,(short)1,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         Gridpromotion_productRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_7_Internalname,(string)sImgUrl,(string)imgprompt_7_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_7_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridpromotion_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductName_Internalname,StringUtil.RTrim( A8ProductName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)63,(short)1,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridpromotion_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A22ProductPrice, 12, 2, ".", "")),StringUtil.LTrim( ((edtProductPrice_Enabled!=0) ? context.localUtil.Format( A22ProductPrice, "$ ZZZZZZ9.99") : context.localUtil.Format( A22ProductPrice, "$ ZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductPrice_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)63,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridpromotion_productRow);
         send_integrity_lvl_hashes077( ) ;
         GXCCtl = "Z7ProductId_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7ProductId), 4, 0, ".", "")));
         GXCCtl = "nRcdDeleted_7_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_7), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_7_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_7), 4, 0, ".", "")));
         GXCCtl = "nIsMod_7_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_7), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTID_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTNAME_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTPRICE_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductPrice_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_7_"+sGXsfl_63_idx+"Link", StringUtil.RTrim( imgprompt_7_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridpromotion_productContainer.AddRow(Gridpromotion_productRow);
      }

      protected void ReadRow077( )
      {
         nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
         SubsflControlProps_637( ) ;
         edtProductId_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTID_"+sGXsfl_63_idx+"Enabled"), ".", ","));
         edtProductName_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTNAME_"+sGXsfl_63_idx+"Enabled"), ".", ","));
         edtProductPrice_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTPRICE_"+sGXsfl_63_idx+"Enabled"), ".", ","));
         imgprompt_7_Link = cgiGet( "PROMPT_7_"+sGXsfl_63_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_63_idx;
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
         GXCCtl = "Z7ProductId_" + sGXsfl_63_idx;
         Z7ProductId = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdDeleted_7_" + sGXsfl_63_idx;
         nRcdDeleted_7 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_7_" + sGXsfl_63_idx;
         nRcdExists_7 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nIsMod_7_" + sGXsfl_63_idx;
         nIsMod_7 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
      }

      protected void assign_properties_default( )
      {
         defedtProductId_Enabled = edtProductId_Enabled;
      }

      protected void ConfirmValues070( )
      {
         nGXsfl_63_idx = 0;
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
         SubsflControlProps_637( ) ;
         while ( nGXsfl_63_idx < nRC_GXsfl_63 )
         {
            nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
            sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
            SubsflControlProps_637( ) ;
            ChangePostValue( "Z7ProductId_"+sGXsfl_63_idx, cgiGet( "ZT_"+"Z7ProductId_"+sGXsfl_63_idx)) ;
            DeletePostValue( "ZT_"+"Z7ProductId_"+sGXsfl_63_idx) ;
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("promotion.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z10PromotionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10PromotionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z24PromotionDescrption", StringUtil.RTrim( Z24PromotionDescrption));
         GxWebStd.gx_hidden_field( context, "Z26PromotionDateStart", context.localUtil.DToC( Z26PromotionDateStart, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z27PromotionDateFinish", context.localUtil.DToC( Z27PromotionDateFinish, 0, "/"));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_63", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_63_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMOTIONPHOTO_GXI", A40000PromotionPhoto_GXI);
         GXCCtlgxBlob = "PROMOTIONPHOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A25PromotionPhoto);
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
         return formatLink("promotion.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Promotion" ;
      }

      public override string GetPgmdesc( )
      {
         return "Promotion" ;
      }

      protected void InitializeNonKey076( )
      {
         A24PromotionDescrption = "";
         AssignAttri("", false, "A24PromotionDescrption", A24PromotionDescrption);
         A25PromotionPhoto = "";
         AssignAttri("", false, "A25PromotionPhoto", A25PromotionPhoto);
         AssignProp("", false, imgPromotionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A25PromotionPhoto)) ? A40000PromotionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A25PromotionPhoto))), true);
         AssignProp("", false, imgPromotionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A25PromotionPhoto), true);
         A40000PromotionPhoto_GXI = "";
         AssignProp("", false, imgPromotionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A25PromotionPhoto)) ? A40000PromotionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A25PromotionPhoto))), true);
         AssignProp("", false, imgPromotionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A25PromotionPhoto), true);
         A26PromotionDateStart = DateTime.MinValue;
         AssignAttri("", false, "A26PromotionDateStart", context.localUtil.Format(A26PromotionDateStart, "99/99/99"));
         A27PromotionDateFinish = DateTime.MinValue;
         AssignAttri("", false, "A27PromotionDateFinish", context.localUtil.Format(A27PromotionDateFinish, "99/99/99"));
         Z24PromotionDescrption = "";
         Z26PromotionDateStart = DateTime.MinValue;
         Z27PromotionDateFinish = DateTime.MinValue;
      }

      protected void InitAll076( )
      {
         A10PromotionId = 0;
         AssignAttri("", false, "A10PromotionId", StringUtil.LTrimStr( (decimal)(A10PromotionId), 4, 0));
         InitializeNonKey076( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey077( )
      {
         A8ProductName = "";
         A22ProductPrice = 0;
      }

      protected void InitAll077( )
      {
         A7ProductId = 0;
         InitializeNonKey077( ) ;
      }

      protected void StandaloneModalInsert077( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202211130482682", true, true);
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
         context.AddJavascriptSource("promotion.js", "?202211130482682", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties7( )
      {
         edtProductId_Enabled = defedtProductId_Enabled;
         AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
      }

      protected void StartGridControl63( )
      {
         Gridpromotion_productContainer.AddObjectProperty("GridName", "Gridpromotion_product");
         Gridpromotion_productContainer.AddObjectProperty("Header", subGridpromotion_product_Header);
         Gridpromotion_productContainer.AddObjectProperty("Class", "Grid");
         Gridpromotion_productContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridpromotion_productContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridpromotion_productContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromotion_product_Backcolorstyle), 1, 0, ".", "")));
         Gridpromotion_productContainer.AddObjectProperty("CmpContext", "");
         Gridpromotion_productContainer.AddObjectProperty("InMasterPage", "false");
         Gridpromotion_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpromotion_productColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7ProductId), 4, 0, ".", "")));
         Gridpromotion_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", "")));
         Gridpromotion_productContainer.AddColumnProperties(Gridpromotion_productColumn);
         Gridpromotion_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpromotion_productContainer.AddColumnProperties(Gridpromotion_productColumn);
         Gridpromotion_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpromotion_productColumn.AddObjectProperty("Value", StringUtil.RTrim( A8ProductName));
         Gridpromotion_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", "")));
         Gridpromotion_productContainer.AddColumnProperties(Gridpromotion_productColumn);
         Gridpromotion_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpromotion_productColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A22ProductPrice, 12, 2, ".", "")));
         Gridpromotion_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductPrice_Enabled), 5, 0, ".", "")));
         Gridpromotion_productContainer.AddColumnProperties(Gridpromotion_productColumn);
         Gridpromotion_productContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromotion_product_Selectedindex), 4, 0, ".", "")));
         Gridpromotion_productContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromotion_product_Allowselection), 1, 0, ".", "")));
         Gridpromotion_productContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromotion_product_Selectioncolor), 9, 0, ".", "")));
         Gridpromotion_productContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromotion_product_Allowhovering), 1, 0, ".", "")));
         Gridpromotion_productContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromotion_product_Hoveringcolor), 9, 0, ".", "")));
         Gridpromotion_productContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromotion_product_Allowcollapsing), 1, 0, ".", "")));
         Gridpromotion_productContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromotion_product_Collapsed), 1, 0, ".", "")));
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
         edtPromotionId_Internalname = "PROMOTIONID";
         edtPromotionDescrption_Internalname = "PROMOTIONDESCRPTION";
         imgPromotionPhoto_Internalname = "PROMOTIONPHOTO";
         edtPromotionDateStart_Internalname = "PROMOTIONDATESTART";
         edtPromotionDateFinish_Internalname = "PROMOTIONDATEFINISH";
         lblTitleproduct_Internalname = "TITLEPRODUCT";
         edtProductId_Internalname = "PRODUCTID";
         edtProductName_Internalname = "PRODUCTNAME";
         edtProductPrice_Internalname = "PRODUCTPRICE";
         divProducttable_Internalname = "PRODUCTTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_7_Internalname = "PROMPT_7";
         subGridpromotion_product_Internalname = "GRIDPROMOTION_PRODUCT";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridpromotion_product_Allowcollapsing = 0;
         subGridpromotion_product_Allowselection = 0;
         subGridpromotion_product_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Promotion";
         edtProductPrice_Jsonclick = "";
         edtProductName_Jsonclick = "";
         imgprompt_7_Visible = 1;
         imgprompt_7_Link = "";
         imgprompt_7_Visible = 1;
         edtProductId_Jsonclick = "";
         subGridpromotion_product_Class = "Grid";
         subGridpromotion_product_Backcolorstyle = 0;
         edtProductPrice_Enabled = 0;
         edtProductName_Enabled = 0;
         edtProductId_Enabled = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPromotionDateFinish_Jsonclick = "";
         edtPromotionDateFinish_Enabled = 1;
         edtPromotionDateStart_Jsonclick = "";
         edtPromotionDateStart_Enabled = 1;
         imgPromotionPhoto_Enabled = 1;
         edtPromotionDescrption_Jsonclick = "";
         edtPromotionDescrption_Enabled = 1;
         edtPromotionId_Jsonclick = "";
         edtPromotionId_Enabled = 1;
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

      protected void gxnrGridpromotion_product_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_637( ) ;
         while ( nGXsfl_63_idx <= nRC_GXsfl_63 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal077( ) ;
            standaloneModal077( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow077( ) ;
            nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
            sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
            SubsflControlProps_637( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridpromotion_productContainer)) ;
         /* End function gxnrGridpromotion_product_newrow */
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
         GX_FocusControl = edtPromotionDescrption_Internalname;
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

      public void Valid_Promotionid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A24PromotionDescrption", StringUtil.RTrim( A24PromotionDescrption));
         AssignAttri("", false, "A25PromotionPhoto", context.PathToRelativeUrl( A25PromotionPhoto));
         GXCCtlgxBlob = "PROMOTIONPHOTO" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A25PromotionPhoto));
         AssignAttri("", false, "A40000PromotionPhoto_GXI", A40000PromotionPhoto_GXI);
         AssignAttri("", false, "A26PromotionDateStart", context.localUtil.Format(A26PromotionDateStart, "99/99/99"));
         AssignAttri("", false, "A27PromotionDateFinish", context.localUtil.Format(A27PromotionDateFinish, "99/99/99"));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z10PromotionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10PromotionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z24PromotionDescrption", StringUtil.RTrim( Z24PromotionDescrption));
         GxWebStd.gx_hidden_field( context, "Z25PromotionPhoto", context.PathToRelativeUrl( Z25PromotionPhoto));
         GxWebStd.gx_hidden_field( context, "Z40000PromotionPhoto_GXI", Z40000PromotionPhoto_GXI);
         GxWebStd.gx_hidden_field( context, "Z26PromotionDateStart", context.localUtil.Format(Z26PromotionDateStart, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z27PromotionDateFinish", context.localUtil.Format(Z27PromotionDateFinish, "99/99/99"));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Productid( )
      {
         /* Using cursor T000721 */
         pr_default.execute(19, new Object[] {A7ProductId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, "PRODUCTID");
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
         }
         A8ProductName = T000721_A8ProductName[0];
         A22ProductPrice = T000721_A22ProductPrice[0];
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A8ProductName", StringUtil.RTrim( A8ProductName));
         AssignAttri("", false, "A22ProductPrice", StringUtil.LTrim( StringUtil.NToC( A22ProductPrice, 10, 2, ".", "")));
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
         setEventMetadata("VALID_PROMOTIONID","{handler:'Valid_Promotionid',iparms:[{av:'A10PromotionId',fld:'PROMOTIONID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PROMOTIONID",",oparms:[{av:'A24PromotionDescrption',fld:'PROMOTIONDESCRPTION',pic:''},{av:'A25PromotionPhoto',fld:'PROMOTIONPHOTO',pic:''},{av:'A40000PromotionPhoto_GXI',fld:'PROMOTIONPHOTO_GXI',pic:''},{av:'A26PromotionDateStart',fld:'PROMOTIONDATESTART',pic:''},{av:'A27PromotionDateFinish',fld:'PROMOTIONDATEFINISH',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z10PromotionId'},{av:'Z24PromotionDescrption'},{av:'Z25PromotionPhoto'},{av:'Z40000PromotionPhoto_GXI'},{av:'Z26PromotionDateStart'},{av:'Z27PromotionDateFinish'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_PROMOTIONDATESTART","{handler:'Valid_Promotiondatestart',iparms:[]");
         setEventMetadata("VALID_PROMOTIONDATESTART",",oparms:[]}");
         setEventMetadata("VALID_PROMOTIONDATEFINISH","{handler:'Valid_Promotiondatefinish',iparms:[]");
         setEventMetadata("VALID_PROMOTIONDATEFINISH",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTID","{handler:'Valid_Productid',iparms:[{av:'A7ProductId',fld:'PRODUCTID',pic:'ZZZ9'},{av:'A8ProductName',fld:'PRODUCTNAME',pic:''},{av:'A22ProductPrice',fld:'PRODUCTPRICE',pic:'$ ZZZZZZ9.99'}]");
         setEventMetadata("VALID_PRODUCTID",",oparms:[{av:'A8ProductName',fld:'PRODUCTNAME',pic:''},{av:'A22ProductPrice',fld:'PRODUCTPRICE',pic:'$ ZZZZZZ9.99'}]}");
         setEventMetadata("NULL","{handler:'Valid_Productprice',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         pr_default.close(19);
         pr_default.close(4);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z24PromotionDescrption = "";
         Z26PromotionDateStart = DateTime.MinValue;
         Z27PromotionDateFinish = DateTime.MinValue;
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         Gx_mode = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A24PromotionDescrption = "";
         A25PromotionPhoto = "";
         A40000PromotionPhoto_GXI = "";
         sImgUrl = "";
         A26PromotionDateStart = DateTime.MinValue;
         A27PromotionDateFinish = DateTime.MinValue;
         lblTitleproduct_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridpromotion_productContainer = new GXWebGrid( context);
         sMode7 = "";
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A8ProductName = "";
         Z25PromotionPhoto = "";
         Z40000PromotionPhoto_GXI = "";
         T00077_A10PromotionId = new short[1] ;
         T00077_A24PromotionDescrption = new string[] {""} ;
         T00077_A40000PromotionPhoto_GXI = new string[] {""} ;
         T00077_A26PromotionDateStart = new DateTime[] {DateTime.MinValue} ;
         T00077_A27PromotionDateFinish = new DateTime[] {DateTime.MinValue} ;
         T00077_A25PromotionPhoto = new string[] {""} ;
         T00078_A10PromotionId = new short[1] ;
         T00076_A10PromotionId = new short[1] ;
         T00076_A24PromotionDescrption = new string[] {""} ;
         T00076_A40000PromotionPhoto_GXI = new string[] {""} ;
         T00076_A26PromotionDateStart = new DateTime[] {DateTime.MinValue} ;
         T00076_A27PromotionDateFinish = new DateTime[] {DateTime.MinValue} ;
         T00076_A25PromotionPhoto = new string[] {""} ;
         sMode6 = "";
         T00079_A10PromotionId = new short[1] ;
         T000710_A10PromotionId = new short[1] ;
         T00075_A10PromotionId = new short[1] ;
         T00075_A24PromotionDescrption = new string[] {""} ;
         T00075_A40000PromotionPhoto_GXI = new string[] {""} ;
         T00075_A26PromotionDateStart = new DateTime[] {DateTime.MinValue} ;
         T00075_A27PromotionDateFinish = new DateTime[] {DateTime.MinValue} ;
         T00075_A25PromotionPhoto = new string[] {""} ;
         T000711_A10PromotionId = new short[1] ;
         T000715_A10PromotionId = new short[1] ;
         Z8ProductName = "";
         T000716_A10PromotionId = new short[1] ;
         T000716_A8ProductName = new string[] {""} ;
         T000716_A22ProductPrice = new decimal[1] ;
         T000716_A7ProductId = new short[1] ;
         T00074_A8ProductName = new string[] {""} ;
         T00074_A22ProductPrice = new decimal[1] ;
         T000717_A8ProductName = new string[] {""} ;
         T000717_A22ProductPrice = new decimal[1] ;
         T000718_A10PromotionId = new short[1] ;
         T000718_A7ProductId = new short[1] ;
         T00073_A10PromotionId = new short[1] ;
         T00073_A7ProductId = new short[1] ;
         T00072_A10PromotionId = new short[1] ;
         T00072_A7ProductId = new short[1] ;
         T000721_A8ProductName = new string[] {""} ;
         T000721_A22ProductPrice = new decimal[1] ;
         T000722_A10PromotionId = new short[1] ;
         T000722_A7ProductId = new short[1] ;
         Gridpromotion_productRow = new GXWebRow();
         subGridpromotion_product_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         Gridpromotion_productColumn = new GXWebColumn();
         ZZ24PromotionDescrption = "";
         ZZ25PromotionPhoto = "";
         ZZ40000PromotionPhoto_GXI = "";
         ZZ26PromotionDateStart = DateTime.MinValue;
         ZZ27PromotionDateFinish = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.promotion__default(),
            new Object[][] {
                new Object[] {
               T00072_A10PromotionId, T00072_A7ProductId
               }
               , new Object[] {
               T00073_A10PromotionId, T00073_A7ProductId
               }
               , new Object[] {
               T00074_A8ProductName, T00074_A22ProductPrice
               }
               , new Object[] {
               T00075_A10PromotionId, T00075_A24PromotionDescrption, T00075_A40000PromotionPhoto_GXI, T00075_A26PromotionDateStart, T00075_A27PromotionDateFinish, T00075_A25PromotionPhoto
               }
               , new Object[] {
               T00076_A10PromotionId, T00076_A24PromotionDescrption, T00076_A40000PromotionPhoto_GXI, T00076_A26PromotionDateStart, T00076_A27PromotionDateFinish, T00076_A25PromotionPhoto
               }
               , new Object[] {
               T00077_A10PromotionId, T00077_A24PromotionDescrption, T00077_A40000PromotionPhoto_GXI, T00077_A26PromotionDateStart, T00077_A27PromotionDateFinish, T00077_A25PromotionPhoto
               }
               , new Object[] {
               T00078_A10PromotionId
               }
               , new Object[] {
               T00079_A10PromotionId
               }
               , new Object[] {
               T000710_A10PromotionId
               }
               , new Object[] {
               T000711_A10PromotionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000715_A10PromotionId
               }
               , new Object[] {
               T000716_A10PromotionId, T000716_A8ProductName, T000716_A22ProductPrice, T000716_A7ProductId
               }
               , new Object[] {
               T000717_A8ProductName, T000717_A22ProductPrice
               }
               , new Object[] {
               T000718_A10PromotionId, T000718_A7ProductId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000721_A8ProductName, T000721_A22ProductPrice
               }
               , new Object[] {
               T000722_A10PromotionId, T000722_A7ProductId
               }
            }
         );
      }

      private short nIsMod_7 ;
      private short Z10PromotionId ;
      private short Z7ProductId ;
      private short nRcdDeleted_7 ;
      private short nRcdExists_7 ;
      private short GxWebError ;
      private short A7ProductId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A10PromotionId ;
      private short nBlankRcdCount7 ;
      private short RcdFound7 ;
      private short nBlankRcdUsr7 ;
      private short GX_JID ;
      private short RcdFound6 ;
      private short nIsDirty_6 ;
      private short Gx_BScreen ;
      private short nIsDirty_7 ;
      private short subGridpromotion_product_Backcolorstyle ;
      private short subGridpromotion_product_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridpromotion_product_Allowselection ;
      private short subGridpromotion_product_Allowhovering ;
      private short subGridpromotion_product_Allowcollapsing ;
      private short subGridpromotion_product_Collapsed ;
      private short ZZ10PromotionId ;
      private int nRC_GXsfl_63 ;
      private int nGXsfl_63_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPromotionId_Enabled ;
      private int edtPromotionDescrption_Enabled ;
      private int imgPromotionPhoto_Enabled ;
      private int edtPromotionDateStart_Enabled ;
      private int edtPromotionDateFinish_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtProductId_Enabled ;
      private int edtProductName_Enabled ;
      private int edtProductPrice_Enabled ;
      private int fRowAdded ;
      private int subGridpromotion_product_Backcolor ;
      private int subGridpromotion_product_Allbackcolor ;
      private int imgprompt_7_Visible ;
      private int defedtProductId_Enabled ;
      private int idxLst ;
      private int subGridpromotion_product_Selectedindex ;
      private int subGridpromotion_product_Selectioncolor ;
      private int subGridpromotion_product_Hoveringcolor ;
      private long GRIDPROMOTION_PRODUCT_nFirstRecordOnPage ;
      private decimal A22ProductPrice ;
      private decimal Z22ProductPrice ;
      private string sPrefix ;
      private string sGXsfl_63_idx="0001" ;
      private string Z24PromotionDescrption ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPromotionId_Internalname ;
      private string Gx_mode ;
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
      private string edtPromotionId_Jsonclick ;
      private string edtPromotionDescrption_Internalname ;
      private string A24PromotionDescrption ;
      private string edtPromotionDescrption_Jsonclick ;
      private string imgPromotionPhoto_Internalname ;
      private string sImgUrl ;
      private string edtPromotionDateStart_Internalname ;
      private string edtPromotionDateStart_Jsonclick ;
      private string edtPromotionDateFinish_Internalname ;
      private string edtPromotionDateFinish_Jsonclick ;
      private string divProducttable_Internalname ;
      private string lblTitleproduct_Internalname ;
      private string lblTitleproduct_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode7 ;
      private string edtProductId_Internalname ;
      private string edtProductName_Internalname ;
      private string edtProductPrice_Internalname ;
      private string imgprompt_7_Link ;
      private string sStyleString ;
      private string subGridpromotion_product_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string A8ProductName ;
      private string sMode6 ;
      private string Z8ProductName ;
      private string imgprompt_7_Internalname ;
      private string sGXsfl_63_fel_idx="0001" ;
      private string subGridpromotion_product_Class ;
      private string subGridpromotion_product_Linesclass ;
      private string ROClassString ;
      private string edtProductId_Jsonclick ;
      private string edtProductName_Jsonclick ;
      private string edtProductPrice_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string subGridpromotion_product_Header ;
      private string ZZ24PromotionDescrption ;
      private DateTime Z26PromotionDateStart ;
      private DateTime Z27PromotionDateFinish ;
      private DateTime A26PromotionDateStart ;
      private DateTime A27PromotionDateFinish ;
      private DateTime ZZ26PromotionDateStart ;
      private DateTime ZZ27PromotionDateFinish ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A25PromotionPhoto_IsBlob ;
      private bool bGXsfl_63_Refreshing=false ;
      private string A40000PromotionPhoto_GXI ;
      private string Z40000PromotionPhoto_GXI ;
      private string ZZ40000PromotionPhoto_GXI ;
      private string A25PromotionPhoto ;
      private string Z25PromotionPhoto ;
      private string ZZ25PromotionPhoto ;
      private GXWebGrid Gridpromotion_productContainer ;
      private GXWebRow Gridpromotion_productRow ;
      private GXWebColumn Gridpromotion_productColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00077_A10PromotionId ;
      private string[] T00077_A24PromotionDescrption ;
      private string[] T00077_A40000PromotionPhoto_GXI ;
      private DateTime[] T00077_A26PromotionDateStart ;
      private DateTime[] T00077_A27PromotionDateFinish ;
      private string[] T00077_A25PromotionPhoto ;
      private short[] T00078_A10PromotionId ;
      private short[] T00076_A10PromotionId ;
      private string[] T00076_A24PromotionDescrption ;
      private string[] T00076_A40000PromotionPhoto_GXI ;
      private DateTime[] T00076_A26PromotionDateStart ;
      private DateTime[] T00076_A27PromotionDateFinish ;
      private string[] T00076_A25PromotionPhoto ;
      private short[] T00079_A10PromotionId ;
      private short[] T000710_A10PromotionId ;
      private short[] T00075_A10PromotionId ;
      private string[] T00075_A24PromotionDescrption ;
      private string[] T00075_A40000PromotionPhoto_GXI ;
      private DateTime[] T00075_A26PromotionDateStart ;
      private DateTime[] T00075_A27PromotionDateFinish ;
      private string[] T00075_A25PromotionPhoto ;
      private short[] T000711_A10PromotionId ;
      private short[] T000715_A10PromotionId ;
      private short[] T000716_A10PromotionId ;
      private string[] T000716_A8ProductName ;
      private decimal[] T000716_A22ProductPrice ;
      private short[] T000716_A7ProductId ;
      private string[] T00074_A8ProductName ;
      private decimal[] T00074_A22ProductPrice ;
      private string[] T000717_A8ProductName ;
      private decimal[] T000717_A22ProductPrice ;
      private short[] T000718_A10PromotionId ;
      private short[] T000718_A7ProductId ;
      private short[] T00073_A10PromotionId ;
      private short[] T00073_A7ProductId ;
      private short[] T00072_A10PromotionId ;
      private short[] T00072_A7ProductId ;
      private string[] T000721_A8ProductName ;
      private decimal[] T000721_A22ProductPrice ;
      private short[] T000722_A10PromotionId ;
      private short[] T000722_A7ProductId ;
      private GXWebForm Form ;
   }

   public class promotion__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00077;
          prmT00077 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          Object[] prmT00078;
          prmT00078 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          Object[] prmT00076;
          prmT00076 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          Object[] prmT00079;
          prmT00079 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          Object[] prmT000710;
          prmT000710 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          Object[] prmT00075;
          prmT00075 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          Object[] prmT000711;
          prmT000711 = new Object[] {
          new ParDef("@PromotionDescrption",GXType.NChar,50,0) ,
          new ParDef("@PromotionPhoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@PromotionPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=1, Tbl="Promotion", Fld="PromotionPhoto"} ,
          new ParDef("@PromotionDateStart",GXType.Date,8,0) ,
          new ParDef("@PromotionDateFinish",GXType.Date,8,0)
          };
          Object[] prmT000712;
          prmT000712 = new Object[] {
          new ParDef("@PromotionDescrption",GXType.NChar,50,0) ,
          new ParDef("@PromotionDateStart",GXType.Date,8,0) ,
          new ParDef("@PromotionDateFinish",GXType.Date,8,0) ,
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          Object[] prmT000713;
          prmT000713 = new Object[] {
          new ParDef("@PromotionPhoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@PromotionPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Promotion", Fld="PromotionPhoto"} ,
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          Object[] prmT000714;
          prmT000714 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          Object[] prmT000715;
          prmT000715 = new Object[] {
          };
          Object[] prmT000716;
          prmT000716 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00074;
          prmT00074 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000717;
          prmT000717 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000718;
          prmT000718 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00073;
          prmT00073 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00072;
          prmT00072 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000719;
          prmT000719 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000720;
          prmT000720 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000722;
          prmT000722 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          Object[] prmT000721;
          prmT000721 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00072", "SELECT [PromotionId], [ProductId] FROM [PromotionProduct] WITH (UPDLOCK) WHERE [PromotionId] = @PromotionId AND [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00072,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00073", "SELECT [PromotionId], [ProductId] FROM [PromotionProduct] WHERE [PromotionId] = @PromotionId AND [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00073,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00074", "SELECT [ProductName], [ProductPrice] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00074,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00075", "SELECT [PromotionId], [PromotionDescrption], [PromotionPhoto_GXI], [PromotionDateStart], [PromotionDateFinish], [PromotionPhoto] FROM [Promotion] WITH (UPDLOCK) WHERE [PromotionId] = @PromotionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00075,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00076", "SELECT [PromotionId], [PromotionDescrption], [PromotionPhoto_GXI], [PromotionDateStart], [PromotionDateFinish], [PromotionPhoto] FROM [Promotion] WHERE [PromotionId] = @PromotionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00076,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00077", "SELECT TM1.[PromotionId], TM1.[PromotionDescrption], TM1.[PromotionPhoto_GXI], TM1.[PromotionDateStart], TM1.[PromotionDateFinish], TM1.[PromotionPhoto] FROM [Promotion] TM1 WHERE TM1.[PromotionId] = @PromotionId ORDER BY TM1.[PromotionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00077,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00078", "SELECT [PromotionId] FROM [Promotion] WHERE [PromotionId] = @PromotionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00078,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00079", "SELECT TOP 1 [PromotionId] FROM [Promotion] WHERE ( [PromotionId] > @PromotionId) ORDER BY [PromotionId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00079,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000710", "SELECT TOP 1 [PromotionId] FROM [Promotion] WHERE ( [PromotionId] < @PromotionId) ORDER BY [PromotionId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000710,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000711", "INSERT INTO [Promotion]([PromotionDescrption], [PromotionPhoto], [PromotionPhoto_GXI], [PromotionDateStart], [PromotionDateFinish]) VALUES(@PromotionDescrption, @PromotionPhoto, @PromotionPhoto_GXI, @PromotionDateStart, @PromotionDateFinish); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000711,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000712", "UPDATE [Promotion] SET [PromotionDescrption]=@PromotionDescrption, [PromotionDateStart]=@PromotionDateStart, [PromotionDateFinish]=@PromotionDateFinish  WHERE [PromotionId] = @PromotionId", GxErrorMask.GX_NOMASK,prmT000712)
             ,new CursorDef("T000713", "UPDATE [Promotion] SET [PromotionPhoto]=@PromotionPhoto, [PromotionPhoto_GXI]=@PromotionPhoto_GXI  WHERE [PromotionId] = @PromotionId", GxErrorMask.GX_NOMASK,prmT000713)
             ,new CursorDef("T000714", "DELETE FROM [Promotion]  WHERE [PromotionId] = @PromotionId", GxErrorMask.GX_NOMASK,prmT000714)
             ,new CursorDef("T000715", "SELECT [PromotionId] FROM [Promotion] ORDER BY [PromotionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000715,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000716", "SELECT T1.[PromotionId], T2.[ProductName], T2.[ProductPrice], T1.[ProductId] FROM ([PromotionProduct] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) WHERE T1.[PromotionId] = @PromotionId and T1.[ProductId] = @ProductId ORDER BY T1.[PromotionId], T1.[ProductId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000716,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000717", "SELECT [ProductName], [ProductPrice] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000717,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000718", "SELECT [PromotionId], [ProductId] FROM [PromotionProduct] WHERE [PromotionId] = @PromotionId AND [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000718,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000719", "INSERT INTO [PromotionProduct]([PromotionId], [ProductId]) VALUES(@PromotionId, @ProductId)", GxErrorMask.GX_NOMASK,prmT000719)
             ,new CursorDef("T000720", "DELETE FROM [PromotionProduct]  WHERE [PromotionId] = @PromotionId AND [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmT000720)
             ,new CursorDef("T000721", "SELECT [ProductName], [ProductPrice] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000721,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000722", "SELECT [PromotionId], [ProductId] FROM [PromotionProduct] WHERE [PromotionId] = @PromotionId ORDER BY [PromotionId], [ProductId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000722,11, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
             case 20 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
