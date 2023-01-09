import React, { useContext, useEffect, useState } from 'react';
import { OrdersContext } from '../contexts/orders.context';
import { UserContext } from '../contexts/user.context';
import OrderEntity from './OrderEntity';
import PaginationAdmin from './PaginationAdmin';
import './AdminPage.scss';
import Button from '../button.component';

const AdminPage = () => {
  const { currentUser } = useContext(UserContext);
  const { ordersList, hasItems, getOrdersAdminWithPage, defaultQuery } =
    useContext(OrdersContext);
  const [search, setSearch] = useState('');
  const [queryState, setQueryState] = useState(defaultQuery);
  const [queryStatus, setQueryStatus] = useState('');
  const [pageSize, setPageSize] = useState('');

  const handleChangePageSize = (e) => {
    if (queryState !== undefined && queryState !== null) {
      queryState.pageSize = e;
      queryState.page = 1;
      setPageSize(e);
      getOrdersAdminWithPage(queryState);
    } else {
      defaultQuery.pageSize = e;
      defaultQuery.page = 1;
      setPageSize(e);
      getOrdersAdminWithPage(defaultQuery);
    }
  };
  const handleSearchSubmit = async (e) => {
    queryState.page = null;
    if (
      (e === null || e === undefined) &&
      (search !== null || search !== undefined)
    ) {
      console.log('wchodzi', e, search);
      queryState.search = search;
    } else queryState.search = e;
    let response = await getOrdersAdminWithPage(queryState);
    if (response === 400) {
      queryState.search = null;
      await getOrdersAdminWithPage(queryState);
      setSearch('');
    }
    setQueryState(queryState);
  };
  const handleChange = (event) => {
    const { value } = event.target;
    setSearch(value);
  };

  const refreshOrders = () => {
    getOrdersAdminWithPage(queryState);
  };

  useEffect(() => {
    async function fetchData() {
      setQueryState(defaultQuery);
      await getOrdersAdminWithPage(defaultQuery);
      setPageSize(5);
    }
    fetchData();
  }, []);

  async function handleChangeStatus(e) {
    queryState.status = e;
    queryState.page = null;
    await getOrdersAdminWithPage(queryState);
    setQueryState(queryState);
    setQueryStatus(e);
  }
  return (
    <>
      {hasItems && (
        <div className="adminpage-header-container">
          <div className="adminpage-header-status">
            {hasItems && (
              <>
                <div className="dropdown-container">
                  <div className="dropdown">
                    <button className="dropbtn">Status</button>
                    <div className="dropdown-content">
                      <a
                        onClick={(e) => handleChangeStatus(e.target.innerText)}>
                        Created
                      </a>
                      <a
                        onClick={(e) => handleChangeStatus(e.target.innerText)}>
                        Prepared
                      </a>
                      <a
                        onClick={(e) => handleChangeStatus(e.target.innerText)}>
                        Shipped
                      </a>
                      <a
                        onClick={(e) => handleChangeStatus(e.target.innerText)}>
                        Archived
                      </a>
                    </div>
                  </div>
                </div>
              </>
            )}
          </div>
          <div className="dropdown-pageSize">
            <button className="dropbtn-pageSize">{pageSize}</button>
            <div className="dropdown-pageSize-content">
              <a onClick={(e) => handleChangePageSize(e.target.innerText)}>5</a>
              <a onClick={(e) => handleChangePageSize(e.target.innerText)}>
                10
              </a>
              <a onClick={(e) => handleChangePageSize(e.target.innerText)}>
                15
              </a>
            </div>
          </div>
          <div className="searchField-admin">
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
      )}
      {currentUser.userName === 'Admin' && (
        <div>
          <div className="adminpage-body-container">
            <div className="adminpage-body-title">
              <h2>Number</h2>
              <h2>Owner</h2>
              <h2>Status</h2>
            </div>
            {hasItems && Array.isArray(ordersList.dataFromServer) ? (
              ordersList.dataFromServer.map((order) => (
                <OrderEntity
                  order={order}
                  key={order.orderNumber}
                  query={queryState}
                  refreshOrders={refreshOrders}
                />
              ))
            ) : (
              <div>Array is empty</div>
            )}
          </div>
          <div>
            {hasItems && Array.isArray(ordersList.dataFromServer) && (
              <PaginationAdmin
                pagesCount={ordersList.pagesCount}
                query={queryState}
              />
            )}
          </div>
        </div>
      )}
    </>
  );
};

export default AdminPage;
