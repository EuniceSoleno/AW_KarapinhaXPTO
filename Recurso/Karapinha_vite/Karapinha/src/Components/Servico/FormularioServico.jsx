import React, { useState } from 'react';
import axios from 'axios';

const baseURL = 'https://localhost:7224/api/Servico';

export default function FormularioServico() {
  const [servico, setServico] = useState([]);
  const [error, setError] = useState(null);
  const [id, setId] = useState("");
  const [servicoNome, setServicoNome] = useState("");
  const [preco, setPreco] = useState("");
  const [categoriaId, setCategoriaId] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();

    const novaCategoria = {
      servicoNome,
      preco,
      categoriaId
    };

    axios.post(baseURL, novaCategoria)
      .then((response) => {
        console.log('Categoria adicionada:', response);
        setServico([...servico, response.data]);
        setServicoNome("");
        setPreco("");
        setCategoriaId("");
      })
      .catch((error) => {
        console.error('Erro ao adicionar servico:', error);
        setError('Erro ao adicionar servico');
      });
  };

  return (
    <form onSubmit={handleSubmit}>
      <div>
        <label htmlFor="nomeServico">Nome Servico: </label>
        <input type="text" value={servicoNome} onChange={(e) => setServicoNome(e.target.value)} />
      </div>

      <div>
        <label htmlFor="idcategoria">IdCategoria: </label>
        <input type="text" value={categoriaId} onChange={(e) => setCategoriaId(e.target.value)} />
      </div>

      <div>
        <label htmlFor="idServico">IdServico: </label>
        <input type="text" value={id} onChange={(e) => setId(e.target.value)} />
      </div>
      
      <div>
        <label htmlFor="preco">Preco: </label>
        <input type="text" value={preco} onChange={(e) => setPreco(e.target.value)} />
      </div>

      <button type="submit">Adicionar Servico</button>
    </form>
  );
}
