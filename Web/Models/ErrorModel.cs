namespace Web.Models
{
    public class ErrorModel: UserAccesModel
    {
        public int? ErrorCode { get; set; } = 0;
        public bool Status { get; set; }
        public string? Message { get; set; }
    }

    public class UserAccesModel 
    {
        public string IdCategoria { get; set; }
        public string UserName { get; set; }
        public string Nombre { get; set; }
        public string? Apellido { get; set; }

    }
}
