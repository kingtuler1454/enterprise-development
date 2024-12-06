import {Component, OnInit} from '@angular/core';
import {User, UserDto, UserService} from "../../../api";
import {NgForOf} from "@angular/common";
import {FormsModule} from "@angular/forms";
import {ButtonsComponent} from "../../Components/buttons/buttons.component";

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [
    NgForOf,
    FormsModule,
    ButtonsComponent
  ],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css'
})
export class UserListComponent implements OnInit {
  users: User[] = [];
  editingStates: { [id: number]: boolean } = {};
  originalUsers: { [id: number]: User } = {};

  constructor(private userService: UserService) {
  }

  ngOnInit(): void {
    this.loadUsers();
  }

  startEdit(userId: number): void {
    this.editingStates[userId] = true;
  }

  saveUser(user: User): void {
    const userDto: UserDto = {
      fullName: user.fullName!,
      phone: user.phone!
    }
    this.userService.apiUserIdPut(user.id!, userDto).subscribe(() => {
      this.editingStates[user.id!] = false;
      this.originalUsers[user.id!] = {...user};
    });
  }

  cancelEdit(userId: number): void {
    const original = this.originalUsers[userId];
    if (original) {
      const index = this.users.findIndex(c => c.id === userId);
      if (index !== -1) {
        Object.assign(this.users[index], original);
      }
    }
    this.editingStates[userId] = false;
  }

  deleteUser(userId: number): void {
    this.userService.apiUserIdDelete(userId).subscribe({
      next: () => {
        this.userService.apiUserGet().subscribe(users => {
          this.users = users;
        });
      }
    });
  }

  loadUsers(): void {
    this.userService.apiUserGet().subscribe((users) => {
      this.users = users;
      this.users.forEach((user) => {
        this.editingStates[user.id!] = false;
        this.originalUsers[user.id!] = {...user};
      });
    });
  }
}
