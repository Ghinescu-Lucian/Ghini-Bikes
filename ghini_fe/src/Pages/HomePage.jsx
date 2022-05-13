import '../App.css';
import { Greeter } from '../Classes/Greeter';
import { useToggle } from '../Components/CunstomHook';
import { useContext, useEffect,useState } from 'react';
import { ColorContext } from '../Components/UseContext';
import { Route, Link, Routes} from "react-router-dom";
import Nav from '../Components/Nav';
import Bikes from './Bikes';
import { Logo } from '../Components/Logo';
import Parts from './Parts';
import Accessories from './Accessories';
import Promotions from './Promotions';
import LogIn from './LogIn';
import SignUp from './SignUp';
import UserProfile from '../Classes/UserProfile'


function App() {
  UserProfile.setName("user!");

  let greeter = new Greeter(UserProfile.getName());
  const [isVisible, toggleVisible] = useToggle(false)
  const colors = useContext(ColorContext);

  console.log(UserProfile.getName(),"NAMEUL");

  return (
    <>
    {/* <Nav/> */}
      <div className="App">
      <Routes> 
        <Route path="/" element={
            <header className="App-header">
              <div className='logoBox'>
                <Logo/>
              </div>
              
              <h1 style={{ color: colors.black }}>{greeter.greet(UserProfile.getName())}</h1>
              <h2>

              {/* <img src="./Images/GhiniBikeLogo.jpg" /> */}
                Welcome to Ghini-Bikes!
                {/* <br> */}
                {/* </br> */}

                {/* Every passionate should know about     it  */}
              </h2>
              {/* <button onClick={toggleVisible} style={{ background: colors.grey, color: colors.yellow }}>Hello</button> */}
              {/* {isVisible && <div>World</div>} */}
            </header>}/>
          {/* <Route path="/welcome" element = { <Welcome/>}/> */}
          <Route path="/bikes" element = { <Bikes/>}></Route>
          <Route path="/parts" element = { <Parts/>}></Route>
          <Route path="/accessories" element = { <Accessories/>}></Route>
          <Route path="/promotions" element = { <Promotions/>}></Route>
          <Route path="/LogIn" element = { <LogIn/>}></Route>
          <Route path="/SignUp" element = { <SignUp/>}></Route>
        </Routes>
      </div>
    
      </>
  );
}

export default App;
function useFetch(arg0) {
  throw new Error('Function not implemented.');
}

