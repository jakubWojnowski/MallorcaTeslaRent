import React, { useEffect, useState } from 'react';
import { Box, Grid } from "@mui/material";
import TileComponent from "../../components/tile/TileComponent.tsx";
import { LocationInterface } from "../../shared/Types.ts";

import { fetchLocationsAction } from "../../actions/location/GetLocations.ts";
import {GetTokenLoader} from "../../utils/GetTokenLoader.ts"; 

interface RentCarProps {

}

export const RentCar: React.FC<RentCarProps> = () => {
    const [locations, setLocations] = useState<LocationInterface[]>([]); // create a state variable to store the locations

    useEffect(() => {
        const fetchLocations = async () => {
            const token = GetTokenLoader().token; // replace this with your actual token
            
            const data = await fetchLocationsAction(token); // fetch the locations
            setLocations(data); // update the state with the fetched locations
            console.log(data)

        };
       
        fetchLocations().then(r => 
            console.log(r));
    }, []);

    
    return (
        <Box sx={{ flexGrow: 0.6 }}>
            <Grid container spacing={5}>
                {locations.map((location) => (
                    <TileComponent name={location.name} address={location.address} link={"/rentCar/:rentCarLocationId"} text={location.name} ImageSrc={"public/spot.svg"}/>
                ))}
                
            </Grid>
        </Box>
    );
}