import React, { useState, useEffect, createRef } from 'react';
import { updateUser, getUsers } from '../store/actions/usersActions';
import { connect } from 'react-redux';

function RedactUser(props) {
    const [user, setUser] = useState({id: null, firstName: "", lastName: "Choose "});

    useEffect(() => {
        setUser(props.user);
    }, [props.user])

    const onNameChange = (event) => setUser({...user, firstName: event.target.value});

    const onLastNameChange = (event) => setUser({...user, lastName: event.target.value});

    function onSaveChanges() {
        if (user != props.user) {
            props.updateUser(user);
        }
    }

    return <div className="userRedact">
        <p>User redaction</p>
        <label>Name:</label> <br />
        <input type="text" value={user.firstName} onChange={onNameChange}></input> <br />
        <label>Last Name:</label> <br />
        <input type="text" value={user.lastName} onChange={onLastNameChange}></input> <br />
        <button type="button" onClick={onSaveChanges}>Save changes</button> <br /> 
    </div>
}


export default connect(null, { updateUser, getUsers })(RedactUser);
