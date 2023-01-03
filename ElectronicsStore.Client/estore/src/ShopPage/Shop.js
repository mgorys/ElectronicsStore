import React from 'react';
import { useContext, useEffect } from 'react';
import { CategoriesContext } from '../contexts/categories.context';
import ProductItem from './ProductItem';
import Categories from './Categories';
import Pagination from './Pagination';
import './Shop.scss';

const Shop = () => {
  const {
    categories,
    hasItems,
    changedProducts,
    choosenCategory,
    searchProces,
    getCategories,
  } = useContext(CategoriesContext);
  const { dataFromServer } = changedProducts;

  const { changeCategory } = useContext(CategoriesContext);
  const changeCategoryHandler = (e) => {
    changeCategory(e);
  };

  useEffect(() => {
    async function fetchData() {
      await getCategories();
    }
    fetchData();
  }, []);

  return (
    <>
      <div className="category-container">
        <Categories categories={categories} />
      </div>
      <div className="productlist-container">
        {hasItems && Array.isArray(dataFromServer) ? (
          dataFromServer.map((product) => (
            <ProductItem product={product} key={product.id} />
          ))
        ) : (
          <div className="category-images-container">
            <div
              className="category-background-phones"
              value="Phones"
              onClick={(e) => changeCategoryHandler(e.target.innerText)}>
              <div className="category-transbox">
                <h1 className="category-title">Phones</h1>
              </div>
            </div>
            <div
              className="category-background-devices"
              value="Devices"
              onClick={(e) => changeCategoryHandler(e.target.innerText)}>
              <div className="category-transbox">
                <h1 className="category-title">Devices</h1>
              </div>
            </div>
            <div
              className="category-background-accessories"
              value="Accessories"
              onClick={(e) => changeCategoryHandler(e.target.innerText)}>
              <div className="category-transbox">
                <h1 className="category-title">Accessories</h1>
              </div>
            </div>
          </div>
        )}
        {hasItems && Array.isArray(dataFromServer) && (
          <Pagination
            searchProces={searchProces}
            category={choosenCategory}
            pagesCount={changedProducts.pagesCount}
          />
        )}
      </div>
    </>
  );
};

export default Shop;
