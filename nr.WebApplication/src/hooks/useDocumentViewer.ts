// hooks/useDocumentViewer.ts
import { useState, useCallback } from 'react';
import { documentService, DocumentInfo } from '../services/document-service';

export const useDocumentViewer = () => {
    const [documentInfo, setDocumentInfo] = useState<DocumentInfo | null>(null);
    const [documentUrl, setDocumentUrl] = useState<string | null>(null);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);

    const loadDocument = useCallback(async (documentId: number) => {
        setLoading(true);
        setError(null);
        setDocumentUrl(null);

        try {
            // Carica le informazioni del documento
            const info = await documentService.getDocumentInfo(documentId);
            setDocumentInfo(info);

            // Crea URL per la visualizzazione
            const blob = await documentService.getDocumentBlob(documentId);
            const url = URL.createObjectURL(blob);
            setDocumentUrl(url);

            return { info, url };
        } catch (err) {
            const errorMessage = err instanceof Error ? err.message : 'Errore nel caricamento del documento';
            setError(errorMessage);
            throw err;
        } finally {
            setLoading(false);
        }
    }, []);

    const clearDocument = useCallback(() => {
        if (documentUrl) {
            URL.revokeObjectURL(documentUrl);
        }
        setDocumentInfo(null);
        setDocumentUrl(null);
        setError(null);
    }, [documentUrl]);

    return {
        documentInfo,
        documentUrl,
        loading,
        error,
        loadDocument,
        clearDocument
    };
};