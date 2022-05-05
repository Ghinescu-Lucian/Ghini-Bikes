import React, { useState, useEffect } from "react";

export function CounterButton() {

    const [count, setCount] = useState(0);

    useEffect(() => {
        document.title = ` Quantity : ${count}`;
    }, [count]);

    return (
        <div>
            <p>
                Product added {count} {count ===1 ? "time": "times"};
            </p>
            <button onClick={ () => setCount(count +1)}>+</button>;
            <button onClick={ () => setCount(count -1)}>-</button>;
        </div>
    );
}