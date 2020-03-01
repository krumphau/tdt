import axios from 'axios'

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
    axios.get('http://localhost:5000/categories').then((response) => {
      context.commit('setCategories', { categories: response.data })
      return true
    }, (err) => {
      console.log(err)
      return false
    })
  },
  addCategory: function ({ commit }, { item }) {
    axios.post('http://localhost:5000/category', item).then((response) => {
      commit('addCategory', { category: item })
    }, (err) => {
      console.log(err)
    })
  },
  deleteCategory: function ({ commit, state }, id) {
    axios.delete('http://localhost:5000/category/' + id).then((response) => {
      commit('deleteCategory', { id: id })
    }, (err) => {
      console.log(err)
    })
  },
  updateCategory: function ({ commit, state }, { item }) {
    axios.put('http://localhost:5000/category/' + item.Id, item).then((response) => {
      commit('updateCategory', { item: item })
    }, (err) => {
      console.log(err)
    })
  }
}

const getters = {
  categories: (state) => {
    return state.categories
  },
  getCategoryById: (state) => (id) => {
    return state.categories.find(categories => categories.Id === id)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
