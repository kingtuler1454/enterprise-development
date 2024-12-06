/**
 * TaxiDetails.WebApi
 *
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */
import { TimeSpan } from './timeSpan';
import { User } from './user';
import { Car } from './car';


export interface Travel { 
    id?: number;
    departurePoint?: string | null;
    destinationPoint?: string | null;
    tripDate?: string | null;
    travelTime?: TimeSpan;
    cost?: number | null;
    assignedCar: Car;
    client: User;
}
