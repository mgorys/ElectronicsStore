import { createContext, useState } from 'react';
import { get } from '../utils/fetch';

export const ProductsContext = createContext({
  product: {},
  fetchProduct: () => {},
});
export const ProductsProvider = ({ children }) => {
  const [product, setProduct] = useState({});

  async function fetchProduct(name) {
    const endpoint = 'product/getby';
    const fetchedData = await get(endpoint, name);
    setProduct(fetchedData);
  }

  const value = { product, fetchProduct };
  return (
    <ProductsContext.Provider value={value}>
      {children}
    </ProductsContext.Provider>
  );
};
