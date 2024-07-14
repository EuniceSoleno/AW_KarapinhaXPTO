import React, { useState } from 'react';
import axios from 'axios';
import './FormularioProfissional.css';

const baseURL = 'https://localhost:7224/api/Profissional';

export default function FormularioProfissional() {
    const [photo, setPhoto] = useState(null);
    const [photoBase64, setPhotoBase64] = useState(null);
    const [profissionalNome, setProfissionalNome] = useState("");
    const [endereco, setEndereco] = useState("");
    const [telemovel, setTelemovel] = useState("");
    const [bi, setBi] = useState("");
    const [categoriaId, setCategoriaId] = useState("");
    const [password, setPassword] = useState("");
    const [userName, setUserName] = useState("");
    const [nivelDeAcesso, setNivelDeAcesso] = useState("profissional");

   /* const handlePhotoChange = (event) => {
        const file = event.target.files[0];
        if (file) {
            const reader = new FileReader();
            reader.onloadend = () => {
                setPhoto(reader.result);
                const base64String = reader.result.split(',')[1];
                setPhotoBase64(base64String);
            };
            reader.readAsDataURL(file);
        }
    };*/

    const handleSubmit = (e) => {
        e.preventDefault();

        const novoFuncionario = {
            id: 0,
            profissionalNome,
            endereco,
            telemovel,
            bi,
            password,
            categoriaId: parseInt(categoriaId),
            userName,
            nivelDeAcesso,
           /* photoBase64 */
        };

        axios.post(baseURL, novoFuncionario)
            .then((response) => {
                console.log('Profissional adicionado:', response);
                // Limpar o formulário
                setProfissionalNome("");
                setEndereco("");
                setTelemovel("");
                setBi("");
                setPassword("");
                setCategoriaId("");
                setUserName("");
                setNivelDeAcesso("profissional");
                /*setPhoto(null);
                setPhotoBase64(null);*/
            })
            .catch((error) => {
                console.error('Erro ao adicionar profissional:', error);
            });
    };

    return (
        <form className="form-container" onSubmit={handleSubmit}>
          {/*  <div className="form-group">
                <label htmlFor="photo">Foto: </label>
                <input type="file" accept="image/*" onChange={handlePhotoChange} />
                {photo && <img src={photo} alt="Preview" className="photo-preview" />}
            </div>*/}

            <div className="form-group">
                <label htmlFor="profissionalNome">Nome Funcionario: </label>
                <input type="text" name="profissionalNome" value={profissionalNome} onChange={(e) => setProfissionalNome(e.target.value)} />
            </div>

            <div className="form-group">
                <label htmlFor="endereco">Endereco: </label>
                <input type="text" name="endereco" value={endereco} onChange={(e) => setEndereco(e.target.value)} />
            </div>

            <div className="form-group">
                <label htmlFor="telemovel">Contacto: </label>
                <input type="text" name="telemovel" value={telemovel} onChange={(e) => setTelemovel(e.target.value)} />
            </div>

            <div className="form-group">
                <label htmlFor="bi">BI: </label>
                <input type="text" name="bi" value={bi} onChange={(e) => setBi(e.target.value)} />
            </div>

            <div className="form-group">
                <label htmlFor="password">Password: </label>
                <input type="password" name="password" value={password} onChange={(e) => setPassword(e.target.value)} />
            </div>

            <div className="form-group">
                <label htmlFor="categoriaId">Categoria_ID: </label>
                <input type="text" name="categoriaId" value={categoriaId} onChange={(e) => setCategoriaId(e.target.value)} />
            </div>

            <div className="form-group">
                <label htmlFor="userName">Username: </label>
                <input type="text" name="userName" value={userName} onChange={(e) => setUserName(e.target.value)} />
            </div>

            <div className="form-group">
                <label htmlFor="nivelDeAcesso">Nível de Acesso: </label>
                <input type="text" name="nivelDeAcesso" value={nivelDeAcesso} onChange={(e) => setNivelDeAcesso(e.target.value)} />
            </div>

            <button type="submit" className="submit-button">Enviar</button>
        </form>
    );
}
