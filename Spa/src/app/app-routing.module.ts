import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './main/dashboard/dashboard.component';
import { UserProfileComponent } from './main/user-profile/user-profile.component';

const routes: Routes = [
  {
    path: 'dashboard', 
    component: DashboardComponent
  },
  {
    path: 'teacherProfile', 
    component: UserProfileComponent
  },
  {
    path: '', redirectTo: 'dashboard', pathMatch: 'full'
  },
  {
    path: '**', component: DashboardComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
