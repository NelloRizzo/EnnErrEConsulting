using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Customers
{
    public class PersonDto : CustomerDto
    {
        [Required(AllowEmptyStrings = false), MaxLength(25)]
        public required string FirstName { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(25)]
        public required string LastName { get; set; }
        [MaxLength(25)]
        public string? Nickname { get; set; }
        public override string DisplayName => Nickname ?? $"{FirstName} {LastName}";
    }
}
