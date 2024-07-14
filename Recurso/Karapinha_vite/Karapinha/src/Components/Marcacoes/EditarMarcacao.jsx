import React, { useState } from 'react';
import axios from 'axios';

const baseURL = 'https://localhost:7224/api/Marcacao';

export default function EditarMarcacao() {
    const [marcacao, setMarcacao] = useState({
        id: "",
        diaSemana: "",
        nomeProfissional: "",
        hora: "",
        minuto: ""
    });
    const [message, setMessage] = useState("");
    const [error, setError] = useState("");

    const handleChange = (e) => {
        const { name, value } = e.target;
        setMarcacao({ ...marcacao, [name]: value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();

        axios.put(`${baseURL}/${marcacao.id}`, marcacao, {
            headers: {
                'Content-Type': 'application/json'
            }
        })
        .then((response) => {
            console.log('Marcação atualizada:', response);
            setMessage('Marcação atualizada com sucesso');
            setMarcacao({
                id: "",
                diaSemana: "",
                nomeProfissional: "",
                hora: "",
                minuto: ""
            });
            setError("");
        })
        .catch((error) => {
            console.error('Erro ao atualizar marcação:', error);
            setError('Erro ao atualizar marcação: ' + error.message);
            setMessage("");
        });
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>ID</label>
                <input 
                    type="text" 
                    name="id"
                    value={marcacao.id} 
                    onChange={handleChange} 
                />
            </div>
            <div>
                <label>Dia da Semana</label>
                <input 
                    type="text" 
                    name="diaSemana"
                    value={marcacao.diaSemana} 
                    onChange={handleChange} 
                />
            </div>
            <div>
                <label>Nome do Profissional</label>
                <input 
                    type="text" 
                    name="nomeProfissional"
                    value={marcacao.nomeProfissional} 
                    onChange={handleChange} 
                />
            </div>
            <div>
                <label>Hora</label>
                <input 
                    type="text" 
                    name="hora"
                    value={marcacao.hora} 
                    onChange={handleChange} 
                />
            </div>
            <div>
                <label>Minuto</label>
                <input 
                    type="text" 
                    name="minuto"
                    value={marcacao.minuto} 
                    onChange={handleChange} 
                />
            </div>
            <button type="submit">Atualizar Marcação</button>
            {message && <p>{message}</p>}
            {error && <p>{error}</p>}
        </form>
    );
}
