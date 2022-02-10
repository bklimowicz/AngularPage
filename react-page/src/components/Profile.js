import React from 'react';
import { useSelector } from 'react-redux';

function Profile() {
    const user = useSelector((state) => state.user.value);
    const themeColor = useSelector((state) => state.theme.value);

    return <div style={{color: themeColor}}>
        <h1>
            Profile Page
            <p>Name:{user.name}</p>
            <p>Age:{user.age}</p>
            <p>Email:{user.email}</p>
        </h1>
    </div>;
}

export default Profile;