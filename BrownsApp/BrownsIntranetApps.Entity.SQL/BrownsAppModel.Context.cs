﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BrownsIntranetApps.Entity.SQL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BrownsAppDBEntities1 : DbContext
    {
        public BrownsAppDBEntities1()
            : base("name=BrownsAppDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceLabor> InvoiceLabors { get; set; }
        public virtual DbSet<InvoiceService> InvoiceServices { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<ExceptionHistory> ExceptionHistories { get; set; }
        public virtual DbSet<Customer_TaxClassification> Customer_TaxClassification { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Repair> Repairs { get; set; }
        public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }
    
        public virtual int AddException(string source, string message, string stackTrace, Nullable<System.DateTime> exceptionDate)
        {
            var sourceParameter = source != null ?
                new ObjectParameter("Source", source) :
                new ObjectParameter("Source", typeof(string));
    
            var messageParameter = message != null ?
                new ObjectParameter("Message", message) :
                new ObjectParameter("Message", typeof(string));
    
            var stackTraceParameter = stackTrace != null ?
                new ObjectParameter("StackTrace", stackTrace) :
                new ObjectParameter("StackTrace", typeof(string));
    
            var exceptionDateParameter = exceptionDate.HasValue ?
                new ObjectParameter("ExceptionDate", exceptionDate) :
                new ObjectParameter("ExceptionDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddException", sourceParameter, messageParameter, stackTraceParameter, exceptionDateParameter);
        }
    
        public virtual int GetPartReportData(string make, string model, string serialNumberRange, string partNumber, string partManual, string partDescription)
        {
            var makeParameter = make != null ?
                new ObjectParameter("Make", make) :
                new ObjectParameter("Make", typeof(string));
    
            var modelParameter = model != null ?
                new ObjectParameter("Model", model) :
                new ObjectParameter("Model", typeof(string));
    
            var serialNumberRangeParameter = serialNumberRange != null ?
                new ObjectParameter("SerialNumberRange", serialNumberRange) :
                new ObjectParameter("SerialNumberRange", typeof(string));
    
            var partNumberParameter = partNumber != null ?
                new ObjectParameter("PartNumber", partNumber) :
                new ObjectParameter("PartNumber", typeof(string));
    
            var partManualParameter = partManual != null ?
                new ObjectParameter("PartManual", partManual) :
                new ObjectParameter("PartManual", typeof(string));
    
            var partDescriptionParameter = partDescription != null ?
                new ObjectParameter("PartDescription", partDescription) :
                new ObjectParameter("PartDescription", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetPartReportData", makeParameter, modelParameter, serialNumberRangeParameter, partNumberParameter, partManualParameter, partDescriptionParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> UpdatePartsPrice(string partNumber, string listPrice)
        {
            var partNumberParameter = partNumber != null ?
                new ObjectParameter("PartNumber", partNumber) :
                new ObjectParameter("PartNumber", typeof(string));
    
            var listPriceParameter = listPrice != null ?
                new ObjectParameter("ListPrice", listPrice) :
                new ObjectParameter("ListPrice", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("UpdatePartsPrice", partNumberParameter, listPriceParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> DeleteInvoice(string invoiceNumber)
        {
            var invoiceNumberParameter = invoiceNumber != null ?
                new ObjectParameter("InvoiceNumber", invoiceNumber) :
                new ObjectParameter("InvoiceNumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("DeleteInvoice", invoiceNumberParameter);
        }
    
        public virtual ObjectResult<GetCustomerReportData_Result> GetCustomerReportData(Nullable<System.DateTime> fromDate, Nullable<System.DateTime> toDate, string customerName)
        {
            var fromDateParameter = fromDate.HasValue ?
                new ObjectParameter("FromDate", fromDate) :
                new ObjectParameter("FromDate", typeof(System.DateTime));
    
            var toDateParameter = toDate.HasValue ?
                new ObjectParameter("ToDate", toDate) :
                new ObjectParameter("ToDate", typeof(System.DateTime));
    
            var customerNameParameter = customerName != null ?
                new ObjectParameter("CustomerName", customerName) :
                new ObjectParameter("CustomerName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetCustomerReportData_Result>("GetCustomerReportData", fromDateParameter, toDateParameter, customerNameParameter);
        }
    
        public virtual ObjectResult<GetSalesReportData_Result> GetSalesReportData(Nullable<System.DateTime> fromDate, Nullable<System.DateTime> toDate)
        {
            var fromDateParameter = fromDate.HasValue ?
                new ObjectParameter("FromDate", fromDate) :
                new ObjectParameter("FromDate", typeof(System.DateTime));
    
            var toDateParameter = toDate.HasValue ?
                new ObjectParameter("ToDate", toDate) :
                new ObjectParameter("ToDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetSalesReportData_Result>("GetSalesReportData", fromDateParameter, toDateParameter);
        }
    }
}
