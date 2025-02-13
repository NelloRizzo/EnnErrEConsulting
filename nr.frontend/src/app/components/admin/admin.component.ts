import { NgFor } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-admin',
  imports: [NgFor],
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.scss'
})
export class AdminComponent {
  cards = [
    { title: 'Clienti', description: 'Gestione clienti', link: '/admin/customers' },
    { title: 'Corsi', description: 'Gestione corsi, argomenti e allegati', link: '/admin/courses' },
    { title: 'Utenti', description: 'Gestione utenti', link: '/admin/users' },
  ]
}
