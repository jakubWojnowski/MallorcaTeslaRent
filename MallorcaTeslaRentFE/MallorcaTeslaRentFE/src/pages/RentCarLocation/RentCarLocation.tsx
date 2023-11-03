import{FC} from "react";
import {Box, Grid} from "@mui/material";
import TileComponent from "../../components/tile/TileComponent.tsx";
import {GetTokenLoader} from "../../utils/GetTokenLoader.ts";
//give me axios Get request with token authorization
//give me list of cars
const token = GetTokenLoader().token;


const RentCarLocation: FC = () =>{
  
    return (
        <Box sx={{ flexGrow: 1 }}>
            <Grid container spacing={5}>
               
                 <TileComponent name={"Tesla"} address={"x"} link={"/"} text={"Rent"} ImageSrc={"public/spot.svg"}/>
             
                
            </Grid>
        </Box>
       
      
    );
}
export default RentCarLocation;

//<Card variant="outlined"><TileComponent name={"sdaasd"} address={"dsadasdas"} link={"/"}/></Card>