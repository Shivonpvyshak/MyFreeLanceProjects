using System.Net;

namespace BrownsIntranetApps.API.Helpers.ServiceResponse
{
    public class RestStatusFactory
    {
        /// <summary>
        /// Factory method
        /// </summary>
        /// <param name="code">The http status code for the call</param>
        /// <param name="message">Message for the caller</param>
        /// <returns>Creates and returns the rest status</returns>
        public static RestStatus Create(HttpStatusCode code, string message)
        {
            return new RestStatus(code, message);
        }
    }

    public class RestStatus : IRestStatus
    {
        /// <summary>
        ///
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public RestStatus(HttpStatusCode code, string message)
        {
            //this.Code = code;
            this.Message = message;
        }

        /// <summary>
        ///
        /// </summary>
        public RestStatus()
        {
        }
    }
}