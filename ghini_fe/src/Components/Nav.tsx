import React from "react";
import styles from './CSS/Nav.module.css';
import * as data from './links.json';
import LocalGroceryStoreIcon from '@material-ui/icons/LocalGroceryStore';
import { LogoNav } from "./LogoNav";
import { CartIcon } from "./CartIcon";
// '@mui/icons-material/AccountCircle';
const linksString = JSON.stringify(data);
const links = JSON.parse(linksString).links;


type Link = {
    label: string;
    href: string;
};



const Links: React.FC<{ links: Link[], size: number }> = ({ links, size }) => {
    return (
        <div className={styles['links-container']}>
            {links.map((link: Link) => {
                return (
                    <div key={link.href} className={styles['link']}>
                        <a href={link.href}>
                            {link.label}
                        </a>
                    </div>
                )
            })}
            <div className="cart">
                <span>
                    <a href={"http://localhost:3000/cart/"}><CartIcon /></a>
                </span>
                <span>{size}</span>
            </div>
        </div>
    )
};

const Nav: React.FC<{ size: number }> = ({ size }) => {
    return (
        <nav className={styles.navbar}>
            <div className={styles['logo-container']}>
                {/* <span>Logo    </span> */}
                <LogoNav />
                {/* <LocalGroceryStoreIcon/> */}
            </div>

            <Links links={links} size={size} />
        </nav>
    );
}

export default Nav;