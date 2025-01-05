import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoggedinDto, LoginDto, RegisterDto } from 'src/app/Models';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = 'https://localhost:7059/user';

  constructor(private http: HttpClient) {}
  
  register(dto: RegisterDto): Observable<any> {
    debugger;
    return this.http.post(`${this.apiUrl}/register`, dto);
  }
  
  login(dto: LoginDto): Observable<LoggedinDto> {
    
    return this.http.post<LoggedinDto>(`${this.apiUrl}/login`, dto);
  }
}
