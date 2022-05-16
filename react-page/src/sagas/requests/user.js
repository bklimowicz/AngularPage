import connection from "../../signalR/signalR";
import { loginUserAction_ServerResponse } from "../../features/userSlice";
import { put } from "redux-saga/effects";

const _connection = connection();

export function loginUser(user) {
    _connection.invoke("Login", user);
}

_connection.on("loginUserAction_ServerResponse", (response) => {
    loginUser_ServerResponse(response);
});

function loginUser_ServerResponse(response) {
    console.log(response);
    put(loginUserAction_ServerResponse(response));
}
