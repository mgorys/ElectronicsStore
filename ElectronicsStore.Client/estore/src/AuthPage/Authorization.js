import React from 'react';
import SignInForm from './SignInForm';
import SignUpForm from './SignUpForm';
import './Authorization.scss';

const Authorization = () => {
  return (
    <div className="authentication-container">
      <SignInForm />
      <SignUpForm />
    </div>
  );
};

export default Authorization;
