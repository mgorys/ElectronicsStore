import React, { useState } from 'react';
import FormInput from './FormInput';
import Button from '../button.component';
import { registerUser } from '../utils/fetch';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
const defaultFormFields = {
  displayName: '',
  email: '',
  password: '',
  confirmPassword: '',
};

const SignUpForm = () => {
  const [formFields, setFormFields] = useState(defaultFormFields);
  const { displayName, email, password, confirmPassword } = formFields;

  const resetFormFields = () => {
    setFormFields(defaultFormFields);
  };

  const handleSubmit = async (event) => {
    event.preventDefault();

    if (password !== confirmPassword) {
      toast.error('passwords do not match');
      return;
    }

    try {
      const response = await registerUser(
        email,
        password,
        confirmPassword,
        displayName
      );
      resetFormFields();
      if (response.status == 400) {
        toast.error('Something went wrong');
      } else {
        toast.success('Account created successfuly', { displayDuration: 3000 });
      }
    } catch (error) {
      if (error.code === 'auth/email-already-in-use') {
        toast.error('Cannot create user, email already in use');
      } else {
        toast.error('User creation encountered an error');
      }
    }
  };

  const handleChange = (event) => {
    const { name, value } = event.target;

    setFormFields({ ...formFields, [name]: value });
  };
  return (
    <div className="sign-up-container">
      <h2>Don't have an account?</h2>
      <span>Sign up with your email and password</span>
      <form onSubmit={handleSubmit}>
        <FormInput
          label="Display Name"
          type="text"
          required
          onChange={handleChange}
          name="displayName"
          value={displayName}
        />

        <FormInput
          label="Email"
          type="email"
          required
          onChange={handleChange}
          name="email"
          value={email}
        />

        <FormInput
          label="Password"
          type="password"
          required
          onChange={handleChange}
          name="password"
          value={password}
        />

        <FormInput
          label="Confirm Password"
          type="password"
          required
          onChange={handleChange}
          name="confirmPassword"
          value={confirmPassword}
        />
        <Button buttonType="classic" type="submit">
          Sign Up
        </Button>
        <ToastContainer />
      </form>
    </div>
  );
};

export default SignUpForm;
