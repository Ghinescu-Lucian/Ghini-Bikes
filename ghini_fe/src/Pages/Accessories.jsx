import { Grid } from "@material-ui/core"
import { useEffect } from "react";
import Content from "../Components/Content";
import * as accessoryService from '../Services/AccessoryService.js';
import { useState } from 'react';
import ProductCard from "../Components/ProductCard";

const Parts = ({ handleClick }) => {

    const [accessories, setAccessories] = useState([]);
    const [role, setRole] = useState("client");

    useEffect(() => {
        setRole(usr => localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user")).role : "client");
    }, [localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user")).username : "user"]
    );

    const accessoryProducts = async () => {
        const response = await accessoryService.GetAccessories();
        //console.log(response);
        setAccessories(response);
    }
    useEffect(() => {
        accessoryProducts();
    }, []);

    accessories.map((values) => {
        console.log(values.images[0].path);
    })

    return (
        <div>
            Accesorii
            <Grid container direction="column">
                <Grid item container>
                    <Grid item xs={false} sm={2}></Grid>
                    <Grid item xs={12} sm={8}>
                        <Grid container spacing={2}>
                            {
                                accessories.map((values) => {
                                    // console.log(values.images.length());
                                    return (

                                        <Grid item xs={12} sm={4}>
                                            <ProductCard {...values} props={values} image={values.images[0].path} role={role}
                                                id={values.productId} data={values} handleClick={handleClick} />

                                        </Grid>

                                    )
                                })
                            }
                        </Grid>
                    </Grid>
                    <Grid item xs={false} sm={2}></Grid>
                </Grid>
            </Grid>
        </div>
    );
};
export default Parts;