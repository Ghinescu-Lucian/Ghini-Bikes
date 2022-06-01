import React, { useState, useEffect } from "react";
import "../Components/CSS/Cart.css";
import { useNavigate } from "react-router-dom";
import { set, useForm } from "react-hook-form";



const Cart = ({ cart, setCart, handleChange }) => {
  const [price, setPrice] = useState(0);

  const navigate = useNavigate();
  const { register, handleSubmit, reset, formState: { errors }, watch } = useForm();

  const handleRemove = (id) => {
    const arr = cart.filter((item) => item.productId !== id);
    // arr.totalPrice = price;
    setCart(arr);
    handlePrice();
    localStorage.setItem('totalPrice',price);

  };

  const handlePrice = () => {
    let ans = 0;
    cart.map((item) => (
      // console.log(item.quantity)
      ans += item.amount * item.price)
    );
    setPrice(ans);
    localStorage.setItem('totalPrice',price);
  };

  useEffect(() => {
    handlePrice();
  });

  const placeOrder = () => {
    navigate("/Order",{price});
  }


  return (
    <article>
      {cart.map((item) => (
        <div className="cart_box" key={item.id}>
          <div className="cart_img">
            <img src={item.images ? item.images[0].path : item.image} alt="" />
            {item.manufacturer ? (<p>{item.manufacturer} {item.model} {item.year}</p>) : (<p>{item.name}</p>)}
          </div>
          <div>
            <button onClick={() => handleChange(item, 1)}>+</button>
            <button>{item.amount}</button>
            <button onClick={() => handleChange(item, -1)}>-</button>
          </div>
          <div>
            <span>{item.price}</span>
            <button onClick={() => handleRemove(item.productId)}>Remove</button>
          </div>
        </div>
      ))}
      <div className="total">
        <span>Total Price of your Cart</span>
        <span> {price} RON</span>
      </div>
      {
        price != 0 ? ( 
          <form onSubmit={handleSubmit(placeOrder)}>
        <button className="orderButton"> Place order</button>
        </form>
        ) :(<h1> Cart is empty</h1>)
        
      }
    </article>
  );
};

export default Cart;