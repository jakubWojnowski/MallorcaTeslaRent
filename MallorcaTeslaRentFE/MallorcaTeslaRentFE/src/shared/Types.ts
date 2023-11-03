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