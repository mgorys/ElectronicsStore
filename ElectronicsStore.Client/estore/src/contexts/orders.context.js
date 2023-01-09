import { createContext, useState, useContext } from 'react';
import { getAdmin, postAdmin, deleteAdmin } from '../utils/fetch';
import { UserContext } from './user.context';

export const OrdersContext = createContext({
  ordersList: {},
  hasItems: false,  
  getOrderAdmin: () => {},
  orderItem: {},
  getOrdersAdminWithPage: () => {},
  changeOrderStatusAdmin: () => {},
  deleteOrderAdmin: () => {},
  defaultQuery: {},
});
export const OrdersProvider = ({ children }) => {
  const { currentUser } = useContext(UserContext);
  const [ordersList, setOrdersList] = useState([]);
  const [orderItem, setOrderItem] = useState({});
  const [hasItems, setHasItems] = useState(false);
  let endpoint = 'admin/order';
  let paramsObj = undefined;

  const defaultQuery = {
    search: null,
    page: null,
    status: null,
  };

  async function getOrdersAdminWithPage(query) {
    if (currentUser !== null) {
      if ((query !== null) & (query !== undefined)) {
        if (Number.isInteger(query.status))
          query.status = parseStatusToEnum(query.status);
      }
      paramsObj = undefined;
      const orders = await getAdmin(
        endpoint,
        paramsObj,
        query,
        currentUser.token
      );
      if (orders.status === 400) {
        alert('smth went wrong');
        return orders.status;
      }
      let changed = parseStatusToString(orders);
      setOrdersList(changed);
      setHasItems(true);
    }
  }
  function parseStatusToString(data) {
    if (Array.isArray(data.dataFromServer)) {
      data.dataFromServer.forEach((element) => {
        {
          switch (element.status) {
            case 0:
              element.status = 'Created';
              break;
            case 1:
              element.status = 'Prepared';
              break;
            case 2:
              element.status = 'Shipped';
              break;
            case 3:
              element.status = 'Archived';
              break;
          }
        }
      });
    } else {
      switch (data.status) {
        case 0:
          data.status = 'Created';
          break;
        case 1:
          data.status = 'Prepared';
          break;
        case 2:
          data.status = 'Shipped';
          break;
        case 3:
          data.status = 'Archived';
          break;
      }
    }
    return data;
  }
  function parseStatusToEnum(status) {
    switch (status) {
      case 'Created':
        return 0;
      case 'Prepared':
        return 1;
      case 'Shipped':
        return 2;
      case 'Archived':
        return 3;
    }
  }
  async function getOrderAdmin(e) {
    paramsObj = e;
    const fetchedData = await getAdmin(
      endpoint,
      paramsObj,
      undefined,
      currentUser.token
    );
    let changed = parseStatusToString(fetchedData);
    setOrdersList(changed);
    setHasItems(true);
    return fetchedData;
  }
  async function deleteOrderAdmin(e) {
    paramsObj = e;
    const fetchedData = await deleteAdmin(
      endpoint,
      paramsObj,
      currentUser.token
    );
    if (fetchedData === true) {
      paramsObj = undefined;
      getOrdersAdminWithPage(defaultQuery);
    }
    return fetchedData;
  }
  async function changeOrderStatusAdmin(number, status) {
    paramsObj = 'status';
    const body = {
      number: number,
      status: parseStatusToEnum(status),
    };
    const fetchedData = await postAdmin(
      endpoint,
      paramsObj,
      currentUser.token,
      body
    );
    let changed = parseStatusToString(fetchedData);
    setOrderItem(changed);
    setHasItems(true);
    return fetchedData;
  }
  const value = {
    ordersList,
    hasItems,
    getOrderAdmin,
    orderItem,
    getOrdersAdminWithPage,
    changeOrderStatusAdmin,
    deleteOrderAdmin,
    defaultQuery,
  };
  return (
    <OrdersContext.Provider value={value}>{children}</OrdersContext.Provider>
  );
};
