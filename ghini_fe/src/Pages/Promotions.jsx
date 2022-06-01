import { Grid } from "@material-ui/core"
import { useEffect } from "react";
import * as promotionService from '../Services/PromotionService.js';
import { useState } from 'react';
import PromotionCard from "../Components/PromotionCard";


const Promotions = ({handleClick}) => {
    const [promotions, setPromotions] = useState([]);
    const [role, setRole] = useState("client");
    useEffect(() => {
        setRole(usr => localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user")).role : "client");
    }, [localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user")).username : "user"]
    );

    const promotionProducts = async () => {
        const response = await promotionService.GetPromotions();
        // console.log(response, "AAOOAO");
        setPromotions(response);
    }
    useEffect(() => {
        promotionProducts();
    }, []);

    promotions.map((values) => (console.log(values)));
   

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
                                            <PromotionCard keyUnique={Math.random()}
                                            props ={values}  role={role}
                                            id={values.id} data={values} handleClick={handleClick}
                                            image={values.image}
                                            />
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