import React, { useEffect } from "react"
import "./CSS/LogInForm.css";
import { useForm } from "react-hook-form";
import { yupResolver } from '@hookform/resolvers/yup';
import * as yup from "yup";
import * as userService from '../Services/UserService.js';

const schema = yup.object()
    .shape({
        Username: yup.string().required(),
        Password: yup.string().required(),
    })
    .required();


export const LogInForm = () => {

    const { register, handleSubmit, reset, formState: { errors }, watch } = useForm(
        {
            resolver: yupResolver(schema)
        });

    // Object.keys(errors).forEach((element) => {
    //     const { ref } = errors[element]
    //     console.log(ref, "eroare element");
    // })

    const onFormSubmit = async (data) => {
        // console.log(data);
        try{
        var Login_Result = await userService.Login(data.Username,data.Password);
        }
        catch(err){
            console.log("Wrong credentials");
        }
        if(Login_Result){
        console.log(Login_Result.status);
         console.log(Login_Result,"REZULTAT");
        }
    }

    

    return (
        <div className="center">
            <h1>Login</h1>
            <form method="POST"
                onSubmit={handleSubmit(onFormSubmit)}
            >
                <div className="txt_field">
                    <input type="text" name="Username"
                        {...register("Username")}
                    />
                    <div className="error">
                        {errors.Username?.message}
                    </div>
                    <span></span>
                    <label>Username</label>
                </div>
                <div className="txt_field">
                    <input type="password" name="Password"
                        {...register("Password")}
                    />
                    <div className="error">
                        {errors.Password?.message}
                    </div>
                    <span></span>
                    <label>Password</label>
                </div>
                <input id="LoginButton" type="submit" value="Login" />
                <div className="signup_link">
                    Not a member? <a href="http://localhost:3000/SignUp">Signup</a>
                </div>
            </form>
        </div>
    )
}