using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Attachments
{
    public class AttachmentDto : TaggedDto
    {
        [Required, MaxLength(80)]
        public required string Title { get; set; }
        [Required, MaxLength(1024)]
        public required string Description { get; set; }
        public required LinkDto Content { get; set; }
    }
}
