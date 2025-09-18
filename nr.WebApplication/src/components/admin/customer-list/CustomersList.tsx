// components/CustomerList.tsx
import React, { useState, useEffect } from 'react';
import { CustomerModel, isCompanyModel, isPersonModel } from '../../../types/customers';
import { customerService } from '../../../services/customer-service';
import './CustomerList.scss';

interface CustomerListProps {
    onEditCustomer?: (id: number) => void;
}

// Componente per l'icona azienda
const CompanyIcon: React.FC = () => (
    <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round">
        <path d="M6 22V4a2 2 0 0 1 2-2h8a2 2 0 0 1 2 2v18Z" />
        <path d="M6 12H4a2 2 0 0 0-2 2v6a2 2 0 0 0 2 2h2" />
        <path d="M18 9h2a2 2 0 0 1 2 2v9a2 2 0 0 1-2 2h-2" />
        <path d="M10 6h4" />
        <path d="M10 10h4" />
        <path d="M10 14h4" />
        <path d="M10 18h4" />
    </svg>
);

// Componente per l'icona persona
const PersonIcon: React.FC = () => (
    <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round">
        <path d="M19 21v-2a4 4 0 0 0-4-4H9a4 4 0 0 0-4 4v2" />
        <circle cx="12" cy="7" r="4" />
    </svg>
);

const CustomerList: React.FC<CustomerListProps> = ({ onEditCustomer }) => {
    const [customers, setCustomers] = useState<CustomerModel[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        loadCustomers();
    }, []);

    const loadCustomers = async () => {
        try {
            setLoading(true);
            const response = await customerService.getCustomers();
            setCustomers(response);
        } catch (err) {
            setError('Si è verificato un errore durante il caricamento dei clienti');
        } finally {
            setLoading(false);
        }
    };

    const handleDelete = async (id: number) => {
        if (window.confirm('Sei sicuro di voler eliminare questo cliente?')) {
            try {
                await customerService.deleteCustomer(id);
                setCustomers(customers.filter(c => c.id !== id));
            } catch (err) {
                setError('Si è verificato un errore durante l\'eliminazione del cliente');
            }
        }
    };

    if (loading) return <div className="loading">Caricamento clienti...</div>;
    if (error) return <div className="error">Errore: {error}</div>;

    return (
        <div className="customer-list">
            <div className="customers-table">
                <table>
                    <thead>
                        <tr>
                            <th>Tipo</th>
                            <th>Nome</th>
                            <th>Dettagli</th>
                            <th>Azioni</th>
                        </tr>
                    </thead>
                    <tbody>
                        {customers.map(customer => (
                            <tr key={customer.id}>
                                <td>
                                    <span className={`customer-type ${customer.$type}`} title={customer.$type === 'company' ? 'Azienda' : 'Persona'}>
                                        {customer.$type === 'company' ? <CompanyIcon /> : <PersonIcon />}
                                    </span>
                                </td>
                                <td>{customer.displayName}</td>
                                <td>
                                    {isCompanyModel(customer) && (
                                        <div>
                                            <div><strong>Azienda:</strong> {customer.companyName}</div>
                                            {
                                                customer.vatCode && (<div><strong>P.IVA:</strong> {customer.vatCode}</div>) || (<div><strong>Codice Fiscale:</strong> {customer.fiscalCode}</div>)
                                            }
                                        </div>
                                    )}
                                    {isPersonModel(customer) && (
                                        <div>
                                            <div><strong>Persona:</strong> {customer.firstName} {customer.lastName}</div>
                                            <div><strong>Nickname:</strong> {customer.nickname || 'N/A'}</div>
                                        </div>
                                    )}
                                </td>
                                <td>
                                    <div className="action-buttons">
                                        <button title='Modifica'
                                            className="btn btn-edit"
                                            onClick={() => onEditCustomer && onEditCustomer(customer.id)}
                                        >
                                            ✏
                                        </button>
                                        <button title='Elimina'
                                            className="btn btn-delete"
                                            onClick={() => handleDelete(customer.id)}
                                        >
                                            🗑
                                        </button>
                                    </div>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
};

export default CustomerList;