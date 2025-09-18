// models/customerModels.ts
export interface AddressModel {
  id?: number;
  $type: string;
}

export interface UserModel {
  id?: number;
  username: string;
  email: string;
  isActive: boolean;
}

export interface PostalAddressModel extends AddressModel {
  street: string;
  civicNumber: string;
  city: string;
  postalCode: string;
  region: string;
  country: string;
}

export interface CustomerModel {
  id: number;
  additionalAddresses: AddressModel[];
  //users: UserModel[];
  displayName?: string;
  $type: 'person' | 'company';
}

export interface CompanyModel extends CustomerModel {
  companyName: string;
  fiscalCode?: string;
  vatCode?: string;
  pec?: string;
  sdi?: string;
  businessAddress: PostalAddressModel;
}

export interface PersonModel extends CustomerModel {
  firstName: string;
  lastName: string;
  nickname?: string;
  businessAddress: PostalAddressModel;
}

// Type guard functions
export function isCompanyModel(customer: CustomerModel): customer is CompanyModel {
  return customer.$type === 'company';
}

export function isPersonModel(customer: CustomerModel): customer is PersonModel {
  return customer.$type === 'person';
}