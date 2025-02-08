namespace nr.BusinessLayer.Dto.Attachments
{
    public class AttachmentWithoutContentDto : TaggedDto
    {
        /// <summary>
        /// Titolo.
        /// </summary>
        public required string Title { get; set; }
        /// <summary>
        /// Descrizione.
        /// </summary>
        public required string Description { get; set; }
        /// <summary>
        /// Chiave del contenuto.
        /// </summary>
        public required int ContentId { get; set; }
        /// <summary>
        /// Tipo del contenuto.
        /// </summary>
        public required string ContentType { get; set; }
    }
}
