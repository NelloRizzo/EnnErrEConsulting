import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { BannerComponent } from "./components/banner/banner.component";
import { NavBarComponent } from "./components/nav-bar/nav-bar.component";
import { HomeComponent } from "./components/home/home.component";
import { LoginComponent } from "./components/login/login.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NavBarComponent, HomeComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'nr.FrontEnd';
}
