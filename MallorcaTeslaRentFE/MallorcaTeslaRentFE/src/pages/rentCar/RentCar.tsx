import {FC} from "react";
import {Link} from "react-router-dom";

interface RentCarProps {

}
const RENTAL_LOCATIONS = [
    {id: 1, name: "Location 1"},
    {id: 2, name: "Location 2"},
    {id: 3, name: "Location 3"},
    {id: 4, name: "Location 4"},
]
    
export const RentCar: FC<RentCarProps> = () => {
    return (
        <div>
            <h1>RentCar Page</h1>
            <ul>
                {RENTAL_LOCATIONS.map((location) => (
                    <li key={location.id}>
                        <Link to={`/rentCar/${location.id}`}>{location.name}</Link>
                    </li>
                ))}
            </ul>
        </div>
    );
}