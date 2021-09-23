import React, { useState } from 'react'
import axios from 'axios'

export default function GetJob() {
    const [managerId, setManagerId] = useState("");
    const [shopId, setShopId] = useState("");

    async function sendData(event) {
        event.preventDefault();
        if (managerId.length !== 0 &&
            shopId !== 0) {
            await axios.patch('/api/managers/get-job', {
                managerId: managerId,
                shopId: shopId
            }
            )
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
        <h3>Input manager and shop Id`s to get a job for manager</h3>
        <form onSubmit={sendData}>
            <label>Manager id</label> <br />
            <input type="text" value={managerId} onChange={(e) => setManagerId(e.target.value)}></input> <br />
            <label>Shop id</label> <br />
            <input type="text" value={shopId} onChange={(e) => setShopId(e.target.value)}></input> <br />
            <button>Submit</button>
        </form>
    </div>
}