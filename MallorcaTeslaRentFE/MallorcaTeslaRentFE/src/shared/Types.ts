import {da} from "date-fns/locale";

export interface LoginDataInterface {
    email: string;
    password: string;
}
export interface RegisterDataInterface {
    name: string;
    surname: string;
    email: string;
    password: string;
    confirmPassword: string;
    dateOfBirth: string;
}

export interface LocationInterface {
    id: number;
    name: string;
    address: string;
}

export interface CarInterface {
    id: number;
    name: string;
    model: string;
    description: string;
    pricePerDay: number;
    numberOfSeats: number;
    locationId: number;
}

export interface AddCarReservationInterface {
    carId: string;
    dateFrom: string;
    dateTo: string;
   
}