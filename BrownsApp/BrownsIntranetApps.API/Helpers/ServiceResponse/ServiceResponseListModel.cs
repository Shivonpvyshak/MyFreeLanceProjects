using System.Collections.Generic;
using System.Linq;

namespace BrownsIntranetApps.API.Helpers.ResponseBuilder
{
    public class ServiceResponseListModel<T> : ServiceResponseModelBase
    {
        /// <summary>
        /// Default contructor
        /// </summary>
        public ServiceResponseListModel()
        {
            this.Data = Enumerable.Empty<T>();
        }

        /// <summary>
        /// Payload being returned
        /// </summary>
        public IEnumerable<T> Data { get; set; }
    }
}