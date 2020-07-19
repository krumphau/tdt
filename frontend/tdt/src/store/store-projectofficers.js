import axios from 'axios'
import storeSettings from './store-settings'

const state = {
  projectOfficers: []
}

const mutations = {
  setProjectOfficers: (state, { projectOfficers }) => {
    state.projectOfficers = projectOfficers
  },
  updateProjectOfficer: (state, { item }) => {
    let idx = state.projectOfficers.map(p => p.id).indexOf(item.id)
    state.projectOfficers.splice(idx, 1, item)
  },
  deleteProjectOfficer: (state, { id }) => {
    let idx = state.projectOfficers.map(p => p.id).indexOf(id)
    state.projectOfficers.splice(idx, 1)
  },
  addProjectOfficer: (state, { projectOfficer }) => {
    state.projectOfficers.push(projectOfficer)
  }
}

const actions = {
  loadProjectOfficers: async function (context) {
    axios.get(storeSettings.state.baseUrl + 'projectofficers', { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      context.commit('setProjectOfficers', { projectOfficers: response.data })
      return true
    }, () => {
      return false
    })
  },
  addProjectOfficer: function ({ commit }, { item }) {
    axios.post(storeSettings.state.baseUrl + 'projectofficers', item, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('addProjectOfficer', { projectOfficer: response.data })
    }, () => {
      return false
    })
  },
  deleteProjectOfficer: function ({ commit, state }, id) {
    axios.delete(storeSettings.state.baseUrl + 'projectofficer/' + id, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('deleteProjectOfficer', { id: id })
    }, () => {
      return false
    })
  },
  updateProjectOfficer: function ({ commit, state }, { item }) {
    axios.put(storeSettings.state.baseUrl + 'projectofficer/' + item.Id, item, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('updateProjectOfficer', { item: item })
    }, () => {
      return false
    })
  }
}

const getters = {
  projectOfficers: (state) => {
    return state.projectOfficers
  },
  getProjectOfficerById: (state) => (id) => {
    return state.projectOfficers.find(projectOfficers => projectOfficers.id === id)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
