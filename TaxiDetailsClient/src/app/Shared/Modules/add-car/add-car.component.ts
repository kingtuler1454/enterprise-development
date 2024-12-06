import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {FormBuilder, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {CarService, Driver, DriverService} from "../../../api";
import {NgForOf, NgIf} from "@angular/common";

@Component({
  selector: 'app-add-car',
  standalone: true,
  imports: [
    NgIf,
    ReactiveFormsModule,
    NgForOf
  ],
  templateUrl: './add-car.component.html',
  styleUrl: './add-car.component.css'
})
export class AddCarComponent implements OnInit {
  isFormOpen = false;
  carForm: FormGroup;
  drivers: Driver[] = [];
  @Output() carAdded = new EventEmitter<void>();

  constructor(
    private fb: FormBuilder,
    private carService: CarService,
    private driverService: DriverService
  ) {
    this.carForm = this.fb.group({
      plate: ['', Validators.required],
      model: ['', Validators.required],
      color: ['', Validators.required],
      assignedDriverId: [1],
    });
  }

  ngOnInit(): void {
    this.driverService.apiDriverGet().subscribe(drivers => {
      this.drivers = drivers;
      if (this.drivers.length > 0) {
        this.carForm.value.assignedDriverId = this.drivers[0].id;
      }
    });
  }

  openForm(): void {
    this.isFormOpen = true;
  }

  closeForm(): void {
    this.isFormOpen = false;
    this.carForm.reset({assignedDriverId: this.drivers[0].id});
  }

  onSubmit(): void {
    if (this.carForm.valid) {
      const newCar = this.carForm.value;
      this.carService.apiCarPost(newCar).subscribe({
        next: () => {
          this.carAdded.emit();
          this.closeForm();
        }
      });
    }
  }
}
