import React from 'react';
import { Outlet } from 'react-router-dom';

const Layout = () => {
  return (
    <div>
      <header>
        {/* Aqui você pode colocar um cabeçalho ou uma barra de navegação */}
        <h1>My Application</h1>
      </header>
      <main>
        <Outlet /> {/* Aqui o conteúdo das rotas aninhadas será renderizado */}
      </main>
      <footer>
        {/* Rodapé opcional */}
        <p>Footer Content</p>
      </footer>
    </div>
  );
};

export default Layout;
