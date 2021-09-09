import {GET_USERS, USERS_ERROR, DELETE_USER} from '../types'
import axios from 'axios'

export const getUsers = () => async dispatch => {
    
    try{
        const res = await axios.get(`https://localhost:44310/Customers`)
        dispatch( {
            type: GET_USERS,
            payload: res.data
        })
    }
    catch(e){
        dispatch( {
            type: USERS_ERROR,
            payload: console.log(e),
        })
    }
}

export const deleteUser = (id) => async (dispatch) => {
    try{
        debugger;
        await axios.delete(`https://localhost:44310/Customers/${id}`)

        dispatch({
            type: DELETE_USER,
            payload: id
        })
    }
    catch(e){
        dispatch({
            type: USERS_ERROR,
            payload: console.log(e),
        })
    }
}