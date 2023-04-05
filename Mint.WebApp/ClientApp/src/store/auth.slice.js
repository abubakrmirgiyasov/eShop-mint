import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { fetchWrapper } from "../helpers/fetchWrapper";

const name = "authentication";
const initialState = createInitialState();
const reducers = createReducers();
const extraActions = createExtraActions();
const extraReducers = createExtraReducers();
const slice = createSlice({
  name,
  initialState,
  reducers,
  extraActions,
  extraReducers,
});

export const authActions = {...slice.actions, ...extraActions };
export const authReducer = slice.reducer;

function createInitialState() {
  return {
    user: JSON.parse(localStorage.getItem("user")),
    error: null,
  };
}

function createReducers() {
  return {
    hasError,
    clearError,
    logout,
  };

  function hasError(state, error) {
    state.error = error.payload;
  }

  function clearError(state) {
    state.error = null;
  }

  function logout(state) {
    state.user = null;
    localStorage.removeItem("user");
  }
}

function createExtraActions() {
  const baseUrl = `api/users`;

  return {
    login: login(),
    refresh: refresh(),
    logout: logout(),
  };

  function login() {
    return createAsyncThunk(
      `${name}/login`,
      async ({ username, password }) =>
        await fetchWrapper.post(`${baseUrl}/login`)
    );
  }

  function refresh() {
    return createAsyncThunk(
      `${name}/refresh-token`,
      async () => await fetchWrapper.post(`${baseUrl}/refresh-token`)
    );
  }

  function logout() {
    return createAsyncThunk(
      `${name}/revoke-token`,
      async () =>
        await fetchWrapper.post(`${baseUrl}/revoke-token`, { token: null })
    );
  }
}

function createExtraReducers() {
  return {
    ...login(),
    ...refresh(),
    ...logout(),
  };

  function login() {
    var { pending, fulFilled, rejected } = extraActions.login;

    return {
      [pending]: (state) => {
        state.error = null;
      },
      [fulFilled]: (state, action) => {
        const user = action.payload;
        localStorage.setItem("user", JSON.stringify(user));
        state.user = user;
      },
      [rejected]: (state, action) => {
        state.error = action.error;
      },
    };
  }

  function refresh() {
    var { pending, fulFilled, rejected } = extraActions.login;

    return {
      [pending]: (state) => {
        state.error = null;
      },
      [fulFilled]: (state, action) => {
        const user = action.payload;
        localStorage.setItem("user", JSON.stringify(user));
        state.user = user;
      },
      [rejected]: (state, action) => {
        state.error = action.error;
        state.user = null;
        localStorage.removeItem("user");
      },
    };
  }

  function logout() {
    var { pending, fulFilled, rejected } = extraActions.logout;

    return {
      [pending]: (state) => {
        state.error = null;
      },
      [fulFilled]: (state, action) => {
        state.user = null;
        localStorage.removeItem("user");
      },
      [rejected]: (state, action) => {
        state.error = action.error;
        state.user = null;
        localStorage.removeItem("user");
      },
    };
  }
}
