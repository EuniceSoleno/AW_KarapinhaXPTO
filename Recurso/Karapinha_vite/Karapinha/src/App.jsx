import { useState } from 'react';
import './App.css';
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import Side from './Components/SideBar/Side';
import Marcacaoes from './Components/Marcacoes/Marcacaoes';
import Login from './Components/Login/Login';
import Home from './Home';
import ProtectedRoute from './ProtectedRoute';
import Servico from './Components/Servico/Servico';
import Categoria from './Components/Categoria/Categoria';
import Utilizadores from './Components/Utilizadores/Utilizador';
import TabelaDeHorario from './Components/TabelaDeHorario.jsx/TabeladeHorario';
import Profissionais from './Components/Profissionais/Profissionais';
import Cadastrado from './Components/Cadastrado/Cadastrado';
import Administrativo from './Components/Administrativo/Administrativo';
import Admin from './Components/Admin/Admin';
import Formulario from './Components/Categoria/Formulario';
import UpdateCat from './Components/Categoria/UpdateCat'
import DeleteCat from './Components/Categoria/DeleteCat';
import FormularioServico from './Components/Servico/FormularioServico';
import DeleteServico from './Components/Servico/DeleteServico';
import UpdateteServico from './Components/Servico/UpdateServico';
import FormularioProfissional from './Components/Profissionais/FormularioProfissional';
import UpdateFuncionario from './Components/Profissionais/UpdateFuncionario';
import DeleteFuncionario from './Components/Profissionais/DeleteFuncionario';
import AdicionarUtilizador from './Components/Utilizadores/AdicionarUtilizador';
import EditarUtilizador from './Components/Utilizadores/EditarUtilizador';
import AdicionarMarcacao from './Components/Marcacoes/AdicionarMarcacao';
import Profissional from './Components/Profissionais/Profissional';
function App() {
  return (
    <Router>
      <Routes>
        <Route path="/login" element={<Login />} />
        <Route path="/" element={<Home />} />
        
       {/* <Route path="/side" element={<ProtectedRoute element={<Side />} allowedRoles={['admin']} />} />*/}
        <Route path="/admin" element={<ProtectedRoute element={<Admin />} allowedRoles={['admin']} />} />
        <Route path="/cadastrado" element={<ProtectedRoute element={<Cadastrado />} allowedRoles={['cadastrado']} />} />
        <Route path="/administrativo" element={<ProtectedRoute element={<Administrativo />} allowedRoles={['administrativo']} />} />
        <Route path='/profissional' element={<ProtectedRoute element={<Profissional></Profissional>} allowedRoles={['profissional']}></ProtectedRoute>}></Route>


         {/*ROutas Nao privadas */}
         <Route path='/servico' element={<Servico></Servico>}></Route>
        <Route path='/categoria' element={<Categoria></Categoria>}></Route>
        <Route path='/utilizador' element={<Utilizadores></Utilizadores>}></Route>
        <Route path='/marcacao' element={<Marcacaoes></Marcacaoes>}></Route>
        <Route path='/proficionais' element={<Profissionais></Profissionais>}></Route>
        <Route path='/formulario' element={<Formulario></Formulario>}></Route>
        <Route path='/updatecat' element={<UpdateCat></UpdateCat>}></Route>
        <Route path='/formularioservico' element={<FormularioServico></FormularioServico>}></Route>
        <Route path='/updateservico' element={<UpdateteServico></UpdateteServico>}></Route>
        <Route path='/deleteservico' element={<DeleteServico></DeleteServico>}></Route>
        <Route path='/formularioprofissional' element={<FormularioProfissional></FormularioProfissional>}></Route>
        <Route path='/updatefuncionario' element={<UpdateFuncionario></UpdateFuncionario>}></Route>
        <Route path='/deletefuncionario' element={<DeleteFuncionario></DeleteFuncionario>}></Route>
        <Route path='/adicionarutilizador' element={<AdicionarUtilizador></AdicionarUtilizador>}></Route>
        <Route path='/editarutilizador/:id' element={<EditarUtilizador></EditarUtilizador>}></Route>
        <Route path='/adicionarmarcacao' element={<AdicionarMarcacao></AdicionarMarcacao>}></Route>
      </Routes>
    </Router>
  );
}

export default App;
