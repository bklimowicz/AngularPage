import { createSlice } from '@reduxjs/toolkit';

const initialStateValue = [
    {
        key: 0,
        name: "MyFirstReceipe",
        ingredients: [{
            key: 0,
            name: "Ingredient",
        }],
        steps: [{
            key: 0,
            header: "header",
            content: "content",
        }],
    },
    {
        key: 1,
        name: "MySecondReceipe",
        ingredients: [{
            key: 1,
            name: "Ingredient",
        }],
        steps: [{
            key: 1,
            header: "header",
            content: "content",
        }],
    },
    {
        key: 2,
        name: "MyThirdReceipe",
        ingredients: [{
            key: 2,
            name: "Ingredient",
        }],
        steps: [{
            key: 2,
            header: "header",
            content: "content",
        }],
    }
];

export const receipeSlice = createSlice({
    name: "receipe",
    initialState: {
        value: initialStateValue
    },
    reducers: {
        addIngredients: (state, action) => {
            const receipe = state.value.filter((x) => x.key === action.payload.key);
            receipe.ingredients.push(action.payload.ingredients);

            state.value = {...state.value, receipe};
        },

        addSteps: (state, action) => {
            state.value.steps = action.payload.steps;
        }
    },
});

export const { addIngredients, addSteps } = receipeSlice.actions;

export default receipeSlice.reducer;