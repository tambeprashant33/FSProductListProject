import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  username = '';
  password = '';
  errorMessage = '';

  constructor(private http: HttpClient, private router: Router) {}

  login() {
    const loginData = { username: this.username, password: this.password };

    this.http
      .post<{ token: string }>(`${environment.apiUrl}/auth/login`, loginData)
      .subscribe({
        next: (res) => {
          localStorage.setItem('jwtToken', res.token);
          this.router.navigate(['/add-product']);
        },
        error: () => {
          this.errorMessage = 'Invalid username or password.';
        },
      });
  }
}
