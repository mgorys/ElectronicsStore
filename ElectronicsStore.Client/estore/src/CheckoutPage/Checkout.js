import { useContext, useState } from 'react';
import { CartContext } from '../contexts/cart.context';
import React from 'react';
import CheckoutItem from './CheckoutItem';
import { UserContext } from '../contexts/user.context';
import Button from '../button.component';
import { Link, Navigate } from 'react-router-dom';
import './Checkout.scss';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const Checkout = () => {
  const { cartItems, cartTotal, clearCartItems, postPurchaseOrder } =
    useContext(CartContext);
  const { currentUser } = useContext(UserContext);
  const [purchaseFinished, setPurchaseFinished] = useState(false);
  const handleSubmitPurchase = async () => {
    if (cartItems.length === 0) {
      alert('Cart cannot be empty');
      return false;
    } else {
      let orderDetails = await postPurchaseOrder(
        cartItems,
        currentUser.token,
        currentUser.email
      );
      if (orderDetails !== undefined && orderDetails !== null) {
        // alert('Purchase completed');
        toast.success('Purchase completed', { displayDuration: 3000 });
        clearCartItems();
        setPurchaseFinished(true);
      }
    }
  };

  return (
    <>
      <ToastContainer />
      {purchaseFinished && <Navigate to="/purchase" />}
      <div className="checkout-page">
        <div className="checkout-container">
          <div>
            <div className="checkout-header">
              <h1 className="header-block-product">Product</h1>
              <h1 className="header-block">Quantity</h1>
              <h1 className="header-block">Price</h1>
              <div className="header-block" />
            </div>
          </div>
          <div>
            {Array.isArray(cartItems) &&
              cartItems.map((cartItem) => (
                <div className="checkoutitem-container" key={cartItem.id}>
                  <CheckoutItem cartItem={cartItem} />
                </div>
              ))}
          </div>
        </div>
        <div className="checkout-summary">
          <h3 className="total">Total: {cartTotal.toFixed(2)}PLN</h3>
          {currentUser ? (
            <Button buttonType="classic" onClick={handleSubmitPurchase}>
              Purchase
            </Button>
          ) : (
            <Link to="/auth">
              <Button buttonType="classic">Log In to Continue</Button>
            </Link>
          )}
        </div>
      </div>
    </>
  );
};

export default Checkout;
