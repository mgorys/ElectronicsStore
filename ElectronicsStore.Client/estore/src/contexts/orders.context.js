import { createContext, useState, useEffect, useContext } from 'react';
import { getAdmin } from '../utils/fetch';
import { UserContext } from './user.context';

export const OrdersContext = createContext({
  ordersList: {},
  searchProductsWithpage: () => {},
  hasItems: false,
  getOrderAdmin: () => {},
  orderItem: {},
});
export const OrdersProvider = ({ children }) => {
  const [ordersList, setOrdersList] = useState([]);
  const { currentUser } = useContext(UserContext);
  const [orderItem, setOrderItem] = useState({});
  const [hasItems, setHasItems] = useState(false);
  let endpoint = 'admin/order';
  let paramsObj = '';
  useEffect(() => {
    const getOrders = async () => {
      if (currentUser !== null) {
        const orders = await getAdmin(
          endpoint,
          paramsObj,
          1,
          currentUser.token
        );
        setHasItems(true);
        setOrdersList(orders);
      }
    };
    getOrders();
  }, []);

  async function getOrderAdmin(e) {
    paramsObj = e;
    const fetchedData = await getAdmin(
      endpoint,
      paramsObj,
      1,
      currentUser.token
    );
    setOrderItem(fetchedData);
    setHasItems(true);
  }

  async function searchProducts(e) {
    const fetchedData = await getAdmin('product/search', e);
    setOrdersList(fetchedData);
    setHasItems(true);
  }
  async function searchProductsWithpage(e, f) {
    const fetchedData = await getAdmin('product/search', e, f);
    setOrdersList(fetchedData);
    setHasItems(true);
  }

  const value = {
    ordersList,
    hasItems,
    searchProductsWithpage,
    getOrderAdmin,
    orderItem,
  };
  return (
    <OrdersContext.Provider value={value}>{children}</OrdersContext.Provider>
  );
};
