using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class customer_bc : GXHttpHandler, IGxSilentTrn
   {
      public customer_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public customer_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow064( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey064( ) ;
         standaloneModal( ) ;
         AddRow064( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z6CustomerId = A6CustomerId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_060( )
      {
         BeforeValidate064( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls064( ) ;
            }
            else
            {
               CheckExtendedTable064( ) ;
               if ( AnyError == 0 )
               {
                  ZM064( 6) ;
               }
               CloseExtendedTableCursors064( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM064( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z15CustomerName = A15CustomerName;
            Z16CustomerAddress = A16CustomerAddress;
            Z17CustomerEmail = A17CustomerEmail;
            Z18CustomerPhone = A18CustomerPhone;
            Z3CountryId = A3CountryId;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z4CountryName = A4CountryName;
         }
         if ( GX_JID == -5 )
         {
            Z6CustomerId = A6CustomerId;
            Z15CustomerName = A15CustomerName;
            Z16CustomerAddress = A16CustomerAddress;
            Z17CustomerEmail = A17CustomerEmail;
            Z18CustomerPhone = A18CustomerPhone;
            Z3CountryId = A3CountryId;
            Z4CountryName = A4CountryName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load064( )
      {
         /* Using cursor BC00065 */
         pr_default.execute(3, new Object[] {A6CustomerId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound4 = 1;
            A15CustomerName = BC00065_A15CustomerName[0];
            A16CustomerAddress = BC00065_A16CustomerAddress[0];
            A17CustomerEmail = BC00065_A17CustomerEmail[0];
            A18CustomerPhone = BC00065_A18CustomerPhone[0];
            A4CountryName = BC00065_A4CountryName[0];
            A3CountryId = BC00065_A3CountryId[0];
            ZM064( -5) ;
         }
         pr_default.close(3);
         OnLoadActions064( ) ;
      }

      protected void OnLoadActions064( )
      {
      }

      protected void CheckExtendedTable064( )
      {
         nIsDirty_4 = 0;
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A15CustomerName)) )
         {
            GX_msglist.addItem("The name cannot be empty", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A16CustomerAddress)) )
         {
            GX_msglist.addItem("The address cannot be empty", 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A17CustomerEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("Field Customer Email does not match the specified pattern", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A18CustomerPhone)) )
         {
            GX_msglist.addItem("The phone is empty", 0, "");
         }
         /* Using cursor BC00064 */
         pr_default.execute(2, new Object[] {A3CountryId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
         }
         A4CountryName = BC00064_A4CountryName[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors064( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey064( )
      {
         /* Using cursor BC00066 */
         pr_default.execute(4, new Object[] {A6CustomerId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00063 */
         pr_default.execute(1, new Object[] {A6CustomerId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM064( 5) ;
            RcdFound4 = 1;
            A6CustomerId = BC00063_A6CustomerId[0];
            A15CustomerName = BC00063_A15CustomerName[0];
            A16CustomerAddress = BC00063_A16CustomerAddress[0];
            A17CustomerEmail = BC00063_A17CustomerEmail[0];
            A18CustomerPhone = BC00063_A18CustomerPhone[0];
            A3CountryId = BC00063_A3CountryId[0];
            Z6CustomerId = A6CustomerId;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load064( ) ;
            if ( AnyError == 1 )
            {
               RcdFound4 = 0;
               InitializeNonKey064( ) ;
            }
            Gx_mode = sMode4;
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey064( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode4;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey064( ) ;
         if ( RcdFound4 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_060( ) ;
         IsConfirmed = 0;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency064( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00062 */
            pr_default.execute(0, new Object[] {A6CustomerId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Customer"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z15CustomerName, BC00062_A15CustomerName[0]) != 0 ) || ( StringUtil.StrCmp(Z16CustomerAddress, BC00062_A16CustomerAddress[0]) != 0 ) || ( StringUtil.StrCmp(Z17CustomerEmail, BC00062_A17CustomerEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z18CustomerPhone, BC00062_A18CustomerPhone[0]) != 0 ) || ( Z3CountryId != BC00062_A3CountryId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Customer"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert064( )
      {
         BeforeValidate064( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable064( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM064( 0) ;
            CheckOptimisticConcurrency064( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm064( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert064( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00067 */
                     pr_default.execute(5, new Object[] {A15CustomerName, A16CustomerAddress, A17CustomerEmail, A18CustomerPhone, A3CountryId});
                     A6CustomerId = BC00067_A6CustomerId[0];
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("Customer");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load064( ) ;
            }
            EndLevel064( ) ;
         }
         CloseExtendedTableCursors064( ) ;
      }

      protected void Update064( )
      {
         BeforeValidate064( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable064( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency064( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm064( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate064( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00068 */
                     pr_default.execute(6, new Object[] {A15CustomerName, A16CustomerAddress, A17CustomerEmail, A18CustomerPhone, A3CountryId, A6CustomerId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Customer");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Customer"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate064( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel064( ) ;
         }
         CloseExtendedTableCursors064( ) ;
      }

      protected void DeferredUpdate064( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate064( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency064( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls064( ) ;
            AfterConfirm064( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete064( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00069 */
                  pr_default.execute(7, new Object[] {A6CustomerId});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("Customer");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel064( ) ;
         Gx_mode = sMode4;
      }

      protected void OnDeleteControls064( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000610 */
            pr_default.execute(8, new Object[] {A3CountryId});
            A4CountryName = BC000610_A4CountryName[0];
            pr_default.close(8);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000611 */
            pr_default.execute(9, new Object[] {A6CustomerId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Shopping Cart"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel064( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete064( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart064( )
      {
         /* Using cursor BC000612 */
         pr_default.execute(10, new Object[] {A6CustomerId});
         RcdFound4 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound4 = 1;
            A6CustomerId = BC000612_A6CustomerId[0];
            A15CustomerName = BC000612_A15CustomerName[0];
            A16CustomerAddress = BC000612_A16CustomerAddress[0];
            A17CustomerEmail = BC000612_A17CustomerEmail[0];
            A18CustomerPhone = BC000612_A18CustomerPhone[0];
            A4CountryName = BC000612_A4CountryName[0];
            A3CountryId = BC000612_A3CountryId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext064( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound4 = 0;
         ScanKeyLoad064( ) ;
      }

      protected void ScanKeyLoad064( )
      {
         sMode4 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound4 = 1;
            A6CustomerId = BC000612_A6CustomerId[0];
            A15CustomerName = BC000612_A15CustomerName[0];
            A16CustomerAddress = BC000612_A16CustomerAddress[0];
            A17CustomerEmail = BC000612_A17CustomerEmail[0];
            A18CustomerPhone = BC000612_A18CustomerPhone[0];
            A4CountryName = BC000612_A4CountryName[0];
            A3CountryId = BC000612_A3CountryId[0];
         }
         Gx_mode = sMode4;
      }

      protected void ScanKeyEnd064( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm064( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert064( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate064( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete064( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete064( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate064( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes064( )
      {
      }

      protected void send_integrity_lvl_hashes064( )
      {
      }

      protected void AddRow064( )
      {
         VarsToRow4( bcCustomer) ;
      }

      protected void ReadRow064( )
      {
         RowToVars4( bcCustomer, 1) ;
      }

      protected void InitializeNonKey064( )
      {
         A15CustomerName = "";
         A16CustomerAddress = "";
         A17CustomerEmail = "";
         A18CustomerPhone = "";
         A3CountryId = 0;
         A4CountryName = "";
         Z15CustomerName = "";
         Z16CustomerAddress = "";
         Z17CustomerEmail = "";
         Z18CustomerPhone = "";
         Z3CountryId = 0;
      }

      protected void InitAll064( )
      {
         A6CustomerId = 0;
         InitializeNonKey064( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow4( SdtCustomer obj4 )
      {
         obj4.gxTpr_Mode = Gx_mode;
         obj4.gxTpr_Customername = A15CustomerName;
         obj4.gxTpr_Customeraddress = A16CustomerAddress;
         obj4.gxTpr_Customeremail = A17CustomerEmail;
         obj4.gxTpr_Customerphone = A18CustomerPhone;
         obj4.gxTpr_Countryid = A3CountryId;
         obj4.gxTpr_Countryname = A4CountryName;
         obj4.gxTpr_Customerid = A6CustomerId;
         obj4.gxTpr_Customerid_Z = Z6CustomerId;
         obj4.gxTpr_Customername_Z = Z15CustomerName;
         obj4.gxTpr_Customeraddress_Z = Z16CustomerAddress;
         obj4.gxTpr_Customeremail_Z = Z17CustomerEmail;
         obj4.gxTpr_Customerphone_Z = Z18CustomerPhone;
         obj4.gxTpr_Countryid_Z = Z3CountryId;
         obj4.gxTpr_Countryname_Z = Z4CountryName;
         obj4.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow4( SdtCustomer obj4 )
      {
         obj4.gxTpr_Customerid = A6CustomerId;
         return  ;
      }

      public void RowToVars4( SdtCustomer obj4 ,
                              int forceLoad )
      {
         Gx_mode = obj4.gxTpr_Mode;
         A15CustomerName = obj4.gxTpr_Customername;
         A16CustomerAddress = obj4.gxTpr_Customeraddress;
         A17CustomerEmail = obj4.gxTpr_Customeremail;
         A18CustomerPhone = obj4.gxTpr_Customerphone;
         A3CountryId = obj4.gxTpr_Countryid;
         A4CountryName = obj4.gxTpr_Countryname;
         A6CustomerId = obj4.gxTpr_Customerid;
         Z6CustomerId = obj4.gxTpr_Customerid_Z;
         Z15CustomerName = obj4.gxTpr_Customername_Z;
         Z16CustomerAddress = obj4.gxTpr_Customeraddress_Z;
         Z17CustomerEmail = obj4.gxTpr_Customeremail_Z;
         Z18CustomerPhone = obj4.gxTpr_Customerphone_Z;
         Z3CountryId = obj4.gxTpr_Countryid_Z;
         Z4CountryName = obj4.gxTpr_Countryname_Z;
         Gx_mode = obj4.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A6CustomerId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey064( ) ;
         ScanKeyStart064( ) ;
         if ( RcdFound4 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z6CustomerId = A6CustomerId;
         }
         ZM064( -5) ;
         OnLoadActions064( ) ;
         AddRow064( ) ;
         ScanKeyEnd064( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars4( bcCustomer, 0) ;
         ScanKeyStart064( ) ;
         if ( RcdFound4 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z6CustomerId = A6CustomerId;
         }
         ZM064( -5) ;
         OnLoadActions064( ) ;
         AddRow064( ) ;
         ScanKeyEnd064( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey064( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert064( ) ;
         }
         else
         {
            if ( RcdFound4 == 1 )
            {
               if ( A6CustomerId != Z6CustomerId )
               {
                  A6CustomerId = Z6CustomerId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update064( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A6CustomerId != Z6CustomerId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert064( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert064( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars4( bcCustomer, 1) ;
         SaveImpl( ) ;
         VarsToRow4( bcCustomer) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars4( bcCustomer, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert064( ) ;
         AfterTrn( ) ;
         VarsToRow4( bcCustomer) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
         }
         else
         {
            SdtCustomer auxBC = new SdtCustomer(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A6CustomerId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcCustomer);
               auxBC.Save();
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars4( bcCustomer, 1) ;
         UpdateImpl( ) ;
         VarsToRow4( bcCustomer) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars4( bcCustomer, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert064( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
         }
         else
         {
            AfterTrn( ) ;
         }
         VarsToRow4( bcCustomer) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars4( bcCustomer, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey064( ) ;
         if ( RcdFound4 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A6CustomerId != Z6CustomerId )
            {
               A6CustomerId = Z6CustomerId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A6CustomerId != Z6CustomerId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(1);
         pr_default.close(8);
         context.RollbackDataStores("customer_bc",pr_default);
         VarsToRow4( bcCustomer) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcCustomer.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcCustomer.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcCustomer )
         {
            bcCustomer = (SdtCustomer)(sdt);
            if ( StringUtil.StrCmp(bcCustomer.gxTpr_Mode, "") == 0 )
            {
               bcCustomer.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow4( bcCustomer) ;
            }
            else
            {
               RowToVars4( bcCustomer, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcCustomer.gxTpr_Mode, "") == 0 )
            {
               bcCustomer.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars4( bcCustomer, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtCustomer Customer_BC
      {
         get {
            return bcCustomer ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
      }

      protected override void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
         pr_default.close(8);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z15CustomerName = "";
         A15CustomerName = "";
         Z16CustomerAddress = "";
         A16CustomerAddress = "";
         Z17CustomerEmail = "";
         A17CustomerEmail = "";
         Z18CustomerPhone = "";
         A18CustomerPhone = "";
         Z4CountryName = "";
         A4CountryName = "";
         BC00065_A6CustomerId = new short[1] ;
         BC00065_A15CustomerName = new string[] {""} ;
         BC00065_A16CustomerAddress = new string[] {""} ;
         BC00065_A17CustomerEmail = new string[] {""} ;
         BC00065_A18CustomerPhone = new string[] {""} ;
         BC00065_A4CountryName = new string[] {""} ;
         BC00065_A3CountryId = new short[1] ;
         BC00064_A4CountryName = new string[] {""} ;
         BC00066_A6CustomerId = new short[1] ;
         BC00063_A6CustomerId = new short[1] ;
         BC00063_A15CustomerName = new string[] {""} ;
         BC00063_A16CustomerAddress = new string[] {""} ;
         BC00063_A17CustomerEmail = new string[] {""} ;
         BC00063_A18CustomerPhone = new string[] {""} ;
         BC00063_A3CountryId = new short[1] ;
         sMode4 = "";
         BC00062_A6CustomerId = new short[1] ;
         BC00062_A15CustomerName = new string[] {""} ;
         BC00062_A16CustomerAddress = new string[] {""} ;
         BC00062_A17CustomerEmail = new string[] {""} ;
         BC00062_A18CustomerPhone = new string[] {""} ;
         BC00062_A3CountryId = new short[1] ;
         BC00067_A6CustomerId = new short[1] ;
         BC000610_A4CountryName = new string[] {""} ;
         BC000611_A11ShoppingCartId = new short[1] ;
         BC000612_A6CustomerId = new short[1] ;
         BC000612_A15CustomerName = new string[] {""} ;
         BC000612_A16CustomerAddress = new string[] {""} ;
         BC000612_A17CustomerEmail = new string[] {""} ;
         BC000612_A18CustomerPhone = new string[] {""} ;
         BC000612_A4CountryName = new string[] {""} ;
         BC000612_A3CountryId = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.customer_bc__default(),
            new Object[][] {
                new Object[] {
               BC00062_A6CustomerId, BC00062_A15CustomerName, BC00062_A16CustomerAddress, BC00062_A17CustomerEmail, BC00062_A18CustomerPhone, BC00062_A3CountryId
               }
               , new Object[] {
               BC00063_A6CustomerId, BC00063_A15CustomerName, BC00063_A16CustomerAddress, BC00063_A17CustomerEmail, BC00063_A18CustomerPhone, BC00063_A3CountryId
               }
               , new Object[] {
               BC00064_A4CountryName
               }
               , new Object[] {
               BC00065_A6CustomerId, BC00065_A15CustomerName, BC00065_A16CustomerAddress, BC00065_A17CustomerEmail, BC00065_A18CustomerPhone, BC00065_A4CountryName, BC00065_A3CountryId
               }
               , new Object[] {
               BC00066_A6CustomerId
               }
               , new Object[] {
               BC00067_A6CustomerId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000610_A4CountryName
               }
               , new Object[] {
               BC000611_A11ShoppingCartId
               }
               , new Object[] {
               BC000612_A6CustomerId, BC000612_A15CustomerName, BC000612_A16CustomerAddress, BC000612_A17CustomerEmail, BC000612_A18CustomerPhone, BC000612_A4CountryName, BC000612_A3CountryId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Z6CustomerId ;
      private short A6CustomerId ;
      private short GX_JID ;
      private short Z3CountryId ;
      private short A3CountryId ;
      private short RcdFound4 ;
      private short nIsDirty_4 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z15CustomerName ;
      private string A15CustomerName ;
      private string Z18CustomerPhone ;
      private string A18CustomerPhone ;
      private string Z4CountryName ;
      private string A4CountryName ;
      private string sMode4 ;
      private bool mustCommit ;
      private string Z16CustomerAddress ;
      private string A16CustomerAddress ;
      private string Z17CustomerEmail ;
      private string A17CustomerEmail ;
      private SdtCustomer bcCustomer ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00065_A6CustomerId ;
      private string[] BC00065_A15CustomerName ;
      private string[] BC00065_A16CustomerAddress ;
      private string[] BC00065_A17CustomerEmail ;
      private string[] BC00065_A18CustomerPhone ;
      private string[] BC00065_A4CountryName ;
      private short[] BC00065_A3CountryId ;
      private string[] BC00064_A4CountryName ;
      private short[] BC00066_A6CustomerId ;
      private short[] BC00063_A6CustomerId ;
      private string[] BC00063_A15CustomerName ;
      private string[] BC00063_A16CustomerAddress ;
      private string[] BC00063_A17CustomerEmail ;
      private string[] BC00063_A18CustomerPhone ;
      private short[] BC00063_A3CountryId ;
      private short[] BC00062_A6CustomerId ;
      private string[] BC00062_A15CustomerName ;
      private string[] BC00062_A16CustomerAddress ;
      private string[] BC00062_A17CustomerEmail ;
      private string[] BC00062_A18CustomerPhone ;
      private short[] BC00062_A3CountryId ;
      private short[] BC00067_A6CustomerId ;
      private string[] BC000610_A4CountryName ;
      private short[] BC000611_A11ShoppingCartId ;
      private short[] BC000612_A6CustomerId ;
      private string[] BC000612_A15CustomerName ;
      private string[] BC000612_A16CustomerAddress ;
      private string[] BC000612_A17CustomerEmail ;
      private string[] BC000612_A18CustomerPhone ;
      private string[] BC000612_A4CountryName ;
      private short[] BC000612_A3CountryId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class customer_bc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00065;
          prmBC00065 = new Object[] {
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmBC00064;
          prmBC00064 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC00066;
          prmBC00066 = new Object[] {
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmBC00063;
          prmBC00063 = new Object[] {
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmBC00062;
          prmBC00062 = new Object[] {
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmBC00067;
          prmBC00067 = new Object[] {
          new ParDef("@CustomerName",GXType.NChar,20,0) ,
          new ParDef("@CustomerAddress",GXType.NVarChar,1024,0) ,
          new ParDef("@CustomerEmail",GXType.NVarChar,100,0) ,
          new ParDef("@CustomerPhone",GXType.NChar,20,0) ,
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC00068;
          prmBC00068 = new Object[] {
          new ParDef("@CustomerName",GXType.NChar,20,0) ,
          new ParDef("@CustomerAddress",GXType.NVarChar,1024,0) ,
          new ParDef("@CustomerEmail",GXType.NVarChar,100,0) ,
          new ParDef("@CustomerPhone",GXType.NChar,20,0) ,
          new ParDef("@CountryId",GXType.Int16,4,0) ,
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmBC00069;
          prmBC00069 = new Object[] {
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmBC000610;
          prmBC000610 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC000611;
          prmBC000611 = new Object[] {
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmBC000612;
          prmBC000612 = new Object[] {
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00062", "SELECT [CustomerId], [CustomerName], [CustomerAddress], [CustomerEmail], [CustomerPhone], [CountryId] FROM [Customer] WITH (UPDLOCK) WHERE [CustomerId] = @CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00062,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00063", "SELECT [CustomerId], [CustomerName], [CustomerAddress], [CustomerEmail], [CustomerPhone], [CountryId] FROM [Customer] WHERE [CustomerId] = @CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00063,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00064", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00064,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00065", "SELECT TM1.[CustomerId], TM1.[CustomerName], TM1.[CustomerAddress], TM1.[CustomerEmail], TM1.[CustomerPhone], T2.[CountryName], TM1.[CountryId] FROM ([Customer] TM1 INNER JOIN [Country] T2 ON T2.[CountryId] = TM1.[CountryId]) WHERE TM1.[CustomerId] = @CustomerId ORDER BY TM1.[CustomerId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00065,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00066", "SELECT [CustomerId] FROM [Customer] WHERE [CustomerId] = @CustomerId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00066,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00067", "INSERT INTO [Customer]([CustomerName], [CustomerAddress], [CustomerEmail], [CustomerPhone], [CountryId]) VALUES(@CustomerName, @CustomerAddress, @CustomerEmail, @CustomerPhone, @CountryId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00067,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC00068", "UPDATE [Customer] SET [CustomerName]=@CustomerName, [CustomerAddress]=@CustomerAddress, [CustomerEmail]=@CustomerEmail, [CustomerPhone]=@CustomerPhone, [CountryId]=@CountryId  WHERE [CustomerId] = @CustomerId", GxErrorMask.GX_NOMASK,prmBC00068)
             ,new CursorDef("BC00069", "DELETE FROM [Customer]  WHERE [CustomerId] = @CustomerId", GxErrorMask.GX_NOMASK,prmBC00069)
             ,new CursorDef("BC000610", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000610,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000611", "SELECT TOP 1 [ShoppingCartId] FROM [ShoppingCart] WHERE [CustomerId] = @CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000611,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000612", "SELECT TM1.[CustomerId], TM1.[CustomerName], TM1.[CustomerAddress], TM1.[CustomerEmail], TM1.[CustomerPhone], T2.[CountryName], TM1.[CountryId] FROM ([Customer] TM1 INNER JOIN [Country] T2 ON T2.[CountryId] = TM1.[CountryId]) WHERE TM1.[CustomerId] = @CustomerId ORDER BY TM1.[CustomerId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000612,100, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
       }
    }

 }

}
