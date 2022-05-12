import logo from './logo.svg';
import './App.css';
import { Greeter } from './Classes/Greeter';
import { useToggle } from './Components/CunstomHook';
import { useContext, useEffect } from 'react';
import { ColorContext } from './Components/UseContext';
import {BrowserRouter, Route, Link, Routes} from "react-router-dom";
import Welcome from './Pages/HomePage';
import Nav from './Components/Nav';
import Bikes from './Pages/Bikes';
import { Logo } from './Components/Logo';
import Parts from './Pages/Parts';
import Accessories from './Pages/Accessories';
import Promotions from './Pages/Promotions';

const sendHttpRequest = (url: RequestInfo, method: any, payload?: any) => {
  return fetch(url, {
    method: method,
    body: JSON.stringify(payload)
  })
}

/*const promise = new Promise((resolve, reject) => {
  console.log("Promise started!");
  setTimeout(() => {
    // reject("Done!")
    resolve("Done!")
  }, 3000)
})
// console.log(promise);
// promise.then(response => console.log(response));
 Promise.race(
  [
    sendHttpRequest("https://jsonplaceholder.typicode.com/posts", "GET"),
    sendHttpRequest("https://jsonplaceholder.typicode.com/users", "GET"),
  ]).then(response => console.log(response));*/
const sendHttpRequestAsyncAwait = async (url: RequestInfo, method: any, payload?: any) => {
  const response = await fetch(url, {
    method: method,
    body: JSON.stringify(payload)
  })
    // .then(response => response.json())
    console.log(response);
}


function App() {

  /*sendHttpRequest("https://jsonplaceholder.typicode.com/posts","GET")
  .then(response => console.log(response.json()));
  //.then(result => console.log(result));

  sendHttpRequest("https://jsonplaceholder.typicode.com/posts","POST",{
      userId : Math.random(),
      title: "somePost",
      id: Math.random()
  })
  .then( result => console.log(result));
*/

 /* useEffect(() => {
    (async () => {
      await sendHttpRequestAsyncAwait("https://jsonplaceholder.typicode.com/posts","GET")
    }) ();
  }, []);
*/
  let greeter = new Greeter("Admin!");
  const [isVisible, toggleVisible] = useToggle(false)
  const colors = useContext(ColorContext);

  return (
    <>
    <Nav/>
    {/* <CounterButton /> */}
      {/* <hr></hr> */}
      {/* <RefHook /> */}
      <div className="App">
      <Routes> 
        <Route path="/" element={
            <header className="App-header">
              <Logo/>
              <h1 style={{ color: colors.blue }}>{greeter.greet()}</h1>
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
          <Route path="/welcome" element = { <Welcome/>}/>
          <Route path="/bikes" element = { <Bikes/>}></Route>
          <Route path="/parts" element = { <Parts/>}></Route>
          <Route path="/accessories" element = { <Accessories/>}></Route>
          <Route path="/promotions" element = { <Promotions/>}></Route>

        </Routes>
      </div>
    
      </>
  );
}

export default App;
function useFetch(arg0: string) {
  throw new Error('Function not implemented.');
}

