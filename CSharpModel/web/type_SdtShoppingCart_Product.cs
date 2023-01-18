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
   [XmlRoot(ElementName = "ShoppingCart.Product" )]
   [XmlType(TypeName =  "ShoppingCart.Product" , Namespace = "TallerJAP2022KarenRubiaca" )]
   [Serializable]
   public class SdtShoppingCart_Product : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtShoppingCart_Product( )
      {
      }

      public SdtShoppingCart_Product( IGxContext context )
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

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ProductId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Product");
         metadata.Set("BT", "ShoppingCartProduct");
         metadata.Set("PK", "[ \"ProductId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ProductId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ShoppingCartId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Productid_Z");
         state.Add("gxTpr_Productname_Z");
         state.Add("gxTpr_Productprice_Z");
         state.Add("gxTpr_Qtyproduct_Z");
         state.Add("gxTpr_Totalproduct_Z");
         state.Add("gxTpr_Categoryid_Z");
         state.Add("gxTpr_Categoryname_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtShoppingCart_Product sdt;
         sdt = (SdtShoppingCart_Product)(source);
         gxTv_SdtShoppingCart_Product_Productid = sdt.gxTv_SdtShoppingCart_Product_Productid ;
         gxTv_SdtShoppingCart_Product_Productname = sdt.gxTv_SdtShoppingCart_Product_Productname ;
         gxTv_SdtShoppingCart_Product_Productprice = sdt.gxTv_SdtShoppingCart_Product_Productprice ;
         gxTv_SdtShoppingCart_Product_Qtyproduct = sdt.gxTv_SdtShoppingCart_Product_Qtyproduct ;
         gxTv_SdtShoppingCart_Product_Totalproduct = sdt.gxTv_SdtShoppingCart_Product_Totalproduct ;
         gxTv_SdtShoppingCart_Product_Categoryid = sdt.gxTv_SdtShoppingCart_Product_Categoryid ;
         gxTv_SdtShoppingCart_Product_Categoryname = sdt.gxTv_SdtShoppingCart_Product_Categoryname ;
         gxTv_SdtShoppingCart_Product_Mode = sdt.gxTv_SdtShoppingCart_Product_Mode ;
         gxTv_SdtShoppingCart_Product_Modified = sdt.gxTv_SdtShoppingCart_Product_Modified ;
         gxTv_SdtShoppingCart_Product_Initialized = sdt.gxTv_SdtShoppingCart_Product_Initialized ;
         gxTv_SdtShoppingCart_Product_Productid_Z = sdt.gxTv_SdtShoppingCart_Product_Productid_Z ;
         gxTv_SdtShoppingCart_Product_Productname_Z = sdt.gxTv_SdtShoppingCart_Product_Productname_Z ;
         gxTv_SdtShoppingCart_Product_Productprice_Z = sdt.gxTv_SdtShoppingCart_Product_Productprice_Z ;
         gxTv_SdtShoppingCart_Product_Qtyproduct_Z = sdt.gxTv_SdtShoppingCart_Product_Qtyproduct_Z ;
         gxTv_SdtShoppingCart_Product_Totalproduct_Z = sdt.gxTv_SdtShoppingCart_Product_Totalproduct_Z ;
         gxTv_SdtShoppingCart_Product_Categoryid_Z = sdt.gxTv_SdtShoppingCart_Product_Categoryid_Z ;
         gxTv_SdtShoppingCart_Product_Categoryname_Z = sdt.gxTv_SdtShoppingCart_Product_Categoryname_Z ;
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
         AddObjectProperty("ProductId", gxTv_SdtShoppingCart_Product_Productid, false, includeNonInitialized);
         AddObjectProperty("ProductName", gxTv_SdtShoppingCart_Product_Productname, false, includeNonInitialized);
         AddObjectProperty("ProductPrice", gxTv_SdtShoppingCart_Product_Productprice, false, includeNonInitialized);
         AddObjectProperty("QtyProduct", gxTv_SdtShoppingCart_Product_Qtyproduct, false, includeNonInitialized);
         AddObjectProperty("TotalProduct", gxTv_SdtShoppingCart_Product_Totalproduct, false, includeNonInitialized);
         AddObjectProperty("CategoryId", gxTv_SdtShoppingCart_Product_Categoryid, false, includeNonInitialized);
         AddObjectProperty("CategoryName", gxTv_SdtShoppingCart_Product_Categoryname, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtShoppingCart_Product_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtShoppingCart_Product_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtShoppingCart_Product_Initialized, false, includeNonInitialized);
            AddObjectProperty("ProductId_Z", gxTv_SdtShoppingCart_Product_Productid_Z, false, includeNonInitialized);
            AddObjectProperty("ProductName_Z", gxTv_SdtShoppingCart_Product_Productname_Z, false, includeNonInitialized);
            AddObjectProperty("ProductPrice_Z", gxTv_SdtShoppingCart_Product_Productprice_Z, false, includeNonInitialized);
            AddObjectProperty("QtyProduct_Z", gxTv_SdtShoppingCart_Product_Qtyproduct_Z, false, includeNonInitialized);
            AddObjectProperty("TotalProduct_Z", gxTv_SdtShoppingCart_Product_Totalproduct_Z, false, includeNonInitialized);
            AddObjectProperty("CategoryId_Z", gxTv_SdtShoppingCart_Product_Categoryid_Z, false, includeNonInitialized);
            AddObjectProperty("CategoryName_Z", gxTv_SdtShoppingCart_Product_Categoryname_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtShoppingCart_Product sdt )
      {
         if ( sdt.IsDirty("ProductId") )
         {
            gxTv_SdtShoppingCart_Product_N = 0;
            gxTv_SdtShoppingCart_Product_Productid = sdt.gxTv_SdtShoppingCart_Product_Productid ;
         }
         if ( sdt.IsDirty("ProductName") )
         {
            gxTv_SdtShoppingCart_Product_N = 0;
            gxTv_SdtShoppingCart_Product_Productname = sdt.gxTv_SdtShoppingCart_Product_Productname ;
         }
         if ( sdt.IsDirty("ProductPrice") )
         {
            gxTv_SdtShoppingCart_Product_N = 0;
            gxTv_SdtShoppingCart_Product_Productprice = sdt.gxTv_SdtShoppingCart_Product_Productprice ;
         }
         if ( sdt.IsDirty("QtyProduct") )
         {
            gxTv_SdtShoppingCart_Product_N = 0;
            gxTv_SdtShoppingCart_Product_Qtyproduct = sdt.gxTv_SdtShoppingCart_Product_Qtyproduct ;
         }
         if ( sdt.IsDirty("TotalProduct") )
         {
            gxTv_SdtShoppingCart_Product_N = 0;
            gxTv_SdtShoppingCart_Product_Totalproduct = sdt.gxTv_SdtShoppingCart_Product_Totalproduct ;
         }
         if ( sdt.IsDirty("CategoryId") )
         {
            gxTv_SdtShoppingCart_Product_N = 0;
            gxTv_SdtShoppingCart_Product_Categoryid = sdt.gxTv_SdtShoppingCart_Product_Categoryid ;
         }
         if ( sdt.IsDirty("CategoryName") )
         {
            gxTv_SdtShoppingCart_Product_N = 0;
            gxTv_SdtShoppingCart_Product_Categoryname = sdt.gxTv_SdtShoppingCart_Product_Categoryname ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ProductId" )]
      [  XmlElement( ElementName = "ProductId"   )]
      public short gxTpr_Productid
      {
         get {
            return gxTv_SdtShoppingCart_Product_Productid ;
         }

         set {
            gxTv_SdtShoppingCart_Product_N = 0;
            gxTv_SdtShoppingCart_Product_Productid = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Productid");
         }

      }

      [  SoapElement( ElementName = "ProductName" )]
      [  XmlElement( ElementName = "ProductName"   )]
      public string gxTpr_Productname
      {
         get {
            return gxTv_SdtShoppingCart_Product_Productname ;
         }

         set {
            gxTv_SdtShoppingCart_Product_N = 0;
            gxTv_SdtShoppingCart_Product_Productname = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Productname");
         }

      }

      [  SoapElement( ElementName = "ProductPrice" )]
      [  XmlElement( ElementName = "ProductPrice"   )]
      public decimal gxTpr_Productprice
      {
         get {
            return gxTv_SdtShoppingCart_Product_Productprice ;
         }

         set {
            gxTv_SdtShoppingCart_Product_N = 0;
            gxTv_SdtShoppingCart_Product_Productprice = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Productprice");
         }

      }

      [  SoapElement( ElementName = "QtyProduct" )]
      [  XmlElement( ElementName = "QtyProduct"   )]
      public short gxTpr_Qtyproduct
      {
         get {
            return gxTv_SdtShoppingCart_Product_Qtyproduct ;
         }

         set {
            gxTv_SdtShoppingCart_Product_N = 0;
            gxTv_SdtShoppingCart_Product_Qtyproduct = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Qtyproduct");
         }

      }

      [  SoapElement( ElementName = "TotalProduct" )]
      [  XmlElement( ElementName = "TotalProduct"   )]
      public decimal gxTpr_Totalproduct
      {
         get {
            return gxTv_SdtShoppingCart_Product_Totalproduct ;
         }

         set {
            gxTv_SdtShoppingCart_Product_N = 0;
            gxTv_SdtShoppingCart_Product_Totalproduct = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Totalproduct");
         }

      }

      public void gxTv_SdtShoppingCart_Product_Totalproduct_SetNull( )
      {
         gxTv_SdtShoppingCart_Product_Totalproduct = 0;
         SetDirty("Totalproduct");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Product_Totalproduct_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoryId" )]
      [  XmlElement( ElementName = "CategoryId"   )]
      public short gxTpr_Categoryid
      {
         get {
            return gxTv_SdtShoppingCart_Product_Categoryid ;
         }

         set {
            gxTv_SdtShoppingCart_Product_N = 0;
            gxTv_SdtShoppingCart_Product_Categoryid = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Categoryid");
         }

      }

      [  SoapElement( ElementName = "CategoryName" )]
      [  XmlElement( ElementName = "CategoryName"   )]
      public string gxTpr_Categoryname
      {
         get {
            return gxTv_SdtShoppingCart_Product_Categoryname ;
         }

         set {
            gxTv_SdtShoppingCart_Product_N = 0;
            gxTv_SdtShoppingCart_Product_Categoryname = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Categoryname");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtShoppingCart_Product_Mode ;
         }

         set {
            gxTv_SdtShoppingCart_Product_N = 0;
            gxTv_SdtShoppingCart_Product_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtShoppingCart_Product_Mode_SetNull( )
      {
         gxTv_SdtShoppingCart_Product_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Product_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtShoppingCart_Product_Modified ;
         }

         set {
            gxTv_SdtShoppingCart_Product_N = 0;
            gxTv_SdtShoppingCart_Product_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtShoppingCart_Product_Modified_SetNull( )
      {
         gxTv_SdtShoppingCart_Product_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Product_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtShoppingCart_Product_Initialized ;
         }

         set {
            gxTv_SdtShoppingCart_Product_N = 0;
            gxTv_SdtShoppingCart_Product_Initialized = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtShoppingCart_Product_Initialized_SetNull( )
      {
         gxTv_SdtShoppingCart_Product_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Product_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductId_Z" )]
      [  XmlElement( ElementName = "ProductId_Z"   )]
      public short gxTpr_Productid_Z
      {
         get {
            return gxTv_SdtShoppingCart_Product_Productid_Z ;
         }

         set {
            gxTv_SdtShoppingCart_Product_N = 0;
            gxTv_SdtShoppingCart_Product_Productid_Z = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Productid_Z");
         }

      }

      public void gxTv_SdtShoppingCart_Product_Productid_Z_SetNull( )
      {
         gxTv_SdtShoppingCart_Product_Productid_Z = 0;
         SetDirty("Productid_Z");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Product_Productid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductName_Z" )]
      [  XmlElement( ElementName = "ProductName_Z"   )]
      public string gxTpr_Productname_Z
      {
         get {
            return gxTv_SdtShoppingCart_Product_Productname_Z ;
         }

         set {
            gxTv_SdtShoppingCart_Product_N = 0;
            gxTv_SdtShoppingCart_Product_Productname_Z = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Productname_Z");
         }

      }

      public void gxTv_SdtShoppingCart_Product_Productname_Z_SetNull( )
      {
         gxTv_SdtShoppingCart_Product_Productname_Z = "";
         SetDirty("Productname_Z");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Product_Productname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductPrice_Z" )]
      [  XmlElement( ElementName = "ProductPrice_Z"   )]
      public decimal gxTpr_Productprice_Z
      {
         get {
            return gxTv_SdtShoppingCart_Product_Productprice_Z ;
         }

         set {
            gxTv_SdtShoppingCart_Product_N = 0;
            gxTv_SdtShoppingCart_Product_Productprice_Z = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Productprice_Z");
         }

      }

      public void gxTv_SdtShoppingCart_Product_Productprice_Z_SetNull( )
      {
         gxTv_SdtShoppingCart_Product_Productprice_Z = 0;
         SetDirty("Productprice_Z");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Product_Productprice_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "QtyProduct_Z" )]
      [  XmlElement( ElementName = "QtyProduct_Z"   )]
      public short gxTpr_Qtyproduct_Z
      {
         get {
            return gxTv_SdtShoppingCart_Product_Qtyproduct_Z ;
         }

         set {
            gxTv_SdtShoppingCart_Product_N = 0;
            gxTv_SdtShoppingCart_Product_Qtyproduct_Z = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Qtyproduct_Z");
         }

      }

      public void gxTv_SdtShoppingCart_Product_Qtyproduct_Z_SetNull( )
      {
         gxTv_SdtShoppingCart_Product_Qtyproduct_Z = 0;
         SetDirty("Qtyproduct_Z");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Product_Qtyproduct_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TotalProduct_Z" )]
      [  XmlElement( ElementName = "TotalProduct_Z"   )]
      public decimal gxTpr_Totalproduct_Z
      {
         get {
            return gxTv_SdtShoppingCart_Product_Totalproduct_Z ;
         }

         set {
            gxTv_SdtShoppingCart_Product_N = 0;
            gxTv_SdtShoppingCart_Product_Totalproduct_Z = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Totalproduct_Z");
         }

      }

      public void gxTv_SdtShoppingCart_Product_Totalproduct_Z_SetNull( )
      {
         gxTv_SdtShoppingCart_Product_Totalproduct_Z = 0;
         SetDirty("Totalproduct_Z");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Product_Totalproduct_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoryId_Z" )]
      [  XmlElement( ElementName = "CategoryId_Z"   )]
      public short gxTpr_Categoryid_Z
      {
         get {
            return gxTv_SdtShoppingCart_Product_Categoryid_Z ;
         }

         set {
            gxTv_SdtShoppingCart_Product_N = 0;
            gxTv_SdtShoppingCart_Product_Categoryid_Z = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Categoryid_Z");
         }

      }

      public void gxTv_SdtShoppingCart_Product_Categoryid_Z_SetNull( )
      {
         gxTv_SdtShoppingCart_Product_Categoryid_Z = 0;
         SetDirty("Categoryid_Z");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Product_Categoryid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoryName_Z" )]
      [  XmlElement( ElementName = "CategoryName_Z"   )]
      public string gxTpr_Categoryname_Z
      {
         get {
            return gxTv_SdtShoppingCart_Product_Categoryname_Z ;
         }

         set {
            gxTv_SdtShoppingCart_Product_N = 0;
            gxTv_SdtShoppingCart_Product_Categoryname_Z = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Categoryname_Z");
         }

      }

      public void gxTv_SdtShoppingCart_Product_Categoryname_Z_SetNull( )
      {
         gxTv_SdtShoppingCart_Product_Categoryname_Z = "";
         SetDirty("Categoryname_Z");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Product_Categoryname_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtShoppingCart_Product_N = 1;
         gxTv_SdtShoppingCart_Product_Productname = "";
         gxTv_SdtShoppingCart_Product_Categoryname = "";
         gxTv_SdtShoppingCart_Product_Mode = "";
         gxTv_SdtShoppingCart_Product_Productname_Z = "";
         gxTv_SdtShoppingCart_Product_Categoryname_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtShoppingCart_Product_N ;
      }

      private short gxTv_SdtShoppingCart_Product_Productid ;
      private short gxTv_SdtShoppingCart_Product_N ;
      private short gxTv_SdtShoppingCart_Product_Qtyproduct ;
      private short gxTv_SdtShoppingCart_Product_Categoryid ;
      private short gxTv_SdtShoppingCart_Product_Modified ;
      private short gxTv_SdtShoppingCart_Product_Initialized ;
      private short gxTv_SdtShoppingCart_Product_Productid_Z ;
      private short gxTv_SdtShoppingCart_Product_Qtyproduct_Z ;
      private short gxTv_SdtShoppingCart_Product_Categoryid_Z ;
      private decimal gxTv_SdtShoppingCart_Product_Productprice ;
      private decimal gxTv_SdtShoppingCart_Product_Totalproduct ;
      private decimal gxTv_SdtShoppingCart_Product_Productprice_Z ;
      private decimal gxTv_SdtShoppingCart_Product_Totalproduct_Z ;
      private string gxTv_SdtShoppingCart_Product_Productname ;
      private string gxTv_SdtShoppingCart_Product_Categoryname ;
      private string gxTv_SdtShoppingCart_Product_Mode ;
      private string gxTv_SdtShoppingCart_Product_Productname_Z ;
      private string gxTv_SdtShoppingCart_Product_Categoryname_Z ;
   }

   [DataContract(Name = @"ShoppingCart.Product", Namespace = "TallerJAP2022KarenRubiaca")]
   public class SdtShoppingCart_Product_RESTInterface : GxGenericCollectionItem<SdtShoppingCart_Product>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtShoppingCart_Product_RESTInterface( ) : base()
      {
      }

      public SdtShoppingCart_Product_RESTInterface( SdtShoppingCart_Product psdt ) : base(psdt)
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

      [DataMember( Name = "ProductPrice" , Order = 2 )]
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

      [DataMember( Name = "QtyProduct" , Order = 3 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Qtyproduct
      {
         get {
            return sdt.gxTpr_Qtyproduct ;
         }

         set {
            sdt.gxTpr_Qtyproduct = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "TotalProduct" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Totalproduct
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Totalproduct, 10, 2)) ;
         }

         set {
            sdt.gxTpr_Totalproduct = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "CategoryId" , Order = 5 )]
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

      [DataMember( Name = "CategoryName" , Order = 6 )]
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

      public SdtShoppingCart_Product sdt
      {
         get {
            return (SdtShoppingCart_Product)Sdt ;
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
            sdt = new SdtShoppingCart_Product() ;
         }
      }

   }

   [DataContract(Name = @"ShoppingCart.Product", Namespace = "TallerJAP2022KarenRubiaca")]
   public class SdtShoppingCart_Product_RESTLInterface : GxGenericCollectionItem<SdtShoppingCart_Product>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtShoppingCart_Product_RESTLInterface( ) : base()
      {
      }

      public SdtShoppingCart_Product_RESTLInterface( SdtShoppingCart_Product psdt ) : base(psdt)
      {
      }

      public SdtShoppingCart_Product sdt
      {
         get {
            return (SdtShoppingCart_Product)Sdt ;
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
            sdt = new SdtShoppingCart_Product() ;
         }
      }

   }

}
