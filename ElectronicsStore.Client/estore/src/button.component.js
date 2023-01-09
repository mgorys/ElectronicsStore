import React from 'react';
import './button.component.scss';
const BUTTON_TYPE_CLASSES = {
  invertedpagination: 'inverted-pagination',
  classic: 'classic',
  inverted: 'inverted',
  pagination: 'pagination',
  invertedgotopagination: 'invertedgotopagination',
};
const Button = ({ children, buttonType, ...otherProps }) => {
  return (
    <button
      className={`button-container ${BUTTON_TYPE_CLASSES[buttonType]}`}
      {...otherProps}>
      {children}
    </button>
  );
};

export default Button;
