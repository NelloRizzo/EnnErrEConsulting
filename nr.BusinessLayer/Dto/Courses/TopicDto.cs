﻿using nr.BusinessLayer.Dto.Attachments;
using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Courses
{
    /// <summary>
    /// Un argomento.
    /// </summary>
    public class TopicDto : TaggedDto
    {
        /// <summary>
        /// Titolo.
        /// </summary>
        [Required(AllowEmptyStrings = false), MaxLength(80)]
        public required string Title { get; set; }
        /// <summary>
        /// Descrizione dettagliata.
        /// </summary>
        [Required(AllowEmptyStrings = false), MaxLength(4096)]
        public required string Description { get; set; }
        /// <summary>
        /// Descrizione breve.
        /// </summary>
        [Required(AllowEmptyStrings = false), MaxLength(1024)]
        public string? Abstract { get; set; }
        /// <summary>
        /// Durata standard.
        /// </summary>
        public virtual TimeSpan? StandardDuration { get; set; }
        /// <summary>
        /// Durata effettiva basata sulla durata dei singoli argomenti collegati.
        /// </summary>
        public virtual TimeSpan? EffectiveDuration => TimeSpan.FromHours(Topics.Sum(t => t.StandardDuration?.Hours ?? 0));
        /// <summary>
        /// Argomenti collegati.
        /// </summary>
        public IEnumerable<TopicDto> Topics { get; set; } = [];
        /// <summary>
        /// Documenti collegati.
        /// </summary>
        public IEnumerable<LinkDto> Links { get; set; } = [];
    }
}
