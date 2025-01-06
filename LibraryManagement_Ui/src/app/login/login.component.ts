import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from 'src/services/user.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { AuthService } from 'src/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  constructor(private fb: FormBuilder,
    private userService: UserService,
    private toastr: ToastrService,
    private router: Router,
    private authService: AuthService) {
    this.loginForm = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.redirects();
  }

  redirects() {
    if (this.authService.isUserLogin) {
      if (this.authService.isAdmin) {
        this.router.navigate(['/books-list']);
      } else {
        this.router.navigate(['/my-books']);
      }
    }
  }

  onSubmit(): void {
    if (this.loginForm.valid) {
      this.userService.login(this.loginForm.value).subscribe(
        (response: any) => {
          debugger;
          sessionStorage.setItem('token', response.token);
          this.redirects()
        },
        (response) => {
          debugger;
          this.toastr.error(response.error);
        }
      );
    }
  }
}
