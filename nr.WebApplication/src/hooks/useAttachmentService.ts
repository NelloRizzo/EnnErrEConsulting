import { useState, useEffect, useCallback } from 'react';
import { NewAttachmentModel } from '../types/attachments';
import { attachmentService } from '../services/attachment-service';

export const useAttachments = () => {
  const [attachments, setAttachments] = useState<NewAttachmentModel[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  const fetchAttachments = useCallback(async () => {
    setLoading(true);
    setError(null);
    try {
      const data = await attachmentService.getAllAttachments();
      setAttachments(data);
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Failed to fetch attachments');
    } finally {
      setLoading(false);
    }
  }, []);

  const deleteAttachment = useCallback(async (id: number) => {
    try {
      await attachmentService.deleteAttachment(id);
      setAttachments(prev => prev.filter(att => att.content.id !== id));
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Failed to delete attachment');
    }
  }, []);

  useEffect(() => {
    fetchAttachments();
  }, [fetchAttachments]);

  const refresh = () => {
    fetchAttachments();
  };

  return {
    attachments,
    loading,
    error,
    deleteAttachment,
    refresh,
  };
};