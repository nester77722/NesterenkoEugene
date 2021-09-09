import { GET_USERS, USERS_ERROR, UPDATE_USER, DELETE_USER, POST_USER } from '../types'
import axios from 'axios'

export const getUsers = () => async dispatch => {

    try {
        const res = await axios.get(`https://localhost:44310/Customers`)
        dispatch({
            type: GET_USERS,
            payload: res.data
        })
    }
    catch (e) {
        dispatch({
            type: USERS_ERROR,
            payload: console.log(e),
        })
    }
}

export const updateUser = (user) => async (dispatch) => {
    try {
        await axios.patch(`https://localhost:44310/Customers`, user);
        dispatch({
            type: UPDATE_USER,
            payload: user
        })
    }
    catch (e) {
        dispatch({
            type: USERS_ERROR,
            payload: console.log(e),
        })
    }
}

export const postUser = (user) => async (dispatch) => {
    try {
        await axios.post(`https://localhost:44310/Customers`, user);
        dispatch({
            type: POST_USER,
            payload: user
        })
    }
    catch (e) {
        dispatch({
            type: USERS_ERROR,
            payload: console.log(e),
        })
    }
}

export const deleteUser = (id) => async (dispatch) => {
    try {
        await axios.delete(`https://localhost:44310/Customers/${id}`)

        dispatch({
            type: DELETE_USER,
            payload: id
        })
    }
    catch (e) {
        dispatch({
            type: USERS_ERROR,
            payload: console.log(e),
        })
    }
}