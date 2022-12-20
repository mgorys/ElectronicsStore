import React from 'react';
import { useContext, useState, useEffect } from 'react';
import { CategoriesContext } from './contexts/categories.context';
import { ProductsContext } from './contexts/products.context';
import ProductItem from './ProductItem';
import Categories from './Categories';
import Pagination from './Pagination';

const Shop = () => {
  const { categoriesMap, hasItems, changedProducts, choosenCategory } =
    useContext(CategoriesContext);
  const { products } = useContext(ProductsContext);
  const [productsList, setProductsList] = useState();
  const [categories, setCategories] = useState(categoriesMap);
  const { dataFromServer } = changedProducts;

  useEffect(() => {
    setCategories(categoriesMap);
  }, [categoriesMap]);

  useEffect(() => {
    setProductsList(changedProducts);
    if (changedProducts === undefined) {
      setProductsList(products);
    }
  }, [changedProducts]);

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
          <div>Choose category to see items</div>
        )}
        {hasItems && Array.isArray(dataFromServer) && (
          <Pagination
            category={choosenCategory}
            pagesCount={changedProducts.pagesCount}
          />
        )}
      </div>
    </>
  );
};

export default Shop;
