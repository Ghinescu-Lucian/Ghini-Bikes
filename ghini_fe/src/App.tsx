import logo from './logo.svg';
import './App.css';
import { Greeter } from './Classes/Greeter';
import { CounterButton } from './Components/CounterButton';
import { RefHook } from './Components/RefHook';
import { useToggle } from './Components/CunstomHook';
import { useContext } from 'react';
import { ColorContext } from './Components/UseContext';

function App() {


  let greeter = new Greeter("Admin!");
  const [isVisible, toggleVisible] = useToggle(false)
  const colors = useContext(ColorContext);

  return (
    <>
      <CounterButton />
      <hr></hr>
      <RefHook />
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 style={{color: colors.blue}}>{greeter.greet()}</h1>
          <h2 style={{color: colors.green}}>
            Welcome to Ghini-Bikes!<br>
            </br>
           
            Every passionate should know about     it    </h2>
<button onClick={toggleVisible} style={{background:colors.grey, color: colors.yellow}}>Hello</button>
      {isVisible && <div>World</div>}
        </header>
        <body>
        
        </body>

      </div></>
  );
}

export default App;
function useFetch(arg0: string) {
  throw new Error('Function not implemented.');
}

