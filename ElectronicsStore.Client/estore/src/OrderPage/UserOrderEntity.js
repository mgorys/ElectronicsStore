import React from 'react';
import './UserOrderEntity.scss';
import { Link } from 'react-router-dom';

const UserOrderEntity = ({ order }) => {
  const { orderNumber, putDate, totalWorth, status } = order;

  return (
    <>
      <Link to={`${orderNumber}`} className="orderentitygroup-container">
        <h2>{orderNumber}</h2>
        <h2>{status}</h2>
        <h2>{putDate}</h2>
        <h2>{totalWorth}PLN</h2>
      </Link>
    </>
  );
};

export default UserOrderEntity;
