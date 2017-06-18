namespace BrownsIntranetApps.Common
{
    public class CommonMethods
    {
        public string GetCompanyName(string companyID)
        {
            switch (companyID)
            {
                case "1":
                    return "JLG";

                case "2":
                    return "SkyTrak";

                case "3":
                    return "Gradall";

                case "4":
                    return "Lull";

                default:
                    return "";
            }
        }
    }
}