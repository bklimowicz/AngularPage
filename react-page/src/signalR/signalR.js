import * as signalR from "@microsoft/signalr";
import { LogLevel } from "redux-signalr";

var _connection = null;

const signalRConnect = () => {
    try {
        _connection = new signalR.HubConnectionBuilder()
            .configureLogging(LogLevel.Debug)
            .withUrl("https://localhost:7115/gateway")
            .build();

        _connection.start();
    } catch (ex) {
        console.log("Error creating signalR connection");
    }
};

const connection = () => {
    if (_connection === null) signalRConnect();
    return _connection;
};

export default connection;
