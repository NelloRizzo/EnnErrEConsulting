// AdminHomePage.tsx
import React, { useState } from 'react';
import './AdminHomePage.scss';
import CustomerList from '../customer-list/CustomersList';
import CustomerForm from '../customer-form/CustomerForm';
import Dashboard from '../dashboard/Dashboard';

interface Course {
  id: number;
  title: string;
  participants: number;
  status: 'active' | 'draft' | 'completed';
}

const AdminHomePage: React.FC = () => {
  const [activeTab, setActiveTab] = useState<string>('dashboard');
  const [selectedCustomerId, setSelectedCustomerId] = useState<number | undefined>();
  const [courses, setCourses] = useState<Course[]>([
    { id: 1, title: 'React Avanzato', participants: 24, status: 'active' },
    { id: 2, title: 'TypeScript per Sviluppatori', participants: 18, status: 'active' },
    { id: 3, title: 'Gestione Progetti Agile', participants: 0, status: 'draft' },
    { id: 4, title: 'Digital Marketing Fundamentals', participants: 32, status: 'completed' },
  ]);

  // Funzione per gestire la selezione di un cliente da modificare
  const handleEditCustomer = (id: number) => {
    setSelectedCustomerId(id);
    setActiveTab('edit-customer');
  };

  // Funzione per tornare alla lista clienti dopo il salvataggio
  const handleSaveCustomer = () => {
    setActiveTab('customers');
    setSelectedCustomerId(undefined);
  };

  // Funzione per annullare la modifica/creazione
  const handleCancelCustomer = () => {
    setActiveTab('customers');
    setSelectedCustomerId(undefined);
  };

  // Render del contenuto in base al tab attivo
  const renderTabContent = () => {
    switch (activeTab) {
      case 'dashboard':
        return <Dashboard />;

      case 'customers':
        return <CustomerList onEditCustomer={handleEditCustomer} />;

      case 'new-customer':
        return <CustomerForm onSave={handleSaveCustomer} onCancel={handleCancelCustomer} />;

      case 'edit-customer':
        return selectedCustomerId ? (
          <CustomerForm
            customerId={selectedCustomerId}
            onSave={handleSaveCustomer}
            onCancel={handleCancelCustomer}
          />
        ) : (
          <div className="error-message">Nessun cliente selezionato</div>
        );

      case 'users':
        return (
          <div className="tab-content">
            <h2>Gestione Utenti</h2>
            <p>Funzionalità di gestione utenti in sviluppo...</p>
          </div>
        );

      case 'reports':
        return (
          <div className="tab-content">
            <h2>Report e Statistiche</h2>
            <p>Funzionalità di reporting in sviluppo...</p>
          </div>
        );

      case 'settings':
        return (
          <div className="tab-content">
            <h2>Impostazioni</h2>
            <p>Funzionalità di configurazione in sviluppo...</p>
          </div>
        );

      default:
        return (
          <div className="tab-content">
            <h2>Admin Page</h2>
            <p>Seleziona una voce dal menu di navigazione.</p>
          </div>
        );
    }
  };

  return (
    <div className="admin-page">
      <header className="admin-header">
        <div className="container">
          <div className="admin-logo">
            <h1>EnnErrE Consulting - Amministrazione</h1>
          </div>
          <div className="admin-actions">
            <button className="logout-btn">Logout</button>
          </div>
        </div>
      </header>

      <div className="admin-container">
        <aside className="admin-sidebar">
          <nav>
            <ul>
              <li
                className={activeTab === 'dashboard' ? 'active' : ''}
                onClick={() => setActiveTab('dashboard')}
              >
                Dashboard
              </li>
              <li
                className={activeTab === 'customers' ? 'active' : ''}
                onClick={() => setActiveTab('customers')}
              >
                Gestione Clienti
              </li>
              <li
                className={activeTab === 'courses' ? 'active' : ''}
                onClick={() => setActiveTab('courses')}
              >
                Gestione Corsi
              </li>
              <li
                className={activeTab === 'users' ? 'active' : ''}
                onClick={() => setActiveTab('users')}
              >
                Utenti
              </li>
              <li
                className={activeTab === 'reports' ? 'active' : ''}
                onClick={() => setActiveTab('reports')}
              >
                Report
              </li>
              <li
                className={activeTab === 'settings' ? 'active' : ''}
                onClick={() => setActiveTab('settings')}
              >
                Impostazioni
              </li>
            </ul>
          </nav>
        </aside>

        <main className="admin-main">
          <div className='admin-content'>
            {activeTab === 'customers' && (
              <div className="page-header">
                <h2>Gestione Clienti</h2>
                <button
                  className="btn btn-primary"
                  onClick={() => setActiveTab('new-customer')}
                >
                  Aggiungi Nuovo Cliente
                </button>
              </div>
            )}
            {renderTabContent()}
          </div>
        </main>
      </div>
    </div>
  );
};

export default AdminHomePage;