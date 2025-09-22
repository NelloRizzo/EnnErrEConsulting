import axios, { AxiosInstance, AxiosResponse } from 'axios';
import { NewAttachmentModel, UrlLinkModel, ContentLinkModel, isUrlLinkModel, isContentLinkModel, LinkModel } from '../types/attachments';
import { API_BASE_URL } from './configuration';

class ApiService {
    private client: AxiosInstance;

    constructor(baseUrl: string) {
        this.client = axios.create({
            baseURL: baseUrl,
            headers: {
                'Content-Type': 'application/json',
            },
        });

        // Aggiungi interceptors per gestire errori, auth, etc.
        this.setupInterceptors();
    }

    private setupInterceptors(): void {
        this.client.interceptors.request.use(
            (config) => {
                const token = localStorage.getItem('token');
                if (token) {
                    config.headers.Authorization = `Bearer ${token}`;
                }
                return config;
            },
            (error) => Promise.reject(error)
        );

        this.client.interceptors.response.use(
            (response) => response,
            (error) => {
                // Gestione errori globale
                console.error('API Error:', error);
                return Promise.reject(error);
            }
        );
    }

    // Attachment Service
    public async createInternalAttachment(attachment: NewAttachmentModel): Promise<NewAttachmentModel> {
        attachment.content.$type = "internal"
        console.log("Sending", attachment)
        try {
            const response: AxiosResponse<NewAttachmentModel> = await this.client.post(
                '/attachments/internal',
                attachment
            );
            return response.data;
        } catch (error) {
            throw new Error(`Failed to create attachment: ${error}`);
        }
    }

    public async createUrlAttachment(attachment: NewAttachmentModel): Promise<NewAttachmentModel> {
        attachment.content.$type = "url"
        try {
            const response: AxiosResponse<NewAttachmentModel> = await this.client.post(
                '/attachments/url',
                attachment
            );
            return response.data;
        } catch (error) {
            throw new Error(`Failed to create attachment: ${error}`);
        }
    }

    public async getAttachment(id: number): Promise<NewAttachmentModel> {
        try {
            const response: AxiosResponse<NewAttachmentModel> = await this.client.get(
                `/attachments/${id}`
            );
            return response.data;
        } catch (error) {
            throw new Error(`Failed to get attachment ${id}: ${error}`);
        }
    }

    public async updateAttachment(
        id: number,
        attachment: Partial<NewAttachmentModel>
    ): Promise<NewAttachmentModel> {
        try {
            const response: AxiosResponse<NewAttachmentModel> = await this.client.put(
                `/attachments/${id}`,
                attachment
            );
            return response.data;
        } catch (error) {
            throw new Error(`Failed to update attachment ${id}: ${error}`);
        }
    }

    public async deleteAttachment(id: number): Promise<void> {
        try {
            await this.client.delete(`/attachments/${id}`);
        } catch (error) {
            throw new Error(`Failed to delete attachment ${id}: ${error}`);
        }
    }

    public async listAttachments(): Promise<NewAttachmentModel[]> {
        try {
            const response: AxiosResponse<NewAttachmentModel[]> = await this.client.get(
                '/attachments'
            );
            return response.data;
        } catch (error) {
            throw new Error(`Failed to list attachments: ${error}`);
        }
    }

    // Metodi specifici per i link
    public async validateUrl(url: string): Promise<boolean> {
        try {
            const response: AxiosResponse<{ isValid: boolean }> = await this.client.post(
                '/attachments/validate-url',
                { url }
            );
            return response.data.isValid;
        } catch (error) {
            throw new Error(`Failed to validate URL: ${error}`);
        }
    }

    public async uploadContent(content: string, mimeType: string): Promise<ContentLinkModel> {
        try {
            const response: AxiosResponse<ContentLinkModel> = await this.client.post(
                '/attachments/upload-content',
                { content, mimeType }
            );
            return response.data;
        } catch (error) {
            throw new Error(`Failed to upload content: ${error}`);
        }
    }

    // Metodo per discriminare il tipo di link
    public isUrlLink(link: LinkModel): link is UrlLinkModel {
        return 'url' in link;
    }

    public isContentLink(link: LinkModel): link is ContentLinkModel {
        return 'content' in link;
    }
}

// Hook personalizzato per usare il service
import { useState, useCallback } from 'react';

class AttachmentService {
    private client: AxiosInstance;

    constructor(baseURL: string) {
        this.client = axios.create({
            baseURL,
            headers: {
                'Content-Type': 'application/json',
            },
        });
    }

    async getAllAttachments(): Promise<NewAttachmentModel[]> {
        try {
            const response = await this.client.get<NewAttachmentModel[]>('/attachments');
            return response.data;
        } catch (error) {
            throw new Error(`Failed to fetch attachments: ${error}`);
        }
    }

    async deleteAttachment(id: number): Promise<void> {
        try {
            await this.client.delete(`/attachments/${id}`);
        } catch (error) {
            throw new Error(`Failed to delete attachment ${id}: ${error}`);
        }
    }

    isUrlLink(link: LinkModel): link is UrlLinkModel {
        return 'url' in link;
    }
}

export const attachmentService = new AttachmentService(`${API_BASE_URL}/api`);

export const useAttachmentService = () => {
    const [service] = useState(() => new ApiService(`${API_BASE_URL}/api`));
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);

    const execute = useCallback(async <T>(operation: () => Promise<T>): Promise<T> => {
        setLoading(true);
        setError(null);
        try {
            const result = await operation();
            return result;
        } catch (err) {
            const errorMessage = err instanceof Error ? err.message : 'Unknown error occurred';
            setError(errorMessage);
            throw err;
        } finally {
            setLoading(false);
        }
    }, []);

    const createInternalAttachment = useCallback((attachment: NewAttachmentModel) =>
        execute(() => service.createInternalAttachment(attachment)), [execute, service]);
    const createUrlAttachment = useCallback((attachment: NewAttachmentModel) =>
        execute(() => service.createUrlAttachment(attachment)), [execute, service]);

    const getAttachment = useCallback((id: number) =>
        execute(() => service.getAttachment(id)), [execute, service]);

    const updateAttachment = useCallback((id: number, attachment: Partial<NewAttachmentModel>) =>
        execute(() => service.updateAttachment(id, attachment)), [execute, service]);

    const deleteAttachment = useCallback((id: number) =>
        execute(() => service.deleteAttachment(id)), [execute, service]);

    const listAttachments = useCallback(() =>
        execute(() => service.listAttachments()), [execute, service]);

    const validateUrl = useCallback((url: string) =>
        execute(() => service.validateUrl(url)), [execute, service]);

    const uploadContent = useCallback((content: string, mimeType: string) =>
        execute(() => service.uploadContent(content, mimeType)), [execute, service]);

    return {
        service,
        loading,
        error,
        createInternalAttachment,
        createUrlAttachment,
        getAttachment,
        updateAttachment,
        deleteAttachment,
        listAttachments,
        validateUrl,
        uploadContent,
        clearError: () => setError(null),
    };
};

export default ApiService;