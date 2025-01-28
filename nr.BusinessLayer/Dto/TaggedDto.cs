namespace nr.BusinessLayer.Dto
{
    /// <summary>
    /// Un DTO al quale sono collegati dei tags.
    /// </summary>
    public class TaggedDto : BaseDto
    {
        /// <summary>
        /// Tags collegati.
        /// </summary>
        public IEnumerable<string> Tags { get; set; } = [];
    }
}
