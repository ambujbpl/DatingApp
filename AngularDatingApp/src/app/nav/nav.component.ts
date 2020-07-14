import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};

  constructor(public authService: AuthService) { }

  // tslint:disable-next-line: typedef
  ngOnInit() {
  }

  // tslint:disable-next-line: typedef
  login() {
    this.authService.login(this.model).subscribe(next => {
      console.log('Login successfully');
    }, error => {
      console.log(error);
    });
    console.log('submitted value is :- ', this.model);
  }

  // tslint:disable-next-line: typedef
  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }

  // tslint:disable-next-line: typedef
  logout() {
    localStorage.removeItem('token');
    console.log('logout successfully');
  }
}
