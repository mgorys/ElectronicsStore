import React, { useContext, useState, useEffect } from 'react';
import { OrdersContext } from '../contexts/orders.context';
import { UserContext } from '../contexts/user.context';
import { useParams } from 'react-router-dom';

const OrderDetails = () => {
  const { orderNumber } = useParams();
  const [orderData, setOrderData] = useState();
  const [hasData, setHasData] = useState(false);
  const [displayStatus, setDisplayStatus] = useState(null);
  const { currentUser } = useContext(UserContext);
  const { getOrderAdmin, changeOrderStatusAdmin } = useContext(OrdersContext);
  const fetchOrder = async () => {
    const data = await getOrderAdmin(orderNumber);
    setOrderData(data);
    setHasData(true);
  };
  useEffect(() => {
    async function fetchData() {
      await fetchOrder();
    }
    fetchData();
  }, []);

  const handleStatusChange = async (e) => {
    let fetchData = await changeOrderStatusAdmin(orderNumber, e);
    setOrderData(fetchData);
  };

  return (
    <>
      {currentUser.userName === 'Admin' && hasData && (
        <div>
          <h2>OrderDetails : </h2>
          <h2>Order Number: {orderData.orderNumber}</h2>
          <h2>Order Status: {orderData.status}</h2>
          <h2>Order PutDate: {orderData.putDate}</h2>
          <h2>Owner : {orderData.userName}</h2>
          <h2>Worth : {orderData.totalWorth}</h2>
          <h2>
            Change status:
            <select
              name="status"
              value={orderData.status}
              onChange={(e) => handleStatusChange(e.target.value)}>
              <option value="Created">Created</option>
              <option value="Prepared">Prepared</option>
              <option value="Shipped">Shipped</option>
              <option value="Archived">Archived</option>
            </select>
          </h2>
          {Array.isArray(orderData.purchasedItemList) &&
            orderData.purchasedItemList.map((item) => (
              <div className="checkoutitem-container" key={item.productId}>
                <h3>Product: {item.name}</h3>
                <h3>Count: {item.count}</h3>
              </div>
            ))}
        </div>
      )}
    </>
  );
};

export default OrderDetails;
