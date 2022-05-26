import React, { useEffect, useState } from "react"
import "./CSS/UpdateBikeForm.css";
import { useForm } from "react-hook-form";
import { yupResolver } from '@hookform/resolvers/yup';
import * as yup from "yup";
import * as bikeService from '../Services/BikeService.js';
import * as accessoryService from '../Services/AccessoryService.js';
import { useNavigate } from "react-router-dom";
import { isConstructorDeclaration } from "typescript";


const schema1 = yup.object()
    .shape({
        manufacturer: yup.string().required(),
        model: yup.string().required(),
        year: yup.number().min(2000).required(),
        description: yup.string().required(),
        price: yup.number().required(),
        quantity: yup.number().min(1).required(),
        file: yup.mixed().required('File is required'),

    })
    .required();

export const UpdateBikeForm = (data) => {

    // let data;
    const { register, handleSubmit, reset, formState: { errors }, watch } = useForm(
        {
            // resolver: yupResolver(schema1)
        });

    const [token, setToken] = useState("");
    const [value, setValue] = useState("");
    // const [dataa, setData] = useState("");



    useEffect(() => {
        setToken(usr => localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user")).token : "user");
        setValue(data.data);
    }, [localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user")).username : "user"]
    );
    // console.log(token);
    // console.log("DATA:", value.productId);

    const onFormSubmit = async (data) => {
        console.log("AICI");
        console.log(data);
        let res;

        if (data.manufacturer === '')
            data.manufacturer = value.manufacturer;
        if (data.model === '')
            data.model = value.model;
        if (data.year === '')
            data.year = value.year;
        if (data.description === '')
            data.description = value.description;
        if (data.price === '')
            data.price = value.price;
        if (data.quantity === '')
            data.quantity = value.quantity;
        // data.file = file;
        if (value.category <= 3) {
            try {
                var AddBike_Result = await bikeService.UpdateBike(value.productId, data, token);
            }
            catch (err) {
                console.log("Something went wrong", err);
                alert("Something went wrong!");
            }
            if (AddBike_Result >= 200 && AddBike_Result < 210) {
                alert("Edited with success!");
                window.location.reload(false);
            }
            else alert("Something went wrong!");
            // window.location("/bikes");
        }
        else if (value.category == 5) {
            try {
                var AddAcc_Result = await accessoryService.AddAccessory(data, token);
            }
            catch (err) {
                console.log("Something went wrong", err);
            }
            if (AddAcc_Result >= 200 && AddAcc_Result < 210)
                alert("Product edited with success!")
            else alert("Something went wrong!");
        }

    }


    // console.log(data);
    // console.log(value);
    return (
        <div className="center">
            <h1> Edit</h1>
            {/* onSubmit={handleSubmit(onFormSubmitUpdate)} */}
            <form onSubmit={handleSubmit(onFormSubmit)} method="post">
                <div className="txt_field">
                    <input name="manufacturer" type="text"
                        {...register("manufacturer")}
                        asp-for="FileUpload.FormFile"
                        defaultValue={value.manufacturer}
                    />
                    <div className="error">
                        {errors.manufacturer?.message}
                    </div>
                    <span></span>
                    <label>Manufacturer</label>
                </div>
                <div className="txt_field">
                    <input name="model" type="text"
                        {...register("model")}
                        asp-for="FileUpload.FormFile"
                        defaultValue={value.model}
                    />
                    <div className="error">
                        {errors.model?.message}
                    </div>
                    <span></span>
                    <label>Model</label>
                </div>

                <div className="txt_field">
                    <input name="year" type="text"
                        {...register("year")}
                        asp-for="FileUpload.FormFile"
                        defaultValue={value.year}
                    />
                    <div className="error">
                        {errors.year?.message}
                    </div>
                    <span></span>
                    <label>Year</label>
                </div>
                <div className="txt_field">
                    <div className="error">
                        {errors.description?.message}
                    </div>
                    <span></span>
                    <textarea name="description" rows={4} cols={45}
                        {...register("description")}
                        asp-for="FileUpload.FormFile"
                        defaultValue={value.description}
                    >

                    </textarea>
                </div>
                <div className="txt_field">
                    <input name="price" type="text"
                        {...register("price")}
                        asp-for="FileUpload.FormFile"
                        defaultValue={value.price}
                    />
                    <div className="error">
                        {errors.price?.message}
                    </div>
                    <span></span>
                    <label>Price</label>
                </div>
                <div className="txt_field">
                    <input name="weight" type="text"
                        {...register("weight")}
                        asp-for="FileUpload.FormFile"
                        defaultValue={value.weight}
                    />
                    <span></span>
                    <label>Weight</label>
                </div>
                <div className="txt_field">
                    <input name="warranty" type="text"
                        {...register("warranty")}
                        asp-for="FileUpload.FormFile"
                        defaultValue={value.warrantyMonths}
                    />
                    <span></span>
                    <label>Warranty months</label>
                </div>

                <div className="txt_field">
                    <input name="quantity" type="text"
                        {...register("quantity")}
                        asp-for="FileUpload.FormFile"
                        defaultValue={value.quantity}
                    />
                    <div className="error">
                        {errors.quantity?.message}
                    </div>
                    <span></span>
                    <label>Quantity</label>
                </div>
                <input type="submit" name="submit" value="Save" />
            </form>
        </div>
    );

}