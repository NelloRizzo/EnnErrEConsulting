import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

  _visible: boolean = false
  _eye: string = 'block'
  _hidden: string = 'none'

  username?: string
  password?: string
  get modelValid(): string | null { return this.username && this.password ? null : 'disabled' }

  get visible() { return this._visible }
  set visible(value: boolean) {
    this._visible = value
  }

  toggleVisible() { this.visible = !this.visible }

  constructor(private service: UserService, private router: Router) { }

  async login() {
    await this.service.login(this.username!, this.password!)
    this.router.navigateByUrl('/')
  }
}
