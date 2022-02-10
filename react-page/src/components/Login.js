import React from 'react';
import { useDispatch } from 'react-redux';
import { login, logout } from '../features/user';

function Login() {
    const dispatch = useDispatch();
    return <div>
        <button onClick={() => {
            dispatch(login({
                name: "Pedro",
                age: 20,
                email: "pedro@gmail.com"
            }));
        }}
        >
            Login
        </button>
        <br></br>
        <button onClick={() => {
            dispatch(logout());
        }}
        >
            logout
        </button>
    </div>;
}

export default Login;
