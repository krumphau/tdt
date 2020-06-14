import axios from 'axios'
import storeSettings from './store-settings'

const state = {
  regions: []
}

const mutations = {
  setRegions: (state, { regions }) => {
    state.regions = regions
  },
  updateRegion: (state, { item }) => {
    let idx = state.regions.map(p => p.id).indexOf(item.id)
    state.regions.splice(idx, 1, item)
  },
  deleteRegion: (state, { id }) => {
    let idx = state.regions.map(p => p.id).indexOf(id)
    state.regions.splice(idx, 1)
  },
  addRegion: (state, { region }) => {
    state.regions.push(region)
  }
}

const actions = {
  loadRegions: async function (context) {
    axios.get(storeSettings.state.baseUrl + 'regions', { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      context.commit('setRegions', { regions: response.data })
      return true
    }, () => {
      return false
    })
  },
  addRegion: function ({ commit }, { item }) {
    axios.post(storeSettings.state.baseUrl + 'regions', item, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('addRegion', { region: item })
    }, () => {
      return false
    })
  },
  deleteRegion: function ({ commit, state }, id) {
    axios.delete(storeSettings.state.baseUrl + 'region/' + id, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('deleteRegion', { id: id })
    }, () => {
      return false
    })
  },
  updateRegion: function ({ commit, state }, { item }) {
    axios.put(storeSettings.state.baseUrl + 'region/' + item.Id, item, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('updateRegion', { item: item })
    }, () => {
      return false
    })
  }
}

const getters = {
  regions: (state) => {
    return state.regions
  },
  getRegionById: (state) => (id) => {
    return state.regions.find(regions => regions.id === id)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
