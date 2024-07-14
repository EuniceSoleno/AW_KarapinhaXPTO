import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';

const baseURL =   'https://localhost:7224/api/Marcacao'


export default function Marcacaoes() {
    const [marcacao, setMarcacao] = useState([]);
    const [error, setError] = useState("");

    useEffect(() => {
        axios.get(baseURL)
            .then((response) => {
                console.log('Resposta da API:', response);
                setMarcacao(response.data);
            })
            .catch((error) => {
                console.error('Erro ao buscar marcacao:', error);
                setError('Erro ao buscar marcacao');
            });
    }, []);

    if (error) return <div>{error}</div>;
    if (!marcacao.length) return <div>Loading...</div>;

    console.log('Dados das marcacao:', marcacao);

    return (
        <div>
            <table>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Dia da Semana</th>
                        <th>Nome do Profissional</th>
                        <th>Hora</th>
                    </tr>
                </thead>
                <tbody>
                    {marcacao.map((marc) => (
                        <tr key={marc.id}>
                            <td>{marc.id}</td>
                            <td>{marc.diaSemana}</td>
                            <td>{marc.nomeProfissional}</td>
                            <td>{marc.HoraCompleta}</td>

                        </tr>
                    ))}
                </tbody>
            </table>
                <Link to="/editarmarcacao">
                    <button>Reagendar Marcacao</button>
                </Link>
                <Link to="/eliminarMarcacao">
                    <button>Remover Marcacao</button>
                </Link>
        </div>
    );
}
