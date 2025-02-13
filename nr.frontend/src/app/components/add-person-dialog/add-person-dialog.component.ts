import { Component } from '@angular/core'
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog'
import { MatFormFieldModule } from '@angular/material/form-field'
import { MatInputModule } from '@angular/material/input'
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms'
import { MatGridListModule } from '@angular/material/grid-list'
import { MatButtonModule } from '@angular/material/button';
import { PersonModel } from '../../services/customers.service'
@Component({
  selector: 'app-add-person-dialog',
  imports: [MatDialogModule, MatFormFieldModule, MatButtonModule, MatInputModule, ReactiveFormsModule, MatGridListModule],
  templateUrl: './add-person-dialog.component.html',
  styleUrl: './add-person-dialog.component.scss'
})
export class AddPersonDialogComponent {
  dataForm: FormGroup

  person?: PersonModel

  constructor(public dialogRef: MatDialogRef<AddPersonDialogComponent>, private fb: FormBuilder) {
    this.dataForm = this.fb.group({
      firstName: [this.person?.firstName],
      lastName: [this.person?.lastName],
      nickname: [this.person?.nickname],
      street: [this.person?.businessAddress.street],
      civicNumber: [this.person?.businessAddress.civicNumber],
      postalCode: [this.person?.businessAddress.postalCode],
      city: [this.person?.businessAddress.city],
      region: [this.person?.businessAddress.region],
    })
  }

  onCancel(): void { this.dialogRef.close() }

  onSubmit(): void {
    if (this.dataForm.valid) {
      this.dialogRef.close(this.dataForm.value)
    }
  }
}
