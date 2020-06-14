import axios from 'axios'
import storeSettings from './store-settings'

const state = {
  projectFunders: []
}

const mutations = {
  setProjectFunders: (state, { projectFunders }) => {
    state.projectFunders = projectFunders
  },
  deleteProjectFunder: (state, { id }) => {
    let idx = state.funders.map(p => p.id).indexOf(id)
    state.projectFunders.splice(idx, 1)
  },
  addProjectFunder: (state, { funder }) => {
    state.projectFunders.push(funder)
  }
}

const actions = {
  addProjectFunder: function ({ commit }, { item }) {
    axios.post(storeSettings.state.baseUrl + 'projectfunder', item, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('addProjectFunder', { funder: item })
    }, () => {
      return false
    })
  },
  deleteProjectFunder: function ({ commit, state }, id) {
    axios.delete(storeSettings.state.baseUrl + 'projectfunder/' + id, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('deleteProjectFunder', { id: id })
    }, () => {
      return false
    })
  },
  loadProjectFunders: function ({ commit, state }, id) {
    axios.get(storeSettings.state.baseUrl + 'projectfunder/' + id, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('setProjectFunders', { projectFunders: response.data })
    }, () => {
      return false
    })
  }
}

const getters = {
  projectFunders: (state) => {
    return state.projectFunders
  },
  getProjectFunderById: (state) => (id) => {
    return state.projectFunders.find(projectFunders => projectFunders.id === id)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
