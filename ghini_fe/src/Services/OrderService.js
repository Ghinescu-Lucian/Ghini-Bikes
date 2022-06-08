import { ContactlessOutlined, DnsTwoTone } from "@material-ui/icons";

const URL = 'https://localhost:7155/api/Order'

export async function GetOrderById(id) {
    var URL2 = `${URL}/${id}`;
    let url = URL2;

    console.log("Options ", url);
    return fetch(url, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        // .then(res => res.json())
        .then(function (response) {
            if (response.status !== 200) {
                console.log("Wrong username or password!");
            }
            return response.json();
        })
        .catch(function (err) {
            //  console.log(err,"eorrr");
            alert("Wrong credentials");
        });
}

export async function GetOrdersByUsername(userId) {
    var URL2 = `${URL}/user/${userId}`;
    let url = URL2;

    // console.log("Options ", url);
    return fetch(url, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        // .then(res => res.json())
        .then(function (response) {
            if (response.status !== 200) {
                console.log("Wrong username or password!");
            }
            return response.json();
        })
        .catch(function (err) {
            //  console.log(err,"eorrr");
            alert("Wrong credentials");
        });
}

export async function GetOrders() {
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


export async function placeOrder(dataDelivery, productsData, userData) {
    var URL2 = `${URL}`;
    let url = URL2;
    // console.log(dataDelivery, productsData);
    // console.log("A:LKLPDKPAKdp");
    if(!userData){
        alert("Must be logged in!");
        return ;
    }
    var itemsOptions = "[";
    productsData.map((item) => {
        var opt = {
            id: item.productId,
            productId: item.productId,
            orderId: 0,
            category: item.category,
            discount: 0,
            year: item.year,
            price: item.price,
            manufacturer: item.manufacturer,
            model: item.model,
            image: item.images[0].path,
            quantity: item.amount,
            description: item.description


        }
        var opt1 = JSON.stringify(opt);
        itemsOptions = itemsOptions + opt1 + ',';
        
    });
    itemsOptions=itemsOptions.slice(0,-1);
    itemsOptions = itemsOptions + "]";
    // console.log("ITEMS:",itemsOptions);
    var itms = JSON.parse(itemsOptions);
    // console.log("A:LKLPDKPAKdp");
    // console.log (itms);
    var options = {
        id: 0,
        items: itms,
        // date: Date(),
        totalCost: 0,
        finalCost: 0,
        user: {
            id: userData.id,
            password: "string",
            email: "string",
            username: "Luky",
            role: "string"
        },
        telephoneNr: dataDelivery.telephone,
        address: dataDelivery.address,
        pay: 0,
        status: 1,
        name: dataDelivery.name

    };
    //     id: 0,
    //     password: _password, 
    //     email: _email,
    //     username: _username,
    //     role: "string"
    // };
    console.log("Options",options);
    // return 200;
    return fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(
            options
        )
    })
        // .then(res => res.json())
        .then(function (response) {
            if (response.status !== 201) {
                // console.log("Username or Email already exists!");
                alert("An error occurred!");
            }
            console.log(response.json);
            return response.json();
        })
        .catch(function (err) {
            console.log(err, "error");
            // alert("Username already exists12");
        });
}

export async function UpdateOrder(data, token) {

    let id = data.id;
    data.id = parseInt(data.id);
    data.status = parseInt(data.status);
    

    var url = `${URL}/${id}`;
    // console.log(token);
    const headers = {
        // Accept: "multipart/form-data",
        // 'Content-Type': 'multipart/form-data; boundary=abcde12345',
        'Authorization': `Bearer ${token}`,
    }

    // console.log(id);
    console.log("URL:",url);
    var options = {
      id: id,
      status: data.status,
      message: data.message
    };
    console.log(JSON.stringify(
        options
    ));
    // return 200;
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
