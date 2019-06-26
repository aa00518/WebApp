import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { MainDashboardComponent } from './components/main-dashboard/main-dashboard.component';
import { MainTableComponent } from './components/main-table/main-table.component';
import { SettingsComponent } from './components/settings/settings.component';
import { NewDashboardComponent } from './components/new-dashboard/new-dashboard.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'main-dashboard', component: MainDashboardComponent },
  { path: 'main-table', component: MainTableComponent },
  { path: 'settings', component: SettingsComponent },
  { path: 'new-dashboard', component: NewDashboardComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
