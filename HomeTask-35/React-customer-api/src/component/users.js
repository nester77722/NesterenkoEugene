import React, { Component, useRef } from 'react'
import { connect } from 'react-redux'
import { getUsers, deleteUser } from '../store/actions/usersActions'
import RedactUser from './redactUser'
import CreateNewUser from './createNewUser'

class users extends Component {
    constructor(props) {
        super(props);

        this.state = { selectedUser: {} };
        this.userSelected = this.userSelected.bind(this);
    }

    componentDidMount() {
        this.props.getUsers();
    }

    componentDidUpdate(){
        this.props.getUsers();
    }

    ondeleteUser(id) {
        this.props.deleteUser(id);
    }

    userSelected(user) {
        this.setState({ selectedUser: user });
    }

    render() {
        const { users } = this.props.users;
        console.log(users);

        return (
            <div className="allUsers">
                <RedactUser user={this.state.selectedUser} />
                <CreateNewUser />
                <br /><br /><label id="title">Click on name of user to redact</label> <br />
                {users.map(u =>
                    <React.Fragment key={u.id}>
                        <button onClick={() => this.userSelected(u)}>Name: {u.firstName} Last Name: {u.lastName} </button>
                        <button onClick={() => this.ondeleteUser(u.id)}>-</button> <br />
                    </React.Fragment>
                )}
            </div>
        )
    }
}

const mapStateToProps = (state) => ({ users: state.users });

export default connect(mapStateToProps, { getUsers, deleteUser })(users);