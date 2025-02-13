import { Injectable } from '@angular/core';
import config from './configuration';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface CustomerModel {
  id?: number
  type: string
  displayName?: string
  additionalAddresses?: AddressModel[]
}
export interface CompanyModel extends CustomerModel {
  companyName: string
  fiscalCode?: string
  vatCode?: string
  pec?: string
  sdi?: string
  businessAddress: PostalAddressModel
}
export interface PersonModel extends CustomerModel {
  firstName: string
  lastName: string
  nickname?: string
  businessAddress: PostalAddressModel
}

export interface AddressModel {
  isBusiness?: boolean
  type: string
}

export interface PostalAddressModel extends AddressModel {
  street: string
  civicNumber: string
  city: string
  postalCode: string
  region: string
  country?: string
}

export interface EmailAddressModel {
  email: string
}
export interface PhoneNumberAddressModel {
  phoneNumber: string
}



@Injectable({
  providedIn: 'root'
})
export class CustomersService {

  constructor(private http: HttpClient) { }

  getCustomers(): Observable<CustomerModel[]> {
    return this.http.get<CustomerModel[]>(config.urls.customers.all)
  }
  addPerson(p: PersonModel): Observable<PersonModel> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<PersonModel>(config.urls.customers.addPerson, p, { headers })
  }
  addCompany(c: CompanyModel): Observable<CompanyModel> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<CompanyModel>(config.urls.customers.addCompany, c, { headers })
  }
}
