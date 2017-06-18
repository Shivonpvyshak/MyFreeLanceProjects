using BrownsIntranetApps.API.Helpers.ServiceResponse;

namespace TaxonomyRepositoryServices.WebService.Models.ServiceResponses
{
    /// <summary>
    /// Builder for a service response
    /// </summary>
    /// <typeparam name="T">Type of response being returned</typeparam>
    public class ServiceResponseBuilder<T> where T : IServiceResponseModel, new()
    {
        /// <summary>
        /// Version of the service API
        /// </summary>
        /// <param name="apiVersion">API version</param>
        /// <returns>Service Response Builder</returns>
        public ServiceResponseBuilder<T> WithApiVersion(double apiVersion)
        {
            this._apiVersion = apiVersion;
            return this;
        }

        /// <summary>
        /// The status of the service
        /// </summary>
        /// <param name="status">Status object</param>
        /// <returns>Service Response Builder</returns>
        public ServiceResponseBuilder<T> WithStatus(RestStatus status)
        {
            this._status = status;
            return this;
        }

        /// <summary>
        /// Pages in the result
        /// </summary>
        /// <param name="pages">Pages to return</param>
        /// <returns>Service Response Builder</returns>
        public ServiceResponseBuilder<T> WithPages(RestPages pages)
        {
            this._pages = pages;
            return this;
        }

        /// <summary>
        /// Creates the response object
        /// </summary>
        /// <returns>Responce object of type T</returns>
        public T Build()
        {
            T result = new T();

            result.ApiVersion = _apiVersion;
            result.Status = _status;
            result.Pages = _pages;

            return result;
        }

        private double _apiVersion;
        private RestStatus _status;
        private RestPages _pages;
    }
}