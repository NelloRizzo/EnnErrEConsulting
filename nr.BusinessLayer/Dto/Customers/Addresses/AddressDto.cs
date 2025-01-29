namespace nr.BusinessLayer.Dto.Customers.Addresses
{
    /// <summary>
    /// Classe base per gli indirizzi.
    /// </summary>
    public abstract class AddressDto : BaseDto
    {
        /// <summary>
        /// Indica se si tratta di un indirizzo di lavoro.
        /// </summary>
        public bool IsBusiness { get; set; }
    }
}