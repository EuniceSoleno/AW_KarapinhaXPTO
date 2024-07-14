import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';


const baseURL = "https://localhost:7224/TabelaDeHorario";

export default function TabeladeHorario() {

    const [tabelaDeHorario, setTabelaDeHorario] = useState([]); 
    const [error, setError] = useState("");  
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        axios.get(baseURL)
            .then((response) => {
                console.log('Resposta da API:', response);
                setTabelaDeHorario(response.data);
                setLoading(false); 
            })
            .catch((error) => {
                console.error('Erro ao buscar dados:', error);
                setError('Erro ao buscar dados');
                setLoading(false); 
            });
    }, []);

    if (error) return <div>{error}</div>;
    if (loading) return <div>Loading...</div>;

    console.log('Dados da tabela de horário:', tabelaDeHorario);  

    return (
        <div>
            <table>
                <thead>
                    <tr>
                        <th> id</th>
                        <th>Nome Profissional</th>
                        <th>Hora de Inicio</th>
                        <th>Hora de Fim</th>
                        <th>Dia da Semana</th>
                    </tr>
                </thead>
                <tbody>
                    {tabelaDeHorario.map((item) => (
                        <tr key={item.id}>
                            <td>{item.id}</td>
                            <td>{item.profissionalNome}</td>
                            <td>{item.horaInicio}</td>
                            <td>{item.horaFim}</td>
                            <td>{item.diaSemana}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
            <div>
                <Link to="/adicionarHorario">
                    <button>Adicionar Horario</button>
                </Link>
                <Link to="/editarHorario">
                    <button>Editar Horario</button>
                </Link>
                <Link to="/deleteHorario">
                    <button>Remover Horario</button>
                </Link>
            </div>
        </div>
    )
}
