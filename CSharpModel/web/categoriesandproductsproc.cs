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
   public class categoriesandproductsproc : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetFirstPar( "CategoryId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               A1CategoryId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  A2CategoryName = GetPar( "CategoryName");
               }
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

      public categoriesandproductsproc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public categoriesandproductsproc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_CategoryId ,
                           ref string aP1_CategoryName )
      {
         this.A1CategoryId = aP0_CategoryId;
         this.A2CategoryName = aP1_CategoryName;
         initialize();
         executePrivate();
         aP0_CategoryId=this.A1CategoryId;
         aP1_CategoryName=this.A2CategoryName;
      }

      public string executeUdp( ref short aP0_CategoryId )
      {
         execute(ref aP0_CategoryId, ref aP1_CategoryName);
         return A2CategoryName ;
      }

      public void executeSubmit( ref short aP0_CategoryId ,
                                 ref string aP1_CategoryName )
      {
         categoriesandproductsproc objcategoriesandproductsproc;
         objcategoriesandproductsproc = new categoriesandproductsproc();
         objcategoriesandproductsproc.A1CategoryId = aP0_CategoryId;
         objcategoriesandproductsproc.A2CategoryName = aP1_CategoryName;
         objcategoriesandproductsproc.context.SetSubmitInitialConfig(context);
         objcategoriesandproductsproc.initialize();
         Submit( executePrivateCatch,objcategoriesandproductsproc);
         aP0_CategoryId=this.A1CategoryId;
         aP1_CategoryName=this.A2CategoryName;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((categoriesandproductsproc)stateInfo).executePrivate();
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
            H0G0( false, 184) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2CategoryName, "")), 317, Gx_line+50, 525, Gx_line+117, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("and Products", 525, Gx_line+50, 708, Gx_line+117, 0, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "923c4c8b-3a49-47f3-a2cd-61d442596ebc", "", context.GetTheme( )), 50, Gx_line+0, 275, Gx_line+150) ;
            getPrinter().GxAttris("Times New Roman", 12, true, false, false, false, 0, 25, 25, 112, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Seller", 675, Gx_line+133, 733, Gx_line+153, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(75, Gx_line+167, 825, Gx_line+167, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+184);
            AV4GXLvl2 = 0;
            /* Using cursor P000G2 */
            pr_default.execute(0, new Object[] {A1CategoryId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A5SellerId = P000G2_A5SellerId[0];
               A40001SellerPhoto_GXI = P000G2_A40001SellerPhoto_GXI[0];
               A40000ProductPhoto_GXI = P000G2_A40000ProductPhoto_GXI[0];
               A13SellerName = P000G2_A13SellerName[0];
               A22ProductPrice = P000G2_A22ProductPrice[0];
               A8ProductName = P000G2_A8ProductName[0];
               A7ProductId = P000G2_A7ProductId[0];
               A14SellerPhoto = P000G2_A14SellerPhoto[0];
               A23ProductPhoto = P000G2_A23ProductPhoto[0];
               A40001SellerPhoto_GXI = P000G2_A40001SellerPhoto_GXI[0];
               A13SellerName = P000G2_A13SellerName[0];
               A14SellerPhoto = P000G2_A14SellerPhoto[0];
               AV4GXLvl2 = 1;
               H0G0( false, 85) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A23ProductPhoto)) ? A40000ProductPhoto_GXI : A23ProductPhoto);
               getPrinter().GxDrawBitMap(sImgUrl, 42, Gx_line+17, 100, Gx_line+67) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A8ProductName, "")), 142, Gx_line+33, 317, Gx_line+48, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A22ProductPrice, "$ ZZZZZZ9.99")), 333, Gx_line+33, 441, Gx_line+48, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A13SellerName, "")), 575, Gx_line+33, 725, Gx_line+48, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A14SellerPhoto)) ? A40001SellerPhoto_GXI : A14SellerPhoto);
               getPrinter().GxDrawBitMap(sImgUrl, 750, Gx_line+17, 800, Gx_line+67) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+85);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV4GXLvl2 == 0 )
            {
               H0G0( false, 100) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 0, 15, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("No hay productos en esta Categoría.", 92, Gx_line+17, 534, Gx_line+50, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+100);
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0G0( true, 0) ;
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

      protected void H0G0( bool bFoot ,
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
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Times New Roman", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
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
         P000G2_A5SellerId = new short[1] ;
         P000G2_A1CategoryId = new short[1] ;
         P000G2_A40001SellerPhoto_GXI = new string[] {""} ;
         P000G2_A40000ProductPhoto_GXI = new string[] {""} ;
         P000G2_A13SellerName = new string[] {""} ;
         P000G2_A22ProductPrice = new decimal[1] ;
         P000G2_A8ProductName = new string[] {""} ;
         P000G2_A7ProductId = new short[1] ;
         P000G2_A14SellerPhoto = new string[] {""} ;
         P000G2_A23ProductPhoto = new string[] {""} ;
         A40001SellerPhoto_GXI = "";
         A40000ProductPhoto_GXI = "";
         A13SellerName = "";
         A8ProductName = "";
         A14SellerPhoto = "";
         A23ProductPhoto = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.categoriesandproductsproc__default(),
            new Object[][] {
                new Object[] {
               P000G2_A5SellerId, P000G2_A1CategoryId, P000G2_A40001SellerPhoto_GXI, P000G2_A40000ProductPhoto_GXI, P000G2_A13SellerName, P000G2_A22ProductPrice, P000G2_A8ProductName, P000G2_A7ProductId, P000G2_A14SellerPhoto, P000G2_A23ProductPhoto
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short A1CategoryId ;
      private short GxWebError ;
      private short AV4GXLvl2 ;
      private short A5SellerId ;
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
      private string A2CategoryName ;
      private string scmdbuf ;
      private string A13SellerName ;
      private string A8ProductName ;
      private string sImgUrl ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string A40001SellerPhoto_GXI ;
      private string A40000ProductPhoto_GXI ;
      private string A14SellerPhoto ;
      private string A23ProductPhoto ;
      private IGxDataStore dsDefault ;
      private short aP0_CategoryId ;
      private string aP1_CategoryName ;
      private IDataStoreProvider pr_default ;
      private short[] P000G2_A5SellerId ;
      private short[] P000G2_A1CategoryId ;
      private string[] P000G2_A40001SellerPhoto_GXI ;
      private string[] P000G2_A40000ProductPhoto_GXI ;
      private string[] P000G2_A13SellerName ;
      private decimal[] P000G2_A22ProductPrice ;
      private string[] P000G2_A8ProductName ;
      private short[] P000G2_A7ProductId ;
      private string[] P000G2_A14SellerPhoto ;
      private string[] P000G2_A23ProductPhoto ;
   }

   public class categoriesandproductsproc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000G2;
          prmP000G2 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000G2", "SELECT T1.[SellerId], T1.[CategoryId], T2.[SellerPhoto_GXI], T1.[ProductPhoto_GXI], T2.[SellerName], T1.[ProductPrice], T1.[ProductName], T1.[ProductId], T2.[SellerPhoto], T1.[ProductPhoto] FROM ([Product] T1 INNER JOIN [Seller] T2 ON T2.[SellerId] = T1.[SellerId]) WHERE T1.[CategoryId] = @CategoryId ORDER BY T1.[CategoryId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000G2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(3));
                ((string[]) buf[9])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(4));
                return;
       }
    }

 }

}
