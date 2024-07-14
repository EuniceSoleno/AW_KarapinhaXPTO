import React, { useState } from 'react';
import axios from 'axios';

const baseURL = 'https://localhost:7224/TabelaDeHorario';

export default function EditHorario() {
    const [tabela, setTabela] = useState({ id: "", profissionalNome: "", horaInicio: "", horaFim: "", diaSemana: "" });
    const [error, setError] = useState("");

    const handleSubmit = (e) => {
        e.preventDefault();
    
        axios.put(`${baseURL}/${tabela.id}`, tabela, {
          headers: {
            'Content-Type': 'application/json'
          }
        })
          .then((response) => {
            console.log('Horario atualizado:', response);
            setTabela({ id: "", profissionalNome: "", horaInicio: "", horaFim: "", diaSemana: "" });
            setError("");
          })
          .catch((error) => {
            console.error('Erro ao atualizar Horario:', error);
            setError('Erro ao atualizar categoria: ' + error.message);
          });
    };
    
    const handleChange = (e) => {
        const { name, value } = e.target;
        setTabela({ ...tabela, [name]: value });
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>Nome Profissional</label>
                <input 
                    type="text" 
                    name="profissionalNome"
                    value={tabela.profissionalNome} 
                    onChange={handleChange} 
                />
            </div>

            <div>
                <label>Dia de Semana</label>
                <input 
                    type="text" 
                    name="diaSemana"
                    value={tabela.diaSemana} 
                    onChange={handleChange} 
                />
            </div>

            <div>
                <label>Início</label>
                <input 
                    type="text" 
                    name="horaInicio"
                    value={tabela.horaInicio} 
                    onChange={handleChange} 
                />
            </div>

            <div>
                <label>Fim</label>
                <input 
                    type="text" 
                    name="horaFim"
                    value={tabela.horaFim} 
                    onChange={handleChange} 
                />
            </div>

            <div>
                <label>Id</label>
                <input 
                    type="text" 
                    name="id"
                    value={tabela.id} 
                    onChange={handleChange} 
                />
            </div>

            <button type="submit">Atualizar Horário</button>
            {error && <p>{error}</p>}
        </form>
    );
}
