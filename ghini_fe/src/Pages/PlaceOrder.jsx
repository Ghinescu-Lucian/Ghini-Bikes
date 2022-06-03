import { Greeter } from '../Classes/Greeter';
import UserProfile from '../Classes/UserProfile'
import { PlaceOrderForm } from '../Components/PlaceOrderForm';

const PlaceOrder = () => {
    return (
    <div>
        {/* <h2> {greeter.greet(UserProfile.getName())}</h2> */}
        <PlaceOrderForm/>
    </div>

    );
}
export default PlaceOrder;