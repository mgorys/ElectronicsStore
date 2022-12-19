import React, { useContext } from 'react';
import { CartContext } from './contexts/cart.context';

const CheckoutItem = ({ cartItem }) => {
  const { name, price, quantity } = cartItem;
  const { clearItemFromCart } = useContext(CartContext);
  const clearItemHandler = () => clearItemFromCart(cartItem);
  return (
    <>
      <td>{name}</td>
      <td>{quantity}</td>
      <td>{price}</td>
      <td onClick={clearItemHandler}>X</td>
    </>
  );
};

export default CheckoutItem;
