import {Component, ViewChild} from '@angular/core';
import {DriverListComponent} from "../../Shared/Modules/driver-list/driver-list.component";
import {AddDriverComponent} from "../../Shared/Modules/add-driver/add-driver.component";

@Component({
  selector: 'app-drivers-page',
  standalone: true,
  imports: [AddDriverComponent, DriverListComponent],
  templateUrl: './drivers-page.component.html',
  styleUrl: './drivers-page.component.css'
})
export class DriversPageComponent {
  currentTitle: string = 'Список водителей';

  @ViewChild(DriverListComponent) driverListComponent!: DriverListComponent;

  onDriverAdded() {
    this.driverListComponent.loadDrivers();
  }
}
