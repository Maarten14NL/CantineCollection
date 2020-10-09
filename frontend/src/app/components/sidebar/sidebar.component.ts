import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
}
export const ROUTES: RouteInfo[] = [
    { path: '/dashboard', title: 'Dashboard',  icon: 'ni-tv-2', class: '' },
    { path: '/bestellingen', title: 'Bestellingen',  icon: 'ni-bullet-list-67', class: '' },
    { path: '/lappen', title: 'Lappen',  icon: 'ni-money-coins', class: '' },
];

export const BARTENDERROUTES: RouteInfo[] = [
  { path: '/turven', title: 'Turven',  icon: 'ni-bullet-list-67', class: '' },
  { path: '/lappen', title: 'Lappotten',  icon: 'ni-money-coins', class: '' },
];

export const ADMINROUTES: RouteInfo[] = [
  { path: '/Assortiment', title: 'Assortiment',  icon: 'ni-tv-2', class: '' },
  { path: '/gebruikers', title: 'Gebruikers',  icon: 'ni-circle-08', class: '' },
  { path: '/bestellingen', title: 'Turven',  icon: 'ni-bullet-list-67', class: '' },
  { path: '/lappen', title: 'Lappotten',  icon: 'ni-money-coins', class: '' },

];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  public menuItems: any[];
  public menuAdminItems: any[];
  public menuBartenderItems: any[];
  public isCollapsed = true;

  constructor(private router: Router) { }

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
    this.menuAdminItems = ADMINROUTES.filter(menuItem => menuItem);
    this.menuBartenderItems = BARTENDERROUTES.filter(menuItem => menuItem);
    this.router.events.subscribe((event) => {
      this.isCollapsed = true;
   });
  }
}
