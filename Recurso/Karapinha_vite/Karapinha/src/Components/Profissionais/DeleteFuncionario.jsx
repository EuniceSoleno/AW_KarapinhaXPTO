import React, { useState } from 'react';
import axios from 'axios';

const baseURL = 'https://localhost:7224/api/Marcacao';

export default function EliminarMarcacao() {
    const [id, setId] = useState("");
    const [message, setMessage] = useState("");
    const [error, setError] = useState("");

    const handleSubmit = (e) => {
        e.preventDefault();

        axios.delete(`${baseURL}/${id}`, {
            headers: {
                'Content-Type': 'application/json'
            }
        })
        .then((response) => {
            console.log('Marcação excluída:', response);
            setMessage('Marcação excluída com sucesso');
            setId("");
            setError("");
        })
        .catch((error) => {
            console.error('Erro ao excluir marcação:', error);
            setError('Erro ao excluir marcação: ' + error.message);
            setMessage("");
        });
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>ID da Marcação</label>
                <input 
                    type="text" 
                    name="id"
                    value={id} 
                    onChange={(e) => setId(e.target.value)} 
                />
            </div>
            <button type="submit">Excluir Marcação</button>
            {message && <p>{message}</p>}
            {error && <p>{error}</p>}
        </form>
    );
}
