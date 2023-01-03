import React, { useContext, useState } from 'react';
import Button from '../button.component';
import { CategoriesContext } from '../contexts/categories.context';
import './Categories.scss';

const Categories = ({ categories }) => {
  const { changeCategory, searchProducts } = useContext(CategoriesContext);
  const changeCategoryHandler = (e) => changeCategory(e);

  const handleSearchSubmit = (e) => searchProducts(e);
  const [search, setSearch] = useState('');

  const handleChange = (event) => {
    const { value } = event.target;
    setSearch(value);
  };

  return (
    <div className="categories-container">
      <div className="categoires-buttons-container">
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
      <div className="searchField">
        <input
          className="search-input"
          label="search"
          required
          onChange={handleChange}
          name="search"
          value={search}
        />
        <Button
          buttonType="classic"
          type="submit"
          onClick={() => handleSearchSubmit(search)}>
          Search
        </Button>
      </div>
    </div>
  );
};

export default Categories;
