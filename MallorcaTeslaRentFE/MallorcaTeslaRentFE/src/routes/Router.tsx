import {
    createBrowserRouter,
    RouterProvider,
} from 'react-router-dom';
import {Home} from "../pages/home/Home.tsx";
import {RentCar} from "../pages/rentCar/RentCar.tsx";
import {RootLayout} from "../layout/RootLayout.tsx";
import RentCarLocation from "../pages/RentCarLocation/RentCarLocation.tsx";
import AuthForm from "../components/Auth/AuthForm.tsx";

export const Router = () => {
    
    const router = createBrowserRouter([
        {path: '/', element: <RootLayout />,
            errorElement: <h1>Not Found</h1>,
        children: [
            {path: '', element: <Home />},
            {path: 'rentCar', element: <RentCar />},
            {path: 'rentCar/:rentCarLocationId', element: <RentCarLocation />},
            {path: 'login', element: <Home />},
            {path: 'auth', element: <AuthForm />},
        ]
        },
        
        ]);
    return (
        <RouterProvider router={router}/>
    );
}
export default Router;