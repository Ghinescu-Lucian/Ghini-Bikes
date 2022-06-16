import React from "react";
import styles from './CSS/Nav.module.css';
import * as data from './links.json';
import LocalGroceryStoreIcon from '@material-ui/icons/LocalGroceryStore';
import { useEffect, useState } from 'react';
import { LogoNav } from "./LogoNav";
import { useNavigate } from "react-router-dom";
import { CartIcon } from "./CartIcon";
// '@mui/icons-material/AccountCircle';
const linksString = JSON.stringify(data);
const links = JSON.parse(linksString).links;


type Link = {
    label: string;
    href: string;
};



const Links: React.FC<{ links: Link[], size: number, role: string }> = ({ links, size, role }) => {
    // console.log("ROLE@2", role);

    const navigate = useNavigate();

    const handleLogout2 = () => {
        // console.log("AJDIPAJKDJAK");
        localStorage.clear();
        navigate("/");
        window.location.reload();
        // setRole(usr => "there");

    }

    return (
        <div className={styles['links-container']}>
            {links.map((link: Link) => {
                if (role === "Administrator") {
                    // console.log("AICIICIC");
                    var labl;
                    if (link.label.includes("ADMN")) {
                        labl = link.label.substring(4);
                    }
                    else labl = link.label;
                    if (labl === "Profile") return;
                    if (link.label === "LogIn") {
                            return (
                                <div key={link.href} className={styles['link']}>
                                    <button  style={{ background: '#cb891d', borderRadius: "10%"}}onClick={handleLogout2}>LogOut</button>
                                </div>
                            )
                    }
                    return (
                        <div key={link.href} className={styles['link']}>
                            <a href={link.href}>
                                {labl}
                            </a>
                        </div>
                    )
                }

                else {
                    if (link.label.includes("ADMN") == false) {
                        if (link.label === "LogIn") {
                            if (role !== "user") {
                                // console.log(role, "AICIII");
                                return (
                                    <div key={link.href} className={styles['link']}>
                                        <button  style={{ background: '#cb891d', borderRadius: "10%"}}onClick={handleLogout2}>LogOut</button>
                                    </div>
                                )
                            }
                        }
                        if(link.label === "Profile"){
                            if(role === "user")
                                return;
                        }
                        return (
                            <div key={link.href} className={styles['link']}>
                                <a href={link.href}>
                                    {link.label}
                                </a>
                            </div>
                        )
                    }
                }
            })}
            {
                role === "Administrator" ? (<div></div>) :
                    (<div className="cart">
                        <span>
                            <a href={"http://localhost:3000/cart/"}><CartIcon /></a>
                        </span>
                        <span className="">{size}</span>
                    </div>)
            }
        </div>
    )
};

const Nav: React.FC<{ size: number }> = ({ size }) => {

    const [role, setRole] = useState("there");
    useEffect(() => {
        setRole(usr => localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user") || "").role : "user");
    }, [localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user") || "").role : "user"]
    );

    // console.log("ROLE", role);
    return (
        <nav className={styles.navbar}>
            <div className={styles['logo-container']}>
                {/* <span>Logo    </span> */}
                <LogoNav />
                {/* <LocalGroceryStoreIcon/> */}
            </div>

            <Links links={links} size={size} role={role} />
        </nav>
    );
}

export default Nav;