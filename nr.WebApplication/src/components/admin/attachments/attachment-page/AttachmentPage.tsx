import React from 'react';
import { AttachmentCard } from '../attachment-card/AttachmentCard';
import './AttachmentPage.scss';
import { useAttachments } from '../../../../hooks/useAttachmentService';
import AttachmentForm from '../attachment-form/AttachmentForm';
import { NewAttachmentModel } from '../../../../types/attachments';

export const AttachmentsPage: React.FC = () => {
  const { attachments, loading, error, deleteAttachment, refresh } = useAttachments();

  if (loading) {
    return (
      <div className="attachments-container">
        <div className="loading">Caricamento allegati...</div>
      </div>
    );
  }

  if (error) {
    return (
      <div className="attachments-container">
        <div className="error">
          <p>Errore nel caricamento: {error}</p>
          <button onClick={refresh} className="retry-btn">
            Riprova
          </button>
        </div>
      </div>
    );
  }

  return (
    <div className="attachments-container">
      <div className="attachments-header">
        <h1>Allegati</h1>
        <div className="attachments-info">
          <span className="count-badge">{attachments.length} allegati trovati</span>
          <button onClick={refresh} className="refresh-btn" aria-label="Aggiorna lista">
            🔄
          </button>
        </div>
      </div>

      {attachments.length === 0 ? (
        <div className="empty-state">
          <p>Nessun allegato trovato</p>
        </div>
      ) : (
        <div className="attachments-grid">
          {attachments.map((attachment) => (
            <AttachmentCard
              key={attachment.content.id}
              attachment={attachment}
              onDelete={deleteAttachment}
            />
          ))}
        </div>
      )}
    </div>
  );
};