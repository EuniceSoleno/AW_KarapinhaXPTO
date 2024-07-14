import React from 'react';
import { Navigate } from 'react-router-dom';

const ProtectedRoute = ({ element, allowedRoles }) => {
  const user = JSON.parse(localStorage.getItem('user'));

  if (!user) {
    return <Navigate to="/login" replace />;
  }

  if (!allowedRoles.includes(user.nivelDeAcesso)) {
    return <Navigate to="/home" replace />;
  }

  return element;
};

export default ProtectedRoute;
