import React, { useState } from 'react';
import axios from 'axios';

const baseURL = "https://localhost:7224/api/Categoria";

export default function Formulario() {
  const [categoria, setCategoria] = useState({ id: "", categoriaNome: "", descricao: "" });
  const [error, setError] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();

    axios.put(`${baseURL}/${categoria.id}`, categoria, {
      headers: {
        'Content-Type': 'application/json'
      }
    })
      .then((response) => {
        console.log('Categoria atualizada:', response);
        setCategoria({ id: "", categoriaNome: "", descricao: "" });
        setError("");
      })
      .catch((error) => {
        console.error('Erro ao atualizar categoria:', error);
        setError('Erro ao atualizar categoria: ' + error.message);
      });
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setCategoria({ ...categoria, [name]: value });
  };

  return (
    <form onSubmit={handleSubmit}>
      <div>
        <label>ID</label>
        <input
          type="text"
          name="id"
          value={categoria.id}
          onChange={handleChange}
          required
        />
      </div>
      <div>
        <label>Nome da Categoria</label>
        <input
          type="text"
          name="categoriaNome"
          value={categoria.categoriaNome}
          onChange={handleChange}
          required
        />
      </div>
      <div>
        <label>Descrição da Categoria</label>
        <input
          type="text"
          name="descricao"
          value={categoria.descricao}
          onChange={handleChange}
          required
        />
      </div>
      <button type="submit">Atualizar Categoria</button>
      {error && <p>{error}</p>}
    </form>
  );
}
