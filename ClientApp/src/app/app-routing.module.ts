import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent }//,
  // { path: 'whrep', component: WhrepComponent },
  // { path: 'frrep', component: FrrepComponent },
  // { path: 'sandbox', component: SandboxComponent },
  // { path: 'lineaccountingdays', component: LineaccountingdaysComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
