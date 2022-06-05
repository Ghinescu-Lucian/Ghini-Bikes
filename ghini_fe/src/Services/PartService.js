import axios from "axios";

const URL = 'https://localhost:7155/api/Part'


export async function GetPartById(id) {
    var URL2 = `${URL}/${id}`;
    let url = URL2;

     console.log("Options ",url);
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

export async function GetParts() {
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
export async function UpdatePart(id, data, token) {
    var url = `${URL}/${id}`;
    // console.log(token);
    const headers = {
        // Accept: "multipart/form-data",
        // 'Content-Type': 'multipart/form-data; boundary=abcde12345',
        'Authorization': `Bearer ${token}`,
    }

    // console.log(id);
    // console.log("URL:",url);
    console.log("UPDATE:",data.weight);
    var options = {
        productId: 0,
        type: "string",
        description: data.description,
        year: data.year,
        price: data.price,
        manufacturer: data.manufacturer,
        model: data.model,
        quantity: data.quantity,
        category: 0,
        warrantyMonths: data.warranty,
        specification: "string",
        weigth: data.weight
    };
    console.log(JSON.stringify(options));

    return fetch(url, {
        method: 'PUT',
        headers: {
            'Authorization': `Bearer ${token}`,
            'Content-Type': 'application/json',
            
        },
        body: JSON.stringify(
            options
        )
    })
        // .then(res => res.json())
        .then(function (response) {
            return response.status;
        })
        .catch(function (err) {
            console.log(err, "eorrr");
            // alert("Username already exists12");
        });
    // return 200;
}


export async function AddPart(data,selected, token) {
    var URL2 = `${URL}/addPart`;
    let url = URL2;
    var type
    var img = `{
        id: 0,
        path: "string",
        position: 0,
        productId: 0
    }`


    // console.log("TOKEN: ", token);
    data.category=4;
    console.log("SELECTEED",selected);

    // console.log(_username,_password,_email);
    const formData = new FormData();
    
    formData.set('ProductId', 0);
    // formData.append('ProductId: ', 0);
    formData.append('Description', data.description);
    formData.append('Year', data.year);
    formData.append('price', data.price);
    formData.append('Manufacturer', data.manufacturer);
    formData.append('Model', data.model);
    formData.append('Images', img);
    formData.append('ImagesURL', data.file);
    formData.append('quantity', data.quantity);
    formData.append('category', data.category);
    for(let i=0 ; i< selected.length; i++){
        console.log(`Compatibilities[${i}]`,selected[0]);
        formData.append(`Compatibilities[${i}]`,selected[i]);
    }
    // formData.append("Compatibilities[0]", selected[0]);
    // formData.append("Compatibilities[1]", selected[1]);
    // formData.append("Compatibilities[2]", selected[2]);
    


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

export async function DeletePart(id, token) {
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
