import React, { useState } from 'react';
import axios from 'axios';

const baseURL = 'https://localhost:7224/TabelaDeHorario';

export default function DeleteHorario() {
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
            console.log('Horario excluído:', response);
            setMessage('Horario excluído com sucesso');
            setId("");
            setError("");
        })
        .catch((error) => {
            console.error('Erro ao excluir Horario:', error);
            setError('Erro ao excluir horario: ' + error.message);
            setMessage("");
        });
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>ID do Horário</label>
                <input 
                    type="text" 
                    name="id"
                    value={id} 
                    onChange={(e) => setId(e.target.value)} 
                />
            </div>

            <button type="submit">Excluir Horário</button>
            {message && <p>{message}</p>}
            {error && <p>{error}</p>}
        </form>
    );
}
