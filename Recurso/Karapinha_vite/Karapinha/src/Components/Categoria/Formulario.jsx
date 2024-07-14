import React, { useState } from 'react';
import axios from 'axios';

const baseURL = "https://localhost:7224/api/Categoria";

export default function Formulario() {
  const [cat, setCat] = useState([]);
  const [categoriaNome, setcategoriaNome] = useState("");
  const [id, setId] = useState("");
  const [descricao, setDescricao] = useState("");
  const [error, setError] = useState(null);

  const handleSubmit = (e) => {
    e.preventDefault();

    const novaCategoria = {
      categoriaNome,
      descricao
    };

    axios.post(baseURL, JSON.stringify(novaCategoria), {
      headers: {
        'Content-Type': 'application/json'
      }
    })
      .then((response) => {
        console.log('Categoria adicionada:', response);
        setCat([...cat, response.data]);
        setcategoriaNome("");
        setDescricao(""); 
        setError(null);
      })
      .catch((error) => {
        console.error('Erro ao adicionar categoria:', error);
        setError('Erro ao adicionar categoria');
      });
  };

  return (
    <form onSubmit={handleSubmit}>
      <div>
        <label>ID</label>
        <input
          type="text"
          value={id}
          onChange={(e) => setId(e.target.value)}
          required
        />
      </div>
      <div>
        <label>Nome da Categoria</label>
        <input
          type="text"
          value={categoriaNome}
          onChange={(e) => setcategoriaNome(e.target.value)}
          required
        />
      </div>
      <div>
        <label>Descrição da Categoria</label>
        <input
          type="text"
          value={descricao}
          onChange={(e) => setDescricao(e.target.value)}
          required
        />
      </div>
      <button type="submit">Adicionar Categoria</button>
      {error && <p>{error}</p>}
    </form>
  );
}
