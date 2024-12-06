import {Component, ViewChild} from '@angular/core';
import {TravelListComponent} from "../../Shared/Modules/travel-list/travel-list.component";
import {AddTravelComponent} from "../../Shared/Modules/add-travel/add-travel.component";

@Component({
  selector: 'app-travels-page',
  standalone: true,
  imports: [TravelListComponent, AddTravelComponent],
  templateUrl: './travels-page.component.html',
  styleUrl: './travels-page.component.css'
})
export class TravelsPageComponent {
  currentTitle: string = 'Список поездок';

  @ViewChild(TravelListComponent) travelListComponent!: TravelListComponent;

  onTravelAdded() {
    this.travelListComponent.loadTravels();
  }
}
