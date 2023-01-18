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
   public class acustomerslist : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetFirstPar( "FromDate");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV8FromDate = context.localUtil.ParseDateParm( gxfirstwebparm);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV9ToDate = context.localUtil.ParseDateParm( GetPar( "ToDate"));
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

      public acustomerslist( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public acustomerslist( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref DateTime aP0_FromDate ,
                           ref DateTime aP1_ToDate )
      {
         this.AV8FromDate = aP0_FromDate;
         this.AV9ToDate = aP1_ToDate;
         initialize();
         executePrivate();
         aP0_FromDate=this.AV8FromDate;
         aP1_ToDate=this.AV9ToDate;
      }

      public DateTime executeUdp( ref DateTime aP0_FromDate )
      {
         execute(ref aP0_FromDate, ref aP1_ToDate);
         return AV9ToDate ;
      }

      public void executeSubmit( ref DateTime aP0_FromDate ,
                                 ref DateTime aP1_ToDate )
      {
         acustomerslist objacustomerslist;
         objacustomerslist = new acustomerslist();
         objacustomerslist.AV8FromDate = aP0_FromDate;
         objacustomerslist.AV9ToDate = aP1_ToDate;
         objacustomerslist.context.SetSubmitInitialConfig(context);
         objacustomerslist.initialize();
         Submit( executePrivateCatch,objacustomerslist);
         aP0_FromDate=this.AV8FromDate;
         aP1_ToDate=this.AV9ToDate;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((acustomerslist)stateInfo).executePrivate();
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
            H0I0( false, 125) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 40, false, false, false, false, 0, 0, 0, 15, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Customers", 242, Gx_line+17, 534, Gx_line+84, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("From Date:", 83, Gx_line+83, 141, Gx_line+97, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("To Date:", 83, Gx_line+100, 128, Gx_line+114, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV8FromDate, "99/99/99"), 150, Gx_line+83, 199, Gx_line+98, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV9ToDate, "99/99/99"), 150, Gx_line+100, 199, Gx_line+115, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(33, Gx_line+117, 783, Gx_line+117, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+125);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV8FromDate ,
                                                 AV9ToDate ,
                                                 A28ShoppingCartDate } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P000I2 */
            pr_default.execute(0, new Object[] {AV8FromDate, AV9ToDate});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A28ShoppingCartDate = P000I2_A28ShoppingCartDate[0];
               A18CustomerPhone = P000I2_A18CustomerPhone[0];
               A17CustomerEmail = P000I2_A17CustomerEmail[0];
               A16CustomerAddress = P000I2_A16CustomerAddress[0];
               A6CustomerId = P000I2_A6CustomerId[0];
               A15CustomerName = P000I2_A15CustomerName[0];
               A18CustomerPhone = P000I2_A18CustomerPhone[0];
               A17CustomerEmail = P000I2_A17CustomerEmail[0];
               A16CustomerAddress = P000I2_A16CustomerAddress[0];
               A15CustomerName = P000I2_A15CustomerName[0];
               H0I0( false, 107) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 12, false, false, false, false, 0, 25, 25, 112, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A15CustomerName, "")), 42, Gx_line+17, 189, Gx_line+39, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A16CustomerAddress, "")), 83, Gx_line+50, 316, Gx_line+65, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A17CustomerEmail, "")), 83, Gx_line+67, 316, Gx_line+82, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A18CustomerPhone, "")), 333, Gx_line+50, 438, Gx_line+65, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(33, Gx_line+100, 783, Gx_line+100, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+107);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0I0( true, 0) ;
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

      protected void H0I0( bool bFoot ,
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
         if (IsMain)	waitPrinterEnd();
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
         A28ShoppingCartDate = DateTime.MinValue;
         P000I2_A28ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         P000I2_A18CustomerPhone = new string[] {""} ;
         P000I2_A17CustomerEmail = new string[] {""} ;
         P000I2_A16CustomerAddress = new string[] {""} ;
         P000I2_A6CustomerId = new short[1] ;
         P000I2_A15CustomerName = new string[] {""} ;
         A18CustomerPhone = "";
         A17CustomerEmail = "";
         A16CustomerAddress = "";
         A15CustomerName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.acustomerslist__default(),
            new Object[][] {
                new Object[] {
               P000I2_A28ShoppingCartDate, P000I2_A18CustomerPhone, P000I2_A17CustomerEmail, P000I2_A16CustomerAddress, P000I2_A6CustomerId, P000I2_A15CustomerName
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
      private short A6CustomerId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private string A18CustomerPhone ;
      private string A15CustomerName ;
      private DateTime AV8FromDate ;
      private DateTime AV9ToDate ;
      private DateTime A28ShoppingCartDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string A17CustomerEmail ;
      private string A16CustomerAddress ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_FromDate ;
      private DateTime aP1_ToDate ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P000I2_A28ShoppingCartDate ;
      private string[] P000I2_A18CustomerPhone ;
      private string[] P000I2_A17CustomerEmail ;
      private string[] P000I2_A16CustomerAddress ;
      private short[] P000I2_A6CustomerId ;
      private string[] P000I2_A15CustomerName ;
   }

   public class acustomerslist__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000I2( IGxContext context ,
                                             DateTime AV8FromDate ,
                                             DateTime AV9ToDate ,
                                             DateTime A28ShoppingCartDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[2];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT DISTINCT NULL AS [ShoppingCartDate], [CustomerPhone], [CustomerEmail], [CustomerAddress], [CustomerId], [CustomerName] FROM ( SELECT TOP(100) PERCENT T1.[ShoppingCartDate], T2.[CustomerPhone], T2.[CustomerEmail], T2.[CustomerAddress], T1.[CustomerId], T2.[CustomerName] FROM ([ShoppingCart] T1 INNER JOIN [Customer] T2 ON T2.[CustomerId] = T1.[CustomerId])";
         if ( ! (DateTime.MinValue==AV8FromDate) )
         {
            AddWhere(sWhereString, "(T1.[ShoppingCartDate] >= @AV8FromDate)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV9ToDate) )
         {
            AddWhere(sWhereString, "(T1.[ShoppingCartDate] <= @AV9ToDate)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[CustomerName]";
         scmdbuf += ") DistinctT";
         scmdbuf += " ORDER BY [CustomerName]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P000I2(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP000I2;
          prmP000I2 = new Object[] {
          new ParDef("@AV8FromDate",GXType.Date,8,0) ,
          new ParDef("@AV9ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000I2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000I2,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                return;
       }
    }

 }

}
