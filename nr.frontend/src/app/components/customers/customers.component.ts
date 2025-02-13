import { Component, OnInit } from '@angular/core';
import { CompanyModel, CustomerModel, CustomersService, PersonModel } from '../../services/customers.service';
import { NgFor, NgIf } from '@angular/common';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { AddPersonDialogComponent } from '../add-person-dialog/add-person-dialog.component';
import { MatButtonModule } from '@angular/material/button';
import { AddCompanyDialogComponent } from '../add-company-dialog/add-company-dialog.component';
import { ShowCustomerItemComponent } from "../show-customer-item/show-customer-item.component";

@Component({
  selector: 'app-customers',
  imports: [NgFor, NgIf, MatButtonModule, ShowCustomerItemComponent],
  templateUrl: './customers.component.html',
  styleUrl: './customers.component.scss'
})
export class CustomersComponent implements OnInit {

  customers: CustomerModel[] = [];

  constructor(private customerService: CustomersService, public dialog: MatDialog) { }

  ngOnInit(): void {
    this.loadCustomers()
  }

  private loadCustomers() {
    this.customerService.getCustomers().subscribe(customers => this.customers = customers);
  }

  addPersonDialog(): void {
    const dialogRef = this.dialog.open(AddPersonDialogComponent)
    dialogRef.afterClosed().subscribe(p => {
      const person: PersonModel = { firstName: p.firstName, lastName: p.lastName, nickname: p.nickname, businessAddress: { street: p.street, civicNumber: p.civicNumber, postalCode: p.postalCode, city: p.city, region: p.region, type: 'postalAddress' }, type: 'person' }
      this.customerService.addPerson(person).subscribe(r => this.loadCustomers())
    })
  }
  
  addCompanyDialog(): void {
    const dialogRef = this.dialog.open(AddCompanyDialogComponent)
    dialogRef.afterClosed().subscribe(c => {
      const company: CompanyModel = { companyName: c.companyName, fiscalCode: c.fiscalCode, vatCode: c.vatCode, pec: c.pec, businessAddress: { street: c.street, civicNumber: c.civicNumber, postalCode: c.postalCode, city: c.city, region: c.region, type: 'postalAddress' }, type: 'company' }
      this.customerService.addCompany(company).subscribe(r => this.loadCustomers())
    })
  }
}
