import { Component } from '@angular/core';
import { LoginComponent } from "../login/login.component";

@Component({
  selector: 'app-nav-bar',
  imports: [LoginComponent],
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.scss'
})
export class NavBarComponent {

}
