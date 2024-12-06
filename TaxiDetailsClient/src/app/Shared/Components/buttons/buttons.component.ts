import {Component, EventEmitter, Output} from '@angular/core';
import { Input } from '@angular/core';
import {NgIf} from "@angular/common";

@Component({
  selector: 'app-buttons',
  standalone: true,
  imports: [
    NgIf
  ],
  templateUrl: './buttons.component.html',
  styleUrl: './buttons.component.css'
})
export class ButtonsComponent<T> {
  @Input() itemId!: T;
  @Output() delete = new EventEmitter<T>();
  @Output() save = new EventEmitter<void>();
  @Output() edit = new EventEmitter<T>();
  @Output() cancel = new EventEmitter<T>();

  isEditing = false;

  startEdit() {
    this.isEditing = true;
    this.edit.emit(this.itemId);
  }

  saveEdit() {
    this.isEditing = false;
    this.save.emit();
  }

  cancelEdit() {
    this.isEditing = false;
    this.cancel.emit(this.itemId);
  }
}
