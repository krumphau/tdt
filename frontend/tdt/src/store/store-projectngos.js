import axios from 'axios'

const state = {
  projectNGOs: []
}

const mutations = {
  setProjectNGOs: (state, { projectNGOs }) => {
    state.projectNGOs = projectNGOs
  },
  deleteProjectNGO: (state, { id }) => {
    let idx = state.ngos.map(p => p.id).indexOf(id)
    state.projectNGOs.splice(idx, 1)
  },
  addProjectNGO: (state, { ngo }) => {
    state.projectNGOs.push(ngo)
  }
}

const actions = {
  addProjectNGO: function ({ commit }, { item }) {
    axios.post('http://localhost:5000/projectngo', item).then((response) => {
      commit('addProjectNGO', { ngo: item })
    }, () => {
      return false
    })
  },
  deleteProjectNGO: function ({ commit, state }, id) {
    axios.delete('http://localhost:5000/projectngo/' + id).then((response) => {
      commit('deleteProjectNGO', { id: id })
    }, () => {
      return false
    })
  },
  loadProjectNGOs: function ({ commit, state }, id) {
    axios.get('http://localhost:5000/projectngo/' + id).then((response) => {
      commit('setProjectNGOs', { projectNGOs: response.data })
    }, () => {
      return false
    })
  }
}

const getters = {
  projectNGOs: (state) => {
    return state.projectNGOs
  },
  getProjectNGOById: (state) => (id) => {
    return state.projectNGOs.find(projectNGOs => projectNGOs.Id === id)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}