import React, { useContext } from 'react';
import { OrdersContext } from '../contexts/orders.context';
import { UserContext } from '../contexts/user.context';
import OrderEntity from './OrderEntity';

const AdminPage = () => {
  const { currentUser } = useContext(UserContext);
  const { ordersList, hasItems } = useContext(OrdersContext);

  return (
    <>
      {currentUser.userName === 'Admin' && (
        <div>
          {hasItems && Array.isArray(ordersList.dataFromServer) ? (
            ordersList.dataFromServer.map((order) => (
              <OrderEntity order={order} key={order.orderNumber} />
            ))
          ) : (
            <div>Array is empty</div>
          )}
        </div>
      )}
    </>
  );
};

export default AdminPage;
