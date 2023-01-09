import { createContext, useState, useEffect } from 'react';
import { useLocalStorage } from '../utils/useLocalStorage';

export const UserContext = createContext({
  setCurrentUser: () => null,
  currentUser: null,
  changeCurrentUser: (e) => {},
  signOutUserFromContext: () => {},
});
export const UserProvider = ({ children }) => {
  const [currentUser, setCurrentUser] = useLocalStorage('currentUser', []);

  const signOutUserFromContext = () => {
    setCurrentUser(null);
  };
  const changeCurrentUser = (e) => {
    setCurrentUser(e);
  };

  const value = {
    currentUser,
    setCurrentUser,
    changeCurrentUser,
    signOutUserFromContext,
  };
  return <UserContext.Provider value={value}>{children}</UserContext.Provider>;
};
