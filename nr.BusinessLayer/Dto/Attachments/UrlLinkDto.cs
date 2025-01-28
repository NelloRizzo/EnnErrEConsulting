using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Attachments
{
    public class UrlLinkDto : LinkDto
    {
        [Required, MaxLength(512)]
        public required string Url { get; set; }
    }
}
