import React from 'react';
import { OrdersContext } from '../contexts/orders.context';
import { UserContext } from '../contexts/user.context';
import { useContext } from 'react';
import { useEffect, useState } from 'react';
import UserOrderEntity from './UserOrderEntity';
import './OrderPage.scss';

const OrderPage = () => {
  const { currentUser } = useContext(UserContext);
  const { getUsersOrders, hasItems, ordersList } = useContext(OrdersContext);

  useEffect(() => {
    async function fetchData() {
      await getUsersOrders(currentUser);
    }
    fetchData();
  }, []);

  return (
    <>
      <div className="orderpage-body-container">
        <div className="orderpage-body-title">
          <h2>Number</h2>
          <h2>Date</h2>
          <h2>Total</h2>
        </div>
        {hasItems && Array.isArray(ordersList.dataFromServer) ? (
          ordersList.dataFromServer.map((order) => (
            <UserOrderEntity order={order} key={order.orderNumber} />
          ))
        ) : (
          <div>Array is empty</div>
        )}
      </div>
    </>
  );
};

export default OrderPage;
