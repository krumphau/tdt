import axios from 'axios'
import storeSettings from './store-settings'

const state = {
  categories: []
}

const mutations = {
  setCategories: (state, { categories }) => {
    state.categories = categories
  },
  updateCategory: (state, { item }) => {
    let idx = state.categories.map(p => p.id).indexOf(item.id)
    state.categories.splice(idx, 1, item)
  },
  deleteCategory: (state, { id }) => {
    let idx = state.categories.map(p => p.id).indexOf(id)
    state.categories.splice(idx, 1)
  },
  addCategory: (state, { category }) => {
    state.categories.push(category)
  }
}

const actions = {
  loadCategories: async function (context) {
    axios.get(storeSettings.state.baseUrl + 'categories', { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      context.commit('setCategories', { categories: response.data })
      return true
    }, () => {
      return false
    })
  },
  addCategory: function ({ commit }, { item }) {
    axios.post(storeSettings.state.baseUrl + 'categories', item, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('addCategory', { category: response.data })
    }, () => {
      return false
    })
  },
  deleteCategory: function ({ commit, state }, id) {
    axios.delete(storeSettings.state.baseUrl + 'category/' + id, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('deleteCategory', { id: id })
    }, () => {
      return false
    })
  },
  updateCategory: function ({ commit, state }, { item }) {
    axios.put(storeSettings.state.baseUrl + 'category/' + item.Id, item, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('updateCategory', { item: item })
    }, () => {
      return false
    })
  }
}

const getters = {
  categories: (state) => {
    return state.categories
  },
  getCategoryById: (state) => (id) => {
    return state.categories.find(categories => categories.id === id)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
