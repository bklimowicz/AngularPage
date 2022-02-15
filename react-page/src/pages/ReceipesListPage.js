import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { addIngredients } from '../features/receipe';

function ReceipesListPage() {

    const receipes = useSelector((state) => state.receipe.value);
    const dispatch = useDispatch();    

    const style = {
        display: "flex",
        flexWrap: "wrap",
        justifyContent: "center",
    };    

    return <div>
        <div style={style}>
            <input type="text"></input>
            {/* <input type="text"></input>
            <input type="text"></input>
            <input type="text"></input> */}
            <button>Add ingredient</button>
        </div>
        <div>
            <h1> Receipes list </h1>
        </div>
        <div>
            {receipes.map((receipe) =>
                <div key={receipe.key}>

                    <h2>
                        {receipe.name}
                    </h2>
                    {receipe.ingredients.map((ingredient) =>
                        <div key={ingredient.key}>
                            <h2>{ingredient.name}</h2>
                        </div>
                    )}
                    <input type="text" placeholder='Add ingredient'></input>
                    <button
                        onClick={() => {
                            dispatch(addIngredients({...receipes}))
                        }}
                    >
                        Add
                    </button>
                </div>
            )}
        </div>
    </div >
}

export default ReceipesListPage;
