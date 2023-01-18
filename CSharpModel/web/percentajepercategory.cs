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
   public class percentajepercategory : GXProcedure
   {
      public percentajepercategory( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public percentajepercategory( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_CategoryId ,
                           ref short aP1_Percentaje )
      {
         this.AV8CategoryId = aP0_CategoryId;
         this.AV9Percentaje = aP1_Percentaje;
         initialize();
         executePrivate();
         aP0_CategoryId=this.AV8CategoryId;
         aP1_Percentaje=this.AV9Percentaje;
      }

      public short executeUdp( ref short aP0_CategoryId )
      {
         execute(ref aP0_CategoryId, ref aP1_Percentaje);
         return AV9Percentaje ;
      }

      public void executeSubmit( ref short aP0_CategoryId ,
                                 ref short aP1_Percentaje )
      {
         percentajepercategory objpercentajepercategory;
         objpercentajepercategory = new percentajepercategory();
         objpercentajepercategory.AV8CategoryId = aP0_CategoryId;
         objpercentajepercategory.AV9Percentaje = aP1_Percentaje;
         objpercentajepercategory.context.SetSubmitInitialConfig(context);
         objpercentajepercategory.initialize();
         Submit( executePrivateCatch,objpercentajepercategory);
         aP0_CategoryId=this.AV8CategoryId;
         aP1_Percentaje=this.AV9Percentaje;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((percentajepercategory)stateInfo).executePrivate();
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
                                              AV8CategoryId ,
                                              A1CategoryId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P000K2 */
         pr_default.execute(0, new Object[] {AV8CategoryId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1CategoryId = P000K2_A1CategoryId[0];
            A7ProductId = P000K2_A7ProductId[0];
            A2CategoryName = P000K2_A2CategoryName[0];
            A2CategoryName = P000K2_A2CategoryName[0];
            AV10Product.Load(A7ProductId);
            AV11Price = (decimal)(AV10Product.gxTpr_Productprice*(1+AV9Percentaje/ (decimal)(100)));
            AV10Product.gxTpr_Productprice = AV11Price;
            AV10Product.Update();
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( (0==AV8CategoryId) )
         {
            /* Using cursor P000K3 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               A7ProductId = P000K3_A7ProductId[0];
               AV10Product.Load(A7ProductId);
               AV11Price = (decimal)(AV10Product.gxTpr_Productprice*(1+AV9Percentaje/ (decimal)(100)));
               AV10Product.gxTpr_Productprice = AV11Price;
               AV10Product.Update();
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         context.CommitDataStores("percentajepercategory",pr_default);
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
         P000K2_A1CategoryId = new short[1] ;
         P000K2_A7ProductId = new short[1] ;
         P000K2_A2CategoryName = new string[] {""} ;
         A2CategoryName = "";
         AV10Product = new SdtProduct(context);
         P000K3_A7ProductId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.percentajepercategory__default(),
            new Object[][] {
                new Object[] {
               P000K2_A1CategoryId, P000K2_A7ProductId, P000K2_A2CategoryName
               }
               , new Object[] {
               P000K3_A7ProductId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8CategoryId ;
      private short AV9Percentaje ;
      private short A1CategoryId ;
      private short A7ProductId ;
      private decimal AV11Price ;
      private string scmdbuf ;
      private string A2CategoryName ;
      private IGxDataStore dsDefault ;
      private short aP0_CategoryId ;
      private short aP1_Percentaje ;
      private IDataStoreProvider pr_default ;
      private short[] P000K2_A1CategoryId ;
      private short[] P000K2_A7ProductId ;
      private string[] P000K2_A2CategoryName ;
      private short[] P000K3_A7ProductId ;
      private SdtProduct AV10Product ;
   }

   public class percentajepercategory__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000K2( IGxContext context ,
                                             short AV8CategoryId ,
                                             short A1CategoryId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[CategoryId], T1.[ProductId], T2.[CategoryName] FROM ([Product] T1 INNER JOIN [Category] T2 ON T2.[CategoryId] = T1.[CategoryId])";
         if ( ! (0==AV8CategoryId) )
         {
            AddWhere(sWhereString, "(T1.[CategoryId] = @AV8CategoryId)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[CategoryName]";
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
                     return conditional_P000K2(context, (short)dynConstraints[0] , (short)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP000K3;
          prmP000K3 = new Object[] {
          };
          Object[] prmP000K2;
          prmP000K2 = new Object[] {
          new ParDef("@AV8CategoryId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000K2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000K3", "SELECT [ProductId] FROM [Product] ORDER BY [ProductId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000K3,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
