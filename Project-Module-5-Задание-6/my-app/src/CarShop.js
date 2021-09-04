import React from 'react';
import './CarShop.css';

let car = function (id, name, type, weight, price) {
    this.id = id;
    this.name = name;
    this.type = type;
    this.weight = weight;
    this.price = price;
}

const carsData = [
    new car(1, "Alfa Romeo", "Station wagon", 2250, 10000),
    new car(2, "Audi", "Hatchback", 3200, 15000),
    new car(3, "BMW", "Station wagon", 1900, 14700),
    new car(4, "KIA", "Minivan", 7000, 4500),
    new car(5, "Lamborghini", "Sportcar", 2100, 250000),
];

class CarShop extends React.Component {

    constructor(props) {
        super(props);

    }

    render() {
        let name = this.props.match.params.name;
        let result = [];
        for (let i = 0; i < carsData.length; i++) {
            let lettersCheck = true;
            for (let j = 0; j < name.length; j++) {
                if (name[j] == carsData[i].name[j] && lettersCheck != false) {
                    lettersCheck = true;
                    continue;
                }

                lettersCheck = false;
            }

            if (lettersCheck) {
                result.push(new car(carsData[i].id, carsData[i].name, carsData[i].type, carsData[i].weight, carsData[i].price));
            }
        }

        if (result.length == 0) {
            let mappedCars = carsData.map(car => <p>{car.name} <br /></p>);

            return <div>
                <h3>Car was not found!</h3>
                {mappedCars}
            </div>
        }

        let mappedResult = result.map((car) => {
            return <p>Id:{car.id} <br /> Name: {car.name} <br /> Type: {car.type} <br /> Weight: {car.weight} <br />Price: {car.price} </p>
        })

        return <div>
            {mappedResult}
        </div>
    }
}
export default CarShop;