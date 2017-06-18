using System.Collections.Generic;
using System.Net.Http;

namespace BrownsIntranetApps.API.Helpers.ResponseBuilder
{
    public interface IHttpResponseMessageBuilder
    {
        /// <summary>
        /// Used to build an HttpResponseMessage, given an object and Request.
        /// </summary>
        /// <param name="value">A generic object</param>
        /// <param name="httpRequestMessage">A controller's HttpRequestMessage</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        HttpResponseMessage GetSimpleResponse<T>(T value, HttpRequestMessage httpRequestMessage);

        /// <summary>
        /// Used to build an HttpResponseMessage, given a generic IEnumberable and Request.
        /// </summary>
        /// <param name="enumerable">A generic IEnumerable</param>
        /// <param name="httpRequestMessage">A controller's HttpRequestMessage</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        HttpResponseMessage GetResponse<T>(IEnumerable<T> enumerable, HttpRequestMessage httpRequestMessage);

        /// <summary>
        /// Used to build a failure HttpResponseMessage, given an error message and Request.
        /// </summary>
        /// <param name="errorMessage">Error message as string</param>
        /// <param name="httpRequestMessage">A controller's HttpRequestMessage</param>
        /// <returns></returns>
        HttpResponseMessage GetFailedValidationResponse(string errorMessage, HttpRequestMessage httpRequestMessage);
    }
}