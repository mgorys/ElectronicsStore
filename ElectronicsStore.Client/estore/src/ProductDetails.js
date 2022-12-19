import React from 'react';
import { useContext } from 'react';
import { ProductsContext } from './contexts/products.context';

const ProductDetails = () => {
  const { product } = useContext(ProductsContext);
  return <div>{product}</div>;
};

export default ProductDetails;
