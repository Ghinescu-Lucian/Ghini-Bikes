import { Grid } from "@material-ui/core"
import { useEffect } from "react";
import Content from "../Components/Content";
import * as partService from '../Services/PartService.js';
import * as bikeService from '../Services/BikeService.js';
import { useState } from 'react';
import ProductCard from "../Components/ProductCard";

const Parts = ({ handleClick }) => {

    const [parts, setParts] = useState([]);
    const [role, setRole] = useState("client");

    const partProducts = async () => {
        const response = await partService.GetParts();
        var descrp = "Compatibilities: \n";
        for (let j = 0; j < response.length; j++) {
            for (let i = 0; i < response[j].compatibilities.length; i++) {
                 var r = await bikeService.GetBikeById(response[j].compatibilities[i].bike_Id);
                //   console.log(r.year);
                descrp = descrp + " " +r.manufacturer+ "  "+r.model+ "  "+r.year+ " \n";
            }
            // console.log("RESP",response[j]);
            response[j].description = response[j].description +" \n "+descrp;
        }
        //console.log(response);
        setParts(response);
    }

    useEffect(() => {
        setRole(usr => localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user")).role : "client");
    }, [localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user")).username : "user"]
    );

    useEffect(() => {
        partProducts();
    }, []);

    // parts.map((values) => {
    //     console.log(values.images[0].path);
    // })

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