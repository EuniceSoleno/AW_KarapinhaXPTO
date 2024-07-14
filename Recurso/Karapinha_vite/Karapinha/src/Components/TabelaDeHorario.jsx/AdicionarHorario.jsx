import React, { useState } from 'react';
import axios from 'axios';

const baseURL = 'https://localhost:7224/TabelaDeHorario';

export default function AdicionarHorario() {
    const [profissionalNome, setProfissionalNome] = useState("");
    const [horaInicio, setHoraInicio] = useState("");
    const [horaFim, setHoraFim] = useState("");
    const[id,setId] = useState("");
    const[dia,setDia] = useState("");
    const [error, setError] = useState(null);

    const handleSubmit = (e) => {
        e.preventDefault();
    
        const novoHorario = {
            profissionalNome,
            horaInicio,
            horaFim,
            dia
        };
    
        axios.post(baseURL, JSON.stringify(novoHorario), {
          headers: {
            'Content-Type': 'application/json'
          }
        })
          .then((response) => {
            console.log('Horario adicionado:', response);
            setProfissionalNome("");
            setHoraInicio(""); 
            setHoraFim("");
            setError(null);
          })
          .catch((error) => {
            console.error('Erro ao adicionar Horario:', error);
            setError('Erro ao adicionar categoria');
          });
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>Nome Profissional</label>
                <input 
                    type="text" 
                    value={profissionalNome} 
                    onChange={(e) => setProfissionalNome(e.target.value)} 
                />
            </div>

            <div>
                <label>Dia de Semana</label>
                <input 
                    type="text" 
                    value={dia} 
                    onChange={(e) => setId(e.target.value)} 
                />
            </div>

            <div>
                <label>Início</label>
                <input 
                    type="text" 
                    value={horaInicio} 
                    onChange={(e) => setHoraInicio(e.target.value)} 
                />
            </div>

            <div>
                <label>Fim</label>
                <input 
                    type="text" 
                    value={horaFim} 
                    onChange={(e) => setHoraFim(e.target.value)} 
                />
            </div>

            <div>
                <label>Id</label>
                <input 
                    type="text" 
                    value={id} 
                    onChange={(e) => setId(e.target.value)} 
                />
            </div>

            


            <button type="submit">Adicionar Horário</button>
            {error && <p>{error}</p>}
        </form>
    )
}
