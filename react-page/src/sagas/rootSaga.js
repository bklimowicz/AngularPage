import { takeLatest } from "redux-saga/effects";
import { loginUserAction } from "../features/userSlice";
import { handleLoginUser } from "./handlers/user";

export function* watcherSaga() {
    yield takeLatest(loginUserAction, handleLoginUser);
}
