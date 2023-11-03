import React, {FC, useEffect, useState} from "react";
import {AddCarReservationInterface, CarInterface} from "../../shared/Types.ts";
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
import {Box, Button} from "@mui/material";
import { DateRangePicker } from 'react-date-range';
import 'react-date-range/dist/styles.css'; // main css file
import 'react-date-range/dist/theme/default.css'; // theme css file

const CarDetails: FC = () => {
    const [car, setCar] = useState<CarInterface>();
    const {carId} = useParams()
    const [state, setState] = useState<{startDate: Date, endDate: Date | undefined, key: string}[]>([
        {
            startDate: new Date(),
            endDate: undefined,
            key: 'selection'
        }
    ]);


    useEffect(() => {
        const fetchCar = async () => {
            const token = GetTokenLoader().token!;

            const data = await fetchCarAction(token, carId!);
            setCar(data);


        };

        fetchCar().then();
    }, [carId]);

    async function handleSubmit(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();

        const token = GetTokenLoader().token!;
        const data = new FormData(e.currentTarget);
        const startDate = state[0].startDate;
        const endDate = state[0].endDate;

        const formatDate = (date: Date) => {
            const year = date.getUTCFullYear();
            const month = String(date.getUTCMonth() + 1).padStart(2, '0');
            const day = String(date.getUTCDate()).padStart(2, '0');
            const hours = String(date.getUTCHours()).padStart(2, '0');
            const minutes = String(date.getUTCMinutes()).padStart(2, '0');
            const seconds = String(date.getUTCSeconds()).padStart(2, '0');
            const milliseconds = String(date.getUTCMilliseconds()).padStart(3, '0');

            return `${year}-${month}-${day}T${hours}:${minutes}:${seconds}.${milliseconds}Z`;
        };

        const reservationData = {
            startDate: formatDate(startDate),
            endDate: endDate ? formatDate(endDate) : formatDate(startDate),
            carId: carId as string,
        };

        console.log(JSON.stringify(reservationData));

        const response = await fetch(`http://localhost:5193/api/RentCar/Reservation`, {
            method: 'POST',
            headers: {
                'Accept': '*/*',
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`,
            },
            body: JSON.stringify(reservationData),
        });

        if (!response.ok) {
            throw new Error('Something went wrong');
        }
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
            <Box sx={{width: "100%"}} margin={1} >
                <Form method="post" onSubmit={handleSubmit}>

                    <DateRangePicker
                        onChange={(item) => {
                            setState([item.selection]);
                        }}
                        moveRangeOnFirstSelection={false}
                        months={2}
                        ranges={state? state : []}
                        direction="horizontal"
                    />
                    {state[0].endDate && (
                        <p>
                            Number of days selected: {Math.floor((state[0].endDate?.getTime() - state[0].startDate.getTime()) / (1000 * 60 * 60 * 24))}

                        </p>
                    )}

                    <button>Rent</button>
                </Form>
            </Box>
        </>
    );
}

export default CarDetails;