import { Greeter } from '../Classes/Greeter';
import UserProfile from '../Classes/UserProfile'
import { PlaceOrderForm } from '../Components/PlaceOrderForm';

const Order = () => {
    UserProfile.setName("user!");
    let greeter = new Greeter(UserProfile.getName());
    return (
    <div>
        <div>About component</div>
        <h2> {greeter.greet(UserProfile.getName())}</h2>
        <PlaceOrderForm/>
    </div>

    );
}
export default Order;