import React, { useState } from 'react';
import axios from 'axios';

function AddManager() {
    const [name, setName] = useState("");
    const [status, setStatus] = useState("");
    const [currentShopId, setCurrentShopId] = useState("");

    async function sendData(event){
        event.preventDefault();
        await axios.post('/api/managers/add-manager', { Name: name, Status: status, CurrentShopId: currentShopId })
        .then(function(response){
            alert(response.data.message);
        })
        .catch(function(error){
            console.log(error);
        })
    }

    return <div>
        <form onSumbmit={sendData}>
            <label>Input name:</label> <br />
            <input type="text" value={name} onChange={(e) => setName(e.target.value)}></input><br />
            <label>Input status:</label> <br />
            <input type="text" value={status} onChange={(e) => setStatus(e.target.value)}></input><br />
            <label>Input shop Id:</label> <br />
            <input type="text" value={currentShopId} onChange={(e) => setCurrentShopId(e.target.value)}></input><br />
            <button onClick={sendData}>Submit</button>
        </form>
    </div>
}

export default AddManager;
