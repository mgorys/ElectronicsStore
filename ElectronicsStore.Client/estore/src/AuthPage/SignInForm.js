import React from 'react';
import { loginUser } from '../utils/fetch';
import Button from '../button.component';
import { useState } from 'react';
import FormInput from './FormInput';
import { useContext } from 'react';
import { UserContext } from '../contexts/user.context';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const defaultFormFields = {
  email: '',
  password: '',
};

const SignInForm = () => {
  const { changeCurrentUser } = useContext(UserContext);
  const [formFields, setFormFields] = useState(defaultFormFields);
  const { email, password } = formFields;

  const resetFormFields = () => {
    setFormFields(defaultFormFields);
  };
  const handleChange = (event) => {
    const { name, value } = event.target;

    setFormFields({ ...formFields, [name]: value });
  };

  const handleSubmit = async (event) => {
    event.preventDefault();

    try {
      const response = await loginUser(email, password);

      if (response.status == 400) {
        toast.error('Incorrect e-mail or password');
      } else {
        changeCurrentUser(response);
        toast.success('Logged successfully');
      }
      resetFormFields();
    } catch (error) {
      switch (error.code) {
        case 'auth/wrong-password':
          toast.error('Incorrect e-mail or password', {
            displayDuration: 3000,
          });
          break;
        default:
      }
    }
  };

  return (
    <div className="sign-up-container">
      <h2>Already have an account?</h2>
      <span>Sign in with your email and password</span>
      <form onSubmit={handleSubmit}>
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
        <div className="buttons-container">
          <Button buttonType="classic" type="submit">
            Sign In
          </Button>
        </div>
      </form>
      <ToastContainer />
    </div>
  );
};

export default SignInForm;
