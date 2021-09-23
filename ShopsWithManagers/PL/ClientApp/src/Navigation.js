import React from 'react';
import { Link } from 'react-router-dom';

class Navigation extends React.Component {
    render() {
        return <nav>
            <Link to="/viewshops"><button>All Shops</button></Link>
            <Link to="/addmanager"><button>Add New Manager</button></Link>
            <Link to="/getJob"><button>Get Job For Manager</button></Link>
            <Link to="/getspecificmanager"><button>Get Specific Manager</button></Link>
            <Link to="/dismissManager"><button>Dismiss Manager</button></Link>
            <Link to="/getAllManagers"><button>Get all managers</button></Link>
        </nav>
    }
}

export default Navigation;
