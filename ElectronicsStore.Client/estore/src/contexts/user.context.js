import { createContext, useState, useEffect } from 'react';

export const UserContext = createContext({
  setCurrentUser: () => null,
  currentUser: null,
  changeCurrentUser: (e) => {},
  signOutUserFromContext: () => {},
});
export const UserProvider = ({ children }) => {
  const [currentUser, setCurrentUser] = useState(null);

  const signOutUserFromContext = () => {
    setCurrentUser(null);
  };
  const changeCurrentUser = (e) => {
    setCurrentUser(e);
  };
  useEffect(() => {
    //react save to cookies
  });

  const value = {
    currentUser,
    setCurrentUser,
    changeCurrentUser,
    signOutUserFromContext,
  };
  return <UserContext.Provider value={value}>{children}</UserContext.Provider>;
};
