import React, { useContext, useState, useEffect } from 'react';
import { OrdersContext } from '../contexts/orders.context';
import { UserContext } from '../contexts/user.context';
import { useParams } from 'react-router-dom';

const OrderDetails = () => {
  const { orderNumber } = useParams();
  const [orderData, setOrderData] = useState();
  const [hasData, setHasData] = useState(false);
  const { currentUser } = useContext(UserContext);
  const { getOrderAdmin } = useContext(OrdersContext);
  const fetchOrder = async () => {
    const data = await getOrderAdmin(orderNumber);
    setOrderData(data);
    setHasData(true);
  };
  useEffect(() => {
    fetchOrder();
  }, []);

  return (
    <>
      {currentUser.userName === 'Admin' && orderData && (
        <div>
          <h2>OrderDetails : </h2>
          <h2>Order Number: {orderData.orderNumber}</h2>
          <h2>Status : {orderData.status}</h2>
          <h2>Owner : {orderData.userName}</h2>
          <h2>Worth : {orderData.totalWorth}</h2>

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
