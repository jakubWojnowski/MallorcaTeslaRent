import React, { FC } from 'react';
import {CardActions, CardContent, Paper, Typography, Grid, ButtonBase} from "@mui/material";
import {Link} from "react-router-dom";
import {styled} from "@mui/material/styles"; 

interface TileProps {
    name: string;
    address: string;
    link: string;
    text: string
    ImageSrc: string
}

const Tile: FC<TileProps> = ({ name, address, link, text, ImageSrc }) => {
    const Item = styled(Paper)(({ theme }) => ({
        backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
        ...theme.typography.body2,
        textAlign: 'center',
        color: theme.palette.text.secondary,
        boxShadow: "true" ,
    }));

    const Img = styled('img')({
        margin: 'auto',
        display: 'block',
        maxWidth: '100%',
        maxHeight: '100%',
    });
    return (
        <React.Fragment>

        <Grid item xs={4}>
           
       <Item>
           <Grid item>
               <ButtonBase sx={{ width: 128, height: 128 }}>
                   <Img alt="complex" src={ImageSrc} />
               </ButtonBase>
           </Grid>
            <CardContent>
                <Typography variant="h5" component="div">
                    {name}
                </Typography>
                <Typography variant="body2">
                    {address}
                </Typography>
            </CardContent>
            <CardActions>
                <Link to={link} >{text}</Link>
            </CardActions>
       </Item>
        </Grid>
        </React.Fragment>
    );
};

export default Tile;
