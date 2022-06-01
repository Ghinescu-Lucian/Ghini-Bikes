import { ContactlessOutlined } from "@material-ui/icons";

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
    console.log(dataDelivery, productsData);
    console.log("A:LKLPDKPAKdp");

    var itemsOptions = "[";
    productsData.map((item) => {
        var opt = {
            id: item.productId,
            productId: item.productId,
            orderId: 0,
            category: item.category,
            discount: 0,
            quantity: item.amount
        }
        var opt1 = JSON.stringify(opt);
        itemsOptions = itemsOptions + opt1 + ',';
        
    });
    itemsOptions=itemsOptions.slice(0,-1);
    itemsOptions = itemsOptions + "]";
    console.log("ITEMS:",itemsOptions);
    var itms = JSON.parse(itemsOptions);
    console.log("A:LKLPDKPAKdp");
    console.log (itms);
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
    // console.log("Options",options);
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
                alert("Username or Email already exists!");
            }
            return response.json();
        })
        .catch(function (err) {
            console.log(err, "eorrr");
            // alert("Username already exists12");
        });
}
