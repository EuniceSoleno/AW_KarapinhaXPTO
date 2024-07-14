import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './Login.css';
import { useNavigate, Link } from 'react-router-dom';

const baseURL = 'https://localhost:7224/api/Utilizador';
const baseURLP = 'https://localhost:7224/api/Profissional';

function Login() {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");
  const [user, setUser] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    const loggedInUser = localStorage.getItem("user");
    if (loggedInUser) {
      const foundUser = JSON.parse(loggedInUser);
      setUser(foundUser);
      redirectBasedOnRole(foundUser.nivelDeAcesso);
    }
  }, []);

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const [userResponse, professionalResponse] = await Promise.all([
        axios.get(`${baseURL}/nome/${username}`, { headers: { 'Content-Type': 'application/json' } }),
        axios.get(`${baseURLP}/nome/${username}`, { headers: { 'Content-Type': 'application/json' } })
      ]);

      const user = userResponse.data;
      const professional = professionalResponse.data;

      if ((user && user.password === password) || (professional && professional.password === password)) {
        const validUser = user || professional;
        setUser(validUser);
        localStorage.setItem('user', JSON.stringify(validUser));
        setError("");
        console.log('Dados do usuário logado:', validUser); // Exibe os dados do usuário ou profissional logado
        redirectBasedOnRole(validUser.nivelDeAcesso);
      } else {
        setError("Nome de usuário ou senha inválidos");
      }
    } catch (error) {
      console.error('Erro ao buscar usuário ou profissional:', error);
      setError('Erro ao buscar usuário ou profissional: ' + error.message);
    }
  };

  const handleLogout = () => {
    setUser(null);
    setUsername("");
    setPassword("");
    localStorage.removeItem('user');
    navigate('/login');
  };

  const redirectBasedOnRole = (role) => {
    switch (role) {
      case 'admin':
        navigate('/admin');
        break;
      case 'cadastrado':
        navigate('/cadastrado');
        break;
      case 'administrativo':
        navigate('/administrativo');
        break;
      case 'profissional':
        navigate('/profissional');
        break;
      default:
        setError('Nível de acesso desconhecido');
        break;
    }
  };

  if (user) {
    console.log('Dados do usuário logado:', user); // Exibe os dados do usuário logado
    return (
      <div>
        {user.username} está logado
        <button onClick={handleLogout}>Logout</button>
      </div>
    );
  }

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <label htmlFor="username">Nome de usuário: </label>
        <input
          type="text"
          id="username"
          value={username}
          placeholder="Digite um nome de usuário"
          onChange={({ target }) => setUsername(target.value)}
        />
        <div>
          <label htmlFor="password">Senha: </label>
          <input
            type="password"
            id="password"
            value={password}
            placeholder="Digite uma senha"
            onChange={({ target }) => setPassword(target.value)}
          />
        </div>
        <button type="submit">Login</button>
        {error && <p>{error}</p>}
      </form>
      <Link to="/adicionarutilizador"><button>Criar Conta</button></Link>
    </div>
  );
}

export default Login;
