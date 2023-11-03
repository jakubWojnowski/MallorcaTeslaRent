import {CarInterface} from "../../shared/Types.ts";

export const fetchCarsAction = async (token: string, locationId: string): Promise<CarInterface[]> => {
    if (token) {
        const response = await fetch(`http://localhost:5193/api/RentCar/${locationId}/Cars`, {
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

        return await response.json();

    } else {
        console.log('Token is not available');
    }
    return [];
}