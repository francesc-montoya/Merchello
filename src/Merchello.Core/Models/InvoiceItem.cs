﻿using System;
using System.Reflection;
using System.Runtime.Serialization;
using Merchello.Core.Models.EntityBase;
using Merchello.Core.Models.TypeFields;

namespace Merchello.Core.Models
{

    [Serializable]
    [DataContract(IsReference = true)]
    public partial class InvoiceItem : IdEntity, IInvoiceItem
    {
        private readonly int _parentId;
        private readonly IInvoice _invoice;
        private Guid _invoiceItemTypeFieldKey;
        private string _sku;
        private string _name;
        private int _baseQuantity;
        private int _unitOfMeasureMultiplier;
        private decimal _amount;
        private bool _exported;

        public InvoiceItem (IInvoice invoice, int parentId)  
        {
            _invoice = _invoice;
            _parentId = parentId;
        }
        
        private static readonly PropertyInfo InvoiceItemTypeFieldKeySelector = ExpressionHelper.GetPropertyInfo<InvoiceItem, Guid>(x => x.InvoiceItemTypeFieldKey);  
        private static readonly PropertyInfo SkuSelector = ExpressionHelper.GetPropertyInfo<InvoiceItem, string>(x => x.Sku);  
        private static readonly PropertyInfo NameSelector = ExpressionHelper.GetPropertyInfo<InvoiceItem, string>(x => x.Name);  
        private static readonly PropertyInfo BaseQuantitySelector = ExpressionHelper.GetPropertyInfo<InvoiceItem, int>(x => x.BaseQuantity);  
        private static readonly PropertyInfo UnitOfMeasureMultiplierSelector = ExpressionHelper.GetPropertyInfo<InvoiceItem, int>(x => x.UnitOfMeasureMultiplier);  
        private static readonly PropertyInfo AmountSelector = ExpressionHelper.GetPropertyInfo<InvoiceItem, decimal>(x => x.Amount);  
        private static readonly PropertyInfo ExportedSelector = ExpressionHelper.GetPropertyInfo<InvoiceItem, bool>(x => x.Exported);  
        
    /// <summary>
    /// The parentId associated with the InvoiceItem
    /// </summary>
    [DataMember]
    public int? ParentId
    {
        get { return _parentId; }
    }
    
    /// <summary>
    /// The invoiceId associated with the InvoiceItem
    /// </summary>
    [DataMember]
    public int InvoiceId
    {
        get { return _invoice.Id; }
    }
    
    /// <summary>
    /// The invoiceItemTypeFieldKey associated with the InvoiceItem
    /// </summary>
    [DataMember]
    public Guid InvoiceItemTypeFieldKey
    {
        get { return _invoiceItemTypeFieldKey; }
            set 
            { 
                SetPropertyValueAndDetectChanges(o =>
                {
                    _invoiceItemTypeFieldKey = value;
                    return _invoiceItemTypeFieldKey;
                }, _invoiceItemTypeFieldKey, InvoiceItemTypeFieldKeySelector); 
            }
    }
    
    /// <summary>
    /// The sku associated with the InvoiceItem
    /// </summary>
    [DataMember]
    public string Sku
    {
        get { return _sku; }
            set 
            { 
                SetPropertyValueAndDetectChanges(o =>
                {
                    _sku = value;
                    return _sku;
                }, _sku, SkuSelector); 
            }
    }
    
    /// <summary>
    /// The name associated with the InvoiceItem
    /// </summary>
    [DataMember]
    public string Name
    {
        get { return _name; }
            set 
            { 
                SetPropertyValueAndDetectChanges(o =>
                {
                    _name = value;
                    return _name;
                }, _name, NameSelector); 
            }
    }
    
    /// <summary>
    /// The baseQuantity associated with the InvoiceItem
    /// </summary>
    [DataMember]
    public int BaseQuantity
    {
        get { return _baseQuantity; }
            set 
            { 
                SetPropertyValueAndDetectChanges(o =>
                {
                    _baseQuantity = value;
                    return _baseQuantity;
                }, _baseQuantity, BaseQuantitySelector); 
            }
    }
    
    /// <summary>
    /// The unitOfMeasureMultiplier associated with the InvoiceItem
    /// </summary>
    [DataMember]
    public int UnitOfMeasureMultiplier
    {
        get { return _unitOfMeasureMultiplier; }
            set 
            { 
                SetPropertyValueAndDetectChanges(o =>
                {
                    _unitOfMeasureMultiplier = value;
                    return _unitOfMeasureMultiplier;
                }, _unitOfMeasureMultiplier, UnitOfMeasureMultiplierSelector); 
            }
    }
    
    /// <summary>
    /// The amount associated with the InvoiceItem
    /// </summary>
    [DataMember]
    public decimal Amount
    {
        get { return _amount; }
            set 
            { 
                SetPropertyValueAndDetectChanges(o =>
                {
                    _amount = value;
                    return _amount;
                }, _amount, AmountSelector); 
            }
    }
    
    /// <summary>
    /// The exported associated with the InvoiceItem
    /// </summary>
    [DataMember]
    public bool Exported
    {
        get { return _exported; }
            set 
            { 
                SetPropertyValueAndDetectChanges(o =>
                {
                    _exported = value;
                    return _exported;
                }, _exported, ExportedSelector); 
            }
    }
    
        
        
    }

}