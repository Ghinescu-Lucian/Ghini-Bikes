import './App.css';
import { Greeter } from './Classes/Greeter';
import { useToggle } from './Components/CunstomHook';
import { useContext, useEffect, useState } from 'react';
import { ColorContext } from './Components/UseContext';
import { Route, Link, Routes } from "react-router-dom";
import Welcome from './Pages/HomePage';
import Nav from './Components/Nav';
import Bikes from './Pages/Bikes';
import { Logo } from './Components/Logo';
import Parts from './Pages/Parts';
import Accessories from './Pages/Accessories';
import Promotions from './Pages/Promotions';
import LogIn from './Pages/LogIn';
import SignUp from './Pages/SignUp';
import UserProfile from './Classes/UserProfile'
import Profile from './Pages/Profile';
import { useNavigate } from "react-router-dom";

// import SearchBox from './Components/SearchBox.jsx';


function App() {


  const [userName, setUsername] = useState("there");
  const navigate = useNavigate();

  let greeter = new Greeter(UserProfile.getName());
  const [isVisible, toggleVisible] = useToggle(false)
  const colors = useContext(ColorContext);

  let ok = null;

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

  return (

    <>
      <Nav />
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
          <Route path="/profile" element={<Profile />} />
          <Route path="/bikes" element={<Bikes />}></Route>
          <Route path="/parts" element={<Parts />}></Route>
          <Route path="/accessories" element={<Accessories />}></Route>
          <Route path="/promotions" element={<Promotions />}></Route>
          <Route path="/LogIn" element={<LogIn />}></Route>
          <Route path="/SignUp" element={<SignUp />}></Route>
        </Routes>
      </div>

    </>
  );
}

export default App;
function useFetch(arg0) {
  throw new Error('Function not implemented.');
}

