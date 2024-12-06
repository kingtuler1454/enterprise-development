import {Component, ViewChild} from '@angular/core';
import {CarListComponent} from "../../Shared/Modules/car-list/car-list.component";
import {AddCarComponent} from "../../Shared/Modules/add-car/add-car.component";

@Component({
  selector: 'app-cars-page',
  standalone: true,
  imports: [
    AddCarComponent,
    CarListComponent
  ],
  templateUrl: './cars-page.component.html',
  styleUrl: './cars-page.component.css'
})
export class CarsPageComponent {
  currentTitle: string = 'Список автомобилей';

  @ViewChild(CarListComponent) carListComponent!: CarListComponent;

  onCarAdded() {
    this.carListComponent.loadCars();
  }
}
