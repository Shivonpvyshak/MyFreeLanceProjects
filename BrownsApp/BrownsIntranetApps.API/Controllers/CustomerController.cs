using BrownsIntranetApps.API.Helpers.ResponseBuilder;
using BrownsIntranetApps.BL;
using BrownsIntranetApps.BL.Interface;
using BrownsIntranetApps.Common;
using BrownsIntranetApps.DTO;
using System;
using System.Data.SqlClient;
using System.Net.Http;
using System.Web.Http;

namespace BrownsIntranetApps.API.Controllers
{
    public class CustomerController : ApiController
    {
        private ICustomerBL _customerBL;
        private IHttpResponseMessageBuilder _httpResponseMessageBuilder;

        public CustomerController()
        {
            _customerBL = new CustomerBL();
            _httpResponseMessageBuilder = new HttpResponseMessageBuilder();
        }

        [Route("API/Customer/Get/")]
        [HttpGet]
        public HttpResponseMessage Get(int customerId)
        {
            return _httpResponseMessageBuilder.GetSimpleResponse(_customerBL.Get(customerId), Request);
        }

        [Route("API/Customer/GetAll/")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            return _httpResponseMessageBuilder.GetResponse(_customerBL.GetAll(), Request);
        }

        [Route("API/Customer/Home/GetAll/")]
        [HttpGet]
        public HttpResponseMessage GetAllCustomerForHome()
        {
            return _httpResponseMessageBuilder.GetResponse(_customerBL.GetAllForHome(), Request);
        }

        [Route("API/Customer/List")]
        [HttpGet]
        public HttpResponseMessage GetCustomerList()
        {
            return _httpResponseMessageBuilder.GetResponse(_customerBL.GetAllWithAddress(), Request);
        }

        [Route("API/Customer/Add/")]
        [HttpPost]
        public HttpResponseMessage Post(CustomerDTO customerDTO)
        {
            try
            {
                if (customerDTO == null) return null;
                if(customerDTO.ID>0)
                {
                    return _httpResponseMessageBuilder.GetSimpleResponse(_customerBL.Update(customerDTO), Request);
                }
                return _httpResponseMessageBuilder.GetSimpleResponse(_customerBL.Add(customerDTO), Request);
            }
            catch (System.Exception ex)
            {
                ExceptionHandler exceptionHandler = new ExceptionHandler();
                exceptionHandler.WrapLogException(ex);
                return null;
            }
        }

        [Route("API/Customer/Update/")]
        [HttpPost]
        public HttpResponseMessage Put(CustomerDTO customerDTO)
        {
            try
            {
                if (customerDTO == null) return null;
                return _httpResponseMessageBuilder.GetSimpleResponse(_customerBL.Update(customerDTO), Request);
            }
            catch (System.Exception ex)
            {
                ExceptionHandler exceptionHandler = new ExceptionHandler();
                exceptionHandler.WrapLogException(ex);
                return null;
            }
        }

        [Route("API/Customer/Delete/")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                return _httpResponseMessageBuilder.GetSimpleResponse(_customerBL.Delete(id), Request);
            }
            
            catch (Exception ex)
            {
                ExceptionHandler exceptionHandler = new ExceptionHandler();
                exceptionHandler.WrapLogException(ex);
                return null;
            }
        }
    }
}