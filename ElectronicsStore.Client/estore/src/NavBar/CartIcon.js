import React, { useContext } from 'react';
import { CartContext } from '../contexts/cart.context';
import { FaShoppingBasket } from 'react-icons/fa';
import './CartIcon.scss';

const CartIcon = () => {
  const { cartCount } = useContext(CartContext);
  return (
    <div className="cart-container">
      <span className="cart-counter">{cartCount}</span>
      <FaShoppingBasket className="shoppingbag-icon" />
    </div>
  );
};

export default CartIcon;
