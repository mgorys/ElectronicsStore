import React from 'react';
import { useContext } from 'react';
import { CategoriesContext } from './contexts/categories.context';

const Paginate = ({ pagesCount, category }) => {
  const { changeCategoryWithPage } = useContext(CategoriesContext);
  const pageNumbers = [];

  for (let i = pagesCount; i > 0; i--) {
    pageNumbers.push(i);
  }

  const handleClick = (page) => {
    changeCategoryWithPage(category, page);
  };

  return (
    <div className="pagination-container">
      <ul className="pagination">
        {pageNumbers.reverse().map((number) => (
          <button
            onClick={(e) => handleClick(e.target.value)}
            key={number}
            value={number}>
            {number}
          </button>
        ))}
      </ul>
    </div>
  );
};

export default Paginate;
