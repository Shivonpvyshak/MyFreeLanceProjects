namespace BrownsIntranetApps.API.Helpers.ServiceResponse
{
    public interface IRestPages
    {
        /// <summary>
        /// Previous page
        /// </summary>
        string Previous { get; }

        /// <summary>
        /// Next page
        /// </summary>
        string Next { get; }

        /// <summary>
        /// Total page count
        /// </summary>
        string Total { get; }
    }

    /// <summary>
    /// Rest page
    /// </summary>
    public class RestPagesFactory
    {
        /// <summary>
        /// Factory method for creating IRestPages
        /// </summary>
        /// <param name="previous">Previous page</param>
        /// <param name="next">Next page</param>
        /// <param name="total">Total page count</param>
        /// <returns></returns>
        public static RestPages Create(string previous, string next, string total)
        {
            return new RestPages(previous, next, total);
        }
    }

    /// <summary>
    ///
    /// </summary>
    public class RestPages : IRestPages
    {
        /// <summary>
        /// The number of the previous page
        /// </summary>
        public string Previous { get; private set; }

        /// <summary>
        /// The number of the next page
        /// </summary>
        public string Next { get; private set; }

        /// <summary>
        /// Total page count
        /// </summary>
        public string Total { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="previous"></param>
        /// <param name="next"></param>
        /// <param name="total"></param>
        public RestPages(string previous, string next, string total)
        {
            Previous = previous;
            Next = next;
            Total = total;
        }

        /// <summary>
        ///
        /// </summary>
        public RestPages() { }
    }
}