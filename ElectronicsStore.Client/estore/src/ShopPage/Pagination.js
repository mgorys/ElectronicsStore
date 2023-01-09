import React, { useState } from 'react';
import { useContext } from 'react';
import { CategoriesContext } from '../contexts/categories.context';
import './Pagination.scss';
import Button from '../button.component';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const Paginate = ({ pagesCount }) => {
  const { getProductsWithCategory, query, currentCategory } =
    useContext(CategoriesContext);
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
      query.page = e;
      getProductsWithCategory(currentCategory, query);
      setCurrentPage(parseInt(e));
    } else {
      defaultQuery.page = e;
      getProductsWithCategory(currentCategory, defaultQuery);
      setCurrentPage(parseInt(e));
    }
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
      getProductsWithCategory(currentCategory, query);
      setCurrentPage(nextpage);
    }
  };

  return (
    <div className="pagination-container">
      <ToastContainer />
      {pagesCount > 1 &&
        pagesCount < 6 &&
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

export default Paginate;
