import React from 'react';
import { loginUser } from '../utils/fetch';
import Button from '../button.component';
import { useState } from 'react';
import FormInput from './FormInput';
import { useContext } from 'react';
import { UserContext } from '../contexts/user.context';

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
      console.log(response);

      if (response.status !== null) {
        changeCurrentUser(response);
        alert('logged succesfully');
      } else {
        alert('something went wrong');
      }
      resetFormFields();
    } catch (error) {
      switch (error.code) {
        case 'auth/wrong-password':
          alert('incorrect password for email');
          break;
        case 'auth/user-not-found':
          alert('no user associated with this email');
          break;
        default:
          console.log(error);
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
    </div>
  );
};

export default SignInForm;
