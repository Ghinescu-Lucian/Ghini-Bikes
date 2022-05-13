import React from "react";
import "./CSS/SignUpForm.css";
import { useForm } from "react-hook-form";


export const SignUpForm = () => {
    const { register, handleSubmit} = useForm();
    const onFormSubmit = (data) => {
        console.log(data);
    }

    const nameObj = register("name",{
        required: true
    });

    return (
        <div className="center">
            <h1>SignUp</h1>
            <form method="post">
                <div className="txt_field">
                    <input id="name" name="Name" type="text" required />
                    <span></span>
                    <label>Name</label>
                </div>
                <div className="txt_field">
                    <input id="email" name="Email" type="text" required />
                    <span></span>
                    <label>Email</label>
                </div>
                <div className="txt_field">
                    <input id="username" name="Username" type="text" required />
                    <span></span>
                    <label>Username</label>
                </div>
                <div className="txt_field">
                    <input id="pwd" name="Password" type="password" required />
                    <span></span>
                    <label>Password</label>
                </div>
                <div className="txt_field">
                    <input id="pwdC" name="PasswordC" type="password" required />
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