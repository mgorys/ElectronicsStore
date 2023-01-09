import React, { useContext, useState, useEffect } from 'react';
import { OrdersContext } from '../contexts/orders.context';
import { UserContext } from '../contexts/user.context';
import { useParams } from 'react-router-dom';
import './OrderDet.scss';
import { Link } from 'react-router-dom';

const OrderDet = () => {
  const { orderNumber } = useParams();
  const [orderData, setOrderData] = useState();
  const { hasItems, getOrder } = useContext(OrdersContext);
  const [hasData, setHasData] = useState();
  const fetchOrder = async () => {
    const data = await getOrder(orderNumber);
    setOrderData(data);
    setHasData(true);
  };
  useEffect(() => {
    async function fetchData() {
      await fetchOrder();
    }
    fetchData();
  }, []);

  return (
    <>
      {hasData && (
        <div className="orderdetails-page">
          <div className="orderdetails-container">
            <h2 className="orderdetails-entity">
              <div>Number: </div>
              <div>{orderData.orderNumber}</div>
            </h2>
            <h2 className="orderdetails-entity">
              <div>Status: </div>
              <div>{orderData.status}</div>
            </h2>
            <h2 className="orderdetails-entity">
              <div>Owner: </div>
              <div>{orderData.userName}</div>
            </h2>
            <h2 className="orderdetails-entity">
              <div>Date: </div>
              <div>{orderData.putDate}</div>
            </h2>
            <h2 className="orderdetails-entity">
              <div>Total: </div>
              <div>{orderData.totalWorth}PLN</div>
            </h2>

            <div />
            <div className="orderdetails-list">
              <div className="orderdetails-list-header">
                <h2>Product</h2>
                <h2>Count</h2>
              </div>
              {Array.isArray(orderData.purchasedItemList) &&
                orderData.purchasedItemList.map((item) => (
                  <Link
                    to={`/product/${item.name}`}
                    className="orderdetails-list-item"
                    key={item.productId}>
                    <h2> {item.name}</h2>
                    <h2>{item.count}</h2>
                  </Link>
                ))}
            </div>
          </div>
        </div>
      )}
    </>
  );
};

export default OrderDet;
