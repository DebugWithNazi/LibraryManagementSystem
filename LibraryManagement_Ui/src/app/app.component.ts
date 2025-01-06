import { Component, OnInit } from '@angular/core';
import { jwtDecode } from 'jwt-decode';
import { JwtPayload } from './Models';
import { AuthService } from 'src/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Library Management System';
  constructor(public authService: AuthService, private router: Router) {

  }

  ngOnInit(): void {

  }

  logout(): void {
    // Clear session storage and navigate to the login page
    sessionStorage.removeItem('token');
    this.router.navigate(['/login']);
  }
}


