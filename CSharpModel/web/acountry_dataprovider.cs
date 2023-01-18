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
   public class acountry_dataprovider : GXProcedure
   {
      public acountry_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public acountry_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtCountry> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtCountry>( context, "Country", "TallerJAP2022KarenRubiaca") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtCountry> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtCountry> aP0_Gxm2rootcol )
      {
         acountry_dataprovider objacountry_dataprovider;
         objacountry_dataprovider = new acountry_dataprovider();
         objacountry_dataprovider.Gxm2rootcol = new GXBCCollection<SdtCountry>( context, "Country", "TallerJAP2022KarenRubiaca") ;
         objacountry_dataprovider.context.SetSubmitInitialConfig(context);
         objacountry_dataprovider.initialize();
         Submit( executePrivateCatch,objacountry_dataprovider);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((acountry_dataprovider)stateInfo).executePrivate();
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
         Gxm1country = new SdtCountry(context);
         Gxm2rootcol.Add(Gxm1country, 0);
         Gxm1country.gxTpr_Countryid = 13;
         Gxm1country.gxTpr_Countryname = "Uruguay";
         Gxm1country.gxTpr_Countryflag = context.convertURL( (string)(context.GetImagePath( "7d81c999-2f06-4a82-8942-939cc67c4f04", "", context.GetTheme( ))));
         Gxm1country = new SdtCountry(context);
         Gxm2rootcol.Add(Gxm1country, 0);
         Gxm1country.gxTpr_Countryid = 14;
         Gxm1country.gxTpr_Countryname = "Brasil";
         Gxm1country.gxTpr_Countryflag = context.convertURL( (string)(context.GetImagePath( "4af06fb7-2d2d-4745-8c7e-bf30e65f0d11", "", context.GetTheme( ))));
         Gxm1country = new SdtCountry(context);
         Gxm2rootcol.Add(Gxm1country, 0);
         Gxm1country.gxTpr_Countryid = 15;
         Gxm1country.gxTpr_Countryname = "Argentina";
         Gxm1country.gxTpr_Countryflag = context.convertURL( (string)(context.GetImagePath( "dd13fce6-51ee-4984-86c6-c7e27477c444", "", context.GetTheme( ))));
         Gxm1country = new SdtCountry(context);
         Gxm2rootcol.Add(Gxm1country, 0);
         Gxm1country.gxTpr_Countryid = 16;
         Gxm1country.gxTpr_Countryname = "México";
         Gxm1country.gxTpr_Countryflag = context.convertURL( (string)(context.GetImagePath( "8a122c0e-2712-4de5-8c5b-9612d05ac872", "", context.GetTheme( ))));
         Gxm1country = new SdtCountry(context);
         Gxm2rootcol.Add(Gxm1country, 0);
         Gxm1country.gxTpr_Countryid = 17;
         Gxm1country.gxTpr_Countryname = "China";
         Gxm1country.gxTpr_Countryflag = context.convertURL( (string)(context.GetImagePath( "8236d1fd-de64-4768-84ea-958e9581a937", "", context.GetTheme( ))));
         Gxm1country = new SdtCountry(context);
         Gxm2rootcol.Add(Gxm1country, 0);
         Gxm1country.gxTpr_Countryid = 18;
         Gxm1country.gxTpr_Countryname = "Estados Unidos";
         Gxm1country.gxTpr_Countryflag = context.convertURL( (string)(context.GetImagePath( "38591e5e-8e7c-43cb-88f9-45cccb578ea6", "", context.GetTheme( ))));
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
         Gxm1country = new SdtCountry(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBCCollection<SdtCountry> aP0_Gxm2rootcol ;
      private GXBCCollection<SdtCountry> Gxm2rootcol ;
      private SdtCountry Gxm1country ;
   }

}
