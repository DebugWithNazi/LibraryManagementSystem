import { Injectable } from '@angular/core';
import { jwtDecode } from 'jwt-decode';
import { JwtPayload } from 'src/app/Models';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor() { }

  /**
   * Checks if a user is logged in by verifying the existence of a token in sessionStorage.
   */
  get isUserLogin(): boolean {
    const token = sessionStorage.getItem('token');
    return token != null;
  }

  /**
   * Decodes the JWT token and checks if the user is an admin.
   */
  get isAdmin(): boolean {
    const token = sessionStorage.getItem('token');
    if (token) {
      debugger
      const decodedToken = jwtDecode<JwtPayload>(token);
      return decodedToken.isAdmin.toLowerCase() === 'true';
    }
    return false;
  }

  get userName(): string {
    const token = sessionStorage.getItem('token');
    if (token) {
      debugger
      const decodedToken = jwtDecode<JwtPayload>(token);
      return decodedToken.username;
    }
    return '';
  }

}
