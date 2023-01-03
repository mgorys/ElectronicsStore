import { createContext, useState, useEffect } from 'react';
import { get } from '../utils/fetch';

export const CategoriesContext = createContext({
  changedProducts: [],
  hasItems: false,
  changeCategory: () => {},
  changeCategoryWithPage: () => {},
  choosenCategory: {},
  searchProducts: () => {},
  searchProductsWithpage: () => {},
  searchProces: false,
  searchRequest: {},
  getCategories: () => {},
  categories: {},
});
export const CategoriesProvider = ({ children }) => {
  const [categories, setCategories] = useState({});
  const [changedProducts, setChangedProducts] = useState([]);
  const [hasItems, setHasItems] = useState(false);
  const [searchProces, setSearchProces] = useState(false);
  const [searchRequest, setSearchRequest] = useState(null);
  const [choosenCategory, setChoosenCategory] = useState(null);
  let endpoint = 'category';
  let paramsObj = undefined;

  async function getCategories(e) {
    const fetchedData = await get(endpoint, paramsObj);
    setCategories(fetchedData);
    setSearchProces(false);
  }

  async function changeCategory(e) {
    const fetchedData = await get('product', e);
    setChangedProducts(fetchedData);
    setChoosenCategory(e);
    setHasItems(true);
    setSearchProces(false);
  }
  async function changeCategoryWithPage(e, f) {
    const fetchedData = await get('product', e, f);
    setChangedProducts(fetchedData);
    setHasItems(true);
    setSearchProces(false);
  }

  async function searchProducts(e) {
    const fetchedData = await get('product/search', e);
    setChangedProducts(fetchedData);
    setSearchRequest(e);
    setHasItems(true);
    setSearchProces(true);
  }
  async function searchProductsWithpage(e, f) {
    const fetchedData = await get('product/search', e, f);
    setChangedProducts(fetchedData);
    setHasItems(true);
    setSearchProces(true);
  }

  const value = {
    changeCategory,
    hasItems,
    changedProducts,
    changeCategoryWithPage,
    choosenCategory,
    searchProducts,
    searchProces,
    searchRequest,
    searchProductsWithpage,
    getCategories,
    categories,
  };
  return (
    <CategoriesContext.Provider value={value}>
      {children}
    </CategoriesContext.Provider>
  );
};
