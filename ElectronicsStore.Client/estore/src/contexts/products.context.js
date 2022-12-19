import { createContext, useState, useEffect } from 'react';
import { get } from '../utils/fetch';
import { useParams } from 'react-router-dom';

export const ProductsContext = createContext({
  product: {},
  fetchProduct: () => {},
});
export const ProductsProvider = ({ children }) => {
  const { name } = useParams();
  const [product, setProduct] = useState({});
  const endpoint = 'product/getby';

  async function fetchProduct(name) {
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
