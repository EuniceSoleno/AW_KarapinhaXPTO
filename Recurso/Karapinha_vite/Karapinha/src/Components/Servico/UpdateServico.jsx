import React, { useState } from 'react';
import axios from 'axios';

const baseURL = 'https://localhost:7224/api/Servico';

export default function UpdateServico() {
  const [servico, setServico] = useState({ id: "", servicoNome: "", preco: "", categoriaId: "" });
  const [error, setError] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();

    axios.put(`${baseURL}/${servico.id}`, servico, {
      headers: {
        'Content-Type': 'application/json'
      }
    })
      .then((response) => {
        console.log('Serviço atualizado:', response);
        setServico({ id: "", servicoNome: "", preco: "", categoriaId: "" });
        setError("");
      })
      .catch((error) => {
        console.error('Erro ao atualizar serviço:', error);
        setError('Erro ao atualizar serviço: ' + error.message);
      });
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setServico({ ...servico, [name]: value });
  };

  return (
    <form onSubmit={handleSubmit}>
      <div>
        <label htmlFor="idServico">ID Serviço: </label>
        <input
          type="text"
          name="id"
          value={servico.id}
          onChange={handleChange}
          required
        />
      </div>

      <div>
        <label htmlFor="nomeServico">Nome Serviço: </label>
        <input
          type="text"
          name="servicoNome"
          value={servico.servicoNome}
          onChange={handleChange}
          
        />
      </div>

      <div>
        <label htmlFor="preco">Preço: </label>
        <input
          type="text"
          name="preco"
          value={servico.preco}
          onChange={handleChange}
          
        />
      </div>

      <div>
        <label htmlFor="idcategoria">ID Categoria: </label>
        <input
          type="text"
          name="categoriaId"
          value={servico.categoriaId}
          onChange={handleChange}
          
        />
      </div>

      <button type="submit">Atualizar Serviço</button>
      {error && <p>{error}</p>}
    </form>
  );
}
