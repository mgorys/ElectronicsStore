import React, { useState } from 'react';
import { useContext } from 'react';
import './PaginationAdmin.scss';
import Button from '../button.component';
import { OrdersContext } from '../contexts/orders.context';

const PaginatationAdmin = ({ pagesCount, query }) => {
  const { getOrdersAdminWithPage } = useContext(OrdersContext);
  const [currentPage, setCurrentPage] = useState(1);
  const pageNumbers = [];

  for (let i = 1; i <= pagesCount; i++) {
    pageNumbers.push(i);
    if (!(pagesCount < 5 && pageNumbers.length < 5)) {
      // (i < currentPage && pageNumbers.length > 5)
      pageNumbers.shift();
    }
  }

  const handleClick = (page) => {
    query.page = page;
    console.log(query);
    getOrdersAdminWithPage(query);
    setCurrentPage(page);
  };
  const handleInput = (e) => {
    e.preventDefault();
    console.log(e);
  };

  return (
    <div className="pagination-container">
      {pageNumbers.length > 1 &&
        pageNumbers.length < 5 &&
        pageNumbers.map((number) => (
          <Button
            buttonType="invertedpagination"
            onClick={(e) => handleClick(e.target.value)}
            key={number}
            value={number}>
            {number}
          </Button>
        ))}
      {pageNumbers.length > 4 && (
        <form
          onSubmit={(e) => handleInput(e.target[0].value)}
          className="pagination-goto-container">
          <input type="text" className="pagination-input"></input>
          <Button
            buttonType="invertedgotopagination"
            style={{ innerWidth: '100px' }}
            type="submit"
            value="submit">
            Go To
          </Button>
        </form>
      )}
    </div>
  );
};

export default PaginatationAdmin;
