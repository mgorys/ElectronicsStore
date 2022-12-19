import React, { useState } from 'react';
import { useContext, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { ProductsContext } from './contexts/products.context';
import { CartContext } from './contexts/cart.context';
import Button from './button.component';

const ProductDetails = () => {
  const { name } = useParams();
  const { product, fetchProduct } = useContext(ProductsContext);
  const { price, brandName } = product;
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
        <div>
          <h2>{product.name}</h2>
          <h2>{price}</h2>
          <h2>{brandName}</h2>
          <Button onClick={addProductToCart}>Add to cart</Button>
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
