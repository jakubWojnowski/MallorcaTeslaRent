import {FC, useEffect, useState} from "react";
import {Box, Grid} from "@mui/material";
import TileComponent from "../../components/tile/TileComponent.tsx";
import {GetTokenLoader} from "../../utils/GetTokenLoader.ts";
import {CarInterface} from "../../shared/Types.ts";
import {fetchCarsAction} from "../../actions/car/GetCars.ts";


const RentCarLocation: FC = () => {
    const [cars, setCars] = useState<CarInterface[]>([]);
    useEffect(() => {
        const fetchCars = async () => {
            const token = GetTokenLoader().token!;

            const data = await fetchCarsAction(token);
            setCars(data);
            console.log(data)

        };

        fetchCars().then();
    }, []);

    return (
        <Box sx={{flexGrow: 1}}>
            <Grid container spacing={5}>

                {cars.map((car) => (
                    <TileComponent key={car.id} name={car.name} address={car.model}  link={`rentCar/${car.locationId}/${car.id}`}
                                   text={"See Details"} ImageSrc={"../../public/tesl.png"}/>
                ))}


            </Grid>
        </Box>


    );
}
export default RentCarLocation;
