// components/DocumentViewer.tsx
import React, { useEffect, useState } from 'react';
import { useDocumentViewer } from '../../../hooks/useDocumentViewer';

interface DocumentViewerProps {
    documentId: number;
    onClose?: () => void;
}

export const DocumentViewer: React.FC<DocumentViewerProps> = ({
    documentId,
    onClose
}) => {
    const { documentInfo, documentUrl, loading, error, loadDocument, clearDocument } = useDocumentViewer();
    const [currentPage, setCurrentPage] = useState(1);
    const [zoom, setZoom] = useState(1);

    useEffect(() => {
        if (documentId) {
            loadDocument(documentId);
        }

        return () => {
            clearDocument();
        };
    }, [documentId, loadDocument, clearDocument]);

    // Determina il tipo di visualizzazione in base al MIME type
    const getViewerType = (mimeType: string) => {
        if (mimeType.startsWith('image/')) return 'image';
        if (mimeType === 'application/pdf') return 'pdf';
        if (mimeType.includes('word') || mimeType.includes('document')) return 'office';
        if (mimeType.includes('text/')) return 'text';
        return 'download';
    };

    const viewerType = documentInfo ? getViewerType(documentInfo.mimeType) : null;

    const renderViewer = () => {
        if (!documentUrl || !documentInfo) return null;

        switch (viewerType) {
            case 'image':
                return (
                    <div className="image-viewer">
                        <img
                            src={documentUrl}
                            alt={documentInfo.title}
                            style={{
                                maxWidth: '100%',
                                maxHeight: '80vh',
                                transform: `scale(${zoom})`,
                                transition: 'transform 0.2s'
                            }}
                        />
                    </div>
                );

            case 'pdf':
                return (
                    <div className="pdf-viewer">
                        <iframe
                            src={documentUrl}
                            title={documentInfo.title}
                            width="100%"
                            height="600"
                            style={{ border: 'none' }}
                        />
                    </div>
                );

            case 'text':
                return (
                    <div className="text-viewer">
                        <iframe
                            src={documentUrl}
                            title={documentInfo.title}
                            width="100%"
                            height="400"
                            style={{ border: 'none' }}
                        />
                    </div>
                );

            default:
                return (
                    <div className="download-viewer">
                        <p>Questo tipo di file non può essere visualizzato in anteprima.</p>
                        <a
                            href={documentUrl}
                            download={documentInfo.fileName}
                            className="download-btn"
                        >
                            Scarica il file
                        </a>
                    </div>
                );
        }
    };

    if (loading) {
        return (
            <div className="document-viewer-loading">
                <div>Caricamento documento...</div>
            </div>
        );
    }

    if (error) {
        return (
            <div className="document-viewer-error">
                <div>Errore: {error}</div>
                <button onClick={() => loadDocument(documentId)}>Riprova</button>
            </div>
        );
    }

    return (
        <div className="document-viewer">
            {/* Header con controlli */}
            <div className="viewer-header">
                <div className="document-info">
                    <h3>{documentInfo?.title}</h3>
                    <span className="file-name">{documentInfo?.fileName}</span>
                    <span className="file-size">({(documentInfo?.size || 0 / 1024).toFixed(1)} KB)</span>
                </div>

                <div className="viewer-controls">
                    {viewerType === 'image' && (
                        <div className="zoom-controls">
                            <button onClick={() => setZoom(prev => Math.max(0.5, prev - 0.1))}>-</button>
                            <span>{(zoom * 100).toFixed(0)}%</span>
                            <button onClick={() => setZoom(prev => Math.min(3, prev + 0.1))}>+</button>
                        </div>
                    )}

                    <button
                        onClick={() => documentUrl && window.open(documentUrl, '_blank')}
                        className="open-external"
                    >
                        Apri in nuova finestra
                    </button>

                    {onClose && (
                        <button onClick={onClose} className="close-viewer">
                            Chiudi
                        </button>
                    )}
                </div>
            </div>

            {/* Area di visualizzazione */}
            <div className="viewer-content">
                {renderViewer()}
            </div>
        </div>
    );
};