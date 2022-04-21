import React from "react";
import styles from "./Logout.module.scss";
import { logout } from "../../features/userSlice";
import { useDispatch } from "react-redux";

const Logout = () => {
    const dispatch = useDispatch();

    const handleLogout = (e) => {
        e.preventDefault();

        dispatch(logout());
    };

    return (
        <div className={styles.logout}>
            <h1>
                Welcome <span className={styles.user__name}>adad</span>
            </h1>
            <button
                className={styles.logout__button}
                onClick={(e) => handleLogout(e)}
            >
                Logout
            </button>
        </div>
    );
};

export default Logout;
