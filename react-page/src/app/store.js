import { configureStore, combineReducers } from "@reduxjs/toolkit";
import createSagaMiddleware from "@redux-saga/core";
import userReducer from "../features/userSlice";
import { watcherSaga } from "../sagas/rootSaga";

const reducer = combineReducers({
    user: userReducer,
});

const sagaMiddleware = createSagaMiddleware();
const middleware = [sagaMiddleware];

export default configureStore({
    reducer,
    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware().concat(...middleware),
});

sagaMiddleware.run(watcherSaga);
