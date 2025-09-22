import React from 'react';
import { NewAttachmentModel } from '../../../../types/attachments';
import { attachmentService } from '../../../../services/attachment-service';
import { API_BASE_URL } from '../../../../services/configuration';

interface AttachmentCardProps {
  attachment: NewAttachmentModel;
  onDelete: (id: number) => void;
}

export const AttachmentCard: React.FC<AttachmentCardProps> = ({ attachment, onDelete }) => {
  const handleDelete = () => {
    if (window.confirm('Sei sicuro di voler eliminare questo allegato?')) {
      onDelete(attachment.content.id);
    }
  };

  const handleOpenUrl = () => {
    if (attachmentService.isUrlLink(attachment.content)) {
      window.open(`${API_BASE_URL}/api/attachments/download/${attachment.content.id}`, '_blank', 'noopener,noreferrer');
    }
  };

  const getFileIcon = (mimeType?: string) => {
    if (mimeType) {
      if (mimeType.includes('pdf')) return '📄';
      if (mimeType.includes('image')) return '🖼️';
      if (mimeType.includes('video')) return '🎬';
      if (mimeType.includes('audio')) return '🎵';
      if (mimeType.includes('word')) return '📝';
      if (mimeType.includes('excel')) return '📊';
      if (mimeType.includes('powerpoint')) return '📊';
    }
    return '📎';
  };

  return (
    <div className="attachment-card">
      <div className="attachment-header">
        <span className="file-icon">{getFileIcon(attachment.content.mimeType)}</span>
        <h3 className="attachment-title">{attachment.title}</h3>
        <button className="delete-btn" onClick={handleDelete} aria-label="Elimina allegato">
          🗑️
        </button>
      </div>

      <p className="attachment-description">{attachment.description}</p>

      <div className="attachment-content">
        {attachmentService.isUrlLink(attachment.content) && (
          <div className="url-link">
            <span className="url-label">URL: </span>
            <a
              href={attachment.content.url}
              target="_blank"
              rel="noopener noreferrer"
              className="url-link"
              onClick={handleOpenUrl}
            >
              {attachment.content.url}
            </a>
          </div>
        )}

        <div className="attachment-meta">
          <span className="mime-type">Tipo: {attachment.content.mimeType}</span>
          <span className="attachment-id">ID: {attachment.content.id}</span>
        </div>
      </div>
    </div>
  );
};