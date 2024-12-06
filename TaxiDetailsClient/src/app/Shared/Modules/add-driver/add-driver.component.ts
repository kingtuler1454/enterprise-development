import {Component, EventEmitter, Output} from '@angular/core';
import {AbstractControl, FormBuilder, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {DriverService} from "../../../api";
import {NgClass, NgIf} from "@angular/common";

@Component({
  selector: 'app-add-driver',
  standalone: true,
  imports: [
    NgIf,
    ReactiveFormsModule,
    NgClass
  ],
  templateUrl: './add-driver.component.html',
  styleUrl: './add-driver.component.css'
})
export class AddDriverComponent {
  isFormOpen = false;
  driverForm: FormGroup;
  @Output() driverAdded = new EventEmitter<void>();

  constructor(private fb: FormBuilder, private driverService: DriverService) {
    this.driverForm = this.fb.group({
      name: ['', Validators.required],
      surname: ['', Validators.required],
      patronymic: [' '],
      passport: ['', Validators.required],
      address: ['', Validators.required],
      phone: ['', [Validators.required, this.phoneValidator]]
    });
  }
  get phone() {
    return this.driverForm.get('phone');
  }
  phoneValidator(control: AbstractControl) {
    const value = control.value;
    const phoneRegex = /^[+]?[0-9]{10,15}$/;

    if (value && !phoneRegex.test(value)) {
      return { invalidPhone: true };
    }
    return null;
  }
  openForm(): void {
    this.isFormOpen = true;
  }

  closeForm(): void {
    this.isFormOpen = false;
    this.driverForm.reset();
  }

  onSubmit(): void {
    if (this.driverForm.valid) {
      const newDriver = this.driverForm.value;
      this.driverService.apiDriverPost(newDriver).subscribe({
        next: () => {
          this.driverAdded.emit();
          this.closeForm();
        }
      });
    }
  }
}
