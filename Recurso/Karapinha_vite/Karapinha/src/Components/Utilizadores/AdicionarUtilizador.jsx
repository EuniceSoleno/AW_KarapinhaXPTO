// FormularioUtilizador.jsx
import React, { useState } from 'react';
import axios from 'axios';

const baseURL = 'https://localhost:7224/api/Utilizador';

export default function AdicionarUtilizador() {
    const [photo, setPhoto] = useState('');
    const [nomeCompleto, setNomeCompleto] = useState('');
    const [endereco, setEndereco] = useState('');
    const [telemovel, setTelemovel] = useState('');
    const [bi, setBi] = useState('');
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [nivelDeAcesso, setNivelDeAcesso] = useState('');

    const handlePhotoChange = (event) => {
        const file = event.target.files[0];
        if (file) {
            const reader = new FileReader();
            reader.onload = () => {
                setPhoto(reader.result);
            };
            reader.readAsDataURL(file);
        }
    };

    const handleSubmit = (e) => {
        e.preventDefault();

        const novoUtilizador = {
            photo,
            nomeCompleto,
            endereco,
            telemovel,
            bi,
            username,
            password,
            nivelDeAcesso
        };

        axios.post(baseURL, novoUtilizador)
            .then((response) => {
                console.log('Utilizador adicionado:', response);
                // Redefinir o estado do formulário
                setPhoto('');
                setNomeCompleto('');
                setEndereco('');
                setTelemovel('');
                setBi('');
                setUsername('');
                setPassword('');
                setNivelDeAcesso('');
            })
            .catch((error) => {
                console.error('Erro ao adicionar utilizador:', error);
            });
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>Foto:</label>
                <input type="file" accept="image/*" onChange={handlePhotoChange} />
                {photo && <img src={photo} alt="Preview" style={{ width: '100px' }} />}
            </div>
            <div>
                <label>Nome Completo:</label>
                <input type="text" value={nomeCompleto} onChange={(e) => setNomeCompleto(e.target.value)} />
            </div>
            <div>
                <label>Endereço:</label>
                <input type="text" value={endereco} onChange={(e) => setEndereco(e.target.value)} />
            </div>
            <div>
                <label>Telemóvel:</label>
                <input type="text" value={telemovel} onChange={(e) => setTelemovel(e.target.value)} />
            </div>
            <div>
                <label>BI:</label>
                <input type="text" value={bi} onChange={(e) => setBi(e.target.value)} />
            </div>
            <div>
                <label>Username:</label>
                <input type="text" value={username} onChange={(e) => setUsername(e.target.value)} />
            </div>
            <div>
                <label>Password:</label>
                <input type="password" value={password} onChange={(e) => setPassword(e.target.value)} />
            </div>
            <div>
                <label>Nível de Acesso:</label>
                <input type="text" value={nivelDeAcesso} onChange={(e) => setNivelDeAcesso(e.target.value)} />
            </div>
            <button type="submit">Adicionar Utilizador</button>
        </form>
    );
}
