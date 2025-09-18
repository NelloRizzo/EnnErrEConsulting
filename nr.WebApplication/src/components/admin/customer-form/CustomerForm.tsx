// components/CustomerForm.tsx
import React, { useState, useEffect } from 'react';
import { CustomerModel, CompanyModel, PersonModel, isCompanyModel, isPersonModel, PostalAddressModel } from '../../../types/customers';
import { customerService } from '../../../services/customer-service';
import './CustomerForm.scss';

interface CustomerFormProps {
    customerId?: number;
    onSave?: () => void;
    onCancel?: () => void;
}

const CustomerForm: React.FC<CustomerFormProps> = ({ customerId, onSave, onCancel }) => {
    const [customerType, setCustomerType] = useState<'person' | 'company'>('person');
    const [customer, setCustomer] = useState<CustomerModel | null>(null);
    const [loading, setLoading] = useState<boolean>(!!customerId);
    const [saving, setSaving] = useState<boolean>(false);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        if (customerId) {
            loadCustomer();
        }
    }, [customerId]);

    const loadCustomer = async () => {
        try {
            setLoading(true);
            const response = await customerService.getCustomerById(customerId!);
            setCustomer(response);
            setCustomerType(response.$type);
        } catch (err) {
            setError('An error occurred while loading the customer');
        } finally {
            setLoading(false);
        }
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setSaving(true);
        setError(null);

        try {
            let response;
            const customerData = customer || (customerType === 'company'
                ? { $type: 'company' } as CompanyModel
                : { $type: 'person' } as PersonModel);

            if (customerId) {
                response = await customerService.updateCustomer(customerId, customerData);
            } else {
                response = await customerService.createCustomer(customerData);
            }

            onSave?.();
        } catch (err) {
            setError('An error occurred while saving the customer');
        } finally {
            setSaving(false);
        }
    };

    const updateField = (field: string, value: any) => {
        setCustomer(prev => ({
            ...prev!,
            [field]: value
        }));
    };

    if (loading) return <div className="loading">Loading customer...</div>;

    return (
        <div className="customer-form">
            <h2>{customerId ? 'Edit Customer' : 'Create New Customer'}</h2>

            {error && <div className="error-message">{error}</div>}

            <form onSubmit={handleSubmit}>
                {!customerId && (
                    <div className="form-group">
                        <label>Customer Type</label>
                        <div className="type-selector">
                            <button
                                type="button"
                                className={customerType === 'person' ? 'active' : ''}
                                onClick={() => setCustomerType('person')}
                            >
                                Person
                            </button>
                            <button
                                type="button"
                                className={customerType === 'company' ? 'active' : ''}
                                onClick={() => setCustomerType('company')}
                            >
                                Company
                            </button>
                        </div>
                    </div>
                )}

                {customerType === 'company' ? (
                    <CompanyFormFields
                        customer={customer as CompanyModel}
                        onChange={updateField}
                    />
                ) : (
                    <PersonFormFields
                        customer={customer as PersonModel}
                        onChange={updateField}
                    />
                )}

                <div className="form-actions">
                    <button type="button" onClick={onCancel} disabled={saving}>
                        Cancel
                    </button>
                    <button type="submit" disabled={saving}>
                        {saving ? 'Saving...' : 'Save Customer'}
                    </button>
                </div>
            </form>
        </div>
    );
};

const CompanyFormFields: React.FC<{
    customer?: CompanyModel;
    onChange: (field: string, value: any) => void;
}> = ({ customer, onChange }) => {
    return (
        <>
            <div className="form-group">
                <label>Company Name *</label>
                <input
                    type="text"
                    value={customer?.companyName || ''}
                    onChange={(e) => onChange('companyName', e.target.value)}
                    required
                />
            </div>

            <div className="form-group">
                <label>Fiscal Code</label>
                <input
                    type="text"
                    value={customer?.fiscalCode || ''}
                    onChange={(e) => onChange('fiscalCode', e.target.value)}
                    maxLength={16}
                />
            </div>

            <div className="form-group">
                <label>VAT Code</label>
                <input
                    type="text"
                    value={customer?.vatCode || ''}
                    onChange={(e) => onChange('vatCode', e.target.value)}
                    maxLength={11}
                />
            </div>

            <div className="form-group">
                <label>PEC Email</label>
                <input
                    type="email"
                    value={customer?.pec || ''}
                    onChange={(e) => onChange('pec', e.target.value)}
                />
            </div>

            <div className="form-group">
                <label>SDI Code</label>
                <input
                    type="text"
                    value={customer?.sdi || ''}
                    onChange={(e) => onChange('sdi', e.target.value)}
                    maxLength={5}
                />
            </div>

            <AddressForm
                address={customer?.businessAddress}
                onChange={(addr) => onChange('businessAddress', addr)}
                title="Business Address"
            />
        </>
    );
};

const PersonFormFields: React.FC<{
    customer?: PersonModel;
    onChange: (field: string, value: any) => void;
}> = ({ customer, onChange }) => {
    return (
        <>
            <div className="form-group">
                <label>First Name *</label>
                <input
                    type="text"
                    value={customer?.firstName || ''}
                    onChange={(e) => onChange('firstName', e.target.value)}
                    required
                />
            </div>

            <div className="form-group">
                <label>Last Name *</label>
                <input
                    type="text"
                    value={customer?.lastName || ''}
                    onChange={(e) => onChange('lastName', e.target.value)}
                    required
                />
            </div>

            <div className="form-group">
                <label>Nickname</label>
                <input
                    type="text"
                    value={customer?.nickname || ''}
                    onChange={(e) => onChange('nickname', e.target.value)}
                />
            </div>

            <AddressForm
                address={customer?.businessAddress}
                onChange={(addr) => onChange('businessAddress', addr)}
                title="Business Address"
            />
        </>
    );
};

const AddressForm: React.FC<{
    address?: PostalAddressModel;
    onChange: (address: any) => void;
    title: string;
}> = ({ address, onChange, title }) => {
    const updateAddressField = (field: string, value: string) => {
        onChange({
            ...address,
            [field]: value
        });
    };

    return (
        <div className="address-section">
            <h3>{title}</h3>
            <div className="form-group">
                <label>Street</label>
                <input
                    type="text"
                    value={address?.street || ''}
                    onChange={(e) => updateAddressField('street', e.target.value)}
                />
            </div>
            <div className="form-group">
                <label>Provincia</label>
                <input
                    type="text"
                    value={address?.region || ''}
                    onChange={(e) => updateAddressField('region', e.target.value)}
                />
            </div>
            <div className="form-group">
                <label>ZIP Code</label>
                <input
                    type="text"
                    value={address?.postalCode || ''}
                    onChange={(e) => updateAddressField('postalCode', e.target.value)}
                />
            </div>
            <div className="form-group">
                <label>Country</label>
                <input
                    type="text"
                    value={address?.country || ''}
                    onChange={(e) => updateAddressField('country', e.target.value)}
                />
            </div>
        </div>
    );
};

export default CustomerForm;