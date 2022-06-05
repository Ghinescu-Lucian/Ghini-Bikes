import './App.css';
import { Greeter } from './Classes/Greeter';
import { useToggle } from './Components/CunstomHook';
import { useContext, useEffect, useState } from 'react';
import { ColorContext } from './Components/UseContext';
import { Route, Link, Routes } from "react-router-dom";
import Welcome from './Pages/HomePage';
import Nav from './Components/Nav';
import Bikes from './Pages/Bikes';
import PlaceOrder from './Pages/PlaceOrder';
import Orders from './Pages/Orders';
import AddProducts from './Pages/AddProducts';
import { Logo } from './Components/Logo';
import Parts from './Pages/Parts';
import Cart from './Pages/Cart';
import Accessories from './Pages/Accessories';
import Promotions from './Pages/Promotions';
import LogIn from './Pages/LogIn';
import SignUp from './Pages/SignUp';
import UserProfile from './Classes/UserProfile'
import Profile from './Pages/Profile';
import { useNavigate } from "react-router-dom";
import { couldStartTrivia } from 'typescript';

// import SearchBox from './Components/SearchBox.jsx';


function App() {


  const [userName, setUsername] = useState("there");

  const navigate = useNavigate();

  let greeter = new Greeter(UserProfile.getName());
  const [isVisible, toggleVisible] = useToggle(false)
  const colors = useContext(ColorContext);

  let ok = null;

  const [cart, setCart] = useState(localStorage.getItem("cart") ? JSON.parse(localStorage.getItem("cart")) : []);
  const [size, setSize] = useState(0);

  var count = document.querySelectorAll('.size');

  const handleClick = (item) => {
    for (var index = 0; index < cart.length; index++) {
      if (cart[index].productId == item.productId) {
        alert("Product already added!");
        return;
      }
    }
    item.amount = 1;
    setCart([...cart, item]);

  };

  const handleChange = (item, d) => {
    const ind = cart.indexOf(item);
    const arr = cart;
    if (arr[ind].amount === undefined)
      arr[ind].amount = 0;
    arr[ind].amount += d;
    if (arr[ind].amount > arr[ind].quantity) {
      arr[ind].amount = arr[ind].quantity;
      alert("Maximum available products");
    }
    if (arr[ind].amount === 0) arr[ind].amount = 1;
    setCart([...arr]);

  };

  const handleLogout = () => {
    localStorage.clear();
    setUsername(usr => "there");

  }

  if (localStorage.getItem("user")) {
    var Username = JSON.parse(window.localStorage.getItem('user'));

  }
  else {
    console.log("Error local storage");
  }


  useEffect(() => {
    setUsername(usr => localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user")).username : "user");
  }, [localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user")).username : "user"]
  );

  useEffect(() => {
    // var siz = JSON.parse(localStorage.getItem("cart")).length + 1;
    var res = JSON.stringify(cart)
    localStorage.setItem('cart', res);
    setSize(cart.length);
    count.values= 0;
  }, [cart]);

  return (

    <>
      <Nav size={cart.length} />
      <div className="App">
        <Routes>
          <Route path="/" element={
            <header className="App-header">
              <div className='logoBox'>
                <Logo />
              </div>
              {/* {
                if()
              } */}
              <h1 style={{ color: colors.black }}>{

                greeter.greet(
                  userName)
                //  ? Username.username:"user")
              }</h1>
              <h2>

                Welcome to Ghini-Bikes!

              </h2>
              <div>
                <button onClick={handleLogout}>LogOut</button>
              </div>
            </header>} />

          <Route path="/home" element={<Welcome />} />
          <Route path="/place_order" element={<PlaceOrder cart={cart} setCart={setCart} />} />
          <Route path="/profile" element={<Profile />} />
          <Route path="/bikes" element={<Bikes handleClick={handleClick} />}></Route>
          <Route path="/parts" element={<Parts handleClick={handleClick} />}></Route>
          <Route path="/accessories" element={<Accessories handleClick={handleClick} />}></Route>
          <Route path="/promotions" element={<Promotions handleClick={handleClick} />}></Route>
          <Route path="/LogIn" element={<LogIn />}></Route>
          <Route path="/SignUp" element={<SignUp />}></Route>
          <Route path="/cart" element={<Cart cart={cart} setCart={setCart} handleChange={handleChange} />}></Route>
          <Route path="/AddProducts" element={<AddProducts />}></Route>
          <Route path="/orders" element={<Orders/>}></Route>
        </Routes>
      </div>

    </>
  );
}

export default App;
function useFetch(arg0) {
  throw new Error('Function not implemented.');
}

