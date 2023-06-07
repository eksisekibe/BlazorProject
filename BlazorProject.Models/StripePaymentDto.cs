namespace BlazorProject.Models
{
    public class StripePaymentDto
    {
        public string CourseName { get; set; }
        public decimal Amount { get; set; }
        public string ImageUrl { get; set; }
        public string ReturnUrl { get; set; }
    }
}
