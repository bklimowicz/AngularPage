import React, { useState } from "react";
import { useDispatch } from "react-redux";
import styles from "./Login.module.scss";
import { loginUserAction } from "../../features/userSlice";

const Login = () => {
    const [name, setName] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const dispatch = useDispatch();

    const handleSubmit = (e) => {
        e.preventDefault();

        dispatch(
            loginUserAction({
                name,
                email,
                password,
            })
        );
    };

    return (
        <div className={styles.login}>
            <form
                className={styles.login__form}
                onSubmit={(e) => handleSubmit(e)}
            >
                <input
                    type="name"
                    placeholder="name"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                />
                <input
                    type="email"
                    placeholder="email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                />
                <input
                    type="password"
                    placeholder="password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                />
                <button type="submit" className={styles.submit__btn}>
                    Submit
                </button>
            </form>
        </div>
    );
};

export default Login;
