import React, { Component } from 'react'
import {connect} from 'react-redux'
import {getUsers, deleteUser} from '../store/actions/usersActions'

 class users extends Component {
    componentDidMount(){
        this.props.getUsers();
    }

    ondeleteUser(id){
        debugger;
        this.props.deleteUser(id);
    }

    render() {
        const {users} = this.props.users
        console.log(users)
        
        return (
            <div>
                {users.map(u => 
                     <React.Fragment key={u.id}>
                         <h6 >{u.firstName} {u.lastName}</h6> 
                     <button onClick={()=>this.ondeleteUser(u.id)}>-</button>
                     </React.Fragment>
                )}
            </div>
        )
    }
}

const mapStateToProps  = (state) => ({users:state.users});

export default connect(mapStateToProps, {getUsers, deleteUser})(users);