import { useContext, useState } from 'react';
import { CartContext } from './contexts/cart.context';
import React from 'react';
import CheckoutItem from './CheckoutItem';

const Checkout = () => {
  const { cartItems, cartTotal } = useContext(CartContext);

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
      <span className="total">Total: ${cartTotal}</span>
    </>
  );
};

export default Checkout;
