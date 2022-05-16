import { createSlice } from "@reduxjs/toolkit";

export const userSlice = createSlice({
    name: "user",
    initialState: {
        user: null,
    },
    reducers: {
        loginUserAction: (state, action) => {},
        logoutUserAction: (state) => {
            state.user = null;
        },
        loginUserAction_ServerResponse: (state, action) => {
            state.user = action.payload;
        },
    },
});

export const {
    loginUserAction,
    logoutUserAction,
    loginUserAction_ServerResponse,
} = userSlice.actions;

export const selectUser = (state) => state.user.user;

export default userSlice.reducer;
