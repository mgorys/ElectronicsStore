import { createContext, useState, useEffect } from 'react';
import { get } from '../utils/fetch';

export const ProductsContext = createContext({
  product: {},
});
export const ProductsProvider = ({ children }) => {
  const [products, setProducts] = useState([]);
  const endpoint = 'product';
  const category = 'phones';

  // useEffect(() => {
  //   const getProducts = async () => {
  //     const products = await get(endpoint, category);
  //     setProducts(products);
  //   };
  //   getProducts();
  // }, [category]);

  const value = { products };
  return (
    <ProductsContext.Provider value={value}>
      {children}
    </ProductsContext.Provider>
  );
};
