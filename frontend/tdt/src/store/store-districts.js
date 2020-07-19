import axios from 'axios'
import storeSettings from './store-settings'

const state = {
  districts: []
}

const mutations = {
  setDistricts: (state, { districts }) => {
    state.districts = districts
  },
  updateDistrict: (state, { item }) => {
    let idx = state.districts.map(p => p.id).indexOf(item.id)
    state.districts.splice(idx, 1, item)
  },
  deleteDistrict: (state, { id }) => {
    let idx = state.districts.map(p => p.id).indexOf(id)
    state.districts.splice(idx, 1)
  },
  addDistrict: (state, { District }) => {
    state.districts.push(District)
  }
}

const actions = {
  loadDistricts: async function (context) {
    axios.get(storeSettings.state.baseUrl + 'districts', { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      context.commit('setDistricts', { districts: response.data })
      return true
    }, () => {
      return false
    })
  },
  addDistrict: function ({ commit }, { item }) {
    axios.post(storeSettings.state.baseUrl + 'districts', item, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('addDistrict', { District: response.data })
    }, () => {
      return false
    })
  },
  deleteDistrict: function ({ commit, state }, id) {
    axios.delete(storeSettings.state.baseUrl + 'district/' + id, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('deleteDistrict', { id: id })
    }, () => {
      return false
    })
  },
  updateDistrict: function ({ commit, state }, { item }) {
    axios.put(storeSettings.state.baseUrl + 'district/' + item.Id, item, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('updateDistrict', { item: item })
    }, () => {
      return false
    })
  }
}

const getters = {
  districts: (state) => {
    return state.districts
  },
  getDistrictById: (state) => (id) => {
    return state.districts.find(districts => districts.id === id)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
