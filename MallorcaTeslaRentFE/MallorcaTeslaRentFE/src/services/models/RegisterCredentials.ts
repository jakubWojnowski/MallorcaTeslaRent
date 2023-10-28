export interface RegisterCredentials {
    firstName: string;
    lastName: string;
    email: string;
    password: string;
    confirmPassword?: string;
    dateOfBirth?: Date;
}