import { call } from "redux-saga/effects";
import { loginUser } from "../requests/user";

export function* handleLoginUser(action) {
    try {
        yield call(loginUser, action.payload);
    } catch (error) {
        console.log(error);
    }
}
