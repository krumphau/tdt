import axios from 'axios'

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
    axios.post('http://localhost:5000/projectcategory', item).then((response) => {
      commit('addProjectCategory', { category: item })
    }, () => {
      return false
    })
  },
  deleteProjectCategory: function ({ commit, state }, id) {
    axios.delete('http://localhost:5000/projectcategory/' + id).then((response) => {
      commit('deleteProjectCategory', { id: id })
    }, () => {
      return false
    })
  },
  loadProjectCategories: function ({ commit, state }, id) {
    axios.get('http://localhost:5000/projectcategory/' + id).then((response) => {
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
