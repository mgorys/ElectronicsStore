import React from 'react';
import { useContext, useState, useEffect } from 'react';
import { CategoriesContext } from './contexts/categories.context';
import Button from './button.component';
import { get } from './utils/fetch';
import { ProductsContext } from './contexts/products.context';
import ProductItem from './ProductItem';
import Categories from './Categories';

const Shop = () => {
  const { categoriesMap, hasItems, changedProducts } =
    useContext(CategoriesContext);
  const { products } = useContext(ProductsContext);
  const [productsList, setProductsList] = useState();
  const [categories, setCategories] = useState(categoriesMap);

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
        {hasItems && Array.isArray(productsList) ? (
          productsList.map((product) => (
            <ProductItem product={product} key={product.id} />
          ))
        ) : (
          <div>Choose category to see items</div>
        )}
      </div>
    </>
  );
};

export default Shop;
