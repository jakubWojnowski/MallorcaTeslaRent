import {FC, useEffect, useState} from "react";
import {CarInterface} from "../../shared/Types.ts";
import {GetTokenLoader} from "../../utils/GetTokenLoader.ts";
import {fetchCarAction} from "../../actions/car/GetCar.ts";
import {useParams} from "react-router-dom";

 const CarDetails: FC = () => {
   const [car, setCar] = useState<CarInterface>();
   const {carId} = useParams()
    useEffect(() => {
        const fetchCar = async () => {
            const token = GetTokenLoader().token!;

            const data = await fetchCarAction(token, carId!);
            setCar(data);
            console.log(data)

        };

       fetchCar().then();
    }, [carId]);
    return (
        <div>
            <h1>{car?.name}</h1>
            <h1>{car?.model}</h1>
            <h1>{car?.pricePerDay}</h1>
            <h1>{car?.description}</h1>
            <h1>{car?.locationId}</h1>
        </div>
    );
}

export default CarDetails;