import { useContext, useEffect, useState } from 'react';
import axios from "axios";

const URL = 'https://localhost:7155/api/Bike'

export async function GetBikeById(id) {
    var URL2 = `${URL}/${id}`;
    let url = URL2;

    var response = await fetch(url, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    });
    return response.ok ? await response.json() : null;
}

export async function GetBikes() {
    var URL2 = `${URL}`;
    let url = URL2;

    var response = await fetch(url, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    });
    return response.ok ? await response.json() : null;

}

export async function AddBike(data, token) {
    var URL2 = `${URL}/addBike`;
    let url = URL2;
    var type
    var img = `{
        id: 0,
        path: "string",
        position: 0,
        productId: 0
    }`
    

    console.log("TOKEN: ", token);
    if (data.category == 1) type = "Bike";
    else if (data.category == 2) type = "MTBBike";
    else if (data.category == 3) type = "ElectricBike";

    // console.log(_username,_password,_email);
    const formData = new FormData();
    formData.set('ProductId', 0);
    // formData.append('ProductId: ', 0);
    formData.append('Type', type);
    formData.append('Description', data.description);
    formData.append('price', data.price);
    formData.append('Manufacturer', data.manufacturer);
    formData.append('Model', data.model);
    formData.append('Images', img);
    formData.append('ImagesURL', data.file);
    formData.append('quantity', data.quantity);
    formData.append('category', data.category);
    formData.append('warrantyMonths', data.warranty);
    formData.append('Specification', "string");
    formData.append('weight', data.weigth);

    console.log(data.file);



    var options = {
            productId: 0,
            type: "string",
            description: "string",
            year: 0,
            price: 0,
            manufacturer: "string",
            model: "string",
            images: [
              {
                id: 0,
                path: "string",
                position: 0,
                productId: 0
              }
            ],
            imagesURL: [
              "string"
            ],
            quantity: data.quantity,
            category: data.category,
            warrantyMonths: data.warranty,
            specification: "string",
            weigth: data.weigth};

    const headers = {
        // Accept: "multipart/form-data",
        // 'Content-Type': 'multipart/form-data; boundary=abcde12345',
        'Authorization': `Bearer ${token}`,

    }

    let res;
    try {
        res = await axios.post(url, formData,{headers: headers});
    } catch (ex) {
        console.log(ex);
    }
    return res;

    // return fetch(url, {
    //     method: 'POST',
    //     headers: {
    //         'content-type': 'multipart/form-data; boundary=abcde12345'  ,
    //         Authorization: `Bearer ${token}`,
    //     },
    //     body: formData
    // })
    //     // .then(res => res.json())
    //     // .then(function (response) {
    //     //     if (response.status !== 201) {
    //     //         // console.log("Username or Email already exists!");
    //     //         // alert(response.body);
    //     //         console.log(response.body);
    //     //         // alert("Username or Email already exists!");
    //     //     }
    //     //     console.log(response.errors);
    //     //     return response.json();
    //     // })
    //     .catch(function (err) {
    //         console.log(err, "eorrr");
    //         // alert("Username already exists12");
    //     })
    //     .then(function (response) {
    //             if (response.status !== 201) {
    //                 // console.log("Username or Email already exists!");
    //                 // alert(response.body);
    //                 console.log(response.text());
    //                 // alert("Username or Email already exists!");
    //                 return null;
    //             }
    //             console.log(response.text());
    //             return response.json();
    //         });

}
