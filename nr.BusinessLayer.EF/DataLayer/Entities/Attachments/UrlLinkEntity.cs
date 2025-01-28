using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Attachments
{
    [Table("UrlLinks")]
    [Index(nameof(Url), IsUnique = true, Name = "IDX_LINKURL_UNIQUE")]
    public class UrlLinkEntity : LinkEntity
    {
        [Required, MaxLength(512)]
        public required string Url { get; set; }
    }
}
