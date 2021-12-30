import React from "react";
import './Header.css';

class Header extends React.Component {
    render() {
        return(
            <header>
                <ul className="menuList">
                    <li>Menu1</li>
                    <li>Menu2</li>
                </ul>
            </header>
        )
    }
}

export default Header;