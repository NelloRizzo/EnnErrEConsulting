// models/attachmentModels.ts
export interface LinkModel {
    $type?: string
    id: number;
    mimeType: string;
    type: string //'url' | 'content';
}

export interface UrlLinkModel extends LinkModel {
    url: string;
}

export interface ContentLinkModel extends LinkModel {
    content: number[];
}

export interface NewAttachmentModel {
    fileName: string;
    title: string;
    description: string;
    content: LinkModel;
}

// Type guard functions
export function isUrlLinkModel(link: LinkModel): link is UrlLinkModel {
    return link.type === 'url';
}

export function isContentLinkModel(link: LinkModel): link is ContentLinkModel {
    return link.type === 'content';
}