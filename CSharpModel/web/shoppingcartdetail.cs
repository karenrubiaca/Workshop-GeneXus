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
using GeneXus.Procedure;
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class shoppingcartdetail : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("Carmine");
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "ShoppingCartId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               A11ShoppingCartId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
            }
            if ( toggleJsOutput )
            {
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public shoppingcartdetail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public shoppingcartdetail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_ShoppingCartId )
      {
         this.A11ShoppingCartId = aP0_ShoppingCartId;
         initialize();
         executePrivate();
         aP0_ShoppingCartId=this.A11ShoppingCartId;
      }

      public short executeUdp( )
      {
         execute(ref aP0_ShoppingCartId);
         return A11ShoppingCartId ;
      }

      public void executeSubmit( ref short aP0_ShoppingCartId )
      {
         shoppingcartdetail objshoppingcartdetail;
         objshoppingcartdetail = new shoppingcartdetail();
         objshoppingcartdetail.A11ShoppingCartId = aP0_ShoppingCartId;
         objshoppingcartdetail.context.SetSubmitInitialConfig(context);
         objshoppingcartdetail.initialize();
         Submit( executePrivateCatch,objshoppingcartdetail);
         aP0_ShoppingCartId=this.A11ShoppingCartId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((shoppingcartdetail)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         getPrinter().GxSetDocName("") ;
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11909, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            H0F0( false, 157) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 40, true, false, false, false, 0, 255, 20, 147, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("My Shopping Cart", 267, Gx_line+33, 767, Gx_line+116, 0, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "7cd17ff6-f677-4e3b-9b83-a6eda26c92d3", "", context.GetTheme( )), 58, Gx_line+0, 250, Gx_line+133) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+157);
            /* Using cursor P000F3 */
            pr_default.execute(0, new Object[] {A11ShoppingCartId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A6CustomerId = P000F3_A6CustomerId[0];
               A3CountryId = P000F3_A3CountryId[0];
               A4CountryName = P000F3_A4CountryName[0];
               A16CustomerAddress = P000F3_A16CustomerAddress[0];
               A15CustomerName = P000F3_A15CustomerName[0];
               A29ShoppingCartFinalPrice = P000F3_A29ShoppingCartFinalPrice[0];
               n29ShoppingCartFinalPrice = P000F3_n29ShoppingCartFinalPrice[0];
               A28ShoppingCartDate = P000F3_A28ShoppingCartDate[0];
               A3CountryId = P000F3_A3CountryId[0];
               A16CustomerAddress = P000F3_A16CustomerAddress[0];
               A15CustomerName = P000F3_A15CustomerName[0];
               A4CountryName = P000F3_A4CountryName[0];
               A29ShoppingCartFinalPrice = P000F3_A29ShoppingCartFinalPrice[0];
               n29ShoppingCartFinalPrice = P000F3_n29ShoppingCartFinalPrice[0];
               A32ShoppingCartDateDelivery = DateTimeUtil.DAdd(A28ShoppingCartDate,+((int)(5)));
               H0F0( false, 215) ;
               getPrinter().GxAttris("Times New Roman", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Shopping Cart:", 58, Gx_line+17, 166, Gx_line+37, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Times New Roman", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A11ShoppingCartId), "ZZZ9")), 175, Gx_line+17, 209, Gx_line+38, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Times New Roman", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Date:", 250, Gx_line+17, 292, Gx_line+37, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Times New Roman", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( A28ShoppingCartDate, "99/99/99"), 308, Gx_line+17, 400, Gx_line+38, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Times New Roman", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Delivery Date:", 475, Gx_line+17, 592, Gx_line+37, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Times New Roman", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( A32ShoppingCartDateDelivery, "99/99/99"), 600, Gx_line+17, 700, Gx_line+38, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Times New Roman", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Customer:", 58, Gx_line+50, 133, Gx_line+70, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Times New Roman", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A15CustomerName, "")), 167, Gx_line+50, 334, Gx_line+71, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A16CustomerAddress, "")), 58, Gx_line+67, 446, Gx_line+88, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A4CountryName, "")), 58, Gx_line+100, 184, Gx_line+121, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Times New Roman", 12, true, false, false, false, 0, 25, 25, 112, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total:", 508, Gx_line+133, 550, Gx_line+153, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Times New Roman", 12, false, false, false, false, 0, 25, 25, 112, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A29ShoppingCartFinalPrice, "$ ZZZZZZ9.99")), 600, Gx_line+133, 700, Gx_line+154, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Times New Roman", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("", 600, Gx_line+133, 608, Gx_line+150, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(58, Gx_line+167, 725, Gx_line+167, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Times New Roman", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total", 608, Gx_line+183, 658, Gx_line+203, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Quantity", 450, Gx_line+183, 517, Gx_line+203, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Price", 283, Gx_line+183, 333, Gx_line+203, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Product", 58, Gx_line+183, 133, Gx_line+203, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+215);
               /* Using cursor P000F4 */
               pr_default.execute(1, new Object[] {A11ShoppingCartId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A7ProductId = P000F4_A7ProductId[0];
                  A1CategoryId = P000F4_A1CategoryId[0];
                  A40000ProductPhoto_GXI = P000F4_A40000ProductPhoto_GXI[0];
                  A8ProductName = P000F4_A8ProductName[0];
                  A2CategoryName = P000F4_A2CategoryName[0];
                  A22ProductPrice = P000F4_A22ProductPrice[0];
                  A31QtyProduct = P000F4_A31QtyProduct[0];
                  A23ProductPhoto = P000F4_A23ProductPhoto[0];
                  A1CategoryId = P000F4_A1CategoryId[0];
                  A40000ProductPhoto_GXI = P000F4_A40000ProductPhoto_GXI[0];
                  A8ProductName = P000F4_A8ProductName[0];
                  A22ProductPrice = P000F4_A22ProductPrice[0];
                  A23ProductPhoto = P000F4_A23ProductPhoto[0];
                  A2CategoryName = P000F4_A2CategoryName[0];
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
                  H0F0( false, 100) ;
                  getPrinter().GxAttris("Times New Roman", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A22ProductPrice, "$ ZZZZZZ9.99")), 283, Gx_line+33, 350, Gx_line+54, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A8ProductName, "")), 125, Gx_line+33, 267, Gx_line+54, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A31QtyProduct), "ZZZ9")), 450, Gx_line+33, 483, Gx_line+54, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A30TotalProduct, "$ ZZZZZZ9.99")), 608, Gx_line+33, 675, Gx_line+54, 2, 0, 0, 0) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A23ProductPhoto)) ? A40000ProductPhoto_GXI : A23ProductPhoto);
                  getPrinter().GxDrawBitMap(sImgUrl, 58, Gx_line+17, 108, Gx_line+50) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+100);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0F0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void H0F0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
         add_metrics1( ) ;
         add_metrics2( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Times New Roman", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics2( )
      {
         getPrinter().setMetrics("Times New Roman", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         scmdbuf = "";
         P000F3_A6CustomerId = new short[1] ;
         P000F3_A3CountryId = new short[1] ;
         P000F3_A11ShoppingCartId = new short[1] ;
         P000F3_A4CountryName = new string[] {""} ;
         P000F3_A16CustomerAddress = new string[] {""} ;
         P000F3_A15CustomerName = new string[] {""} ;
         P000F3_A29ShoppingCartFinalPrice = new decimal[1] ;
         P000F3_n29ShoppingCartFinalPrice = new bool[] {false} ;
         P000F3_A28ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         A4CountryName = "";
         A16CustomerAddress = "";
         A15CustomerName = "";
         A28ShoppingCartDate = DateTime.MinValue;
         A32ShoppingCartDateDelivery = DateTime.MinValue;
         P000F4_A7ProductId = new short[1] ;
         P000F4_A1CategoryId = new short[1] ;
         P000F4_A11ShoppingCartId = new short[1] ;
         P000F4_A40000ProductPhoto_GXI = new string[] {""} ;
         P000F4_A8ProductName = new string[] {""} ;
         P000F4_A2CategoryName = new string[] {""} ;
         P000F4_A22ProductPrice = new decimal[1] ;
         P000F4_A31QtyProduct = new short[1] ;
         P000F4_A23ProductPhoto = new string[] {""} ;
         A40000ProductPhoto_GXI = "";
         A8ProductName = "";
         A2CategoryName = "";
         A23ProductPhoto = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.shoppingcartdetail__default(),
            new Object[][] {
                new Object[] {
               P000F3_A6CustomerId, P000F3_A3CountryId, P000F3_A11ShoppingCartId, P000F3_A4CountryName, P000F3_A16CustomerAddress, P000F3_A15CustomerName, P000F3_A29ShoppingCartFinalPrice, P000F3_n29ShoppingCartFinalPrice, P000F3_A28ShoppingCartDate
               }
               , new Object[] {
               P000F4_A7ProductId, P000F4_A1CategoryId, P000F4_A11ShoppingCartId, P000F4_A40000ProductPhoto_GXI, P000F4_A8ProductName, P000F4_A2CategoryName, P000F4_A22ProductPrice, P000F4_A31QtyProduct, P000F4_A23ProductPhoto
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short A11ShoppingCartId ;
      private short GxWebError ;
      private short A6CustomerId ;
      private short A3CountryId ;
      private short A7ProductId ;
      private short A1CategoryId ;
      private short A31QtyProduct ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private decimal A29ShoppingCartFinalPrice ;
      private decimal A22ProductPrice ;
      private decimal A30TotalProduct ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private string A4CountryName ;
      private string A15CustomerName ;
      private string A8ProductName ;
      private string A2CategoryName ;
      private string sImgUrl ;
      private DateTime A28ShoppingCartDate ;
      private DateTime A32ShoppingCartDateDelivery ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n29ShoppingCartFinalPrice ;
      private string A16CustomerAddress ;
      private string A40000ProductPhoto_GXI ;
      private string A23ProductPhoto ;
      private IGxDataStore dsDefault ;
      private short aP0_ShoppingCartId ;
      private IDataStoreProvider pr_default ;
      private short[] P000F3_A6CustomerId ;
      private short[] P000F3_A3CountryId ;
      private short[] P000F3_A11ShoppingCartId ;
      private string[] P000F3_A4CountryName ;
      private string[] P000F3_A16CustomerAddress ;
      private string[] P000F3_A15CustomerName ;
      private decimal[] P000F3_A29ShoppingCartFinalPrice ;
      private bool[] P000F3_n29ShoppingCartFinalPrice ;
      private DateTime[] P000F3_A28ShoppingCartDate ;
      private short[] P000F4_A7ProductId ;
      private short[] P000F4_A1CategoryId ;
      private short[] P000F4_A11ShoppingCartId ;
      private string[] P000F4_A40000ProductPhoto_GXI ;
      private string[] P000F4_A8ProductName ;
      private string[] P000F4_A2CategoryName ;
      private decimal[] P000F4_A22ProductPrice ;
      private short[] P000F4_A31QtyProduct ;
      private string[] P000F4_A23ProductPhoto ;
   }

   public class shoppingcartdetail__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000F3;
          prmP000F3 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmP000F4;
          prmP000F4 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000F3", "SELECT T1.[CustomerId], T2.[CountryId], T1.[ShoppingCartId], T3.[CountryName], T2.[CustomerAddress], T2.[CustomerName], COALESCE( T4.[ShoppingCartFinalPrice], 0) AS ShoppingCartFinalPrice, T1.[ShoppingCartDate] FROM ((([ShoppingCart] T1 INNER JOIN [Customer] T2 ON T2.[CustomerId] = T1.[CustomerId]) INNER JOIN [Country] T3 ON T3.[CountryId] = T2.[CountryId]) LEFT JOIN (SELECT SUM(CASE  WHEN T7.[CategoryName] = 'Joyería' THEN T5.[QtyProduct] * CAST(T6.[ProductPrice] AS decimal( 20, 10)) * CAST(( 1 + CAST(5 AS decimal( 13, 10)) / 100) AS decimal( 22, 10)) WHEN T7.[CategoryName] = 'Entretenimiento' THEN T5.[QtyProduct] * CAST(T6.[ProductPrice] AS decimal( 20, 10)) * CAST(( 1 - CAST(10 AS decimal( 13, 10)) / 100) AS decimal( 22, 10)) ELSE T5.[QtyProduct] * CAST(T6.[ProductPrice] AS decimal( 20, 10)) END) AS ShoppingCartFinalPrice, T5.[ShoppingCartId] FROM (([ShoppingCartProduct] T5 INNER JOIN [Product] T6 ON T6.[ProductId] = T5.[ProductId]) INNER JOIN [Category] T7 ON T7.[CategoryId] = T6.[CategoryId]) GROUP BY T5.[ShoppingCartId] ) T4 ON T4.[ShoppingCartId] = T1.[ShoppingCartId]) WHERE T1.[ShoppingCartId] = @ShoppingCartId ORDER BY T1.[ShoppingCartId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000F3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P000F4", "SELECT T1.[ProductId], T2.[CategoryId], T1.[ShoppingCartId], T2.[ProductPhoto_GXI], T2.[ProductName], T3.[CategoryName], T2.[ProductPrice], T1.[QtyProduct], T2.[ProductPhoto] FROM (([ShoppingCartProduct] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) INNER JOIN [Category] T3 ON T3.[CategoryId] = T2.[CategoryId]) WHERE T1.[ShoppingCartId] = @ShoppingCartId ORDER BY T2.[ProductName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000F4,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(4));
                return;
       }
    }

 }

}
