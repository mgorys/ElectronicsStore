import React, { useContext } from 'react';
import Button from './button.component';
import { CategoriesContext } from './contexts/categories.context';

const Categories = ({ categories }) => {
  const { changeCategory } = useContext(CategoriesContext);
  const changeCategoryHandler = (e) => changeCategory(e);
  return (
    <div>
      {Array.isArray(categories) ? (
        categories.map((category) => (
          <div key={category.id}>
            <Button
              value={category.name}
              onClick={(e) => changeCategoryHandler(e.target.textContent)}>
              {category.name}
            </Button>
          </div>
        ))
      ) : (
        <div>--Loading--</div>
      )}
    </div>
  );
};

export default Categories;
