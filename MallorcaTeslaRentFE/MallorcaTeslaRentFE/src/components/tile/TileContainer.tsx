import React from 'react';
import './TileContainer.module.css'; 

interface TileContainerProps {
    children: React.ReactNode;
}

const TileContainer: React.FC<TileContainerProps> = ({ children }) => {
    return (
        <div className="tile-container">
            {children}
        </div>
    );
}

export default TileContainer;