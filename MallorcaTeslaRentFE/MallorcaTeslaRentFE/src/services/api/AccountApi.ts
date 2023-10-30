import {User} from "../../interfaces/User";
import {Endpoints} from "../../config/Urls";
import {LoginCredentials} from "../models/LoginCredentials.ts";
import {RegisterCredentials} from "../models/RegisterCredentials.ts";
import {LoginResponse} from "../models/LoginResponse.ts";
import {RegisterResponse} from "../models/RegisterResponse.ts";

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

    return await response.json();
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

    return await response.json();
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

    return await response.json();
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



