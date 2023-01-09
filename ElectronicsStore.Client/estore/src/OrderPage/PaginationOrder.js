import React from 'react';
import Button from '../button.component';
import { useContext, useState } from 'react';
import { OrdersContext } from '../contexts/orders.context';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const PaginationOrder = ({ pagesCount, query }) => {
  const { getUsersOrders } = useContext(OrdersContext);
  const pageNumbers = [];
  const [currentPage, setCurrentPage] = useState(1);
  const defaultQuery = {
    search: null,
    page: null,
    sortDirection: null,
  };
  for (let i = pagesCount; i > 0; i--) {
    if (pagesCount < 6) pageNumbers.push(i);
  }

  const handleClick = (e) => {
    if (query !== null && query !== undefined) {
      query.page = parseInt(e);
      getUsersOrders(query);
      setCurrentPage(parseInt(e));
    } else {
      defaultQuery.page = parseInt(e);
      getUsersOrders(defaultQuery);
      setCurrentPage(parseInt(e));
    }
  };
  const handleChangePage = (e) => {
    let changepage;
    if (e == 'increment') changepage = parseInt(currentPage) + 1;
    else changepage = parseInt(currentPage) - 1;
    {
      if (changepage < 1 || changepage > pagesCount) {
        toast.error('Invalid Page');
      }
      query.page = changepage;
      let nextpage = changepage;
      getUsersOrders(query);
      setCurrentPage(nextpage);
    }
  };
  return (
    <div className="pagination-container">
      <ToastContainer />
      {pageNumbers.length > 1 &&
        pageNumbers.length < 6 &&
        pageNumbers.reverse().map((number) => (
          <Button
            buttonType="invertedpagination"
            onClick={(e) => handleClick(e.target.value)}
            key={number}
            value={number}>
            {number}
          </Button>
        ))}
      {pagesCount > 5 && (
        <>
          <Button
            buttonType={currentPage !== 1 ? 'invertedpagination' : 'pagination'}
            onClick={(e) => handleClick(e.target.value)}
            key={1}
            value={1}>
            {1}
          </Button>
          {currentPage !== 1 && (
            <Button
              buttonType="invertedpagination"
              onClick={(e) => handleChangePage(e.target.value)}
              key={'decrement'}
              value={'decrement'}>
              {'<'}
            </Button>
          )}
          {currentPage !== 1 && currentPage != pagesCount && (
            <Button
              buttonType="pagination"
              key={currentPage}
              value={currentPage}>
              {currentPage}
            </Button>
          )}
          {currentPage !== pagesCount && (
            <Button
              buttonType="invertedpagination"
              onClick={(e) => handleChangePage(e.target.value)}
              key={'increment'}
              value={'increment'}>
              {'>'}
            </Button>
          )}

          <Button
            buttonType={
              currentPage !== pagesCount ? 'invertedpagination' : 'pagination'
            }
            onClick={(e) => handleClick(e.target.value)}
            key={pagesCount}
            value={pagesCount}>
            {pagesCount}
          </Button>
        </>
      )}
    </div>
  );
};

export default PaginationOrder;
