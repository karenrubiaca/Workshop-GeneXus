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
   public class aproduct_dataprovider : GXProcedure
   {
      public aproduct_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public aproduct_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtProduct> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtProduct>( context, "Product", "TallerJAP2022KarenRubiaca") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtProduct> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtProduct> aP0_Gxm2rootcol )
      {
         aproduct_dataprovider objaproduct_dataprovider;
         objaproduct_dataprovider = new aproduct_dataprovider();
         objaproduct_dataprovider.Gxm2rootcol = new GXBCCollection<SdtProduct>( context, "Product", "TallerJAP2022KarenRubiaca") ;
         objaproduct_dataprovider.context.SetSubmitInitialConfig(context);
         objaproduct_dataprovider.initialize();
         Submit( executePrivateCatch,objaproduct_dataprovider);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aproduct_dataprovider)stateInfo).executePrivate();
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
         Gxm1product = new SdtProduct(context);
         Gxm2rootcol.Add(Gxm1product, 0);
         Gxm1product.gxTpr_Productid = 2;
         Gxm1product.gxTpr_Productname = "Silver Set";
         Gxm1product.gxTpr_Productdescription = "Latest fine jewelry model with sapphire";
         Gxm1product.gxTpr_Productprice = 195.10m;
         Gxm1product.gxTpr_Productphoto = context.convertURL( (string)(context.GetImagePath( "b317a777-bfa3-4487-ac3f-516d943b6cdb", "", context.GetTheme( ))));
         Gxm1product.gxTpr_Productcountryid = 18;
         Gxm1product.gxTpr_Sellerid = 3;
         Gxm1product.gxTpr_Categoryid = 7;
         Gxm1product = new SdtProduct(context);
         Gxm2rootcol.Add(Gxm1product, 0);
         Gxm1product.gxTpr_Productid = 3;
         Gxm1product.gxTpr_Productname = "Pearl Necklace";
         Gxm1product.gxTpr_Productdescription = "New model";
         Gxm1product.gxTpr_Productprice = 230.00m;
         Gxm1product.gxTpr_Productphoto = context.convertURL( (string)(context.GetImagePath( "59cc28c2-4618-4285-97fe-1ba920efacf2", "", context.GetTheme( ))));
         Gxm1product.gxTpr_Productcountryid = 16;
         Gxm1product.gxTpr_Sellerid = 2;
         Gxm1product.gxTpr_Categoryid = 7;
         Gxm1product = new SdtProduct(context);
         Gxm2rootcol.Add(Gxm1product, 0);
         Gxm1product.gxTpr_Productid = 4;
         Gxm1product.gxTpr_Productname = "Golden ring";
         Gxm1product.gxTpr_Productdescription = "Best quality gold";
         Gxm1product.gxTpr_Productprice = 150.50m;
         Gxm1product.gxTpr_Productphoto = context.convertURL( (string)(context.GetImagePath( "d2f058ab-c29b-4567-9a7b-ca978e528708", "", context.GetTheme( ))));
         Gxm1product.gxTpr_Productcountryid = 15;
         Gxm1product.gxTpr_Sellerid = 4;
         Gxm1product.gxTpr_Categoryid = 7;
         Gxm1product = new SdtProduct(context);
         Gxm2rootcol.Add(Gxm1product, 0);
         Gxm1product.gxTpr_Productid = 5;
         Gxm1product.gxTpr_Productname = "Esmerald ring";
         Gxm1product.gxTpr_Productdescription = "";
         Gxm1product.gxTpr_Productprice = 125.00m;
         Gxm1product.gxTpr_Productphoto = context.convertURL( (string)(context.GetImagePath( "3ded90f9-693e-4a9d-9c57-be3c3dcb6646", "", context.GetTheme( ))));
         Gxm1product.gxTpr_Productcountryid = 13;
         Gxm1product.gxTpr_Sellerid = 3;
         Gxm1product.gxTpr_Categoryid = 7;
         Gxm1product = new SdtProduct(context);
         Gxm2rootcol.Add(Gxm1product, 0);
         Gxm1product.gxTpr_Productid = 6;
         Gxm1product.gxTpr_Productname = "Nacklace and earring";
         Gxm1product.gxTpr_Productdescription = "";
         Gxm1product.gxTpr_Productprice = 230.00m;
         Gxm1product.gxTpr_Productphoto = context.convertURL( (string)(context.GetImagePath( "5249670d-20da-487a-a1eb-95cfe9acb185", "", context.GetTheme( ))));
         Gxm1product.gxTpr_Productcountryid = 14;
         Gxm1product.gxTpr_Sellerid = 5;
         Gxm1product.gxTpr_Categoryid = 7;
         Gxm1product = new SdtProduct(context);
         Gxm2rootcol.Add(Gxm1product, 0);
         Gxm1product.gxTpr_Productid = 7;
         Gxm1product.gxTpr_Productname = "Lady Purse";
         Gxm1product.gxTpr_Productdescription = "";
         Gxm1product.gxTpr_Productprice = 75.00m;
         Gxm1product.gxTpr_Productphoto = context.convertURL( (string)(context.GetImagePath( "6e32ed47-22d1-4a06-903f-6b1a0ab4ef47", "", context.GetTheme( ))));
         Gxm1product.gxTpr_Productcountryid = 15;
         Gxm1product.gxTpr_Sellerid = 3;
         Gxm1product.gxTpr_Categoryid = 6;
         Gxm1product = new SdtProduct(context);
         Gxm2rootcol.Add(Gxm1product, 0);
         Gxm1product.gxTpr_Productid = 8;
         Gxm1product.gxTpr_Productname = "Lady Boots";
         Gxm1product.gxTpr_Productdescription = "";
         Gxm1product.gxTpr_Productprice = 45.00m;
         Gxm1product.gxTpr_Productphoto = context.convertURL( (string)(context.GetImagePath( "67e5b1d3-651f-4b38-ae6e-a07821c646e8", "", context.GetTheme( ))));
         Gxm1product.gxTpr_Productcountryid = 13;
         Gxm1product.gxTpr_Sellerid = 2;
         Gxm1product.gxTpr_Categoryid = 6;
         Gxm1product = new SdtProduct(context);
         Gxm2rootcol.Add(Gxm1product, 0);
         Gxm1product.gxTpr_Productid = 9;
         Gxm1product.gxTpr_Productname = "Lady Jacket";
         Gxm1product.gxTpr_Productdescription = "";
         Gxm1product.gxTpr_Productprice = 98.00m;
         Gxm1product.gxTpr_Productphoto = context.convertURL( (string)(context.GetImagePath( "c085dbf1-c7ae-4359-92ad-0092ea7a922e", "", context.GetTheme( ))));
         Gxm1product.gxTpr_Productcountryid = 18;
         Gxm1product.gxTpr_Sellerid = 2;
         Gxm1product.gxTpr_Categoryid = 6;
         Gxm1product = new SdtProduct(context);
         Gxm2rootcol.Add(Gxm1product, 0);
         Gxm1product.gxTpr_Productid = 10;
         Gxm1product.gxTpr_Productname = "Girl Boots";
         Gxm1product.gxTpr_Productdescription = "";
         Gxm1product.gxTpr_Productprice = 45.00m;
         Gxm1product.gxTpr_Productphoto = context.convertURL( (string)(context.GetImagePath( "c8d84aba-1602-41a3-9bfe-3509c6de36db", "", context.GetTheme( ))));
         Gxm1product.gxTpr_Productcountryid = 17;
         Gxm1product.gxTpr_Sellerid = 6;
         Gxm1product.gxTpr_Categoryid = 6;
         Gxm1product = new SdtProduct(context);
         Gxm2rootcol.Add(Gxm1product, 0);
         Gxm1product.gxTpr_Productid = 11;
         Gxm1product.gxTpr_Productname = "Blood Pressure Meter";
         Gxm1product.gxTpr_Productdescription = "";
         Gxm1product.gxTpr_Productprice = 125.00m;
         Gxm1product.gxTpr_Productphoto = context.convertURL( (string)(context.GetImagePath( "0d09ced4-e8f6-4972-a866-0348c66b8708", "", context.GetTheme( ))));
         Gxm1product.gxTpr_Productcountryid = 17;
         Gxm1product.gxTpr_Sellerid = 4;
         Gxm1product.gxTpr_Categoryid = 10;
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
         Gxm1product = new SdtProduct(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBCCollection<SdtProduct> aP0_Gxm2rootcol ;
      private GXBCCollection<SdtProduct> Gxm2rootcol ;
      private SdtProduct Gxm1product ;
   }

}
