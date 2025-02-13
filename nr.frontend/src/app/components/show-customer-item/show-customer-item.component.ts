import { Component, Input } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { CustomerModel } from '../../services/customers.service';
import { NgIf } from '@angular/common';

@Component({
  imports: [MatIconModule, NgIf],
  templateUrl: './show-customer-item.component.html',
  styleUrl: './show-customer-item.component.scss',
  selector: 'app-show-customer-item'
})
export class ShowCustomerItemComponent {

  @Input()
  customer!: CustomerModel;

  
}
