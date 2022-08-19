namespace Web.Models
{
    public class UserAccountModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Token { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Validate { get; set; }
        public string? Error { get; set; }
    }
}
