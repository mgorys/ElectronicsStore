import React from 'react';
import { useContext } from 'react';
import { CartContext } from './contexts/cart.context';
import Button from './button.component';
import './ProductItem.scss';

const ProductItem = ({ product }) => {
  const { addItemToCart } = useContext(CartContext);
  const { id, name, price } = product;
  const addProductToCart = () => addItemToCart(product);
  return (
    <div key={id} className="productitem-container">
      <h2>{name}</h2>
      <h2 className="productitem-price">{price}</h2>
      <Button onClick={addProductToCart}>Add to cart</Button>
    </div>
  );
};

export default ProductItem;
