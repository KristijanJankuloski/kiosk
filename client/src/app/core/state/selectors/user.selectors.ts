import { createFeatureSelector, createSelector } from "@ngrx/store";
import { UserState } from "../reducers/user.reducers";

const getUserFeatureState = createFeatureSelector<UserState>("user");

export const getCurrentUser = createSelector(getUserFeatureState, state => state.currentUser);