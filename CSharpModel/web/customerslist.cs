using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Web.Services.Protocols;
using System.Web.Services;
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
   public class customerslist : GXProcedure
   {
      public customerslist( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public customerslist( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref DateTime aP0_FromDate ,
                           ref DateTime aP1_ToDate )
      {
         this.AV2FromDate = aP0_FromDate;
         this.AV3ToDate = aP1_ToDate;
         initialize();
         executePrivate();
         aP0_FromDate=this.AV2FromDate;
         aP1_ToDate=this.AV3ToDate;
      }

      public DateTime executeUdp( ref DateTime aP0_FromDate )
      {
         execute(ref aP0_FromDate, ref aP1_ToDate);
         return AV3ToDate ;
      }

      public void executeSubmit( ref DateTime aP0_FromDate ,
                                 ref DateTime aP1_ToDate )
      {
         customerslist objcustomerslist;
         objcustomerslist = new customerslist();
         objcustomerslist.AV2FromDate = aP0_FromDate;
         objcustomerslist.AV3ToDate = aP1_ToDate;
         objcustomerslist.context.SetSubmitInitialConfig(context);
         objcustomerslist.initialize();
         Submit( executePrivateCatch,objcustomerslist);
         aP0_FromDate=this.AV2FromDate;
         aP1_ToDate=this.AV3ToDate;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((customerslist)stateInfo).executePrivate();
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
         args = new Object[] {(DateTime)AV2FromDate,(DateTime)AV3ToDate} ;
         ClassLoader.Execute("acustomerslist","GeneXus.Programs","acustomerslist", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 2 ) )
         {
            AV2FromDate = (DateTime)(args[0]) ;
            AV3ToDate = (DateTime)(args[1]) ;
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private DateTime AV2FromDate ;
      private DateTime AV3ToDate ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_FromDate ;
      private DateTime aP1_ToDate ;
      private Object[] args ;
   }

}
