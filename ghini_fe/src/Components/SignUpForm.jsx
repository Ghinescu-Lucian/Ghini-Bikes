import React, { useEffect } from "react"
import "./CSS/SignUpForm.css";
import { useForm } from "react-hook-form";
import { yupResolver } from '@hookform/resolvers/yup';
import * as yup from "yup";
import * as userService from '../Services/UserService.js';
import { useNavigate } from "react-router-dom";


const schema = yup.object()
    .shape({
        Username: yup.string().required(),
        Password: yup.string().min(4).max(20).required(),
        PasswordC: yup.string().min(4).max(20).required(),
        Email: yup.string().min(5).required(),
    })
    .required();

export const SignUpForm = () => {

    const navigate = useNavigate();


    const { register, handleSubmit, reset, formState: { errors }, watch } = useForm(
        {
            resolver: yupResolver(schema)
        });

    const onFormSubmit = async(data) => {
        console.log(data);
        if(data.Password === data.PasswordC){
            var register_Result = await userService.Register(data.Username, data.Password, data.Email);
            if(register_Result){
                console.log(register_Result,"REGISTER AICI");
                alert("Successfully created user");
                navigate("/LogIn");
            }
        }
        else{
            alert("Password doesn't match!");
        }
    }

    return (
        <div className="center2">
            <h1>SignUp</h1>
            <form method="post"
                onSubmit={handleSubmit(onFormSubmit)}
            >
               
                <div className="txt_field2">
                
                    <input id="email" name="Email" type="text"  {...register("Email")}/>
                    <div className="error">
                        {errors.Email?.message}
                    </div>
                    <span></span>
                    <label>Email</label>
                </div>
                <div className="txt_field2">
                
                    <input id="username" name="Username" type="text"  {...register("Username")}/>
                    <div className="error">
                        {errors.Username?.message}
                    </div>
                    <span></span>
                    <label>Username</label>
                </div>
                <div className="txt_field2">
                
                    <input id="pwd" name="Password" type="password"  {...register("Password")}/>
                    <div className="error">
                        {errors.Password?.message}
                    </div>
                    <span></span>
                    <label>Password</label>
                </div>
                <div className="txt_field2">
                
                    <input id="pwdC" name="PasswordC" type="password"  {...register("PasswordC")}/>
                    <div className="error">
                        {errors.PasswordC?.message}
                    </div>
                    <span></span>
                    <label>Confirm password</label>
                </div>
                <input id="signUp" type="submit" value="SignUp" />
                <div className="signup_link">
                    <br/> <a href="http://localhost:3000/LogIn">Back</a>
                        <br/>
                </div>
            </form>
        </div>
                );
}