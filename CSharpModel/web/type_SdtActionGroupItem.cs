/*
				   File: type_SdtActionGroupItem
			Description: ActionGroupItem
				 Author: Nemo 🐠 for C# version 17.0.11.163677
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Services.Protocols;


namespace GeneXus.Programs
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="ActionGroupItem")]
	[XmlType(TypeName="ActionGroupItem" , Namespace="TallerJAP2022KarenRubiaca" )]
	[Serializable]
	public class SdtActionGroupItem : GxUserType
	{
		public SdtActionGroupItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtActionGroupItem_Id = "";

			gxTv_SdtActionGroupItem_Caption = "";

			gxTv_SdtActionGroupItem_Link = "";

			gxTv_SdtActionGroupItem_Eventname = "";

			gxTv_SdtActionGroupItem_Class = "";

			gxTv_SdtActionGroupItem_Tooltiptext = "";

		}

		public SdtActionGroupItem(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("Id", gxTpr_Id, false);


			AddObjectProperty("Caption", gxTpr_Caption, false);


			AddObjectProperty("Link", gxTpr_Link, false);


			AddObjectProperty("EventName", gxTpr_Eventname, false);


			AddObjectProperty("Class", gxTpr_Class, false);


			AddObjectProperty("TooltipText", gxTpr_Tooltiptext, false);

			if (gxTv_SdtActionGroupItem_Children != null)
			{
				AddObjectProperty("Children", gxTv_SdtActionGroupItem_Children, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Id")]
		[XmlElement(ElementName="Id")]
		public string gxTpr_Id
		{
			get {
				return gxTv_SdtActionGroupItem_Id; 
			}
			set {
				gxTv_SdtActionGroupItem_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="Caption")]
		[XmlElement(ElementName="Caption")]
		public string gxTpr_Caption
		{
			get {
				return gxTv_SdtActionGroupItem_Caption; 
			}
			set {
				gxTv_SdtActionGroupItem_Caption = value;
				SetDirty("Caption");
			}
		}




		[SoapElement(ElementName="Link")]
		[XmlElement(ElementName="Link")]
		public string gxTpr_Link
		{
			get {
				return gxTv_SdtActionGroupItem_Link; 
			}
			set {
				gxTv_SdtActionGroupItem_Link = value;
				SetDirty("Link");
			}
		}




		[SoapElement(ElementName="EventName")]
		[XmlElement(ElementName="EventName")]
		public string gxTpr_Eventname
		{
			get {
				return gxTv_SdtActionGroupItem_Eventname; 
			}
			set {
				gxTv_SdtActionGroupItem_Eventname = value;
				SetDirty("Eventname");
			}
		}




		[SoapElement(ElementName="Class")]
		[XmlElement(ElementName="Class")]
		public string gxTpr_Class
		{
			get {
				return gxTv_SdtActionGroupItem_Class; 
			}
			set {
				gxTv_SdtActionGroupItem_Class = value;
				SetDirty("Class");
			}
		}




		[SoapElement(ElementName="TooltipText")]
		[XmlElement(ElementName="TooltipText")]
		public string gxTpr_Tooltiptext
		{
			get {
				return gxTv_SdtActionGroupItem_Tooltiptext; 
			}
			set {
				gxTv_SdtActionGroupItem_Tooltiptext = value;
				SetDirty("Tooltiptext");
			}
		}




		[SoapElement(ElementName="Children" )]
		[XmlArray(ElementName="Children"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtActionGroupItem> gxTpr_Children_GXBaseCollection
		{
			get {
				if ( gxTv_SdtActionGroupItem_Children == null )
				{
					gxTv_SdtActionGroupItem_Children = new GXBaseCollection<GeneXus.Programs.SdtActionGroupItem>( context, "ActionGroupItem", "");
				}
				return gxTv_SdtActionGroupItem_Children;
			}
			set {
				gxTv_SdtActionGroupItem_Children_N = false;
				gxTv_SdtActionGroupItem_Children = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtActionGroupItem> gxTpr_Children
		{
			get {
				if ( gxTv_SdtActionGroupItem_Children == null )
				{
					gxTv_SdtActionGroupItem_Children = new GXBaseCollection<GeneXus.Programs.SdtActionGroupItem>( context, "ActionGroupItem", "");
				}
				gxTv_SdtActionGroupItem_Children_N = false;
				return gxTv_SdtActionGroupItem_Children ;
			}
			set {
				gxTv_SdtActionGroupItem_Children_N = false;
				gxTv_SdtActionGroupItem_Children = value;
				SetDirty("Children");
			}
		}

		public void gxTv_SdtActionGroupItem_Children_SetNull()
		{
			gxTv_SdtActionGroupItem_Children_N = true;
			gxTv_SdtActionGroupItem_Children = null;
		}

		public bool gxTv_SdtActionGroupItem_Children_IsNull()
		{
			return gxTv_SdtActionGroupItem_Children == null;
		}
		public bool ShouldSerializegxTpr_Children_GXBaseCollection_Json()
		{
			return gxTv_SdtActionGroupItem_Children != null && gxTv_SdtActionGroupItem_Children.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtActionGroupItem_Id = "";
			gxTv_SdtActionGroupItem_Caption = "";
			gxTv_SdtActionGroupItem_Link = "";
			gxTv_SdtActionGroupItem_Eventname = "";
			gxTv_SdtActionGroupItem_Class = "";
			gxTv_SdtActionGroupItem_Tooltiptext = "";

			gxTv_SdtActionGroupItem_Children_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtActionGroupItem_Id;
		 

		protected string gxTv_SdtActionGroupItem_Caption;
		 

		protected string gxTv_SdtActionGroupItem_Link;
		 

		protected string gxTv_SdtActionGroupItem_Eventname;
		 

		protected string gxTv_SdtActionGroupItem_Class;
		 

		protected string gxTv_SdtActionGroupItem_Tooltiptext;
		 
		protected bool gxTv_SdtActionGroupItem_Children_N;
		protected GXBaseCollection<GeneXus.Programs.SdtActionGroupItem> gxTv_SdtActionGroupItem_Children = null;  


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"ActionGroupItem", Namespace="TallerJAP2022KarenRubiaca")]
	public class SdtActionGroupItem_RESTInterface : GxGenericCollectionItem<SdtActionGroupItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtActionGroupItem_RESTInterface( ) : base()
		{	
		}

		public SdtActionGroupItem_RESTInterface( SdtActionGroupItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Id", Order=0)]
		public  string gxTpr_Id
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Id);

			}
			set { 
				 sdt.gxTpr_Id = value;
			}
		}

		[DataMember(Name="Caption", Order=1)]
		public  string gxTpr_Caption
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Caption);

			}
			set { 
				 sdt.gxTpr_Caption = value;
			}
		}

		[DataMember(Name="Link", Order=2)]
		public  string gxTpr_Link
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Link);

			}
			set { 
				 sdt.gxTpr_Link = value;
			}
		}

		[DataMember(Name="EventName", Order=3)]
		public  string gxTpr_Eventname
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Eventname);

			}
			set { 
				 sdt.gxTpr_Eventname = value;
			}
		}

		[DataMember(Name="Class", Order=4)]
		public  string gxTpr_Class
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Class);

			}
			set { 
				 sdt.gxTpr_Class = value;
			}
		}

		[DataMember(Name="TooltipText", Order=5)]
		public  string gxTpr_Tooltiptext
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tooltiptext);

			}
			set { 
				 sdt.gxTpr_Tooltiptext = value;
			}
		}

		[DataMember(Name="Children", Order=6, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtActionGroupItem_RESTInterface> gxTpr_Children
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Children_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtActionGroupItem_RESTInterface>(sdt.gxTpr_Children);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Children);
			}
		}


		#endregion

		public SdtActionGroupItem sdt
		{
			get { 
				return (SdtActionGroupItem)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtActionGroupItem() ;
			}
		}
	}
	#endregion
}