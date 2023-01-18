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
   public class product_bc : GXHttpHandler, IGxSilentTrn
   {
      public product_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public product_bc( IGxContext context )
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
         ReadRow045( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey045( ) ;
         standaloneModal( ) ;
         AddRow045( ) ;
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
               Z7ProductId = A7ProductId;
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

      protected void CONFIRM_040( )
      {
         BeforeValidate045( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls045( ) ;
            }
            else
            {
               CheckExtendedTable045( ) ;
               if ( AnyError == 0 )
               {
                  ZM045( 5) ;
                  ZM045( 6) ;
                  ZM045( 7) ;
                  ZM045( 8) ;
               }
               CloseExtendedTableCursors045( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM045( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z8ProductName = A8ProductName;
            Z21ProductDescription = A21ProductDescription;
            Z22ProductPrice = A22ProductPrice;
            Z5SellerId = A5SellerId;
            Z1CategoryId = A1CategoryId;
            Z9ProductCountryId = A9ProductCountryId;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z13SellerName = A13SellerName;
            Z3CountryId = A3CountryId;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z2CategoryName = A2CategoryName;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z33ProductCountryName = A33ProductCountryName;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z4CountryName = A4CountryName;
         }
         if ( GX_JID == -3 )
         {
            Z7ProductId = A7ProductId;
            Z8ProductName = A8ProductName;
            Z21ProductDescription = A21ProductDescription;
            Z22ProductPrice = A22ProductPrice;
            Z23ProductPhoto = A23ProductPhoto;
            Z40000ProductPhoto_GXI = A40000ProductPhoto_GXI;
            Z5SellerId = A5SellerId;
            Z1CategoryId = A1CategoryId;
            Z9ProductCountryId = A9ProductCountryId;
            Z33ProductCountryName = A33ProductCountryName;
            Z13SellerName = A13SellerName;
            Z14SellerPhoto = A14SellerPhoto;
            Z40001SellerPhoto_GXI = A40001SellerPhoto_GXI;
            Z3CountryId = A3CountryId;
            Z4CountryName = A4CountryName;
            Z2CategoryName = A2CategoryName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load045( )
      {
         /* Using cursor BC00048 */
         pr_default.execute(6, new Object[] {A7ProductId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound5 = 1;
            A8ProductName = BC00048_A8ProductName[0];
            A21ProductDescription = BC00048_A21ProductDescription[0];
            A22ProductPrice = BC00048_A22ProductPrice[0];
            A40000ProductPhoto_GXI = BC00048_A40000ProductPhoto_GXI[0];
            A33ProductCountryName = BC00048_A33ProductCountryName[0];
            A13SellerName = BC00048_A13SellerName[0];
            A40001SellerPhoto_GXI = BC00048_A40001SellerPhoto_GXI[0];
            A2CategoryName = BC00048_A2CategoryName[0];
            A4CountryName = BC00048_A4CountryName[0];
            A5SellerId = BC00048_A5SellerId[0];
            A1CategoryId = BC00048_A1CategoryId[0];
            A9ProductCountryId = BC00048_A9ProductCountryId[0];
            A3CountryId = BC00048_A3CountryId[0];
            A23ProductPhoto = BC00048_A23ProductPhoto[0];
            A14SellerPhoto = BC00048_A14SellerPhoto[0];
            ZM045( -3) ;
         }
         pr_default.close(6);
         OnLoadActions045( ) ;
      }

      protected void OnLoadActions045( )
      {
      }

      protected void CheckExtendedTable045( )
      {
         nIsDirty_5 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00049 */
         pr_default.execute(7, new Object[] {A8ProductName, A7ProductId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Product Name"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(7);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A8ProductName)) )
         {
            GX_msglist.addItem("The name cannot be empty", 1, "");
            AnyError = 1;
         }
         if ( (Convert.ToDecimal(0)==A22ProductPrice) )
         {
            GX_msglist.addItem("The price cannot be empty", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00046 */
         pr_default.execute(4, new Object[] {A9ProductCountryId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Product Country'.", "ForeignKeyNotFound", 1, "PRODUCTCOUNTRYID");
            AnyError = 1;
         }
         A33ProductCountryName = BC00046_A33ProductCountryName[0];
         pr_default.close(4);
         /* Using cursor BC00044 */
         pr_default.execute(2, new Object[] {A5SellerId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Seller'.", "ForeignKeyNotFound", 1, "SELLERID");
            AnyError = 1;
         }
         A13SellerName = BC00044_A13SellerName[0];
         A40001SellerPhoto_GXI = BC00044_A40001SellerPhoto_GXI[0];
         A3CountryId = BC00044_A3CountryId[0];
         A14SellerPhoto = BC00044_A14SellerPhoto[0];
         pr_default.close(2);
         /* Using cursor BC00047 */
         pr_default.execute(5, new Object[] {A3CountryId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No matching 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
         }
         A4CountryName = BC00047_A4CountryName[0];
         pr_default.close(5);
         /* Using cursor BC00045 */
         pr_default.execute(3, new Object[] {A1CategoryId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No matching 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
            AnyError = 1;
         }
         A2CategoryName = BC00045_A2CategoryName[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors045( )
      {
         pr_default.close(4);
         pr_default.close(2);
         pr_default.close(5);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey045( )
      {
         /* Using cursor BC000410 */
         pr_default.execute(8, new Object[] {A7ProductId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00043 */
         pr_default.execute(1, new Object[] {A7ProductId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM045( 3) ;
            RcdFound5 = 1;
            A7ProductId = BC00043_A7ProductId[0];
            A8ProductName = BC00043_A8ProductName[0];
            A21ProductDescription = BC00043_A21ProductDescription[0];
            A22ProductPrice = BC00043_A22ProductPrice[0];
            A40000ProductPhoto_GXI = BC00043_A40000ProductPhoto_GXI[0];
            A5SellerId = BC00043_A5SellerId[0];
            A1CategoryId = BC00043_A1CategoryId[0];
            A9ProductCountryId = BC00043_A9ProductCountryId[0];
            A23ProductPhoto = BC00043_A23ProductPhoto[0];
            Z7ProductId = A7ProductId;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load045( ) ;
            if ( AnyError == 1 )
            {
               RcdFound5 = 0;
               InitializeNonKey045( ) ;
            }
            Gx_mode = sMode5;
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey045( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode5;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey045( ) ;
         if ( RcdFound5 == 0 )
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
         CONFIRM_040( ) ;
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

      protected void CheckOptimisticConcurrency045( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00042 */
            pr_default.execute(0, new Object[] {A7ProductId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Product"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z8ProductName, BC00042_A8ProductName[0]) != 0 ) || ( StringUtil.StrCmp(Z21ProductDescription, BC00042_A21ProductDescription[0]) != 0 ) || ( Z22ProductPrice != BC00042_A22ProductPrice[0] ) || ( Z5SellerId != BC00042_A5SellerId[0] ) || ( Z1CategoryId != BC00042_A1CategoryId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z9ProductCountryId != BC00042_A9ProductCountryId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Product"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert045( )
      {
         BeforeValidate045( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable045( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM045( 0) ;
            CheckOptimisticConcurrency045( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm045( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert045( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000411 */
                     pr_default.execute(9, new Object[] {A8ProductName, A21ProductDescription, A22ProductPrice, A23ProductPhoto, A40000ProductPhoto_GXI, A5SellerId, A1CategoryId, A9ProductCountryId});
                     A7ProductId = BC000411_A7ProductId[0];
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("Product");
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
               Load045( ) ;
            }
            EndLevel045( ) ;
         }
         CloseExtendedTableCursors045( ) ;
      }

      protected void Update045( )
      {
         BeforeValidate045( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable045( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency045( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm045( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate045( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000412 */
                     pr_default.execute(10, new Object[] {A8ProductName, A21ProductDescription, A22ProductPrice, A5SellerId, A1CategoryId, A9ProductCountryId, A7ProductId});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("Product");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Product"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate045( ) ;
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
            EndLevel045( ) ;
         }
         CloseExtendedTableCursors045( ) ;
      }

      protected void DeferredUpdate045( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000413 */
            pr_default.execute(11, new Object[] {A23ProductPhoto, A40000ProductPhoto_GXI, A7ProductId});
            pr_default.close(11);
            dsDefault.SmartCacheProvider.SetUpdated("Product");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate045( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency045( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls045( ) ;
            AfterConfirm045( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete045( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000414 */
                  pr_default.execute(12, new Object[] {A7ProductId});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("Product");
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
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel045( ) ;
         Gx_mode = sMode5;
      }

      protected void OnDeleteControls045( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000415 */
            pr_default.execute(13, new Object[] {A9ProductCountryId});
            A33ProductCountryName = BC000415_A33ProductCountryName[0];
            pr_default.close(13);
            /* Using cursor BC000416 */
            pr_default.execute(14, new Object[] {A5SellerId});
            A13SellerName = BC000416_A13SellerName[0];
            A40001SellerPhoto_GXI = BC000416_A40001SellerPhoto_GXI[0];
            A3CountryId = BC000416_A3CountryId[0];
            A14SellerPhoto = BC000416_A14SellerPhoto[0];
            pr_default.close(14);
            /* Using cursor BC000417 */
            pr_default.execute(15, new Object[] {A3CountryId});
            A4CountryName = BC000417_A4CountryName[0];
            pr_default.close(15);
            /* Using cursor BC000418 */
            pr_default.execute(16, new Object[] {A1CategoryId});
            A2CategoryName = BC000418_A2CategoryName[0];
            pr_default.close(16);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000419 */
            pr_default.execute(17, new Object[] {A7ProductId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Product"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor BC000420 */
            pr_default.execute(18, new Object[] {A7ProductId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Product"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
         }
      }

      protected void EndLevel045( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete045( ) ;
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

      public void ScanKeyStart045( )
      {
         /* Using cursor BC000421 */
         pr_default.execute(19, new Object[] {A7ProductId});
         RcdFound5 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound5 = 1;
            A7ProductId = BC000421_A7ProductId[0];
            A8ProductName = BC000421_A8ProductName[0];
            A21ProductDescription = BC000421_A21ProductDescription[0];
            A22ProductPrice = BC000421_A22ProductPrice[0];
            A40000ProductPhoto_GXI = BC000421_A40000ProductPhoto_GXI[0];
            A33ProductCountryName = BC000421_A33ProductCountryName[0];
            A13SellerName = BC000421_A13SellerName[0];
            A40001SellerPhoto_GXI = BC000421_A40001SellerPhoto_GXI[0];
            A2CategoryName = BC000421_A2CategoryName[0];
            A4CountryName = BC000421_A4CountryName[0];
            A5SellerId = BC000421_A5SellerId[0];
            A1CategoryId = BC000421_A1CategoryId[0];
            A9ProductCountryId = BC000421_A9ProductCountryId[0];
            A3CountryId = BC000421_A3CountryId[0];
            A23ProductPhoto = BC000421_A23ProductPhoto[0];
            A14SellerPhoto = BC000421_A14SellerPhoto[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext045( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound5 = 0;
         ScanKeyLoad045( ) ;
      }

      protected void ScanKeyLoad045( )
      {
         sMode5 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound5 = 1;
            A7ProductId = BC000421_A7ProductId[0];
            A8ProductName = BC000421_A8ProductName[0];
            A21ProductDescription = BC000421_A21ProductDescription[0];
            A22ProductPrice = BC000421_A22ProductPrice[0];
            A40000ProductPhoto_GXI = BC000421_A40000ProductPhoto_GXI[0];
            A33ProductCountryName = BC000421_A33ProductCountryName[0];
            A13SellerName = BC000421_A13SellerName[0];
            A40001SellerPhoto_GXI = BC000421_A40001SellerPhoto_GXI[0];
            A2CategoryName = BC000421_A2CategoryName[0];
            A4CountryName = BC000421_A4CountryName[0];
            A5SellerId = BC000421_A5SellerId[0];
            A1CategoryId = BC000421_A1CategoryId[0];
            A9ProductCountryId = BC000421_A9ProductCountryId[0];
            A3CountryId = BC000421_A3CountryId[0];
            A23ProductPhoto = BC000421_A23ProductPhoto[0];
            A14SellerPhoto = BC000421_A14SellerPhoto[0];
         }
         Gx_mode = sMode5;
      }

      protected void ScanKeyEnd045( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm045( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert045( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate045( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete045( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete045( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate045( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes045( )
      {
      }

      protected void send_integrity_lvl_hashes045( )
      {
      }

      protected void AddRow045( )
      {
         VarsToRow5( bcProduct) ;
      }

      protected void ReadRow045( )
      {
         RowToVars5( bcProduct, 1) ;
      }

      protected void InitializeNonKey045( )
      {
         A8ProductName = "";
         A21ProductDescription = "";
         A22ProductPrice = 0;
         A23ProductPhoto = "";
         A40000ProductPhoto_GXI = "";
         A9ProductCountryId = 0;
         A33ProductCountryName = "";
         A5SellerId = 0;
         A13SellerName = "";
         A14SellerPhoto = "";
         A40001SellerPhoto_GXI = "";
         A1CategoryId = 0;
         A2CategoryName = "";
         A3CountryId = 0;
         A4CountryName = "";
         Z8ProductName = "";
         Z21ProductDescription = "";
         Z22ProductPrice = 0;
         Z5SellerId = 0;
         Z1CategoryId = 0;
         Z9ProductCountryId = 0;
      }

      protected void InitAll045( )
      {
         A7ProductId = 0;
         InitializeNonKey045( ) ;
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

      public void VarsToRow5( SdtProduct obj5 )
      {
         obj5.gxTpr_Mode = Gx_mode;
         obj5.gxTpr_Productname = A8ProductName;
         obj5.gxTpr_Productdescription = A21ProductDescription;
         obj5.gxTpr_Productprice = A22ProductPrice;
         obj5.gxTpr_Productphoto = A23ProductPhoto;
         obj5.gxTpr_Productphoto_gxi = A40000ProductPhoto_GXI;
         obj5.gxTpr_Productcountryid = A9ProductCountryId;
         obj5.gxTpr_Productcountryname = A33ProductCountryName;
         obj5.gxTpr_Sellerid = A5SellerId;
         obj5.gxTpr_Sellername = A13SellerName;
         obj5.gxTpr_Sellerphoto = A14SellerPhoto;
         obj5.gxTpr_Sellerphoto_gxi = A40001SellerPhoto_GXI;
         obj5.gxTpr_Categoryid = A1CategoryId;
         obj5.gxTpr_Categoryname = A2CategoryName;
         obj5.gxTpr_Countryid = A3CountryId;
         obj5.gxTpr_Countryname = A4CountryName;
         obj5.gxTpr_Productid = A7ProductId;
         obj5.gxTpr_Productid_Z = Z7ProductId;
         obj5.gxTpr_Productname_Z = Z8ProductName;
         obj5.gxTpr_Productdescription_Z = Z21ProductDescription;
         obj5.gxTpr_Productprice_Z = Z22ProductPrice;
         obj5.gxTpr_Productcountryid_Z = Z9ProductCountryId;
         obj5.gxTpr_Productcountryname_Z = Z33ProductCountryName;
         obj5.gxTpr_Sellerid_Z = Z5SellerId;
         obj5.gxTpr_Sellername_Z = Z13SellerName;
         obj5.gxTpr_Categoryid_Z = Z1CategoryId;
         obj5.gxTpr_Categoryname_Z = Z2CategoryName;
         obj5.gxTpr_Countryid_Z = Z3CountryId;
         obj5.gxTpr_Countryname_Z = Z4CountryName;
         obj5.gxTpr_Productphoto_gxi_Z = Z40000ProductPhoto_GXI;
         obj5.gxTpr_Sellerphoto_gxi_Z = Z40001SellerPhoto_GXI;
         obj5.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow5( SdtProduct obj5 )
      {
         obj5.gxTpr_Productid = A7ProductId;
         return  ;
      }

      public void RowToVars5( SdtProduct obj5 ,
                              int forceLoad )
      {
         Gx_mode = obj5.gxTpr_Mode;
         A8ProductName = obj5.gxTpr_Productname;
         A21ProductDescription = obj5.gxTpr_Productdescription;
         A22ProductPrice = obj5.gxTpr_Productprice;
         A23ProductPhoto = obj5.gxTpr_Productphoto;
         A40000ProductPhoto_GXI = obj5.gxTpr_Productphoto_gxi;
         A9ProductCountryId = obj5.gxTpr_Productcountryid;
         A33ProductCountryName = obj5.gxTpr_Productcountryname;
         A5SellerId = obj5.gxTpr_Sellerid;
         A13SellerName = obj5.gxTpr_Sellername;
         A14SellerPhoto = obj5.gxTpr_Sellerphoto;
         A40001SellerPhoto_GXI = obj5.gxTpr_Sellerphoto_gxi;
         A1CategoryId = obj5.gxTpr_Categoryid;
         A2CategoryName = obj5.gxTpr_Categoryname;
         A3CountryId = obj5.gxTpr_Countryid;
         A4CountryName = obj5.gxTpr_Countryname;
         A7ProductId = obj5.gxTpr_Productid;
         Z7ProductId = obj5.gxTpr_Productid_Z;
         Z8ProductName = obj5.gxTpr_Productname_Z;
         Z21ProductDescription = obj5.gxTpr_Productdescription_Z;
         Z22ProductPrice = obj5.gxTpr_Productprice_Z;
         Z9ProductCountryId = obj5.gxTpr_Productcountryid_Z;
         Z33ProductCountryName = obj5.gxTpr_Productcountryname_Z;
         Z5SellerId = obj5.gxTpr_Sellerid_Z;
         Z13SellerName = obj5.gxTpr_Sellername_Z;
         Z1CategoryId = obj5.gxTpr_Categoryid_Z;
         Z2CategoryName = obj5.gxTpr_Categoryname_Z;
         Z3CountryId = obj5.gxTpr_Countryid_Z;
         Z4CountryName = obj5.gxTpr_Countryname_Z;
         Z40000ProductPhoto_GXI = obj5.gxTpr_Productphoto_gxi_Z;
         Z40001SellerPhoto_GXI = obj5.gxTpr_Sellerphoto_gxi_Z;
         Gx_mode = obj5.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A7ProductId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey045( ) ;
         ScanKeyStart045( ) ;
         if ( RcdFound5 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z7ProductId = A7ProductId;
         }
         ZM045( -3) ;
         OnLoadActions045( ) ;
         AddRow045( ) ;
         ScanKeyEnd045( ) ;
         if ( RcdFound5 == 0 )
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
         RowToVars5( bcProduct, 0) ;
         ScanKeyStart045( ) ;
         if ( RcdFound5 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z7ProductId = A7ProductId;
         }
         ZM045( -3) ;
         OnLoadActions045( ) ;
         AddRow045( ) ;
         ScanKeyEnd045( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey045( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert045( ) ;
         }
         else
         {
            if ( RcdFound5 == 1 )
            {
               if ( A7ProductId != Z7ProductId )
               {
                  A7ProductId = Z7ProductId;
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
                  Update045( ) ;
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
                  if ( A7ProductId != Z7ProductId )
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
                        Insert045( ) ;
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
                        Insert045( ) ;
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
         RowToVars5( bcProduct, 1) ;
         SaveImpl( ) ;
         VarsToRow5( bcProduct) ;
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
         RowToVars5( bcProduct, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert045( ) ;
         AfterTrn( ) ;
         VarsToRow5( bcProduct) ;
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
            SdtProduct auxBC = new SdtProduct(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A7ProductId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcProduct);
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
         RowToVars5( bcProduct, 1) ;
         UpdateImpl( ) ;
         VarsToRow5( bcProduct) ;
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
         RowToVars5( bcProduct, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert045( ) ;
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
         VarsToRow5( bcProduct) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars5( bcProduct, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey045( ) ;
         if ( RcdFound5 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A7ProductId != Z7ProductId )
            {
               A7ProductId = Z7ProductId;
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
            if ( A7ProductId != Z7ProductId )
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
         pr_default.close(14);
         pr_default.close(16);
         pr_default.close(13);
         pr_default.close(15);
         context.RollbackDataStores("product_bc",pr_default);
         VarsToRow5( bcProduct) ;
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
         Gx_mode = bcProduct.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcProduct.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcProduct )
         {
            bcProduct = (SdtProduct)(sdt);
            if ( StringUtil.StrCmp(bcProduct.gxTpr_Mode, "") == 0 )
            {
               bcProduct.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow5( bcProduct) ;
            }
            else
            {
               RowToVars5( bcProduct, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcProduct.gxTpr_Mode, "") == 0 )
            {
               bcProduct.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars5( bcProduct, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtProduct Product_BC
      {
         get {
            return bcProduct ;
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
         pr_default.close(14);
         pr_default.close(16);
         pr_default.close(13);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z8ProductName = "";
         A8ProductName = "";
         Z21ProductDescription = "";
         A21ProductDescription = "";
         Z13SellerName = "";
         A13SellerName = "";
         Z2CategoryName = "";
         A2CategoryName = "";
         Z33ProductCountryName = "";
         A33ProductCountryName = "";
         Z4CountryName = "";
         A4CountryName = "";
         Z23ProductPhoto = "";
         A23ProductPhoto = "";
         Z40000ProductPhoto_GXI = "";
         A40000ProductPhoto_GXI = "";
         Z14SellerPhoto = "";
         A14SellerPhoto = "";
         Z40001SellerPhoto_GXI = "";
         A40001SellerPhoto_GXI = "";
         BC00048_A7ProductId = new short[1] ;
         BC00048_A8ProductName = new string[] {""} ;
         BC00048_A21ProductDescription = new string[] {""} ;
         BC00048_A22ProductPrice = new decimal[1] ;
         BC00048_A40000ProductPhoto_GXI = new string[] {""} ;
         BC00048_A33ProductCountryName = new string[] {""} ;
         BC00048_A13SellerName = new string[] {""} ;
         BC00048_A40001SellerPhoto_GXI = new string[] {""} ;
         BC00048_A2CategoryName = new string[] {""} ;
         BC00048_A4CountryName = new string[] {""} ;
         BC00048_A5SellerId = new short[1] ;
         BC00048_A1CategoryId = new short[1] ;
         BC00048_A9ProductCountryId = new short[1] ;
         BC00048_A3CountryId = new short[1] ;
         BC00048_A23ProductPhoto = new string[] {""} ;
         BC00048_A14SellerPhoto = new string[] {""} ;
         BC00049_A8ProductName = new string[] {""} ;
         BC00046_A33ProductCountryName = new string[] {""} ;
         BC00044_A13SellerName = new string[] {""} ;
         BC00044_A40001SellerPhoto_GXI = new string[] {""} ;
         BC00044_A3CountryId = new short[1] ;
         BC00044_A14SellerPhoto = new string[] {""} ;
         BC00047_A4CountryName = new string[] {""} ;
         BC00045_A2CategoryName = new string[] {""} ;
         BC000410_A7ProductId = new short[1] ;
         BC00043_A7ProductId = new short[1] ;
         BC00043_A8ProductName = new string[] {""} ;
         BC00043_A21ProductDescription = new string[] {""} ;
         BC00043_A22ProductPrice = new decimal[1] ;
         BC00043_A40000ProductPhoto_GXI = new string[] {""} ;
         BC00043_A5SellerId = new short[1] ;
         BC00043_A1CategoryId = new short[1] ;
         BC00043_A9ProductCountryId = new short[1] ;
         BC00043_A23ProductPhoto = new string[] {""} ;
         sMode5 = "";
         BC00042_A7ProductId = new short[1] ;
         BC00042_A8ProductName = new string[] {""} ;
         BC00042_A21ProductDescription = new string[] {""} ;
         BC00042_A22ProductPrice = new decimal[1] ;
         BC00042_A40000ProductPhoto_GXI = new string[] {""} ;
         BC00042_A5SellerId = new short[1] ;
         BC00042_A1CategoryId = new short[1] ;
         BC00042_A9ProductCountryId = new short[1] ;
         BC00042_A23ProductPhoto = new string[] {""} ;
         BC000411_A7ProductId = new short[1] ;
         BC000415_A33ProductCountryName = new string[] {""} ;
         BC000416_A13SellerName = new string[] {""} ;
         BC000416_A40001SellerPhoto_GXI = new string[] {""} ;
         BC000416_A3CountryId = new short[1] ;
         BC000416_A14SellerPhoto = new string[] {""} ;
         BC000417_A4CountryName = new string[] {""} ;
         BC000418_A2CategoryName = new string[] {""} ;
         BC000419_A11ShoppingCartId = new short[1] ;
         BC000419_A7ProductId = new short[1] ;
         BC000420_A10PromotionId = new short[1] ;
         BC000420_A7ProductId = new short[1] ;
         BC000421_A7ProductId = new short[1] ;
         BC000421_A8ProductName = new string[] {""} ;
         BC000421_A21ProductDescription = new string[] {""} ;
         BC000421_A22ProductPrice = new decimal[1] ;
         BC000421_A40000ProductPhoto_GXI = new string[] {""} ;
         BC000421_A33ProductCountryName = new string[] {""} ;
         BC000421_A13SellerName = new string[] {""} ;
         BC000421_A40001SellerPhoto_GXI = new string[] {""} ;
         BC000421_A2CategoryName = new string[] {""} ;
         BC000421_A4CountryName = new string[] {""} ;
         BC000421_A5SellerId = new short[1] ;
         BC000421_A1CategoryId = new short[1] ;
         BC000421_A9ProductCountryId = new short[1] ;
         BC000421_A3CountryId = new short[1] ;
         BC000421_A23ProductPhoto = new string[] {""} ;
         BC000421_A14SellerPhoto = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.product_bc__default(),
            new Object[][] {
                new Object[] {
               BC00042_A7ProductId, BC00042_A8ProductName, BC00042_A21ProductDescription, BC00042_A22ProductPrice, BC00042_A40000ProductPhoto_GXI, BC00042_A5SellerId, BC00042_A1CategoryId, BC00042_A9ProductCountryId, BC00042_A23ProductPhoto
               }
               , new Object[] {
               BC00043_A7ProductId, BC00043_A8ProductName, BC00043_A21ProductDescription, BC00043_A22ProductPrice, BC00043_A40000ProductPhoto_GXI, BC00043_A5SellerId, BC00043_A1CategoryId, BC00043_A9ProductCountryId, BC00043_A23ProductPhoto
               }
               , new Object[] {
               BC00044_A13SellerName, BC00044_A40001SellerPhoto_GXI, BC00044_A3CountryId, BC00044_A14SellerPhoto
               }
               , new Object[] {
               BC00045_A2CategoryName
               }
               , new Object[] {
               BC00046_A33ProductCountryName
               }
               , new Object[] {
               BC00047_A4CountryName
               }
               , new Object[] {
               BC00048_A7ProductId, BC00048_A8ProductName, BC00048_A21ProductDescription, BC00048_A22ProductPrice, BC00048_A40000ProductPhoto_GXI, BC00048_A33ProductCountryName, BC00048_A13SellerName, BC00048_A40001SellerPhoto_GXI, BC00048_A2CategoryName, BC00048_A4CountryName,
               BC00048_A5SellerId, BC00048_A1CategoryId, BC00048_A9ProductCountryId, BC00048_A3CountryId, BC00048_A23ProductPhoto, BC00048_A14SellerPhoto
               }
               , new Object[] {
               BC00049_A8ProductName
               }
               , new Object[] {
               BC000410_A7ProductId
               }
               , new Object[] {
               BC000411_A7ProductId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000415_A33ProductCountryName
               }
               , new Object[] {
               BC000416_A13SellerName, BC000416_A40001SellerPhoto_GXI, BC000416_A3CountryId, BC000416_A14SellerPhoto
               }
               , new Object[] {
               BC000417_A4CountryName
               }
               , new Object[] {
               BC000418_A2CategoryName
               }
               , new Object[] {
               BC000419_A11ShoppingCartId, BC000419_A7ProductId
               }
               , new Object[] {
               BC000420_A10PromotionId, BC000420_A7ProductId
               }
               , new Object[] {
               BC000421_A7ProductId, BC000421_A8ProductName, BC000421_A21ProductDescription, BC000421_A22ProductPrice, BC000421_A40000ProductPhoto_GXI, BC000421_A33ProductCountryName, BC000421_A13SellerName, BC000421_A40001SellerPhoto_GXI, BC000421_A2CategoryName, BC000421_A4CountryName,
               BC000421_A5SellerId, BC000421_A1CategoryId, BC000421_A9ProductCountryId, BC000421_A3CountryId, BC000421_A23ProductPhoto, BC000421_A14SellerPhoto
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
      private short Z7ProductId ;
      private short A7ProductId ;
      private short GX_JID ;
      private short Z5SellerId ;
      private short A5SellerId ;
      private short Z1CategoryId ;
      private short A1CategoryId ;
      private short Z9ProductCountryId ;
      private short A9ProductCountryId ;
      private short Z3CountryId ;
      private short A3CountryId ;
      private short RcdFound5 ;
      private short nIsDirty_5 ;
      private int trnEnded ;
      private decimal Z22ProductPrice ;
      private decimal A22ProductPrice ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z8ProductName ;
      private string A8ProductName ;
      private string Z21ProductDescription ;
      private string A21ProductDescription ;
      private string Z13SellerName ;
      private string A13SellerName ;
      private string Z2CategoryName ;
      private string A2CategoryName ;
      private string Z33ProductCountryName ;
      private string A33ProductCountryName ;
      private string Z4CountryName ;
      private string A4CountryName ;
      private string sMode5 ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z40000ProductPhoto_GXI ;
      private string A40000ProductPhoto_GXI ;
      private string Z40001SellerPhoto_GXI ;
      private string A40001SellerPhoto_GXI ;
      private string Z23ProductPhoto ;
      private string A23ProductPhoto ;
      private string Z14SellerPhoto ;
      private string A14SellerPhoto ;
      private SdtProduct bcProduct ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00048_A7ProductId ;
      private string[] BC00048_A8ProductName ;
      private string[] BC00048_A21ProductDescription ;
      private decimal[] BC00048_A22ProductPrice ;
      private string[] BC00048_A40000ProductPhoto_GXI ;
      private string[] BC00048_A33ProductCountryName ;
      private string[] BC00048_A13SellerName ;
      private string[] BC00048_A40001SellerPhoto_GXI ;
      private string[] BC00048_A2CategoryName ;
      private string[] BC00048_A4CountryName ;
      private short[] BC00048_A5SellerId ;
      private short[] BC00048_A1CategoryId ;
      private short[] BC00048_A9ProductCountryId ;
      private short[] BC00048_A3CountryId ;
      private string[] BC00048_A23ProductPhoto ;
      private string[] BC00048_A14SellerPhoto ;
      private string[] BC00049_A8ProductName ;
      private string[] BC00046_A33ProductCountryName ;
      private string[] BC00044_A13SellerName ;
      private string[] BC00044_A40001SellerPhoto_GXI ;
      private short[] BC00044_A3CountryId ;
      private string[] BC00044_A14SellerPhoto ;
      private string[] BC00047_A4CountryName ;
      private string[] BC00045_A2CategoryName ;
      private short[] BC000410_A7ProductId ;
      private short[] BC00043_A7ProductId ;
      private string[] BC00043_A8ProductName ;
      private string[] BC00043_A21ProductDescription ;
      private decimal[] BC00043_A22ProductPrice ;
      private string[] BC00043_A40000ProductPhoto_GXI ;
      private short[] BC00043_A5SellerId ;
      private short[] BC00043_A1CategoryId ;
      private short[] BC00043_A9ProductCountryId ;
      private string[] BC00043_A23ProductPhoto ;
      private short[] BC00042_A7ProductId ;
      private string[] BC00042_A8ProductName ;
      private string[] BC00042_A21ProductDescription ;
      private decimal[] BC00042_A22ProductPrice ;
      private string[] BC00042_A40000ProductPhoto_GXI ;
      private short[] BC00042_A5SellerId ;
      private short[] BC00042_A1CategoryId ;
      private short[] BC00042_A9ProductCountryId ;
      private string[] BC00042_A23ProductPhoto ;
      private short[] BC000411_A7ProductId ;
      private string[] BC000415_A33ProductCountryName ;
      private string[] BC000416_A13SellerName ;
      private string[] BC000416_A40001SellerPhoto_GXI ;
      private short[] BC000416_A3CountryId ;
      private string[] BC000416_A14SellerPhoto ;
      private string[] BC000417_A4CountryName ;
      private string[] BC000418_A2CategoryName ;
      private short[] BC000419_A11ShoppingCartId ;
      private short[] BC000419_A7ProductId ;
      private short[] BC000420_A10PromotionId ;
      private short[] BC000420_A7ProductId ;
      private short[] BC000421_A7ProductId ;
      private string[] BC000421_A8ProductName ;
      private string[] BC000421_A21ProductDescription ;
      private decimal[] BC000421_A22ProductPrice ;
      private string[] BC000421_A40000ProductPhoto_GXI ;
      private string[] BC000421_A33ProductCountryName ;
      private string[] BC000421_A13SellerName ;
      private string[] BC000421_A40001SellerPhoto_GXI ;
      private string[] BC000421_A2CategoryName ;
      private string[] BC000421_A4CountryName ;
      private short[] BC000421_A5SellerId ;
      private short[] BC000421_A1CategoryId ;
      private short[] BC000421_A9ProductCountryId ;
      private short[] BC000421_A3CountryId ;
      private string[] BC000421_A23ProductPhoto ;
      private string[] BC000421_A14SellerPhoto ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class product_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00048;
          prmBC00048 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC00049;
          prmBC00049 = new Object[] {
          new ParDef("@ProductName",GXType.NChar,20,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC00046;
          prmBC00046 = new Object[] {
          new ParDef("@ProductCountryId",GXType.Int16,4,0)
          };
          Object[] prmBC00044;
          prmBC00044 = new Object[] {
          new ParDef("@SellerId",GXType.Int16,4,0)
          };
          Object[] prmBC00047;
          prmBC00047 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC00045;
          prmBC00045 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmBC000410;
          prmBC000410 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC00043;
          prmBC00043 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC00042;
          prmBC00042 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000411;
          prmBC000411 = new Object[] {
          new ParDef("@ProductName",GXType.NChar,20,0) ,
          new ParDef("@ProductDescription",GXType.NChar,50,0) ,
          new ParDef("@ProductPrice",GXType.Decimal,10,2) ,
          new ParDef("@ProductPhoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@ProductPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=3, Tbl="Product", Fld="ProductPhoto"} ,
          new ParDef("@SellerId",GXType.Int16,4,0) ,
          new ParDef("@CategoryId",GXType.Int16,4,0) ,
          new ParDef("@ProductCountryId",GXType.Int16,4,0)
          };
          Object[] prmBC000412;
          prmBC000412 = new Object[] {
          new ParDef("@ProductName",GXType.NChar,20,0) ,
          new ParDef("@ProductDescription",GXType.NChar,50,0) ,
          new ParDef("@ProductPrice",GXType.Decimal,10,2) ,
          new ParDef("@SellerId",GXType.Int16,4,0) ,
          new ParDef("@CategoryId",GXType.Int16,4,0) ,
          new ParDef("@ProductCountryId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000413;
          prmBC000413 = new Object[] {
          new ParDef("@ProductPhoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@ProductPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Product", Fld="ProductPhoto"} ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000414;
          prmBC000414 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000415;
          prmBC000415 = new Object[] {
          new ParDef("@ProductCountryId",GXType.Int16,4,0)
          };
          Object[] prmBC000416;
          prmBC000416 = new Object[] {
          new ParDef("@SellerId",GXType.Int16,4,0)
          };
          Object[] prmBC000417;
          prmBC000417 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC000418;
          prmBC000418 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmBC000419;
          prmBC000419 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000420;
          prmBC000420 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000421;
          prmBC000421 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00042", "SELECT [ProductId], [ProductName], [ProductDescription], [ProductPrice], [ProductPhoto_GXI], [SellerId], [CategoryId], [ProductCountryId] AS ProductCountryId, [ProductPhoto] FROM [Product] WITH (UPDLOCK) WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00042,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00043", "SELECT [ProductId], [ProductName], [ProductDescription], [ProductPrice], [ProductPhoto_GXI], [SellerId], [CategoryId], [ProductCountryId] AS ProductCountryId, [ProductPhoto] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00043,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00044", "SELECT [SellerName], [SellerPhoto_GXI], [CountryId], [SellerPhoto] FROM [Seller] WHERE [SellerId] = @SellerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00044,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00045", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00045,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00046", "SELECT [CountryName] AS ProductCountryName FROM [Country] WHERE [CountryId] = @ProductCountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00046,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00047", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00047,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00048", "SELECT TM1.[ProductId], TM1.[ProductName], TM1.[ProductDescription], TM1.[ProductPrice], TM1.[ProductPhoto_GXI], T2.[CountryName] AS ProductCountryName, T3.[SellerName], T3.[SellerPhoto_GXI], T5.[CategoryName], T4.[CountryName], TM1.[SellerId], TM1.[CategoryId], TM1.[ProductCountryId] AS ProductCountryId, T3.[CountryId], TM1.[ProductPhoto], T3.[SellerPhoto] FROM (((([Product] TM1 INNER JOIN [Country] T2 ON T2.[CountryId] = TM1.[ProductCountryId]) INNER JOIN [Seller] T3 ON T3.[SellerId] = TM1.[SellerId]) INNER JOIN [Country] T4 ON T4.[CountryId] = T3.[CountryId]) INNER JOIN [Category] T5 ON T5.[CategoryId] = TM1.[CategoryId]) WHERE TM1.[ProductId] = @ProductId ORDER BY TM1.[ProductId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00048,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00049", "SELECT [ProductName] FROM [Product] WHERE ([ProductName] = @ProductName) AND (Not ( [ProductId] = @ProductId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00049,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000410", "SELECT [ProductId] FROM [Product] WHERE [ProductId] = @ProductId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000410,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000411", "INSERT INTO [Product]([ProductName], [ProductDescription], [ProductPrice], [ProductPhoto], [ProductPhoto_GXI], [SellerId], [CategoryId], [ProductCountryId]) VALUES(@ProductName, @ProductDescription, @ProductPrice, @ProductPhoto, @ProductPhoto_GXI, @SellerId, @CategoryId, @ProductCountryId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000411,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000412", "UPDATE [Product] SET [ProductName]=@ProductName, [ProductDescription]=@ProductDescription, [ProductPrice]=@ProductPrice, [SellerId]=@SellerId, [CategoryId]=@CategoryId, [ProductCountryId]=@ProductCountryId  WHERE [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmBC000412)
             ,new CursorDef("BC000413", "UPDATE [Product] SET [ProductPhoto]=@ProductPhoto, [ProductPhoto_GXI]=@ProductPhoto_GXI  WHERE [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmBC000413)
             ,new CursorDef("BC000414", "DELETE FROM [Product]  WHERE [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmBC000414)
             ,new CursorDef("BC000415", "SELECT [CountryName] AS ProductCountryName FROM [Country] WHERE [CountryId] = @ProductCountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000415,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000416", "SELECT [SellerName], [SellerPhoto_GXI], [CountryId], [SellerPhoto] FROM [Seller] WHERE [SellerId] = @SellerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000416,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000417", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000417,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000418", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000418,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000419", "SELECT TOP 1 [ShoppingCartId], [ProductId] FROM [ShoppingCartProduct] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000419,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000420", "SELECT TOP 1 [PromotionId], [ProductId] FROM [PromotionProduct] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000420,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000421", "SELECT TM1.[ProductId], TM1.[ProductName], TM1.[ProductDescription], TM1.[ProductPrice], TM1.[ProductPhoto_GXI], T2.[CountryName] AS ProductCountryName, T3.[SellerName], T3.[SellerPhoto_GXI], T5.[CategoryName], T4.[CountryName], TM1.[SellerId], TM1.[CategoryId], TM1.[ProductCountryId] AS ProductCountryId, T3.[CountryId], TM1.[ProductPhoto], T3.[SellerPhoto] FROM (((([Product] TM1 INNER JOIN [Country] T2 ON T2.[CountryId] = TM1.[ProductCountryId]) INNER JOIN [Seller] T3 ON T3.[SellerId] = TM1.[SellerId]) INNER JOIN [Country] T4 ON T4.[CountryId] = T3.[CountryId]) INNER JOIN [Category] T5 ON T5.[CategoryId] = TM1.[CategoryId]) WHERE TM1.[ProductId] = @ProductId ORDER BY TM1.[ProductId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000421,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(5));
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(5));
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(2));
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getMultimediaUri(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((short[]) buf[12])[0] = rslt.getShort(13);
                ((short[]) buf[13])[0] = rslt.getShort(14);
                ((string[]) buf[14])[0] = rslt.getMultimediaFile(15, rslt.getVarchar(5));
                ((string[]) buf[15])[0] = rslt.getMultimediaFile(16, rslt.getVarchar(8));
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(2));
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getMultimediaUri(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((short[]) buf[12])[0] = rslt.getShort(13);
                ((short[]) buf[13])[0] = rslt.getShort(14);
                ((string[]) buf[14])[0] = rslt.getMultimediaFile(15, rslt.getVarchar(5));
                ((string[]) buf[15])[0] = rslt.getMultimediaFile(16, rslt.getVarchar(8));
                return;
       }
    }

 }

}
