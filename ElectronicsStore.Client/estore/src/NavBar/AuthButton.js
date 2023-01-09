import React, { useContext } from 'react';
import Button from '../button.component';
import { UserContext } from '../contexts/user.context';
import './AuthButton.scss';
import { Link } from 'react-router-dom';

const AuthButton = () => {
  const { currentUser, signOutUserFromContext } = useContext(UserContext);

  const signOutUser = () => {
    signOutUserFromContext();
    if (currentUser === null);
  };
  return (
    <div>
      {currentUser ? (
        <Link to="/" className="nav-link">
          <Button buttonType="classic">
            <div onClick={signOutUser}>SIGN OUT</div>
          </Button>
        </Link>
      ) : (
        <Link className="nav-link" to="/auth">
          <Button buttonType="classic">SIGN IN</Button>
        </Link>
      )}
    </div>
  );
};

export default AuthButton;
