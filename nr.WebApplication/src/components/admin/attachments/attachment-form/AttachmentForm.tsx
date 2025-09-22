// components/AttachmentForm.tsx
import React, { useState } from 'react';
import { NewAttachmentModel, LinkModel, UrlLinkModel, ContentLinkModel, isUrlLinkModel, isContentLinkModel } from '../../../../types/attachments';
import LoadingSpinner from '../../../commons/loading-spinner/LoadingSpinner';
import './AttachmentForm.scss';

interface AttachmentFormProps {
    onSubmit: (attachment: NewAttachmentModel) => Promise<void>;
    onCancel?: () => void;
    loading?: boolean;
}

const AttachmentForm: React.FC<AttachmentFormProps> = ({ onSubmit, onCancel, loading = false }) => {
    const [formData, setFormData] = useState<NewAttachmentModel>({
        title: '',
        description: '',
        fileName: '',
        content: {
            id: 0,
            mimeType: '',
            type: 'url'
        } as UrlLinkModel
    });

    const [errors, setErrors] = useState<{ [key: string]: string }>({});
    const [file, setFile] = useState<File | null>(null);

    // Opzioni di MIME type predefinite
    const mimeTypes = [
        { value: '', label: 'Seleziona tipo di file' },
        { value: 'application/pdf', label: 'PDF Document' },
        { value: 'image/jpeg', label: 'JPEG Image' },
        { value: 'image/png', label: 'PNG Image' },
        { value: 'application/msword', label: 'Word Document' },
        { value: 'application/vnd.openxmlformats-officedocument.wordprocessingml.document', label: 'Word Document (docx)' },
        { value: 'application/vnd.ms-excel', label: 'Excel Spreadsheet' },
        { value: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet', label: 'Excel Spreadsheet (xlsx)' },
        { value: 'text/plain', label: 'Text File' },
        { value: 'application/zip', label: 'ZIP Archive' },
        { value: 'other', label: 'Altro...' }
    ];

    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement>) => {
        const { name, value } = e.target;

        if (name.startsWith('content.')) {
            const contentField = name.replace('content.', '');
            setFormData(prev => ({
                ...prev,
                content: {
                    ...prev.content,
                    [contentField]: value
                }
            }));
        } else {
            setFormData(prev => ({
                ...prev,
                [name]: value
            }));
        }

        // Rimuovi l'errore quando l'utente inizia a digitare
        if (errors[name]) {
            setErrors(prev => {
                const newErrors = { ...prev };
                delete newErrors[name];
                return newErrors;
            });
        }
    };

    const handleLinkTypeChange = (type: 'url' | 'content') => {
        if (type === 'url') {
            setFormData(prev => ({
                ...prev,
                content: {
                    id: 0,
                    mimeType: prev.content.mimeType,
                    type: 'url',
                    url: ''
                } as UrlLinkModel
            }));
        } else {
            setFormData(prev => ({
                ...prev,
                fileName: '',
                content: {
                    $type: "internal",
                    id: 0,
                    mimeType: prev.content.mimeType,
                    type: 'content',
                    content: [],
                } as ContentLinkModel
            }));
        }
        setFile(null);
    };

    const getFileAsArrayBuffer = async (file: File): Promise<ArrayBuffer> => {
        return new Promise((resolve, reject) => {
            const reader = new FileReader();
            reader.onload = () => resolve(reader.result as ArrayBuffer);
            reader.onerror = reject;
            reader.readAsArrayBuffer(file);
        });
    };

    const handleFileChange = async (e: React.ChangeEvent<HTMLInputElement>) => {
        const selectedFile = e.target.files?.[0];
        if (selectedFile) {
            setFile(selectedFile);


            const content: number[] = [...new Uint8Array(await getFileAsArrayBuffer(selectedFile))]
            setFormData(prev => ({
                ...prev,
                fileName: selectedFile.name,
                content: {
                    ...prev.content,
                    content: content,
                    mimeType: selectedFile.type || 'application/octet-stream'
                } as ContentLinkModel
            }));
        }

    };

    const validateForm = (): boolean => {
        const newErrors: { [key: string]: string } = {};

        if (!formData.title.trim()) {
            newErrors.title = 'Il titolo è obbligatorio';
        } else if (formData.title.length > 80) {
            newErrors.title = 'Il titolo non può superare 80 caratteri';
        }

        if (!formData.description.trim()) {
            newErrors.description = 'La descrizione è obbligatoria';
        } else if (formData.description.length > 1024) {
            newErrors.description = 'La descrizione non può superare 1024 caratteri';
        }

        if (!formData.content.mimeType) {
            newErrors['content.mimeType'] = 'Il tipo di file è obbligatorio';
        }

        if (isUrlLinkModel(formData.content)) {
            if (!formData.content.url.trim()) {
                newErrors['content.url'] = 'L\'URL è obbligatorio';
            } else if (formData.content.url.length > 512) {
                newErrors['content.url'] = 'L\'URL non può superare 512 caratteri';
            } else if (!isValidUrl(formData.content.url)) {
                newErrors['content.url'] = 'Inserisci un URL valido';
            }
        } else if (isContentLinkModel(formData.content)) {
            if (!formData.content.content.length) {
                newErrors['content.content'] = 'Il file è obbligatorio';
            }
        }

        setErrors(newErrors);
        return Object.keys(newErrors).length === 0;
    };

    const isValidUrl = (url: string): boolean => {
        try {
            new URL(url);
            return true;
        } catch {
            return false;
        }
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        if (validateForm()) {
            try {
                await onSubmit(formData);
                // Reset form dopo il successo
                setFormData({
                    title: '',
                    description: '',
                    fileName: '',
                    content: {
                        id: 0,
                        mimeType: '',
                        type: 'url'
                    } as UrlLinkModel
                });
                setFile(null);
            } catch (error) {
                console.error('Errore durante il salvataggio:', error);
            }
        }
    };

    const getFileSize = (base64String: string): number => {
        try {
            // Calcola la dimensione approssimativa in byte
            return Math.floor((base64String.length * 3) / 4);
        } catch {
            return 0;
        }
    };

    const isFileTooLarge = (base64String: string): boolean => {
        return getFileSize(base64String) > 1000000; // 1MB limite
    };

    return (
        <div className="attachment-form">
            <h2>Aggiungi Nuovo Allegato</h2>

            <form onSubmit={handleSubmit}>
                {/* Titolo */}
                <div className="form-group">
                    <label htmlFor="title">Titolo *</label>
                    <input
                        type="text"
                        id="title"
                        name="title"
                        value={formData.title}
                        onChange={handleInputChange}
                        maxLength={80}
                        placeholder="Inserisci il titolo dell'allegato"
                        className={errors.title ? 'error' : ''}
                    />
                    {errors.title && <span className="error-message">{errors.title}</span>}
                    <div className="character-count">{formData.title.length}/80</div>
                </div>

                {/* Descrizione */}
                <div className="form-group">
                    <label htmlFor="description">Descrizione *</label>
                    <textarea
                        id="description"
                        name="description"
                        value={formData.description}
                        onChange={handleInputChange}
                        maxLength={1024}
                        rows={4}
                        placeholder="Inserisci una descrizione per l'allegato"
                        className={errors.description ? 'error' : ''}
                    />
                    {errors.description && <span className="error-message">{errors.description}</span>}
                    <div className="character-count">{formData.description.length}/1024</div>
                </div>

                {/* Tipo di contenuto */}
                <div className="form-group">
                    <label>Tipo di Contenuto</label>
                    <div className="link-type-selector">
                        <button
                            type="button"
                            className={formData.content.type === 'url' ? 'active' : ''}
                            onClick={() => handleLinkTypeChange('url')}
                        >
                            <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round">
                                <path d="M10 13a5 5 0 0 0 7.54.54l3-3a5 5 0 0 0-7.07-7.07l-1.72 1.71" />
                                <path d="M14 11a5 5 0 0 0-7.54-.54l-3 3a5 5 0 0 0 7.07 7.07l1.71-1.71" />
                            </svg>
                            <span>Collegamento URL</span>
                        </button>
                        <button
                            type="button"
                            className={formData.content.type === 'content' ? 'active' : ''}
                            onClick={() => handleLinkTypeChange('content')}
                        >
                            <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round">
                                <path d="M14 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V8z" />
                                <polyline points="14 2 14 8 20 8" />
                                <line x1="16" y1="13" x2="8" y2="13" />
                                <line x1="16" y1="17" x2="8" y2="17" />
                                <polyline points="10 9 9 9 8 9" />
                            </svg>
                            <span>Carica File</span>
                        </button>
                    </div>
                </div>

                {/* Tipo MIME */}
                <div className="form-group">
                    <label htmlFor="mimeType">Tipo di File *</label>
                    <select
                        id="mimeType"
                        name="content.mimeType"
                        value={formData.content.mimeType}
                        onChange={handleInputChange}
                        className={errors['content.mimeType'] ? 'error' : ''}
                    >
                        {mimeTypes.map(option => (
                            <option key={option.value} value={option.value}>
                                {option.label}
                            </option>
                        ))}
                    </select>
                    {errors['content.mimeType'] && <span className="error-message">{errors['content.mimeType']}</span>}
                </div>

                {/* Contenuto in base al tipo */}
                {formData.content.type === 'url' ? (
                    <div className="form-group">
                        <label htmlFor="url">URL *</label>
                        <input
                            type="url"
                            id="url"
                            name="content.url"
                            value={(formData.content as UrlLinkModel).url}
                            onChange={handleInputChange}
                            maxLength={512}
                            placeholder="https://example.com/documento.pdf"
                            className={errors['content.url'] ? 'error' : ''}
                        />
                        {errors['content.url'] && <span className="error-message">{errors['content.url']}</span>}
                        <div className="character-count">{(formData.content as UrlLinkModel).url?.length ?? 0}/512</div>
                    </div>
                ) : (
                    <div className="form-group">
                        <label htmlFor="file">File *</label>
                        <div className="file-upload">
                            <input
                                type="file"
                                id="file"
                                onChange={handleFileChange}
                                className={errors['content.content'] ? 'error' : ''}
                            />
                            <label htmlFor="file" className="file-upload-label">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round">
                                    <path d="M21 15v4a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2v-4" />
                                    <polyline points="17 8 12 3 7 8" />
                                    <line x1="12" y1="3" x2="12" y2="15" />
                                </svg>
                                {file ? file.name : 'Seleziona un file'}
                            </label>
                            {file && (
                                <div className="file-info">
                                    <span>Dimensione: {(file.size / 1024).toFixed(2)} KB</span>
                                    {
                                        // { isFileTooLarge((formData.content as ContentLinkModel).content) && (
                                        // <span className="error-message">Il file supera 1MB di dimensione massima</span>
                                        //)}
                                    }
                                </div>
                            )}
                        </div>
                        {errors['content.content'] && <span className="error-message">{errors['content.content']}</span>}
                    </div>
                )}

                {/* Pulsanti di azione */}
                <div className="form-actions">
                    <button type="button" onClick={onCancel} disabled={loading}>
                        Annulla
                    </button>
                    <button type="submit" disabled={loading}>
                        {loading ? <LoadingSpinner size="small" text="" /> : 'Salva Allegato'}
                    </button>
                </div>
            </form>

            {loading && <LoadingSpinner overlay text="Salvataggio in corso..." />}
        </div>
    );
};

export default AttachmentForm;