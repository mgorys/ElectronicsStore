import React, { useState } from 'react';
import { useContext } from 'react';
import './PaginationAdmin.scss';
import Button from '../button.component';
import { OrdersContext } from '../contexts/orders.context';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const PaginatationAdmin = ({ pagesCount, query }) => {
  const { getOrdersAdminWithPage } = useContext(OrdersContext);
  const [currentPage, setCurrentPage] = useState(1);
  const pageNumbers = [];

  for (let i = 1; i <= pagesCount; i++) {
    if (pagesCount < 6) pageNumbers.push(i);
  }

  const handleClick = (e) => {
    query.page = e;
    console.log(query);
    getOrdersAdminWithPage(query);
    setCurrentPage(e);
  };
  const handleInput = (e) => {
    e.preventDefault();
  };
  const handleChangePage = (e) => {
    let changepage;
    if (e == 'increment') changepage = currentPage + 1;
    else changepage = currentPage - 1;
    {
      if (changepage < 1 || changepage > pagesCount) {
        toast.error('Invalid Page');
      }
      query.page = changepage;
      let nextpage = changepage;
      getOrdersAdminWithPage(query);
      setCurrentPage(nextpage);
    }
  };

  return (
    <div className="pagination-container">
      <ToastContainer />
      {pageNumbers.length > 1 &&
        pageNumbers.length < 6 &&
        pageNumbers.map((number) => (
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
          {currentPage !== 1 && currentPage !== pagesCount && (
            <Button
              buttonType="pagination"
              // onClick={(e) => handleClick(e.target.value)}
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
        // <form
        //   onSubmit={(e) => handleInput(e)}
        //   className="pagination-goto-container">
        //   <input type="text" className="pagination-input"></input>
        //   <Button
        //     buttonType="invertedgotopagination"
        //     style={{ innerWidth: '100px' }}
        //     type="submit"
        //     value="submit">
        //     Go To
        //   </Button>
        // </form>
      )}
    </div>
  );
};

export default PaginatationAdmin;
