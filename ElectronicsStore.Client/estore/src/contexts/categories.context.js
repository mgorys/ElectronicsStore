import { createContext, useState, useEffect } from 'react';
import { get } from '../utils/fetch';

export const CategoriesContext = createContext({
  categoriesMap: {},
});
export const CategoriesProvider = ({ children }) => {
  const [categoriesMap, setCategoriesMap] = useState({});
  const endpoint = 'category';
  const paramsObj = '';
  useEffect(() => {
    const getCategoriesMap = async () => {
      const categoryMap = await get(endpoint, paramsObj);
      setCategoriesMap(categoryMap);
    };
    getCategoriesMap();
  }, []);

  const value = { categoriesMap };
  return (
    <CategoriesContext.Provider value={value}>
      {children}
    </CategoriesContext.Provider>
  );
};
