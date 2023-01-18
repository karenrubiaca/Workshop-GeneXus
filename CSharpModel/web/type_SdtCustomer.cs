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
   [XmlRoot(ElementName = "Customer" )]
   [XmlType(TypeName =  "Customer" , Namespace = "TallerJAP2022KarenRubiaca" )]
   [Serializable]
   public class SdtCustomer : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtCustomer( )
      {
      }

      public SdtCustomer( IGxContext context )
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

      public void Load( short AV6CustomerId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV6CustomerId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"CustomerId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Customer");
         metadata.Set("BT", "Customer");
         metadata.Set("PK", "[ \"CustomerId\" ]");
         metadata.Set("PKAssigned", "[ \"CustomerId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CountryId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Customerid_Z");
         state.Add("gxTpr_Customername_Z");
         state.Add("gxTpr_Customeraddress_Z");
         state.Add("gxTpr_Customeremail_Z");
         state.Add("gxTpr_Customerphone_Z");
         state.Add("gxTpr_Countryid_Z");
         state.Add("gxTpr_Countryname_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtCustomer sdt;
         sdt = (SdtCustomer)(source);
         gxTv_SdtCustomer_Customerid = sdt.gxTv_SdtCustomer_Customerid ;
         gxTv_SdtCustomer_Customername = sdt.gxTv_SdtCustomer_Customername ;
         gxTv_SdtCustomer_Customeraddress = sdt.gxTv_SdtCustomer_Customeraddress ;
         gxTv_SdtCustomer_Customeremail = sdt.gxTv_SdtCustomer_Customeremail ;
         gxTv_SdtCustomer_Customerphone = sdt.gxTv_SdtCustomer_Customerphone ;
         gxTv_SdtCustomer_Countryid = sdt.gxTv_SdtCustomer_Countryid ;
         gxTv_SdtCustomer_Countryname = sdt.gxTv_SdtCustomer_Countryname ;
         gxTv_SdtCustomer_Mode = sdt.gxTv_SdtCustomer_Mode ;
         gxTv_SdtCustomer_Initialized = sdt.gxTv_SdtCustomer_Initialized ;
         gxTv_SdtCustomer_Customerid_Z = sdt.gxTv_SdtCustomer_Customerid_Z ;
         gxTv_SdtCustomer_Customername_Z = sdt.gxTv_SdtCustomer_Customername_Z ;
         gxTv_SdtCustomer_Customeraddress_Z = sdt.gxTv_SdtCustomer_Customeraddress_Z ;
         gxTv_SdtCustomer_Customeremail_Z = sdt.gxTv_SdtCustomer_Customeremail_Z ;
         gxTv_SdtCustomer_Customerphone_Z = sdt.gxTv_SdtCustomer_Customerphone_Z ;
         gxTv_SdtCustomer_Countryid_Z = sdt.gxTv_SdtCustomer_Countryid_Z ;
         gxTv_SdtCustomer_Countryname_Z = sdt.gxTv_SdtCustomer_Countryname_Z ;
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
         AddObjectProperty("CustomerId", gxTv_SdtCustomer_Customerid, false, includeNonInitialized);
         AddObjectProperty("CustomerName", gxTv_SdtCustomer_Customername, false, includeNonInitialized);
         AddObjectProperty("CustomerAddress", gxTv_SdtCustomer_Customeraddress, false, includeNonInitialized);
         AddObjectProperty("CustomerEmail", gxTv_SdtCustomer_Customeremail, false, includeNonInitialized);
         AddObjectProperty("CustomerPhone", gxTv_SdtCustomer_Customerphone, false, includeNonInitialized);
         AddObjectProperty("CountryId", gxTv_SdtCustomer_Countryid, false, includeNonInitialized);
         AddObjectProperty("CountryName", gxTv_SdtCustomer_Countryname, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtCustomer_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtCustomer_Initialized, false, includeNonInitialized);
            AddObjectProperty("CustomerId_Z", gxTv_SdtCustomer_Customerid_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerName_Z", gxTv_SdtCustomer_Customername_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerAddress_Z", gxTv_SdtCustomer_Customeraddress_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerEmail_Z", gxTv_SdtCustomer_Customeremail_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerPhone_Z", gxTv_SdtCustomer_Customerphone_Z, false, includeNonInitialized);
            AddObjectProperty("CountryId_Z", gxTv_SdtCustomer_Countryid_Z, false, includeNonInitialized);
            AddObjectProperty("CountryName_Z", gxTv_SdtCustomer_Countryname_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtCustomer sdt )
      {
         if ( sdt.IsDirty("CustomerId") )
         {
            gxTv_SdtCustomer_N = 0;
            gxTv_SdtCustomer_Customerid = sdt.gxTv_SdtCustomer_Customerid ;
         }
         if ( sdt.IsDirty("CustomerName") )
         {
            gxTv_SdtCustomer_N = 0;
            gxTv_SdtCustomer_Customername = sdt.gxTv_SdtCustomer_Customername ;
         }
         if ( sdt.IsDirty("CustomerAddress") )
         {
            gxTv_SdtCustomer_N = 0;
            gxTv_SdtCustomer_Customeraddress = sdt.gxTv_SdtCustomer_Customeraddress ;
         }
         if ( sdt.IsDirty("CustomerEmail") )
         {
            gxTv_SdtCustomer_N = 0;
            gxTv_SdtCustomer_Customeremail = sdt.gxTv_SdtCustomer_Customeremail ;
         }
         if ( sdt.IsDirty("CustomerPhone") )
         {
            gxTv_SdtCustomer_N = 0;
            gxTv_SdtCustomer_Customerphone = sdt.gxTv_SdtCustomer_Customerphone ;
         }
         if ( sdt.IsDirty("CountryId") )
         {
            gxTv_SdtCustomer_N = 0;
            gxTv_SdtCustomer_Countryid = sdt.gxTv_SdtCustomer_Countryid ;
         }
         if ( sdt.IsDirty("CountryName") )
         {
            gxTv_SdtCustomer_N = 0;
            gxTv_SdtCustomer_Countryname = sdt.gxTv_SdtCustomer_Countryname ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "CustomerId" )]
      [  XmlElement( ElementName = "CustomerId"   )]
      public short gxTpr_Customerid
      {
         get {
            return gxTv_SdtCustomer_Customerid ;
         }

         set {
            gxTv_SdtCustomer_N = 0;
            if ( gxTv_SdtCustomer_Customerid != value )
            {
               gxTv_SdtCustomer_Mode = "INS";
               this.gxTv_SdtCustomer_Customerid_Z_SetNull( );
               this.gxTv_SdtCustomer_Customername_Z_SetNull( );
               this.gxTv_SdtCustomer_Customeraddress_Z_SetNull( );
               this.gxTv_SdtCustomer_Customeremail_Z_SetNull( );
               this.gxTv_SdtCustomer_Customerphone_Z_SetNull( );
               this.gxTv_SdtCustomer_Countryid_Z_SetNull( );
               this.gxTv_SdtCustomer_Countryname_Z_SetNull( );
            }
            gxTv_SdtCustomer_Customerid = value;
            SetDirty("Customerid");
         }

      }

      [  SoapElement( ElementName = "CustomerName" )]
      [  XmlElement( ElementName = "CustomerName"   )]
      public string gxTpr_Customername
      {
         get {
            return gxTv_SdtCustomer_Customername ;
         }

         set {
            gxTv_SdtCustomer_N = 0;
            gxTv_SdtCustomer_Customername = value;
            SetDirty("Customername");
         }

      }

      [  SoapElement( ElementName = "CustomerAddress" )]
      [  XmlElement( ElementName = "CustomerAddress"   )]
      public string gxTpr_Customeraddress
      {
         get {
            return gxTv_SdtCustomer_Customeraddress ;
         }

         set {
            gxTv_SdtCustomer_N = 0;
            gxTv_SdtCustomer_Customeraddress = value;
            SetDirty("Customeraddress");
         }

      }

      [  SoapElement( ElementName = "CustomerEmail" )]
      [  XmlElement( ElementName = "CustomerEmail"   )]
      public string gxTpr_Customeremail
      {
         get {
            return gxTv_SdtCustomer_Customeremail ;
         }

         set {
            gxTv_SdtCustomer_N = 0;
            gxTv_SdtCustomer_Customeremail = value;
            SetDirty("Customeremail");
         }

      }

      [  SoapElement( ElementName = "CustomerPhone" )]
      [  XmlElement( ElementName = "CustomerPhone"   )]
      public string gxTpr_Customerphone
      {
         get {
            return gxTv_SdtCustomer_Customerphone ;
         }

         set {
            gxTv_SdtCustomer_N = 0;
            gxTv_SdtCustomer_Customerphone = value;
            SetDirty("Customerphone");
         }

      }

      [  SoapElement( ElementName = "CountryId" )]
      [  XmlElement( ElementName = "CountryId"   )]
      public short gxTpr_Countryid
      {
         get {
            return gxTv_SdtCustomer_Countryid ;
         }

         set {
            gxTv_SdtCustomer_N = 0;
            gxTv_SdtCustomer_Countryid = value;
            SetDirty("Countryid");
         }

      }

      [  SoapElement( ElementName = "CountryName" )]
      [  XmlElement( ElementName = "CountryName"   )]
      public string gxTpr_Countryname
      {
         get {
            return gxTv_SdtCustomer_Countryname ;
         }

         set {
            gxTv_SdtCustomer_N = 0;
            gxTv_SdtCustomer_Countryname = value;
            SetDirty("Countryname");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtCustomer_Mode ;
         }

         set {
            gxTv_SdtCustomer_N = 0;
            gxTv_SdtCustomer_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtCustomer_Mode_SetNull( )
      {
         gxTv_SdtCustomer_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtCustomer_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtCustomer_Initialized ;
         }

         set {
            gxTv_SdtCustomer_N = 0;
            gxTv_SdtCustomer_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtCustomer_Initialized_SetNull( )
      {
         gxTv_SdtCustomer_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtCustomer_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerId_Z" )]
      [  XmlElement( ElementName = "CustomerId_Z"   )]
      public short gxTpr_Customerid_Z
      {
         get {
            return gxTv_SdtCustomer_Customerid_Z ;
         }

         set {
            gxTv_SdtCustomer_N = 0;
            gxTv_SdtCustomer_Customerid_Z = value;
            SetDirty("Customerid_Z");
         }

      }

      public void gxTv_SdtCustomer_Customerid_Z_SetNull( )
      {
         gxTv_SdtCustomer_Customerid_Z = 0;
         SetDirty("Customerid_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Customerid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerName_Z" )]
      [  XmlElement( ElementName = "CustomerName_Z"   )]
      public string gxTpr_Customername_Z
      {
         get {
            return gxTv_SdtCustomer_Customername_Z ;
         }

         set {
            gxTv_SdtCustomer_N = 0;
            gxTv_SdtCustomer_Customername_Z = value;
            SetDirty("Customername_Z");
         }

      }

      public void gxTv_SdtCustomer_Customername_Z_SetNull( )
      {
         gxTv_SdtCustomer_Customername_Z = "";
         SetDirty("Customername_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Customername_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerAddress_Z" )]
      [  XmlElement( ElementName = "CustomerAddress_Z"   )]
      public string gxTpr_Customeraddress_Z
      {
         get {
            return gxTv_SdtCustomer_Customeraddress_Z ;
         }

         set {
            gxTv_SdtCustomer_N = 0;
            gxTv_SdtCustomer_Customeraddress_Z = value;
            SetDirty("Customeraddress_Z");
         }

      }

      public void gxTv_SdtCustomer_Customeraddress_Z_SetNull( )
      {
         gxTv_SdtCustomer_Customeraddress_Z = "";
         SetDirty("Customeraddress_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Customeraddress_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerEmail_Z" )]
      [  XmlElement( ElementName = "CustomerEmail_Z"   )]
      public string gxTpr_Customeremail_Z
      {
         get {
            return gxTv_SdtCustomer_Customeremail_Z ;
         }

         set {
            gxTv_SdtCustomer_N = 0;
            gxTv_SdtCustomer_Customeremail_Z = value;
            SetDirty("Customeremail_Z");
         }

      }

      public void gxTv_SdtCustomer_Customeremail_Z_SetNull( )
      {
         gxTv_SdtCustomer_Customeremail_Z = "";
         SetDirty("Customeremail_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Customeremail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerPhone_Z" )]
      [  XmlElement( ElementName = "CustomerPhone_Z"   )]
      public string gxTpr_Customerphone_Z
      {
         get {
            return gxTv_SdtCustomer_Customerphone_Z ;
         }

         set {
            gxTv_SdtCustomer_N = 0;
            gxTv_SdtCustomer_Customerphone_Z = value;
            SetDirty("Customerphone_Z");
         }

      }

      public void gxTv_SdtCustomer_Customerphone_Z_SetNull( )
      {
         gxTv_SdtCustomer_Customerphone_Z = "";
         SetDirty("Customerphone_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Customerphone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CountryId_Z" )]
      [  XmlElement( ElementName = "CountryId_Z"   )]
      public short gxTpr_Countryid_Z
      {
         get {
            return gxTv_SdtCustomer_Countryid_Z ;
         }

         set {
            gxTv_SdtCustomer_N = 0;
            gxTv_SdtCustomer_Countryid_Z = value;
            SetDirty("Countryid_Z");
         }

      }

      public void gxTv_SdtCustomer_Countryid_Z_SetNull( )
      {
         gxTv_SdtCustomer_Countryid_Z = 0;
         SetDirty("Countryid_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Countryid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CountryName_Z" )]
      [  XmlElement( ElementName = "CountryName_Z"   )]
      public string gxTpr_Countryname_Z
      {
         get {
            return gxTv_SdtCustomer_Countryname_Z ;
         }

         set {
            gxTv_SdtCustomer_N = 0;
            gxTv_SdtCustomer_Countryname_Z = value;
            SetDirty("Countryname_Z");
         }

      }

      public void gxTv_SdtCustomer_Countryname_Z_SetNull( )
      {
         gxTv_SdtCustomer_Countryname_Z = "";
         SetDirty("Countryname_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Countryname_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtCustomer_N = 1;
         gxTv_SdtCustomer_Customername = "";
         gxTv_SdtCustomer_Customeraddress = "";
         gxTv_SdtCustomer_Customeremail = "";
         gxTv_SdtCustomer_Customerphone = "";
         gxTv_SdtCustomer_Countryname = "";
         gxTv_SdtCustomer_Mode = "";
         gxTv_SdtCustomer_Customername_Z = "";
         gxTv_SdtCustomer_Customeraddress_Z = "";
         gxTv_SdtCustomer_Customeremail_Z = "";
         gxTv_SdtCustomer_Customerphone_Z = "";
         gxTv_SdtCustomer_Countryname_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "customer", "GeneXus.Programs.customer_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtCustomer_N ;
      }

      private short gxTv_SdtCustomer_Customerid ;
      private short gxTv_SdtCustomer_N ;
      private short gxTv_SdtCustomer_Countryid ;
      private short gxTv_SdtCustomer_Initialized ;
      private short gxTv_SdtCustomer_Customerid_Z ;
      private short gxTv_SdtCustomer_Countryid_Z ;
      private string gxTv_SdtCustomer_Customername ;
      private string gxTv_SdtCustomer_Customerphone ;
      private string gxTv_SdtCustomer_Countryname ;
      private string gxTv_SdtCustomer_Mode ;
      private string gxTv_SdtCustomer_Customername_Z ;
      private string gxTv_SdtCustomer_Customerphone_Z ;
      private string gxTv_SdtCustomer_Countryname_Z ;
      private string gxTv_SdtCustomer_Customeraddress ;
      private string gxTv_SdtCustomer_Customeremail ;
      private string gxTv_SdtCustomer_Customeraddress_Z ;
      private string gxTv_SdtCustomer_Customeremail_Z ;
   }

   [DataContract(Name = @"Customer", Namespace = "TallerJAP2022KarenRubiaca")]
   public class SdtCustomer_RESTInterface : GxGenericCollectionItem<SdtCustomer>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtCustomer_RESTInterface( ) : base()
      {
      }

      public SdtCustomer_RESTInterface( SdtCustomer psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CustomerId" , Order = 0 )]
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

      [DataMember( Name = "CustomerName" , Order = 1 )]
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

      [DataMember( Name = "CustomerAddress" , Order = 2 )]
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

      [DataMember( Name = "CustomerEmail" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Customeremail
      {
         get {
            return sdt.gxTpr_Customeremail ;
         }

         set {
            sdt.gxTpr_Customeremail = value;
         }

      }

      [DataMember( Name = "CustomerPhone" , Order = 4 )]
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

      public SdtCustomer sdt
      {
         get {
            return (SdtCustomer)Sdt ;
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
            sdt = new SdtCustomer() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 7 )]
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

   [DataContract(Name = @"Customer", Namespace = "TallerJAP2022KarenRubiaca")]
   public class SdtCustomer_RESTLInterface : GxGenericCollectionItem<SdtCustomer>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtCustomer_RESTLInterface( ) : base()
      {
      }

      public SdtCustomer_RESTLInterface( SdtCustomer psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CustomerName" , Order = 0 )]
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

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtCustomer sdt
      {
         get {
            return (SdtCustomer)Sdt ;
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
            sdt = new SdtCustomer() ;
         }
      }

   }

}
