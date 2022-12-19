import React from 'react';
import { Link } from 'react-router-dom';
import CartIcon from './CartIcon';
import Button from './button.component';
import './Navigation.scss';

const Navigation = () => {
  return (
    <>
      <div className="nav-container">
        <div className="nav-button-container">
          <Link className="nav-link" to="/">
            <Button>BACK HOME</Button>
          </Link>
          <Link className="nav-link" to="/shop">
            <Button>SHOP</Button>
          </Link>
          <Link className="nav-link" to="/checkout">
            <Button>CHECKOUT</Button>
          </Link>
        </div>
        <CartIcon />
      </div>
    </>
  );
};

export default Navigation;
