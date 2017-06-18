using BrownsIntranetApps.BL.Interface;
using BrownsIntranetApps.BL.Mappers;
using BrownsIntranetApps.Common;
using BrownsIntranetApps.DAL.UOW;
using BrownsIntranetApps.DTO;
using BrownsIntranetApps.Entity.SQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BrownsIntranetApps.BL
{
    public class CustomerBL : ICustomerBL
    {
        private readonly BHEUnitOfWork _bheUOW;
        private CustomerMapper mapper;

        public CustomerBL()
        {
            BrownsAppDBEntities1 _bheDBContext = new BrownsAppDBEntities1();
            _bheUOW = new BHEUnitOfWork(_bheDBContext);
        }

        public CustomerDTO Get(int customerId)
        {
            try
            {
                var customer = _bheUOW.CustomerRepository.Query().Where(x => x.ID == customerId).FirstOrDefault();
               
                mapper = new CustomerMapper();

                return mapper.CustomerDTOMapper(customer);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<CustomerDTO> GetAll()
        {
            mapper = new CustomerMapper();
            var customers = _bheUOW.CustomerRepository.Query();
            return customers.ToList().ConvertAll(mapper.CustomerDTOMapper);
        }

        public IEnumerable<CustomerHomeDTO> GetAllForHome()
        {
            mapper = new CustomerMapper();
            var customers = _bheUOW.CustomerRepository.Query();
            return customers.ToList().ConvertAll(mapper.CustomerHomeDTOMapper);
        }

        public IEnumerable<CustomerListDTO> GetAllWithAddress()
        {
            mapper = new CustomerMapper();
            var customers = _bheUOW.CustomerRepository.Query();
            return customers.ToList().ConvertAll(mapper.CustomerListDTOMapper);
        }

        public CustomerDTO Add(CustomerDTO customerDTO)
        {
            try
            {
                customerDTO.IsCustomerAlreadyExist = false;
                mapper = new CustomerMapper();

                customerDTO.ID = _bheUOW.CustomerRepository.Add(mapper.CustomerEntityMapper(customerDTO));

                _bheUOW.SaveChanges();
                return customerDTO;
            }
            catch (Exception ex)
            {
                ExceptionHandler exceptionHandler = new ExceptionHandler();
                exceptionHandler.WrapLogException(ex);
                if (((SqlException)ex.InnerException.InnerException).Number == 2627)
                {
                    customerDTO.IsCustomerAlreadyExist = true;
                    return customerDTO;
                }
                else
                    return null;

               
            }
        }

        public int Update(CustomerDTO customer)
        {
            if (customer != null)
            {
                mapper = new CustomerMapper();
                var existingCustomer = _bheUOW.CustomerRepository.Query().SingleOrDefault(x => x.ID == customer.ID);
                if (existingCustomer != null)
                {
                    if (customer != null)
                    {
                        
                        existingCustomer.Name = customer.Name;
                        existingCustomer.Contact = customer.Contact;
                        existingCustomer.Position = customer.Position;
                        existingCustomer.PhoneNumber = customer.PhoneNumber;
                        existingCustomer.Fax = customer.Fax;
                        existingCustomer.Email = customer.Email;
                        existingCustomer.BillingContact = customer.BillingContact;
                        existingCustomer.BillingEmail = customer.BillingEmail;
                        existingCustomer.BillingPhone = customer.BillingPhone;
                        existingCustomer.TaxExcemptNumber = customer.TaxExcemptNumber;
                        existingCustomer.Address1 = customer.Address1;
                        existingCustomer.Address2 = customer.Address2;
                        existingCustomer.City = customer.City;
                        existingCustomer.State = customer.State.TypeCode;
                        existingCustomer.StateID = customer.State.TypeCodeID;
                        existingCustomer.Zip = customer.Zip;

                        existingCustomer.ShippingAddress1 = customer.ShippingAddress1;
                        existingCustomer.ShippingAddress2 = customer.ShippingAddress2;
                        existingCustomer.ShippingCity = customer.ShippingCity;
                        existingCustomer.ShippingState = customer.ShippingState.TypeCode;
                        existingCustomer.ShippingStateID = customer.State.TypeCodeID;
                        existingCustomer.ShippingZip = customer.ShippingZip;
                        existingCustomer.TaxClassification = customer.TaxClassification;
                        existingCustomer.TaxJurisdiction = customer.TaxJurisdiction;
                        existingCustomer.Notes = customer.Notes;

                        existingCustomer.AddedBy = "Admin";
                        existingCustomer.AddedDate = DateTime.Now;
                        existingCustomer.IsShippingSameAsAddress = customer.IsShippingSameAsAddress;
                        existingCustomer = mapper.CustomerEntityMapper(customer);
                    }
                    
                 
                    _bheUOW.SaveChanges();
                }
            }
            return customer.ID;
        }

        public int Delete(int id)
        {
            try
            {
                var deletedCustomerId = _bheUOW.CustomerRepository.Delete(id);
                _bheUOW.SaveChanges();
                return deletedCustomerId;
            }
            
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}