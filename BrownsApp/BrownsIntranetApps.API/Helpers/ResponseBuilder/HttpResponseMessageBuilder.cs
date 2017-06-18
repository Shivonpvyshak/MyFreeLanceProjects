using BrownsIntranetApps.API.Helpers.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using TaxonomyRepositoryServices.WebService.Models.ServiceResponses;

namespace BrownsIntranetApps.API.Helpers.ResponseBuilder
{
    public class HttpResponseMessageBuilder : IHttpResponseMessageBuilder
    {
        /// <summary>
        /// Used to build an HttpResponseMessage, given a generic object and Request.
        /// </summary>
        /// <param name="value">A generic object</param>
        /// <param name="httpRequestMessage">A controller's HttpRequestMessage</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public HttpResponseMessage GetSimpleResponse<T>(T value, HttpRequestMessage httpRequestMessage)
        {
            return httpRequestMessage.CreateResponse(HttpStatusCode.OK, value);
        }

        /// <summary>
        /// Used to build an HttpResponseMessage, given a generic IEnumberable and Request.
        /// </summary>
        /// <param name="enumerable">A generic IEnumerable</param>
        /// <param name="httpRequestMessage">A controller's HttpRequestMessage</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public HttpResponseMessage GetResponse<T>(IEnumerable<T> enumerable, HttpRequestMessage httpRequestMessage)
        {
            ServiceResponseListModel<T> result;

            try
            {
                result = new ServiceResponseBuilder<ServiceResponseListModel<T>>().
                    WithApiVersion(1.0).
                    WithStatus(RestStatusFactory.Create(HttpStatusCode.OK, "OK")).
                    WithPages(null).
                    Build();

                result.Data = enumerable;
            }
            catch (Exception ex)
            {
                result = new ServiceResponseBuilder<ServiceResponseListModel<T>>().
                    WithApiVersion(1.0).
                    WithStatus(RestStatusFactory.Create(HttpStatusCode.OK, ex.Message)).
                    WithPages(null).
                    Build();

                return httpRequestMessage.CreateResponse(HttpStatusCode.InternalServerError, result);
            }

            return httpRequestMessage.CreateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Used to build a failure HttpResponseMessage, given an error message and Request.
        /// </summary>
        /// <param name="errorMessage">Error message as string</param>
        /// <param name="httpRequestMessage">A controller's HttpRequestMessage</param>
        /// <returns></returns>
        public HttpResponseMessage GetFailedValidationResponse(string errorMessage, HttpRequestMessage httpRequestMessage)
        {
            var failedValidationResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(errorMessage)
            };
            return failedValidationResponse;
        }
    }
}