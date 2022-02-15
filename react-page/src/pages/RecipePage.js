import React from 'react';
import { useSelector } from 'react-redux';

function RecipePage() {
    const receipe = useSelector((state) => state.receipe.value);

    return <div>
        <h1></h1>
        {/* Receipe page */}
    </div>;
}

export default RecipePage;
