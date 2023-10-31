import {FC} from "react";
import { Outlet } from "react-router-dom";
import {MainNavigationComponent} from "../components/navBar/MainNavigationComponent"
import classes from "./RootLayout.module.css";

interface RootLayoutProps {

}

export const RootLayout: FC<RootLayoutProps> = () => {
    return (
        <>
            <MainNavigationComponent />
            <main className={classes.content}>
                <Outlet />
            </main>
        </>
    );
}