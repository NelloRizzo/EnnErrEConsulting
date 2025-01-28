namespace nr.BusinessLayer.Dto
{
    public class TaggedDto : BaseDto
    {
        public IEnumerable<string> Tags { get; set; } = [];
    }
}
