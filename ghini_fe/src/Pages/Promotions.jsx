import { Grid } from "@material-ui/core"
import { useEffect } from "react";
import * as promotionService from '../Services/PromotionService.js';
import { useState } from 'react';
import ProductCard from "../Components/ProductCard";
import PromotionCard from "../Components/PromotionCard";


const Promotions = () => {
    const [promotions, setPromotions] = useState([]);

    const promotionProducts = async () => {
        const response = await promotionService.GetPromotions();
        // console.log(response, "AAOOAO");
        setPromotions(response);
    }
    useEffect(() => {
        promotionProducts();
    }, []);

    
   

    return (
        <div>
            Promotii
            <div key={Math.random()} className="container">
            <Grid container direction="column">
                <Grid item container>
                    <Grid item xs={false} sm={2}></Grid>
                    <Grid item xs={12} sm={12} md={8}>
                    <Grid container spacing={2}>
                        {
                            promotions.map((values) => {
                                return (
                                          
                                        <Grid item xs={12} sm={4} key={Math.random() -1}>
                                            <PromotionCard {... values} keyUnique={Math.random()}/>
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
export default Promotions;