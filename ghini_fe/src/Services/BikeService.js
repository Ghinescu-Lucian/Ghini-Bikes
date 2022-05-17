const URL = 'https://localhost:7155/api/Bike'

export async function GetBikeById(id) {
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
