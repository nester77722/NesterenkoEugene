import React from 'react'
import './gameStyles.css'

function getRandomInt(min, max) {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min)) + min;
}

class Game extends React.Component {

    constructor(props) {
        super(props);

        this.onButtonClick = this.onButtonClick.bind(this);
        this.getComputerChoice = this.getComputerChoice.bind(this);
    }

    getComputerChoice() {
        let randomComputerChoice = getRandomInt(0, 3);

        switch (randomComputerChoice) {
            case 0:
                return "stone";
            case 1:
                return "scissors";
            case 2:
                return "paper";
        }
    }

    onButtonClick(event) {
        let userChoice = event.currentTarget.id;
        let computerChoice = this.getComputerChoice();

        switch (userChoice) {
            case computerChoice:
                alert("Ничья!");
                break;

            case "stone":
                if (computerChoice == "scissors") {
                    alert("Ты победил!");
                }
                else {
                    alert("Ты проиграл!");
                }
                break;
            case "scissors":
                if (computerChoice == "paper") {
                    alert("Ты победил!");
                }
                else {
                    alert("Ты проиграл!");
                }
                break;
            case "paper":
                if (computerChoice == "stone") {
                    alert("Ты победил!");
                }
                else {
                    alert("Ты проиграл!");
                }
                break;
        }
    }

    render() {
        return <div>
            <h3>Игра</h3>
            <div class="buttons">
                <button id="stone" onClick={this.onButtonClick}>
                    <span>Stone 🗿</span>
                </button>
                <button id="scissors" onClick={this.onButtonClick}>
                    <span>Scissors ✂️    </span>
                </button>
                <button id="paper" onClick={this.onButtonClick}>
                    <span>Paper 🧻</span>
                </button>
            </div>
        </div>
    }
}

export default Game;