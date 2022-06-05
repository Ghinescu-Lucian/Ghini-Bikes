import { Grid } from "@material-ui/core"
import { useEffect } from "react";
import Content from "../Components/Content";
import * as partService from '../Services/PartService.js';
import * as bikeService from '../Services/BikeService.js';
import { useState } from 'react';
import ProductCard from "../Components/ProductCard";
import SearchIcon from "@material-ui/icons/Search";
import { useForm } from "react-hook-form";
import Button from "@material-ui/core/Button";


const Parts = ({ handleClick }) => {

    const [parts, setParts] = useState([]);
    const [role, setRole] = useState("client");

    const { register, handleSubmit, reset, formState: { errors }, watch } = useForm();

    const [searchTerm, setSearchTerm] = useState("");

    const onFormSubmit2 = async (data) => {

        var keyword = data.keyword;
        setSearchTerm(keyword);
    }


    const partProducts = async () => {
        const response = await partService.GetParts();
        var descrp = "Compatibilities: \n";
        for (let j = 0; j < response.length; j++) {
            for (let i = 0; i < response[j].compatibilities.length; i++) {
                var r = await bikeService.GetBikeById(response[j].compatibilities[i].bike_Id);
                //   console.log(r.year);
                descrp = descrp + " " + r.manufacturer + "  " + r.model + "  " + r.year + " \n";
            }
            // console.log("RESP",response[j]);
            response[j].description = response[j].description + " \n " + descrp;
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
    let list2 = parts.filter((val) => {
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
    });

    console.log("List 2", list2);

    return (
        <div>
            Piese
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
                                    parts.filter((val) => {
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