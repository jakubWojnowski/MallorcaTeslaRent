import {
    type LoginDataInterface,
    type RegisterDataInterface,
} from '../../shared/Types.ts';
import {AccountApi} from "../api/AccountApi.ts";

export const signUpService = async (data: LoginDataInterface) => {
    return AccountApi.login(data);
};
export const signInService = async (data: RegisterDataInterface) => {
    return AccountApi.register(data);
};