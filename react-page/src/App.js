import { useSelector } from "react-redux";
import "./App.module.scss";
import Login from "./pages/login/Login";
import Logout from "./pages/logout/Logout";
import { selectUser } from "./features/userSlice";
import SignalRConnection from "./signalR/SignalRConnection";
import Messages from "./pages/signalRResponseTest/SignalRResponseTest";

const App = () => {
    const hubConnection = SignalRConnection();

    //hubConnection.

    const list = [];

    // const user = useSelector(selectUser);
    // return <div>{user ? <Logout /> : <Login />}</div>;

    const sendMessage = (message) => {
        hubConnection.invoke("SendMessage", message);
    };

    return (
        <div>
            <button onClick={() => sendMessage("dupadupa")}>Button</button>
            <Messages hubConnection={hubConnection} list={list} />
        </div>
    );
};

export default App;
