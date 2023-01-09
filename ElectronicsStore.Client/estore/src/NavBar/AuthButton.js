import React, { useContext } from 'react';
import Button from '../button.component';
import { UserContext } from '../contexts/user.context';
import './AuthButton.scss';
import { Link } from 'react-router-dom';

const AuthButton = () => {
  const { currentUser, signOutUserFromContext } = useContext(UserContext);

  const signOutUser = () => {
    signOutUserFromContext();
    console.log(currentUser);
    if (currentUser === null) alert('sign out');
  };
  return (
    <div>
      {currentUser ? (
        <Button buttonType="classic">
          <div className="nav-link" onClick={signOutUser}>
            SIGN OUT
          </div>
        </Button>
      ) : (
        <Link className="nav-link" to="/auth">
          <Button buttonType="classic">SIGN IN</Button>
        </Link>
      )}
    </div>
  );
};

export default AuthButton;
