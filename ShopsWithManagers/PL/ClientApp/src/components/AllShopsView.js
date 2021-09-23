import React from 'react'
import axios from 'axios'

class GetAllShops extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            shops: []
        }

        this.loadShops = this.loadShops.bind(this);
    }

    componentDidMount() {
        this.loadShops();
    }

    async loadShops() {
        await axios.get('/api/shops')
            .then(function (response) {
                this.setState({ shops: response.data });
            }.bind(this))
            .catch(function (error) {
                console.log(error);
            });
    }

    render() {
        let mappedShops = this.state.shops.map((shop) => <span>Shop name: {shop.name}. Address: {shop.address} <br /></span>)

        return <div>
            <h1>Shops:</h1>
            {mappedShops}
        </div>
    }
}

export default GetAllShops;
