import React, { useContext } from 'react';
import Button from '../button.component';
import { UserContext } from '../contexts/user.context';
import './AuthButton.scss';

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
        <Button buttonType="inverted">
          <div className="nav-link" onClick={signOutUser}>
            SIGN OUT
          </div>
        </Button>
      ) : (
        <div className="nav-link" to="/auth">
          <Button buttonType="classic">SIGN IN</Button>
        </div>
      )}
    </div>
  );
};

export default AuthButton;