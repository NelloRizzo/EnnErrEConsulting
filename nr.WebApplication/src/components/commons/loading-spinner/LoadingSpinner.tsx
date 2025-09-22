// components/LoadingSpinner.tsx
import React from 'react';
import './LoadingSpinner.scss';

interface LoadingSpinnerProps {
  size?: 'small' | 'medium' | 'large';
  text?: string;
  overlay?: boolean;
  fullScreen?: boolean;
}

const LoadingSpinner: React.FC<LoadingSpinnerProps> = ({
  size = 'medium',
  text = 'Caricamento in corso...',
  overlay = false,
  fullScreen = false
}) => {
  // Se è fullScreen, forziamo overlay a true
  const showOverlay = fullScreen || overlay;
  
  const spinnerContent = (
    <div className={`loading-spinner ${size} ${fullScreen ? 'full-screen' : ''}`}>
      <div className="spinner">
        <div className="spinner-circle"></div>
        <div className="spinner-circle"></div>
        <div className="spinner-circle"></div>
        <div className="spinner-circle"></div>
      </div>
      {text && <p className="loading-text">{text}</p>}
    </div>
  );

  if (showOverlay) {
    return (
      <div className={`loading-overlay ${fullScreen ? 'full-screen' : ''}`}>
        {spinnerContent}
      </div>
    );
  }

  return spinnerContent;
};

export default LoadingSpinner;