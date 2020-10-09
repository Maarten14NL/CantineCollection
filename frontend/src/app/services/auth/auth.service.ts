import { Injectable } from '@angular/core';
import {Router} from '@angular/router';
import {CollectionCallService} from '../collection-call/collection-call.service';
import {User} from '../../models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private loggedIn = false;
  loginUser: User;

  constructor(
    private collectionCallService: CollectionCallService,
    private router: Router
  ) { }

  logIn() {
    this.collectionCallService.get('/auth').subscribe(login => {
      this.loginUser = login;
      this.loggedIn = true;
      this.router.navigate(['/']);
    });
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
