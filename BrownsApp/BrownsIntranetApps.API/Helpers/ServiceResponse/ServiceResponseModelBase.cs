using BrownsIntranetApps.API.Helpers.ServiceResponse;

namespace BrownsIntranetApps.API.Helpers.ResponseBuilder
{
    public abstract class ServiceResponseModelBase : IServiceResponseModel
    {
        /// <summary>
        /// Version of the service API
        /// </summary>
        public double ApiVersion { get; set; }

        /// <summary>
        /// The status of the call
        /// </summary>
        public RestStatus Status { get; set; }

        /// <summary>
        /// Pages, if the interface is paged
        /// </summary>
        public RestPages Pages { get; set; }
    }
}