import React from 'react';
import { Link } from 'react-router-dom';
import Servico from '../Servico/Servico';
/*import './Side.css';*/
const Side = () => {
  return (
    <nav className='sidebar'>
      <ul>       
        <li><Link to="/categoria">Categoria</Link></li>
        <li><Link to="/servico">Servico</Link></li>
        <li><Link to="/proficionais">Profissionais</Link></li>
       {/* <li><Link to='/utilizador'>Utilizadores</Link></li>*/}
        <li><Link to="/marcacao">Marcacoes</Link></li>
       {/* <li><Link to="/tabeladehorario">Tabela de Horarios</Link></li>*/}
      </ul>
    </nav>
  );
}

export default Side;
