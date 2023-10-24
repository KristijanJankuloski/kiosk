import { createAction, props } from "@ngrx/store";
import { UserModel } from "../../models/user.model";

export const setCurrentUser = createAction("[User] Set current user", props<{user: UserModel}>());