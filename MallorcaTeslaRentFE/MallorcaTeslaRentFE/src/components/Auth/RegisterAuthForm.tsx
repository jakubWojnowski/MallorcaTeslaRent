import {Form, Link, redirect, useNavigation, useSearchParams} from 'react-router-dom';
import {TextField} from '@mui/material';
import classes from './AuthForm.module.css';
import React, {FC} from "react";
import {RegisterDataInterface} from "../../shared/Types.ts";


const RegisterAuthForm: FC = () => {
const navigation = useNavigation()
const [searchParams] = useSearchParams();
const isLogin = searchParams.get('mode') === 'login';

const isSubmitting = navigation.state === 'submitting';

    async function  handleSubmit(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();
        
        const data = new FormData(e.currentTarget);
        const email = data.get('email') as string;
        const password = data.get('password') as string;
        const confirmPassword = data.get('confirmPassword') as string;
        const dob = data.get('dob') as string;
        const name = data.get('name') as string;
        const surname = data.get('surname') as string;

        const registerData: RegisterDataInterface = {
            email: email,
            password: password,
            confirmPassword: confirmPassword,
            dateOfBirth: dob,
            name: name,
            surname: surname
        };
        console.log(JSON.stringify(registerData));
        const response = await fetch('http://localhost:5193/api/Account/register', {
            method: 'POST',
            headers: {
                'Accept': '*/*',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(registerData),

        });
        console.log(response);
        if (response.status === 422 || response.status === 401) {
            return response;
        }

        if (!response.ok) {
            throw new Error('Could not authenticate user.');
        }

        return Promise.resolve(redirect('..'));
    
    }
        

    return (
        <>
            <Form method="post" className={classes.form } onSubmit={handleSubmit}>
                <h1>{isLogin ? 'Log in' : 'Create a new user'}</h1>
     
                <div className={classes.formFields}>
                    <p>
                        <label htmlFor="email">Email</label>
                        <TextField id="email" type="email" name="email" required style={{ width: '50%', textAlign: 'center' }} />
                    </p>
                    <p>
                        <label htmlFor="password">Password</label>
                        <TextField id="password" type="password" name="password" required style={{ width: '50%', textAlign: 'center' }} />
                    </p>
                    {!isLogin && (
                        <>
                            <p>
                                <label htmlFor="confirmPassword">Confirm Password</label>
                                <TextField id="confirmPassword" type="password" name="confirmPassword" required style={{ width: '50%', textAlign: 'center' }} />
                            </p>
                            <p>
                                <label htmlFor="dob">Date of Birth</label>
                                <TextField id="dob" type="date" name="dob" required style={{ width: '50%', textAlign: 'center' }} />
                            </p>
                            <p>
                                <label htmlFor="Name">Name</label>
                                <TextField id="name" type="text" name="name" required style={{ width: '50%', textAlign: 'center' }} />
                            </p>
                            <p>
                                <label htmlFor="Surname">Surname</label>
                                <TextField id="surname" type="text" name="surname" required style={{ width: '50%', textAlign: 'center' }} />
                            </p>
                        </>
                    )}
                </div>
                <div className={classes.actions}>
                    <Link  to={`?mode=${isLogin ? 'signup' : 'login'}`}>
                        {isLogin ? 'Create new user' : 'Login'}
                    </Link>
                    <button disabled={isSubmitting}>{isSubmitting ? 'Submitting ...' : 'Save'}</button>
                </div>
            </Form>
        </>
    );
}

export default RegisterAuthForm;


    