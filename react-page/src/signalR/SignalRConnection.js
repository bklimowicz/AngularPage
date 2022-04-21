import * as signalR from "@microsoft/signalr";

const SignalRConnection = () => {
    const hubConnection = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:7115/message")
        .build();

    hubConnection.start();

    return hubConnection;
};

export default SignalRConnection;
