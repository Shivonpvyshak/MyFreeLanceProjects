using System;

namespace BrownsIntranetApps.DTO
{
    public class LogsDTO
    {
        public int ID { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public Nullable<System.DateTime> ExceptionDate { get; set; }
    }
}