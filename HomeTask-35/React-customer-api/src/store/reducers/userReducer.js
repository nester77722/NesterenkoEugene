import {DELETE_USER, GET_USERS} from '../types'

const initialState = {
    users:[],
    loading:true
}

export default function(state = initialState, action){
    debugger;
    switch(action.type){

        case GET_USERS:
        return {
            ...state,
            users:action.payload,
            loading:false

        }
        case DELETE_USER:
            return {
                ...state,
                users:state.users.filter(({ id }) => id !== action.payload),
                loading:false
            }
        default: return state
    }
}