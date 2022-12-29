import React, { useContext } from 'react';
import { OrdersContext } from '../contexts/orders.context';
import { UserContext } from '../contexts/user.context';
import { useParams } from 'react-router-dom';

const OrderDetails = () => {
  const { orderNumber } = useParams();
  const { currentUser } = useContext(UserContext);
  const { getOrderAdmin } = useContext(OrdersContext);
  const fetchOrder = (orderNumber) => getOrderAdmin(orderNumber);
  return (
    <>
      {currentUser.userName === 'Admin' && fetchOrder && (
        <div>OrderDetails</div>
      )}
    </>
  );
};

export default OrderDetails;
