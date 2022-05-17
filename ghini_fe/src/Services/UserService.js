const URL = 'https://localhost:7155/api/User' 

//LogIn
export async function Login(_username, _password) {
    var URL2 = `${URL}/login/1`;
    let url = URL2;

    var options = {
        id: 0,
        password: _password, 
        email: "string",
        username: _username,
        role: "string"
    };
    console.log("Options",options);
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

export async function Register(_username,_password,_email){
    var URL2 = `${URL}`;
    let url = URL2;
    console.log(_username,_password,_email);
    var options = {
        id: 0,
        password: _password, 
        email: _email,
        username: _username,
        role: "string"
    };
    // console.log("Options",options);
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
        .then(function(response){
            if(response.status !== 201){
                // console.log("Username or Email already exists!");
                alert("Username or Email already exists!");
            }
            return response.json();
        })
        .catch(function(err){
             console.log(err,"eorrr");
            // alert("Username already exists12");
        });
}