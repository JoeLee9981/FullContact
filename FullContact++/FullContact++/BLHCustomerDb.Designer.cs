﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]

namespace FullContact__
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class BLHCustomerDbEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new BLHCustomerDbEntities object using the connection string found in the 'BLHCustomerDbEntities' section of the application configuration file.
        /// </summary>
        public BLHCustomerDbEntities() : base("name=BLHCustomerDbEntities", "BLHCustomerDbEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new BLHCustomerDbEntities object.
        /// </summary>
        public BLHCustomerDbEntities(string connectionString) : base(connectionString, "BLHCustomerDbEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new BLHCustomerDbEntities object.
        /// </summary>
        public BLHCustomerDbEntities(EntityConnection connection) : base(connection, "BLHCustomerDbEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<BLHCustomer> BLHCustomers
        {
            get
            {
                if ((_BLHCustomers == null))
                {
                    _BLHCustomers = base.CreateObjectSet<BLHCustomer>("BLHCustomers");
                }
                return _BLHCustomers;
            }
        }
        private ObjectSet<BLHCustomer> _BLHCustomers;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Order> Orders
        {
            get
            {
                if ((_Orders == null))
                {
                    _Orders = base.CreateObjectSet<Order>("Orders");
                }
                return _Orders;
            }
        }
        private ObjectSet<Order> _Orders;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Catalog> Catalogs
        {
            get
            {
                if ((_Catalogs == null))
                {
                    _Catalogs = base.CreateObjectSet<Catalog>("Catalogs");
                }
                return _Catalogs;
            }
        }
        private ObjectSet<Catalog> _Catalogs;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the BLHCustomers EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToBLHCustomers(BLHCustomer bLHCustomer)
        {
            base.AddObject("BLHCustomers", bLHCustomer);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Orders EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToOrders(Order order)
        {
            base.AddObject("Orders", order);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Catalogs EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToCatalogs(Catalog catalog)
        {
            base.AddObject("Catalogs", catalog);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="CustomerDbModel", Name="BLHCustomer")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class BLHCustomer : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new BLHCustomer object.
        /// </summary>
        /// <param name="customerID">Initial value of the CustomerID property.</param>
        /// <param name="firstName">Initial value of the FirstName property.</param>
        /// <param name="lastName">Initial value of the LastName property.</param>
        /// <param name="address">Initial value of the Address property.</param>
        /// <param name="city">Initial value of the City property.</param>
        /// <param name="state">Initial value of the State property.</param>
        /// <param name="zip">Initial value of the Zip property.</param>
        /// <param name="phone">Initial value of the Phone property.</param>
        public static BLHCustomer CreateBLHCustomer(global::System.Int32 customerID, global::System.String firstName, global::System.String lastName, global::System.String address, global::System.String city, global::System.String state, global::System.String zip, global::System.String phone)
        {
            BLHCustomer bLHCustomer = new BLHCustomer();
            bLHCustomer.CustomerID = customerID;
            bLHCustomer.FirstName = firstName;
            bLHCustomer.LastName = lastName;
            bLHCustomer.Address = address;
            bLHCustomer.City = city;
            bLHCustomer.State = state;
            bLHCustomer.Zip = zip;
            bLHCustomer.Phone = phone;
            return bLHCustomer;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 CustomerID
        {
            get
            {
                return _CustomerID;
            }
            set
            {
                if (_CustomerID != value)
                {
                    OnCustomerIDChanging(value);
                    ReportPropertyChanging("CustomerID");
                    _CustomerID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("CustomerID");
                    OnCustomerIDChanged();
                }
            }
        }
        private global::System.Int32 _CustomerID;
        partial void OnCustomerIDChanging(global::System.Int32 value);
        partial void OnCustomerIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                OnFirstNameChanging(value);
                ReportPropertyChanging("FirstName");
                _FirstName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("FirstName");
                OnFirstNameChanged();
            }
        }
        private global::System.String _FirstName;
        partial void OnFirstNameChanging(global::System.String value);
        partial void OnFirstNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                OnLastNameChanging(value);
                ReportPropertyChanging("LastName");
                _LastName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("LastName");
                OnLastNameChanged();
            }
        }
        private global::System.String _LastName;
        partial void OnLastNameChanging(global::System.String value);
        partial void OnLastNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Address
        {
            get
            {
                return _Address;
            }
            set
            {
                OnAddressChanging(value);
                ReportPropertyChanging("Address");
                _Address = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Address");
                OnAddressChanged();
            }
        }
        private global::System.String _Address;
        partial void OnAddressChanging(global::System.String value);
        partial void OnAddressChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Apt
        {
            get
            {
                return _Apt;
            }
            set
            {
                OnAptChanging(value);
                ReportPropertyChanging("Apt");
                _Apt = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Apt");
                OnAptChanged();
            }
        }
        private global::System.String _Apt;
        partial void OnAptChanging(global::System.String value);
        partial void OnAptChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String City
        {
            get
            {
                return _City;
            }
            set
            {
                OnCityChanging(value);
                ReportPropertyChanging("City");
                _City = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("City");
                OnCityChanged();
            }
        }
        private global::System.String _City;
        partial void OnCityChanging(global::System.String value);
        partial void OnCityChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String State
        {
            get
            {
                return _State;
            }
            set
            {
                OnStateChanging(value);
                ReportPropertyChanging("State");
                _State = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("State");
                OnStateChanged();
            }
        }
        private global::System.String _State;
        partial void OnStateChanging(global::System.String value);
        partial void OnStateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Zip
        {
            get
            {
                return _Zip;
            }
            set
            {
                OnZipChanging(value);
                ReportPropertyChanging("Zip");
                _Zip = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Zip");
                OnZipChanged();
            }
        }
        private global::System.String _Zip;
        partial void OnZipChanging(global::System.String value);
        partial void OnZipChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                OnPhoneChanging(value);
                ReportPropertyChanging("Phone");
                _Phone = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Phone");
                OnPhoneChanged();
            }
        }
        private global::System.String _Phone;
        partial void OnPhoneChanging(global::System.String value);
        partial void OnPhoneChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Email
        {
            get
            {
                return _Email;
            }
            set
            {
                OnEmailChanging(value);
                ReportPropertyChanging("Email");
                _Email = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Email");
                OnEmailChanged();
            }
        }
        private global::System.String _Email;
        partial void OnEmailChanging(global::System.String value);
        partial void OnEmailChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String AVS
        {
            get
            {
                return _AVS;
            }
            set
            {
                OnAVSChanging(value);
                ReportPropertyChanging("AVS");
                _AVS = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("AVS");
                OnAVSChanged();
            }
        }
        private global::System.String _AVS;
        partial void OnAVSChanging(global::System.String value);
        partial void OnAVSChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Birthday
        {
            get
            {
                return _Birthday;
            }
            set
            {
                OnBirthdayChanging(value);
                ReportPropertyChanging("Birthday");
                _Birthday = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Birthday");
                OnBirthdayChanged();
            }
        }
        private global::System.String _Birthday;
        partial void OnBirthdayChanging(global::System.String value);
        partial void OnBirthdayChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="CustomerDbModel", Name="Catalog")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Catalog : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Catalog object.
        /// </summary>
        /// <param name="productID">Initial value of the ProductID property.</param>
        public static Catalog CreateCatalog(global::System.Int32 productID)
        {
            Catalog catalog = new Catalog();
            catalog.ProductID = productID;
            return catalog;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ProductID
        {
            get
            {
                return _ProductID;
            }
            set
            {
                if (_ProductID != value)
                {
                    OnProductIDChanging(value);
                    ReportPropertyChanging("ProductID");
                    _ProductID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ProductID");
                    OnProductIDChanged();
                }
            }
        }
        private global::System.Int32 _ProductID;
        partial void OnProductIDChanging(global::System.Int32 value);
        partial void OnProductIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ProductName
        {
            get
            {
                return _ProductName;
            }
            set
            {
                OnProductNameChanging(value);
                ReportPropertyChanging("ProductName");
                _ProductName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ProductName");
                OnProductNameChanged();
            }
        }
        private global::System.String _ProductName;
        partial void OnProductNameChanging(global::System.String value);
        partial void OnProductNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Category
        {
            get
            {
                return _Category;
            }
            set
            {
                OnCategoryChanging(value);
                ReportPropertyChanging("Category");
                _Category = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Category");
                OnCategoryChanged();
            }
        }
        private global::System.String _Category;
        partial void OnCategoryChanging(global::System.String value);
        partial void OnCategoryChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ShortDescription
        {
            get
            {
                return _ShortDescription;
            }
            set
            {
                OnShortDescriptionChanging(value);
                ReportPropertyChanging("ShortDescription");
                _ShortDescription = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ShortDescription");
                OnShortDescriptionChanged();
            }
        }
        private global::System.String _ShortDescription;
        partial void OnShortDescriptionChanging(global::System.String value);
        partial void OnShortDescriptionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String FullDescription
        {
            get
            {
                return _FullDescription;
            }
            set
            {
                OnFullDescriptionChanging(value);
                ReportPropertyChanging("FullDescription");
                _FullDescription = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("FullDescription");
                OnFullDescriptionChanged();
            }
        }
        private global::System.String _FullDescription;
        partial void OnFullDescriptionChanging(global::System.String value);
        partial void OnFullDescriptionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> Price
        {
            get
            {
                return _Price;
            }
            set
            {
                OnPriceChanging(value);
                ReportPropertyChanging("Price");
                _Price = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Price");
                OnPriceChanged();
            }
        }
        private Nullable<global::System.Decimal> _Price;
        partial void OnPriceChanging(Nullable<global::System.Decimal> value);
        partial void OnPriceChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="CustomerDbModel", Name="Order")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Order : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Order object.
        /// </summary>
        /// <param name="orderNumber">Initial value of the OrderNumber property.</param>
        /// <param name="customerNumber">Initial value of the CustomerNumber property.</param>
        /// <param name="firstName">Initial value of the FirstName property.</param>
        /// <param name="lastName">Initial value of the LastName property.</param>
        /// <param name="zipCode">Initial value of the ZipCode property.</param>
        /// <param name="productList">Initial value of the ProductList property.</param>
        /// <param name="shippingCost">Initial value of the ShippingCost property.</param>
        /// <param name="totalCost">Initial value of the TotalCost property.</param>
        public static Order CreateOrder(global::System.Int32 orderNumber, global::System.Int32 customerNumber, global::System.String firstName, global::System.String lastName, global::System.String zipCode, global::System.String productList, global::System.Decimal shippingCost, global::System.Decimal totalCost)
        {
            Order order = new Order();
            order.OrderNumber = orderNumber;
            order.CustomerNumber = customerNumber;
            order.FirstName = firstName;
            order.LastName = lastName;
            order.ZipCode = zipCode;
            order.ProductList = productList;
            order.ShippingCost = shippingCost;
            order.TotalCost = totalCost;
            return order;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 OrderNumber
        {
            get
            {
                return _OrderNumber;
            }
            set
            {
                if (_OrderNumber != value)
                {
                    OnOrderNumberChanging(value);
                    ReportPropertyChanging("OrderNumber");
                    _OrderNumber = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("OrderNumber");
                    OnOrderNumberChanged();
                }
            }
        }
        private global::System.Int32 _OrderNumber;
        partial void OnOrderNumberChanging(global::System.Int32 value);
        partial void OnOrderNumberChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 CustomerNumber
        {
            get
            {
                return _CustomerNumber;
            }
            set
            {
                OnCustomerNumberChanging(value);
                ReportPropertyChanging("CustomerNumber");
                _CustomerNumber = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CustomerNumber");
                OnCustomerNumberChanged();
            }
        }
        private global::System.Int32 _CustomerNumber;
        partial void OnCustomerNumberChanging(global::System.Int32 value);
        partial void OnCustomerNumberChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                OnFirstNameChanging(value);
                ReportPropertyChanging("FirstName");
                _FirstName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("FirstName");
                OnFirstNameChanged();
            }
        }
        private global::System.String _FirstName;
        partial void OnFirstNameChanging(global::System.String value);
        partial void OnFirstNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                OnLastNameChanging(value);
                ReportPropertyChanging("LastName");
                _LastName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("LastName");
                OnLastNameChanged();
            }
        }
        private global::System.String _LastName;
        partial void OnLastNameChanging(global::System.String value);
        partial void OnLastNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String ZipCode
        {
            get
            {
                return _ZipCode;
            }
            set
            {
                OnZipCodeChanging(value);
                ReportPropertyChanging("ZipCode");
                _ZipCode = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("ZipCode");
                OnZipCodeChanged();
            }
        }
        private global::System.String _ZipCode;
        partial void OnZipCodeChanging(global::System.String value);
        partial void OnZipCodeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String ProductList
        {
            get
            {
                return _ProductList;
            }
            set
            {
                OnProductListChanging(value);
                ReportPropertyChanging("ProductList");
                _ProductList = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("ProductList");
                OnProductListChanged();
            }
        }
        private global::System.String _ProductList;
        partial void OnProductListChanging(global::System.String value);
        partial void OnProductListChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal ShippingCost
        {
            get
            {
                return _ShippingCost;
            }
            set
            {
                OnShippingCostChanging(value);
                ReportPropertyChanging("ShippingCost");
                _ShippingCost = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ShippingCost");
                OnShippingCostChanged();
            }
        }
        private global::System.Decimal _ShippingCost;
        partial void OnShippingCostChanging(global::System.Decimal value);
        partial void OnShippingCostChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal TotalCost
        {
            get
            {
                return _TotalCost;
            }
            set
            {
                OnTotalCostChanging(value);
                ReportPropertyChanging("TotalCost");
                _TotalCost = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("TotalCost");
                OnTotalCostChanged();
            }
        }
        private global::System.Decimal _TotalCost;
        partial void OnTotalCostChanging(global::System.Decimal value);
        partial void OnTotalCostChanged();

        #endregion
    
    }

    #endregion
    
}