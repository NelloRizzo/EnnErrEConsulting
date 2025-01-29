namespace nr.PresentationLayer.Controllers.Api.Models.Customers
{
    public class SearchByEmailModel
    {
        public required string Email { get; set; }
    }
    public class SearchByNameModel
    {
        public required string Name { get; set; }
    }
    public class SearchByCityModel
    {
        public string? City { get; set; }
        public string? Province { get; set; }
    }
}
