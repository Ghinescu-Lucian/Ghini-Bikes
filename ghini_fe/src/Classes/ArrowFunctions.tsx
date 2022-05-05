import { stringify } from "querystring";
import { Product } from "./Product";

let userArrow = {
    username : "Admin",
    password : "1234321",
    authenticate: function(thePassword:string){
        return () =>
        {
          console.log(this);
          console.log(thePassword);
            let ok : boolean ;
            ok = false;
            if( this.password === thePassword)
                ok = true;
            console.log(ok);
        }
    }
}

let user = userArrow.authenticate("1234321");
user();

