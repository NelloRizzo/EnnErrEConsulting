using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Customers
{
    [Table("People")]
    public class PersonEntity : CustomerEntity
    {
        [Required(AllowEmptyStrings = false), MaxLength(25)]
        public required string FirstName { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(25)]
        public required string LastName { get; set; }
        [MaxLength(25)]
        public string? Nickname { get; set; }
    }
}
