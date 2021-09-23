import axios from 'axios';
import React from 'react'

class GetSpecificManager extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            id: null,
            manager:{
                name: null,
                status: null,
                currentShopId: null,
                workingHistory: []
            }
        }

        this.handleInputChange = this.handleInputChange.bind(this);
        this.onSubmit = this.onSubmit.bind(this);
    }

    async onSubmit() {
        if (this.state.id.length != 0) {
            await axios.get('/api/managers/get-specific-manager', {
                params: {
                    managerId: this.state.id
                }
            })
                .then(function (response) {
                    this.setState({ manager: response.data.manager });
                }.bind(this))
                .catch(function (error) {
                    if (error.response) {
                        console.log(error.response.data);
                        console.log(error.response.status);
                        console.log(error.response.headers);
                    } else if (error.request) {
                        console.log(error.request);
                    } else {
                        console.log('Error', error.message);
                    }
                    console.log(error.config);
                });
        }
    }

    handleInputChange(event) {
        this.setState({ id: event.target.value });
    }


    render() {
        let counter = 0;
        let mappedWorkingHistory = this.state.manager.workingHistories?.map(
            (historyLog) => {
                counter = counter + 1;
                return <div>
                    <span>Job №{counter}</span> <br />
                    <span>Shop id: {historyLog.shopId}</span> <br />
                    <span>Started working at: {historyLog.startedWorkingAt}</span> <br />
                    <span>Stopped working at: {historyLog.stoppedWorkingAt}</span> <br />
                </div>
            }
        )
        return <div>
            <h3>Input manager id to show his info</h3>
            <input type="text" value={this.state.id} onChange={this.handleInputChange}></input>
            <button onClick={this.onSubmit}>Get Manager Info</button>
            <h3>Id: {this.state.id}</h3>
            <h3>Name: {this.state.manager.name}</h3>
            <h3>Status: {this.state.manager.status}</h3>
            <h3>Current Shop Id: {this.state.manager.currentShopId}</h3>
            <h3>Working history: <br /> {mappedWorkingHistory}</h3>
        </div>
    }
}

export default GetSpecificManager;
