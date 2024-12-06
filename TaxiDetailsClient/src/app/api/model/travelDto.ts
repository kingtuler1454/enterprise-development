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


/**
 * Data transfer object for travel information.
 */
export interface TravelDto { 
    /**
     * from
     */
    departurePoint: string;
    /**
     * to
     */
    destinationPoint: string;
    /**
     * date of travel
     */
    tripDate: string;
    travelTime: TimeSpan;
    /**
     * cost
     */
    cost: number;
    /**
     * identificator of car
     */
    assignedCarId?: number;
    /**
     * identificator of client
     */
    clientId?: number;
}
