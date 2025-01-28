using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Attachments
{
    [Table("ContentLinks")]
    public class ContentLinkEntity : LinkEntity
    {
        [Required, MaxLength(8192)]
        public required byte[] Content { get; set; }
    }
}
