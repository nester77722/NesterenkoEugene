import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import { BrowserRouter, Switch, Route } from 'react-router-dom'
import Registration from './Registration'
import App from './Main';
import Nav from './Nav';
import CarShop from './CarShop';
import Game from './game'

ReactDOM.render(
  <BrowserRouter>
    <div className="body">
      <Nav />
      <div id="component-body-style">
        <Switch >
          <Route path="/" exact component={App} />
          <Route path="/register" component={Registration} />
          <Route path="/game" component={Game} />
          <Route path="/Cars/:name" component={CarShop} />
        </Switch>
      </div>
    </div>
  </BrowserRouter >,
  document.getElementById('root')
);
