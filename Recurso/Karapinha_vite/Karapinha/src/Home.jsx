
import axios from 'axios';
import React, { useState, useEffect } from 'react';
import Marcacaoes from './Components/Marcacoes/Marcacaoes';
import { Link } from 'react-router-dom';
import Login from './Components/Login/Login';

const baseURL = 'https://localhost:7224/api/Servico';

export default function Home() {
    const [servico, setservico] = useState([]);
    const [error, setError] = useState(null);

    useEffect(() => {
        axios.get(baseURL)
            .then((response) => {
                console.log('Resposta da API:', response);
                setservico(response.data);
            })
            .catch((error) => {
                console.error('Erro ao buscar categorias:', error);
                setError('Erro ao buscar servico');
            });
    }, []);

    if (error) return <div>{error}</div>;
    if (!servico.length) return <div>Loading...</div>;

    const handleLogout = () => {
        setUser(null);
        setUsername("");
        setPassword("");
        localStorage.clear();
        navigate('/login');
    };



    return (
        <div>
            <nav>
            <Link to="/login"><button>Fazer Marcacao</button></Link>
                <Link to='login'> <button>Login</button></Link>

            </nav>
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

        </div>
    )
}
