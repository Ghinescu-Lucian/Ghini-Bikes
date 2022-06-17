import axios from "axios";

const URL = 'https://localhost:7155/api/Promotion'

export async function GetPromotionById(id) {
    var URL2 = `${URL}/${id}`;
    let url = URL2;

    //  console.log("Options ",url);
     return fetch(url, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        // .then(res => res.json())
        .then(function(response){
            if(response.status !== 200){
                console.log("Wrong username or password!");
            }
            return response.json();
        })
        .catch(function(err){
            //  console.log(err,"eorrr");
            alert("Wrong credentials");
        });
}

export async function GetPromotions() {
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


export async function AddPromotion(data, selected, selected2, selected3, token) {
    var URL2 = `${URL}/addPromo`;
    let url = URL2;
    var img = `{
        id: 0,
        path: "string",
        position: 0,
        productId: 0
    }`

  

    // console.log(_username,_password,_email);
    console.log("BA AICI",selected3);
    console.log("BA AIVILEA",selected2);
    console.log("BA AIVILEA",selected);
    const formData = new FormData();
    
    formData.set('Name', data.name);
    formData.append('Image', data.file);
    let i;
    for( i=0 ; i< selected.length; i++){
        var price = selected[i].price - (selected[i].price * selected[i].discount /100); 
        // if(selected[i].discount==100)
        // console.log(`Compatibilities[${i}]`,selected[0]);
        formData.append(`ItemsId[${i}]`,selected[i].productId);
        formData.append(`ItemsDiscount[${i}]`,selected[i].discount);
        formData.append(`ItemsCategory[${i}]`,selected[i].category);
        formData.append(`ItemsQuantity[${i}]`,selected[i].quantity);
        formData.append(`ItemsPrices[${i}]`,price);
    }
    var x =i;
    for( i=0 ; i< selected2.length; i++){
        var price = selected2[i].price - (selected2[i].price *selected2[i].discount /100); 

        // console.log(`Compatibilities[${i}]`,selected[0]);
        formData.append(`ItemsId[${i+x}]`,selected2[i].productId);
        formData.append(`ItemsDiscount[${i+x}]`,selected2[i].discount);
        formData.append(`ItemsCategory[${i+x}]`,selected2[i].category);
        formData.append(`ItemsQuantity[${i+x}]`,selected2[i].quantity);
        formData.append(`ItemsPrices[${i+x}]`,price);

    }
    x=i+x;
    for(let i=0 ; i< selected3.length; i++){
        var price = selected3[i].price - (selected3[i].price * selected3[i].discount /100); 

        // console.log(`Compatibilities[${i}]`,selected[0]);
        formData.append(`ItemsId[${i+x}]`,selected3[i].productId);
        formData.append(`ItemsDiscount[${i+x}]`,selected3[i].discount);
        formData.append(`ItemsCategory[${i+x}]`,selected3[i].category);
        formData.append(`ItemsQuantity[${i+x}]`,selected3[i].quantity);
        formData.append(`ItemsPrices[${i+x}]`,price);

    }
    // formData.append("Compatibilities[0]", selected[0]);
    // formData.append("Compatibilities[1]", selected[1]);
    // formData.append("Compatibilities[2]", selected[2]);
    


    // console.log(sel)
    // return 200;
    const headers = {
        // Accept: "multipart/form-data",
        // 'Content-Type': 'multipart/form-data; boundary=abcde12345',
        'Authorization': `Bearer ${token}`,

    }

    let res;
    try {
        res = await axios.post(url, formData, { headers: headers });
    } catch (ex) {
        console.log(ex);
    }
    return res.status;


}

export async function DeletePromotion(id, token) {
    var url = `${URL}/${id}`;
    const headers = {
        // Accept: "multipart/form-data",
        // 'Content-Type': 'multipart/form-data; boundary=abcde12345',
        'Authorization': `Bearer ${token}`,

    }
    let res;
    try {
        res = await axios.delete(url, { headers: headers });
    } catch (ex) {
        console.log(ex);
    }
    return res.status;
}
