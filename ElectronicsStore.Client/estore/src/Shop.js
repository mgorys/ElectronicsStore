import React from 'react';
import { useContext, useState, useEffect } from 'react';
import { CategoriesContext } from './contexts/categories.context';
import Button from './button.component';
import { get } from './utils/fetch';
import { ProductsContext } from './contexts/products.context';
import ProductItem from './ProductItem';

const Shop = () => {
  const { categoriesMap } = useContext(CategoriesContext);
  const { products } = useContext(ProductsContext);
  const [productsList, setProductsList] = useState();
  const [categories, setCategories] = useState(categoriesMap);
  const [hasItems, setHasItems] = useState(false);

  let changedProducts;
  useEffect(() => {
    setCategories(categoriesMap);
  }, [categoriesMap]);

  useEffect(() => {
    setProductsList(changedProducts);
    if (changedProducts === undefined) {
      setProductsList(products);
    }
  }, [changedProducts]);

  async function changeCategory(e) {
    changedProducts = await get('product', e);
    setProductsList(changedProducts);
    setHasItems(true);
  }
  return (
    <>
      <div className="category-container">
        {Array.isArray(categories) ? (
          categories.map((category) => (
            <div key={category.id}>
              <Button
                value={category.name}
                onClick={(e) => changeCategory(e.target.textContent)}>
                {category.name}
              </Button>
            </div>
          ))
        ) : (
          <div>--Loading--</div>
        )}
        {hasItems ? (
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
