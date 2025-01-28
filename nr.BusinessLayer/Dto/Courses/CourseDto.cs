using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Courses
{
    public class CourseDto : TaggedDto
    {
        [Required(AllowEmptyStrings = false), MaxLength(80)]
        public required string Name { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(4096)]
        public required string Description { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(1024)]
        public string? Abstract { get; set; }
        public IEnumerable<CourseTopicDto> Topics { get; set; } = [];
        public TimeSpan? StandardDuration { get; set; }
        public TimeSpan EffectiveDuration => TimeSpan.FromHours(Topics.Sum(t => t.Topic.EffectiveDuration?.Hours ?? 0));
    }
}
