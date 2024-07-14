import React, { useState } from 'react';
import axios from 'axios';

const baseURL = 'https://localhost:7224/api/Marcacao';

export default function AdicionarMarcacao() {
    const [novaMarcacao, setNovaMarcacao] = useState({
        diaSemana: "",
        nomeProfissional: "",
        hora: "",
        minuto: ""
    });
    const [message, setMessage] = useState("");
    const [error, setError] = useState("");

    const handleChange = (e) => {
        const { name, value } = e.target;
        setNovaMarcacao({ ...novaMarcacao, [name]: value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();

        axios.post(baseURL, novaMarcacao, {
            headers: {
                'Content-Type': 'application/json'
            }
        })
        .then((response) => {
            console.log('Marcação adicionada:', response);
            setMessage('Marcação adicionada com sucesso');
            setNovaMarcacao({
                diaSemana: "",
                nomeProfissional: "",
                hora: "",
                minuto: ""
            });
            setError("");
        })
        .catch((error) => {
            console.error('Erro ao adicionar marcação:', error);
            setError('Erro ao adicionar marcação: ' + error.message);
            setMessage("");
        });
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>Dia da Semana</label>
                <input 
                    type="text" 
                    name="diaSemana"
                    value={novaMarcacao.diaSemana} 
                    onChange={handleChange} 
                />
            </div>
            <div>
                <label>Nome do Profissional</label>
                <input 
                    type="text" 
                    name="nomeProfissional"
                    value={novaMarcacao.nomeProfissional} 
                    onChange={handleChange} 
                />
            </div>
            <div>
                <label>Hora</label>
                <input 
                    type="text" 
                    name="hora"
                    value={novaMarcacao.hora} 
                    onChange={handleChange} 
                />
            </div>
            <div>
                <label>Minuto</label>
                <input 
                    type="text" 
                    name="minuto"
                    value={novaMarcacao.minuto} 
                    onChange={handleChange} 
                />
            </div>
            <button type="submit">Adicionar Marcação</button>
            {message && <p>{message}</p>}
            {error && <p>{error}</p>}
        </form>
    );
}
