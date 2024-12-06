import { Component } from '@angular/core';
import {Driver, DriverDto, DriverService, User, UserDto, UserService} from "../../../api";
import {ButtonsComponent} from "../../Components/buttons/buttons.component";
import {NgForOf} from "@angular/common";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";

@Component({
  selector: 'app-driver-list',
  standalone: true,
  imports: [ButtonsComponent, NgForOf, ReactiveFormsModule, FormsModule],
  templateUrl: './driver-list.component.html',
  styleUrl: './driver-list.component.css'
})
export class DriverListComponent {
  drivers: Driver[] = [];
  editingStates: { [id: number]: boolean } = {};
  originalDrivers: { [id: number]: Driver } = {};

  constructor(private driverService: DriverService) {
  }

  ngOnInit(): void {
    this.loadDrivers();
  }

  startEdit(driverId: number): void {
    this.editingStates[driverId] = true;
  }

  saveDriver(driver: Driver): void {
    const driverDto: DriverDto = {
      name: driver.name!,
      surname: driver.surname!,
      patronymic: driver.patronymic!,
      passport: driver.passport!,
      address: driver.address!,
      phone: driver.phone!
    }
    this.driverService.apiDriverIdPut(driver.id!, driverDto).subscribe(() => {
      this.editingStates[driver.id!] = false;
      this.originalDrivers[driver.id!] = {...driver};
    });
  }

  cancelEdit(driverId: number): void {
    const original = this.originalDrivers[driverId];
    if (original) {
      const index = this.drivers.findIndex(c => c.id === driverId);
      if (index !== -1) {
        Object.assign(this.drivers[index], original);
      }
    }
    this.editingStates[driverId] = false;
  }

  deleteDriver(driverId: number): void {
    this.driverService.apiDriverIdDelete(driverId).subscribe({
      next: () => {
        this.driverService.apiDriverGet().subscribe(drivers => {
          this.drivers = drivers;
        });
      }
    });
  }

  loadDrivers(): void {
    this.driverService.apiDriverGet().subscribe((drivers) => {
      this.drivers = drivers;
      this.drivers.forEach((driver) => {
        this.editingStates[driver.id!] = false;
        this.originalDrivers[driver.id!] = {...driver};
      });
    });
  }
}
