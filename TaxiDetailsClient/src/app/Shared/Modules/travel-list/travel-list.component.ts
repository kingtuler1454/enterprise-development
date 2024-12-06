import {Component, OnInit} from '@angular/core';
import {Car, TravelDto, CarService, Travel, TravelService, User, UserService} from "../../../api";
import {ButtonsComponent} from "../../Components/buttons/buttons.component";
import {NgForOf, NgIf} from "@angular/common";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";


@Component({
  selector: 'app-travel-list',
  standalone: true,
  imports: [
    ButtonsComponent,
    NgForOf,
    NgIf,
    ReactiveFormsModule,
    FormsModule
  ],
  templateUrl: './travel-list.component.html',
  styleUrl: './travel-list.component.css'
})
export class TravelListComponent implements OnInit {
  travels: Travel[] = [];
  editingStates: { [id: number]: boolean } = {};
  originalTravels: { [id: number]: Travel} = {};
  cars: Car[] = [];
  users: User[] = [];

  constructor(private carService: CarService, private userService: UserService, private travelService: TravelService) {
  }

  ngOnInit(): void {
    this.loadTravels();
  }

  startEdit(carId: number): void {
    this.editingStates[carId] = true;
  }

  saveTravel(travel: Travel): void {
    const oldTravel = this.originalTravels[travel.id!];

    if (!oldTravel) {
      this.editingStates[travel.id!] = false;
      return;
    }

    const newCost = Number(travel.cost);
    if (isNaN(newCost)) {
      travel.cost = oldTravel.cost;
    }
    const travelDto: TravelDto = {
      departurePoint: travel.departurePoint!,
      destinationPoint: travel.destinationPoint!,
      tripDate: travel.tripDate!,
      travelTime: travel.travelTime!,
      cost: travel.cost!,
      assignedCarId: travel.assignedCar.id,
      clientId: travel.client.id
    };
    console.log(travelDto);
    this.travelService.apiTravelIdPut(travel.id!, travelDto).subscribe(() => {
      this.loadTravels();
    });
  }

  cancelEdit(travelId: number): void {
    const original = this.originalTravels[travelId];
    if (original) {
      const index = this.travels.findIndex(c => c.id === travelId);
      if (index !== -1) {
        Object.assign(this.travels[index], original);
      }
    }
    this.editingStates[travelId] = false;
  }

  deleteTravel(travelId: number): void {
    this.travelService.apiTravelIdDelete(travelId).subscribe({
      next: () => {
        this.travelService.apiTravelGet().subscribe(travels => {
          this.travels = travels;
        });
      }
    });
  }

  loadTravels(): void {
    this.travelService.apiTravelGet().subscribe((travels) => {
      this.travels = travels.map(travel => ({
        ...travel,
        tripDate: travel.tripDate!.substring(0, 10)
      }));
      this.travels.forEach((travel) => {
        this.editingStates[travel.id!] = false;
        this.originalTravels[travel.id!] = {...travel};
      });
    });
    this.userService.apiUserGet().subscribe(users => {
      this.users = users;
    });
    this.carService.apiCarGet().subscribe(cars => {
      this.cars = cars;
    });
  }
}
