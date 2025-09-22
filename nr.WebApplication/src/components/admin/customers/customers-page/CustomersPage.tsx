// pages/AdminCustomersPage.tsx
import React, { useState } from 'react';
import CustomerList from '../customer-list/CustomersList';
import CustomerForm from '../customer-form/CustomerForm';
import SeoHead from '../../../seo-head/SeoHead';
import './AdminCustomersPage.scss';

const CustomersPage: React.FC = () => {
    const [view, setView] = useState<'list' | 'create' | 'edit'>('list');
    const [selectedCustomerId, setSelectedCustomerId] = useState<number | undefined>();

    const handleCreate = () => {
        setView('create');
    };

    const handleEdit = (id: number) => {
        setSelectedCustomerId(id);
        setView('edit');
    };

    const handleSave = () => {
        setView('list');
        setSelectedCustomerId(undefined);
    };

    const handleCancel = () => {
        setView('list');
        setSelectedCustomerId(undefined);
    };

    return (
        <div className="admin-customers-page">
            <SeoHead
                title="Customer Management - EnnErrE Consulting"
                description="Manage customers and companies in the EnnErrE Consulting administration panel"
                noIndex={true}
            />

            {view === 'list' && <CustomerList />}
            {view === 'create' && (
                <CustomerForm onSave={handleSave} onCancel={handleCancel} />
            )}
            {view === 'edit' && selectedCustomerId && (
                <CustomerForm
                    customerId={selectedCustomerId}
                    onSave={handleSave}
                    onCancel={handleCancel}
                />
            )}
        </div>
    );
};

export default CustomersPage;