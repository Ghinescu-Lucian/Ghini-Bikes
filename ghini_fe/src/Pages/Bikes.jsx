import { Grid } from "@material-ui/core"
import { useEffect } from "react";
import * as bikeService from '../Services/BikeService.js';
import { useState } from 'react';
import ProductCard from "../Components/ProductCard";

const Bikes = () => {

    const [bikes, setBikes] = useState([]);

    const bikeProducts = async () => {
        const response = await bikeService.GetBikes();
        setBikes(response);
    }
    useEffect(() => {
        bikeProducts();
    }, []);

    bikes.map((values) => {
        console.log(values);
     })

    return (
        <div>
            Biciclete
            <div className="container">
            <Grid container direction="column">
                <Grid item container>
                    <Grid item xs={false} sm={2}></Grid>
                    <Grid item xs={12} sm={12} md={8}>
                    <Grid container spacing={2}>
                        {
                            bikes.map((values) => {
                                return (
                                    
                                        <Grid item xs={12} sm={4}>
                                            <ProductCard {... values} image={values.images[0].path}/>
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
        </div>
    );
};
export default Bikes;