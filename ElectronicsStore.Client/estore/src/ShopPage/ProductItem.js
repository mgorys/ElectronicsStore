import React from 'react';
import { useContext } from 'react';
import { CartContext } from '../contexts/cart.context';
import Button from '../button.component';
import './ProductItem.scss';
import { Link } from 'react-router-dom';

const ProductItem = ({ product }) => {
  const { addItemToCart } = useContext(CartContext);
  const { id, name, price, imgUrl } = product;
  const addProductToCart = () => addItemToCart(product);
  const defaultImg =
    'https://www.vodafone.com.au/images/devices/apple/iphone-14-plus/iphone-14-plus-blue-feature1-m.jpg';
  return (
    <>
      <div key={id} className="productitem-container">
        <Link to={`/product/${name}`}>
          {imgUrl !== null ? (
            <img src={imgUrl} className="productitem-image" />
          ) : (
            <img src={defaultImg} className="productitem-image" />
          )}
        </Link>
        <Link to={`/product/${name}`} className="productitem-name">
          <h2>{name}</h2>
        </Link>
        <h2 className="productitem-price">{price}PLN</h2>
        <Button buttonType="classic" onClick={addProductToCart}>
          Add to cart
        </Button>
      </div>
    </>
  );
};

export default ProductItem;
