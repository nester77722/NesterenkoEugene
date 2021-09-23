import React, { useState } from 'react';
import { postUser, getUsers } from '../store/actions/usersActions';
import { connect } from 'react-redux';

function CreateNewUser(props) {

    const [user, setUser] = useState({ firstName: null, lastName: null });

    function onCreateUser() {
        props.postUser(user);
    }

    const onNameChange = (event) => setUser({ ...user, firstName: event.target.value });

    const onLastNameChange = (event) => setUser({ ...user, lastName: event.target.value });

    return <div>
        <p>User create</p>
        <label>Name:</label> <br />
        <input type="text" onChange={onNameChange}></input> <br />
        <label>Last Name:</label> <br />
        <input type="text" onChange={onLastNameChange}></input> <br />
        <button id="createUserButton" type="button" onClick={onCreateUser}>Create new user</button>
    </div>
}

export default connect(null, { postUser, getUsers })(CreateNewUser);
