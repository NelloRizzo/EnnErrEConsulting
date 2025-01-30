import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import config from './configuration'
import { LoginResponseModel, RegisterUserRequestModel } from './models'
import { Observable } from 'rxjs'

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  get username(): string | null {
    return localStorage.getItem("username")
  }
  set username(value: string) {
    localStorage.setItem("username", value)
  }

  get password(): string | null {
    return localStorage.getItem("password")
  }
  set password(value: string) {
    localStorage.setItem("password", value)
  }

  get token(): string | null {
    return localStorage.getItem("token")
  }
  set token(value: string) {
    localStorage.setItem("token", value)
  }

  async login(username: string, password: string): Promise<Observable<LoginResponseModel>> {
    return this.http.post<LoginResponseModel>(config.urls.login, { 'username': username, 'password': password })
      .pipe(resp => {
        resp.subscribe(b => {
          this.username = b.username
          this.password = password
          this.token = b.token
        })
        return resp
      })
  }

  async registerUser(user: RegisterUserRequestModel): Promise<Observable<RegisterUserRequestModel | null>> {
    return this.http.post<RegisterUserRequestModel>(config.urls.registerUser, user);
  }
}
