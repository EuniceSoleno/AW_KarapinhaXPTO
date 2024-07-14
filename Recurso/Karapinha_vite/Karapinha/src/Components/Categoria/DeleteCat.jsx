import React, { useState } from 'react';
import axios from 'axios';

const baseURL = "https://localhost:7224/api/Categoria";

export default function DeleteCat() {
  const [categoria, setCategoria] = useState({ id: "" });
  const [error, setError] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();

    axios.delete(`${baseURL}/${categoria.id}`)
      .then((response) => {
        console.log('Categoria eliminada:', response);
        setCategoria({ id: "" }); 
        setError(""); 
      })
      .catch((error) => {
        console.error('Erro ao eliminar categoria:', error);
        setError('Erro ao eliminar categoria');
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
      <button type="submit">Eliminar Categoria</button>
      {error && <p>{error}</p>}
    </form>
  );
}
