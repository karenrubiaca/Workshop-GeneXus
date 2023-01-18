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
   [XmlRoot(ElementName = "Seller" )]
   [XmlType(TypeName =  "Seller" , Namespace = "TallerJAP2022KarenRubiaca" )]
   [Serializable]
   public class SdtSeller : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtSeller( )
      {
      }

      public SdtSeller( IGxContext context )
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

      public void Load( short AV5SellerId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV5SellerId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SellerId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Seller");
         metadata.Set("BT", "Seller");
         metadata.Set("PK", "[ \"SellerId\" ]");
         metadata.Set("PKAssigned", "[ \"SellerId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CountryId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Sellerphoto_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Sellerid_Z");
         state.Add("gxTpr_Sellername_Z");
         state.Add("gxTpr_Countryid_Z");
         state.Add("gxTpr_Countryname_Z");
         state.Add("gxTpr_Sellerphoto_gxi_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtSeller sdt;
         sdt = (SdtSeller)(source);
         gxTv_SdtSeller_Sellerid = sdt.gxTv_SdtSeller_Sellerid ;
         gxTv_SdtSeller_Sellername = sdt.gxTv_SdtSeller_Sellername ;
         gxTv_SdtSeller_Sellerphoto = sdt.gxTv_SdtSeller_Sellerphoto ;
         gxTv_SdtSeller_Sellerphoto_gxi = sdt.gxTv_SdtSeller_Sellerphoto_gxi ;
         gxTv_SdtSeller_Countryid = sdt.gxTv_SdtSeller_Countryid ;
         gxTv_SdtSeller_Countryname = sdt.gxTv_SdtSeller_Countryname ;
         gxTv_SdtSeller_Mode = sdt.gxTv_SdtSeller_Mode ;
         gxTv_SdtSeller_Initialized = sdt.gxTv_SdtSeller_Initialized ;
         gxTv_SdtSeller_Sellerid_Z = sdt.gxTv_SdtSeller_Sellerid_Z ;
         gxTv_SdtSeller_Sellername_Z = sdt.gxTv_SdtSeller_Sellername_Z ;
         gxTv_SdtSeller_Countryid_Z = sdt.gxTv_SdtSeller_Countryid_Z ;
         gxTv_SdtSeller_Countryname_Z = sdt.gxTv_SdtSeller_Countryname_Z ;
         gxTv_SdtSeller_Sellerphoto_gxi_Z = sdt.gxTv_SdtSeller_Sellerphoto_gxi_Z ;
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
         AddObjectProperty("SellerId", gxTv_SdtSeller_Sellerid, false, includeNonInitialized);
         AddObjectProperty("SellerName", gxTv_SdtSeller_Sellername, false, includeNonInitialized);
         AddObjectProperty("SellerPhoto", gxTv_SdtSeller_Sellerphoto, false, includeNonInitialized);
         AddObjectProperty("CountryId", gxTv_SdtSeller_Countryid, false, includeNonInitialized);
         AddObjectProperty("CountryName", gxTv_SdtSeller_Countryname, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("SellerPhoto_GXI", gxTv_SdtSeller_Sellerphoto_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtSeller_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtSeller_Initialized, false, includeNonInitialized);
            AddObjectProperty("SellerId_Z", gxTv_SdtSeller_Sellerid_Z, false, includeNonInitialized);
            AddObjectProperty("SellerName_Z", gxTv_SdtSeller_Sellername_Z, false, includeNonInitialized);
            AddObjectProperty("CountryId_Z", gxTv_SdtSeller_Countryid_Z, false, includeNonInitialized);
            AddObjectProperty("CountryName_Z", gxTv_SdtSeller_Countryname_Z, false, includeNonInitialized);
            AddObjectProperty("SellerPhoto_GXI_Z", gxTv_SdtSeller_Sellerphoto_gxi_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtSeller sdt )
      {
         if ( sdt.IsDirty("SellerId") )
         {
            gxTv_SdtSeller_N = 0;
            gxTv_SdtSeller_Sellerid = sdt.gxTv_SdtSeller_Sellerid ;
         }
         if ( sdt.IsDirty("SellerName") )
         {
            gxTv_SdtSeller_N = 0;
            gxTv_SdtSeller_Sellername = sdt.gxTv_SdtSeller_Sellername ;
         }
         if ( sdt.IsDirty("SellerPhoto") )
         {
            gxTv_SdtSeller_N = 0;
            gxTv_SdtSeller_Sellerphoto = sdt.gxTv_SdtSeller_Sellerphoto ;
         }
         if ( sdt.IsDirty("SellerPhoto") )
         {
            gxTv_SdtSeller_N = 0;
            gxTv_SdtSeller_Sellerphoto_gxi = sdt.gxTv_SdtSeller_Sellerphoto_gxi ;
         }
         if ( sdt.IsDirty("CountryId") )
         {
            gxTv_SdtSeller_N = 0;
            gxTv_SdtSeller_Countryid = sdt.gxTv_SdtSeller_Countryid ;
         }
         if ( sdt.IsDirty("CountryName") )
         {
            gxTv_SdtSeller_N = 0;
            gxTv_SdtSeller_Countryname = sdt.gxTv_SdtSeller_Countryname ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SellerId" )]
      [  XmlElement( ElementName = "SellerId"   )]
      public short gxTpr_Sellerid
      {
         get {
            return gxTv_SdtSeller_Sellerid ;
         }

         set {
            gxTv_SdtSeller_N = 0;
            if ( gxTv_SdtSeller_Sellerid != value )
            {
               gxTv_SdtSeller_Mode = "INS";
               this.gxTv_SdtSeller_Sellerid_Z_SetNull( );
               this.gxTv_SdtSeller_Sellername_Z_SetNull( );
               this.gxTv_SdtSeller_Countryid_Z_SetNull( );
               this.gxTv_SdtSeller_Countryname_Z_SetNull( );
               this.gxTv_SdtSeller_Sellerphoto_gxi_Z_SetNull( );
            }
            gxTv_SdtSeller_Sellerid = value;
            SetDirty("Sellerid");
         }

      }

      [  SoapElement( ElementName = "SellerName" )]
      [  XmlElement( ElementName = "SellerName"   )]
      public string gxTpr_Sellername
      {
         get {
            return gxTv_SdtSeller_Sellername ;
         }

         set {
            gxTv_SdtSeller_N = 0;
            gxTv_SdtSeller_Sellername = value;
            SetDirty("Sellername");
         }

      }

      [  SoapElement( ElementName = "SellerPhoto" )]
      [  XmlElement( ElementName = "SellerPhoto"   )]
      [GxUpload()]
      public string gxTpr_Sellerphoto
      {
         get {
            return gxTv_SdtSeller_Sellerphoto ;
         }

         set {
            gxTv_SdtSeller_N = 0;
            gxTv_SdtSeller_Sellerphoto = value;
            SetDirty("Sellerphoto");
         }

      }

      [  SoapElement( ElementName = "SellerPhoto_GXI" )]
      [  XmlElement( ElementName = "SellerPhoto_GXI"   )]
      public string gxTpr_Sellerphoto_gxi
      {
         get {
            return gxTv_SdtSeller_Sellerphoto_gxi ;
         }

         set {
            gxTv_SdtSeller_N = 0;
            gxTv_SdtSeller_Sellerphoto_gxi = value;
            SetDirty("Sellerphoto_gxi");
         }

      }

      [  SoapElement( ElementName = "CountryId" )]
      [  XmlElement( ElementName = "CountryId"   )]
      public short gxTpr_Countryid
      {
         get {
            return gxTv_SdtSeller_Countryid ;
         }

         set {
            gxTv_SdtSeller_N = 0;
            gxTv_SdtSeller_Countryid = value;
            SetDirty("Countryid");
         }

      }

      [  SoapElement( ElementName = "CountryName" )]
      [  XmlElement( ElementName = "CountryName"   )]
      public string gxTpr_Countryname
      {
         get {
            return gxTv_SdtSeller_Countryname ;
         }

         set {
            gxTv_SdtSeller_N = 0;
            gxTv_SdtSeller_Countryname = value;
            SetDirty("Countryname");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtSeller_Mode ;
         }

         set {
            gxTv_SdtSeller_N = 0;
            gxTv_SdtSeller_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtSeller_Mode_SetNull( )
      {
         gxTv_SdtSeller_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtSeller_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtSeller_Initialized ;
         }

         set {
            gxTv_SdtSeller_N = 0;
            gxTv_SdtSeller_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtSeller_Initialized_SetNull( )
      {
         gxTv_SdtSeller_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtSeller_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SellerId_Z" )]
      [  XmlElement( ElementName = "SellerId_Z"   )]
      public short gxTpr_Sellerid_Z
      {
         get {
            return gxTv_SdtSeller_Sellerid_Z ;
         }

         set {
            gxTv_SdtSeller_N = 0;
            gxTv_SdtSeller_Sellerid_Z = value;
            SetDirty("Sellerid_Z");
         }

      }

      public void gxTv_SdtSeller_Sellerid_Z_SetNull( )
      {
         gxTv_SdtSeller_Sellerid_Z = 0;
         SetDirty("Sellerid_Z");
         return  ;
      }

      public bool gxTv_SdtSeller_Sellerid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SellerName_Z" )]
      [  XmlElement( ElementName = "SellerName_Z"   )]
      public string gxTpr_Sellername_Z
      {
         get {
            return gxTv_SdtSeller_Sellername_Z ;
         }

         set {
            gxTv_SdtSeller_N = 0;
            gxTv_SdtSeller_Sellername_Z = value;
            SetDirty("Sellername_Z");
         }

      }

      public void gxTv_SdtSeller_Sellername_Z_SetNull( )
      {
         gxTv_SdtSeller_Sellername_Z = "";
         SetDirty("Sellername_Z");
         return  ;
      }

      public bool gxTv_SdtSeller_Sellername_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CountryId_Z" )]
      [  XmlElement( ElementName = "CountryId_Z"   )]
      public short gxTpr_Countryid_Z
      {
         get {
            return gxTv_SdtSeller_Countryid_Z ;
         }

         set {
            gxTv_SdtSeller_N = 0;
            gxTv_SdtSeller_Countryid_Z = value;
            SetDirty("Countryid_Z");
         }

      }

      public void gxTv_SdtSeller_Countryid_Z_SetNull( )
      {
         gxTv_SdtSeller_Countryid_Z = 0;
         SetDirty("Countryid_Z");
         return  ;
      }

      public bool gxTv_SdtSeller_Countryid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CountryName_Z" )]
      [  XmlElement( ElementName = "CountryName_Z"   )]
      public string gxTpr_Countryname_Z
      {
         get {
            return gxTv_SdtSeller_Countryname_Z ;
         }

         set {
            gxTv_SdtSeller_N = 0;
            gxTv_SdtSeller_Countryname_Z = value;
            SetDirty("Countryname_Z");
         }

      }

      public void gxTv_SdtSeller_Countryname_Z_SetNull( )
      {
         gxTv_SdtSeller_Countryname_Z = "";
         SetDirty("Countryname_Z");
         return  ;
      }

      public bool gxTv_SdtSeller_Countryname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SellerPhoto_GXI_Z" )]
      [  XmlElement( ElementName = "SellerPhoto_GXI_Z"   )]
      public string gxTpr_Sellerphoto_gxi_Z
      {
         get {
            return gxTv_SdtSeller_Sellerphoto_gxi_Z ;
         }

         set {
            gxTv_SdtSeller_N = 0;
            gxTv_SdtSeller_Sellerphoto_gxi_Z = value;
            SetDirty("Sellerphoto_gxi_Z");
         }

      }

      public void gxTv_SdtSeller_Sellerphoto_gxi_Z_SetNull( )
      {
         gxTv_SdtSeller_Sellerphoto_gxi_Z = "";
         SetDirty("Sellerphoto_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtSeller_Sellerphoto_gxi_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtSeller_N = 1;
         gxTv_SdtSeller_Sellername = "";
         gxTv_SdtSeller_Sellerphoto = "";
         gxTv_SdtSeller_Sellerphoto_gxi = "";
         gxTv_SdtSeller_Countryname = "";
         gxTv_SdtSeller_Mode = "";
         gxTv_SdtSeller_Sellername_Z = "";
         gxTv_SdtSeller_Countryname_Z = "";
         gxTv_SdtSeller_Sellerphoto_gxi_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "seller", "GeneXus.Programs.seller_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtSeller_N ;
      }

      private short gxTv_SdtSeller_Sellerid ;
      private short gxTv_SdtSeller_N ;
      private short gxTv_SdtSeller_Countryid ;
      private short gxTv_SdtSeller_Initialized ;
      private short gxTv_SdtSeller_Sellerid_Z ;
      private short gxTv_SdtSeller_Countryid_Z ;
      private string gxTv_SdtSeller_Sellername ;
      private string gxTv_SdtSeller_Countryname ;
      private string gxTv_SdtSeller_Mode ;
      private string gxTv_SdtSeller_Sellername_Z ;
      private string gxTv_SdtSeller_Countryname_Z ;
      private string gxTv_SdtSeller_Sellerphoto_gxi ;
      private string gxTv_SdtSeller_Sellerphoto_gxi_Z ;
      private string gxTv_SdtSeller_Sellerphoto ;
   }

   [DataContract(Name = @"Seller", Namespace = "TallerJAP2022KarenRubiaca")]
   public class SdtSeller_RESTInterface : GxGenericCollectionItem<SdtSeller>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtSeller_RESTInterface( ) : base()
      {
      }

      public SdtSeller_RESTInterface( SdtSeller psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SellerId" , Order = 0 )]
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

      [DataMember( Name = "SellerName" , Order = 1 )]
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

      [DataMember( Name = "SellerPhoto" , Order = 2 )]
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

      [DataMember( Name = "CountryId" , Order = 3 )]
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

      [DataMember( Name = "CountryName" , Order = 4 )]
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

      public SdtSeller sdt
      {
         get {
            return (SdtSeller)Sdt ;
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
            sdt = new SdtSeller() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 5 )]
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

   [DataContract(Name = @"Seller", Namespace = "TallerJAP2022KarenRubiaca")]
   public class SdtSeller_RESTLInterface : GxGenericCollectionItem<SdtSeller>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtSeller_RESTLInterface( ) : base()
      {
      }

      public SdtSeller_RESTLInterface( SdtSeller psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SellerName" , Order = 0 )]
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

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtSeller sdt
      {
         get {
            return (SdtSeller)Sdt ;
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
            sdt = new SdtSeller() ;
         }
      }

   }

}
