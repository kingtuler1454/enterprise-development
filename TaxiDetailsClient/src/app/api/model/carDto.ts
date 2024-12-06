/**
 * TaxiDetails.WebApi
 *
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


/**
 * Data transfer object for car information.
 */
export interface CarDto { 
    /**
     * number list of car
     */
    plate: string;
    /**
     * model car
     */
    model: string;
    /**
     * color
     */
    color: string;
    /**
     * identificator of driver
     */
    assignedDriverId?: number;
}

