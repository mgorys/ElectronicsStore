import React, { useContext, useState, useEffect } from 'react';
import Button from '../button.component';
import { CategoriesContext } from '../contexts/categories.context';
import './Categories.scss';
import { FaArrowUp, FaArrowDown } from 'react-icons/fa';

const Categories = ({ categories }) => {
  const { getProductsWithCategory, setQuery, query, currentCategory } =
    useContext(CategoriesContext);
  const defaultQuery = {
    search: null,
    page: null,
    sortDirection: null,
  };
  const [search, setSearch] = useState('');
  const [pageSize, setPageSize] = useState('');
  const changeCategoryHandler = (e) => {
    setQuery(defaultQuery);
    getProductsWithCategory(e);
  };
  useEffect(() => {
    setPageSize(5);
  }, []);

  const handleSortDirection = (e) => {
    if (query !== undefined && query !== null) {
      query.sortDirection = e;
      getProductsWithCategory(currentCategory, query);
    } else {
      defaultQuery.sortDirection = e;
      getProductsWithCategory(currentCategory, defaultQuery);
    }
  };
  const handleChangePageSize = (e) => {
    if (query !== undefined && query !== null) {
      query.pageSize = e;
      setPageSize(e);
      getProductsWithCategory(currentCategory, query);
    } else {
      defaultQuery.pageSize = e;
      setPageSize(e);
      getProductsWithCategory(currentCategory, defaultQuery);
    }
  };
  const handleSearchSubmit = (e) => {
    if (query !== undefined && query !== null) {
      query.search = e;
      getProductsWithCategory(currentCategory, query);
    } else {
      defaultQuery.search = e;
      getProductsWithCategory(currentCategory, defaultQuery);
    }
  };

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
      <div className="searchPanel">
        <div className="searchPanel-sortDirection">
          <button className="button-arrow">
            <FaArrowDown
              className="searchPanel-sortDirection-mark"
              onClick={() => handleSortDirection('DESC')}
            />
          </button>
          <button className="button-arrow">
            <FaArrowUp
              className="searchPanel-sortDirection-mark"
              onClick={() => handleSortDirection('ASC')}
            />
          </button>
        </div>
        <div className="dropdown-pageSize">
          <button className="dropbtn-pageSize">{pageSize}</button>
          <div className="dropdown-pageSize-content">
            <a onClick={(e) => handleChangePageSize(e.target.innerText)}>5</a>
            <a onClick={(e) => handleChangePageSize(e.target.innerText)}>10</a>
            <a onClick={(e) => handleChangePageSize(e.target.innerText)}>15</a>
          </div>
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
    </div>
  );
};

export default Categories;
