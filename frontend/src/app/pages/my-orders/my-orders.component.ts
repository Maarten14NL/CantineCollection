import { Component, OnInit } from '@angular/core';
import {AuthService} from '../../services/auth/auth.service';
import {CollectionCallService} from '../../services/collection-call/collection-call.service';
import {User} from '../../models/user';
import {OrderList} from '../../models/order-list';

@Component({
  selector: 'app-user-profile',
  templateUrl: './my-orders.component.html',
  styleUrls: ['./my-orders.component.scss']
})
export class MyOrdersComponent implements OnInit {

  user: User;
  orderLists: OrderList[];
  selectedOrderList: OrderList;

  constructor(
    private authService: AuthService,
    private collectionCallService: CollectionCallService
  ) { }

  ngOnInit() {
    this.collectionCallService.get('api/myorders').subscribe(res => {
      console.log(res);
      this.orderLists = res;
      this.selectedOrderList = res[0];
    });
    this.user = this.authService.loginUser;
  }

  selectActiveOrderList(orderLists: OrderList){
    this.selectedOrderList = orderLists;
  }

}
