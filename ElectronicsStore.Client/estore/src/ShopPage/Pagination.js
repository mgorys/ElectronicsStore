import React from 'react';
import { useContext } from 'react';
import { CategoriesContext } from '../contexts/categories.context';
import './Pagination.scss';
import Button from '../button.component';

const Paginate = ({ pagesCount, category, searchProces }) => {
  const { changeCategoryWithPage, searchProductsWithpage, searchRequest } =
    useContext(CategoriesContext);
  const pageNumbers = [];

  for (let i = pagesCount; i > 0; i--) {
    pageNumbers.push(i);
  }

  const handleClick = (page) => {
    if (!searchProces) changeCategoryWithPage(category, page);
    else searchProductsWithpage(searchRequest, page);
  };

  return (
    <div className="pagination-container">
      {pageNumbers.length > 1 &&
        pageNumbers.reverse().map((number) => (
          <Button
            buttonType="invertedpagination"
            onClick={(e) => handleClick(e.target.value)}
            key={number}
            value={number}>
            {number}
          </Button>
        ))}
    </div>
  );
};

export default Paginate;