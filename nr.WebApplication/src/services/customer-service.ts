// services/customerService.ts
import { CustomerModel, CompanyModel, PersonModel, isPersonModel } from '../types/customers';
import { API_BASE_URL } from './configuration';

class CustomerService {
    private baseUrl: string = `${API_BASE_URL}/api/customers`;

    // Get all customers
    async getCustomers(): Promise<CustomerModel[]> {
        try {
            const response = await fetch(this.baseUrl);
            return await response.json();
        } catch (error) {
            throw new Error(`Failed to fetch customers: ${error}`);
        }
    }

    // Get customer by ID
    async getCustomerById(id: number): Promise<CustomerModel> {
        try {
            const response = await fetch(`${this.baseUrl}/${id}`);
            return await response.json();
        } catch (error) {
            throw new Error(`Failed to fetch customer: ${error}`);
        }
    }

    // Create new customer
    async createCompany(customer: CompanyModel): Promise<CustomerModel> {
        try {
            const response = await fetch(`${this.baseUrl}/company`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(customer),
            });
            return await response.json();
        } catch (error) {
            throw new Error(`Failed to create customer: ${error}`);
        }
    }
    async createPerson(customer: PersonModel): Promise<CustomerModel> {
        try {
            console.log("CustomerService", "Saving person", customer)
            const response = await fetch(`${this.baseUrl}/person`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(customer),
            });
            return await response.json();
        } catch (error) {
            throw new Error(`Failed to create customer: ${error}`);
        }
    }

    // Update customer
    async updateCustomer(id: number, customer: CustomerModel): Promise<CustomerModel> {
        try {
            const response = await fetch(`${this.baseUrl}/${id}/${isPersonModel(customer) ? 'person' : 'company'}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(customer),
            });
            return await response.json();
        } catch (error) {
            throw new Error(`Failed to update customer: ${error}`);
        }
    }

    // Delete customer
    async deleteCustomer(id: number): Promise<void> {
        try {
            const response = await fetch(`${this.baseUrl}/${id}`, {
                method: 'DELETE',
            });
            return await response.json();
        } catch (error) {
            throw new Error(`Failed to delete customer: ${error}`);
        }
    }
}

export const customerService = new CustomerService();