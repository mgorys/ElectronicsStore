import React, { useContext, useState, useEffect } from 'react';
import { OrdersContext } from '../contexts/orders.context';
import { UserContext } from '../contexts/user.context';
import { useParams } from 'react-router-dom';
import './OrderDetails.scss';
import { Link } from 'react-router-dom';

const OrderDetails = () => {
  const { orderNumber } = useParams();
  const [orderData, setOrderData] = useState();
  const [hasData, setHasData] = useState(false);
  const { currentUser } = useContext(UserContext);
  const { getOrderAdmin, changeOrderStatusAdmin } = useContext(OrdersContext);
  const fetchOrder = async () => {
    const data = await getOrderAdmin(orderNumber);
    setOrderData(data);
    setHasData(true);
  };
  useEffect(() => {
    async function fetchData() {
      await fetchOrder();
    }
    fetchData();
  }, []);

  const handleChangeStatus = async (e) => {
    let fetchData = await changeOrderStatusAdmin(orderNumber, e);
    setOrderData(fetchData);
  };

  return (
    <>
      {currentUser.userName === 'Admin' && hasData && (
        <div className="orderdetails-page">
          <div className="orderdetails-container">
            <h2 className="orderdetails-entity">
              <div>Number: </div>
              <div>{orderData.orderNumber}</div>
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
              <div>Worth: </div>
              <div>{orderData.totalWorth}PLN</div>
            </h2>
            <h2>
              <div className="dropdown">
                <button className="dropbtn">{orderData.status}</button>
                <div className="dropdown-content">
                  <a onClick={(e) => handleChangeStatus(e.target.innerText)}>
                    Prepared
                  </a>
                  <a onClick={(e) => handleChangeStatus(e.target.innerText)}>
                    Shipped
                  </a>
                  <a onClick={(e) => handleChangeStatus(e.target.innerText)}>
                    Archived
                  </a>
                </div>
              </div>
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

export default OrderDetails;
