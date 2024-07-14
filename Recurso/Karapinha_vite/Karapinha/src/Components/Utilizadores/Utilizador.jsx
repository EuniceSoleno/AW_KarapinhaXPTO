import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';

const baseURL = 'https://localhost:7224/api/Utilizador';

export default function Utilizador() {
  const [utilizador, setUtilizador] = useState([]);
  const [error, setError] = useState(null);

  useEffect(() => {
      axios.get(baseURL)
          .then((response) => {
              console.log('Resposta da API:', response);
              setUtilizador(response.data);
          })
          .catch((error) => {
              console.error('Erro ao buscar Utilizado:', error);
              setError('Erro ao buscar Utilizador');
          });
  }, []);

  if (error) return <div>{error}</div>;
  if (!utilizador.length) return <div>Loading...</div>;

  console.log('Dados dos Profissionais:', utilizador);
  return (
    <div>
            <table>
                <thead>
                    <tr>
                        <th>Photo</th>
                        <th>ID</th>
                        <th>NomeCompleto</th>
                        <th>Endereco</th>
                        <th>Telemovel</th>
                        <th>BI</th>
                        <th>UserName</th>
                        <th>Password</th>
                        <th>nivelDeAcesso</th>
                    </tr>
                </thead>
                <tbody>
                    {utilizador.map((user) => (
                        <tr key={user.id}>
                            <td>{user.photo}</td>
                            <td>{user.id}</td>
                            <td>{user.nomeCompleto}</td>
                            <td>{user.endereco}</td>
                            <td>{user.telemovel}</td>
                            <td>{user.bi}</td>
                            <td>{user.username}</td>
                            <td>{user.password}</td>
                            <td>{user.nivelDeAcesso}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
            <div>
                <Link to="/adicionarutilizador">
                    <button>Adicionar Utilizador</button>
                </Link>
                <Link to="/removerutilizador">
                    <button>Remover Utilizador</button>
                </Link>
            </div>
        </div>
  )
}
