import React, { useContext, useEffect, useState } from 'react';
import { OrdersContext } from '../contexts/orders.context';
import { UserContext } from '../contexts/user.context';
import OrderEntity from './OrderEntity';
import PaginationAdmin from './PaginationAdmin';
import './AdminPage.scss';
import Button from '../button.component';

const defaultQuery = {
  search: null,
  page: null,
  status: null,
};

const AdminPage = () => {
  const { currentUser } = useContext(UserContext);
  const { ordersList, hasItems, getOrdersAdminWithPage } =
    useContext(OrdersContext);
  const [search, setSearch] = useState('');
  const [queryState, setQueryState] = useState(defaultQuery);
  const [queryStatus, setQueryStatus] = useState('');

  const handleSearchSubmit = async (e) => {
    queryState.page = null;
    queryState.search = e;
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

  useEffect(() => {
    async function fetchData() {
      setQueryState(defaultQuery);
      await getOrdersAdminWithPage(defaultQuery);
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
          <h2>Hi {currentUser.userName}</h2>
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
          <div className="adminpage-header-status">
            {hasItems && (
              <select
                name="status"
                value={queryStatus}
                onChange={(e) => handleChangeStatus(e.target.value)}>
                <option value="">Status</option>
                <option value="Created">Created</option>
                <option value="Prepared">Prepared</option>
                <option value="Shipped">Shipped</option>
                <option value="Archived">Archived</option>
              </select>
            )}
          </div>
        </div>
      )}
      {currentUser.userName === 'Admin' && (
        <div>
          <div>
            {hasItems && Array.isArray(ordersList.dataFromServer) ? (
              ordersList.dataFromServer.map((order) => (
                <OrderEntity order={order} key={order.orderNumber} />
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
