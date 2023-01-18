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
   public class shoppingcart_bc : GXHttpHandler, IGxSilentTrn
   {
      public shoppingcart_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public shoppingcart_bc( IGxContext context )
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
         ReadRow058( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey058( ) ;
         standaloneModal( ) ;
         AddRow058( ) ;
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
            /* Execute user event: After Trn */
            E11052 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z11ShoppingCartId = A11ShoppingCartId;
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

      protected void CONFIRM_050( )
      {
         BeforeValidate058( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls058( ) ;
            }
            else
            {
               CheckExtendedTable058( ) ;
               if ( AnyError == 0 )
               {
                  ZM058( 8) ;
                  ZM058( 9) ;
                  ZM058( 10) ;
               }
               CloseExtendedTableCursors058( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode8 = Gx_mode;
            CONFIRM_059( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode8;
               IsConfirmed = 1;
            }
            /* Restore parent mode. */
            Gx_mode = sMode8;
         }
      }

      protected void CONFIRM_059( )
      {
         s29ShoppingCartFinalPrice = O29ShoppingCartFinalPrice;
         n29ShoppingCartFinalPrice = false;
         nGXsfl_9_idx = 0;
         while ( nGXsfl_9_idx < bcShoppingCart.gxTpr_Product.Count )
         {
            ReadRow059( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound9 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_9 != 0 ) )
            {
               GetKey059( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound9 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate059( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable059( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM059( 12) ;
                           ZM059( 13) ;
                        }
                        CloseExtendedTableCursors059( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                        }
                        O29ShoppingCartFinalPrice = A29ShoppingCartFinalPrice;
                        n29ShoppingCartFinalPrice = false;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound9 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey059( ) ;
                        Load059( ) ;
                        BeforeValidate059( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls059( ) ;
                           O29ShoppingCartFinalPrice = A29ShoppingCartFinalPrice;
                           n29ShoppingCartFinalPrice = false;
                        }
                     }
                     else
                     {
                        if ( nIsMod_9 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate059( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable059( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM059( 12) ;
                                 ZM059( 13) ;
                              }
                              CloseExtendedTableCursors059( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                              }
                              O29ShoppingCartFinalPrice = A29ShoppingCartFinalPrice;
                              n29ShoppingCartFinalPrice = false;
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow9( ((SdtShoppingCart_Product)bcShoppingCart.gxTpr_Product.Item(nGXsfl_9_idx))) ;
            }
         }
         O29ShoppingCartFinalPrice = s29ShoppingCartFinalPrice;
         n29ShoppingCartFinalPrice = false;
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E12052( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11052( )
      {
         /* After Trn Routine */
         returnInSub = false;
         context.PopUp(formatLink("shoppingcartdetail.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A11ShoppingCartId,4,0))}, new string[] {"ShoppingCartId"}) , new Object[] {"A11ShoppingCartId"});
         /*  Sending Event outputs  */
      }

      protected void ZM058( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z28ShoppingCartDate = A28ShoppingCartDate;
            Z6CustomerId = A6CustomerId;
            Z32ShoppingCartDateDelivery = A32ShoppingCartDateDelivery;
            Z29ShoppingCartFinalPrice = A29ShoppingCartFinalPrice;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z15CustomerName = A15CustomerName;
            Z16CustomerAddress = A16CustomerAddress;
            Z18CustomerPhone = A18CustomerPhone;
            Z3CountryId = A3CountryId;
            Z32ShoppingCartDateDelivery = A32ShoppingCartDateDelivery;
            Z29ShoppingCartFinalPrice = A29ShoppingCartFinalPrice;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z4CountryName = A4CountryName;
            Z32ShoppingCartDateDelivery = A32ShoppingCartDateDelivery;
            Z29ShoppingCartFinalPrice = A29ShoppingCartFinalPrice;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z32ShoppingCartDateDelivery = A32ShoppingCartDateDelivery;
            Z29ShoppingCartFinalPrice = A29ShoppingCartFinalPrice;
         }
         if ( GX_JID == -7 )
         {
            Z11ShoppingCartId = A11ShoppingCartId;
            Z28ShoppingCartDate = A28ShoppingCartDate;
            Z6CustomerId = A6CustomerId;
            Z29ShoppingCartFinalPrice = A29ShoppingCartFinalPrice;
            Z15CustomerName = A15CustomerName;
            Z16CustomerAddress = A16CustomerAddress;
            Z18CustomerPhone = A18CustomerPhone;
            Z3CountryId = A3CountryId;
            Z4CountryName = A4CountryName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A28ShoppingCartDate) && ( Gx_BScreen == 0 ) )
         {
            A28ShoppingCartDate = DateTimeUtil.Today( context);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            A32ShoppingCartDateDelivery = DateTimeUtil.DAdd(A28ShoppingCartDate,+((int)(5)));
         }
      }

      protected void Load058( )
      {
         /* Using cursor BC000513 */
         pr_default.execute(9, new Object[] {A11ShoppingCartId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound8 = 1;
            A28ShoppingCartDate = BC000513_A28ShoppingCartDate[0];
            A15CustomerName = BC000513_A15CustomerName[0];
            A4CountryName = BC000513_A4CountryName[0];
            A16CustomerAddress = BC000513_A16CustomerAddress[0];
            A18CustomerPhone = BC000513_A18CustomerPhone[0];
            A6CustomerId = BC000513_A6CustomerId[0];
            A3CountryId = BC000513_A3CountryId[0];
            A29ShoppingCartFinalPrice = BC000513_A29ShoppingCartFinalPrice[0];
            n29ShoppingCartFinalPrice = BC000513_n29ShoppingCartFinalPrice[0];
            ZM058( -7) ;
         }
         pr_default.close(9);
         OnLoadActions058( ) ;
      }

      protected void OnLoadActions058( )
      {
         O29ShoppingCartFinalPrice = A29ShoppingCartFinalPrice;
         n29ShoppingCartFinalPrice = false;
         A32ShoppingCartDateDelivery = DateTimeUtil.DAdd(A28ShoppingCartDate,+((int)(5)));
      }

      protected void CheckExtendedTable058( )
      {
         nIsDirty_8 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000511 */
         pr_default.execute(8, new Object[] {A11ShoppingCartId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A29ShoppingCartFinalPrice = BC000511_A29ShoppingCartFinalPrice[0];
            n29ShoppingCartFinalPrice = BC000511_n29ShoppingCartFinalPrice[0];
         }
         else
         {
            nIsDirty_8 = 1;
            A29ShoppingCartFinalPrice = 0;
            n29ShoppingCartFinalPrice = false;
         }
         pr_default.close(8);
         if ( ! ( (DateTime.MinValue==A28ShoppingCartDate) || ( DateTimeUtil.ResetTime ( A28ShoppingCartDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Shopping Cart Date is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         nIsDirty_8 = 1;
         A32ShoppingCartDateDelivery = DateTimeUtil.DAdd(A28ShoppingCartDate,+((int)(5)));
         /* Using cursor BC00058 */
         pr_default.execute(6, new Object[] {A6CustomerId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No matching 'Customer'.", "ForeignKeyNotFound", 1, "CUSTOMERID");
            AnyError = 1;
         }
         A15CustomerName = BC00058_A15CustomerName[0];
         A16CustomerAddress = BC00058_A16CustomerAddress[0];
         A18CustomerPhone = BC00058_A18CustomerPhone[0];
         A3CountryId = BC00058_A3CountryId[0];
         pr_default.close(6);
         /* Using cursor BC00059 */
         pr_default.execute(7, new Object[] {A3CountryId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No matching 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
         }
         A4CountryName = BC00059_A4CountryName[0];
         pr_default.close(7);
      }

      protected void CloseExtendedTableCursors058( )
      {
         pr_default.close(8);
         pr_default.close(6);
         pr_default.close(7);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey058( )
      {
         /* Using cursor BC000514 */
         pr_default.execute(10, new Object[] {A11ShoppingCartId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(10);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00057 */
         pr_default.execute(5, new Object[] {A11ShoppingCartId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM058( 7) ;
            RcdFound8 = 1;
            A11ShoppingCartId = BC00057_A11ShoppingCartId[0];
            A28ShoppingCartDate = BC00057_A28ShoppingCartDate[0];
            A6CustomerId = BC00057_A6CustomerId[0];
            Z11ShoppingCartId = A11ShoppingCartId;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load058( ) ;
            if ( AnyError == 1 )
            {
               RcdFound8 = 0;
               InitializeNonKey058( ) ;
            }
            Gx_mode = sMode8;
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey058( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode8;
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey058( ) ;
         if ( RcdFound8 == 0 )
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
         CONFIRM_050( ) ;
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

      protected void CheckOptimisticConcurrency058( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00056 */
            pr_default.execute(4, new Object[] {A11ShoppingCartId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ShoppingCart"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) || ( DateTimeUtil.ResetTime ( Z28ShoppingCartDate ) != DateTimeUtil.ResetTime ( BC00056_A28ShoppingCartDate[0] ) ) || ( Z6CustomerId != BC00056_A6CustomerId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ShoppingCart"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert058( )
      {
         BeforeValidate058( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable058( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM058( 0) ;
            CheckOptimisticConcurrency058( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm058( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert058( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000515 */
                     pr_default.execute(11, new Object[] {A28ShoppingCartDate, A6CustomerId});
                     A11ShoppingCartId = BC000515_A11ShoppingCartId[0];
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("ShoppingCart");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel058( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                           }
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
               Load058( ) ;
            }
            EndLevel058( ) ;
         }
         CloseExtendedTableCursors058( ) ;
      }

      protected void Update058( )
      {
         BeforeValidate058( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable058( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency058( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm058( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate058( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000516 */
                     pr_default.execute(12, new Object[] {A28ShoppingCartDate, A6CustomerId, A11ShoppingCartId});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("ShoppingCart");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ShoppingCart"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate058( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel058( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
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
            }
            EndLevel058( ) ;
         }
         CloseExtendedTableCursors058( ) ;
      }

      protected void DeferredUpdate058( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate058( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency058( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls058( ) ;
            AfterConfirm058( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete058( ) ;
               if ( AnyError == 0 )
               {
                  A29ShoppingCartFinalPrice = O29ShoppingCartFinalPrice;
                  n29ShoppingCartFinalPrice = false;
                  ScanKeyStart059( ) ;
                  while ( RcdFound9 != 0 )
                  {
                     getByPrimaryKey059( ) ;
                     Delete059( ) ;
                     ScanKeyNext059( ) ;
                     O29ShoppingCartFinalPrice = A29ShoppingCartFinalPrice;
                     n29ShoppingCartFinalPrice = false;
                  }
                  ScanKeyEnd059( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000517 */
                     pr_default.execute(13, new Object[] {A11ShoppingCartId});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("ShoppingCart");
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
         }
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel058( ) ;
         Gx_mode = sMode8;
      }

      protected void OnDeleteControls058( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000519 */
            pr_default.execute(14, new Object[] {A11ShoppingCartId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               A29ShoppingCartFinalPrice = BC000519_A29ShoppingCartFinalPrice[0];
               n29ShoppingCartFinalPrice = BC000519_n29ShoppingCartFinalPrice[0];
            }
            else
            {
               A29ShoppingCartFinalPrice = 0;
               n29ShoppingCartFinalPrice = false;
            }
            pr_default.close(14);
            A32ShoppingCartDateDelivery = DateTimeUtil.DAdd(A28ShoppingCartDate,+((int)(5)));
            /* Using cursor BC000520 */
            pr_default.execute(15, new Object[] {A6CustomerId});
            A15CustomerName = BC000520_A15CustomerName[0];
            A16CustomerAddress = BC000520_A16CustomerAddress[0];
            A18CustomerPhone = BC000520_A18CustomerPhone[0];
            A3CountryId = BC000520_A3CountryId[0];
            pr_default.close(15);
            /* Using cursor BC000521 */
            pr_default.execute(16, new Object[] {A3CountryId});
            A4CountryName = BC000521_A4CountryName[0];
            pr_default.close(16);
         }
      }

      protected void ProcessNestedLevel059( )
      {
         s29ShoppingCartFinalPrice = O29ShoppingCartFinalPrice;
         n29ShoppingCartFinalPrice = false;
         nGXsfl_9_idx = 0;
         while ( nGXsfl_9_idx < bcShoppingCart.gxTpr_Product.Count )
         {
            ReadRow059( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound9 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_9 != 0 ) )
            {
               standaloneNotModal059( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert059( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete059( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update059( ) ;
                  }
               }
               O29ShoppingCartFinalPrice = A29ShoppingCartFinalPrice;
               n29ShoppingCartFinalPrice = false;
            }
            KeyVarsToRow9( ((SdtShoppingCart_Product)bcShoppingCart.gxTpr_Product.Item(nGXsfl_9_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_9_idx = 0;
            while ( nGXsfl_9_idx < bcShoppingCart.gxTpr_Product.Count )
            {
               ReadRow059( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound9 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcShoppingCart.gxTpr_Product.RemoveElement(nGXsfl_9_idx);
                  nGXsfl_9_idx = (int)(nGXsfl_9_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey059( ) ;
                  VarsToRow9( ((SdtShoppingCart_Product)bcShoppingCart.gxTpr_Product.Item(nGXsfl_9_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll059( ) ;
         if ( AnyError != 0 )
         {
            O29ShoppingCartFinalPrice = s29ShoppingCartFinalPrice;
            n29ShoppingCartFinalPrice = false;
         }
         nRcdExists_9 = 0;
         nIsMod_9 = 0;
         Gxremove9 = 0;
      }

      protected void ProcessLevel058( )
      {
         /* Save parent mode. */
         sMode8 = Gx_mode;
         ProcessNestedLevel059( ) ;
         if ( AnyError != 0 )
         {
            O29ShoppingCartFinalPrice = s29ShoppingCartFinalPrice;
            n29ShoppingCartFinalPrice = false;
         }
         /* Restore parent mode. */
         Gx_mode = sMode8;
         /* ' Update level parameters */
      }

      protected void EndLevel058( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete058( ) ;
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

      public void ScanKeyStart058( )
      {
         /* Scan By routine */
         /* Using cursor BC000523 */
         pr_default.execute(17, new Object[] {A11ShoppingCartId});
         RcdFound8 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound8 = 1;
            A11ShoppingCartId = BC000523_A11ShoppingCartId[0];
            A28ShoppingCartDate = BC000523_A28ShoppingCartDate[0];
            A15CustomerName = BC000523_A15CustomerName[0];
            A4CountryName = BC000523_A4CountryName[0];
            A16CustomerAddress = BC000523_A16CustomerAddress[0];
            A18CustomerPhone = BC000523_A18CustomerPhone[0];
            A6CustomerId = BC000523_A6CustomerId[0];
            A3CountryId = BC000523_A3CountryId[0];
            A29ShoppingCartFinalPrice = BC000523_A29ShoppingCartFinalPrice[0];
            n29ShoppingCartFinalPrice = BC000523_n29ShoppingCartFinalPrice[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext058( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound8 = 0;
         ScanKeyLoad058( ) ;
      }

      protected void ScanKeyLoad058( )
      {
         sMode8 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound8 = 1;
            A11ShoppingCartId = BC000523_A11ShoppingCartId[0];
            A28ShoppingCartDate = BC000523_A28ShoppingCartDate[0];
            A15CustomerName = BC000523_A15CustomerName[0];
            A4CountryName = BC000523_A4CountryName[0];
            A16CustomerAddress = BC000523_A16CustomerAddress[0];
            A18CustomerPhone = BC000523_A18CustomerPhone[0];
            A6CustomerId = BC000523_A6CustomerId[0];
            A3CountryId = BC000523_A3CountryId[0];
            A29ShoppingCartFinalPrice = BC000523_A29ShoppingCartFinalPrice[0];
            n29ShoppingCartFinalPrice = BC000523_n29ShoppingCartFinalPrice[0];
         }
         Gx_mode = sMode8;
      }

      protected void ScanKeyEnd058( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm058( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert058( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate058( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete058( )
      {
         /* Before Delete Rules */
         if ( DateTimeUtil.ResetTime ( A28ShoppingCartDate ) == DateTimeUtil.ResetTime ( DateTimeUtil.Today( context) ) )
         {
            GX_msglist.addItem("You cannot delete today's cart", 1, "");
            AnyError = 1;
         }
      }

      protected void BeforeComplete058( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate058( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes058( )
      {
      }

      protected void ZM059( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z31QtyProduct = A31QtyProduct;
            Z30TotalProduct = A30TotalProduct;
         }
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z8ProductName = A8ProductName;
            Z22ProductPrice = A22ProductPrice;
            Z1CategoryId = A1CategoryId;
            Z30TotalProduct = A30TotalProduct;
         }
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            Z2CategoryName = A2CategoryName;
            Z30TotalProduct = A30TotalProduct;
         }
         if ( GX_JID == -11 )
         {
            Z11ShoppingCartId = A11ShoppingCartId;
            Z31QtyProduct = A31QtyProduct;
            Z7ProductId = A7ProductId;
            Z8ProductName = A8ProductName;
            Z22ProductPrice = A22ProductPrice;
            Z1CategoryId = A1CategoryId;
            Z2CategoryName = A2CategoryName;
         }
      }

      protected void standaloneNotModal059( )
      {
      }

      protected void standaloneModal059( )
      {
      }

      protected void Load059( )
      {
         /* Using cursor BC000524 */
         pr_default.execute(18, new Object[] {A11ShoppingCartId, A7ProductId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound9 = 1;
            A8ProductName = BC000524_A8ProductName[0];
            A22ProductPrice = BC000524_A22ProductPrice[0];
            A31QtyProduct = BC000524_A31QtyProduct[0];
            A2CategoryName = BC000524_A2CategoryName[0];
            A1CategoryId = BC000524_A1CategoryId[0];
            ZM059( -11) ;
         }
         pr_default.close(18);
         OnLoadActions059( ) ;
      }

      protected void OnLoadActions059( )
      {
         if ( StringUtil.StrCmp(A2CategoryName, "Joyería") == 0 )
         {
            A30TotalProduct = (decimal)(A31QtyProduct*A22ProductPrice*(1+5/ (decimal)(100)));
         }
         else
         {
            if ( StringUtil.StrCmp(A2CategoryName, "Entretenimiento") == 0 )
            {
               A30TotalProduct = (decimal)(A31QtyProduct*A22ProductPrice*(1-10/ (decimal)(100)));
            }
            else
            {
               A30TotalProduct = (decimal)(A31QtyProduct*A22ProductPrice);
            }
         }
         O30TotalProduct = A30TotalProduct;
         if ( IsIns( )  )
         {
            A29ShoppingCartFinalPrice = (decimal)(O29ShoppingCartFinalPrice+A30TotalProduct);
            n29ShoppingCartFinalPrice = false;
         }
         else
         {
            if ( IsUpd( )  )
            {
               A29ShoppingCartFinalPrice = (decimal)(O29ShoppingCartFinalPrice+A30TotalProduct-O30TotalProduct);
               n29ShoppingCartFinalPrice = false;
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A29ShoppingCartFinalPrice = (decimal)(O29ShoppingCartFinalPrice-O30TotalProduct);
                  n29ShoppingCartFinalPrice = false;
               }
            }
         }
      }

      protected void CheckExtendedTable059( )
      {
         nIsDirty_9 = 0;
         Gx_BScreen = 1;
         standaloneModal059( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC00054 */
         pr_default.execute(2, new Object[] {A7ProductId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, "PRODUCTID");
            AnyError = 1;
         }
         A8ProductName = BC00054_A8ProductName[0];
         A22ProductPrice = BC00054_A22ProductPrice[0];
         A1CategoryId = BC00054_A1CategoryId[0];
         pr_default.close(2);
         /* Using cursor BC00055 */
         pr_default.execute(3, new Object[] {A1CategoryId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No matching 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
            AnyError = 1;
         }
         A2CategoryName = BC00055_A2CategoryName[0];
         pr_default.close(3);
         if ( StringUtil.StrCmp(A2CategoryName, "Joyería") == 0 )
         {
            nIsDirty_9 = 1;
            A30TotalProduct = (decimal)(A31QtyProduct*A22ProductPrice*(1+5/ (decimal)(100)));
         }
         else
         {
            if ( StringUtil.StrCmp(A2CategoryName, "Entretenimiento") == 0 )
            {
               nIsDirty_9 = 1;
               A30TotalProduct = (decimal)(A31QtyProduct*A22ProductPrice*(1-10/ (decimal)(100)));
            }
            else
            {
               nIsDirty_9 = 1;
               A30TotalProduct = (decimal)(A31QtyProduct*A22ProductPrice);
            }
         }
         if ( IsIns( )  )
         {
            nIsDirty_9 = 1;
            A29ShoppingCartFinalPrice = (decimal)(O29ShoppingCartFinalPrice+A30TotalProduct);
            n29ShoppingCartFinalPrice = false;
         }
         else
         {
            if ( IsUpd( )  )
            {
               nIsDirty_9 = 1;
               A29ShoppingCartFinalPrice = (decimal)(O29ShoppingCartFinalPrice+A30TotalProduct-O30TotalProduct);
               n29ShoppingCartFinalPrice = false;
            }
            else
            {
               if ( IsDlt( )  )
               {
                  nIsDirty_9 = 1;
                  A29ShoppingCartFinalPrice = (decimal)(O29ShoppingCartFinalPrice-O30TotalProduct);
                  n29ShoppingCartFinalPrice = false;
               }
            }
         }
      }

      protected void CloseExtendedTableCursors059( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable059( )
      {
      }

      protected void GetKey059( )
      {
         /* Using cursor BC000525 */
         pr_default.execute(19, new Object[] {A11ShoppingCartId, A7ProductId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(19);
      }

      protected void getByPrimaryKey059( )
      {
         /* Using cursor BC00053 */
         pr_default.execute(1, new Object[] {A11ShoppingCartId, A7ProductId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM059( 11) ;
            RcdFound9 = 1;
            InitializeNonKey059( ) ;
            A31QtyProduct = BC00053_A31QtyProduct[0];
            A7ProductId = BC00053_A7ProductId[0];
            Z11ShoppingCartId = A11ShoppingCartId;
            Z7ProductId = A7ProductId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal059( ) ;
            Load059( ) ;
            Gx_mode = sMode9;
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey059( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal059( ) ;
            Gx_mode = sMode9;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes059( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency059( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00052 */
            pr_default.execute(0, new Object[] {A11ShoppingCartId, A7ProductId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ShoppingCartProduct"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z31QtyProduct != BC00052_A31QtyProduct[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ShoppingCartProduct"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert059( )
      {
         BeforeValidate059( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable059( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM059( 0) ;
            CheckOptimisticConcurrency059( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm059( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert059( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000526 */
                     pr_default.execute(20, new Object[] {A11ShoppingCartId, A31QtyProduct, A7ProductId});
                     pr_default.close(20);
                     dsDefault.SmartCacheProvider.SetUpdated("ShoppingCartProduct");
                     if ( (pr_default.getStatus(20) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
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
               Load059( ) ;
            }
            EndLevel059( ) ;
         }
         CloseExtendedTableCursors059( ) ;
      }

      protected void Update059( )
      {
         BeforeValidate059( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable059( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency059( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm059( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate059( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000527 */
                     pr_default.execute(21, new Object[] {A31QtyProduct, A11ShoppingCartId, A7ProductId});
                     pr_default.close(21);
                     dsDefault.SmartCacheProvider.SetUpdated("ShoppingCartProduct");
                     if ( (pr_default.getStatus(21) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ShoppingCartProduct"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate059( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey059( ) ;
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
            EndLevel059( ) ;
         }
         CloseExtendedTableCursors059( ) ;
      }

      protected void DeferredUpdate059( )
      {
      }

      protected void Delete059( )
      {
         Gx_mode = "DLT";
         BeforeValidate059( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency059( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls059( ) ;
            AfterConfirm059( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete059( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000528 */
                  pr_default.execute(22, new Object[] {A11ShoppingCartId, A7ProductId});
                  pr_default.close(22);
                  dsDefault.SmartCacheProvider.SetUpdated("ShoppingCartProduct");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel059( ) ;
         Gx_mode = sMode9;
      }

      protected void OnDeleteControls059( )
      {
         standaloneModal059( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000529 */
            pr_default.execute(23, new Object[] {A7ProductId});
            A8ProductName = BC000529_A8ProductName[0];
            A22ProductPrice = BC000529_A22ProductPrice[0];
            A1CategoryId = BC000529_A1CategoryId[0];
            pr_default.close(23);
            /* Using cursor BC000530 */
            pr_default.execute(24, new Object[] {A1CategoryId});
            A2CategoryName = BC000530_A2CategoryName[0];
            pr_default.close(24);
            if ( StringUtil.StrCmp(A2CategoryName, "Joyería") == 0 )
            {
               A30TotalProduct = (decimal)(A31QtyProduct*A22ProductPrice*(1+5/ (decimal)(100)));
            }
            else
            {
               if ( StringUtil.StrCmp(A2CategoryName, "Entretenimiento") == 0 )
               {
                  A30TotalProduct = (decimal)(A31QtyProduct*A22ProductPrice*(1-10/ (decimal)(100)));
               }
               else
               {
                  A30TotalProduct = (decimal)(A31QtyProduct*A22ProductPrice);
               }
            }
            if ( IsIns( )  )
            {
               A29ShoppingCartFinalPrice = (decimal)(O29ShoppingCartFinalPrice+A30TotalProduct);
               n29ShoppingCartFinalPrice = false;
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A29ShoppingCartFinalPrice = (decimal)(O29ShoppingCartFinalPrice+A30TotalProduct-O30TotalProduct);
                  n29ShoppingCartFinalPrice = false;
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A29ShoppingCartFinalPrice = (decimal)(O29ShoppingCartFinalPrice-O30TotalProduct);
                     n29ShoppingCartFinalPrice = false;
                  }
               }
            }
         }
      }

      protected void EndLevel059( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart059( )
      {
         /* Scan By routine */
         /* Using cursor BC000531 */
         pr_default.execute(25, new Object[] {A11ShoppingCartId});
         RcdFound9 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound9 = 1;
            A8ProductName = BC000531_A8ProductName[0];
            A22ProductPrice = BC000531_A22ProductPrice[0];
            A31QtyProduct = BC000531_A31QtyProduct[0];
            A2CategoryName = BC000531_A2CategoryName[0];
            A7ProductId = BC000531_A7ProductId[0];
            A1CategoryId = BC000531_A1CategoryId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext059( )
      {
         /* Scan next routine */
         pr_default.readNext(25);
         RcdFound9 = 0;
         ScanKeyLoad059( ) ;
      }

      protected void ScanKeyLoad059( )
      {
         sMode9 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound9 = 1;
            A8ProductName = BC000531_A8ProductName[0];
            A22ProductPrice = BC000531_A22ProductPrice[0];
            A31QtyProduct = BC000531_A31QtyProduct[0];
            A2CategoryName = BC000531_A2CategoryName[0];
            A7ProductId = BC000531_A7ProductId[0];
            A1CategoryId = BC000531_A1CategoryId[0];
         }
         Gx_mode = sMode9;
      }

      protected void ScanKeyEnd059( )
      {
         pr_default.close(25);
      }

      protected void AfterConfirm059( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert059( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate059( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete059( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete059( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate059( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes059( )
      {
      }

      protected void send_integrity_lvl_hashes059( )
      {
      }

      protected void send_integrity_lvl_hashes058( )
      {
      }

      protected void AddRow058( )
      {
         VarsToRow8( bcShoppingCart) ;
      }

      protected void ReadRow058( )
      {
         RowToVars8( bcShoppingCart, 1) ;
      }

      protected void AddRow059( )
      {
         SdtShoppingCart_Product obj9;
         obj9 = new SdtShoppingCart_Product(context);
         VarsToRow9( obj9) ;
         bcShoppingCart.gxTpr_Product.Add(obj9, 0);
         obj9.gxTpr_Mode = "UPD";
         obj9.gxTpr_Modified = 0;
      }

      protected void ReadRow059( )
      {
         nGXsfl_9_idx = (int)(nGXsfl_9_idx+1);
         RowToVars9( ((SdtShoppingCart_Product)bcShoppingCart.gxTpr_Product.Item(nGXsfl_9_idx)), 1) ;
      }

      protected void InitializeNonKey058( )
      {
         A32ShoppingCartDateDelivery = DateTime.MinValue;
         A6CustomerId = 0;
         A15CustomerName = "";
         A3CountryId = 0;
         A4CountryName = "";
         A16CustomerAddress = "";
         A18CustomerPhone = "";
         A29ShoppingCartFinalPrice = 0;
         n29ShoppingCartFinalPrice = false;
         A28ShoppingCartDate = DateTimeUtil.Today( context);
         O29ShoppingCartFinalPrice = A29ShoppingCartFinalPrice;
         n29ShoppingCartFinalPrice = false;
         Z28ShoppingCartDate = DateTime.MinValue;
         Z6CustomerId = 0;
      }

      protected void InitAll058( )
      {
         A11ShoppingCartId = 0;
         InitializeNonKey058( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A28ShoppingCartDate = i28ShoppingCartDate;
      }

      protected void InitializeNonKey059( )
      {
         A30TotalProduct = 0;
         A8ProductName = "";
         A22ProductPrice = 0;
         A31QtyProduct = 0;
         A1CategoryId = 0;
         A2CategoryName = "";
         O30TotalProduct = A30TotalProduct;
         Z31QtyProduct = 0;
      }

      protected void InitAll059( )
      {
         A7ProductId = 0;
         InitializeNonKey059( ) ;
      }

      protected void StandaloneModalInsert059( )
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

      public void VarsToRow8( SdtShoppingCart obj8 )
      {
         obj8.gxTpr_Mode = Gx_mode;
         obj8.gxTpr_Shoppingcartdatedelivery = A32ShoppingCartDateDelivery;
         obj8.gxTpr_Customerid = A6CustomerId;
         obj8.gxTpr_Customername = A15CustomerName;
         obj8.gxTpr_Countryid = A3CountryId;
         obj8.gxTpr_Countryname = A4CountryName;
         obj8.gxTpr_Customeraddress = A16CustomerAddress;
         obj8.gxTpr_Customerphone = A18CustomerPhone;
         obj8.gxTpr_Shoppingcartfinalprice = A29ShoppingCartFinalPrice;
         obj8.gxTpr_Shoppingcartdate = A28ShoppingCartDate;
         obj8.gxTpr_Shoppingcartid = A11ShoppingCartId;
         obj8.gxTpr_Shoppingcartid_Z = Z11ShoppingCartId;
         obj8.gxTpr_Shoppingcartdate_Z = Z28ShoppingCartDate;
         obj8.gxTpr_Shoppingcartdatedelivery_Z = Z32ShoppingCartDateDelivery;
         obj8.gxTpr_Customerid_Z = Z6CustomerId;
         obj8.gxTpr_Customername_Z = Z15CustomerName;
         obj8.gxTpr_Countryid_Z = Z3CountryId;
         obj8.gxTpr_Countryname_Z = Z4CountryName;
         obj8.gxTpr_Customeraddress_Z = Z16CustomerAddress;
         obj8.gxTpr_Customerphone_Z = Z18CustomerPhone;
         obj8.gxTpr_Shoppingcartfinalprice_Z = Z29ShoppingCartFinalPrice;
         obj8.gxTpr_Shoppingcartfinalprice_N = (short)(Convert.ToInt16(n29ShoppingCartFinalPrice));
         obj8.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow8( SdtShoppingCart obj8 )
      {
         obj8.gxTpr_Shoppingcartid = A11ShoppingCartId;
         return  ;
      }

      public void RowToVars8( SdtShoppingCart obj8 ,
                              int forceLoad )
      {
         Gx_mode = obj8.gxTpr_Mode;
         A32ShoppingCartDateDelivery = obj8.gxTpr_Shoppingcartdatedelivery;
         A6CustomerId = obj8.gxTpr_Customerid;
         A15CustomerName = obj8.gxTpr_Customername;
         A3CountryId = obj8.gxTpr_Countryid;
         A4CountryName = obj8.gxTpr_Countryname;
         A16CustomerAddress = obj8.gxTpr_Customeraddress;
         A18CustomerPhone = obj8.gxTpr_Customerphone;
         A29ShoppingCartFinalPrice = obj8.gxTpr_Shoppingcartfinalprice;
         n29ShoppingCartFinalPrice = false;
         A28ShoppingCartDate = obj8.gxTpr_Shoppingcartdate;
         A11ShoppingCartId = obj8.gxTpr_Shoppingcartid;
         Z11ShoppingCartId = obj8.gxTpr_Shoppingcartid_Z;
         Z28ShoppingCartDate = obj8.gxTpr_Shoppingcartdate_Z;
         Z32ShoppingCartDateDelivery = obj8.gxTpr_Shoppingcartdatedelivery_Z;
         Z6CustomerId = obj8.gxTpr_Customerid_Z;
         Z15CustomerName = obj8.gxTpr_Customername_Z;
         Z3CountryId = obj8.gxTpr_Countryid_Z;
         Z4CountryName = obj8.gxTpr_Countryname_Z;
         Z16CustomerAddress = obj8.gxTpr_Customeraddress_Z;
         Z18CustomerPhone = obj8.gxTpr_Customerphone_Z;
         Z29ShoppingCartFinalPrice = obj8.gxTpr_Shoppingcartfinalprice_Z;
         O29ShoppingCartFinalPrice = obj8.gxTpr_Shoppingcartfinalprice_Z;
         n29ShoppingCartFinalPrice = (bool)(Convert.ToBoolean(obj8.gxTpr_Shoppingcartfinalprice_N));
         Gx_mode = obj8.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow9( SdtShoppingCart_Product obj9 )
      {
         obj9.gxTpr_Mode = Gx_mode;
         obj9.gxTpr_Totalproduct = A30TotalProduct;
         obj9.gxTpr_Productname = A8ProductName;
         obj9.gxTpr_Productprice = A22ProductPrice;
         obj9.gxTpr_Qtyproduct = A31QtyProduct;
         obj9.gxTpr_Categoryid = A1CategoryId;
         obj9.gxTpr_Categoryname = A2CategoryName;
         obj9.gxTpr_Productid = A7ProductId;
         obj9.gxTpr_Productid_Z = Z7ProductId;
         obj9.gxTpr_Productname_Z = Z8ProductName;
         obj9.gxTpr_Productprice_Z = Z22ProductPrice;
         obj9.gxTpr_Qtyproduct_Z = Z31QtyProduct;
         obj9.gxTpr_Totalproduct_Z = Z30TotalProduct;
         obj9.gxTpr_Categoryid_Z = Z1CategoryId;
         obj9.gxTpr_Categoryname_Z = Z2CategoryName;
         obj9.gxTpr_Modified = nIsMod_9;
         return  ;
      }

      public void KeyVarsToRow9( SdtShoppingCart_Product obj9 )
      {
         obj9.gxTpr_Productid = A7ProductId;
         return  ;
      }

      public void RowToVars9( SdtShoppingCart_Product obj9 ,
                              int forceLoad )
      {
         Gx_mode = obj9.gxTpr_Mode;
         A30TotalProduct = obj9.gxTpr_Totalproduct;
         A8ProductName = obj9.gxTpr_Productname;
         A22ProductPrice = obj9.gxTpr_Productprice;
         A31QtyProduct = obj9.gxTpr_Qtyproduct;
         A1CategoryId = obj9.gxTpr_Categoryid;
         A2CategoryName = obj9.gxTpr_Categoryname;
         A7ProductId = obj9.gxTpr_Productid;
         Z7ProductId = obj9.gxTpr_Productid_Z;
         Z8ProductName = obj9.gxTpr_Productname_Z;
         Z22ProductPrice = obj9.gxTpr_Productprice_Z;
         Z31QtyProduct = obj9.gxTpr_Qtyproduct_Z;
         Z30TotalProduct = obj9.gxTpr_Totalproduct_Z;
         O30TotalProduct = obj9.gxTpr_Totalproduct_Z;
         Z1CategoryId = obj9.gxTpr_Categoryid_Z;
         Z2CategoryName = obj9.gxTpr_Categoryname_Z;
         nIsMod_9 = obj9.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A11ShoppingCartId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey058( ) ;
         ScanKeyStart058( ) ;
         if ( RcdFound8 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z11ShoppingCartId = A11ShoppingCartId;
         }
         ZM058( -7) ;
         OnLoadActions058( ) ;
         AddRow058( ) ;
         bcShoppingCart.gxTpr_Product.ClearCollection();
         if ( RcdFound8 == 1 )
         {
            ScanKeyStart059( ) ;
            nGXsfl_9_idx = 1;
            while ( RcdFound9 != 0 )
            {
               O30TotalProduct = A30TotalProduct;
               Z11ShoppingCartId = A11ShoppingCartId;
               Z7ProductId = A7ProductId;
               ZM059( -11) ;
               OnLoadActions059( ) ;
               nRcdExists_9 = 1;
               nIsMod_9 = 0;
               Z30TotalProduct = A30TotalProduct;
               AddRow059( ) ;
               nGXsfl_9_idx = (int)(nGXsfl_9_idx+1);
               ScanKeyNext059( ) ;
            }
            ScanKeyEnd059( ) ;
         }
         ScanKeyEnd058( ) ;
         if ( RcdFound8 == 0 )
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
         RowToVars8( bcShoppingCart, 0) ;
         ScanKeyStart058( ) ;
         if ( RcdFound8 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z11ShoppingCartId = A11ShoppingCartId;
         }
         ZM058( -7) ;
         OnLoadActions058( ) ;
         AddRow058( ) ;
         bcShoppingCart.gxTpr_Product.ClearCollection();
         if ( RcdFound8 == 1 )
         {
            ScanKeyStart059( ) ;
            nGXsfl_9_idx = 1;
            while ( RcdFound9 != 0 )
            {
               O30TotalProduct = A30TotalProduct;
               Z11ShoppingCartId = A11ShoppingCartId;
               Z7ProductId = A7ProductId;
               ZM059( -11) ;
               OnLoadActions059( ) ;
               nRcdExists_9 = 1;
               nIsMod_9 = 0;
               Z30TotalProduct = A30TotalProduct;
               AddRow059( ) ;
               nGXsfl_9_idx = (int)(nGXsfl_9_idx+1);
               ScanKeyNext059( ) ;
            }
            ScanKeyEnd059( ) ;
         }
         ScanKeyEnd058( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey058( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A29ShoppingCartFinalPrice = O29ShoppingCartFinalPrice;
            n29ShoppingCartFinalPrice = false;
            Insert058( ) ;
         }
         else
         {
            if ( RcdFound8 == 1 )
            {
               if ( A11ShoppingCartId != Z11ShoppingCartId )
               {
                  A11ShoppingCartId = Z11ShoppingCartId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  A29ShoppingCartFinalPrice = O29ShoppingCartFinalPrice;
                  n29ShoppingCartFinalPrice = false;
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  A29ShoppingCartFinalPrice = O29ShoppingCartFinalPrice;
                  n29ShoppingCartFinalPrice = false;
                  Update058( ) ;
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
                  if ( A11ShoppingCartId != Z11ShoppingCartId )
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
                        A29ShoppingCartFinalPrice = O29ShoppingCartFinalPrice;
                        n29ShoppingCartFinalPrice = false;
                        Insert058( ) ;
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
                        A29ShoppingCartFinalPrice = O29ShoppingCartFinalPrice;
                        n29ShoppingCartFinalPrice = false;
                        Insert058( ) ;
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
         RowToVars8( bcShoppingCart, 1) ;
         SaveImpl( ) ;
         VarsToRow8( bcShoppingCart) ;
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
         RowToVars8( bcShoppingCart, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         A29ShoppingCartFinalPrice = O29ShoppingCartFinalPrice;
         n29ShoppingCartFinalPrice = false;
         Insert058( ) ;
         AfterTrn( ) ;
         VarsToRow8( bcShoppingCart) ;
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
            SdtShoppingCart auxBC = new SdtShoppingCart(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A11ShoppingCartId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcShoppingCart);
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
         RowToVars8( bcShoppingCart, 1) ;
         UpdateImpl( ) ;
         VarsToRow8( bcShoppingCart) ;
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
         RowToVars8( bcShoppingCart, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert058( ) ;
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
         VarsToRow8( bcShoppingCart) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars8( bcShoppingCart, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey058( ) ;
         if ( RcdFound8 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A11ShoppingCartId != Z11ShoppingCartId )
            {
               A11ShoppingCartId = Z11ShoppingCartId;
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
            if ( A11ShoppingCartId != Z11ShoppingCartId )
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
         pr_default.close(5);
         pr_default.close(1);
         pr_default.close(15);
         pr_default.close(16);
         pr_default.close(14);
         pr_default.close(23);
         pr_default.close(24);
         context.RollbackDataStores("shoppingcart_bc",pr_default);
         VarsToRow8( bcShoppingCart) ;
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
         Gx_mode = bcShoppingCart.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcShoppingCart.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcShoppingCart )
         {
            bcShoppingCart = (SdtShoppingCart)(sdt);
            if ( StringUtil.StrCmp(bcShoppingCart.gxTpr_Mode, "") == 0 )
            {
               bcShoppingCart.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow8( bcShoppingCart) ;
            }
            else
            {
               RowToVars8( bcShoppingCart, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcShoppingCart.gxTpr_Mode, "") == 0 )
            {
               bcShoppingCart.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars8( bcShoppingCart, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtShoppingCart ShoppingCart_BC
      {
         get {
            return bcShoppingCart ;
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
         pr_default.close(23);
         pr_default.close(24);
         pr_default.close(5);
         pr_default.close(15);
         pr_default.close(16);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode8 = "";
         Z28ShoppingCartDate = DateTime.MinValue;
         A28ShoppingCartDate = DateTime.MinValue;
         Z32ShoppingCartDateDelivery = DateTime.MinValue;
         A32ShoppingCartDateDelivery = DateTime.MinValue;
         Z15CustomerName = "";
         A15CustomerName = "";
         Z16CustomerAddress = "";
         A16CustomerAddress = "";
         Z18CustomerPhone = "";
         A18CustomerPhone = "";
         Z4CountryName = "";
         A4CountryName = "";
         BC000513_A11ShoppingCartId = new short[1] ;
         BC000513_A28ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         BC000513_A15CustomerName = new string[] {""} ;
         BC000513_A4CountryName = new string[] {""} ;
         BC000513_A16CustomerAddress = new string[] {""} ;
         BC000513_A18CustomerPhone = new string[] {""} ;
         BC000513_A6CustomerId = new short[1] ;
         BC000513_A3CountryId = new short[1] ;
         BC000513_A29ShoppingCartFinalPrice = new decimal[1] ;
         BC000513_n29ShoppingCartFinalPrice = new bool[] {false} ;
         BC000511_A29ShoppingCartFinalPrice = new decimal[1] ;
         BC000511_n29ShoppingCartFinalPrice = new bool[] {false} ;
         BC00058_A15CustomerName = new string[] {""} ;
         BC00058_A16CustomerAddress = new string[] {""} ;
         BC00058_A18CustomerPhone = new string[] {""} ;
         BC00058_A3CountryId = new short[1] ;
         BC00059_A4CountryName = new string[] {""} ;
         BC000514_A11ShoppingCartId = new short[1] ;
         BC00057_A11ShoppingCartId = new short[1] ;
         BC00057_A28ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         BC00057_A6CustomerId = new short[1] ;
         BC00056_A11ShoppingCartId = new short[1] ;
         BC00056_A28ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         BC00056_A6CustomerId = new short[1] ;
         BC000515_A11ShoppingCartId = new short[1] ;
         BC000519_A29ShoppingCartFinalPrice = new decimal[1] ;
         BC000519_n29ShoppingCartFinalPrice = new bool[] {false} ;
         BC000520_A15CustomerName = new string[] {""} ;
         BC000520_A16CustomerAddress = new string[] {""} ;
         BC000520_A18CustomerPhone = new string[] {""} ;
         BC000520_A3CountryId = new short[1] ;
         BC000521_A4CountryName = new string[] {""} ;
         BC000523_A11ShoppingCartId = new short[1] ;
         BC000523_A28ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         BC000523_A15CustomerName = new string[] {""} ;
         BC000523_A4CountryName = new string[] {""} ;
         BC000523_A16CustomerAddress = new string[] {""} ;
         BC000523_A18CustomerPhone = new string[] {""} ;
         BC000523_A6CustomerId = new short[1] ;
         BC000523_A3CountryId = new short[1] ;
         BC000523_A29ShoppingCartFinalPrice = new decimal[1] ;
         BC000523_n29ShoppingCartFinalPrice = new bool[] {false} ;
         Z8ProductName = "";
         A8ProductName = "";
         Z2CategoryName = "";
         A2CategoryName = "";
         BC000524_A11ShoppingCartId = new short[1] ;
         BC000524_A8ProductName = new string[] {""} ;
         BC000524_A22ProductPrice = new decimal[1] ;
         BC000524_A31QtyProduct = new short[1] ;
         BC000524_A2CategoryName = new string[] {""} ;
         BC000524_A7ProductId = new short[1] ;
         BC000524_A1CategoryId = new short[1] ;
         BC00054_A8ProductName = new string[] {""} ;
         BC00054_A22ProductPrice = new decimal[1] ;
         BC00054_A1CategoryId = new short[1] ;
         BC00055_A2CategoryName = new string[] {""} ;
         BC000525_A11ShoppingCartId = new short[1] ;
         BC000525_A7ProductId = new short[1] ;
         BC00053_A11ShoppingCartId = new short[1] ;
         BC00053_A31QtyProduct = new short[1] ;
         BC00053_A7ProductId = new short[1] ;
         sMode9 = "";
         BC00052_A11ShoppingCartId = new short[1] ;
         BC00052_A31QtyProduct = new short[1] ;
         BC00052_A7ProductId = new short[1] ;
         BC000529_A8ProductName = new string[] {""} ;
         BC000529_A22ProductPrice = new decimal[1] ;
         BC000529_A1CategoryId = new short[1] ;
         BC000530_A2CategoryName = new string[] {""} ;
         BC000531_A11ShoppingCartId = new short[1] ;
         BC000531_A8ProductName = new string[] {""} ;
         BC000531_A22ProductPrice = new decimal[1] ;
         BC000531_A31QtyProduct = new short[1] ;
         BC000531_A2CategoryName = new string[] {""} ;
         BC000531_A7ProductId = new short[1] ;
         BC000531_A1CategoryId = new short[1] ;
         i28ShoppingCartDate = DateTime.MinValue;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.shoppingcart_bc__default(),
            new Object[][] {
                new Object[] {
               BC00052_A11ShoppingCartId, BC00052_A31QtyProduct, BC00052_A7ProductId
               }
               , new Object[] {
               BC00053_A11ShoppingCartId, BC00053_A31QtyProduct, BC00053_A7ProductId
               }
               , new Object[] {
               BC00054_A8ProductName, BC00054_A22ProductPrice, BC00054_A1CategoryId
               }
               , new Object[] {
               BC00055_A2CategoryName
               }
               , new Object[] {
               BC00056_A11ShoppingCartId, BC00056_A28ShoppingCartDate, BC00056_A6CustomerId
               }
               , new Object[] {
               BC00057_A11ShoppingCartId, BC00057_A28ShoppingCartDate, BC00057_A6CustomerId
               }
               , new Object[] {
               BC00058_A15CustomerName, BC00058_A16CustomerAddress, BC00058_A18CustomerPhone, BC00058_A3CountryId
               }
               , new Object[] {
               BC00059_A4CountryName
               }
               , new Object[] {
               BC000511_A29ShoppingCartFinalPrice, BC000511_n29ShoppingCartFinalPrice
               }
               , new Object[] {
               BC000513_A11ShoppingCartId, BC000513_A28ShoppingCartDate, BC000513_A15CustomerName, BC000513_A4CountryName, BC000513_A16CustomerAddress, BC000513_A18CustomerPhone, BC000513_A6CustomerId, BC000513_A3CountryId, BC000513_A29ShoppingCartFinalPrice, BC000513_n29ShoppingCartFinalPrice
               }
               , new Object[] {
               BC000514_A11ShoppingCartId
               }
               , new Object[] {
               BC000515_A11ShoppingCartId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000519_A29ShoppingCartFinalPrice, BC000519_n29ShoppingCartFinalPrice
               }
               , new Object[] {
               BC000520_A15CustomerName, BC000520_A16CustomerAddress, BC000520_A18CustomerPhone, BC000520_A3CountryId
               }
               , new Object[] {
               BC000521_A4CountryName
               }
               , new Object[] {
               BC000523_A11ShoppingCartId, BC000523_A28ShoppingCartDate, BC000523_A15CustomerName, BC000523_A4CountryName, BC000523_A16CustomerAddress, BC000523_A18CustomerPhone, BC000523_A6CustomerId, BC000523_A3CountryId, BC000523_A29ShoppingCartFinalPrice, BC000523_n29ShoppingCartFinalPrice
               }
               , new Object[] {
               BC000524_A11ShoppingCartId, BC000524_A8ProductName, BC000524_A22ProductPrice, BC000524_A31QtyProduct, BC000524_A2CategoryName, BC000524_A7ProductId, BC000524_A1CategoryId
               }
               , new Object[] {
               BC000525_A11ShoppingCartId, BC000525_A7ProductId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000529_A8ProductName, BC000529_A22ProductPrice, BC000529_A1CategoryId
               }
               , new Object[] {
               BC000530_A2CategoryName
               }
               , new Object[] {
               BC000531_A11ShoppingCartId, BC000531_A8ProductName, BC000531_A22ProductPrice, BC000531_A31QtyProduct, BC000531_A2CategoryName, BC000531_A7ProductId, BC000531_A1CategoryId
               }
            }
         );
         Z28ShoppingCartDate = DateTimeUtil.Today( context);
         A28ShoppingCartDate = DateTimeUtil.Today( context);
         i28ShoppingCartDate = DateTimeUtil.Today( context);
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12052 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Z11ShoppingCartId ;
      private short A11ShoppingCartId ;
      private short nIsMod_9 ;
      private short RcdFound9 ;
      private short GX_JID ;
      private short Z6CustomerId ;
      private short A6CustomerId ;
      private short Z3CountryId ;
      private short A3CountryId ;
      private short Gx_BScreen ;
      private short RcdFound8 ;
      private short nIsDirty_8 ;
      private short nRcdExists_9 ;
      private short Gxremove9 ;
      private short Z31QtyProduct ;
      private short A31QtyProduct ;
      private short Z1CategoryId ;
      private short A1CategoryId ;
      private short Z7ProductId ;
      private short A7ProductId ;
      private short nIsDirty_9 ;
      private int trnEnded ;
      private int nGXsfl_9_idx=1 ;
      private decimal s29ShoppingCartFinalPrice ;
      private decimal O29ShoppingCartFinalPrice ;
      private decimal A29ShoppingCartFinalPrice ;
      private decimal Z29ShoppingCartFinalPrice ;
      private decimal Z30TotalProduct ;
      private decimal A30TotalProduct ;
      private decimal Z22ProductPrice ;
      private decimal A22ProductPrice ;
      private decimal O30TotalProduct ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode8 ;
      private string Z15CustomerName ;
      private string A15CustomerName ;
      private string Z18CustomerPhone ;
      private string A18CustomerPhone ;
      private string Z4CountryName ;
      private string A4CountryName ;
      private string Z8ProductName ;
      private string A8ProductName ;
      private string Z2CategoryName ;
      private string A2CategoryName ;
      private string sMode9 ;
      private DateTime Z28ShoppingCartDate ;
      private DateTime A28ShoppingCartDate ;
      private DateTime Z32ShoppingCartDateDelivery ;
      private DateTime A32ShoppingCartDateDelivery ;
      private DateTime i28ShoppingCartDate ;
      private bool n29ShoppingCartFinalPrice ;
      private bool returnInSub ;
      private bool mustCommit ;
      private string Z16CustomerAddress ;
      private string A16CustomerAddress ;
      private SdtShoppingCart bcShoppingCart ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC000513_A11ShoppingCartId ;
      private DateTime[] BC000513_A28ShoppingCartDate ;
      private string[] BC000513_A15CustomerName ;
      private string[] BC000513_A4CountryName ;
      private string[] BC000513_A16CustomerAddress ;
      private string[] BC000513_A18CustomerPhone ;
      private short[] BC000513_A6CustomerId ;
      private short[] BC000513_A3CountryId ;
      private decimal[] BC000513_A29ShoppingCartFinalPrice ;
      private bool[] BC000513_n29ShoppingCartFinalPrice ;
      private decimal[] BC000511_A29ShoppingCartFinalPrice ;
      private bool[] BC000511_n29ShoppingCartFinalPrice ;
      private string[] BC00058_A15CustomerName ;
      private string[] BC00058_A16CustomerAddress ;
      private string[] BC00058_A18CustomerPhone ;
      private short[] BC00058_A3CountryId ;
      private string[] BC00059_A4CountryName ;
      private short[] BC000514_A11ShoppingCartId ;
      private short[] BC00057_A11ShoppingCartId ;
      private DateTime[] BC00057_A28ShoppingCartDate ;
      private short[] BC00057_A6CustomerId ;
      private short[] BC00056_A11ShoppingCartId ;
      private DateTime[] BC00056_A28ShoppingCartDate ;
      private short[] BC00056_A6CustomerId ;
      private short[] BC000515_A11ShoppingCartId ;
      private decimal[] BC000519_A29ShoppingCartFinalPrice ;
      private bool[] BC000519_n29ShoppingCartFinalPrice ;
      private string[] BC000520_A15CustomerName ;
      private string[] BC000520_A16CustomerAddress ;
      private string[] BC000520_A18CustomerPhone ;
      private short[] BC000520_A3CountryId ;
      private string[] BC000521_A4CountryName ;
      private short[] BC000523_A11ShoppingCartId ;
      private DateTime[] BC000523_A28ShoppingCartDate ;
      private string[] BC000523_A15CustomerName ;
      private string[] BC000523_A4CountryName ;
      private string[] BC000523_A16CustomerAddress ;
      private string[] BC000523_A18CustomerPhone ;
      private short[] BC000523_A6CustomerId ;
      private short[] BC000523_A3CountryId ;
      private decimal[] BC000523_A29ShoppingCartFinalPrice ;
      private bool[] BC000523_n29ShoppingCartFinalPrice ;
      private short[] BC000524_A11ShoppingCartId ;
      private string[] BC000524_A8ProductName ;
      private decimal[] BC000524_A22ProductPrice ;
      private short[] BC000524_A31QtyProduct ;
      private string[] BC000524_A2CategoryName ;
      private short[] BC000524_A7ProductId ;
      private short[] BC000524_A1CategoryId ;
      private string[] BC00054_A8ProductName ;
      private decimal[] BC00054_A22ProductPrice ;
      private short[] BC00054_A1CategoryId ;
      private string[] BC00055_A2CategoryName ;
      private short[] BC000525_A11ShoppingCartId ;
      private short[] BC000525_A7ProductId ;
      private short[] BC00053_A11ShoppingCartId ;
      private short[] BC00053_A31QtyProduct ;
      private short[] BC00053_A7ProductId ;
      private short[] BC00052_A11ShoppingCartId ;
      private short[] BC00052_A31QtyProduct ;
      private short[] BC00052_A7ProductId ;
      private string[] BC000529_A8ProductName ;
      private decimal[] BC000529_A22ProductPrice ;
      private short[] BC000529_A1CategoryId ;
      private string[] BC000530_A2CategoryName ;
      private short[] BC000531_A11ShoppingCartId ;
      private string[] BC000531_A8ProductName ;
      private decimal[] BC000531_A22ProductPrice ;
      private short[] BC000531_A31QtyProduct ;
      private string[] BC000531_A2CategoryName ;
      private short[] BC000531_A7ProductId ;
      private short[] BC000531_A1CategoryId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class shoppingcart_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new UpdateCursor(def[20])
         ,new UpdateCursor(def[21])
         ,new UpdateCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000513;
          prmBC000513 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmBC000511;
          prmBC000511 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmBC00058;
          prmBC00058 = new Object[] {
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmBC00059;
          prmBC00059 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC000514;
          prmBC000514 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmBC00057;
          prmBC00057 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmBC00056;
          prmBC00056 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmBC000515;
          prmBC000515 = new Object[] {
          new ParDef("@ShoppingCartDate",GXType.Date,8,0) ,
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmBC000516;
          prmBC000516 = new Object[] {
          new ParDef("@ShoppingCartDate",GXType.Date,8,0) ,
          new ParDef("@CustomerId",GXType.Int16,4,0) ,
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmBC000517;
          prmBC000517 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmBC000519;
          prmBC000519 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmBC000520;
          prmBC000520 = new Object[] {
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmBC000521;
          prmBC000521 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC000523;
          prmBC000523 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmBC000524;
          prmBC000524 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC00054;
          prmBC00054 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC00055;
          prmBC00055 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmBC000525;
          prmBC000525 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC00053;
          prmBC00053 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC00052;
          prmBC00052 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000526;
          prmBC000526 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@QtyProduct",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000527;
          prmBC000527 = new Object[] {
          new ParDef("@QtyProduct",GXType.Int16,4,0) ,
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000528;
          prmBC000528 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000529;
          prmBC000529 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000530;
          prmBC000530 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmBC000531;
          prmBC000531 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00052", "SELECT [ShoppingCartId], [QtyProduct], [ProductId] FROM [ShoppingCartProduct] WITH (UPDLOCK) WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00052,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00053", "SELECT [ShoppingCartId], [QtyProduct], [ProductId] FROM [ShoppingCartProduct] WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00053,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00054", "SELECT [ProductName], [ProductPrice], [CategoryId] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00054,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00055", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00055,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00056", "SELECT [ShoppingCartId], [ShoppingCartDate], [CustomerId] FROM [ShoppingCart] WITH (UPDLOCK) WHERE [ShoppingCartId] = @ShoppingCartId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00056,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00057", "SELECT [ShoppingCartId], [ShoppingCartDate], [CustomerId] FROM [ShoppingCart] WHERE [ShoppingCartId] = @ShoppingCartId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00057,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00058", "SELECT [CustomerName], [CustomerAddress], [CustomerPhone], [CountryId] FROM [Customer] WHERE [CustomerId] = @CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00058,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00059", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00059,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000511", "SELECT COALESCE( T1.[ShoppingCartFinalPrice], 0) AS ShoppingCartFinalPrice FROM (SELECT SUM(CASE  WHEN T4.[CategoryName] = 'Joyería' THEN T2.[QtyProduct] * CAST(T3.[ProductPrice] AS decimal( 20, 10)) * CAST(( 1 + CAST(5 AS decimal( 13, 10)) / 100) AS decimal( 22, 10)) WHEN T4.[CategoryName] = 'Entretenimiento' THEN T2.[QtyProduct] * CAST(T3.[ProductPrice] AS decimal( 20, 10)) * CAST(( 1 - CAST(10 AS decimal( 13, 10)) / 100) AS decimal( 22, 10)) ELSE T2.[QtyProduct] * CAST(T3.[ProductPrice] AS decimal( 20, 10)) END) AS ShoppingCartFinalPrice, T2.[ShoppingCartId] FROM (([ShoppingCartProduct] T2 WITH (UPDLOCK) INNER JOIN [Product] T3 ON T3.[ProductId] = T2.[ProductId]) INNER JOIN [Category] T4 ON T4.[CategoryId] = T3.[CategoryId]) GROUP BY T2.[ShoppingCartId] ) T1 WHERE T1.[ShoppingCartId] = @ShoppingCartId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000511,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000513", "SELECT TM1.[ShoppingCartId], TM1.[ShoppingCartDate], T3.[CustomerName], T4.[CountryName], T3.[CustomerAddress], T3.[CustomerPhone], TM1.[CustomerId], T3.[CountryId], COALESCE( T2.[ShoppingCartFinalPrice], 0) AS ShoppingCartFinalPrice FROM ((([ShoppingCart] TM1 LEFT JOIN (SELECT SUM(CASE  WHEN T7.[CategoryName] = 'Joyería' THEN T5.[QtyProduct] * CAST(T6.[ProductPrice] AS decimal( 20, 10)) * CAST(( 1 + CAST(5 AS decimal( 13, 10)) / 100) AS decimal( 22, 10)) WHEN T7.[CategoryName] = 'Entretenimiento' THEN T5.[QtyProduct] * CAST(T6.[ProductPrice] AS decimal( 20, 10)) * CAST(( 1 - CAST(10 AS decimal( 13, 10)) / 100) AS decimal( 22, 10)) ELSE T5.[QtyProduct] * CAST(T6.[ProductPrice] AS decimal( 20, 10)) END) AS ShoppingCartFinalPrice, T5.[ShoppingCartId] FROM (([ShoppingCartProduct] T5 INNER JOIN [Product] T6 ON T6.[ProductId] = T5.[ProductId]) INNER JOIN [Category] T7 ON T7.[CategoryId] = T6.[CategoryId]) GROUP BY T5.[ShoppingCartId] ) T2 ON T2.[ShoppingCartId] = TM1.[ShoppingCartId]) INNER JOIN [Customer] T3 ON T3.[CustomerId] = TM1.[CustomerId]) INNER JOIN [Country] T4 ON T4.[CountryId] = T3.[CountryId]) WHERE TM1.[ShoppingCartId] = @ShoppingCartId ORDER BY TM1.[ShoppingCartId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000513,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000514", "SELECT [ShoppingCartId] FROM [ShoppingCart] WHERE [ShoppingCartId] = @ShoppingCartId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000514,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000515", "INSERT INTO [ShoppingCart]([ShoppingCartDate], [CustomerId]) VALUES(@ShoppingCartDate, @CustomerId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000515,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000516", "UPDATE [ShoppingCart] SET [ShoppingCartDate]=@ShoppingCartDate, [CustomerId]=@CustomerId  WHERE [ShoppingCartId] = @ShoppingCartId", GxErrorMask.GX_NOMASK,prmBC000516)
             ,new CursorDef("BC000517", "DELETE FROM [ShoppingCart]  WHERE [ShoppingCartId] = @ShoppingCartId", GxErrorMask.GX_NOMASK,prmBC000517)
             ,new CursorDef("BC000519", "SELECT COALESCE( T1.[ShoppingCartFinalPrice], 0) AS ShoppingCartFinalPrice FROM (SELECT SUM(CASE  WHEN T4.[CategoryName] = 'Joyería' THEN T2.[QtyProduct] * CAST(T3.[ProductPrice] AS decimal( 20, 10)) * CAST(( 1 + CAST(5 AS decimal( 13, 10)) / 100) AS decimal( 22, 10)) WHEN T4.[CategoryName] = 'Entretenimiento' THEN T2.[QtyProduct] * CAST(T3.[ProductPrice] AS decimal( 20, 10)) * CAST(( 1 - CAST(10 AS decimal( 13, 10)) / 100) AS decimal( 22, 10)) ELSE T2.[QtyProduct] * CAST(T3.[ProductPrice] AS decimal( 20, 10)) END) AS ShoppingCartFinalPrice, T2.[ShoppingCartId] FROM (([ShoppingCartProduct] T2 WITH (UPDLOCK) INNER JOIN [Product] T3 ON T3.[ProductId] = T2.[ProductId]) INNER JOIN [Category] T4 ON T4.[CategoryId] = T3.[CategoryId]) GROUP BY T2.[ShoppingCartId] ) T1 WHERE T1.[ShoppingCartId] = @ShoppingCartId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000519,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000520", "SELECT [CustomerName], [CustomerAddress], [CustomerPhone], [CountryId] FROM [Customer] WHERE [CustomerId] = @CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000520,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000521", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000521,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000523", "SELECT TM1.[ShoppingCartId], TM1.[ShoppingCartDate], T3.[CustomerName], T4.[CountryName], T3.[CustomerAddress], T3.[CustomerPhone], TM1.[CustomerId], T3.[CountryId], COALESCE( T2.[ShoppingCartFinalPrice], 0) AS ShoppingCartFinalPrice FROM ((([ShoppingCart] TM1 LEFT JOIN (SELECT SUM(CASE  WHEN T7.[CategoryName] = 'Joyería' THEN T5.[QtyProduct] * CAST(T6.[ProductPrice] AS decimal( 20, 10)) * CAST(( 1 + CAST(5 AS decimal( 13, 10)) / 100) AS decimal( 22, 10)) WHEN T7.[CategoryName] = 'Entretenimiento' THEN T5.[QtyProduct] * CAST(T6.[ProductPrice] AS decimal( 20, 10)) * CAST(( 1 - CAST(10 AS decimal( 13, 10)) / 100) AS decimal( 22, 10)) ELSE T5.[QtyProduct] * CAST(T6.[ProductPrice] AS decimal( 20, 10)) END) AS ShoppingCartFinalPrice, T5.[ShoppingCartId] FROM (([ShoppingCartProduct] T5 INNER JOIN [Product] T6 ON T6.[ProductId] = T5.[ProductId]) INNER JOIN [Category] T7 ON T7.[CategoryId] = T6.[CategoryId]) GROUP BY T5.[ShoppingCartId] ) T2 ON T2.[ShoppingCartId] = TM1.[ShoppingCartId]) INNER JOIN [Customer] T3 ON T3.[CustomerId] = TM1.[CustomerId]) INNER JOIN [Country] T4 ON T4.[CountryId] = T3.[CountryId]) WHERE TM1.[ShoppingCartId] = @ShoppingCartId ORDER BY TM1.[ShoppingCartId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000523,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000524", "SELECT T1.[ShoppingCartId], T2.[ProductName], T2.[ProductPrice], T1.[QtyProduct], T3.[CategoryName], T1.[ProductId], T2.[CategoryId] FROM (([ShoppingCartProduct] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) INNER JOIN [Category] T3 ON T3.[CategoryId] = T2.[CategoryId]) WHERE T1.[ShoppingCartId] = @ShoppingCartId and T1.[ProductId] = @ProductId ORDER BY T1.[ShoppingCartId], T1.[ProductId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000524,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000525", "SELECT [ShoppingCartId], [ProductId] FROM [ShoppingCartProduct] WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000525,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000526", "INSERT INTO [ShoppingCartProduct]([ShoppingCartId], [QtyProduct], [ProductId]) VALUES(@ShoppingCartId, @QtyProduct, @ProductId)", GxErrorMask.GX_NOMASK,prmBC000526)
             ,new CursorDef("BC000527", "UPDATE [ShoppingCartProduct] SET [QtyProduct]=@QtyProduct  WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmBC000527)
             ,new CursorDef("BC000528", "DELETE FROM [ShoppingCartProduct]  WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmBC000528)
             ,new CursorDef("BC000529", "SELECT [ProductName], [ProductPrice], [CategoryId] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000529,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000530", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000530,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000531", "SELECT T1.[ShoppingCartId], T2.[ProductName], T2.[ProductPrice], T1.[QtyProduct], T3.[CategoryName], T1.[ProductId], T2.[CategoryId] FROM (([ShoppingCartProduct] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) INNER JOIN [Category] T3 ON T3.[CategoryId] = T2.[CategoryId]) WHERE T1.[ShoppingCartId] = @ShoppingCartId ORDER BY T1.[ShoppingCartId], T1.[ProductId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000531,11, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 8 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 14 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 23 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 24 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 25 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
       }
    }

 }

}
