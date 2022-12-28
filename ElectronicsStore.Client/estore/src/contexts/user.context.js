import { createContext, useState, useEffect } from 'react';
import { useLocalStorage } from '../utils/useLocalStorage';

export const UserContext = createContext({
  setCurrentUser: () => null,
  currentUser: null,
  changeCurrentUser: (e) => {},
  signOutUserFromContext: () => {},
  token: null,
});
export const UserProvider = ({ children }) => {
  const [currentUser, setCurrentUser] = useLocalStorage('currentUser', []);
  const [token, setToken] = useState(null);

  const signOutUserFromContext = () => {
    setCurrentUser(null);
  };
  const changeCurrentUser = (e) => {
    setCurrentUser(e);
    setToken(e.token);
  };
  useEffect(() => {
    //react save to cookies
  });

  const value = {
    currentUser,
    setCurrentUser,
    changeCurrentUser,
    signOutUserFromContext,
    token,
  };
  return <UserContext.Provider value={value}>{children}</UserContext.Provider>;
};
