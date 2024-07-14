import React, { useState, useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import axios from 'axios';
import Side from '../SideBar/Side';
import './Admin.css'; // Supondo que você tenha um arquivo CSS separado para estilos

export default function Admin() {
  const [user, setUser] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    const loggedInUser = localStorage.getItem("user");
    if (loggedInUser) {
      setUser(JSON.parse(loggedInUser));
    }
  }, []);

  const handleLogout = () => {
    setUser(null);
    localStorage.removeItem("user");
    navigate('/login');
  };

  return (
    <div className="admin-container">
      <Side />
      {user ? (
        <div className="user-info">
          <p><strong>Nome de usuário:</strong> {user.nomeCompleto}</p>
          <p><strong>Nível de acesso:</strong> {user.nivelDeAcesso}</p>
          <p><strong>ID :</strong> {user.id}</p>
          <Link to={`/editarprofissional/${user.id}`}><button>Atualizar Dados</button></Link>
          <button onClick={handleLogout}>Logout</button>
        </div>
      ) : (
        <p>Carregando dados do usuário...</p>
      )}
    </div>
  );
}
