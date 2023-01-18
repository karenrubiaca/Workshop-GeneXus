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
   public class productspercategory : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetNextPar( );
            toggleJsOutput = isJsOutputEnabled( );
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

      public productspercategory( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public productspercategory( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         productspercategory objproductspercategory;
         objproductspercategory = new productspercategory();
         objproductspercategory.context.SetSubmitInitialConfig(context);
         objproductspercategory.initialize();
         Submit( executePrivateCatch,objproductspercategory);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((productspercategory)stateInfo).executePrivate();
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
            H0H0( false, 168) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 30, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Catalogue", 292, Gx_line+67, 567, Gx_line+134, 0, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "923c4c8b-3a49-47f3-a2cd-61d442596ebc", "", context.GetTheme( )), 50, Gx_line+0, 258, Gx_line+117) ;
            getPrinter().GxDrawLine(25, Gx_line+150, 808, Gx_line+150, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+168);
            /* Using cursor P000H2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRK0H2 = false;
               A5SellerId = P000H2_A5SellerId[0];
               A1CategoryId = P000H2_A1CategoryId[0];
               A2CategoryName = P000H2_A2CategoryName[0];
               A40001SellerPhoto_GXI = P000H2_A40001SellerPhoto_GXI[0];
               A40000ProductPhoto_GXI = P000H2_A40000ProductPhoto_GXI[0];
               A13SellerName = P000H2_A13SellerName[0];
               A22ProductPrice = P000H2_A22ProductPrice[0];
               A8ProductName = P000H2_A8ProductName[0];
               A7ProductId = P000H2_A7ProductId[0];
               A14SellerPhoto = P000H2_A14SellerPhoto[0];
               A23ProductPhoto = P000H2_A23ProductPhoto[0];
               A40001SellerPhoto_GXI = P000H2_A40001SellerPhoto_GXI[0];
               A13SellerName = P000H2_A13SellerName[0];
               A14SellerPhoto = P000H2_A14SellerPhoto[0];
               A2CategoryName = P000H2_A2CategoryName[0];
               H0H0( false, 43) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 127, 255, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2CategoryName, "")), 67, Gx_line+17, 172, Gx_line+32, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+43);
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P000H2_A2CategoryName[0], A2CategoryName) == 0 ) )
               {
                  BRK0H2 = false;
                  A5SellerId = P000H2_A5SellerId[0];
                  A1CategoryId = P000H2_A1CategoryId[0];
                  A40001SellerPhoto_GXI = P000H2_A40001SellerPhoto_GXI[0];
                  A40000ProductPhoto_GXI = P000H2_A40000ProductPhoto_GXI[0];
                  A13SellerName = P000H2_A13SellerName[0];
                  A22ProductPrice = P000H2_A22ProductPrice[0];
                  A8ProductName = P000H2_A8ProductName[0];
                  A7ProductId = P000H2_A7ProductId[0];
                  A14SellerPhoto = P000H2_A14SellerPhoto[0];
                  A23ProductPhoto = P000H2_A23ProductPhoto[0];
                  A40001SellerPhoto_GXI = P000H2_A40001SellerPhoto_GXI[0];
                  A13SellerName = P000H2_A13SellerName[0];
                  A14SellerPhoto = P000H2_A14SellerPhoto[0];
                  H0H0( false, 100) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A23ProductPhoto)) ? A40000ProductPhoto_GXI : A23ProductPhoto);
                  getPrinter().GxDrawBitMap(sImgUrl, 42, Gx_line+17, 100, Gx_line+67) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A8ProductName, "")), 142, Gx_line+33, 317, Gx_line+48, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A22ProductPrice, "$ ZZZZZZ9.99")), 333, Gx_line+33, 441, Gx_line+48, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A13SellerName, "")), 483, Gx_line+33, 700, Gx_line+48, 0, 0, 0, 0) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A14SellerPhoto)) ? A40001SellerPhoto_GXI : A14SellerPhoto);
                  getPrinter().GxDrawBitMap(sImgUrl, 750, Gx_line+17, 800, Gx_line+67) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+100);
                  BRK0H2 = true;
                  pr_default.readNext(0);
               }
               if ( ! BRK0H2 )
               {
                  BRK0H2 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0H0( true, 0) ;
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

      protected void H0H0( bool bFoot ,
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
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
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
         P000H2_A5SellerId = new short[1] ;
         P000H2_A1CategoryId = new short[1] ;
         P000H2_A2CategoryName = new string[] {""} ;
         P000H2_A40001SellerPhoto_GXI = new string[] {""} ;
         P000H2_A40000ProductPhoto_GXI = new string[] {""} ;
         P000H2_A13SellerName = new string[] {""} ;
         P000H2_A22ProductPrice = new decimal[1] ;
         P000H2_A8ProductName = new string[] {""} ;
         P000H2_A7ProductId = new short[1] ;
         P000H2_A14SellerPhoto = new string[] {""} ;
         P000H2_A23ProductPhoto = new string[] {""} ;
         A2CategoryName = "";
         A40001SellerPhoto_GXI = "";
         A40000ProductPhoto_GXI = "";
         A13SellerName = "";
         A8ProductName = "";
         A14SellerPhoto = "";
         A23ProductPhoto = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.productspercategory__default(),
            new Object[][] {
                new Object[] {
               P000H2_A5SellerId, P000H2_A1CategoryId, P000H2_A2CategoryName, P000H2_A40001SellerPhoto_GXI, P000H2_A40000ProductPhoto_GXI, P000H2_A13SellerName, P000H2_A22ProductPrice, P000H2_A8ProductName, P000H2_A7ProductId, P000H2_A14SellerPhoto,
               P000H2_A23ProductPhoto
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short A5SellerId ;
      private short A1CategoryId ;
      private short A7ProductId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private decimal A22ProductPrice ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private string A2CategoryName ;
      private string A13SellerName ;
      private string A8ProductName ;
      private string sImgUrl ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRK0H2 ;
      private string A40001SellerPhoto_GXI ;
      private string A40000ProductPhoto_GXI ;
      private string A14SellerPhoto ;
      private string A23ProductPhoto ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000H2_A5SellerId ;
      private short[] P000H2_A1CategoryId ;
      private string[] P000H2_A2CategoryName ;
      private string[] P000H2_A40001SellerPhoto_GXI ;
      private string[] P000H2_A40000ProductPhoto_GXI ;
      private string[] P000H2_A13SellerName ;
      private decimal[] P000H2_A22ProductPrice ;
      private string[] P000H2_A8ProductName ;
      private short[] P000H2_A7ProductId ;
      private string[] P000H2_A14SellerPhoto ;
      private string[] P000H2_A23ProductPhoto ;
   }

   public class productspercategory__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000H2;
          prmP000H2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P000H2", "SELECT T1.[SellerId], T1.[CategoryId], T3.[CategoryName], T2.[SellerPhoto_GXI], T1.[ProductPhoto_GXI], T2.[SellerName], T1.[ProductPrice], T1.[ProductName], T1.[ProductId], T2.[SellerPhoto], T1.[ProductPhoto] FROM (([Product] T1 INNER JOIN [Seller] T2 ON T2.[SellerId] = T1.[SellerId]) INNER JOIN [Category] T3 ON T3.[CategoryId] = T1.[CategoryId]) ORDER BY T3.[CategoryName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000H2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((string[]) buf[9])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(4));
                ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(5));
                return;
       }
    }

 }

}
