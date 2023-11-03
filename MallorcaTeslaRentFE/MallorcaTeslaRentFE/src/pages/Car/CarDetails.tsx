import React, {FC, useEffect, useState} from "react";
import {CarInterface} from "../../shared/Types.ts";
import {GetTokenLoader} from "../../utils/GetTokenLoader.ts";
import {fetchCarAction} from "../../actions/car/GetCar.ts";
import {Form, useParams} from "react-router-dom";
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import {Box, Button, TextField} from "@mui/material";


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

    function handleSubmit() {

    }

    return (
        <>
            <TableContainer component={Paper}>
                <Table sx={{minWidth: 650}} aria-label="simple table">
                    <TableHead>
                        <TableRow>
                            <TableCell>Name of Car</TableCell>
                            <TableCell align="right">Model</TableCell>
                            <TableCell align="right">Price Per Day</TableCell>
                            <TableCell align="right">Number of seats</TableCell>
                            <TableCell align="right">Description</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>

                        <TableRow
                            key={car?.id}
                            sx={{'&:last-child td, &:last-child th': {border: 0}}}
                        >
                            <TableCell component="th" scope="row">
                                {car?.name}
                            </TableCell>
                            <TableCell align="right">{car?.model}</TableCell>
                            <TableCell align="right">{car?.pricePerDay}</TableCell>
                            <TableCell align="right">{car?.numberOfSeats}</TableCell>
                            <TableCell align="right">{car?.description}</TableCell>
                        </TableRow>
                    </TableBody>
                </Table>

            </TableContainer>
            <Box sx={{width: 300}} >
                <Form method="post" onSubmit={handleSubmit}>

                    <TextField id="dob" type="date" name="start" required style={{ width: '50%', textAlign: 'center' }} />
                    <TextField id="dob" type="date" name="end" required style={{ width: '50%', textAlign: 'center' }} />

                    <Button>Rent</Button>
                </Form>
            </Box>
        </>
    );
}

export default CarDetails;