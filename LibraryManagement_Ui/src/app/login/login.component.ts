import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from 'src/services/user.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  loginForm: FormGroup;

  constructor(private fb: FormBuilder,
    private userService: UserService,
    private toastr: ToastrService,
    private router: Router) {
    this.loginForm = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', Validators.required]
    });
  }

  onSubmit(): void {
    if (this.loginForm.valid) {
      this.userService.login(this.loginForm.value).subscribe(
        (response: any) => {
          debugger;
          localStorage.setItem('token', response.token);
          this.router.navigate(['/books-list']);
        },
        (response) => {
          debugger;
          this.toastr.error(response.error);
        }
      );
    }
  }
}
