namespace BrownsIntranetApps.API.Helpers.ServiceResponse
{
    public interface IServiceResponseModel
    {
        /// <summary>
        /// API call version
        /// </summary>
        double ApiVersion { get; set; }

        /// <summary>
        /// Service call status
        /// </summary>
        RestStatus Status { get; set; }

        /// <summary>
        /// Pages in call
        /// </summary>
        RestPages Pages { get; set; }
    }
}