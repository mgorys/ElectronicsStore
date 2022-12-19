import React from 'react';
import './button.component.scss';
const Button = ({ children, ...otherProps }) => {
  return (
    <button className="button-container" {...otherProps}>
      {children}
    </button>
  );
};

export default Button;
