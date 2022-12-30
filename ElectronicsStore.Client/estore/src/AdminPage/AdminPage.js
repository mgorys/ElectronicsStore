import React, { useContext } from 'react';
import { OrdersContext } from '../contexts/orders.context';
import { UserContext } from '../contexts/user.context';
import OrderEntity from './OrderEntity';
import PaginationAdmin from './PaginationAdmin';

const AdminPage = () => {
  const { currentUser } = useContext(UserContext);
  const { ordersList, hasItems } = useContext(OrdersContext);

  return (
    <>
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
              <PaginationAdmin pagesCount={ordersList.pagesCount} />
            )}
          </div>
        </div>
      )}
    </>
  );
};

export default AdminPage;
