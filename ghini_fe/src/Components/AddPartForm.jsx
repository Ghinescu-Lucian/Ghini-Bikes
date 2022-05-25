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

export const AddPartForm = () => {}