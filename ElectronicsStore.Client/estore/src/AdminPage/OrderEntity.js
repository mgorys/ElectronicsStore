import React from 'react';
import { Link } from 'react-router-dom';
import './OrderEntity.scss';
import { OrdersContext } from '../contexts/orders.context';
import { useContext } from 'react';
import { FaTimes, FaCheck } from 'react-icons/fa';

const OrderEntity = ({ order, query, refreshOrders }) => {
  const { orderNumber, status, userName } = order;
  const { deleteOrderAdmin, changeOrderStatusAdmin, getOrdersAdminWithPage } =
    useContext(OrdersContext);
  const handleDelete = () => {
    deleteOrderAdmin(orderNumber);
  };
  const handleAccept = () => {
    changeOrderStatusAdmin(orderNumber, 'Prepared');
    getOrdersAdminWithPage(query);
    refreshOrders();
  };

  return (
    <>
      <div className="orderitemgroup-container">
        <Link to={`/admin/${orderNumber}`} className="orderitem-container">
          <h2 className="orderitem-number">{orderNumber}</h2>
          <h2 className="orderitem-owner">{userName}</h2>
          <h2 className="orderitem-status">{status}</h2>
        </Link>
        {status === 'Created' && (
          <>
            <FaCheck onClick={handleAccept} className="admin-icon" />
            <FaTimes onClick={handleDelete} className="admin-icon" />
          </>
        )}
      </div>
    </>
  );
};

export default OrderEntity;
