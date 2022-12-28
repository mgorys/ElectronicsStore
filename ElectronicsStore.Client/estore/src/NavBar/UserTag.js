import React from 'react';
import { useContext } from 'react';
import { UserContext } from '../contexts/user.context';
import './UserTag.scss';

const UserTag = () => {
  const { currentUser } = useContext(UserContext);
  return (
    <>
      <div className="userTag">
        {currentUser && <div>Hello {currentUser.userName}!</div>}
      </div>
    </>
  );
};

export default UserTag;
