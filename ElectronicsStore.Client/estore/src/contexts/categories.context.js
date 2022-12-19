import { createContext, useState, useEffect } from 'react';
import { get } from '../utils/fetch';

export const CategoriesContext = createContext({
  categoriesMap: {},
  changedProducts: [],
  hasItems: false,
  changeCategory: () => {},
});
export const CategoriesProvider = ({ children }) => {
  const [categoriesMap, setCategoriesMap] = useState({});
  const [changedProducts, setChangedProducts] = useState([]);
  const [hasItems, setHasItems] = useState(false);
  let endpoint = 'category';
  let paramsObj = '';
  useEffect(() => {
    const getCategoriesMap = async () => {
      const categoryMap = await get(endpoint, paramsObj);
      setCategoriesMap(categoryMap);
    };
    getCategoriesMap();
  }, []);

  async function changeCategory(e) {
    const fetchedData = await get('product', e);
    setChangedProducts(fetchedData);
    setHasItems(true);
  }

  const value = { categoriesMap, changeCategory, hasItems, changedProducts };
  return (
    <CategoriesContext.Provider value={value}>
      {children}
    </CategoriesContext.Provider>
  );
};
