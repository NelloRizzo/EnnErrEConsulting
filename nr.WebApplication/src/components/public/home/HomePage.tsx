// HomePage.tsx
import React from 'react';
import './HomePage.scss';
import SeoHead from '../../commons/seo-head/SeoHead';

const HomePage: React.FC = () => {
  return (
    <div className="home-page">
      <SeoHead 
        title="EnnErrE Consulting - Corsi di Formazione Professionale"
        description="Scopri i corsi di formazione professionale di EnnErrE Consulting."
      />
      <header className="header">
        <div className="container">
          <div className="logo">
            <h1>EnnErrE Consulting</h1>
          </div>
          <nav className="navigation">
            <ul>
              <li><a href="#courses">Corsi</a></li>
              <li><a href="#about">Chi Siamo</a></li>
              <li><a href="#contact">Contatti</a></li>
              <li><a href="/admin" className="admin-link">Area Amministrazione</a></li>
            </ul>
          </nav>
        </div>
      </header>

      <section className="hero">
        <div className="container">
          <div className="hero-content">
            <h2>Formazione di Qualità per il Tuo Futuro</h2>
            <p>Scopri i nostri corsi professionali progettati per sviluppare le competenze richieste dal mercato attuale</p>
            <button className="cta-button">Scopri i Corsi</button>
          </div>
        </div>
      </section>

      <section className="features">
        <div className="container">
          <h2>Perché Sceglierci</h2>
          <div className="features-grid">
            <div className="feature">
              <div className="feature-icon">📚</div>
              <h3>Materiali Didattici</h3>
              <p>Accesso a risorse esclusive e materiali aggiornati</p>
            </div>
            <div className="feature">
              <div className="feature-icon">👨‍🏫</div>
              <h3>Docenti Esperti</h3>
              <p>Insegnanti con esperienza pratica nel settore</p>
            </div>
            <div className="feature">
              <div className="feature-icon">📜</div>
              <h3>Certificazioni</h3>
              <p>Attestati riconosciuti a livello nazionale e internazionale</p>
            </div>
          </div>
        </div>
      </section>

      <footer className="footer">
        <div className="container">
          <p>&copy; {new Date().getFullYear()} EnnErrE Consulting. Tutti i diritti riservati.</p>
        </div>
      </footer>
    </div>
  );
};

export default HomePage;