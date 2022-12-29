import React from 'react';
import { CartContext } from './contexts/cart.context';
import { useContext } from 'react';

const PurchaseDetails = () => {
  const { orderDetails } = useContext(CartContext);
  return (
    <div>
      <h2>order number : {orderDetails.orderNumber}</h2>
      <h2>order status : {orderDetails.status}</h2>
      <h2>order totalWorth : {orderDetails.totalWorth}</h2>
    </div>
  );
};

export default PurchaseDetails;
