import { Greeter } from '../Classes/Greeter';
import UserProfile from '../Classes/UserProfile'

const Profile = () => {
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