import React, { useState } from 'react';
import axios from 'axios';

export default function DismissManager() {
    const [managerIdFromInput, setManagerId] = useState("");

    async function onSubmit(event) {
        event.preventDefault();
        if (managerIdFromInput.length != 0) {
            await axios.delete('/api/managers/dismiss?managerId=' + managerIdFromInput)
                .then(function (response) {
                    console.log(response.data);
                })
                .catch(function (error) {
                    if (error.response) {
                        // Request made and server responded
                        console.log(error.response.data);
                        console.log(error.response.status);
                        console.log(error.response.headers);
                    } else if (error.request) {
                        // The request was made but no response was received
                        console.log(error.request);
                    } else {
                        // Something happened in setting up the request that triggered an Error
                        console.log('Error', error.message);
                    }
                })
        }

    }

    return <div>
        <h3>Input manager id to dismiss him</h3> <br />
        <input type="text" value={managerIdFromInput} onChange={(e) => setManagerId(e.target.value)}></input>
        <button onClick={onSubmit}>Dismiss manager</button>
    </div>
}