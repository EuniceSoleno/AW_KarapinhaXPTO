import axios from 'axios';
import React, { useState, useEffect } from 'react';
import './FormularioServico'
import Butoes from './Butoes';


const baseURL = 'https://localhost:7224/api/Servico';
export default function Servico() {
    const [servico, setservico] = useState([]);
    const [error, setError] = useState(null);

    useEffect(() => {
        axios.get(baseURL)
            .then((response) => {
                console.log('Resposta da API:', response);
                setservico(response.data);
            })
            .catch((error) => {
                console.error('Erro ao buscar categorias:', error);
                setError('Erro ao buscar categorias');
            });
    }, []);

    if (error) return <div>{error}</div>;
    if (!servico.length) return <div>Loading...</div>;

    return (
        <div>
            <table>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Servico</th>
                        <th>Preco</th>
                        <th>CategoriaId</th>
                    </tr>
                </thead>
                <tbody>
                    {servico.map((servico) => (
                        <tr key={servico.id}>
                            <td>{servico.id}</td>
                            <td>{servico.servicoNome}</td>
                            <td>{servico.preco}</td>
                            <td>{servico.categoriaId}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
           <Butoes></Butoes>
        </div>
    );
}
