using nr.BusinessLayer.Dto.Attachments;
using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Courses
{
    public class TopicDto : TaggedDto
    {
        [Required(AllowEmptyStrings = false), MaxLength(80)]
        public required string Title { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(4096)]
        public required string Description { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(1024)]
        public string? Abstract { get; set; }
        public virtual TimeSpan? StandardDuration { get; set; }
        public virtual TimeSpan? EffectiveDuration => TimeSpan.FromHours(Topics.Sum(t => t.StandardDuration?.Hours ?? 0));
        public IEnumerable<TopicDto> Topics { get; set; } = [];
        public IEnumerable<LinkDto> Links { get; set; } = [];
    }
}
