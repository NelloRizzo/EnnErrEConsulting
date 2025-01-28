using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Attachments
{
    public abstract class LinkDto : BaseDto
    {
        [Required, MaxLength(80)]
        public required string MimeType { get; set; }
    }
}