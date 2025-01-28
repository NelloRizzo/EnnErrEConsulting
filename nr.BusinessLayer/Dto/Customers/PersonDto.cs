using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Customers
{
    /// <summary>
    /// Una persona.
    /// </summary>
    public class PersonDto : CustomerDto
    {
        /// <summary>
        /// Nome.
        /// </summary>
        [Required(AllowEmptyStrings = false), MaxLength(25)]
        public required string FirstName { get; set; }
        /// <summary>
        /// Cognome.
        /// </summary>
        [Required(AllowEmptyStrings = false), MaxLength(25)]
        public required string LastName { get; set; }
        /// <summary>
        /// Nomignolo.
        /// </summary>
        [MaxLength(25)]
        public string? Nickname { get; set; }
        /// <inheritdoc/>
        public override string DisplayName => Nickname ?? $"{FirstName} {LastName}";
    }
}
