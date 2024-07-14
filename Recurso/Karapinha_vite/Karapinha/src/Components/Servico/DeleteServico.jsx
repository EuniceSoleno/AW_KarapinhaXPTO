import React, { useState } from 'react';
import axios from 'axios';

const baseURL = 'https://localhost:7224/api/Servico';

export default function DeleteServico() {
    const [servico, setServico] = useState({ id: "" });
    const [error, setError] = useState("");

    const handleSubmit = (e) => {
        e.preventDefault();

        if (!servico.id) {
            setError('ID do serviço é obrigatório');
            return;
        }

        axios.delete(`${baseURL}/${servico.id}`)
            .then((response) => {
                console.log('Servico eliminado:', response);
                setServico({ id: "" });
                setError("");
            })
            .catch((error) => {
                console.error('Erro ao eliminar Servico:', error);
                setError('Erro ao eliminar Servico');
            });
    };

    const handleChange = (e) => {
        const { name, value } = e.target;
        setServico({ ...servico, [name]: value });
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>ID</label>
                <input
                    type="text"
                    name="id"
                    value={servico.id}
                    onChange={handleChange}
                    required
                />
            </div>
            <button type="submit">Eliminar Servico</button>
            {error && <p>{error}</p>}
        </form>
    );
}
