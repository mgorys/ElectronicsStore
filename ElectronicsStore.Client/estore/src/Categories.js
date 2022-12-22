import React, { useContext } from 'react';
import Button from './button.component';
import { CategoriesContext } from './contexts/categories.context';
import './Categories.scss';

const Categories = ({ categories }) => {
  const { changeCategory } = useContext(CategoriesContext);
  const changeCategoryHandler = (e) => changeCategory(e);
  return (
    <div className="categories-container">
      {Array.isArray(categories) ? (
        categories.map((category) => (
          <Button
            key={category.id}
            buttonType="inverted"
            value={category.name}
            onClick={(e) => changeCategoryHandler(e.target.textContent)}>
            {category.name}
          </Button>
        ))
      ) : (
        <div>--Loading--</div>
      )}
    </div>
  );
};

export default Categories;
