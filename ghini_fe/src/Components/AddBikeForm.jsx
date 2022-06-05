import React, { useEffect, useState } from "react"
import "./CSS/AddBikeForm.css";
import { useForm } from "react-hook-form";
import { yupResolver } from '@hookform/resolvers/yup';
import * as yup from "yup";
import * as bikeService from '../Services/BikeService.js';
import * as accessoryService from '../Services/AccessoryService.js';
import { useNavigate } from "react-router-dom";


const schema = yup.object()
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

export const AddBikeForm = () => {

    const { register, handleSubmit, reset, formState: { errors }, watch } = useForm(
        {
            resolver: yupResolver(schema)
        }); 

    const [token, setToken] = useState("");
    const [file, setFile] = useState("");

    const saveFile = (e) => {
        setFile(e.target.files[0]);
    }

    useEffect(() => {
        setToken(usr => localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user")).token : "user");
    }, [localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user")).username : "user"]
    );
    // console.log(token);

    const onFormSubmit = async (data) => {
        console.log(data);
        data.file = file;
        if (data.category <= 3) {
            try {
                var AddBike_Result = await bikeService.AddBike(data, token);
            }
            catch (err) {
                console.log("Something went wrong", err);
                alert("Something went wrong!");
            }
            if (AddBike_Result >= 200 && AddBike_Result < 210)
                alert("Product added with success!")
            else alert("Something went wrong!");
            // window.location("/bikes");
        }
        else if (data.category == 5) {
            try {
                var AddAcc_Result = await accessoryService.AddAccessory(data, token);
            }
            catch (err) {
                console.log("Something went wrong", err);
            }
            if (AddAcc_Result >= 200 && AddAcc_Result < 210)
            alert("Product added with success!")
        else alert("Something went wrong!");
        }
        // try {
        //     var AdDBike_Result = await userService.Login(data);
        // }
        // catch (err) {
        //     console.log("Wrong credentials 123");
        // }
        // if (Login_Result) {
        //     var res = JSON.stringify(Login_Result);
        //     localStorage.setItem('user', res);
        //     // UserProfile.setName(Login_Result.username);
        //     // console.log("Username:", data.username);
        //     // console.log(localStorage.getItem("user"));
        //     // navigate("/");
        //     // console.log(Login_Result, "REZULTAT");
        // }
    }

    return (
        <div className="center">
            <h1> Add products</h1>
            <form onSubmit={handleSubmit(onFormSubmit)} method="post">
                <div className="txt_field">
                    <input name="manufacturer" type="text"
                        {...register("manufacturer")}
                        asp-for="FileUpload.FormFile"
                        defaultValue="Proba"
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
                        defaultValue="Proba"
                    />
                    <div className="error">
                        {errors.model?.message}
                    </div>
                    <span></span>
                    <label>Model</label>
                </div>
                <div className="txt_field">
                    {/* <input name="category" type="text" required /> */}
                    <span></span>
                    <select id="cars" name="category" className="txt_fieldD"  {...register("category")} asp-for="FileUpload.FormFile" 
                            style={{color: '#00131a', width:"45%", fontWeight: '700', fontSize:"16px"}}
                        >
                        <option value="1">Classic bike</option>
                        <option value="2">MTB</option>
                        <option value="3">Electric bike</option>
                        <option value="5">Accessory</option>
                    </select>
                    <label>Category</label>
                </div>
                <div className="txt_field">
                    <input name="year" type="text"
                        {...register("year")}
                        asp-for="FileUpload.FormFile"
                        defaultValue="2022"
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
                    <textarea className="ckeditor" name="description" rows={4} cols={45}
                        {...register("description")}
                        asp-for="FileUpload.FormFile"
                        defaultValue="Description"></textarea>
                </div>
                <div className="txt_field">
                    <input name="price" type="text"
                        {...register("price")}
                        asp-for="FileUpload.FormFile"
                        defaultValue="2022"
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
                        defaultValue="2022"
                    />
                    <span></span>
                    <label>Weight</label>
                </div>
                <div className="txt_field">
                    <input name="warranty" type="text"
                        {...register("warranty")}
                        asp-for="FileUpload.FormFile"
                        defaultValue="2022"
                    />
                    <span></span>
                    <label>Warranty months</label>
                </div>
                <div className="txt_field">
                    <input name="quantity" type="text"
                        {...register("quantity")}
                        asp-for="FileUpload.FormFile"
                        defaultValue="2022"
                    />
                    <div className="error">
                        {errors.quantity?.message}
                    </div>
                    <span></span>
                    <label>Quantity</label>
                </div>
                <input type="file" name="file"
                    {...register("file")}
                    asp-for="FileUpload.FormFile"
                    onChange={saveFile}
                />
                <div className="error">
                    {errors.file?.message}
                </div>
                <input type="submit" name="submit" value="Upload" />
            </form>
        </div>
    );

}