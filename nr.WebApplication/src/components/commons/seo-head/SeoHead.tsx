// components/NativeSeoHead.tsx
import React from 'react';

interface SeoHeadProps {
    title?: string;
    description?: string;
    canonicalUrl?: string;
    keywords?: string;
    noIndex?: boolean;
}

const NativeSeoHead: React.FC<SeoHeadProps> = ({
    title = "EnnErrE Consulting - Corsi di Formazione Professionale",
    description = "EnnErrE Consulting offre corsi di formazione professionale di alta qualità.",
    canonicalUrl = "https://www.ennerre-consulting.it",
    keywords = "corsi formazione, formazione professionale, EnnErrE Consulting"
}) => {
    // React 19 permette di restituire direttamente tag meta e title
    return (
        <>
            <title>{title}</title>
            <meta name="description" content={description} />
            <meta name="keywords" content={keywords} />
            <link rel="canonical" href={canonicalUrl} />
            <meta property="og:title" content={title} />
            <meta property="og:description" content={description} />
            <meta property="og:type" content="website" />
            <meta property="og:url" content={canonicalUrl} />
            <meta property="og:image" content="https://www.ennerre-consulting.it/images/og-image.jpg" />
            <meta name="twitter:card" content="summary_large_image" />
            <meta name="twitter:title" content={title} />
            <meta name="twitter:description" content={description} />
        </>
    );
};

export default NativeSeoHead;