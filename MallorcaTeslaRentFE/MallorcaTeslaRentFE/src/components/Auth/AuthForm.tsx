import {Form, Link, useNavigation, useSearchParams} from 'react-router-dom';
import {TextField} from '@mui/material';
import classes from './AuthForm.module.css';
import React, {FC, useState} from "react";
import {LoginDataInterface, RegisterDataInterface} from "../../shared/Types.ts";
import { useNavigate } from 'react-router-dom';

const AuthForm: FC = () => {
    const navigation = useNavigation()
    const [searchParams] = useSearchParams();
    const isLogin = searchParams.get('mode') === 'login';

    const isSubmitting = navigation.state === 'submitting';

    const [emailError, setEmailError] = useState('');
    const [passwordError, setPasswordError] = useState('');
    const [confirmPasswordError, setConfirmPasswordError] = useState('');
    const [dobError, setDobError] = useState('');

    const navigate = useNavigate();

    async function handleSubmit(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();
        const mode = isLogin ? 'login' : 'register';
        const data = new FormData(e.currentTarget);
        const email = data.get('email') as string;
        const password = data.get('password') as string;
        const confirmPassword = data.get('confirmPassword') as string;
        const dob = data.get('dob') as string;
        const name = data.get('name') as string;
        const surname = data.get('surname') as string;

        if (mode === 'register' && password !== confirmPassword) {
            setConfirmPasswordError('Passwords do not match');
            return;
        }

        const loginData: LoginDataInterface = {
            email,
            password,
        };

        const registerData: RegisterDataInterface = {
            email,
            password,
            confirmPassword,
            dateOfBirth: dob,
            name,
            surname,
        };

        const requestData = isLogin ? loginData : registerData;

        const response = await fetch(`http://localhost:5193/api/Account/${mode}`, {
            method: 'POST',
            headers: {
                'Accept': '*/*',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(requestData),
        });

        if (response.status === 422) {
            setEmailError('Email is already in use');
            return;
        }

        if (response.status === 401) {
            setPasswordError('Invalid email or password');
            return;
        }

        if (!response.ok) {
            let errorMessage;
            const contentType = response.headers.get('content-type');
            if (contentType && contentType.indexOf('application/json') !== -1) {
                const responseBody = await response.json();
                errorMessage = responseBody.message;
            } else {
                errorMessage = await response.text();
            }

            if (errorMessage === 'Invalid email or password') {
                setPasswordError('Invalid email or password');
            } else if (errorMessage === 'Email is already in use') {
                setEmailError('Email is already in use');
            } else if (errorMessage === 'User must be above 18 years old') {
                setDobError('User must be above 18 years old');
            }
            return;
        }
        const token = await response.text();
        console.log(token);
        localStorage.setItem('token', token);
        navigate("/");
    }

    return (
        <>
            <Form method="post" className={classes.form } onSubmit={handleSubmit}>
                <h1>{isLogin ? 'Log in' : 'Create a new user'}</h1>
                {emailError && <span className={classes.error}>{emailError}</span>}
                {passwordError && <span className={classes.error}>{passwordError}</span>}
                {confirmPasswordError && <span className={classes.error}>{confirmPasswordError}</span>}
                {dobError && <span className={classes.error}>{dobError}</span>}
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
                    <Link  to={`?mode=${isLogin ? 'register' : 'login'}`}>
                        {isLogin ? 'Create new user' : 'login'}
                    </Link>
                    <button disabled={isSubmitting}>{isSubmitting ? 'Submitting ...' : 'Save'}</button>
                </div>
            </Form>
        </>
    );
}

export default AuthForm;