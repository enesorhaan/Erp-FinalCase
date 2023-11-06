import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators} from '@angular/forms';
import { AuthService } from '../../../services/auth.service';
import { Router } from '@angular/router';
import { StorageService } from '../../../services/storage.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  loginForm=new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required, Validators.minLength(5)])
  })

  constructor(
    private authService: AuthService,
    private router: Router,
    private storage: StorageService,
    private toastr: ToastrService
  ) { 
    this.toastr.success('Hi Vakifbank & Patika!', 'Have fun!');
  }
  onSubmit(){
    const {email, password} = this.loginForm.value;
    this.authService.login(email, password).subscribe({
      next: data => {
        if(data.success === false){
          this.toastr.error(data.message, 'Error');
          return;
        }
        console.log(data);
        this.storage.saveUser(data);
        this.router.navigate(['/dashboard']);
      },
      error: error => {
        if (error.status === 400 && error.error) {
          const validationErrors = error.error.errors;
          for (const field in validationErrors) {
            if (validationErrors.hasOwnProperty(field)) {
              const errorMessage = validationErrors[field].join(' ');
              console.log(`Error: ${field}, Message: ${errorMessage}`);
              this.toastr.error(`${errorMessage}`, 'Error');
            }
          }
        }else{
          this.toastr.error('API Connection Refused!', 'Error');
        }
      }
    })
  }

}
