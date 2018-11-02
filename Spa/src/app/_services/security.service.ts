import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';

import { AppUserAuth } from '../_models/app-user-auth';
import { AppUser } from '../_models/app-user';

@Injectable()
export class SecurityService {

    userSecurity: AppUserAuth;

    constructor(private http: HttpClient) {
        this.userSecurity = new AppUserAuth();
     }

    login(loginData: AppUser): Observable<AppUserAuth> {

        this.resetSecurityObject();
        return this.http.post('/api/Values', loginData).pipe(
            map((response: AppUserAuth) => {
                this.userSecurity = response;
                localStorage.setItem("bearerToken",
            this.userSecurity.bearerToken);
              return this.userSecurity;
          })
          )
      }

      logout(): void {
        this.resetSecurityObject();
      }

      resetSecurityObject(): void {
        this.userSecurity.userName = "";
        this.userSecurity.bearerToken = "";
        this.userSecurity.isAuthenticated = false;
    
        this.userSecurity.claims = [];
    
        localStorage.removeItem("bearerToken");
      }
}