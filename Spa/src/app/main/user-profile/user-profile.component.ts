import { Component, OnInit } from '@angular/core';
import { SecurityService } from '../../_services/security.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})
export class UserProfileComponent implements OnInit {

  constructor(public securityService: SecurityService) { }

  ngOnInit() {
  }

}
