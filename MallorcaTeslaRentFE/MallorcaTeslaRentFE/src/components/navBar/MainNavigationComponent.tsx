import {FC, FormEvent} from "react";
import {NavLink, Form, useNavigate} from "react-router-dom";
import {AppBar, Box, Button, IconButton, Toolbar, Typography} from "@mui/material";
import MenuIcon from "@mui/icons-material/Menu";
import classes from "./MainNavigationComponent.module.css";
import {logout} from "../../actions/logout/Logout.ts";
import {GetTokenLoader} from "../../utils/GetTokenLoader.ts";

interface MainNavigationComponentProps {

}

export const MainNavigationComponent: FC<MainNavigationComponentProps> = () => {
    const navigate = useNavigate();
    const token = GetTokenLoader().token;
 
    const handleLogout = async (event: FormEvent) => {
        event.preventDefault();
        navigate('');
        await logout();
        
    };
    return (
        <header className={classes.header}>
            <Box sx={{flexGrow: 1}}>
                <AppBar position="static">
                    <Toolbar variant="dense">
                        <IconButton
                            size="large"
                            edge="start"
                            color="inherit"
                            aria-label="menu"
                            sx={{mr: 2}}
                        >
                            <MenuIcon/>
                        </IconButton>
                        <Typography variant="h6" component="div" sx={{flexGrow: 1}}>
                            <ul className={classes.list}>

                                <NavLink
                                    to="/"
                                    className={({isActive}) => isActive ? classes.active : undefined} end>Home</NavLink>
                                {token && (
                                <NavLink to={"/rentCar"}
                                         className={({isActive}) => isActive ? classes.active : undefined}> rentCar </NavLink>
                                ) }
                                
                            </ul>
                        </Typography>

                        {token && (
                            <Form onSubmit={handleLogout} method="post">
                                <Button type="submit" variant="contained" color="error">Logout</Button>
                            </Form>
                        ) }
                        {!token && (
                            <NavLink to={"/auth?mode=login"}> Login </NavLink>
                        )}
                        
                    </Toolbar>
                </AppBar>
            </Box>
        </header>
    );


}
