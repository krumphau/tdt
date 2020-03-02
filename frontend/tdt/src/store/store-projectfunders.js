import axios from 'axios'

const state = {
  projectFunders: []
}

const mutations = {
  setProjectFunders: (state, { projectFunders }) => {
    state.projectFunders = projectFunders
  },
  deleteProjectFunder: (state, { id }) => {
    let idx = state.funders.map(p => p.id).indexOf(id)
    state.projectFunders.splice(idx, 1)
  },
  addProjectFunder: (state, { funder }) => {
    state.projectFunders.push(funder)
  }
}

const actions = {
  addProjectFunder: function ({ commit }, { item }) {
    axios.post('http://localhost:5000/projectfunder', item).then((response) => {
      commit('addProjectFunder', { funder: item })
    }, () => {
      return false
    })
  },
  deleteProjectFunder: function ({ commit, state }, id) {
    axios.delete('http://localhost:5000/projectfunder/' + id).then((response) => {
      commit('deleteProjectFunder', { id: id })
    }, () => {
      return false
    })
  },
  loadProjectFunders: function ({ commit, state }, id) {
    axios.get('http://localhost:5000/projectfunder/' + id).then((response) => {
      commit('setProjectFunders', { projectFunders: response.data })
    }, () => {
      return false
    })
  }
}

const getters = {
  projectFunders: (state) => {
    return state.projectFunders
  },
  getProjectFunderById: (state) => (id) => {
    return state.projectFunders.find(projectFunders => projectFunders.Id === id)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
