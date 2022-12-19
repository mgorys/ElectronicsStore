import React from 'react';
import { useContext } from 'react';
import { CartContext } from './contexts/cart.context';
import Button from './button.component';
import './ProductItem.scss';
import { Link } from 'react-router-dom';

const ProductItem = ({ product }) => {
  const { addItemToCart } = useContext(CartContext);
  const { id, name, price } = product;
  const addProductToCart = () => addItemToCart(product);
  return (
    <>
      <div key={id} className="productitem-container">
        <Link to="/product">
          <h2>{name}</h2>
        </Link>
        <h2 className="productitem-price">{price}</h2>
        <Button onClick={addProductToCart}>Add to cart</Button>
      </div>
    </>
  );
};

export default ProductItem;
