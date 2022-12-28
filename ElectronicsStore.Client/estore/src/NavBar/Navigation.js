import React from 'react';
import { Link } from 'react-router-dom';
import CartIcon from './CartIcon';
import Button from '../button.component';
import './Navigation.scss';
import AuthButton from './AuthButton';
import UserTag from './UserTag';

const Navigation = () => {
  return (
    <>
      <div className="nav-container">
        <div className="nav-button-container">
          <Link className="nav-link" to="/">
            <Button buttonType="classic">HOME</Button>
          </Link>
          <Link className="nav-link" to="/shop">
            <Button buttonType="classic">SHOP</Button>
          </Link>
          <Link className="nav-link" to="/checkout">
            <Button buttonType="classic">CHECKOUT</Button>
          </Link>
        </div>
        <div className="nav-container-right">
          <UserTag />
          <CartIcon />
          <Link className="nav-link" to="/auth">
            <AuthButton />
          </Link>
        </div>
      </div>
    </>
  );
};

export default Navigation;
