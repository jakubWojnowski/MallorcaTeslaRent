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
import { GetTokenLoader as tokenLoader} from "../utils/GetTokenLoader.ts";
import {fetchLocationsAction as locationLoader} from "../actions/location/GetLocations.ts";
import {fetchCarsAction as carsLoader} from "../actions/car/GetCars.ts"
import CarDetails from "../pages/Car/CarDetails.tsx";
import {fetchCarAction as carLoader} from "../actions/car/GetCar.ts";

export const Router = () => {
    const token = tokenLoader().token;
    
    const router = createBrowserRouter([
        {path: '/', element: <RootLayout />,
            errorElement: <h1>Not Found</h1>,
            id: 'root',
            loader: tokenLoader,
        children: [
            {path: '', element: <Home />},
            {path: 'rentCar', element: <RentCar />, action: () => {
                    if (token) {
                        return locationLoader(token);
                    } else {
                        return Promise.resolve({}); 
                    }
                }},
            {path: 'rentCar/:rentCarLocationId', element: <RentCarLocation /> , action: () => {
                    if (token) {
                        return carsLoader(token);
                    } else {
                        return Promise.resolve({}); 
                    }
                }
                },
            {path:'rentCar/:rentCarLocationId/:carId', element: <CarDetails/>, action: (request) => {
                    const carId = request.params.carId!;
                    const locationId = request.params.rentCarLocationId!;
                    if (token) {
                        return carLoader(token, carId);
                    } else {
                        return Promise.resolve({}); 
                    }
                },
            },
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