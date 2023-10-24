import { UserState, userReducer } from "./reducers/user.reducers";
import * as UserActions from "./actions/user.actions";
import * as UserSelectors from "./selectors/user.selectors";

export interface State {
    user: UserState
}

export { UserActions, UserSelectors, userReducer };