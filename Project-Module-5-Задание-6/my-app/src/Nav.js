import React from 'react';
import { Link } from 'react-router-dom';

class Nav extends React.Component {
    render() {
        return <nav id="header">
            <button> <Link to="/register">Регистрация</Link> </button>
            <button> <Link exact to="/">Главная</Link></button>
            <button> <Link to="/game">Камень-Ножницы-Бумага</Link> </button>
            <button> <Link to="/Cars/:name">Машины</Link> </button>
        </nav>
    }
}

export default Nav;
