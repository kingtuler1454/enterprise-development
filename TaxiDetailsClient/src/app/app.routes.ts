import {RouterModule, Routes} from '@angular/router';
import {HomePageComponent} from "./Pages/home-page/home-page.component";
import {CarsPageComponent} from "./Pages/cars-page/cars-page.component";
import {DriversPageComponent} from "./Pages/drivers-page/drivers-page.component";
import {TravelsPageComponent} from "./Pages/travels-page/travels-page.component";
import {UsersPageComponent} from "./Pages/users-page/users-page.component";
import {ErrorPageComponent} from "./Pages/error-page/error-page.component";
import {NgModule} from "@angular/core";

export const routes: Routes = [
  {path: '', component: HomePageComponent},
  {path: 'cars', component: CarsPageComponent},
  {path: 'drivers', component: DriversPageComponent},
  {path: 'travels', component: TravelsPageComponent},
  {path: 'users', component: UsersPageComponent},
  {path: '**', component: ErrorPageComponent}
];

@NgModule({ imports: [RouterModule.forRoot(routes)], exports: [RouterModule] })
export class AppRoutingModule { }