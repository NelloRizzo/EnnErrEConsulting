using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Attachments
{
    /// <summary>
    /// Link ad un contenuto esterno.
    /// </summary>
    public class UrlLinkDto : LinkDto
    {
        [Required, MaxLength(512)]
        public required string Url { get; set; }
    }
}
