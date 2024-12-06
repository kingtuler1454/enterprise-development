import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {FormBuilder, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {Car, CarService, TravelService, User, UserService} from "../../../api";
import {combineLatest} from "rxjs";
import {NgForOf, NgIf} from "@angular/common";

@Component({
  selector: 'app-add-travel',
  standalone: true,
  imports: [
    NgForOf,
    NgIf,
    ReactiveFormsModule
  ],
  templateUrl: './add-travel.component.html',
  styleUrl: './add-travel.component.css'
})
export class AddTravelComponent implements OnInit {
  isFormOpen = false;
  travelForm: FormGroup;
  cars: Car[] = [];
  users: User[] = [];
  @Output() travelAdded = new EventEmitter<void>();

  constructor(
    private fb: FormBuilder,
    private travelService: TravelService,
    private carService: CarService,
    private userService: UserService
  ) {
    this.travelForm = this.fb.group({
      departurePoint: ['', Validators.required],
      destinationPoint: ['', Validators.required],
      tripDate: ['', Validators.required],
      travelTime: ['', Validators.required],
      cost: ['', Validators.required],
      assignedCarId: [1],
      clientId: [1],
    });
  }

  ngOnInit(): void {
    combineLatest([
      this.carService.apiCarGet(),
      this.userService.apiUserGet()
    ]).subscribe(([cars, users]) => {
      this.cars = cars;
      this.users = users;

      if (this.cars.length > 0) {
        this.travelForm.patchValue({
          assignedCarId: this.cars[0].id
        });
      }

      if (this.users.length > 0) {
        this.travelForm.patchValue({
          clientId: this.users[0].id
        });
      }
    });
  }

  openForm(): void {
    this.isFormOpen = true;
  }

  closeForm(): void {
    this.isFormOpen = false;
    this.travelForm.reset({assignedCarId: this.cars[0].id, clientId: this.users[0].id});
  }

  onSubmit(): void {
    if (this.travelForm.valid) {
      const newTravel = this.travelForm.value;
      newTravel.cost = Number(this.travelForm.value.cost);
      if (newTravel.travelTime) {
        newTravel.travelTime += ':00';
      }
      console.log(newTravel);
      this.travelService.apiTravelPost(newTravel).subscribe({
        next: () => {
          this.travelAdded.emit();
          this.closeForm();
        }
      });
    }
  }
}
