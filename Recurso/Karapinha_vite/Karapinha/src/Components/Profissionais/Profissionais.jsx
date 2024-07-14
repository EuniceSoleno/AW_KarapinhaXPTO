import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link, useNavigate } from 'react-router-dom';

const baseURL = 'https://localhost:7224/api/Profissional';

function Profissionais() {
    const [profissionais, setProfissionais] = useState([]);
    const [error, setError] = useState(null);
    const navigate = useNavigate();

    useEffect(() => {
        axios.get(baseURL)
            .then((response) => {
                console.log('Resposta da API:', response);
                setProfissionais(response.data);
            })
            .catch((error) => {
                console.error('Erro ao buscar Profissionais:', error);
                setError('Erro ao buscar profissionais');
            });
    }, []);

    if (error) return <div>{error}</div>;
    if (!profissionais.length) return <div>Loading...</div>;

    console.log('Dados dos Profissionais:', profissionais);

    return (
        <div>
            
            <table>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Categoria</th>
                        <th>Nome do Funcionário</th>
                        <th>Endereço</th>
                        <th>Contato</th>
                        <th>BI</th>
                    </tr>
                </thead>
                <tbody>
                    {profissionais.map((prof) => (
                        <tr key={prof.id}>
                            <td>{prof.id}</td>
                            <td>{prof.categoriaId}</td>
                            <td>{prof.profissionalNome}</td>
                            <td>{prof.endereco}</td>
                            <td>{prof.telemovel}</td>
                            <td>{prof.bi}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
            <div>
                <Link to="/formularioprofissional">
                    <button>Adicionar Profissional</button>
                </Link>
                <Link to="/updatefuncionario">
                    <button>Atualizar Profissional</button>
                </Link>
                <Link to="/deletefuncionario">
                    <button>Remover Profissional</button>
                </Link>
            </div>
        </div>
    );
}

export default Profissionais;
