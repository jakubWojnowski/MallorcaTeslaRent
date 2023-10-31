import {FC} from "react";
import {Link} from "react-router-dom";
import {AppBar, Box, Button, IconButton, Toolbar, Typography} from "@mui/material";
import MenuIcon from "@mui/icons-material/Menu";
import classes from "./MainNavigationComponent.module.css";
interface MainNavigationComponentProps {

}
  export const MainNavigationComponent: FC<MainNavigationComponentProps> = () => {
    return (
        <header  className={classes.header}>
            <Box sx={{ flexGrow: 1 }}>
        <AppBar position="static" >
            <Toolbar variant="dense">
                <IconButton
                    size="large"
                    edge="start"
                    color="inherit"
                    aria-label="menu"
                    sx={{ mr: 2 }}
                >
                    <MenuIcon />
                </IconButton>
                <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
                    <ul className={classes.list}>
                    <Link to={"/"} > Home </Link>
                      
                    <Link to={"/rentCar" } > rentCar </Link>
                       
                    </ul>
                </Typography>
                <Button color="inherit" >
                    <Link to={"/login"} > Login </Link>
                </Button>
            </Toolbar>
        </AppBar>
    </Box>
        </header>
    );
    
    
}
