import axios from 'axios'
import storeSettings from './store-settings'

const state = {
  projectCategories: []
}

const mutations = {
  setProjectCategories: (state, { projectCategories }) => {
    state.projectCategories = projectCategories
  },
  deleteProjectCategory: (state, { id }) => {
    let idx = state.categories.map(p => p.id).indexOf(id)
    state.projectCategories.splice(idx, 1)
  },
  addProjectCategory: (state, { category }) => {
    state.projectCategories.push(category)
  }
}

const actions = {
  addProjectCategory: function ({ commit }, { item }) {
    axios.post(storeSettings.state.baseUrl + 'projectcategory', item, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('addProjectCategory', { category: item })
    }, () => {
      return false
    })
  },
  deleteProjectCategory: function ({ commit, state }, id) {
    axios.delete(storeSettings.state.baseUrl + 'projectcategory/' + id, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('deleteProjectCategory', { id: id })
    }, () => {
      return false
    })
  },
  loadProjectCategories: function ({ commit, state }, id) {
    axios.get(storeSettings.state.baseUrl + 'projectcategory/' + id, { headers: { 'x-api-key': storeSettings.state.apiKey } }).then((response) => {
      commit('setProjectCategories', { projectCategories: response.data })
    }, () => {
      return false
    })
  }
}

const getters = {
  projectCategories: (state) => {
    return state.projectCategories
  },
  getProjectCategoryById: (state) => (id) => {
    return state.projectCategories.find(projectCategories => projectCategories.Id === id)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
