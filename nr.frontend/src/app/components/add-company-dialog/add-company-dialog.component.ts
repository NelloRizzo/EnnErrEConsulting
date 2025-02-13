import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatInputModule } from '@angular/material/input';
import { CompanyModel } from '../../services/customers.service';

@Component({
  selector: 'app-add-company',
  imports: [MatDialogModule, MatFormFieldModule, MatButtonModule, MatInputModule, ReactiveFormsModule, MatGridListModule],
  templateUrl: './add-company-dialog.component.html',
  styleUrl: './add-company-dialog.component.scss'
})
export class AddCompanyDialogComponent {
  dataForm: FormGroup

  company?: CompanyModel

  constructor(public dialogRef: MatDialogRef<AddCompanyDialogComponent>, private fb: FormBuilder) {
    this.dataForm = this.fb.group({
      companyName: [this.company?.companyName],
      fiscalCode: [this.company?.fiscalCode],
      vatCode: [this.company?.vatCode],
      pec: [this.company?.pec],
      sdi: [this.company?.sdi],
      street: [this.company?.businessAddress.street],
      civicNumber: [this.company?.businessAddress.civicNumber],
      postalCode: [this.company?.businessAddress.postalCode],
      city: [this.company?.businessAddress.city],
      region: [this.company?.businessAddress.region],
    })
  }
  onCancel(): void { this.dialogRef.close() }

  onSubmit(): void {
    if (this.dataForm.valid) {
      this.dialogRef.close(this.dataForm.value)
    }
  }
}
