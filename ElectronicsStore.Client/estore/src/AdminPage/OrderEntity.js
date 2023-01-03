import React from 'react';
import { Link } from 'react-router-dom';
import './OrderEntity.scss';

const OrderEntity = ({ order }) => {
  const { orderNumber, status } = order;

  return (
    <>
      <div>
        <Link to={`/admin/${orderNumber}`} className="orderitem-container">
          <div className="orderitem-number-container">
            <h2 className="orderitem-number-title">Order :</h2>
            <h2 className="orderitem-number-number">{orderNumber}</h2>
          </div>
          <h2 className="orderitem-status">Status : {status}</h2>
        </Link>
      </div>
    </>
  );
};

export default OrderEntity;
