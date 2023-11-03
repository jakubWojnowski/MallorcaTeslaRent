import {FC, useEffect, useState} from 'react';
import { Box, Grid } from "@mui/material";
import TileComponent from "../../components/tile/TileComponent.tsx";
import { LocationInterface } from "../../shared/Types.ts";
import { fetchLocationsAction } from "../../actions/location/GetLocations.ts";
import {GetTokenLoader} from "../../utils/GetTokenLoader.ts";

export const RentCar: FC = () => {
    const [locations, setLocations] = useState<LocationInterface[]>([]);

    useEffect(() => {
        const fetchLocations = async () => {
            const token = GetTokenLoader().token!;
            const data = await fetchLocationsAction(token);
            setLocations(data);
        };
        fetchLocations().then();
    }, []);

    useEffect(() => {
        locations.map((location) => {
            console.log(location.name, location.address, location.id)
        })
    }, [locations]);

    return (
        <Box sx={{ flexGrow: 0.6 }}>
            <Grid container spacing={5}>
                {locations.map((location) => (
                    <TileComponent key={location.id} name={location.name} address={location.address}  link={`/rentCar/${location.id}`} text={location.name} ImageSrc={"public/spot.svg"}/>
                ))}
            </Grid>
        </Box>
    );
}