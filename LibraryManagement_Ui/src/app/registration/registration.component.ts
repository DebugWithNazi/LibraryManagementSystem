import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from 'src/services/user.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent {
  registerForm: FormGroup;

  constructor(private fb: FormBuilder, 
     private userService: UserService,
     private toastr: ToastrService) {
    this.registerForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }
  onSubmit(): void {
    if (this.registerForm.valid) {
      this.userService.register(this.registerForm.value).subscribe(
        (response:any) => {
          debugger;
          this.registerForm.reset();
          this.toastr.success(response.message);
        },
        (response) => {
          debugger;
          this.toastr.error(response.error);
        }
      );
    }
  }
}
