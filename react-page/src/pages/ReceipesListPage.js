import React from 'react';

function ReceipesListPage() {

    const receipes = [
        "First element",
        "Second element",
        "Third element"
    ];

    return <div>
        <div>
            <button>Add new receipe</button>
        </div>
        <div>
            <h1> Receipes list </h1>
        </div>
        <div>
            {receipes.map((receipe) => <h2>{receipe}</h2>)}
        </div>
    </div>
}

export default ReceipesListPage;
