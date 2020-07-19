import axios from 'axios'
import storeSettings from './store-settings'

const state = {
  NGOs: []
}

const mutations = {
  setNGOs: (state, { NGOs }) => {
    state.NGOs = NGOs
  },
  updateNGO: (state, { item }) => {
    let idx = state.NGOs.map(p => p.id).indexOf(item.id)
    state.NGOs.splice(idx, 1, item)
  },
  deleteNGO: (state, { id }) => {
    let idx = state.NGOs.map(p => p.id).indexOf(id)
    state.NGOs.splice(idx, 1)
  },
  addNGO: (state, { NGO }) => {
    state.NGOs.push(NGO)
  }
}

const actions = {
  loadNGOs: async function (context) {
    axios.get(storeSettings.state.baseUrl + 'ngos', { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      context.commit('setNGOs', { NGOs: response.data })
      return true
    }, () => {
      return false
    })
  },
  addNGO: function ({ commit }, { item }) {
    axios.post(storeSettings.state.baseUrl + 'ngos', item, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('addNGO', { NGO: response.data })
    }, () => {
      return false
    })
  },
  deleteNGO: function ({ commit, state }, id) {
    axios.delete(storeSettings.state.baseUrl + 'ngo/' + id, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('deleteNGO', { id: id })
    }, () => {
      return false
    })
  },
  updateNGO: function ({ commit, state }, { item }) {
    axios.put(storeSettings.state.baseUrl + 'ngo/' + item.Id, item, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('updateNGO', { item: item })
    }, () => {
      return false
    })
  }
}

const getters = {
  NGOs: (state) => {
    return state.NGOs
  },
  getNGOById: (state) => (id) => {
    return state.NGOs.find(NGOs => NGOs.id === id)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
