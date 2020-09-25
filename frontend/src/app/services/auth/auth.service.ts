import { Injectable } from '@angular/core';
import {Router} from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private router: Router
  ) { }
  private loggedIn = false;

  logIn() {
    this.loggedIn = true;
    this.router.navigate(['/']);
  }

  logOut() {
    this.loggedIn = false;
    this.isLoggedIn();
  }

  isLoggedIn() {
    if (!this.loggedIn) {
      this.router.navigate(['/login']);
    }
  }
}
