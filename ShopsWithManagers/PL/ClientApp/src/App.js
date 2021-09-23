import React from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import GetAllShops from "./components/AllShopsView";
import Navigation from "./Navigation";

import './AppStyles.css'
import MainPage from './main';
import AddManager from './components/AddManager';
import GetJob from './components/GetJob';
import GetSpecificManager from './components/GetSpecificManager';
import DismissManager from './components/DismissManager';
import AllManagers from './components/GetAllManagers';

function App() {
  return (
    <div className="wrapper">
      <BrowserRouter>

        <div className="header">
          <Navigation />
        </div>

        <div className="content">
          <Switch>
            <Route path="/viewshops" component={GetAllShops}></Route>
            <Route path="/" exact component={MainPage}></Route>
            <Route path="/addmanager" component={AddManager}></Route>
            <Route path="/getJob" component={GetJob}></Route>
            <Route path="/getspecificmanager" component={GetSpecificManager}></Route>
            <Route path="/dismissManager" component={DismissManager}></Route>
            <Route path="/getAllManagers" component={AllManagers}></Route>
          </Switch>
        </div>
      </BrowserRouter>

    </div>
  );
}

export default App;
