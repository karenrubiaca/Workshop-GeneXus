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
   [XmlRoot(ElementName = "Product" )]
   [XmlType(TypeName =  "Product" , Namespace = "TallerJAP2022KarenRubiaca" )]
   [Serializable]
   public class SdtProduct : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtProduct( )
      {
      }

      public SdtProduct( IGxContext context )
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

      public void Load( short AV7ProductId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV7ProductId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ProductId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Product");
         metadata.Set("BT", "Product");
         metadata.Set("PK", "[ \"ProductId\" ]");
         metadata.Set("PKAssigned", "[ \"ProductId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CategoryId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"CountryId\" ],\"FKMap\":[ \"ProductCountryId-CountryId\" ] },{ \"FK\":[ \"SellerId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Productphoto_gxi");
         state.Add("gxTpr_Sellerphoto_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Productid_Z");
         state.Add("gxTpr_Productname_Z");
         state.Add("gxTpr_Productdescription_Z");
         state.Add("gxTpr_Productprice_Z");
         state.Add("gxTpr_Productcountryid_Z");
         state.Add("gxTpr_Productcountryname_Z");
         state.Add("gxTpr_Sellerid_Z");
         state.Add("gxTpr_Sellername_Z");
         state.Add("gxTpr_Categoryid_Z");
         state.Add("gxTpr_Categoryname_Z");
         state.Add("gxTpr_Countryid_Z");
         state.Add("gxTpr_Countryname_Z");
         state.Add("gxTpr_Productphoto_gxi_Z");
         state.Add("gxTpr_Sellerphoto_gxi_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtProduct sdt;
         sdt = (SdtProduct)(source);
         gxTv_SdtProduct_Productid = sdt.gxTv_SdtProduct_Productid ;
         gxTv_SdtProduct_Productname = sdt.gxTv_SdtProduct_Productname ;
         gxTv_SdtProduct_Productdescription = sdt.gxTv_SdtProduct_Productdescription ;
         gxTv_SdtProduct_Productprice = sdt.gxTv_SdtProduct_Productprice ;
         gxTv_SdtProduct_Productphoto = sdt.gxTv_SdtProduct_Productphoto ;
         gxTv_SdtProduct_Productphoto_gxi = sdt.gxTv_SdtProduct_Productphoto_gxi ;
         gxTv_SdtProduct_Productcountryid = sdt.gxTv_SdtProduct_Productcountryid ;
         gxTv_SdtProduct_Productcountryname = sdt.gxTv_SdtProduct_Productcountryname ;
         gxTv_SdtProduct_Sellerid = sdt.gxTv_SdtProduct_Sellerid ;
         gxTv_SdtProduct_Sellername = sdt.gxTv_SdtProduct_Sellername ;
         gxTv_SdtProduct_Sellerphoto = sdt.gxTv_SdtProduct_Sellerphoto ;
         gxTv_SdtProduct_Sellerphoto_gxi = sdt.gxTv_SdtProduct_Sellerphoto_gxi ;
         gxTv_SdtProduct_Categoryid = sdt.gxTv_SdtProduct_Categoryid ;
         gxTv_SdtProduct_Categoryname = sdt.gxTv_SdtProduct_Categoryname ;
         gxTv_SdtProduct_Countryid = sdt.gxTv_SdtProduct_Countryid ;
         gxTv_SdtProduct_Countryname = sdt.gxTv_SdtProduct_Countryname ;
         gxTv_SdtProduct_Mode = sdt.gxTv_SdtProduct_Mode ;
         gxTv_SdtProduct_Initialized = sdt.gxTv_SdtProduct_Initialized ;
         gxTv_SdtProduct_Productid_Z = sdt.gxTv_SdtProduct_Productid_Z ;
         gxTv_SdtProduct_Productname_Z = sdt.gxTv_SdtProduct_Productname_Z ;
         gxTv_SdtProduct_Productdescription_Z = sdt.gxTv_SdtProduct_Productdescription_Z ;
         gxTv_SdtProduct_Productprice_Z = sdt.gxTv_SdtProduct_Productprice_Z ;
         gxTv_SdtProduct_Productcountryid_Z = sdt.gxTv_SdtProduct_Productcountryid_Z ;
         gxTv_SdtProduct_Productcountryname_Z = sdt.gxTv_SdtProduct_Productcountryname_Z ;
         gxTv_SdtProduct_Sellerid_Z = sdt.gxTv_SdtProduct_Sellerid_Z ;
         gxTv_SdtProduct_Sellername_Z = sdt.gxTv_SdtProduct_Sellername_Z ;
         gxTv_SdtProduct_Categoryid_Z = sdt.gxTv_SdtProduct_Categoryid_Z ;
         gxTv_SdtProduct_Categoryname_Z = sdt.gxTv_SdtProduct_Categoryname_Z ;
         gxTv_SdtProduct_Countryid_Z = sdt.gxTv_SdtProduct_Countryid_Z ;
         gxTv_SdtProduct_Countryname_Z = sdt.gxTv_SdtProduct_Countryname_Z ;
         gxTv_SdtProduct_Productphoto_gxi_Z = sdt.gxTv_SdtProduct_Productphoto_gxi_Z ;
         gxTv_SdtProduct_Sellerphoto_gxi_Z = sdt.gxTv_SdtProduct_Sellerphoto_gxi_Z ;
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
         AddObjectProperty("ProductId", gxTv_SdtProduct_Productid, false, includeNonInitialized);
         AddObjectProperty("ProductName", gxTv_SdtProduct_Productname, false, includeNonInitialized);
         AddObjectProperty("ProductDescription", gxTv_SdtProduct_Productdescription, false, includeNonInitialized);
         AddObjectProperty("ProductPrice", gxTv_SdtProduct_Productprice, false, includeNonInitialized);
         AddObjectProperty("ProductPhoto", gxTv_SdtProduct_Productphoto, false, includeNonInitialized);
         AddObjectProperty("ProductCountryId", gxTv_SdtProduct_Productcountryid, false, includeNonInitialized);
         AddObjectProperty("ProductCountryName", gxTv_SdtProduct_Productcountryname, false, includeNonInitialized);
         AddObjectProperty("SellerId", gxTv_SdtProduct_Sellerid, false, includeNonInitialized);
         AddObjectProperty("SellerName", gxTv_SdtProduct_Sellername, false, includeNonInitialized);
         AddObjectProperty("SellerPhoto", gxTv_SdtProduct_Sellerphoto, false, includeNonInitialized);
         AddObjectProperty("CategoryId", gxTv_SdtProduct_Categoryid, false, includeNonInitialized);
         AddObjectProperty("CategoryName", gxTv_SdtProduct_Categoryname, false, includeNonInitialized);
         AddObjectProperty("CountryId", gxTv_SdtProduct_Countryid, false, includeNonInitialized);
         AddObjectProperty("CountryName", gxTv_SdtProduct_Countryname, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("ProductPhoto_GXI", gxTv_SdtProduct_Productphoto_gxi, false, includeNonInitialized);
            AddObjectProperty("SellerPhoto_GXI", gxTv_SdtProduct_Sellerphoto_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtProduct_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtProduct_Initialized, false, includeNonInitialized);
            AddObjectProperty("ProductId_Z", gxTv_SdtProduct_Productid_Z, false, includeNonInitialized);
            AddObjectProperty("ProductName_Z", gxTv_SdtProduct_Productname_Z, false, includeNonInitialized);
            AddObjectProperty("ProductDescription_Z", gxTv_SdtProduct_Productdescription_Z, false, includeNonInitialized);
            AddObjectProperty("ProductPrice_Z", gxTv_SdtProduct_Productprice_Z, false, includeNonInitialized);
            AddObjectProperty("ProductCountryId_Z", gxTv_SdtProduct_Productcountryid_Z, false, includeNonInitialized);
            AddObjectProperty("ProductCountryName_Z", gxTv_SdtProduct_Productcountryname_Z, false, includeNonInitialized);
            AddObjectProperty("SellerId_Z", gxTv_SdtProduct_Sellerid_Z, false, includeNonInitialized);
            AddObjectProperty("SellerName_Z", gxTv_SdtProduct_Sellername_Z, false, includeNonInitialized);
            AddObjectProperty("CategoryId_Z", gxTv_SdtProduct_Categoryid_Z, false, includeNonInitialized);
            AddObjectProperty("CategoryName_Z", gxTv_SdtProduct_Categoryname_Z, false, includeNonInitialized);
            AddObjectProperty("CountryId_Z", gxTv_SdtProduct_Countryid_Z, false, includeNonInitialized);
            AddObjectProperty("CountryName_Z", gxTv_SdtProduct_Countryname_Z, false, includeNonInitialized);
            AddObjectProperty("ProductPhoto_GXI_Z", gxTv_SdtProduct_Productphoto_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("SellerPhoto_GXI_Z", gxTv_SdtProduct_Sellerphoto_gxi_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtProduct sdt )
      {
         if ( sdt.IsDirty("ProductId") )
         {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productid = sdt.gxTv_SdtProduct_Productid ;
         }
         if ( sdt.IsDirty("ProductName") )
         {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productname = sdt.gxTv_SdtProduct_Productname ;
         }
         if ( sdt.IsDirty("ProductDescription") )
         {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productdescription = sdt.gxTv_SdtProduct_Productdescription ;
         }
         if ( sdt.IsDirty("ProductPrice") )
         {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productprice = sdt.gxTv_SdtProduct_Productprice ;
         }
         if ( sdt.IsDirty("ProductPhoto") )
         {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productphoto = sdt.gxTv_SdtProduct_Productphoto ;
         }
         if ( sdt.IsDirty("ProductPhoto") )
         {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productphoto_gxi = sdt.gxTv_SdtProduct_Productphoto_gxi ;
         }
         if ( sdt.IsDirty("ProductCountryId") )
         {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productcountryid = sdt.gxTv_SdtProduct_Productcountryid ;
         }
         if ( sdt.IsDirty("ProductCountryName") )
         {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productcountryname = sdt.gxTv_SdtProduct_Productcountryname ;
         }
         if ( sdt.IsDirty("SellerId") )
         {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Sellerid = sdt.gxTv_SdtProduct_Sellerid ;
         }
         if ( sdt.IsDirty("SellerName") )
         {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Sellername = sdt.gxTv_SdtProduct_Sellername ;
         }
         if ( sdt.IsDirty("SellerPhoto") )
         {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Sellerphoto = sdt.gxTv_SdtProduct_Sellerphoto ;
         }
         if ( sdt.IsDirty("SellerPhoto") )
         {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Sellerphoto_gxi = sdt.gxTv_SdtProduct_Sellerphoto_gxi ;
         }
         if ( sdt.IsDirty("CategoryId") )
         {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Categoryid = sdt.gxTv_SdtProduct_Categoryid ;
         }
         if ( sdt.IsDirty("CategoryName") )
         {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Categoryname = sdt.gxTv_SdtProduct_Categoryname ;
         }
         if ( sdt.IsDirty("CountryId") )
         {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Countryid = sdt.gxTv_SdtProduct_Countryid ;
         }
         if ( sdt.IsDirty("CountryName") )
         {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Countryname = sdt.gxTv_SdtProduct_Countryname ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ProductId" )]
      [  XmlElement( ElementName = "ProductId"   )]
      public short gxTpr_Productid
      {
         get {
            return gxTv_SdtProduct_Productid ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            if ( gxTv_SdtProduct_Productid != value )
            {
               gxTv_SdtProduct_Mode = "INS";
               this.gxTv_SdtProduct_Productid_Z_SetNull( );
               this.gxTv_SdtProduct_Productname_Z_SetNull( );
               this.gxTv_SdtProduct_Productdescription_Z_SetNull( );
               this.gxTv_SdtProduct_Productprice_Z_SetNull( );
               this.gxTv_SdtProduct_Productcountryid_Z_SetNull( );
               this.gxTv_SdtProduct_Productcountryname_Z_SetNull( );
               this.gxTv_SdtProduct_Sellerid_Z_SetNull( );
               this.gxTv_SdtProduct_Sellername_Z_SetNull( );
               this.gxTv_SdtProduct_Categoryid_Z_SetNull( );
               this.gxTv_SdtProduct_Categoryname_Z_SetNull( );
               this.gxTv_SdtProduct_Countryid_Z_SetNull( );
               this.gxTv_SdtProduct_Countryname_Z_SetNull( );
               this.gxTv_SdtProduct_Productphoto_gxi_Z_SetNull( );
               this.gxTv_SdtProduct_Sellerphoto_gxi_Z_SetNull( );
            }
            gxTv_SdtProduct_Productid = value;
            SetDirty("Productid");
         }

      }

      [  SoapElement( ElementName = "ProductName" )]
      [  XmlElement( ElementName = "ProductName"   )]
      public string gxTpr_Productname
      {
         get {
            return gxTv_SdtProduct_Productname ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productname = value;
            SetDirty("Productname");
         }

      }

      [  SoapElement( ElementName = "ProductDescription" )]
      [  XmlElement( ElementName = "ProductDescription"   )]
      public string gxTpr_Productdescription
      {
         get {
            return gxTv_SdtProduct_Productdescription ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productdescription = value;
            SetDirty("Productdescription");
         }

      }

      [  SoapElement( ElementName = "ProductPrice" )]
      [  XmlElement( ElementName = "ProductPrice"   )]
      public decimal gxTpr_Productprice
      {
         get {
            return gxTv_SdtProduct_Productprice ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productprice = value;
            SetDirty("Productprice");
         }

      }

      [  SoapElement( ElementName = "ProductPhoto" )]
      [  XmlElement( ElementName = "ProductPhoto"   )]
      [GxUpload()]
      public string gxTpr_Productphoto
      {
         get {
            return gxTv_SdtProduct_Productphoto ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productphoto = value;
            SetDirty("Productphoto");
         }

      }

      [  SoapElement( ElementName = "ProductPhoto_GXI" )]
      [  XmlElement( ElementName = "ProductPhoto_GXI"   )]
      public string gxTpr_Productphoto_gxi
      {
         get {
            return gxTv_SdtProduct_Productphoto_gxi ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productphoto_gxi = value;
            SetDirty("Productphoto_gxi");
         }

      }

      [  SoapElement( ElementName = "ProductCountryId" )]
      [  XmlElement( ElementName = "ProductCountryId"   )]
      public short gxTpr_Productcountryid
      {
         get {
            return gxTv_SdtProduct_Productcountryid ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productcountryid = value;
            SetDirty("Productcountryid");
         }

      }

      [  SoapElement( ElementName = "ProductCountryName" )]
      [  XmlElement( ElementName = "ProductCountryName"   )]
      public string gxTpr_Productcountryname
      {
         get {
            return gxTv_SdtProduct_Productcountryname ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productcountryname = value;
            SetDirty("Productcountryname");
         }

      }

      [  SoapElement( ElementName = "SellerId" )]
      [  XmlElement( ElementName = "SellerId"   )]
      public short gxTpr_Sellerid
      {
         get {
            return gxTv_SdtProduct_Sellerid ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Sellerid = value;
            SetDirty("Sellerid");
         }

      }

      [  SoapElement( ElementName = "SellerName" )]
      [  XmlElement( ElementName = "SellerName"   )]
      public string gxTpr_Sellername
      {
         get {
            return gxTv_SdtProduct_Sellername ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Sellername = value;
            SetDirty("Sellername");
         }

      }

      [  SoapElement( ElementName = "SellerPhoto" )]
      [  XmlElement( ElementName = "SellerPhoto"   )]
      [GxUpload()]
      public string gxTpr_Sellerphoto
      {
         get {
            return gxTv_SdtProduct_Sellerphoto ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Sellerphoto = value;
            SetDirty("Sellerphoto");
         }

      }

      [  SoapElement( ElementName = "SellerPhoto_GXI" )]
      [  XmlElement( ElementName = "SellerPhoto_GXI"   )]
      public string gxTpr_Sellerphoto_gxi
      {
         get {
            return gxTv_SdtProduct_Sellerphoto_gxi ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Sellerphoto_gxi = value;
            SetDirty("Sellerphoto_gxi");
         }

      }

      [  SoapElement( ElementName = "CategoryId" )]
      [  XmlElement( ElementName = "CategoryId"   )]
      public short gxTpr_Categoryid
      {
         get {
            return gxTv_SdtProduct_Categoryid ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Categoryid = value;
            SetDirty("Categoryid");
         }

      }

      [  SoapElement( ElementName = "CategoryName" )]
      [  XmlElement( ElementName = "CategoryName"   )]
      public string gxTpr_Categoryname
      {
         get {
            return gxTv_SdtProduct_Categoryname ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Categoryname = value;
            SetDirty("Categoryname");
         }

      }

      [  SoapElement( ElementName = "CountryId" )]
      [  XmlElement( ElementName = "CountryId"   )]
      public short gxTpr_Countryid
      {
         get {
            return gxTv_SdtProduct_Countryid ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Countryid = value;
            SetDirty("Countryid");
         }

      }

      [  SoapElement( ElementName = "CountryName" )]
      [  XmlElement( ElementName = "CountryName"   )]
      public string gxTpr_Countryname
      {
         get {
            return gxTv_SdtProduct_Countryname ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Countryname = value;
            SetDirty("Countryname");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtProduct_Mode ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtProduct_Mode_SetNull( )
      {
         gxTv_SdtProduct_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtProduct_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtProduct_Initialized ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtProduct_Initialized_SetNull( )
      {
         gxTv_SdtProduct_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtProduct_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductId_Z" )]
      [  XmlElement( ElementName = "ProductId_Z"   )]
      public short gxTpr_Productid_Z
      {
         get {
            return gxTv_SdtProduct_Productid_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productid_Z = value;
            SetDirty("Productid_Z");
         }

      }

      public void gxTv_SdtProduct_Productid_Z_SetNull( )
      {
         gxTv_SdtProduct_Productid_Z = 0;
         SetDirty("Productid_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductName_Z" )]
      [  XmlElement( ElementName = "ProductName_Z"   )]
      public string gxTpr_Productname_Z
      {
         get {
            return gxTv_SdtProduct_Productname_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productname_Z = value;
            SetDirty("Productname_Z");
         }

      }

      public void gxTv_SdtProduct_Productname_Z_SetNull( )
      {
         gxTv_SdtProduct_Productname_Z = "";
         SetDirty("Productname_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductDescription_Z" )]
      [  XmlElement( ElementName = "ProductDescription_Z"   )]
      public string gxTpr_Productdescription_Z
      {
         get {
            return gxTv_SdtProduct_Productdescription_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productdescription_Z = value;
            SetDirty("Productdescription_Z");
         }

      }

      public void gxTv_SdtProduct_Productdescription_Z_SetNull( )
      {
         gxTv_SdtProduct_Productdescription_Z = "";
         SetDirty("Productdescription_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productdescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductPrice_Z" )]
      [  XmlElement( ElementName = "ProductPrice_Z"   )]
      public decimal gxTpr_Productprice_Z
      {
         get {
            return gxTv_SdtProduct_Productprice_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productprice_Z = value;
            SetDirty("Productprice_Z");
         }

      }

      public void gxTv_SdtProduct_Productprice_Z_SetNull( )
      {
         gxTv_SdtProduct_Productprice_Z = 0;
         SetDirty("Productprice_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productprice_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductCountryId_Z" )]
      [  XmlElement( ElementName = "ProductCountryId_Z"   )]
      public short gxTpr_Productcountryid_Z
      {
         get {
            return gxTv_SdtProduct_Productcountryid_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productcountryid_Z = value;
            SetDirty("Productcountryid_Z");
         }

      }

      public void gxTv_SdtProduct_Productcountryid_Z_SetNull( )
      {
         gxTv_SdtProduct_Productcountryid_Z = 0;
         SetDirty("Productcountryid_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productcountryid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductCountryName_Z" )]
      [  XmlElement( ElementName = "ProductCountryName_Z"   )]
      public string gxTpr_Productcountryname_Z
      {
         get {
            return gxTv_SdtProduct_Productcountryname_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productcountryname_Z = value;
            SetDirty("Productcountryname_Z");
         }

      }

      public void gxTv_SdtProduct_Productcountryname_Z_SetNull( )
      {
         gxTv_SdtProduct_Productcountryname_Z = "";
         SetDirty("Productcountryname_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productcountryname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SellerId_Z" )]
      [  XmlElement( ElementName = "SellerId_Z"   )]
      public short gxTpr_Sellerid_Z
      {
         get {
            return gxTv_SdtProduct_Sellerid_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Sellerid_Z = value;
            SetDirty("Sellerid_Z");
         }

      }

      public void gxTv_SdtProduct_Sellerid_Z_SetNull( )
      {
         gxTv_SdtProduct_Sellerid_Z = 0;
         SetDirty("Sellerid_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Sellerid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SellerName_Z" )]
      [  XmlElement( ElementName = "SellerName_Z"   )]
      public string gxTpr_Sellername_Z
      {
         get {
            return gxTv_SdtProduct_Sellername_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Sellername_Z = value;
            SetDirty("Sellername_Z");
         }

      }

      public void gxTv_SdtProduct_Sellername_Z_SetNull( )
      {
         gxTv_SdtProduct_Sellername_Z = "";
         SetDirty("Sellername_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Sellername_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoryId_Z" )]
      [  XmlElement( ElementName = "CategoryId_Z"   )]
      public short gxTpr_Categoryid_Z
      {
         get {
            return gxTv_SdtProduct_Categoryid_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Categoryid_Z = value;
            SetDirty("Categoryid_Z");
         }

      }

      public void gxTv_SdtProduct_Categoryid_Z_SetNull( )
      {
         gxTv_SdtProduct_Categoryid_Z = 0;
         SetDirty("Categoryid_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Categoryid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoryName_Z" )]
      [  XmlElement( ElementName = "CategoryName_Z"   )]
      public string gxTpr_Categoryname_Z
      {
         get {
            return gxTv_SdtProduct_Categoryname_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Categoryname_Z = value;
            SetDirty("Categoryname_Z");
         }

      }

      public void gxTv_SdtProduct_Categoryname_Z_SetNull( )
      {
         gxTv_SdtProduct_Categoryname_Z = "";
         SetDirty("Categoryname_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Categoryname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CountryId_Z" )]
      [  XmlElement( ElementName = "CountryId_Z"   )]
      public short gxTpr_Countryid_Z
      {
         get {
            return gxTv_SdtProduct_Countryid_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Countryid_Z = value;
            SetDirty("Countryid_Z");
         }

      }

      public void gxTv_SdtProduct_Countryid_Z_SetNull( )
      {
         gxTv_SdtProduct_Countryid_Z = 0;
         SetDirty("Countryid_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Countryid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CountryName_Z" )]
      [  XmlElement( ElementName = "CountryName_Z"   )]
      public string gxTpr_Countryname_Z
      {
         get {
            return gxTv_SdtProduct_Countryname_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Countryname_Z = value;
            SetDirty("Countryname_Z");
         }

      }

      public void gxTv_SdtProduct_Countryname_Z_SetNull( )
      {
         gxTv_SdtProduct_Countryname_Z = "";
         SetDirty("Countryname_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Countryname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductPhoto_GXI_Z" )]
      [  XmlElement( ElementName = "ProductPhoto_GXI_Z"   )]
      public string gxTpr_Productphoto_gxi_Z
      {
         get {
            return gxTv_SdtProduct_Productphoto_gxi_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productphoto_gxi_Z = value;
            SetDirty("Productphoto_gxi_Z");
         }

      }

      public void gxTv_SdtProduct_Productphoto_gxi_Z_SetNull( )
      {
         gxTv_SdtProduct_Productphoto_gxi_Z = "";
         SetDirty("Productphoto_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productphoto_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SellerPhoto_GXI_Z" )]
      [  XmlElement( ElementName = "SellerPhoto_GXI_Z"   )]
      public string gxTpr_Sellerphoto_gxi_Z
      {
         get {
            return gxTv_SdtProduct_Sellerphoto_gxi_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Sellerphoto_gxi_Z = value;
            SetDirty("Sellerphoto_gxi_Z");
         }

      }

      public void gxTv_SdtProduct_Sellerphoto_gxi_Z_SetNull( )
      {
         gxTv_SdtProduct_Sellerphoto_gxi_Z = "";
         SetDirty("Sellerphoto_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Sellerphoto_gxi_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtProduct_N = 1;
         gxTv_SdtProduct_Productname = "";
         gxTv_SdtProduct_Productdescription = "";
         gxTv_SdtProduct_Productphoto = "";
         gxTv_SdtProduct_Productphoto_gxi = "";
         gxTv_SdtProduct_Productcountryname = "";
         gxTv_SdtProduct_Sellername = "";
         gxTv_SdtProduct_Sellerphoto = "";
         gxTv_SdtProduct_Sellerphoto_gxi = "";
         gxTv_SdtProduct_Categoryname = "";
         gxTv_SdtProduct_Countryname = "";
         gxTv_SdtProduct_Mode = "";
         gxTv_SdtProduct_Productname_Z = "";
         gxTv_SdtProduct_Productdescription_Z = "";
         gxTv_SdtProduct_Productcountryname_Z = "";
         gxTv_SdtProduct_Sellername_Z = "";
         gxTv_SdtProduct_Categoryname_Z = "";
         gxTv_SdtProduct_Countryname_Z = "";
         gxTv_SdtProduct_Productphoto_gxi_Z = "";
         gxTv_SdtProduct_Sellerphoto_gxi_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "product", "GeneXus.Programs.product_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtProduct_N ;
      }

      private short gxTv_SdtProduct_Productid ;
      private short gxTv_SdtProduct_N ;
      private short gxTv_SdtProduct_Productcountryid ;
      private short gxTv_SdtProduct_Sellerid ;
      private short gxTv_SdtProduct_Categoryid ;
      private short gxTv_SdtProduct_Countryid ;
      private short gxTv_SdtProduct_Initialized ;
      private short gxTv_SdtProduct_Productid_Z ;
      private short gxTv_SdtProduct_Productcountryid_Z ;
      private short gxTv_SdtProduct_Sellerid_Z ;
      private short gxTv_SdtProduct_Categoryid_Z ;
      private short gxTv_SdtProduct_Countryid_Z ;
      private decimal gxTv_SdtProduct_Productprice ;
      private decimal gxTv_SdtProduct_Productprice_Z ;
      private string gxTv_SdtProduct_Productname ;
      private string gxTv_SdtProduct_Productdescription ;
      private string gxTv_SdtProduct_Productcountryname ;
      private string gxTv_SdtProduct_Sellername ;
      private string gxTv_SdtProduct_Categoryname ;
      private string gxTv_SdtProduct_Countryname ;
      private string gxTv_SdtProduct_Mode ;
      private string gxTv_SdtProduct_Productname_Z ;
      private string gxTv_SdtProduct_Productdescription_Z ;
      private string gxTv_SdtProduct_Productcountryname_Z ;
      private string gxTv_SdtProduct_Sellername_Z ;
      private string gxTv_SdtProduct_Categoryname_Z ;
      private string gxTv_SdtProduct_Countryname_Z ;
      private string gxTv_SdtProduct_Productphoto_gxi ;
      private string gxTv_SdtProduct_Sellerphoto_gxi ;
      private string gxTv_SdtProduct_Productphoto_gxi_Z ;
      private string gxTv_SdtProduct_Sellerphoto_gxi_Z ;
      private string gxTv_SdtProduct_Productphoto ;
      private string gxTv_SdtProduct_Sellerphoto ;
   }

   [DataContract(Name = @"Product", Namespace = "TallerJAP2022KarenRubiaca")]
   public class SdtProduct_RESTInterface : GxGenericCollectionItem<SdtProduct>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtProduct_RESTInterface( ) : base()
      {
      }

      public SdtProduct_RESTInterface( SdtProduct psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProductId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Productid
      {
         get {
            return sdt.gxTpr_Productid ;
         }

         set {
            sdt.gxTpr_Productid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ProductName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Productname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Productname) ;
         }

         set {
            sdt.gxTpr_Productname = value;
         }

      }

      [DataMember( Name = "ProductDescription" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Productdescription
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Productdescription) ;
         }

         set {
            sdt.gxTpr_Productdescription = value;
         }

      }

      [DataMember( Name = "ProductPrice" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Productprice
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Productprice, 10, 2)) ;
         }

         set {
            sdt.gxTpr_Productprice = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ProductPhoto" , Order = 4 )]
      [GxUpload()]
      public string gxTpr_Productphoto
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Productphoto)) ? PathUtil.RelativeURL( sdt.gxTpr_Productphoto) : StringUtil.RTrim( sdt.gxTpr_Productphoto_gxi)) ;
         }

         set {
            sdt.gxTpr_Productphoto = value;
         }

      }

      [DataMember( Name = "ProductCountryId" , Order = 5 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Productcountryid
      {
         get {
            return sdt.gxTpr_Productcountryid ;
         }

         set {
            sdt.gxTpr_Productcountryid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ProductCountryName" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Productcountryname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Productcountryname) ;
         }

         set {
            sdt.gxTpr_Productcountryname = value;
         }

      }

      [DataMember( Name = "SellerId" , Order = 7 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Sellerid
      {
         get {
            return sdt.gxTpr_Sellerid ;
         }

         set {
            sdt.gxTpr_Sellerid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SellerName" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Sellername
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Sellername) ;
         }

         set {
            sdt.gxTpr_Sellername = value;
         }

      }

      [DataMember( Name = "SellerPhoto" , Order = 9 )]
      [GxUpload()]
      public string gxTpr_Sellerphoto
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Sellerphoto)) ? PathUtil.RelativeURL( sdt.gxTpr_Sellerphoto) : StringUtil.RTrim( sdt.gxTpr_Sellerphoto_gxi)) ;
         }

         set {
            sdt.gxTpr_Sellerphoto = value;
         }

      }

      [DataMember( Name = "CategoryId" , Order = 10 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Categoryid
      {
         get {
            return sdt.gxTpr_Categoryid ;
         }

         set {
            sdt.gxTpr_Categoryid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CategoryName" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Categoryname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Categoryname) ;
         }

         set {
            sdt.gxTpr_Categoryname = value;
         }

      }

      [DataMember( Name = "CountryId" , Order = 12 )]
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

      [DataMember( Name = "CountryName" , Order = 13 )]
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

      public SdtProduct sdt
      {
         get {
            return (SdtProduct)Sdt ;
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
            sdt = new SdtProduct() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 14 )]
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

   [DataContract(Name = @"Product", Namespace = "TallerJAP2022KarenRubiaca")]
   public class SdtProduct_RESTLInterface : GxGenericCollectionItem<SdtProduct>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtProduct_RESTLInterface( ) : base()
      {
      }

      public SdtProduct_RESTLInterface( SdtProduct psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProductName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Productname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Productname) ;
         }

         set {
            sdt.gxTpr_Productname = value;
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

      public SdtProduct sdt
      {
         get {
            return (SdtProduct)Sdt ;
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
            sdt = new SdtProduct() ;
         }
      }

   }

}
