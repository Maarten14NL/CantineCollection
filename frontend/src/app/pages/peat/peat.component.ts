import { Component, OnInit } from '@angular/core';
import {CollectionCallService} from '../../services/collection-call/collection-call.service';
import {User} from '../../models/user';

@Component({
  selector: 'app-peat',
  templateUrl: './peat.component.html',
  styleUrls: ['./peat.component.css']
})
export class PeatComponent implements OnInit {
  users: User[];
  constructor(
    private collectionCallService: CollectionCallService
  ) { }

  ngOnInit(): void {
    this.collectionCallService.get('api/peat').subscribe(res => {
      this.users = res;
      console.log(res);
    });
  }

  changeAmount(user, calculate = 1) {
    user.lastOrder.amount += calculate;
    this.collectionCallService.post('api/order', user.lastOrder).subscribe(res => {
    }, error => {
      user.lastOrder.amount -= calculate;
    });
  }

}
