import React, { useEffect, useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import axios from 'axios';
import AdicionarMarcacao from '../Marcacoes/AdicionarMarcacao';

const baseURL = 'https://localhost:7224/api/Servico';

export default function Cadastrado() {
  const [user, setUser] = useState(null);
  const [servico, setServico] = useState([]);
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    axios.get(baseURL)
      .then((response) => {
        console.log('Resposta da API:', response);
        setServico(response.data);
      })
      .catch((error) => {
        console.error('Erro ao buscar categorias:', error);
        setError('Erro ao buscar categorias');
      });
  }, []);

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
    <div>
      {user ? (
        <div>
          <p><strong>Nome de usuário:</strong> {user.username}</p>
          <p><strong>Nível de acesso:</strong> {user.nivelDeAcesso}</p>
          <p><strong>ID :</strong> {user.id}</p>
          <Link to={`/editarutilizador/${user.id}`}><button>Actualizar os Dados</button></Link>
          <button onClick={handleLogout}>Logout</button>
        </div>
      ) : (
        <p>Carregando dados do usuário...</p>
      )}

      <table>
        <thead>
          <tr>
            <th>ID</th>
            <th>Servico</th>
            <th>Preco</th>
            <th>CategoriaId</th>
          </tr>
        </thead>
        <tbody>
          {servico.map((servico) => (
            <tr key={servico.id}>
              <td>{servico.id}</td>
              <td>{servico.servicoNome}</td>
              <td>{servico.preco}</td>
              <td>{servico.categoriaId}</td>
            </tr>
          ))}
        </tbody>
      </table>
      <Link to="/adicionarmarcacao"><button>Fazer Marcacao</button></Link>
    </div>
  );
}
