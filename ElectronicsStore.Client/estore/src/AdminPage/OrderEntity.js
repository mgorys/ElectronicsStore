import React from 'react';
import { Link } from 'react-router-dom';
import './OrderEntity.scss';

const OrderEntity = ({ order }) => {
  const { status, orderNumber } = order;
  return (
    <>
      <div>
        <Link to={`/admin/${orderNumber}`} className="orderitem">
          <h2>Order : {orderNumber}</h2>
        </Link>
      </div>
    </>
  );
};

export default OrderEntity;
