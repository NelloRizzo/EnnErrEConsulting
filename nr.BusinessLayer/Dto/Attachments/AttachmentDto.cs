﻿using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Attachments
{
    /// <summary>
    /// Un allegato.
    /// </summary>
    public class AttachmentDto : TaggedDto
    {
        /// <summary>
        /// Titolo.
        /// </summary>
        [Required, MaxLength(80)]
        public required string Title { get; set; }
        /// <summary>
        /// Descrizione.
        /// </summary>
        [Required, MaxLength(1024)]
        public required string Description { get; set; }
        /// <summary>
        /// Contenuto.
        /// </summary>
        public required LinkDto Content { get; set; }
    }
}
