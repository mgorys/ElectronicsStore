import React, { useContext } from 'react';
import { Link } from 'react-router-dom';
import CartIcon from './CartIcon';
import Button from '../button.component';
import './Navigation.scss';
import AuthButton from './AuthButton';
import UserTag from './UserTag';
import { UserContext } from '../contexts/user.context';

const Navigation = () => {
  const { currentUser } = useContext(UserContext);
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
          {currentUser && (
            <Link className="nav-link" to="/order">
              <Button buttonType="classic">ORDERS</Button>
            </Link>
          )}
          {currentUser && currentUser.userName === 'Admin' && (
            <Link className="nav-button-key" to="/admin">
              <Button buttonType="classic">Admin</Button>
            </Link>
          )}
        </div>
        <div className="nav-container-right">
          <UserTag />
          <CartIcon />

          <AuthButton />
        </div>
      </div>
    </>
  );
};

export default Navigation;
