import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams, useNavigate } from 'react-router-dom';

const baseURL = 'https://localhost:7224/api/Utilizador';

export default function EditarUtilizador() {
    const { id } = useParams();
    const [utilizador, setUtilizador] = useState(null);
    const navigate = useNavigate();

    useEffect(() => {
        axios.get(`${baseURL}/${id}`)
            .then((response) => {
                setUtilizador(response.data);
            })
            .catch((error) => {
                console.error('Erro ao buscar utilizador:', error);
            });
    }, [id]);

    const handleChange = (e) => {
        setUtilizador({ ...utilizador, [e.target.name]: e.target.value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();

        axios.put(`${baseURL}/${id}`, utilizador)
            .then((response) => {
                console.log('Utilizador atualizado:', response);
                navigate('/cadastrado'); // Navega para a página de cadastro após a atualização
            })
            .catch((error) => {
                console.error('Erro ao atualizar utilizador:', error);
            });
    };

    if (!utilizador) return <div>Loading...</div>;

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>Nome Completo:</label>
                <input type="text" name="nomeCompleto" value={utilizador.nomeCompleto} onChange={handleChange} />
            </div>
            <div>
                <label>Endereço:</label>
                <input type="text" name="endereco" value={utilizador.endereco} onChange={handleChange} />
            </div>
            <div>
                <label>Telemóvel:</label>
                <input type="text" name="telemovel" value={utilizador.telemovel} onChange={handleChange} />
            </div>
            <div>
                <label>BI:</label>
                <input type="text" name="bi" value={utilizador.bi} onChange={handleChange} />
            </div>
            <div>
                <label>Username:</label>
                <input type="text" name="username" value={utilizador.username} onChange={handleChange} />
            </div>
            <div>
                <label>Password:</label>
                <input type="password" name="password" value={utilizador.password} onChange={handleChange} />
            </div>
            <div>
                <label>Nível de Acesso:</label>
                <input type="text" name="nivelDeAcesso" value={utilizador.nivelDeAcesso} onChange={handleChange} />
            </div>
            <button type="submit">Atualizar Utilizador</button>
        </form>
    );
}
