import axios from 'axios'

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
  }
}

const actions = {
  addPurchasedItem: function ({ commit }, { item }) {
    axios.post('http://localhost:5000/purchaseditems', item).then((response) => {
      commit('addPurchasedItem', { purchasedItem: item })
    }, () => {
      return false
    })
  },
  deletePurchasedItem: function ({ commit, state }, id) {
    axios.delete('http://localhost:5000/purchaseditems/' + id).then((response) => {
      commit('deletePurchasedItem', { id: id })
    }, () => {
      return false
    })
  },
  loadPurchasedItems: function ({ commit, state }, id) {
    axios.get('http://localhost:5000/purchaseditems/' + id).then((response) => {
      commit('setPurchasedItems', { purchasedItems: response.data })
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
    return state.purchasedItems.find(purchasedItems => purchasedItems.Id === id)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
