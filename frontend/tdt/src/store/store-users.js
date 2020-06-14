import axios from 'axios'
import storeSettings from './store-settings'

const state = {
  isAuthenticated: false,
  user: {},
  loading: false
}

const mutations = {
  setAuthenticated: (state, { isAuth }) => {
    state.isAuthenticated = isAuth
  },
  setUser: (state, { user }) => {
    state.user = user
  },
  setLoading: (state, { isLoading }) => {
    state.loading = isLoading
  }
}

const actions = {
  getUser: function ({ commit, state }, email) {
    commit('setLoading', { isLoading: true })
    axios.get(storeSettings.state.baseUrl + 'user/' + email, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('setUser', { user: response.data })
      commit('setLoading', { isLoading: false })
    }, () => {
      return false
    })
  }
}

const getters = {
  isAuthenticated: (state) => {
    return state.isAuthenticated
  },
  user: (state) => {
    return state.user
  },
  loading: (state) => {
    return state.loading
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
