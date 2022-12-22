import React from 'react';
import { useContext, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { ProductsContext } from './contexts/products.context';
import { CartContext } from './contexts/cart.context';
import Button from './button.component';
import './ProductDetails.scss';

const ProductDetails = () => {
  const { name } = useParams();
  const { product, fetchProduct } = useContext(ProductsContext);
  const { price, brandName, description } = product;
  const { addItemToCart } = useContext(CartContext);
  const addProductToCart = () => addItemToCart(product);

  useEffect(() => {
    async function fetchData() {
      await fetchProduct(name);
    }
    fetchData();
  }, []);
  return (
    <>
      {product ? (
        <div className="productdetails-container">
          <h2>{product.name}</h2>
          <h3>{price}</h3>
          <h3>{brandName}</h3>
          <h3>{description}</h3>
          <Button buttonType="classic" onClick={addProductToCart}>
            Add to cart
          </Button>
        </div>
      ) : (
        <div>
          <h2>please wait</h2>
        </div>
      )}
    </>
  );
};

export default ProductDetails;
