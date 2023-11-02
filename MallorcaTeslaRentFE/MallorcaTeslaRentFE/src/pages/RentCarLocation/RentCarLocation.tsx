import {FC} from "react";
import {Link, useParams} from "react-router-dom";
import {GetAuth} from "../../utils/Auth.ts";

interface RentCarLocationProps {
    
    }

const RentCarLocation: FC<RentCarLocationProps> = () =>{
    const params = useParams();
    const token = GetAuth().token;
  
    return (
        <div>
            <h1>RentCarLocation Page</h1>
            <h2>Location: {params.rentCarLocationId}</h2>
            <p> {params.rentCarLocationId}</p>
            <p><Link to=".." relative="path"> Back</Link> </p>
        </div>
    );
}
export default RentCarLocation;