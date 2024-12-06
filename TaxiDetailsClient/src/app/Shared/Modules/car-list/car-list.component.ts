import {Component, OnInit} from '@angular/core';
import {Car, CarDto, CarService, Driver, DriverService} from "../../../api";
import {NgForOf, NgIf} from "@angular/common";
import {FormsModule} from "@angular/forms";
import {ButtonsComponent} from "../../Components/buttons/buttons.component";

@Component({
  selector: 'app-car-list',
  standalone: true,
  imports: [
    NgForOf,
    FormsModule,
    NgIf,
    ButtonsComponent
  ],
  templateUrl: './car-list.component.html',
  styleUrl: './car-list.component.css'
})
export class CarListComponent implements OnInit {
  cars: Car[] = [];
  editingStates: { [id: number]: boolean } = {};
  originalCars: { [id: number]: Car } = {};
  drivers: Driver[] = [];

  constructor(private carService: CarService, private driverService: DriverService) {
  }

  ngOnInit(): void {
    this.loadCars();
  }

  startEdit(carId: number): void {
    this.editingStates[carId] = true;
  }

  saveCar(car: Car): void {
    const carDto: CarDto = {
      plate: car.plate!,
      model: car.model!,
      color: car.color!,
      assignedDriverId: car.assignedDriver.id
    };

    this.carService.apiCarIdPut(car.id!, carDto).subscribe(() => {
      this.loadCars();
    });
  }

  cancelEdit(carId: number): void {
    const original = this.originalCars[carId];
    if (original) {
      const index = this.cars.findIndex(c => c.id === carId);
      if (index !== -1) {
        Object.assign(this.cars[index], original);
      }
    }
    this.editingStates[carId] = false;
  }

  deleteCar(carId: number): void {
    this.carService.apiCarIdDelete(carId).subscribe({
      next: () => {
        this.carService.apiCarGet().subscribe(cars => {
          this.cars = cars;
        });
      }
    });
  }

  loadCars(): void {
    this.carService.apiCarGet().subscribe((cars) => {
      this.cars = cars;
      this.cars.forEach((car) => {
        this.editingStates[car.id!] = false;
        this.originalCars[car.id!] = {...car};
      });
    });
    this.driverService.apiDriverGet().subscribe(drivers => {
      this.drivers = drivers;
    });
  }
}
