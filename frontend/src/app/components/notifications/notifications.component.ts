import { Component, OnInit } from '@angular/core';
import {NotificationService} from '../../services/notificiation/notification.service';
import {Notification} from '../../models/notification';
import {not} from 'rxjs/internal-compatibility';

@Component({
  selector: 'app-notifications',
  templateUrl: './notifications.component.html',
  styleUrls: ['./notifications.component.css']
})
export class NotificationsComponent implements OnInit {

  notifications: Notification[];

  constructor(private notificationService: NotificationService) {
    this.notifications = notificationService.notifications;
  }

  ngOnInit(): void {

  }


  removeNotification(notification: Notification) {
    this.notificationService.removeNotification(notification);
  }

}
