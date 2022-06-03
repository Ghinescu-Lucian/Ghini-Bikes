import { Greeter } from '../Classes/Greeter';
import UserProfile from '../Classes/UserProfile'
import { PlaceOrderForm } from '../Components/PlaceOrderForm';
import * as orderService from '../Services/OrderService.js';
import { useState, useEffect } from 'react';
import CollapsibleTable from '../Components/CollapsibleTable';



const Orders = () => {

    const [orders, setOrders] = useState([]);

    const ordersGet = async () => {
        const response = await orderService.GetOrders();
        setOrders(response);
        
    }
    useEffect(() => {
        ordersGet();
    }, []);

    console.log(orders);

    return (
    <div>
        <CollapsibleTable rws={orders}/>
    </div>

    );
}
export default Orders;