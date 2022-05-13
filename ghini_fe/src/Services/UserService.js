const URL = 'https://localhost:7155/api/User'
export async function Login(_username, _password) {
    var URL2 = `${URL}/1`;
    let url = URL2;

    var options = {
        id: 0,
        password: _password, 
        email: "string",
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
            if(response.status != 200){
                console.log("Wrong username or password!");
            }
            return response.json();
        })
        .catch(function(err){
            //  console.log(err,"eorrr");
            alert("Wrong credentials");
        });


}