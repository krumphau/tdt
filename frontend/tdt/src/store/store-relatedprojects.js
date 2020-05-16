import axios from 'axios'
import storeSettings from './store-settings'

const state = {
  relatedProjects: []
}

const mutations = {
  setRelatedProjects: (state, { relatedProjects }) => {
    state.relatedProjects = relatedProjects
  },
  deleteRelatedProject: (state, { id }) => {
    let idx = state.relatedProjects.map(p => p.id).indexOf(id)
    state.relatedProjects.splice(idx, 1)
  },
  addRelatedProject: (state, { relatedProject }) => {
    state.relatedProjects.push(relatedProject)
  }
}

const actions = {
  addRelatedProject: function ({ commit }, { item }) {
    axios.post(storeSettings.state.baseUrl + 'relatedproject', item, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('addRelatedProject', { relatedProject: item })
    }, () => {
      return false
    })
  },
  deleteRelatedProject: function ({ commit, state }, id) {
    axios.delete(storeSettings.state.baseUrl + 'relatedproject/' + id, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('deleteRelatedProject', { id: id })
    }, () => {
      return false
    })
  },
  loadRelatedProjects: function ({ commit, state }, id) {
    axios.get(storeSettings.state.baseUrl + 'relatedproject/' + id, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('setRelatedProjects', { relatedProjects: response.data })
    }, () => {
      return false
    })
  }
}

const getters = {
  relatedProjects: (state) => {
    return state.relatedProjects
  },
  getRelatedProjectById: (state) => (id) => {
    return state.relatedProjects.find(relatedProjects => relatedProjects.Id === id)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
