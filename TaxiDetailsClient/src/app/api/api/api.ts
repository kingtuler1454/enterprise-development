export * from './car.service';
import { CarService } from './car.service';
export * from './driver.service';
import { DriverService } from './driver.service';
export * from './travel.service';
import { TravelService } from './travel.service';
export * from './user.service';
import { UserService } from './user.service';
export const APIS = [CarService, DriverService, TravelService, UserService];
