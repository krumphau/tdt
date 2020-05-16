import axios from 'axios'
import storeSettings from './store-settings'

const state = {
  projectVisits: []
}

const mutations = {
  setProjectVisits: (state, { projectVisits }) => {
    state.projectVisits = projectVisits
  },
  deleteProjectVisit: (state, { id }) => {
    let idx = state.projectVisits.map(p => p.id).indexOf(id)
    state.projectVisits.splice(idx, 1)
  },
  addProjectVisit: (state, { projectVisit }) => {
    state.projectVisits.push(projectVisit)
  },
  updateProjectVisit: (state, { item }) => {
    let idx = state.projectVisits.map(p => p.id).indexOf(item.id)
    state.projectVisits.splice(idx, 1, item)
  }
}

const actions = {
  addProjectVisit: function ({ commit }, { item }) {
    axios.post(storeSettings.state.baseUrl + 'projectvisit', item, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('addProjectVisit', { projectVisit: item })
    }, () => {
      return false
    })
  },
  deleteProjectVisit: function ({ commit, state }, id) {
    axios.delete(storeSettings.state.baseUrl + 'projectvisit/' + id, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('deleteProjectVisit', { id: id })
    }, () => {
      return false
    })
  },
  loadProjectVisits: function ({ commit, state }, id) {
    axios.get(storeSettings.state.baseUrl + 'projectvisit/' + id, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('setProjectVisits', { projectVisits: response.data })
    }, () => {
      return false
    })
  },
  updateProjectVisit: function ({ commit, state }, { item }) {
    axios.put(storeSettings.state.baseUrl + 'projectvisit/' + item.Id, item, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('updateProjectVisit', { item: item })
    }, () => {
      return false
    })
  }
}

const getters = {
  projectVisits: (state) => {
    return state.projectVisits
  },
  getProjectVisitById: (state) => (id) => {
    return state.projectVisits.find(projectVisits => projectVisits.Id === id)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
