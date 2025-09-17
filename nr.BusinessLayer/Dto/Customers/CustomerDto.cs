using nr.BusinessLayer.Dto.Customers.Addresses;
using nr.BusinessLayer.Dto.Operators;
using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Customers
{
    /// <summary>
    /// Classe base per i clienti.
    /// </summary>
    public abstract class CustomerDto : BaseDto
    {
        /// <summary>
        /// Nome con cui il cliente viene visualizzato.
        /// </summary>
        public abstract string DisplayName { get; }
        public IEnumerable<UserDto> Users { get; set; } = [];
        /// <summary>
        /// Indirizzo postale di residenza/sede legale.
        /// </summary>
        [Required]
        public required PostalAddressDto BusinessAddress { get; set; }
        /// <summary>
        /// Eventuali ulteriori indirizzi.
        /// </summary>
        public IEnumerable<AddressDto> Addresses { get; set; } = [];
    }
}
