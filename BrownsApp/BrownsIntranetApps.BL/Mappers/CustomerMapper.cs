using BrownsIntranetApps.DTO;
using BrownsIntranetApps.Entity.SQL;
using System;

namespace BrownsIntranetApps.BL.Mappers
{
    public class CustomerMapper
    {
        public CustomerDTO CustomerDTOMapper(Customer customer)
        {
            CustomerDTO customerDTO = new CustomerDTO();

            customerDTO.ID = customer.ID;
            customerDTO.Name = customer.Name;
            customerDTO.Contact = customer.Contact;
            customerDTO.Position = customer.Position;
            customerDTO.PhoneNumber = customer.PhoneNumber;
            customerDTO.Fax = customer.Fax;
            customerDTO.Email = customer.Email;
            customerDTO.BillingContact = customer.BillingContact;
            customerDTO.BillingEmail = customer.BillingEmail;
            customerDTO.BillingPhone = customer.BillingPhone;
            customerDTO.TaxExcemptNumber = customer.TaxExcemptNumber;

            customerDTO.Address1 = customer.Address1;
            customerDTO.Address2 = customer.Address2;
            customerDTO.City = customer.City;
            customerDTO.Zip = customer.Zip;
            customerDTO.State = new TypeCodeDTO();
            customerDTO.State.TypeCode = customer.State;
            customerDTO.State.TypeCodeID = customer.StateID.GetValueOrDefault();
            customerDTO.IsShippingSameAsAddress = customer.IsShippingSameAsAddress.GetValueOrDefault();
            if (customer.ShippingAddress1 != "" && customer.ShippingAddress1 != null)
            {
                customerDTO.ShippingAddress1 = customer.ShippingAddress1;
                customerDTO.ShippingAddress2 = customer.ShippingAddress2;
                customerDTO.ShippingCity = customer.ShippingCity;
                customerDTO.ShippingZip = customer.ShippingZip;
                customerDTO.ShippingState = new TypeCodeDTO();
                customerDTO.ShippingState.TypeCode = customer.ShippingState;
                customerDTO.ShippingState.TypeCodeID = customer.ShippingStateID.GetValueOrDefault();
            }
            customerDTO.TaxJurisdiction = customer.TaxJurisdiction;
            customerDTO.TaxClassification = customer.TaxClassification;
            customerDTO.Notes = customer.Notes;
            if (customer.Invoices.Count > 0)
            {
                customerDTO.IsCustomerTaggedInInvoice = true;
            }
            return customerDTO;
        }

        public CustomerHomeDTO CustomerHomeDTOMapper(Customer customer)
        {
            CustomerHomeDTO customerDTO = new CustomerHomeDTO();

            customerDTO.ID = customer.ID;
            customerDTO.Name = customer.Name;
            customerDTO.Contact = customer.Contact;
            customerDTO.Position = customer.Position;
            customerDTO.PhoneNumber = customer.PhoneNumber;
            customerDTO.Fax = customer.Fax;
            customerDTO.Email = customer.Email;
            customerDTO.BillingContact = customer.BillingContact;
            customerDTO.BillingEmail = customer.BillingEmail;
            customerDTO.BillingPhone = customer.BillingPhone;
            customerDTO.TaxExcemptNumber = customer.TaxExcemptNumber;
            customerDTO.TaxJurisdiction = customer.TaxJurisdiction;
            customerDTO.TaxClassification = customer.TaxClassification;

            return customerDTO;
        }

        public CustomerListDTO CustomerListDTOMapper(Customer customer)
        {
            CustomerListDTO customerDTO = new CustomerListDTO();

            customerDTO.ID = customer.ID;
            customerDTO.value = customer.Name;
            customerDTO.Address1 = customer.Address1;
            customerDTO.Address2 = customer.Address2;
            customerDTO.City = customer.City;
            customerDTO.Zip = customer.Zip;
            customerDTO.State = customer.State;
            customerDTO.ShippingAddress1 = customer.ShippingAddress1;
            customerDTO.ShippingAddress2 = customer.ShippingAddress2;
            customerDTO.ShippingCity = customer.ShippingCity;
            customerDTO.ShippingZip = customer.ShippingZip;
            customerDTO.ShippingState = customer.ShippingState;

            return customerDTO;
        }

        public Customer CustomerEntityMapper(CustomerDTO customerDTO)
        {
            Customer customer = new Customer();
            if (customerDTO != null)
            {
                //  ID = customerDTO.ID,
                customer.Name = customerDTO.Name;
                customer.Contact = customerDTO.Contact;
                customer.Position = customerDTO.Position;
                customer.PhoneNumber = customerDTO.PhoneNumber;
                customer.Fax = customerDTO.Fax;
                customer.Email = customerDTO.Email;
                customer.BillingContact = customerDTO.BillingContact;
                customer.BillingEmail = customerDTO.BillingEmail;
                customer.BillingPhone = customerDTO.BillingPhone;
                customer.TaxExcemptNumber = customerDTO.TaxExcemptNumber;
                customer.Address1 = customerDTO.Address1;
                customer.Address2 = customerDTO.Address2;
                customer.City = customerDTO.City;
                customer.State = customerDTO.State.TypeCode;
                customer.StateID = customerDTO.State.TypeCodeID;
                customer.Zip = customerDTO.Zip;

                customer.ShippingAddress1 = customerDTO.ShippingAddress1;
                customer.ShippingAddress2 = customerDTO.ShippingAddress2;
                customer.ShippingCity = customerDTO.ShippingCity;
                customer.ShippingState = customerDTO.ShippingState.TypeCode;
                customer.ShippingStateID = customerDTO.State.TypeCodeID;
                customer.ShippingZip = customerDTO.ShippingZip;
                customer.TaxClassification = customerDTO.TaxClassification;
                customer.TaxJurisdiction = customerDTO.TaxJurisdiction;
                customer.Notes = customerDTO.Notes;

                customer.AddedBy = "Admin";
                customer.AddedDate = DateTime.Now;
                customer.IsShippingSameAsAddress = customerDTO.IsShippingSameAsAddress;
                return customer;
            }
            else
                return null;
        }
    }
}