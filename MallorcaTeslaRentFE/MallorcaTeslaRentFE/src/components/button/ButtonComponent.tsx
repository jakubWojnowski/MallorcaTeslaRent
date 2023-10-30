import {FC} from 'react';
import {useFormikContext} from 'formik';
import {Button} from "@mui/material";

interface Props {
    label: string;
    className?: string;
    onClick?: () => void;
}

const ButtonComponent: FC<Props> = ({ label, className, onClick }) => {
    const { submitForm } = useFormikContext();
    return (
        <Button
            className={className}
            variant="contained"
            color="primary"
            onClick={onClick ? onClick : submitForm}
        >
            {label}
        </Button>
    );
};

export default ButtonComponent;