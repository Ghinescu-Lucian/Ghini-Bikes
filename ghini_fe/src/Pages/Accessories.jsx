import { Grid } from "@material-ui/core"
import { useEffect } from "react";
import Content from "../Components/Content";
import * as accessoryService from '../Services/AccessoryService.js';
import { useState } from 'react';
import ProductCard from "../Components/ProductCard";
import SearchIcon from "@material-ui/icons/Search";
import { useForm } from "react-hook-form";
import Button from "@material-ui/core/Button";


const Parts = ({ handleClick }) => {

    const [accessories, setAccessories] = useState([]);
    const [role, setRole] = useState("client");

    const { register, handleSubmit, reset, formState: { errors }, watch } = useForm();

    const [searchTerm, setSearchTerm] = useState("");

    const onFormSubmit2 = async (data) => {

        var keyword = data.keyword;
        setSearchTerm(keyword);
    }
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
            <form onSubmit={handleSubmit(onFormSubmit2)}>
                <div className="wrapper">
                    <div className="search-input">
                        <a href="" target="_blank" hidden></a>
                        <input type="text" placeholder="Order ID" {...register("keyword")} />
                        <div className="autocom-box">

                        </div>
                        {/* <div className="icon"><button type="submit" className="fas fa-search"></button></div> */}
                        <Button type="submit" style={{
                            position: "absolute",
                            top: "10%",
                            left: "85%"

                        }}><SearchIcon className="icon" style={{ height: "40px", width: "40px" }} /></Button>
                    </div>
                </div>
            </form>
            <div style={{ position: "relative", marginTop: "2%" }} >

                <Grid container direction="column">
                    <Grid item container>
                        <Grid item xs={false} sm={2}></Grid>
                        <Grid item xs={12} sm={8}>
                            <Grid container spacing={2}>
                                {
                                    accessories.filter((val) => {
                                        if ((val.manufacturer.toLowerCase().includes(searchTerm.toLowerCase())) ||
                                            (val.model.toLowerCase().includes(searchTerm.toLowerCase())) ||
                                            (val.description.toLowerCase().includes(searchTerm.toLowerCase())) ||
                                            val.year == searchTerm
                                        ) {
                                            return val;
                                        }
                                        else if (searchTerm == "") {
                                            return val;
                                        }
                                    }).map((values) => {
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
        </div>
    );
};
export default Parts;