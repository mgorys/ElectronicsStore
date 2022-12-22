import { useContext, useState } from 'react';
import { CartContext } from './contexts/cart.context';
import React from 'react';
import CheckoutItem from './CheckoutItem';
import { UserContext } from './contexts/user.context';
import Button from './button.component';
import { Link } from 'react-router-dom';
import { postPurchase } from './utils/fetch';

const Checkout = () => {
  const { cartItems, cartTotal } = useContext(CartContext);
  const { currentUser, token } = useContext(UserContext);
  const handleSubmitPurchase = () => {
    const cartValue = postPurchase(cartItems, token);
  };

  return (
    <>
      <table className="checkout-container">
        <thead className="checkout-header">
          <tr>
            <th className="header-block">Product</th>
            <th className="header-block">Quantity</th>
            <th className="header-block">Price</th>
            <th className="header-block">Remove</th>
          </tr>
        </thead>
        <tbody>
          {Array.isArray(cartItems) &&
            cartItems.map((cartItem) => (
              <tr key={cartItem.id}>
                <CheckoutItem cartItem={cartItem} />
              </tr>
            ))}
        </tbody>
      </table>
      <span className="total">Total: ${cartTotal.toFixed(2)}</span>
      {currentUser ? (
        <Button onClick={handleSubmitPurchase}>Purchase</Button>
      ) : (
        <Link to="/auth">
          <Button>Log In to Continue</Button>
        </Link>
      )}
    </>
  );
};

export default Checkout;
