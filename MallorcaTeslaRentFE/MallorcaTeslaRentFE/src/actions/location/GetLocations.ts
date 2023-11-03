import {LocationInterface} from "../../shared/Types.ts";

export const fetchLocationsAction = async (token: string): Promise<LocationInterface[]> => {

    if (token) {
        const response = await fetch(`http://localhost:5193/api/RentCar/RentalLocations`, {
            method: 'GET',
            headers: {
                'Accept': '*/*',
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`,
            }
        });

        if (response.status !== 200) {
            throw new Error('Get locations failed');
        }

        const data = await response.json();
        console.log(data);
    } else {
        console.log('Token is not available');
    }
    return [];
}
