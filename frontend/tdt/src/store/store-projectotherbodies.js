import axios from 'axios'
import storeSettings from './store-settings'

const state = {
  projectOtherBodies: []
}

const mutations = {
  setProjectOtherBodies: (state, { projectOtherBodies }) => {
    state.projectOtherBodies = projectOtherBodies
  },
  deleteProjectOtherBody: (state, { id }) => {
    let idx = state.projectOtherBodies.map(p => p.id).indexOf(id)
    state.projectOtherBodies.splice(idx, 1)
  },
  addProjectOtherBody: (state, { projectOtherBody }) => {
    state.projectOtherBodies.push(projectOtherBody)
  }
}

const actions = {
  addProjectOtherBody: function ({ commit }, { item }) {
    axios.post(storeSettings.state.baseUrl + 'projectotherbody', item, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('addProjectOtherBody', { projectOtherBody: item })
    }, () => {
      return false
    })
  },
  deleteProjectOtherBody: function ({ commit, state }, id) {
    axios.delete(storeSettings.state.baseUrl + 'projectotherbody/' + id, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('deleteProjectOtherBody', { id: id })
    }, () => {
      return false
    })
  },
  loadProjectOtherBodies: function ({ commit, state }, id) {
    axios.get(storeSettings.state.baseUrl + 'projectotherbody/' + id, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('setProjectOtherBodies', { projectOtherBodies: response.data })
    }, () => {
      return false
    })
  }
}

const getters = {
  projectOtherBodies: (state) => {
    return state.projectOtherBodies
  },
  getProjectOtherBodyById: (state) => (id) => {
    return state.projectOtherBodies.find(projectOtherBodies => projectOtherBodies.Id === id)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
