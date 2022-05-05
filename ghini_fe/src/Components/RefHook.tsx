import React, { useEffect, useRef, useState } from "react";

export function RefHook() {
    const inputRef = useRef<HTMLInputElement>(null);
    const intervalRef = useRef<number>();

    const rendered = useRef<number>(0);
    const [inputValue, setInputvalue] = useState<string | undefined>("");

    const onButtonClick = () => {
        console.log(inputRef.current);
        inputRef.current?.focus();
    };
    useEffect(() => {
        const id = window.setTimeout(() => { }, 1000);

        intervalRef.current = id;
        return () => {
            clearInterval(intervalRef.current)
        };

    },[]);

    useEffect(() =>{
        rendered.current = rendered.current +1;
    });
    const handleInputChange = () => {
        setInputvalue(inputRef.current?.value);
    }

    return (
        <div>
            <p>RefHook</p>
            <div>Rendered { rendered.current}{rendered.current === 1? "time" : "times"}</div>
            <div>Input length : {inputRef.current?.value.length}</div>
            <input ref={inputRef} type="text" onChange={handleInputChange} placeholder="input"></input>
            <button onClick={onButtonClick}>Focus the input</button>{ }
        </div>
    );
}