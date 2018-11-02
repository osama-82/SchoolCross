import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { SecurityService } from '../_services/security.service';
import { AppUser } from '../_models/app-user';
import { AppUserAuth } from '../_models/app-user-auth';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss'],
})
export class MainComponent implements OnInit {

  user: AppUser;

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches)
    );

  constructor(private breakpointObserver: BreakpointObserver,
              public securityService: SecurityService) {}

  stopPropagation(event){
    event.stopPropagation();
  }

  ngOnInit() {
    this.user = new AppUser();
  }

  login() {
    this.securityService.login(this.user)
      .subscribe(resp => {
        console.log('log in succeeded');
      }, error => {
        console.log(error);
    });
  }
}
