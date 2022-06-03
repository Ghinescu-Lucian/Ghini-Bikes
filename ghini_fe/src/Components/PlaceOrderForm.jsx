import React, { useEffect, useState } from "react"
import "./CSS/PlaceOrderForm.css";
import { useForm } from "react-hook-form";
import { yupResolver } from '@hookform/resolvers/yup';
import * as yup from "yup";
import * as orderService from '../Services/OrderService.js';
import { useNavigate } from "react-router-dom";
import Select from 'react-select';


const schema2 = yup.object()
    .shape({
        name: yup.string().required(),
        telephone: yup.string().min(10).max(14).required(),
    })
    .required();

export const PlaceOrderForm = () => {


    const navigate = useNavigate();
    let ok = 0;
    let cost;
    let userData;
    if (localStorage.getItem("totalPrice")) {
        cost = localStorage.getItem("totalPrice");
        if (cost <= 2500) {
             ok = 1;
             // cost = cost + 25;
             // localStorage.setItem('totalPrice', cost);
 
         }
     }
     
     if (localStorage.getItem("user")) {
        userData = JSON.parse(localStorage.getItem("user"));
        
     }

    const data = [
        {
            value: 1,
            label: "Personal lifting"
        },
        {
            value: 2,
            label: "Courier"
        }
    ];

    const [selectedOption, setSelectedOption] = useState(null);
    const [cart, setCart] = useState(localStorage.getItem("cart") ? JSON.parse(localStorage.getItem("cart")) : []);

    // handle onChange event of the dropdown
    const handleChange = e => {
        setSelectedOption(e);
    }

    useEffect(() => {
        // console.log("AOAOOAOA");
        if (selectedOption) {
            var part2 = document.getElementById('part2');
            var part1 = document.getElementById('part1');
            if (selectedOption.value == 2) {
                part2.setAttribute("style", "display:true;");
                part1.setAttribute("style", "display:none;");
                console.log(part2);
            }
            else {
                part2.setAttribute("style", "display:none;");
                part1.setAttribute("style", "display:true;");
                console.log(part2);


            }
        }


    }, [selectedOption]);


    const { register, handleSubmit, reset, getValues, formState: { errors }, watch } = useForm(
        {
            resolver: yupResolver(schema2)
        });


    const onFormSubmit1 = async (data) => {
        data.shipping_method = selectedOption.value;
        console.log(data,cart,userData);

    
            var place_Result = await orderService.placeOrder(data,cart, userData);
            if (place_Result) {
                console.log(place_Result, "REGISTER AICI");
                alert("Order placed successfully!"); 
                navigate("/");
            }
        
       
    }
    // ok = 1;
    return (
        <div className="center1">
            <h1>Place order</h1>
            <form method="POST"
                onSubmit={handleSubmit(onFormSubmit1)}
            >


                <div className="txt_field1">

                    <input id="name" name="name" type="text"  {...register("name")} />
                    <div className="error">
                        {errors.name?.message}
                    </div>
                    <span></span>
                    <label>Name</label>
                </div>

                <div className="txt_field1">

                    <input id="telephone" name="telephone" type="text"  {...register("telephone")} />
                    <div className="error">
                        {errors.telephone?.message}
                    </div>
                    <span></span>
                    <label>Telephone</label>
                </div>


                <div className="txt_field1" >
                    {/* <select id="shipping" name="shipping_method" className="txt_field"
                        {...register("shipping_method")} asp-for="FileUpload.FormFile"
                    //  onSelect={handleSelect1}
                    > */}
                    <Select
                        placeholder="Select Option"
                        value={selectedOption} // set selected value
                        options={data} // set list of the data
                        onChange={handleChange} // assign onChange function
                    />

                    {/* </select> */}
                    <span></span>
                    {/* <label>Shipping<br /> method</label> */}
                </div>
                <div id="part1">


                    <input id="address" name="address" type="hidden" />
                    <span></span>

                    <label>See address details in about page</label>
                </div>
                <div id="part2" style={{ display: "none" }}>
                    <span>{ok == 1 ? "Transport = +25 RON" : "TRANSPORT: FREE"}</span>
                    <div className="txt_field1">

                        <input id="address" name="address" type="text"  {...register("address")} />
                        <div className="error">
                            {errors.address?.message}
                        </div>
                        <span></span>
                        <label>Address</label>
                    </div>

                    <div className="txt_field1">
                        <select id="cars" name="payment" className="txt_field"  {...register("payment")} asp-for="FileUpload.FormFile" >
                            <option value="1">Cash on delivery</option>
                            <option value="2">Card</option>
                        </select>
                        <span></span>
                        <label>Payment</label>
                    </div>
                </div>


                <input type="submit" value="Place order" />

                <div className="signup_link">
                </div>
            </form>
        </div>
    );
}