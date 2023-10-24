import { createReducer, on } from "@ngrx/store";
import { UserModel } from "../../models/user.model";
import * as actions from "../actions/user.actions";

export interface UserState {
    currentUser: UserModel
}

const initialState: UserState = {
    currentUser: null
}

export const userReducer = createReducer<UserState>(
    initialState,
    on(actions.setCurrentUser, (state, action) => {
        return {
            ...state,
            currentUser: action.user
        }
    })
)