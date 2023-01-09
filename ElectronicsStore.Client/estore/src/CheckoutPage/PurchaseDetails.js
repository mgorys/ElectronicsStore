import React from 'react';
import { CartContext } from '../contexts/cart.context';
import { useContext } from 'react';
import { UserContext } from '../contexts/user.context';
import './PurchaseDetails.scss';

const PurchaseDetails = () => {
  const { orderDetails } = useContext(CartContext);
  const { currentUser } = useContext(UserContext);
  return (
    <div className="purchaseDetails-body-container">
      <h2>Hey {currentUser.userName}, your order has been started. </h2>
      <h2>Some information:</h2>
      <h2>Contact email : {orderDetails.userName}</h2>
      <h2>Order number : {orderDetails.orderNumber}</h2>
      <h2>Total : {orderDetails.totalWorth} PLN</h2>
    </div>
  );
};

export default PurchaseDetails;
