import React, { useContext } from 'react';
import { CartContext } from '../contexts/cart.context';
import Button from '../button.component';

const CheckoutItem = ({ cartItem }) => {
  const { name, price, quantity } = cartItem;
  const { clearItemFromCart } = useContext(CartContext);
  const clearItemHandler = () => clearItemFromCart(cartItem);
  return (
    <>
      <h2 className="checkoutitem-name">{name}</h2>
      <h2 className="checkoutitem-quantity">{quantity}</h2>
      <h2 className="checkoutitem-price">{price}PLN</h2>
      <div onClick={clearItemHandler}>
        <Button buttonType="classic">Remove</Button>
      </div>
    </>
  );
};

export default CheckoutItem;
