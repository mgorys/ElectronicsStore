import React from 'react';
import { useContext } from 'react';
import './PaginationAdmin.scss';
import Button from '../button.component';
import { OrdersContext } from '../contexts/orders.context';

const PaginatationAdmin = ({ pagesCount }) => {
  const { getOrdersAdminWithPage } = useContext(OrdersContext);
  const pageNumbers = [];

  for (let i = pagesCount; i > 0; i--) {
    pageNumbers.push(i);
  }

  const handleClick = (page) => {
    getOrdersAdminWithPage(page);
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

export default PaginatationAdmin;
