using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Attachments
{
    public class ContentLinkDto : LinkDto
    {
        [Required, MaxLength(8192)]
        public required byte[] Content { get; set; }
    }
}
