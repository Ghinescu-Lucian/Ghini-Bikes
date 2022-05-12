import React from "react"; 
import styles from './CSS/Nav.module.css';
import * as data from './links.json';
import LocalGroceryStoreIcon from '@material-ui/icons/LocalGroceryStore';
import { LogoNav } from "./LogoNav";
// '@mui/icons-material/AccountCircle';
const linksString = JSON.stringify(data);
const links = JSON.parse(linksString).links;


type Link = {
    label : string;
    href : string;
};

const Links: React.FC<{ links: Link[] }> = ({ links }) => {
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
        </div>
    )
};

const Nav: React.FC<{}> = () => {
    return (
        <nav className={styles.navbar}>
            <div className={styles['logo-container']}>
                {/* <span>Logo    </span> */}
                <LogoNav/>
                {/* <LocalGroceryStoreIcon/> */}
            </div>
            <Links links={links} />
        </nav>
    )
}

export default Nav;