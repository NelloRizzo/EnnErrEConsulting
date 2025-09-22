// documentService.ts
import axios from 'axios';

const apiClient = axios.create({
  baseURL: 'https://your-api-url.com/api',
});

export interface DocumentInfo {
  id: number;
  fileName: string;
  mimeType: string;
  size: number;
  title: string;
  description: string;
}

export const documentService = {
  // Ottieni le informazioni del documento
  async getDocumentInfo(id: number): Promise<DocumentInfo> {
    const response = await apiClient.get<DocumentInfo>(`/documents/${id}/info`);
    return response.data;
  },

  // Ottieni il documento come Blob per la visualizzazione
  async getDocumentBlob(id: number): Promise<Blob> {
    const response = await apiClient.get(`/documents/${id}/content`, {
      responseType: 'blob'
    });
    return response.data;
  },

  // Ottieni come Base64 per embedding diretto
  async getDocumentBase64(id: number): Promise<string> {
    const blob = await this.getDocumentBlob(id);
    return new Promise((resolve, reject) => {
      const reader = new FileReader();
      reader.onload = () => resolve(reader.result as string);
      reader.onerror = reject;
      reader.readAsDataURL(blob);
    });
  }
};