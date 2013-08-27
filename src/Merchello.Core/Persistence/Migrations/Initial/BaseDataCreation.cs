﻿using System;
using Merchello.Core.Models;
using Merchello.Core.Models.Rdbms;
using Merchello.Core.Models.TypeFields;
using Umbraco.Core.Logging;
using Umbraco.Core.Persistence;

namespace Merchello.Core.Persistence.Migrations.Initial
{
    /// <summary>
    /// Represents the initial data creation by running Insert for the base data.
    /// </summary>
    internal class BaseDataCreation
    {
        private readonly Database _database;

        public BaseDataCreation(Database database)
        {
            _database = database;
        }

        /// <summary>
        /// Initialize the base data creation by inserting the data foundation for umbraco
        /// specific to a table
        /// </summary>
        /// <param name="tableName">Name of the table to create base data for</param>
        public void InitializeBaseData(string tableName)
        {
            LogHelper.Info<BaseDataCreation>(string.Format("Creating data in table {0}", tableName));

            if (tableName.Equals("merchDBTypeField")) CreateDbTypeFieldData();

            if(tableName.Equals("merchInvoiceStatus")) CreateInvoiceStatusData();
            
        }

        private void CreateDbTypeFieldData()
        {
            // address
            var address = new AddressTypeField();
            _database.Insert("merchDBTypeField", "Key", new TypeFieldDto() { Key = address.Residential.TypeKey, Alias = address.Residential.Alias, Name = address.Residential.Name });
            _database.Insert("merchDBTypeField", "Key", new TypeFieldDto() { Key = address.Commercial.TypeKey, Alias = address.Commercial.Alias, Name = address.Commercial.Name });

            // BasketTypeField
            var basket = new BasketTypeField();
            _database.Insert("merchDBTypeField", "Key", new TypeFieldDto() { Key = basket.Basket.TypeKey, Alias = basket.Basket.Alias, Name = basket.Basket.Name });
            _database.Insert("merchDBTypeField", "Key", new TypeFieldDto() { Key = basket.Wishlist.TypeKey, Alias = basket.Wishlist.Alias, Name = basket.Wishlist.Name });

            // InvoiceItemType
            var itf = new InvoiceItemTypeField();
            _database.Insert("merchDBTypeField", "Key", new TypeFieldDto() { Key = itf.Product.TypeKey, Alias = itf.Product.Alias, Name = itf.Product.Name });
            _database.Insert("merchDBTypeField", "Key", new TypeFieldDto() { Key = itf.Charge.TypeKey, Alias = itf.Charge.Alias, Name = itf.Charge.Name });
            _database.Insert("merchDBTypeField", "Key", new TypeFieldDto() { Key = itf.Credit.TypeKey, Alias = itf.Credit.Alias, Name = itf.Credit.Name });
            _database.Insert("merchDBTypeField", "Key", new TypeFieldDto() { Key = itf.Shipping.TypeKey, Alias = itf.Shipping.Alias, Name = itf.Shipping.Name });
            _database.Insert("merchDBTypeField", "Key", new TypeFieldDto() { Key = itf.Tax.TypeKey, Alias = itf.Tax.Alias, Name = itf.Tax.Name });

            // PaymentMethodType
            var ptf = new PaymentMethodTypeField();
            _database.Insert("merchDBTypeField", "Key", new TypeFieldDto() { Key = ptf.Cash.TypeKey, Alias = ptf.Cash.Alias, Name = ptf.Cash.Name });
            _database.Insert("merchDBTypeField", "Key", new TypeFieldDto() { Key = ptf.CreditCard.TypeKey, Alias = ptf.CreditCard.Alias, Name = ptf.CreditCard.Name });
            _database.Insert("merchDBTypeField", "Key", new TypeFieldDto() { Key = ptf.PurchaseOrder.TypeKey, Alias = ptf.PurchaseOrder.Alias, Name = ptf.PurchaseOrder.Name });

            // ShipmentMethodType
            var stf = new ShipMethodTypeField();
            _database.Insert("merchDBTypeField", "Key", new TypeFieldDto() { Key = stf.FlatRate.TypeKey, Alias = stf.FlatRate.Alias, Name = stf.FlatRate.Name });
            _database.Insert("merchDBTypeField", "Key", new TypeFieldDto() { Key = stf.Carrier.TypeKey, Alias = stf.Carrier.Alias, Name = stf.Carrier.Name });
            _database.Insert("merchDBTypeField", "Key", new TypeFieldDto() { Key = stf.PercentTotal.TypeKey, Alias = stf.PercentTotal.Alias, Name = stf.PercentTotal.Name });
        }

        private void CreateInvoiceStatusData()
        {
            _database.Insert("merchInvoiceStatus", "id", new InvoiceStatusDto() { Alias = "unpaid", Name = "Unpaid", Active = true, Reportable = true, SortOrder = 1, CreateDate = DateTime.Now, UpdateDate = DateTime.Now});
            _database.Insert("merchInvoiceStatus", "id", new InvoiceStatusDto() { Alias = "unshipped", Name = "Unshipped", Active = true, Reportable = true, SortOrder = 2, CreateDate = DateTime.Now, UpdateDate = DateTime.Now });
            _database.Insert("merchInvoiceStatus", "id", new InvoiceStatusDto() { Alias = "completed", Name = "Completed", Active = true, Reportable = true, SortOrder = 3, CreateDate = DateTime.Now, UpdateDate = DateTime.Now });
            _database.Insert("merchInvoiceStatus", "id", new InvoiceStatusDto() { Alias = "cancelled", Name = "Cancelled", Active = true, Reportable = true, SortOrder = 4, CreateDate = DateTime.Now, UpdateDate = DateTime.Now });
            _database.Insert("merchInvoiceStatus", "id", new InvoiceStatusDto() { Alias = "fraud", Name = "Fraud", Active = true, Reportable = true, SortOrder = 5, CreateDate = DateTime.Now, UpdateDate = DateTime.Now });
        }
    }
}