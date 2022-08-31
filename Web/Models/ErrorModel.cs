namespace Web.Models
{
    public class ErrorModel
    {
        public int? ErrorCode { get; set; } = 0;
        public bool Status { get; set; }
        public string? Message { get; set; }
    }
}
