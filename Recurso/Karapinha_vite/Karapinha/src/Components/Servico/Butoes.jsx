import React from 'react'
import { Link } from 'react-router-dom';

export default function Butoes() {
  return (
    <div> 
    <Link to="/formularioservico"><button>Adicionar Servico</button></Link>
    <Link to="/updateservico"><button>Actualizar Servico</button></Link>
    <Link to="/deleteservico"><button>Remover Servico</button></Link>
    </div>
  )
}
