using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Web.Services.Protocols;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlSerializerFormat]
   [XmlRoot(ElementName = "ShoppingCart" )]
   [XmlType(TypeName =  "ShoppingCart" , Namespace = "TallerJAP2022KarenRubiaca" )]
   [Serializable]
   public class SdtShoppingCart : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtShoppingCart( )
      {
      }

      public SdtShoppingCart( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetCallingAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( short AV11ShoppingCartId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV11ShoppingCartId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ShoppingCartId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "ShoppingCart");
         metadata.Set("BT", "ShoppingCart");
         metadata.Set("PK", "[ \"ShoppingCartId\" ]");
         metadata.Set("PKAssigned", "[ \"ShoppingCartId\" ]");
         metadata.Set("Levels", "[ \"Product\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CustomerId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Shoppingcartid_Z");
         state.Add("gxTpr_Shoppingcartdate_Z_Nullable");
         state.Add("gxTpr_Shoppingcartdatedelivery_Z_Nullable");
         state.Add("gxTpr_Customerid_Z");
         state.Add("gxTpr_Customername_Z");
         state.Add("gxTpr_Countryid_Z");
         state.Add("gxTpr_Countryname_Z");
         state.Add("gxTpr_Customeraddress_Z");
         state.Add("gxTpr_Customerphone_Z");
         state.Add("gxTpr_Shoppingcartfinalprice_Z");
         state.Add("gxTpr_Shoppingcartfinalprice_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtShoppingCart sdt;
         sdt = (SdtShoppingCart)(source);
         gxTv_SdtShoppingCart_Shoppingcartid = sdt.gxTv_SdtShoppingCart_Shoppingcartid ;
         gxTv_SdtShoppingCart_Shoppingcartdate = sdt.gxTv_SdtShoppingCart_Shoppingcartdate ;
         gxTv_SdtShoppingCart_Shoppingcartdatedelivery = sdt.gxTv_SdtShoppingCart_Shoppingcartdatedelivery ;
         gxTv_SdtShoppingCart_Customerid = sdt.gxTv_SdtShoppingCart_Customerid ;
         gxTv_SdtShoppingCart_Customername = sdt.gxTv_SdtShoppingCart_Customername ;
         gxTv_SdtShoppingCart_Countryid = sdt.gxTv_SdtShoppingCart_Countryid ;
         gxTv_SdtShoppingCart_Countryname = sdt.gxTv_SdtShoppingCart_Countryname ;
         gxTv_SdtShoppingCart_Customeraddress = sdt.gxTv_SdtShoppingCart_Customeraddress ;
         gxTv_SdtShoppingCart_Customerphone = sdt.gxTv_SdtShoppingCart_Customerphone ;
         gxTv_SdtShoppingCart_Product = sdt.gxTv_SdtShoppingCart_Product ;
         gxTv_SdtShoppingCart_Shoppingcartfinalprice = sdt.gxTv_SdtShoppingCart_Shoppingcartfinalprice ;
         gxTv_SdtShoppingCart_Mode = sdt.gxTv_SdtShoppingCart_Mode ;
         gxTv_SdtShoppingCart_Initialized = sdt.gxTv_SdtShoppingCart_Initialized ;
         gxTv_SdtShoppingCart_Shoppingcartid_Z = sdt.gxTv_SdtShoppingCart_Shoppingcartid_Z ;
         gxTv_SdtShoppingCart_Shoppingcartdate_Z = sdt.gxTv_SdtShoppingCart_Shoppingcartdate_Z ;
         gxTv_SdtShoppingCart_Shoppingcartdatedelivery_Z = sdt.gxTv_SdtShoppingCart_Shoppingcartdatedelivery_Z ;
         gxTv_SdtShoppingCart_Customerid_Z = sdt.gxTv_SdtShoppingCart_Customerid_Z ;
         gxTv_SdtShoppingCart_Customername_Z = sdt.gxTv_SdtShoppingCart_Customername_Z ;
         gxTv_SdtShoppingCart_Countryid_Z = sdt.gxTv_SdtShoppingCart_Countryid_Z ;
         gxTv_SdtShoppingCart_Countryname_Z = sdt.gxTv_SdtShoppingCart_Countryname_Z ;
         gxTv_SdtShoppingCart_Customeraddress_Z = sdt.gxTv_SdtShoppingCart_Customeraddress_Z ;
         gxTv_SdtShoppingCart_Customerphone_Z = sdt.gxTv_SdtShoppingCart_Customerphone_Z ;
         gxTv_SdtShoppingCart_Shoppingcartfinalprice_Z = sdt.gxTv_SdtShoppingCart_Shoppingcartfinalprice_Z ;
         gxTv_SdtShoppingCart_Shoppingcartfinalprice_N = sdt.gxTv_SdtShoppingCart_Shoppingcartfinalprice_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("ShoppingCartId", gxTv_SdtShoppingCart_Shoppingcartid, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtShoppingCart_Shoppingcartdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtShoppingCart_Shoppingcartdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtShoppingCart_Shoppingcartdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("ShoppingCartDate", sDateCnv, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtShoppingCart_Shoppingcartdatedelivery)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtShoppingCart_Shoppingcartdatedelivery)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtShoppingCart_Shoppingcartdatedelivery)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("ShoppingCartDateDelivery", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("CustomerId", gxTv_SdtShoppingCart_Customerid, false, includeNonInitialized);
         AddObjectProperty("CustomerName", gxTv_SdtShoppingCart_Customername, false, includeNonInitialized);
         AddObjectProperty("CountryId", gxTv_SdtShoppingCart_Countryid, false, includeNonInitialized);
         AddObjectProperty("CountryName", gxTv_SdtShoppingCart_Countryname, false, includeNonInitialized);
         AddObjectProperty("CustomerAddress", gxTv_SdtShoppingCart_Customeraddress, false, includeNonInitialized);
         AddObjectProperty("CustomerPhone", gxTv_SdtShoppingCart_Customerphone, false, includeNonInitialized);
         if ( gxTv_SdtShoppingCart_Product != null )
         {
            AddObjectProperty("Product", gxTv_SdtShoppingCart_Product, includeState, includeNonInitialized);
         }
         AddObjectProperty("ShoppingCartFinalPrice", gxTv_SdtShoppingCart_Shoppingcartfinalprice, false, includeNonInitialized);
         AddObjectProperty("ShoppingCartFinalPrice_N", gxTv_SdtShoppingCart_Shoppingcartfinalprice_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtShoppingCart_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtShoppingCart_Initialized, false, includeNonInitialized);
            AddObjectProperty("ShoppingCartId_Z", gxTv_SdtShoppingCart_Shoppingcartid_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtShoppingCart_Shoppingcartdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtShoppingCart_Shoppingcartdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtShoppingCart_Shoppingcartdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("ShoppingCartDate_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtShoppingCart_Shoppingcartdatedelivery_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtShoppingCart_Shoppingcartdatedelivery_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtShoppingCart_Shoppingcartdatedelivery_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("ShoppingCartDateDelivery_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("CustomerId_Z", gxTv_SdtShoppingCart_Customerid_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerName_Z", gxTv_SdtShoppingCart_Customername_Z, false, includeNonInitialized);
            AddObjectProperty("CountryId_Z", gxTv_SdtShoppingCart_Countryid_Z, false, includeNonInitialized);
            AddObjectProperty("CountryName_Z", gxTv_SdtShoppingCart_Countryname_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerAddress_Z", gxTv_SdtShoppingCart_Customeraddress_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerPhone_Z", gxTv_SdtShoppingCart_Customerphone_Z, false, includeNonInitialized);
            AddObjectProperty("ShoppingCartFinalPrice_Z", gxTv_SdtShoppingCart_Shoppingcartfinalprice_Z, false, includeNonInitialized);
            AddObjectProperty("ShoppingCartFinalPrice_N", gxTv_SdtShoppingCart_Shoppingcartfinalprice_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtShoppingCart sdt )
      {
         if ( sdt.IsDirty("ShoppingCartId") )
         {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Shoppingcartid = sdt.gxTv_SdtShoppingCart_Shoppingcartid ;
         }
         if ( sdt.IsDirty("ShoppingCartDate") )
         {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Shoppingcartdate = sdt.gxTv_SdtShoppingCart_Shoppingcartdate ;
         }
         if ( sdt.IsDirty("ShoppingCartDateDelivery") )
         {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Shoppingcartdatedelivery = sdt.gxTv_SdtShoppingCart_Shoppingcartdatedelivery ;
         }
         if ( sdt.IsDirty("CustomerId") )
         {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Customerid = sdt.gxTv_SdtShoppingCart_Customerid ;
         }
         if ( sdt.IsDirty("CustomerName") )
         {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Customername = sdt.gxTv_SdtShoppingCart_Customername ;
         }
         if ( sdt.IsDirty("CountryId") )
         {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Countryid = sdt.gxTv_SdtShoppingCart_Countryid ;
         }
         if ( sdt.IsDirty("CountryName") )
         {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Countryname = sdt.gxTv_SdtShoppingCart_Countryname ;
         }
         if ( sdt.IsDirty("CustomerAddress") )
         {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Customeraddress = sdt.gxTv_SdtShoppingCart_Customeraddress ;
         }
         if ( sdt.IsDirty("CustomerPhone") )
         {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Customerphone = sdt.gxTv_SdtShoppingCart_Customerphone ;
         }
         if ( gxTv_SdtShoppingCart_Product != null )
         {
            GXBCLevelCollection<SdtShoppingCart_Product> newCollectionProduct = sdt.gxTpr_Product;
            SdtShoppingCart_Product currItemProduct;
            SdtShoppingCart_Product newItemProduct;
            short idx = 1;
            while ( idx <= newCollectionProduct.Count )
            {
               newItemProduct = ((SdtShoppingCart_Product)newCollectionProduct.Item(idx));
               currItemProduct = gxTv_SdtShoppingCart_Product.GetByKey(newItemProduct.gxTpr_Productid);
               if ( StringUtil.StrCmp(currItemProduct.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemProduct.UpdateDirties(newItemProduct);
                  if ( StringUtil.StrCmp(newItemProduct.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemProduct.gxTpr_Mode = "DLT";
                  }
                  currItemProduct.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtShoppingCart_Product.Add(newItemProduct, 0);
               }
               idx = (short)(idx+1);
            }
         }
         if ( sdt.IsDirty("ShoppingCartFinalPrice") )
         {
            gxTv_SdtShoppingCart_Shoppingcartfinalprice_N = (short)(sdt.gxTv_SdtShoppingCart_Shoppingcartfinalprice_N);
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Shoppingcartfinalprice = sdt.gxTv_SdtShoppingCart_Shoppingcartfinalprice ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ShoppingCartId" )]
      [  XmlElement( ElementName = "ShoppingCartId"   )]
      public short gxTpr_Shoppingcartid
      {
         get {
            return gxTv_SdtShoppingCart_Shoppingcartid ;
         }

         set {
            gxTv_SdtShoppingCart_N = 0;
            if ( gxTv_SdtShoppingCart_Shoppingcartid != value )
            {
               gxTv_SdtShoppingCart_Mode = "INS";
               this.gxTv_SdtShoppingCart_Shoppingcartid_Z_SetNull( );
               this.gxTv_SdtShoppingCart_Shoppingcartdate_Z_SetNull( );
               this.gxTv_SdtShoppingCart_Shoppingcartdatedelivery_Z_SetNull( );
               this.gxTv_SdtShoppingCart_Customerid_Z_SetNull( );
               this.gxTv_SdtShoppingCart_Customername_Z_SetNull( );
               this.gxTv_SdtShoppingCart_Countryid_Z_SetNull( );
               this.gxTv_SdtShoppingCart_Countryname_Z_SetNull( );
               this.gxTv_SdtShoppingCart_Customeraddress_Z_SetNull( );
               this.gxTv_SdtShoppingCart_Customerphone_Z_SetNull( );
               this.gxTv_SdtShoppingCart_Shoppingcartfinalprice_Z_SetNull( );
               if ( gxTv_SdtShoppingCart_Product != null )
               {
                  GXBCLevelCollection<SdtShoppingCart_Product> collectionProduct = gxTv_SdtShoppingCart_Product;
                  SdtShoppingCart_Product currItemProduct;
                  short idx = 1;
                  while ( idx <= collectionProduct.Count )
                  {
                     currItemProduct = ((SdtShoppingCart_Product)collectionProduct.Item(idx));
                     currItemProduct.gxTpr_Mode = "INS";
                     currItemProduct.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtShoppingCart_Shoppingcartid = value;
            SetDirty("Shoppingcartid");
         }

      }

      [  SoapElement( ElementName = "ShoppingCartDate" )]
      [  XmlElement( ElementName = "ShoppingCartDate"  , IsNullable=true )]
      public string gxTpr_Shoppingcartdate_Nullable
      {
         get {
            if ( gxTv_SdtShoppingCart_Shoppingcartdate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtShoppingCart_Shoppingcartdate).value ;
         }

         set {
            gxTv_SdtShoppingCart_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtShoppingCart_Shoppingcartdate = DateTime.MinValue;
            else
               gxTv_SdtShoppingCart_Shoppingcartdate = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Shoppingcartdate
      {
         get {
            return gxTv_SdtShoppingCart_Shoppingcartdate ;
         }

         set {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Shoppingcartdate = value;
            SetDirty("Shoppingcartdate");
         }

      }

      [  SoapElement( ElementName = "ShoppingCartDateDelivery" )]
      [  XmlElement( ElementName = "ShoppingCartDateDelivery"  , IsNullable=true )]
      public string gxTpr_Shoppingcartdatedelivery_Nullable
      {
         get {
            if ( gxTv_SdtShoppingCart_Shoppingcartdatedelivery == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtShoppingCart_Shoppingcartdatedelivery).value ;
         }

         set {
            gxTv_SdtShoppingCart_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtShoppingCart_Shoppingcartdatedelivery = DateTime.MinValue;
            else
               gxTv_SdtShoppingCart_Shoppingcartdatedelivery = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Shoppingcartdatedelivery
      {
         get {
            return gxTv_SdtShoppingCart_Shoppingcartdatedelivery ;
         }

         set {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Shoppingcartdatedelivery = value;
            SetDirty("Shoppingcartdatedelivery");
         }

      }

      public void gxTv_SdtShoppingCart_Shoppingcartdatedelivery_SetNull( )
      {
         gxTv_SdtShoppingCart_Shoppingcartdatedelivery = (DateTime)(DateTime.MinValue);
         SetDirty("Shoppingcartdatedelivery");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Shoppingcartdatedelivery_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerId" )]
      [  XmlElement( ElementName = "CustomerId"   )]
      public short gxTpr_Customerid
      {
         get {
            return gxTv_SdtShoppingCart_Customerid ;
         }

         set {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Customerid = value;
            SetDirty("Customerid");
         }

      }

      [  SoapElement( ElementName = "CustomerName" )]
      [  XmlElement( ElementName = "CustomerName"   )]
      public string gxTpr_Customername
      {
         get {
            return gxTv_SdtShoppingCart_Customername ;
         }

         set {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Customername = value;
            SetDirty("Customername");
         }

      }

      [  SoapElement( ElementName = "CountryId" )]
      [  XmlElement( ElementName = "CountryId"   )]
      public short gxTpr_Countryid
      {
         get {
            return gxTv_SdtShoppingCart_Countryid ;
         }

         set {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Countryid = value;
            SetDirty("Countryid");
         }

      }

      [  SoapElement( ElementName = "CountryName" )]
      [  XmlElement( ElementName = "CountryName"   )]
      public string gxTpr_Countryname
      {
         get {
            return gxTv_SdtShoppingCart_Countryname ;
         }

         set {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Countryname = value;
            SetDirty("Countryname");
         }

      }

      [  SoapElement( ElementName = "CustomerAddress" )]
      [  XmlElement( ElementName = "CustomerAddress"   )]
      public string gxTpr_Customeraddress
      {
         get {
            return gxTv_SdtShoppingCart_Customeraddress ;
         }

         set {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Customeraddress = value;
            SetDirty("Customeraddress");
         }

      }

      [  SoapElement( ElementName = "CustomerPhone" )]
      [  XmlElement( ElementName = "CustomerPhone"   )]
      public string gxTpr_Customerphone
      {
         get {
            return gxTv_SdtShoppingCart_Customerphone ;
         }

         set {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Customerphone = value;
            SetDirty("Customerphone");
         }

      }

      [  SoapElement( ElementName = "Product" )]
      [  XmlArray( ElementName = "Product"  )]
      [  XmlArrayItemAttribute( ElementName= "ShoppingCart.Product"  , IsNullable=false)]
      public GXBCLevelCollection<SdtShoppingCart_Product> gxTpr_Product_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtShoppingCart_Product == null )
            {
               gxTv_SdtShoppingCart_Product = new GXBCLevelCollection<SdtShoppingCart_Product>( context, "ShoppingCart.Product", "TallerJAP2022KarenRubiaca");
            }
            return gxTv_SdtShoppingCart_Product ;
         }

         set {
            if ( gxTv_SdtShoppingCart_Product == null )
            {
               gxTv_SdtShoppingCart_Product = new GXBCLevelCollection<SdtShoppingCart_Product>( context, "ShoppingCart.Product", "TallerJAP2022KarenRubiaca");
            }
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Product = value;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public GXBCLevelCollection<SdtShoppingCart_Product> gxTpr_Product
      {
         get {
            if ( gxTv_SdtShoppingCart_Product == null )
            {
               gxTv_SdtShoppingCart_Product = new GXBCLevelCollection<SdtShoppingCart_Product>( context, "ShoppingCart.Product", "TallerJAP2022KarenRubiaca");
            }
            gxTv_SdtShoppingCart_N = 0;
            return gxTv_SdtShoppingCart_Product ;
         }

         set {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Product = value;
            SetDirty("Product");
         }

      }

      public void gxTv_SdtShoppingCart_Product_SetNull( )
      {
         gxTv_SdtShoppingCart_Product = null;
         SetDirty("Product");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Product_IsNull( )
      {
         if ( gxTv_SdtShoppingCart_Product == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "ShoppingCartFinalPrice" )]
      [  XmlElement( ElementName = "ShoppingCartFinalPrice"   )]
      public decimal gxTpr_Shoppingcartfinalprice
      {
         get {
            return gxTv_SdtShoppingCart_Shoppingcartfinalprice ;
         }

         set {
            gxTv_SdtShoppingCart_Shoppingcartfinalprice_N = 0;
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Shoppingcartfinalprice = value;
            SetDirty("Shoppingcartfinalprice");
         }

      }

      public void gxTv_SdtShoppingCart_Shoppingcartfinalprice_SetNull( )
      {
         gxTv_SdtShoppingCart_Shoppingcartfinalprice_N = 1;
         gxTv_SdtShoppingCart_Shoppingcartfinalprice = 0;
         SetDirty("Shoppingcartfinalprice");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Shoppingcartfinalprice_IsNull( )
      {
         return (gxTv_SdtShoppingCart_Shoppingcartfinalprice_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtShoppingCart_Mode ;
         }

         set {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtShoppingCart_Mode_SetNull( )
      {
         gxTv_SdtShoppingCart_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtShoppingCart_Initialized ;
         }

         set {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtShoppingCart_Initialized_SetNull( )
      {
         gxTv_SdtShoppingCart_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ShoppingCartId_Z" )]
      [  XmlElement( ElementName = "ShoppingCartId_Z"   )]
      public short gxTpr_Shoppingcartid_Z
      {
         get {
            return gxTv_SdtShoppingCart_Shoppingcartid_Z ;
         }

         set {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Shoppingcartid_Z = value;
            SetDirty("Shoppingcartid_Z");
         }

      }

      public void gxTv_SdtShoppingCart_Shoppingcartid_Z_SetNull( )
      {
         gxTv_SdtShoppingCart_Shoppingcartid_Z = 0;
         SetDirty("Shoppingcartid_Z");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Shoppingcartid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ShoppingCartDate_Z" )]
      [  XmlElement( ElementName = "ShoppingCartDate_Z"  , IsNullable=true )]
      public string gxTpr_Shoppingcartdate_Z_Nullable
      {
         get {
            if ( gxTv_SdtShoppingCart_Shoppingcartdate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtShoppingCart_Shoppingcartdate_Z).value ;
         }

         set {
            gxTv_SdtShoppingCart_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtShoppingCart_Shoppingcartdate_Z = DateTime.MinValue;
            else
               gxTv_SdtShoppingCart_Shoppingcartdate_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Shoppingcartdate_Z
      {
         get {
            return gxTv_SdtShoppingCart_Shoppingcartdate_Z ;
         }

         set {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Shoppingcartdate_Z = value;
            SetDirty("Shoppingcartdate_Z");
         }

      }

      public void gxTv_SdtShoppingCart_Shoppingcartdate_Z_SetNull( )
      {
         gxTv_SdtShoppingCart_Shoppingcartdate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Shoppingcartdate_Z");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Shoppingcartdate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ShoppingCartDateDelivery_Z" )]
      [  XmlElement( ElementName = "ShoppingCartDateDelivery_Z"  , IsNullable=true )]
      public string gxTpr_Shoppingcartdatedelivery_Z_Nullable
      {
         get {
            if ( gxTv_SdtShoppingCart_Shoppingcartdatedelivery_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtShoppingCart_Shoppingcartdatedelivery_Z).value ;
         }

         set {
            gxTv_SdtShoppingCart_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtShoppingCart_Shoppingcartdatedelivery_Z = DateTime.MinValue;
            else
               gxTv_SdtShoppingCart_Shoppingcartdatedelivery_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Shoppingcartdatedelivery_Z
      {
         get {
            return gxTv_SdtShoppingCart_Shoppingcartdatedelivery_Z ;
         }

         set {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Shoppingcartdatedelivery_Z = value;
            SetDirty("Shoppingcartdatedelivery_Z");
         }

      }

      public void gxTv_SdtShoppingCart_Shoppingcartdatedelivery_Z_SetNull( )
      {
         gxTv_SdtShoppingCart_Shoppingcartdatedelivery_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Shoppingcartdatedelivery_Z");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Shoppingcartdatedelivery_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerId_Z" )]
      [  XmlElement( ElementName = "CustomerId_Z"   )]
      public short gxTpr_Customerid_Z
      {
         get {
            return gxTv_SdtShoppingCart_Customerid_Z ;
         }

         set {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Customerid_Z = value;
            SetDirty("Customerid_Z");
         }

      }

      public void gxTv_SdtShoppingCart_Customerid_Z_SetNull( )
      {
         gxTv_SdtShoppingCart_Customerid_Z = 0;
         SetDirty("Customerid_Z");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Customerid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerName_Z" )]
      [  XmlElement( ElementName = "CustomerName_Z"   )]
      public string gxTpr_Customername_Z
      {
         get {
            return gxTv_SdtShoppingCart_Customername_Z ;
         }

         set {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Customername_Z = value;
            SetDirty("Customername_Z");
         }

      }

      public void gxTv_SdtShoppingCart_Customername_Z_SetNull( )
      {
         gxTv_SdtShoppingCart_Customername_Z = "";
         SetDirty("Customername_Z");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Customername_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CountryId_Z" )]
      [  XmlElement( ElementName = "CountryId_Z"   )]
      public short gxTpr_Countryid_Z
      {
         get {
            return gxTv_SdtShoppingCart_Countryid_Z ;
         }

         set {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Countryid_Z = value;
            SetDirty("Countryid_Z");
         }

      }

      public void gxTv_SdtShoppingCart_Countryid_Z_SetNull( )
      {
         gxTv_SdtShoppingCart_Countryid_Z = 0;
         SetDirty("Countryid_Z");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Countryid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CountryName_Z" )]
      [  XmlElement( ElementName = "CountryName_Z"   )]
      public string gxTpr_Countryname_Z
      {
         get {
            return gxTv_SdtShoppingCart_Countryname_Z ;
         }

         set {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Countryname_Z = value;
            SetDirty("Countryname_Z");
         }

      }

      public void gxTv_SdtShoppingCart_Countryname_Z_SetNull( )
      {
         gxTv_SdtShoppingCart_Countryname_Z = "";
         SetDirty("Countryname_Z");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Countryname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerAddress_Z" )]
      [  XmlElement( ElementName = "CustomerAddress_Z"   )]
      public string gxTpr_Customeraddress_Z
      {
         get {
            return gxTv_SdtShoppingCart_Customeraddress_Z ;
         }

         set {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Customeraddress_Z = value;
            SetDirty("Customeraddress_Z");
         }

      }

      public void gxTv_SdtShoppingCart_Customeraddress_Z_SetNull( )
      {
         gxTv_SdtShoppingCart_Customeraddress_Z = "";
         SetDirty("Customeraddress_Z");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Customeraddress_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerPhone_Z" )]
      [  XmlElement( ElementName = "CustomerPhone_Z"   )]
      public string gxTpr_Customerphone_Z
      {
         get {
            return gxTv_SdtShoppingCart_Customerphone_Z ;
         }

         set {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Customerphone_Z = value;
            SetDirty("Customerphone_Z");
         }

      }

      public void gxTv_SdtShoppingCart_Customerphone_Z_SetNull( )
      {
         gxTv_SdtShoppingCart_Customerphone_Z = "";
         SetDirty("Customerphone_Z");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Customerphone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ShoppingCartFinalPrice_Z" )]
      [  XmlElement( ElementName = "ShoppingCartFinalPrice_Z"   )]
      public decimal gxTpr_Shoppingcartfinalprice_Z
      {
         get {
            return gxTv_SdtShoppingCart_Shoppingcartfinalprice_Z ;
         }

         set {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Shoppingcartfinalprice_Z = value;
            SetDirty("Shoppingcartfinalprice_Z");
         }

      }

      public void gxTv_SdtShoppingCart_Shoppingcartfinalprice_Z_SetNull( )
      {
         gxTv_SdtShoppingCart_Shoppingcartfinalprice_Z = 0;
         SetDirty("Shoppingcartfinalprice_Z");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Shoppingcartfinalprice_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ShoppingCartFinalPrice_N" )]
      [  XmlElement( ElementName = "ShoppingCartFinalPrice_N"   )]
      public short gxTpr_Shoppingcartfinalprice_N
      {
         get {
            return gxTv_SdtShoppingCart_Shoppingcartfinalprice_N ;
         }

         set {
            gxTv_SdtShoppingCart_N = 0;
            gxTv_SdtShoppingCart_Shoppingcartfinalprice_N = value;
            SetDirty("Shoppingcartfinalprice_N");
         }

      }

      public void gxTv_SdtShoppingCart_Shoppingcartfinalprice_N_SetNull( )
      {
         gxTv_SdtShoppingCart_Shoppingcartfinalprice_N = 0;
         SetDirty("Shoppingcartfinalprice_N");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Shoppingcartfinalprice_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtShoppingCart_N = 1;
         gxTv_SdtShoppingCart_Shoppingcartdate = DateTime.MinValue;
         gxTv_SdtShoppingCart_Shoppingcartdatedelivery = DateTime.MinValue;
         gxTv_SdtShoppingCart_Customername = "";
         gxTv_SdtShoppingCart_Countryname = "";
         gxTv_SdtShoppingCart_Customeraddress = "";
         gxTv_SdtShoppingCart_Customerphone = "";
         gxTv_SdtShoppingCart_Mode = "";
         gxTv_SdtShoppingCart_Shoppingcartdate_Z = DateTime.MinValue;
         gxTv_SdtShoppingCart_Shoppingcartdatedelivery_Z = DateTime.MinValue;
         gxTv_SdtShoppingCart_Customername_Z = "";
         gxTv_SdtShoppingCart_Countryname_Z = "";
         gxTv_SdtShoppingCart_Customeraddress_Z = "";
         gxTv_SdtShoppingCart_Customerphone_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "shoppingcart", "GeneXus.Programs.shoppingcart_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtShoppingCart_N ;
      }

      private short gxTv_SdtShoppingCart_Shoppingcartid ;
      private short gxTv_SdtShoppingCart_N ;
      private short gxTv_SdtShoppingCart_Customerid ;
      private short gxTv_SdtShoppingCart_Countryid ;
      private short gxTv_SdtShoppingCart_Initialized ;
      private short gxTv_SdtShoppingCart_Shoppingcartid_Z ;
      private short gxTv_SdtShoppingCart_Customerid_Z ;
      private short gxTv_SdtShoppingCart_Countryid_Z ;
      private short gxTv_SdtShoppingCart_Shoppingcartfinalprice_N ;
      private decimal gxTv_SdtShoppingCart_Shoppingcartfinalprice ;
      private decimal gxTv_SdtShoppingCart_Shoppingcartfinalprice_Z ;
      private string gxTv_SdtShoppingCart_Customername ;
      private string gxTv_SdtShoppingCart_Countryname ;
      private string gxTv_SdtShoppingCart_Customerphone ;
      private string gxTv_SdtShoppingCart_Mode ;
      private string gxTv_SdtShoppingCart_Customername_Z ;
      private string gxTv_SdtShoppingCart_Countryname_Z ;
      private string gxTv_SdtShoppingCart_Customerphone_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtShoppingCart_Shoppingcartdate ;
      private DateTime gxTv_SdtShoppingCart_Shoppingcartdatedelivery ;
      private DateTime gxTv_SdtShoppingCart_Shoppingcartdate_Z ;
      private DateTime gxTv_SdtShoppingCart_Shoppingcartdatedelivery_Z ;
      private string gxTv_SdtShoppingCart_Customeraddress ;
      private string gxTv_SdtShoppingCart_Customeraddress_Z ;
      private GXBCLevelCollection<SdtShoppingCart_Product> gxTv_SdtShoppingCart_Product=null ;
   }

   [DataContract(Name = @"ShoppingCart", Namespace = "TallerJAP2022KarenRubiaca")]
   public class SdtShoppingCart_RESTInterface : GxGenericCollectionItem<SdtShoppingCart>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtShoppingCart_RESTInterface( ) : base()
      {
      }

      public SdtShoppingCart_RESTInterface( SdtShoppingCart psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ShoppingCartId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Shoppingcartid
      {
         get {
            return sdt.gxTpr_Shoppingcartid ;
         }

         set {
            sdt.gxTpr_Shoppingcartid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ShoppingCartDate" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Shoppingcartdate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Shoppingcartdate) ;
         }

         set {
            sdt.gxTpr_Shoppingcartdate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "ShoppingCartDateDelivery" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Shoppingcartdatedelivery
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Shoppingcartdatedelivery) ;
         }

         set {
            sdt.gxTpr_Shoppingcartdatedelivery = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "CustomerId" , Order = 3 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Customerid
      {
         get {
            return sdt.gxTpr_Customerid ;
         }

         set {
            sdt.gxTpr_Customerid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CustomerName" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Customername
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Customername) ;
         }

         set {
            sdt.gxTpr_Customername = value;
         }

      }

      [DataMember( Name = "CountryId" , Order = 5 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Countryid
      {
         get {
            return sdt.gxTpr_Countryid ;
         }

         set {
            sdt.gxTpr_Countryid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CountryName" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Countryname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Countryname) ;
         }

         set {
            sdt.gxTpr_Countryname = value;
         }

      }

      [DataMember( Name = "CustomerAddress" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Customeraddress
      {
         get {
            return sdt.gxTpr_Customeraddress ;
         }

         set {
            sdt.gxTpr_Customeraddress = value;
         }

      }

      [DataMember( Name = "CustomerPhone" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Customerphone
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Customerphone) ;
         }

         set {
            sdt.gxTpr_Customerphone = value;
         }

      }

      [DataMember( Name = "Product" , Order = 9 )]
      public GxGenericCollection<SdtShoppingCart_Product_RESTInterface> gxTpr_Product
      {
         get {
            return new GxGenericCollection<SdtShoppingCart_Product_RESTInterface>(sdt.gxTpr_Product) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Product);
         }

      }

      [DataMember( Name = "ShoppingCartFinalPrice" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Shoppingcartfinalprice
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Shoppingcartfinalprice, 10, 2)) ;
         }

         set {
            sdt.gxTpr_Shoppingcartfinalprice = NumberUtil.Val( value, ".");
         }

      }

      public SdtShoppingCart sdt
      {
         get {
            return (SdtShoppingCart)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtShoppingCart() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 11 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"ShoppingCart", Namespace = "TallerJAP2022KarenRubiaca")]
   public class SdtShoppingCart_RESTLInterface : GxGenericCollectionItem<SdtShoppingCart>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtShoppingCart_RESTLInterface( ) : base()
      {
      }

      public SdtShoppingCart_RESTLInterface( SdtShoppingCart psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ShoppingCartDate" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Shoppingcartdate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Shoppingcartdate) ;
         }

         set {
            sdt.gxTpr_Shoppingcartdate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtShoppingCart sdt
      {
         get {
            return (SdtShoppingCart)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtShoppingCart() ;
         }
      }

   }

}
