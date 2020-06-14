import axios from 'axios'
import storeSettings from './store-settings'

const state = {
  funders: []
}

const mutations = {
  setFunders: (state, { funders }) => {
    state.funders = funders
  },
  updateFunder: (state, { item }) => {
    let idx = state.funders.map(p => p.id).indexOf(item.id)
    state.funders.splice(idx, 1, item)
  },
  deleteFunder: (state, { id }) => {
    let idx = state.funders.map(p => p.id).indexOf(id)
    state.funders.splice(idx, 1)
  },
  addFunder: (state, { funder }) => {
    state.funders.push(funder)
  }
}

const actions = {
  loadFunders: async function (context) {
    axios.get(storeSettings.state.baseUrl + 'funders', { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      context.commit('setFunders', { funders: response.data })
      return true
    }, () => {
      return false
    })
  },
  addFunder: function ({ commit }, { item }) {
    axios.post(storeSettings.state.baseUrl + 'funder', item, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('addFunder', { funder: item })
    }, () => {
      return false
    })
  },
  deleteFunder: function ({ commit, state }, id) {
    axios.delete(storeSettings.state.baseUrl + 'funder/' + id, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('deleteFunder', { id: id })
    }, () => {
      return false
    })
  },
  updateFunder: function ({ commit, state }, { item }) {
    axios.put(storeSettings.state.baseUrl + 'funder/' + item.Id, item, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('updateFunder', { item: item })
    }, () => {
      return false
    })
  }
}

const getters = {
  funders: (state) => {
    return state.funders
  },
  getFunderById: (state) => (id) => {
    return state.funders.find(funders => funders.id === id)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
