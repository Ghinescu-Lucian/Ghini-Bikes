import { Greeter } from '../Classes/Greeter';
import UserProfile from '../Classes/UserProfile'
import { PlaceOrderForm } from '../Components/PlaceOrderForm';

const PlaceOrder = ({cart,setCart}) => {

    return (
    <div>
        {/* <h2> {greeter.greet(UserProfile.getName())}</h2> */}
        <PlaceOrderForm cart1={cart} setCart1={setCart}/>
    </div>

    );
}
export default PlaceOrder;