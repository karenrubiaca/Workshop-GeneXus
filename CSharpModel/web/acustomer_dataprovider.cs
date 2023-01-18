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
   public class acustomer_dataprovider : GXProcedure
   {
      public acustomer_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public acustomer_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtCustomer> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtCustomer>( context, "Customer", "TallerJAP2022KarenRubiaca") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtCustomer> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtCustomer> aP0_Gxm2rootcol )
      {
         acustomer_dataprovider objacustomer_dataprovider;
         objacustomer_dataprovider = new acustomer_dataprovider();
         objacustomer_dataprovider.Gxm2rootcol = new GXBCCollection<SdtCustomer>( context, "Customer", "TallerJAP2022KarenRubiaca") ;
         objacustomer_dataprovider.context.SetSubmitInitialConfig(context);
         objacustomer_dataprovider.initialize();
         Submit( executePrivateCatch,objacustomer_dataprovider);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((acustomer_dataprovider)stateInfo).executePrivate();
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
         Gxm1customer = new SdtCustomer(context);
         Gxm2rootcol.Add(Gxm1customer, 0);
         Gxm1customer.gxTpr_Customerid = 2;
         Gxm1customer.gxTpr_Customername = "Alexandra Smith";
         Gxm1customer.gxTpr_Customeraddress = "Pedro Berro 1279";
         Gxm1customer.gxTpr_Customeremail = "alexandra@hotmail.com";
         Gxm1customer.gxTpr_Customerphone = "098765432";
         Gxm1customer.gxTpr_Countryid = 13;
         Gxm1customer = new SdtCustomer(context);
         Gxm2rootcol.Add(Gxm1customer, 0);
         Gxm1customer.gxTpr_Customerid = 3;
         Gxm1customer.gxTpr_Customername = "Jonathan Andrews";
         Gxm1customer.gxTpr_Customeraddress = "5th avenue 1547";
         Gxm1customer.gxTpr_Customeremail = "pedro@hotmail.com";
         Gxm1customer.gxTpr_Customerphone = "099765432";
         Gxm1customer.gxTpr_Countryid = 18;
         Gxm1customer = new SdtCustomer(context);
         Gxm2rootcol.Add(Gxm1customer, 0);
         Gxm1customer.gxTpr_Customerid = 4;
         Gxm1customer.gxTpr_Customername = "Richard Cruise";
         Gxm1customer.gxTpr_Customeraddress = "3rd Avenue 444";
         Gxm1customer.gxTpr_Customeremail = "richard@gmail.com";
         Gxm1customer.gxTpr_Customerphone = "094333222";
         Gxm1customer.gxTpr_Countryid = 18;
         Gxm1customer = new SdtCustomer(context);
         Gxm2rootcol.Add(Gxm1customer, 0);
         Gxm1customer.gxTpr_Customerid = 5;
         Gxm1customer.gxTpr_Customername = "Maria Cabrera";
         Gxm1customer.gxTpr_Customeraddress = "Concepción 1830";
         Gxm1customer.gxTpr_Customeremail = "mariacabrera@gmail.com";
         Gxm1customer.gxTpr_Customerphone = "096334867";
         Gxm1customer.gxTpr_Countryid = 16;
         Gxm1customer = new SdtCustomer(context);
         Gxm2rootcol.Add(Gxm1customer, 0);
         Gxm1customer.gxTpr_Customerid = 6;
         Gxm1customer.gxTpr_Customername = "Adriana Gómez";
         Gxm1customer.gxTpr_Customeraddress = "9 de Julio 333";
         Gxm1customer.gxTpr_Customeremail = "adriana@hotmail.com";
         Gxm1customer.gxTpr_Customerphone = "098787654";
         Gxm1customer.gxTpr_Countryid = 15;
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
         Gxm1customer = new SdtCustomer(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBCCollection<SdtCustomer> aP0_Gxm2rootcol ;
      private GXBCCollection<SdtCustomer> Gxm2rootcol ;
      private SdtCustomer Gxm1customer ;
   }

}
