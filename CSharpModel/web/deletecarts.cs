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
   public class deletecarts : GXProcedure
   {
      public deletecarts( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public deletecarts( IGxContext context )
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
         deletecarts objdeletecarts;
         objdeletecarts = new deletecarts();
         objdeletecarts.AV8FromDate = aP0_FromDate;
         objdeletecarts.AV9ToDate = aP1_ToDate;
         objdeletecarts.context.SetSubmitInitialConfig(context);
         objdeletecarts.initialize();
         Submit( executePrivateCatch,objdeletecarts);
         aP0_FromDate=this.AV8FromDate;
         aP1_ToDate=this.AV9ToDate;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((deletecarts)stateInfo).executePrivate();
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
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV8FromDate ,
                                              AV9ToDate ,
                                              A28ShoppingCartDate } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P000J2 */
         pr_default.execute(0, new Object[] {AV8FromDate, AV9ToDate});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A28ShoppingCartDate = P000J2_A28ShoppingCartDate[0];
            A11ShoppingCartId = P000J2_A11ShoppingCartId[0];
            AV10Shopping.Load(A11ShoppingCartId);
            AV10Shopping.Delete();
            pr_default.readNext(0);
         }
         pr_default.close(0);
         context.CommitDataStores("deletecarts",pr_default);
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
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
         scmdbuf = "";
         A28ShoppingCartDate = DateTime.MinValue;
         P000J2_A28ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         P000J2_A11ShoppingCartId = new short[1] ;
         AV10Shopping = new SdtShoppingCart(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.deletecarts__default(),
            new Object[][] {
                new Object[] {
               P000J2_A28ShoppingCartDate, P000J2_A11ShoppingCartId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A11ShoppingCartId ;
      private string scmdbuf ;
      private DateTime AV8FromDate ;
      private DateTime AV9ToDate ;
      private DateTime A28ShoppingCartDate ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_FromDate ;
      private DateTime aP1_ToDate ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P000J2_A28ShoppingCartDate ;
      private short[] P000J2_A11ShoppingCartId ;
      private SdtShoppingCart AV10Shopping ;
   }

   public class deletecarts__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000J2( IGxContext context ,
                                             DateTime AV8FromDate ,
                                             DateTime AV9ToDate ,
                                             DateTime A28ShoppingCartDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[2];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [ShoppingCartDate], [ShoppingCartId] FROM [ShoppingCart]";
         if ( ! (DateTime.MinValue==AV8FromDate) )
         {
            AddWhere(sWhereString, "([ShoppingCartDate] >= @AV8FromDate)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV9ToDate) )
         {
            AddWhere(sWhereString, "([ShoppingCartDate] <= @AV9ToDate)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ShoppingCartId]";
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
                     return conditional_P000J2(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] );
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
          Object[] prmP000J2;
          prmP000J2 = new Object[] {
          new ParDef("@AV8FromDate",GXType.Date,8,0) ,
          new ParDef("@AV9ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000J2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
