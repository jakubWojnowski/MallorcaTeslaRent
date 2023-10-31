import React from 'react';
interface TileComponentProps {
    backgroundColor: string;
    title: string;
    onClick: () => void;
}

const TileComponent: React.FC<TileComponentProps> = ({ backgroundColor, title, onClick }) => {
    return (
        <div
            style={{ backgroundColor }}
            onClick={onClick}
            className="tile"
        >
            <h2>{title}</h2>
        </div>
    );
}

export default TileComponent;