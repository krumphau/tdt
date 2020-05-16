import axios from 'axios'
import storeSettings from './store-settings'

const state = {
  isAuthenticated: false,
  user: {}
}

const mutations = {
  setAuthenticated: (state, { isAuth }) => {
    state.isAuthenticated = isAuth
  },
  setUser: (state, { user }) => {
    state.user = user
  }
}

const actions = {
  getUser: function ({ commit, state }, email) {
    axios.get(storeSettings.state.baseUrl + 'user/' + email, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('setUser', { user: response.data })
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
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
