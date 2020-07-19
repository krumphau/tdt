import axios from 'axios'
import storeSettings from './store-settings'

const state = {
  purchasedItems: []
}

const mutations = {
  setPurchasedItems: (state, { purchasedItems }) => {
    state.purchasedItems = purchasedItems
  },
  deletePurchasedItem: (state, { id }) => {
    let idx = state.purchasedItems.map(p => p.id).indexOf(id)
    state.purchasedItems.splice(idx, 1)
  },
  addPurchasedItem: (state, { purchasedItem }) => {
    state.purchasedItems.push(purchasedItem)
  },
  updatePurchasedItem: (state, { item }) => {
    let idx = state.purchasedItems.map(p => p.id).indexOf(item.id)
    state.purchasedItems.splice(idx, 1, item)
  }
}

const actions = {
  addPurchasedItem: function ({ commit }, { item }) {
    axios.post(storeSettings.state.baseUrl + 'purchaseditem', item, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('addPurchasedItem', { purchasedItem: response.data })
    }, () => {
      return false
    })
  },
  deletePurchasedItem: function ({ commit, state }, id) {
    axios.delete(storeSettings.state.baseUrl + 'purchaseditems/' + id, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('deletePurchasedItem', { id: id })
    }, () => {
      return false
    })
  },
  loadPurchasedItems: function ({ commit, state }, id) {
    axios.get(storeSettings.state.baseUrl + 'purchaseditems/' + id, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('setPurchasedItems', { purchasedItems: response.data })
    }, () => {
      return false
    })
  },
  updatePurchasedItem: function ({ commit, state }, { item }) {
    axios.put(storeSettings.state.baseUrl + 'purchaseditem/' + item.Id, item, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('updatePurchasedItem', { item: item })
    }, () => {
      return false
    })
  }
}

const getters = {
  purchasedItems: (state) => {
    return state.purchasedItems
  },
  getPurchasedItemById: (state) => (id) => {
    return state.purchasedItems.find(purchasedItems => purchasedItems.id === id)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
