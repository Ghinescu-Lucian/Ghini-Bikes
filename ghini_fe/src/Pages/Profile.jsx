import { Greeter } from '../Classes/Greeter';
import { useEffect, useState } from "react"
import * as orderService from '../Services/OrderService.js';
import OrdersHistory from '../Components/OrdersHistory';
import UserProfile from '../Classes/UserProfile'

const Profile = () => {

    const [orders, setOrders] = useState([]);
    const [userName, setUsername] = useState("there");

    useEffect(() => {
        setUsername(usr => localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user")).username : "user");
      }, [localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user")).username : "user"]
      );
    

    const ordersGet = async () => {
        var id =JSON.parse(localStorage.getItem("user")).id ;
        const response = await orderService.GetOrdersByUsername(id);
        setOrders(response);
        
    }
    useEffect(() => {
        ordersGet();
    }, []);

console.log(userName);
// console.log(orders);
    return (
    <div>
        <h1>Hello {userName} !</h1>

        <h2>Your orders</h2>
        <OrdersHistory rws={orders}/>
    </div>

    );
    UserProfile.setName("user!");
    let greeter = new Greeter(UserProfile.getName());
    return (
    <div>
        <div>About component</div>
        <h2> {greeter.greet(UserProfile.getName())}</h2>
    </div>

    );
}
export default Profile;