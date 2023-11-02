import {Form, Link} from "react-router-dom";
import classes from "./AuthForm.module.css";
import {TextField} from "@mui/material";
import {FC} from "react";

const LoginAuthForm: FC = () => {
    
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
            </div>
              
        </Form>
    </>
    );
}
export default LoginAuthForm;