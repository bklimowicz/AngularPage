import { useEffect, useState } from "react";

const Messages = (props) => {
    const { hubConnection, list } = props;

    const [date, setDate] = useState();
    useEffect(() => {
        hubConnection.on("sendToReact", (message) => {
            list.push(message);
            setDate(new Date());
        });

        hubConnection.on("SendMessage", (message) => {
            list.push(message);
            setDate(new Date());
        });
    });

    return (
        <>
            {list.map((message, index) => (
                <p key={`message${index}`}>{message}</p>
            ))}
        </>
    );
};

export default Messages;
