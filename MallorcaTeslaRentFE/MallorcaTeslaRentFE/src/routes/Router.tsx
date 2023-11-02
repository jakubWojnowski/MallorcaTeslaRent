import {
    createBrowserRouter,
    RouterProvider,
} from 'react-router-dom';
import {Home} from "../pages/home/Home.tsx";
import {RentCar} from "../pages/rentCar/RentCar.tsx";
import {RootLayout} from "../layout/RootLayout.tsx";
import RentCarLocation from "../pages/RentCarLocation/RentCarLocation.tsx";
import Authentication from "../pages/Auth/AuthenticationPage.tsx";
import {logout as LogoutAction} from "../actions/logout/Logout.ts";

export const Router = () => {
    
    const router = createBrowserRouter([
        {path: '/', element: <RootLayout />,
            errorElement: <h1>Not Found</h1>,
        children: [
            {path: '', element: <Home />},
            {path: 'rentCar', element: <RentCar />},
            {path: 'rentCar/:rentCarLocationId', element: <RentCarLocation />},
            {path: 'login', element: <Home />},
            {path: 'auth', element: <Authentication />},
            {path: 'logout', action : LogoutAction},
        ]
        },
        
        
        ]);
    return (
        <RouterProvider router={router}/>
    );
}
export default Router;