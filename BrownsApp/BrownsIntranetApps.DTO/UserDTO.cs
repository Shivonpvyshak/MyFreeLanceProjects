namespace BrownsIntranetApps.DTO
{
    public class UserDTO : BaseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmpCode { get; set; }
        public string Role { get; set; }
        public int IsActive { get; set; }
    }
}