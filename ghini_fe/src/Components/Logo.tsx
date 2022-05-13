import React from 'react'
import logo from './../Images/GhiniBikeLogo.png'
import "./CSS/Logo.css";
export const Logo = () => {
    return (
        <div className='logo'>
            <img src={logo} />
        </div>
    )
}