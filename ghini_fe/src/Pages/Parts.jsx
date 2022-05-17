import { Grid } from "@material-ui/core"
import { useEffect } from "react";
import Content from "../Components/Content";
import * as partService from '../Services/PartService.js';
import { useState } from 'react';
import ProductCard from "../Components/ProductCard";

const Parts = () => {

    const [parts, setParts] = useState([]);
   // const lnk = "https://localhost:7155/Images/FOCUS.png";

    const partProducts = async () => {
        const response = await partService.GetParts();
        //console.log(response);
        setParts(response);
    }
    useEffect(() => {
        partProducts();
    }, []);

    parts.map((values) => {
        console.log(values.images[0].path);
     })

    return (
        <div>
            Piese
            <Grid container direction="column">
                <Grid item container>
                    <Grid item xs={false} sm={2}></Grid>
                    <Grid item xs={12} sm={8}>
                    <Grid container spacing={2}>
                        {
                            parts.map((values) => {
                               // console.log(values.images.length());
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
    );
};
export default Parts;