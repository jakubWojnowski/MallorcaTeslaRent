//napisz mi serwisy endpointow do logowania i rejestracji w typescript za pomoca biblioteki fetch 
//dodaj do nich typy
//dodaj do nich obsluge bledow
//dodaj do nich obsluge tokenow
//dodaj do nich obsluge zapisu tokenow w local storage
//dodaj do nich obsluge wylogowania
//dodaj do nich obsluge rejestracji
//dodaj do nich obsluge logowania

import { User } from "../../models/User";
import { Endpoints } from "../../config/Urls";
import { LoginCredentials } from "../../models/LoginCredentials";
import { RegisterCredentials } from "../../models/RegisterCredentials";
import { LoginResponse } from "../../models/LoginResponse";
import { RegisterResponse } from "../../models/RegisterResponse";

export const login = async (credentials: LoginCredentials): Promise<LoginResponse> => {
    const response = await fetch(`${Endpoints.API_URL_ACCOUNT}/login`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(credentials)
    });

    if (!response.ok) {
        throw new Error('Login failed');
    }

    const data = await response.json();

    return data;
}

export const register = async (credentials: RegisterCredentials): Promise<RegisterResponse> => {
    const response = await fetch(`${Endpoints.API_URL_ACCOUNT}/register`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(credentials)
    });

    if (!response.ok) {
        throw new Error('Register failed');
    }

    const data = await response.json();

    return data;
}

export const logout = async (): Promise<void> => {
    const response = await fetch(`${Endpoints.API_URL_ACCOUNT}/logout`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
    });

    if (!response.ok) {
        throw new Error('Logout failed');
    }
}

export const getUser = async (): Promise<User> => {
    const response = await fetch(`${Endpoints.API_URL_ACCOUNT}/user`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        },
    });

    if (!response.ok) {
        throw new Error('Get user failed');
    }

    const data = await response.json();

    return data;
}

export const updateUser = async (user: User): Promise<User> => {
    const response = await fetch(`${Endpoints.API_URL_ACCOUNT}/user`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    });

    if (!response.ok) {
        throw new Error('Update user failed');
    }

    const data = await response.json();

    return data;
}

export const deleteUser = async (): Promise<void> => {
    const response = await fetch(`${Endpoints.API_URL_ACCOUNT}/user`, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json'
        },
    });

    if (!response.ok) {
        throw new Error('Delete user failed');
    }
}

export const changePassword = async (oldPassword: string, newPassword: string): Promise<void> => {
    const response = await fetch(`${Endpoints.API_URL_ACCOUNT}/user/password`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ oldPassword, newPassword })
    });

    if (!response.ok) {
        throw new Error('Change password failed');
    }
}

export const changeEmail = async (email: string): Promise<void> => {
    const response = await fetch(`${Endpoints.API_URL_ACCOUNT}/user/email`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ email })
    });

    if (!response.ok) {
        throw new Error('Change email failed');
    }
}



