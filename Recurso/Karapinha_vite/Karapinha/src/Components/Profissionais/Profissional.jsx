import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

const baseURL = 'https://localhost:7224/TabelaDeHorario';

export default function Profissional() {
    const [profissional, setProfissional] = useState(null);
    const [error, setError] = useState(null);
    const [loading, setLoading] = useState(true);
    const [marcacao, setMarcacao] = useState([]); 
    
    const navigate = useNavigate();

    useEffect(() => {
        const loggedInUser = localStorage.getItem("user");
        if (loggedInUser) {
            const user = JSON.parse(loggedInUser);
            if (user.nivelDeAcesso === 'profissional') {
                setProfissional(user);
                axios.get(`${baseURL}/${user.username}`)
                    .then((response) => {
                        console.log('Resposta da API:', response);
                        setMarcacao(response.data);                        
                    })
                    .catch((error) => {
                        console.error('Erro ao buscar marcações:', error);
                        setError('Erro ao buscar marcações');
                    });
            } else {
                setError("Usuário logado não é um profissional.");
            }
        } else {
            setError("Nenhum usuário encontrado.");
        }
        setLoading(false);
    }, []);

    const handleLogout = () => {
        setProfissional(null);
        localStorage.removeItem("user");
        navigate('/login');
    };

    return (
        <div className="profissional-container">
            <h1>Profissional Particular</h1>

            {loading ? (
                <p>Carregando dados do Profissional...</p>
            ) : profissional ? (
                <div>
                    <p><strong>Nome de usuário:</strong> {profissional.username}</p>
                    <p><strong>Nível de acesso:</strong> {profissional.nivelDeAcesso}</p>
                    <p><strong>ID:</strong> {profissional.id}</p>
                </div>
            ) : (
                <p>{error}</p>
            )}

            <button onClick={handleLogout} aria-label="Logout">
                Logout
            </button>

            {marcacao.length > 0 && (
                <table>
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Nome do Profissional</th>
                            <th>Hora Início Hora</th>
                            <th>Hora Início Minuto</th>
                            <th>Hora Fim Hora</th>
                            <th>Hora Fim Minuto</th>
                            <th>Dia da Semana</th>
                        </tr>
                    </thead>
                    <tbody>
                        {marcacao.map((marc) => (
                            <tr key={marc.id}>
                                <td>{marc.id}</td>
                                <td>{marc.profissionalNome}</td>
                                <td>{marc.horaInicioHora}</td>
                                <td>{marc.horaInicioMinuto}</td>
                                <td>{marc.horaFimHora}</td>
                                <td>{marc.horaFimMinuto}</td>
                                <td>{marc.diaSemana}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            )}
        </div>
    );
}
