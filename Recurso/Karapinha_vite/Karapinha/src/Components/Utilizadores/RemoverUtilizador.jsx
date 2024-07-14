import React from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

const baseURL = 'https://localhost:7224/api/Utilizador';

export default function removerutilizador({ id }) {
    const navigate = useNavigate();

    const handleDelete = () => {
        axios.delete(`${baseURL}/${id}`)
            .then((response) => {
                console.log('Utilizador eliminado:', response);
                navigate('/utilizadores');
            })
            .catch((error) => {
                console.error('Erro ao eliminar utilizador:', error);
            });
    };

    return (
        <button onClick={handleDelete}>Eliminar</button>
    );
}
