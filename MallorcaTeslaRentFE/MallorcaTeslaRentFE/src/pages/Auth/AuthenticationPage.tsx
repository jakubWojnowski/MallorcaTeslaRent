import { FC } from "react";
import RegisterAuthForm from "../../components/Auth/RegisterAuthForm.tsx";
const Authentication: FC = () => {
    return (
        <RegisterAuthForm/>
    );
}

export default Authentication;
// export const authAction: ActionFunction<any> = async (request: any) => {
//     const data = new FormData(await request.data());
//     const searchParams = new URL(request.url).searchParams;
//     const mode = searchParams.get('mode') || 'login';
//     if (mode !== 'login' && mode !== 'signup') {
//         throw new Error('Invalid mode');
//     }
//     const authData: RegisterDataInterface = {
//         firstName: data.get('name') as string,
//         // email: data.get('email') as string,
//         // password: data.get('password') as string,
//         // passwordConfirmation: data.get('confirmPassword') as string,
//         // dateOfBirth: data.get('dob') as string,
//         // firstName: data.get('name') as string,
//         // lastName: data.get('surname') as string,
//     };
//     console.log(JSON.stringify(authData));
//     const response = await fetch('https://localhost:5193/api/Account/register', {
//         method: 'POST',
//         headers: {
//             'Accept': '*/*',
//             'Content-Type': 'application/json',
//         },
//        
//        
//     });
//     console.log(response);
//     if (response.status === 422 || response.status === 401) {
//         return response;
//     }
//
//     if (!response.ok) {
//         throw new Error('Could not authenticate user.');
//     }
//
//     return Promise.resolve(redirect('..'));
// }

// export const loginAction: ActionFunction<any> = async (request: any) => {
//     const data = new FormData(await request.data());
//     const searchParams = new URL(request.url).searchParams;
//     const mode = searchParams.get('mode') || 'login';
//     if (mode !== 'login' && mode !== 'signup') {
//         throw new Error('Invalid mode');
//     }
//     const authData: RegisterDataInterface = {
//         email: data.get('email') as string,
//         password: data.get('password') as string,
//         passwordConfirmation: data.get('confirmPassword') as string,
//         dateOfBirth: data.get('dob') as string,
//         firstName: data.get('name') as string,
//         lastName: data.get('surname') as string,
//     };
//     const response = await fetch('https://localhost:5193/api/Account/login', {
//         method: 'POST',
//         headers: {
//             'Accept': '*/*',
//             'Content-Type': 'application/json',
//         },
//         body: JSON.stringify(authData), 
//        
//     });
//         console.log(response);
//     if (response.status === 422 || response.status === 401) {
//         return response;
//     }
//
//     if (!response.ok) {
//         throw new Error('Could not authenticate user.');
//     }
//
//     return Promise.resolve(redirect('..'));
// }
//    
//    