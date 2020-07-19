import axios from 'axios'
import storeSettings from './store-settings'

const state = {
  projectDocuments: []
}

const mutations = {
  setProjectDocuments: (state, { projectDocuments }) => {
    state.projectDocuments = projectDocuments
  },
  deleteProjectDocument: (state, { id }) => {
    let idx = state.projectDocuments.map(p => p.id).indexOf(id)
    state.projectDocuments.splice(idx, 1)
  },
  addProjectDocument: (state, { document }) => {
    state.projectDocuments.push(document)
  }
}

const actions = {
  addProjectDocument: function ({ commit }, { item }) {
    axios.post(storeSettings.state.baseUrl + 'projectdocument', item, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('addProjectDocument', { document: response.data })
    }, () => {
      return false
    })
  },
  deleteProjectDocument: function ({ commit, state }, id) {
    axios.delete(storeSettings.state.baseUrl + 'projectdocument/' + id, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('deleteProjectDocument', { id: id })
    }, () => {
      return false
    })
  },
  loadProjectDocuments: function ({ commit, state }, id) {
    axios.get(storeSettings.state.baseUrl + 'projectdocument/' + id, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('setProjectDocuments', { projectDocuments: response.data })
    }, () => {
      return false
    })
  },
  uploadFile: function ({ commit }, { fileData, projectId }) {
    axios.post(storeSettings.state.baseUrl + 'upload/' + projectId, fileData, {
      headers: { 'Content-Type': 'multipart/form-data', 'x-api-key': storeSettings.state.apiKey }
    }).then((response) => {
      return response.data
    }, () => {
      return false
    })
  }
}

const getters = {
  projectDocuments: (state) => {
    return state.projectDocuments
  },
  getProjectDocumentById: (state) => (id) => {
    return state.projectDocuments.find(projectDocuments => projectDocuments.id === id)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
