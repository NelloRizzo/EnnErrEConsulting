// components/DocumentLink.tsx
import React, { useState } from 'react';
import { DocumentViewer } from './DocumentViewer';

interface DocumentLinkProps {
    documentId: number;
    documentName: string;
    children?: React.ReactNode;
}

export const DocumentLink: React.FC<DocumentLinkProps> = ({
    documentId,
    documentName,
    children
}) => {
    const [showViewer, setShowViewer] = useState(false);

    const handleClick = (e: React.MouseEvent) => {
        e.preventDefault();
        setShowViewer(true);
    };

    return (
        <>
            <a
                href="#"
                onClick={handleClick}
                className="document-link"
                title={`Visualizza ${documentName}`}
            >
                {children || documentName}
            </a>

            {showViewer && (
                <div className="modal-overlay">
                    <div className="modal-content">
                        <DocumentViewer
                            documentId={documentId}
                            onClose={() => setShowViewer(false)}
                        />
                    </div>
                </div>
            )}
        </>
    );
};