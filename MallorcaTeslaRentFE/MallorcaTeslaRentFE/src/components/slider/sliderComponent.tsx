import  {FC} from 'react';
import {useFormikContext} from 'formik';
import {Slider} from "@mui/material";

interface Props {
    label: string;
    className?: string;
}

const SliderComponent: FC<Props> = ({ label, className}) => {
    const { values, handleChange } = useFormikContext<number[]>();
    return (
        <Slider
            value={values}
            className={className}
            getAriaLabel={() => label}
            onChange={handleChange}
            valueLabelDisplay="auto"
            step={1}
            min={1}
            max={100}
        />
    );
};
    
export default SliderComponent;