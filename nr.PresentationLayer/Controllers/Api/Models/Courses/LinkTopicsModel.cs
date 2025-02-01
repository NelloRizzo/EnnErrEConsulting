namespace nr.PresentationLayer.Controllers.Api.Models.Courses
{
    public class LinkTopicsModel
    {
        public IEnumerable<int> TopicIds { get; set; } = [];
        public int Order { get; set; } 
    }
}
