using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class aseller_dataprovider : GXProcedure
   {
      public aseller_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public aseller_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtSeller> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtSeller>( context, "Seller", "TallerJAP2022KarenRubiaca") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtSeller> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtSeller> aP0_Gxm2rootcol )
      {
         aseller_dataprovider objaseller_dataprovider;
         objaseller_dataprovider = new aseller_dataprovider();
         objaseller_dataprovider.Gxm2rootcol = new GXBCCollection<SdtSeller>( context, "Seller", "TallerJAP2022KarenRubiaca") ;
         objaseller_dataprovider.context.SetSubmitInitialConfig(context);
         objaseller_dataprovider.initialize();
         Submit( executePrivateCatch,objaseller_dataprovider);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aseller_dataprovider)stateInfo).executePrivate();
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
         Gxm1seller = new SdtSeller(context);
         Gxm2rootcol.Add(Gxm1seller, 0);
         Gxm1seller.gxTpr_Sellerid = 2;
         Gxm1seller.gxTpr_Sellername = "Ann Sanders";
         Gxm1seller.gxTpr_Sellerphoto = context.convertURL( (string)(context.GetImagePath( "8e8a692e-0170-4fb1-83a4-bfbb7bada663", "", context.GetTheme( ))));
         Gxm1seller.gxTpr_Countryid = 13;
         Gxm1seller = new SdtSeller(context);
         Gxm2rootcol.Add(Gxm1seller, 0);
         Gxm1seller.gxTpr_Sellerid = 3;
         Gxm1seller.gxTpr_Sellername = "Charles Jones";
         Gxm1seller.gxTpr_Sellerphoto = context.convertURL( (string)(context.GetImagePath( "6362b595-fb9c-4294-9a92-77db852d2f28", "", context.GetTheme( ))));
         Gxm1seller.gxTpr_Countryid = 15;
         Gxm1seller = new SdtSeller(context);
         Gxm2rootcol.Add(Gxm1seller, 0);
         Gxm1seller.gxTpr_Sellerid = 4;
         Gxm1seller.gxTpr_Sellername = "James Parker";
         Gxm1seller.gxTpr_Sellerphoto = context.convertURL( (string)(context.GetImagePath( "8e4029c5-34ea-465d-9b5c-8a17a5212f40", "", context.GetTheme( ))));
         Gxm1seller.gxTpr_Countryid = 13;
         Gxm1seller = new SdtSeller(context);
         Gxm2rootcol.Add(Gxm1seller, 0);
         Gxm1seller.gxTpr_Sellerid = 5;
         Gxm1seller.gxTpr_Sellername = "Marc Sarandon";
         Gxm1seller.gxTpr_Sellerphoto = context.convertURL( (string)(context.GetImagePath( "e0f1f065-7311-4d80-8fac-6c9a7503637f", "", context.GetTheme( ))));
         Gxm1seller.gxTpr_Countryid = 18;
         Gxm1seller = new SdtSeller(context);
         Gxm2rootcol.Add(Gxm1seller, 0);
         Gxm1seller.gxTpr_Sellerid = 6;
         Gxm1seller.gxTpr_Sellername = "Melanie Anderson";
         Gxm1seller.gxTpr_Sellerphoto = context.convertURL( (string)(context.GetImagePath( "ece4fcdb-e908-4c7b-8cd8-784ac7102346", "", context.GetTheme( ))));
         Gxm1seller.gxTpr_Countryid = 16;
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
         Gxm1seller = new SdtSeller(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBCCollection<SdtSeller> aP0_Gxm2rootcol ;
      private GXBCCollection<SdtSeller> Gxm2rootcol ;
      private SdtSeller Gxm1seller ;
   }

}
