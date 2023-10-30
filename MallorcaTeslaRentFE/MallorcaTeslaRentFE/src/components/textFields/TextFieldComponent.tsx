import  {FC} from 'react';
import {useFormikContext, useField} from 'formik';
import {TextField} from "@mui/material";

interface Props {
    label: string;
    className?: string;
}

const InputComponent: FC<Props> = ({ label, className}) => {
    const { values, handleChange } = useFormikContext();
    const [, meta] = useField(label);
    return (
        <TextField
            className={className}
            variant="outlined"
            color="primary"
            label={label}
            value={values}
            onChange={handleChange}
            helperText={meta.error}
            error={!!(meta.touched && meta.error)}
        />
    );
};

export default InputComponent;