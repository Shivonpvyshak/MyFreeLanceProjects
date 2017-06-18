namespace BrownsIntranetApps.DTO
{
    public class CustomerDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string BillingContact { get; set; }
        public string BillingEmail { get; set; }
        public string BillingPhone { get; set; }
        public string TaxExcemptNumber { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public TypeCodeDTO State { get; set; }
        public bool IsShippingSameAsAddress { get; set; }
        public string Zip { get; set; }
        public string ShippingAddress1 { get; set; }
        public string ShippingAddress2 { get; set; }
        public string ShippingCity { get; set; }
        public TypeCodeDTO ShippingState { get; set; }
        public string ShippingZip { get; set; }
        public string TaxJurisdiction { get; set; }
        public string TaxClassification { get; set; }
        public string Notes { get; set; }
        public bool IsCustomerTaggedInInvoice { get; set; }

        public bool IsCustomerAlreadyExist { get; set; }
    }
}