import { Component, OnInit } from '@angular/core';
import {AuthService} from '../../services/auth/auth.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './my-orders.component.html',
  styleUrls: ['./my-orders.component.scss']
})
export class MyOrdersComponent implements OnInit {

  user;

  constructor(
    private authService: AuthService
  ) { }

  public orders: any[];
  ngOnInit() {
    this.orders = [1, 2, 3, 4, 5, 6, 7, 8, 9];
    console.log(this.orders)
    this.user = this.authService.loginUser;
  }

}
