import {Component, ViewChild} from '@angular/core';
import {UserListComponent} from "../../Shared/Modules/user-list/user-list.component";
import {AddUserComponent} from "../../Shared/Modules/add-user/add-user.component";

@Component({
  selector: 'app-users-page',
  standalone: true,
  imports: [AddUserComponent, UserListComponent],
  templateUrl: './users-page.component.html',
  styleUrl: './users-page.component.css'
})
export class UsersPageComponent {
  currentTitle: string = 'Список пользователей';

  @ViewChild(UserListComponent) userListComponent!: UserListComponent;

  onUserAdded() {
    this.userListComponent.loadUsers();
  }
}
