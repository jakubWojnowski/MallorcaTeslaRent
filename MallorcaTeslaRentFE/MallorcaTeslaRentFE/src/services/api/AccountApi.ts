import {User} from "../../interfaces/User";
import {Endpoints} from "../../config/Urls";
import axios from "axios";
import {LoginDataInterface, RegisterDataInterface} from "../../shared/Types.ts";

export class AccountApi {
    static async login(data: LoginDataInterface) {
        const response = await axios.post(`${Endpoints.API_URL_ACCOUNT}/login`, data);

        if (response.status !== 200) {
            throw new Error('Login failed');
        }

        return response.data;
    }

    static async register(data: RegisterDataInterface) {
        const response = await axios.post(`${Endpoints.API_URL_ACCOUNT}/register`, data);

        if (response.status !== 200) {
            throw new Error('Register failed');
        }

        return response.data;
    }

    static async logout(): Promise<void> {
        const response = await axios.post(`${Endpoints.API_URL_ACCOUNT}/logout`);

        if (response.status !== 200) {
            throw new Error('Logout failed');
        }
    }

    static async getUser(): Promise<User> {
        const response = await axios.get(`${Endpoints.API_URL_ACCOUNT}/user`);

        if (response.status !== 200) {
            throw new Error('Get user failed');
        }

        return response.data;
    }

    static async updateUser(user: User): Promise<User> {
        const response = await axios.put(`${Endpoints.API_URL_ACCOUNT}/user`, user);

        if (response.status !== 200) {
            throw new Error('Update user failed');
        }

        return response.data;
    }

    static async deleteUser(): Promise<void> {
        const response = await axios.delete(`${Endpoints.API_URL_ACCOUNT}/user`);

        if (response.status !== 200) {
            throw new Error('Delete user failed');
        }
    }
}
