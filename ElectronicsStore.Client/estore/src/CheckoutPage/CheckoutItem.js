import React, { useContext } from 'react';
import { CartContext } from '../contexts/cart.context';
import Button from '../button.component';
import { Link } from 'react-router-dom';

const CheckoutItem = ({ cartItem }) => {
  const { name, price, quantity } = cartItem;
  const { clearItemFromCart, removeItemFromCart, addItemToCart } =
    useContext(CartContext);
  const clearItemHandler = () => clearItemFromCart(cartItem);
  const removeItemHandler = () => removeItemFromCart(cartItem);
  const addItemHandler = () => addItemToCart(cartItem);
  return (
    <>
      <Link to={`/product/${name}`} className="checkoutitem-name">
        <h2>{name}</h2>
      </Link>
      <h2 className="checkoutitem-quantity-container">
        <div className="checkoutitem-quantity-mark" onClick={removeItemHandler}>
          -
        </div>
        <div className="checkoutitem-quantity">{quantity}</div>
        <div className="checkoutitem-quantity-mark" onClick={addItemHandler}>
          +
        </div>
      </h2>
      <h2 className="checkoutitem-price">{price}PLN</h2>
      <div onClick={clearItemHandler}>
        <Button buttonType="classic">Remove</Button>
      </div>
    </>
  );
};

export default CheckoutItem;
