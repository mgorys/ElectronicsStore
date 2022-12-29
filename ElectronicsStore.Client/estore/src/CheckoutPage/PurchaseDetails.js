import React from 'react';
import { CartContext } from '../contexts/cart.context';
import { useContext } from 'react';
import { UserContext } from '../contexts/user.context';

const PurchaseDetails = () => {
  const { orderDetails } = useContext(CartContext);
  const { currentUser } = useContext(UserContext);
  return (
    <div>
      <h2>
        Hey {currentUser.userName}, your order has been started. With some
        information:
      </h2>
      <h2>contact email : {orderDetails.userName}</h2>
      <h2>order number : {orderDetails.orderNumber}</h2>
      <h2>order status : {orderDetails.status}</h2>
      <h2>order totalWorth : {orderDetails.totalWorth}</h2>
    </div>
  );
};

export default PurchaseDetails;
