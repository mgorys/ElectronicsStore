import React, { useContext } from 'react';
import Button from './button.component';
import { UserContext } from './contexts/user.context';
import './AuthButton.scss';

const AuthButton = () => {
  const { currentUser, signOutUserFromContext } = useContext(UserContext);

  const signOutUser = () => {
    alert('sign out');
    signOutUserFromContext();
    console.log(currentUser);
  };
  return (
    <div>
      {currentUser ? (
        <Button>
          <div className="nav-link" onClick={signOutUser}>
            SIGN OUT
          </div>
        </Button>
      ) : (
        <div className="nav-link" to="/auth">
          <Button>SIGN IN</Button>
        </div>
      )}
    </div>
  );
};

export default AuthButton;
