import {Component, EventEmitter, Output} from '@angular/core';
import {AbstractControl, FormBuilder, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {UserService} from "../../../api";
import {NgClass, NgIf} from "@angular/common";

@Component({
  selector: 'app-add-user',
  standalone: true,
  imports: [
    NgIf,
    ReactiveFormsModule,
    NgClass
  ],
  templateUrl: './add-user.component.html',
  styleUrl: './add-user.component.css'
})
export class AddUserComponent {
  isFormOpen = false;
  userForm: FormGroup;
  @Output() userAdded = new EventEmitter<void>();

  constructor(private fb: FormBuilder, private userService: UserService) {
    this.userForm = this.fb.group({
      fullName: ['', Validators.required],
      phone: ['', [Validators.required, this.phoneValidator]]
    });
  }
  get phone() {
    return this.userForm.get('phone');
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
    this.userForm.reset();
  }

  onSubmit(): void {
    if (this.userForm.valid) {
      const newStore = this.userForm.value;
      this.userService.apiUserPost(newStore).subscribe({
        next: () => {
          this.userAdded.emit();
          this.closeForm();
        }
      });
    }
  }
}
