import React from 'react';
import 'react-date-picker/dist/DatePicker.css';
import './registrationStyles.css'

class Registration extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            name: null,
            secondName: null,
            middleName: null,
            isNameValid: false,
            isSecondNameValid: false,
            isMiddleNameValid: false,
        }

        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleNameChange = this.handleNameChange.bind(this);
        this.handleSecondNameChange = this.handleSecondNameChange.bind(this);
        this.handleMiddleNameChange = this.handleMiddleNameChange.bind(this);
    }

    handleSubmit() {
        if(this.state.isNameValid 
            && this.state.isSecondNameValid
            && this.state.isMiddleNameValid){
            alert("Успешная регистрация!");
        }
        else{
            alert("Регистрация не удалась!. Проверьте вводимые данные");
        }
    }

    handleNameChange(event) {
        if (event.target.value.length > 0) {
            this.setState({ name: event.target.value });
            this.setState({ isNameValid: true });
        }
        else {
            this.setState({ isNameValid: false });
        }
    }

    handleSecondNameChange(event) {
        if (event.target.value.length > 0) {
            this.setState({ secondName: event.target.value });
            this.setState({ isSecondNameValid: true });
        }
        else {
            this.setState({ isSecondNameValid: false });
        }
    }

    handleMiddleNameChange(event) {
        if (event.target.value.length > 0) {
            this.setState({ middleName: event.target.value });
            this.setState({ isMiddleNameValid: true });
        }
        else {
            this.setState({ isMiddleNameValid: false });
        }
    }

    render() {
        return <form class="registrationFormClass" onSubmit={this.handleSubmit}>
            <h3>Введите свои данные:</h3> <br />
            <>
                <label>Имя:</label><br />
                <input type="text" value={this.state.name} onChange={this.handleNameChange}></input>
            </>
            <>
                <br /><label>Отчество:</label><br />
                <input type="text" value={this.state.middleName} onChange={this.handleMiddleNameChange}></input>
            </>
            <>
                <br /><label>Фамилия:</label><br />
                <input type="text" value={this.state.secondName} onChange={this.handleSecondNameChange}></input>
            </>
         
            <>
                <br /><input type="submit"></input>
            </>
        </form>

    }
}

export default Registration;
