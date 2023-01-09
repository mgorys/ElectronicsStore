import { createContext, useState, useEffect } from 'react';
import { get } from '../utils/fetch';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

export const CategoriesContext = createContext({
  changedProducts: [],
  hasItems: false,
  categories: {},
  query: {},
  currentCategory: {},
  getProductsWithCategory: () => {},
  getCategories: () => {},
  setQuery: () => {},
});
export const CategoriesProvider = ({ children }) => {
  const [categories, setCategories] = useState({});
  const [changedProducts, setChangedProducts] = useState([]);
  const [hasItems, setHasItems] = useState(false);
  const [currentCategory, setCurrentCategory] = useState(null);
  const [query, setQuery] = useState(null);
  let endpoint = 'product';
  let paramsObj = undefined;
  const defaultQuery = {
    search: null,
    page: null,
    sortDirection: null,
  };

  async function getCategories(e) {
    const fetchedData = await get('category', paramsObj);
    setCategories(fetchedData);
    setQuery(defaultQuery);
  }
  async function getProductsWithCategory(paramsObj, f) {
    const fetchedData = await get(endpoint, paramsObj, f);
    if (fetchedData.status >= 400)
      toast.error(`Something went wrong`, { displayDuration: 3000 });
    else {
      setChangedProducts(fetchedData);
      setCurrentCategory(paramsObj);
      setQuery(f);
      setHasItems(true);
    }
  }

  const value = {
    changedProducts,
    hasItems,
    categories,
    query,
    currentCategory,
    getProductsWithCategory,
    getCategories,
    setQuery,
  };
  return (
    <CategoriesContext.Provider value={value}>
      <ToastContainer />
      {children}
    </CategoriesContext.Provider>
  );
};
