import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
import './Tabela.css'
const baseURL = 'https://localhost:7224/api/Categoria';

export default function Categoria() {
    const [cat, setCat] = useState([]);
    const [error, setError] = useState(null);

    useEffect(() => {
        axios.get(baseURL)
            .then((response) => {
                console.log('Resposta da API:', response);
                setCat(response.data);
            })
            .catch((error) => {
                console.error('Erro ao buscar categorias:', error);
                setError('Erro ao buscar categorias');
            });
    }, []);

    if (error) return <div>{error}</div>;
    if (!cat.length) return <div>Loading...</div>;

    console.log('Dados das categorias:', cat);

    return (
        <div>
            <table>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Nome da Categoria</th>
                        <th>Descrição da Categoria</th>
                    </tr>
                </thead>
                <tbody>
                    {cat.map((categoria) => (
                        <tr key={categoria.id}>
                            <td>{categoria.id}</td>
                            <td>{categoria.categoriaNome}</td>
                            <td>{categoria.descricao}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
            <div>
                <Link to="/formulario">
                    <button>Adicionar Categoria</button>
                </Link>
                <Link to="/updatecat">
                    <button>Atualizar Categoria</button>
                </Link>
                <Link to="/delete">
                    <button>Remover Categoria</button>
                </Link>
            </div>
        </div>
    );
}
